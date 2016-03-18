using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Utils;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using yodaCollection;
using System.Text.RegularExpressions;

namespace EBoxClient.Device
{
    public class ElcWeight
    {
        Xuri device;
        public Control Host { get; set; }

        public void Init()
        {
            device = new Xuri();
            device.Name = "COM" + Setting.Instance.ElcWeightCOMPort;
            device.Sets("COM" + Setting.Instance.ElcWeightCOMPort, "9600,8,1,N");
            
        }

        bool stop = false;
        public void StartRead(string Weight)
        {

            var th = new Thread(new ThreadStart(() =>
            {
                device.ClosePort();
                if (!device.OpenPort())
                {
                    LogHelper.Log("电子称重串口打开失败");
                }
                stop = false;
            
                while (!stop)
                {
                    Thread.Sleep(1000);
                    try
                    {
                        string strReturn = device.ReturnValue().ToString();
                        if (Setting.Instance.IsDebug) //Roy Mark 20150515 
                         LogHelper.Log(strReturn); //Roy Mark 20150515     
                        var weight = 0f;
                        weight = float.Parse(Weight);
                       if (OnReadWeight != null && float.TryParse(strReturn, out weight))
                        {
                           OnReadWeight(weight - Setting.Instance.ElcWeightBaseValue);
                           OnReadWeight(weight);
                            LogHelper.Log("OnReadWeight");
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log("读取重量失败", ex);
                    }
                }
                device.ClosePort();
            }));
            th.IsBackground = true;
            th.Start();
        }

        public void Stop()
        {
            stop = true;
            if (device != null) device.ClosePort();
        }


        public void MockReadWeight(float weight)
        {
            if (OnReadWeight != null)
                OnReadWeight(weight);
        }

        public event Action<float> OnReadWeight;
    }

}
