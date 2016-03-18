using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO.Ports;
using EBoxClient.Utils;
using System.Threading;

namespace EBoxClient.Device
{
    public class BarCodeScanner
    {
        int bauRate = 115200;

        string result = null;
        bool flag;

        SerialPort sp = new SerialPort();

        public event Action<string> OnCodeScan;



        public void Init()
        {
            try
            {
                sp.PortName = "COM" + Setting.Instance.BarCodeScannerCOMPort;
                sp.BaudRate = bauRate;
                sp.Parity = Parity.None;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.ReadBufferSize = 1024;
                sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                sp.Open();

            }
            catch (Exception ex)
            {
                LogHelper.Log("打开扫描枪串口失败", ex);
            }
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            Thread.Sleep(500);
            if (result == null)
            {
                byte[] bytes = new byte[1024 * 512];
                int count = 0;
                while (true)
                {
                    if (sp.BytesToRead == 0)
                    {
                        break;
                    }
                    int i = sp.ReadByte();
                    bytes[count++] = (byte)i;
                }
                byte[] buf = new byte[count];
                for (int n = 0; n < buf.Length; n++)
                {
                    buf[n] = bytes[n];
                }
                result = Encoding.UTF8.GetString(buf);
                LogHelper.Log("读取缓冲区成功，长度为：" + count);
            }
             
            //result = sp.ReadLine();
            if (OnCodeScan != null && result != null && !string.IsNullOrEmpty(result))
            {
                //像服务器去拿此运单号对应的电话号码

                OnCodeScan(result);
            }
            /*
            bool l = e.EventType == SerialData.Eof;
            LogHelper.Log("EnvntType:"+l);
            int len = sp.BytesToRead;
            byte[] buf = new byte[len];
            sp.Read(buf, 0, buf.Length);
            result = Encoding.UTF8.GetString(buf);
            int len2 = sp.BytesToRead;
            string log = "扫描枪读取长度为：" + len + ",值：";
            

            for (int i = 0; i < len; i++)
            {
                log += buf[i]+",";
            }
            log += "重读缓存区长度:" + len2;
            LogHelper.Log(log);
            if (buf[len-2]==13 && buf[len-1]==10) 
            { 
            if (OnCodeScan != null && result != null && !string.IsNullOrEmpty(result))
            {
                string temp = result;
                result = null;
                OnCodeScan(temp);
            }
            }
            
            */
            /*
            string str = "";
            ArrayList result = new ArrayList();
            int len = sp.BytesToRead;
            byte[] buf = new byte[20];
            sp.Read(buf, 0, buf.Length);
            str += Encoding.UTF8.GetString(buf);
                /*
            while(true)
            {
                int len = sp.BytesToRead;
                if (len <= 0)
                {
                    break;
                }
                byte[] buf = new byte[len];
                sp.Read(buf, 0, buf.Length);
                str += Encoding.UTF8.GetString(buf);
              
            }
            
            if (OnCodeScan != null && str != null && !string.IsNullOrEmpty(str))
            {
                OnCodeScan(str);
            }
            */
        }

        public void StartRead()
        {
            try
            {
                result = null;
                var cmd = new byte[] { 0xFF, 0x54, 0x0D };
                sp.Write(cmd, 0, cmd.Length);

            }
            catch (Exception ex)
            {
                LogHelper.Log("发送扫描枪指令失败", ex);
            }
        }

        public void Stop()
        {
            try
            {
                if (sp.IsOpen) sp.Close();
            }
            catch (Exception)
            {
            }
        }
    }

}
