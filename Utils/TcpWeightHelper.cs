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
using Newtonsoft.Json;

namespace EBoxClient.Utils
{
    public class TcpWeightHelper
    {
        public static readonly TcpWeightHelper Instance = new TcpWeightHelper();
        private TcpWeightHelper()
        {
        }
        public bool IsConnected
        {
            get { return client != null && client.Connected; }
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
        int closeWhile = 0;
        int readbuffoffset = 0;
        string weight1 = "";
        AutoResetEvent resetEvent = new AutoResetEvent(false);
        Thread reader = null;
        Thread syncThread = null;
        Thread heart = null;
        UIData uiData = new UIData();
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
                        client.Connect("127.0.0.1",9070);//发送连接的地址和端口
                        sm = client.GetStream();//返回一个可用来发送和接收数据的 NetworkStream
                        stop = false;
                        //Service.Instance.programLogin("SYS", Convert.ToInt32(Setting.Instance.BoxID), Setting.Instance.BoxNo);
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
                      
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Log("链接失败,稍后重试...", ex);
                    if (OnConnectFailed != null) OnConnectFailed(client);
                }
            }
        }

        public void Close()
        {
            if (IsConnected)
                client.Close();
        }
        public class WeightClass
        {
            public string cmd;
            public string weight;
            public string reply;

        };

        void Read()
        {
            List<byte> datapool = null;
            datapool = new List<byte>();
            while (!stop)
            {
                Thread.Sleep(20);
                try
                {
                    if (sm == null || !sm.DataAvailable) continue;

                    var rbuf = new byte[2048];
                    var pos = sm.Read(rbuf, readbuffoffset, rbuf.Length);
                    datapool.AddRange(rbuf.Take(pos));
                    //LogHelper.Log("sm.Read:读取到数据没有嘛" + pos);
                    while (datapool.Count > 0)
                    {
                        datastr = string.Empty;
                        var headerbuf = datapool.Take(100).ToArray();
                        var headerstr = Encoding.Unicode.GetString(headerbuf).Trim('\0');
                        var json = JsonHelper.ToObject(headerstr);
                            WeightClass cWeight = JsonConvert.DeserializeObject<WeightClass>(headerstr);

                            var cmd = json["Cmd"];//拿到获取重量的状态
                            //var weight = json["Weight"];//拿到重量
                            var reply = json["Reply"];//拿到读取重量的状态
                            uiData.Weight = cWeight.weight; //cWeight.cmd;
                            uiData.FitCmd = cWeight.cmd.ToString();
                            uiData.FitReply = cWeight.reply.ToString();                 
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
                Thread.Sleep(50);
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
        //用來存儲電子稱返回的數據
        public string svse()
        {
            var weight1 = "";
            if (uiData.FitReply=="0")
            {
                weight1 = uiData.Weight;
                //电子称读取成功
            }
            else
            {
                return uiData.Weight;//电子称读取失败
            }
 
            return uiData.Weight;//电子称读取失败
        }

        public string Send(string cmd)
        {
            try
            {                
                if (!IsConnected) Connect();
                if (!IsConnected) return string.Empty;
                var json = JsonHelper.ToObject(cmd);
                reader.Abort();
                reader = new Thread(new ThreadStart(Read));
                reader.IsBackground = true;
                reader.Start();
                lock (locker)
                {
                    cmdQueue.Enqueue("WeightSend");
                }
                try
                {
                    var buf = Encoding.Unicode.GetBytes(cmd);
                    lock (locker)
                    {
                        sm.Write(buf, 0, buf.Length);
                        sm.Flush();
                      
                        if (Setting.Instance.IsDebug)
                            LogHelper.Log("发送消息：" + cmd);
                    }
                    resetEvent.WaitOne(50, false);
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

        public void InitDate()
        {
            uiData.Weight = "0";
            uiData.FitReply = "";
        }
        public void Stop()
        { stop = true; }

        public void MockRecData(string data)
        {
            syncDataQueue.Enqueue(data);
        }
    }
}