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
    public class TcpOctopusCardHelper
    {
        public static readonly TcpOctopusCardHelper Instance = new TcpOctopusCardHelper();
        private TcpOctopusCardHelper()
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
        static volatile JObject json = new JObject();
        int closeWhile = 0;
        int sendWhile = 0;
        bool stop = false;
        string reply = "";
        string cmd = "";
        AutoResetEvent resetEvent = new AutoResetEvent(false);
        Thread reader = null;
        Thread syncThread = null;
        Thread heart = null;
        UIData uiData = null;
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
                        client.ReceiveTimeout = 35000;
                        client.Connect("127.0.0.1", 9080);//发送连接的地址和端口
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

        void Read()
        {
            uiData = new UIData();
            List<byte> datapool = new List<byte>();
            closeWhile = 0;
            while (!stop)
            {
                Thread.Sleep(30);
                
             //   LogHelper.Log("线程拿到八达通信息" + closeWhile );
                closeWhile++;
                       
                try
                {
                    if (sm == null || !sm.DataAvailable) continue;

                    var rbuf = new byte[2048];
                    var pos = sm.Read(rbuf, 0, rbuf.Length);
                    datapool.AddRange(rbuf.Take(pos));
                    while (datapool.Count > 0)
                    {
                        datastr = string.Empty;
                        json = null;

                        var headerbuf = datapool.Take(800).ToArray();
                        var headerstr = Encoding.Unicode.GetString(headerbuf).Trim('\0');
                        json = JsonHelper.ToObject(headerstr);
                        uiData.CardReply = json["Reply"].ToString();//拿到读取重量的状态
                        uiData.CardOTime = json["OTime"].ToString();//八達通付款時間E:\wokefile\EBoxClient\Debugger.cs
                        uiData.CardOCardNo = json["OCardNo"].ToString();//八達通卡號
                        uiData.CardOAmount = json["OAmount"].ToString();//八達通金額
                        uiData.CardCmd = json["Cmd"].ToString();
                        cmd = json["Cmd"].ToString();
                        reply = json["Reply"].ToString();
                     
             
                        if(reply!=""||reply!=null)
                        {
                            datapool.RemoveRange(0, datapool.Count);
                            resetEvent.Set(); 
                        } 
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex);
                }
               // LogHelper.Log("线程退出" + stop);
            }
        }


        void syncData()
        {
            while (!stop)
            {
                Thread.Sleep(20);
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
      
       

        public string svse()
        {
            var re=reply;
            if (cmd == "0")
            {
                //判断八达通是否连接成功
               // LogHelper.Log(reply + "是否连接八达通成功！！！");
            }
            else if (cmd == "1") //八达通洗衣扣款
            {
                if (reply == "1")
                {
                    //扣款成功
                    var OAmount = uiData.CardOAmount;
                    var OTime = uiData.CardOTime;
                    var OCardNo = uiData.CardOCardNo;
                }
            }
            else if (cmd == "2")            //八达通取衣扣款
            {
                if (reply == "1")
                {
                    //扣款成功
                    var OAmount = uiData.CardOAmount;
                    var OTime = uiData.CardOTime;
                    var OCardNo = uiData.CardOCardNo;
                }
            }
        //   LogHelper.Log("线程收到八达通信息" + cmd+reply);

            //InvokeJs("JumpOpenDoor");
            return re;
        }

        public string Send(string cmd)
        {
            reader.Abort();
            try
            {
                if (!IsConnected) Connect();
                if (!IsConnected) return string.Empty;
                var json = JsonHelper.ToObject(cmd);
                reader = new Thread(new ThreadStart(Read));
                reader.IsBackground = true;
                reader.Start();
                
                uiData.CardReply="";
                uiData.CardCmd="";
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
                        reply = "";
                        if (Setting.Instance.IsDebug)
                            LogHelper.Log("发送消息：" + cmd);
                            
                    }
                    resetEvent.WaitOne(35000, false);
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
            reply = "";
        }

        public void Stop()
        { stop = true; }

        public void MockRecData(string data)
        {
            syncDataQueue.Enqueue(data);
        }
    }
}