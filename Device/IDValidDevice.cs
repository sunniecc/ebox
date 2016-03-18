using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Utils;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EBoxClient.Device
{
    public class IDValidDevice
    {   
        public Control Host { get; set; }

        [DllImport("termb.dll")]
        static extern int CVR_InitComm(int Port); 						// 初始化连接;
        [DllImport("termb.dll")]
        static extern int CVR_Authenticate();							// 卡认证;
        [DllImport("termb.dll")]
        static extern int CVR_Read_Content(int active);	    			         //读卡操作。
        [DllImport("termb.dll")]
        static extern int CVR_CloseComm();
        [DllImport("termb.dll")]
        static extern int GetPeopleName(StringBuilder strTmp, out int strLen);
        [DllImport("termb.dll")]
        static extern int GetPeopleIDCode(StringBuilder strTmp, out int strLen);


        //[DllImport("EBoxHook.dll")]
        //static extern void setEBoxHook();

        //public void setHook()
        //{
            //setEBoxHook();
        //}


        bool isOpened;
        //yodaCollection.Yanjiusuo device = new yodaCollection.Yanjiusuo();
        public void Init()
        {
            //device.Name = "COM" + Setting.Instance.IDCardDeviceCOMPort;
            //device.Sets("COM" + Setting.Instance.IDCardDeviceCOMPort, "9600,8,1,N");
            try
            {
                var r = CVR_InitComm(Setting.Instance.IDCardDeviceCOMPort);
                if (r == 0)
                {
                    LogHelper.Log("身份证设备动态库加载失败");
                    isOpened = false;
                }
                else if (r == 1)
                {
                    isOpened = true;
                    if (Setting.Instance.IsDebug)
                        LogHelper.Log("身份证设备初始化成功");
                }
                else if (r == 2)
                {
                    LogHelper.Log("身份证设备端口打开失败");
                    isOpened = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log("身份证设备初始化失败", ex);
            }
        }

        bool stop = false;
        public void StartRead()
        {
            var th = new Thread(new ThreadStart(() =>
            {
                stop = false;
                while (!stop)
                {
                    Thread.Sleep(500);
                    if (!isOpened)
                    {
                        Init();
                    }
                    if (!isOpened)
                    {
                        Thread.Sleep(5000);
                        continue;
                    }
                    try
                    {
                        var r = CVR_Authenticate();
                        if (r == 0)
                        {
                            LogHelper.Log("身份证读卡验证失败");
                            continue;
                        }
                        else if (r == 1 && Setting.Instance.IsDebug)
                        {
                            LogHelper.Log("身份证读卡验证成功,返回码:1");
                        }
                        else if (r == 2)
                        {
                            LogHelper.Log("身份证寻卡失败,返回码:2");
                            continue;
                        }
                        else if (r == 3)
                        {
                            LogHelper.Log("身份证选卡失败,返回码:3");
                            continue;
                        }
                        r = CVR_Read_Content(0);
                        if (r == 1 && Setting.Instance.IsDebug)
                        {
                            LogHelper.Log("身份证读卡成功,返回码:1");
                        }
                        else if (r == 0)
                        {
                            LogHelper.Log("身份证读卡错误,返回码:0");
                            continue;
                        }
                        else if (r == 99)
                        {
                            LogHelper.Log("身份证读卡异常,返回码:99");
                            continue;
                        }
                        var sb = new StringBuilder();
                        var len = 0;
                        string strReturn = string.Empty;
                        var a = GetPeopleIDCode(sb, out len);
                        if (Setting.Instance.IsDebug)
                            LogHelper.Log("身份证读ID返回：" + a);
                        strReturn += sb.ToString();
                        sb = new StringBuilder();
                        var b = GetPeopleName(sb, out len);
                        if (Setting.Instance.IsDebug)
                            LogHelper.Log("身份证读姓名返回：" + b);
                        strReturn += "," + sb.ToString();
                        if (Setting.Instance.IsDebug)
                            LogHelper.Log("身份证读卡返回：" + strReturn);
                        String[] str = strReturn.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (str.Length >= 2)
                        {
                            if (OnIDRead != null)
                                OnIDRead(strReturn);
                        }
                        else
                            LogHelper.Log("身份证读卡失败");
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log("身份证识别失败", ex);
                    }
                }
                Stop();
            }));
            th.IsBackground = true;
            th.Start();
        }

        public void Stop()
        {
            stop = true;
            try
            {
                CVR_CloseComm();
                isOpened = false;
            }
            catch (Exception)
            {
            }
        }

        public void MockReadID(string id)
        {
            if (OnIDRead != null)
                OnIDRead(id);
        }

        public event Action<string> OnIDRead;
    }
}
