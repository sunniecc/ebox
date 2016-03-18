using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Utils;
using System.Threading;
using EBoxClient.Device.lc;


namespace EBoxClient.Device
{
    public class BoxDoor
    {
        //yodaCollection.pakpobox pakpobox = new yodaCollection.pakpobox();
        LockControl lockControl = new LockControl();
        public int BoardCount = 4;
        public int LockCount = 24;
        bool[,] Status;
        bool stop = false;
        bool opened = false;
        static object locker = new object();

        public void Init()
        {
            Status = new bool[BoardCount, LockCount];
            //pakpobox.Name = "COM" + Setting.Instance.ElcLockCOMPort;
            //pakpobox.Sets("COM" + Setting.Instance.ElcLockCOMPort, "38400,8,1,N");
            //opened = pakpobox.OpenPort();
            opened = lockControl.OpenPort("" + Setting.Instance.ElcLockCOMPort);
            if (!opened)
            {
                LogHelper.Log("电子锁串口打开失败");
            }
        }

        public bool[,] GetStatus()
        {
            LogHelper.Log("调用状态");
            lock (locker)
            {
                Status = new bool[BoardCount, LockCount];
                for (int i = 0; i < BoardCount; i++)
                {
                    try
                    {
                        //pakpobox.WriteBit(i, "aa", 0);
                        //string strReturn = pakpobox.ReturnValue().ToString();
                        string strReturn = lockControl.getLockStatus(i);
                        if (Setting.Instance.IsDebug)
                            LogHelper.Log("电子锁状态监测(板号" + i + ")：" + strReturn ?? "null");
                        if (strReturn != "读卡失败" && !string.IsNullOrEmpty(strReturn) && strReturn.Length > 3)
                        {
                            try
                            {
                                var arr = strReturn.Substring(3).Split(',');
                                for (int j = 0; j < Math.Min(arr.Length, Status.GetUpperBound(1)); j++)
                                {
                                    Status[i, j] = arr[j] == "0";
                                }
                            }
                            catch (Exception ex)
                            {
                                LogHelper.Log("电子锁状态解析异常", ex);
                            }
                        }
                        if (Setting.Instance.IsDebug)
                            LogHelper.Log("更新完成");
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log("电子锁状态监测异常", ex);
                    }
                }
                return Status;
            }
        }
        /**
        public void Start()
        {
            stop = false;
            Status = new bool[BoardCount, LockCount];
            Thread th = new Thread(new ThreadStart(() =>
            {
                // while (!stop && opened)
                while (!stop)
                {
                    Thread.Sleep(200);
                    lock (locker)
                    {
                        for (int i = 0; i < BoardCount; i++)
                        {
                            try
                            {
                                if (stop)
                                    return;
                                //pakpobox.WriteBit(i, "aa", 0);
                                //string strReturn = pakpobox.ReturnValue().ToString();
                                string strReturn = lockControl.getLockStatus(i);
                                if (Setting.Instance.IsDebug)
                                    LogHelper.Log("电子锁状态监测(板号" + i + ")：" + strReturn ?? "null");
                                if (strReturn != "读卡失败" && !string.IsNullOrEmpty(strReturn) && strReturn.Length > 3)
                                {
                                    try
                                    {
                                        var arr = strReturn.Substring(3).Split(',');
                                        for (int j = 0; j < Math.Min(arr.Length, Status.GetUpperBound(1)); j++)
                                        {
                                            if (stop)
                                                return;
                                            //LogHelper.Log("锁状态： " + arr[j]);

                                            Status[i, j] = arr[j] == "0";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        LogHelper.Log("电子锁状态解析异常", ex);
                                    }
                                }
                                if (Setting.Instance.IsDebug)
                                    LogHelper.Log("更新完成");
                            }
                            catch (Exception ex)
                            {
                                LogHelper.Log("电子锁状态监测异常", ex);
                            }
                        }
                    }
                }
            }));
            th.IsBackground = true;
            th.Start();

        }

        public void Stop()
        { stop = true; }
        **/

        public void Start(){ }

        public void Stop() { }
        public void Open(int boardNo, string lockNo)
        {
            try
            {
              

                if (null == lockNo)
                {
                    LogHelper.Log("开锁编号  柜号：" + boardNo + "；锁编号为空，无法开锁");
                    return;
                }
                //pakpobox.WriteRom((boardNo - 1), lockNo, 0);
                lockControl.unLock((boardNo - 1), lockNo);
                if (Setting.Instance.IsDebug)
                {
                    LogHelper.Log("开锁编号  柜号：" + boardNo + "；锁编号：" + lockNo);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log("电子锁开门失败", ex);
            }
        }
     
        public bool Close(string no)
        { return true; }

        public event Action<string> OnClosed;
    }
}