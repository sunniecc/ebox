using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using EBoxClient.Entity;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace EBoxClient.Utils
{
    public class TcpClientHelper
    {
        public static readonly TcpClientHelper Instance = new TcpClientHelper();
        private TcpClientHelper()
        {
        }
        public bool IsConnected
        {
            get 
            {
                bool okConnectes = client != null && client.Connected;
                if(!okConnectes)
                {
                    LogHelper.Log("网络连接异常");
                }
                return okConnectes; 
            }
        }

        private bool isAlive;
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        static volatile TcpClient client = null;
        static volatile NetworkStream sm = null;
        static readonly object locker = new object();
        static volatile string datastr = string.Empty;
        bool stop = false;

        AutoResetEvent resetEvent = new AutoResetEvent(false);
        Thread reader = null;
        Thread syncThread = null;
        Thread heart = null;
        public event Action<TcpClient> OnConnectFailed;
        static volatile Queue<string> cmdQueue = new Queue<string>();
        static volatile Queue<string> syncDataQueue = new Queue<string>();
        public void Connect()
        {
            if (client == null || !client.Connected)
            {
                try
                {
                    lock (locker)
                    {
                        client = new TcpClient();
                        client.ReceiveTimeout = 10000;
                        client.Connect(Setting.Instance.ServerHost, Setting.Instance.ServerPort);//发送连接的地址和端口
                        sm = client.GetStream();//返回一个可用来发送和接收数据的 NetworkStream
                        stop = false;
                        Service.Instance.programLogin("SYS", Convert.ToInt32(Setting.Instance.BoxID), Setting.Instance.BoxNo);
                        if (reader == null)
                        {
                            reader = new Thread(new ThreadStart(Read));
                            reader.IsBackground = true;
                            reader.Start();
                        }
                        if (syncThread == null)
                        {
                            syncThread = new Thread(new ThreadStart(syncData));
                            syncThread.IsBackground = true;
                            syncThread.Start();
                        }
                        if (heart == null)
                        {
                            heart = new Thread(new ThreadStart(StartHeartBeat));
                            heart.IsBackground = true;
                            heart.Start();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Log("链接服务器失败,稍后重试...", ex);
                    if (OnConnectFailed != null) OnConnectFailed(client);
                }
            }
        }

        public void Close()
        {
            if (IsConnected)
                client.Close();
        }

        void Read()
        {
            List<byte> datapool = new List<byte>();
            while (!stop)
            {
                Thread.Sleep(1000);
                try
                {
                    if (sm == null || !sm.DataAvailable) continue;

                    var rbuf = new byte[2048];
                    var pos = sm.Read(rbuf, 0, rbuf.Length);
                    datapool.AddRange(rbuf.Take(pos));

                    while (datapool.Count > 0)
                    {
                        datastr = string.Empty;
                        var headerbuf = datapool.Take(100).ToArray();
                        var headerstr = Encoding.UTF8.GetString(headerbuf).Trim('\0');
                        var len = Regex.Match(headerstr, "[^EB:]*?EB:(\\d+)E{");
                        if (!len.Success)
                        {
                            LogHelper.Log("服务器返回格式错误,消息头部:" + headerstr);
                            datapool.Clear();
                            break;
                        }
                        else
                        {
                            if (Setting.Instance.IsDebug)
                                LogHelper.Log("接收消息,消息头部：" + headerstr);

                            var dataLen = Convert.ToInt32(len.Groups[1].Value);
                            var totalLen = len.Value.Length - 1 + dataLen;
                            var leftLen = totalLen - datapool.Count;
                            while (leftLen > 0)
                            {
                                var leftBuf = new byte[leftLen];
                                var leftPos = sm.Read(leftBuf, 0, leftBuf.Length);
                                datapool.AddRange(leftBuf.Take(leftPos));
                                leftLen -= leftPos;
                            }
                            datastr = Encoding.UTF8.GetString(
                               datapool.Skip(len.Value.Length - 1)
                               .Take(dataLen).ToArray()).Trim('\0');
                            //datastr = MyRSA.Decrypt(datastr).Trim('\0');
                            var usedLen = len.Value.Length - 1 + dataLen;
                            datapool.RemoveRange(0, Math.Min(totalLen, datapool.Count));

                            if (Setting.Instance.IsDebug)
                                LogHelper.Log("接收消息：" + datastr);
                            var json = JsonHelper.ToObject(datastr);
                            var action = json["action"];
                            var type = json["type"];
                            if (action == null || type == null)
                            {
                                LogHelper.Log("收到内容与协议不相符");
                            }
                            else if (action.ToString().ToLower() == "synchronous")
                            {
                                lock (locker)
                                {
                                    syncDataQueue.Enqueue(datastr);
                                }
                            }
                            else
                            {
                                lock (locker)
                                {
									var inQueue = false;
                                    inQueue = cmdQueue.Count > 0 && cmdQueue.Peek() == action + "_" + type;
									if (inQueue)
									{
										resetEvent.Set();
									}
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex);
                }
            }
        }

        void syncData()
        {
            while (!stop)
            {
                Thread.Sleep(1000);
                while (syncDataQueue.Count > 0)
                {
                    try
                    {
                        var data = string.Empty;
                        lock (locker)
                        {
                            data = syncDataQueue.Dequeue();
                        }
                        var json = JsonHelper.ToObject(data);
                        var table = json["type"];
                        var detail = json["returnValue"];
                        if (table != null)
                            LocalData.Instance.SyncData(table.ToString(), detail as JObject);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log("同步数据异常", ex);
                    }
                }
            }
        }

        public string Send(string cmd)
        {
            try
            {
                
                if (!IsConnected) Connect();
                if (!IsConnected) return string.Empty;
                var json = JsonHelper.ToObject(cmd);
                var action = json["action"];
                var type = json["type"];            
                if (action == null || type == null)
                {
                    LogHelper.Log("发送指令与协议不相符");
                    return string.Empty;
                }
                //cmd = MyRSA.Encrypt(cmd);
                var cmdLen = Encoding.UTF8.GetBytes(cmd).Length;
                var sendCmd = string.Format("EB:{0}E{1}", cmdLen, cmd);
                lock (locker)
                {
                    cmdQueue.Enqueue(action + "_" + type);
                }
                try
                {
                    var buf = Encoding.UTF8.GetBytes(sendCmd);
                    lock (locker)
                    {
                        sm.Write(buf, 0, buf.Length);
                        sm.Flush();

                        if (datastr==null)
                        {

                        }
                        if (Setting.Instance.IsDebug)
                            LogHelper.Log("发送消息：" + cmd);
                    }
                    resetEvent.WaitOne(10000, false);
                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex);
                }

                lock (locker)
                {
                    cmdQueue.Dequeue();
                }
                return datastr;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return string.Empty;
            }
        }

        void StartHeartBeat()
        {
            var cnt = 0L;
            while (!stop)
            {
                try
                {
                    Thread.Sleep(Setting.Instance.HeartBeatInterval + 200);
                    if (!IsConnected) continue;

                    Service.Instance.heartbeat(cnt);
                    cnt++;
                }
                catch (Exception ex)
                {
                    LogHelper.Log("发送心跳包异常", ex);
                }
            }
        }


        public void Stop()
        { stop = true; }

        public void MockRecData(string data)
        {
            syncDataQueue.Enqueue(data);
        }
    }
}