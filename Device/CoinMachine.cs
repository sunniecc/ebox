using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using yodaCollection;
using System.Threading;
using EBoxClient.Utils;

namespace EBoxClient.Device
{
    public class CoinMachine
    {
        bool stop = false;
        Toubiji toubiji = new yodaCollection.Toubiji();
        public event Action OnTouchCoin;

        public int CoinCount { get; set; }
        bool opened = false;

        public void Init()
        {
            opened = false;
            toubiji.Name = "COM" + Setting.Instance.CoinMachineCOMPort;
            toubiji.Sets("COM" + Setting.Instance.CoinMachineCOMPort, "9600,8,1,N");
        }

        public void Start()
        {
            stop = false;
            CoinCount = 0;
            Thread th = new Thread(new ThreadStart(() =>
            {
                if (!opened)
                {
                    opened = toubiji.OpenPort();
                    if (!opened)
                    {
                        LogHelper.Log("投币机端口打开失败");
                        return;
                    }
                    toubiji.WriteRom(0, "1", 0);
                }

                while (!stop)
                {
                    Thread.Sleep(300);
                    try
                    {
                        string strReturn = toubiji.ReturnValue().ToString();
                        if (strReturn == "1")
                        {
                            CoinCount++;
                            if (OnTouchCoin != null) OnTouchCoin();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log("投币机读取异常", ex);
                    }
                }
            }));
            th.IsBackground = true;
            th.Start();
        }

        public void Stop()
        {
            CoinCount = 0;
            stop = true;
            try
            {
                toubiji.ClosePort();
                opened = false;
            }
            catch (Exception ex)
            {
                LogHelper.Log("关闭投币机端口失败", ex);
            }
        }
    }
}