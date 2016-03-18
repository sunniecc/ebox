using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EBoxClient.Entity;
using EBoxClient.Device;
using EBoxClient.Utils;
using System.IO;
using Newtonsoft.Json.Linq;

namespace EBoxClient
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
          
        }

        static bool firstLoad = true;
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
           
            this.webBrowser1.WebBrowserShortcutsEnabled = Setting.Instance.IsDebug;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = Setting.Instance.IsDebug;

            webBrowser1.Navigate(Path.Combine(Application.StartupPath, Setting.Instance.IndexPage));
            webBrowser1.ObjectForScripting = this;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            if (!Setting.Instance.isShowMouse)
            {
                Cursor.Hide();
            }

            Init();
            //杀到进程
            killProcess();
        }
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);


        private void killProcess()
        {
           WinExec("taskkill /f /im explorer.exe", 0);
        }

        private void Debug()
        {
            //TaskTimer t = new TaskTimer();
            //t.Execute();
            string s = "MJ/0ee36iULGGDZC1e0NUv874aVVtVdD1be+4ryKkckKoqRgoiE/MZCWrM9aM7LvrBFWprwDYQvYTaH50rJWJTTi7adhB09UDHHK47BDyInWRFxQVZeO+99SvPcObgpTvYv6dkdRcrXkYoKTCz5y20++iLiScdHgMi4dg5pufCg=";
            string rst = MyRSA.Decrypt(s);
            string r = rst.Trim('\0');
            LogHelper.Log(r);
            //BarCodePrinter barCodePrinter = new BarCodePrinter();
            //barCodePrinter.Print("111","","","");
            //var d = localData.GetBoxLockNoByTypeID(1);
            //idValidDevice.Init();
            //idValidDevice.OnIDRead += new Action<string>(idValidDevice_OnIDRead);

            //elcWeight.Init();
            //elcWeight.OnReadWeight += new Action<float>(elcWeight_OnReadWeight);
            //elcWeight.StartRead();
            // BarCodePrinter printer = new BarCodePrinter();
            //printer.Init();
            //var a =    service.userRegist("中文测试", "150125198501093611", "17011111111", "111111", "899413");
        }

        public void InvokeJs(string func, params object[] paraArr)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    webBrowser1.Document.InvokeScript(func, paraArr);
                }));
            }
            catch (Exception ex)
            {
                LogHelper.Log("JS调用异常", ex);
            }
        }


        string bizCode = string.Empty;
        BoxDoor boxDoor = new BoxDoor();
        IDValidDevice idValidDevice = new IDValidDevice();
        Service service = Service.Instance;
        LocalData localData = LocalData.Instance;
        UIData uiData;

        string eiOrderNo;
        string pickupPhoneNumber;
        string pickupCode;
        long pickupIntcode;
        ElcWeight elcWeight = new ElcWeight();
        BarCodeScanner barCodeScanner = new BarCodeScanner();
        BarCodePrinter barCodePrinter = new BarCodePrinter();
        Camera camera = new Camera();
        TaskTimer timer = new TaskTimer();
        CoinMachine coinMachine = new CoinMachine();

        void Init()
        {
            service.Init(int.Parse(Setting.Instance.BoxID), Setting.Instance.BoxNo.ToString());
            uiData = new UIData();
            if (uiData.PBoxInfo == null)
            {
                var data = service.programInit() as JObject;
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        if (item.Key.Equals("overdueBusiness", StringComparison.OrdinalIgnoreCase))
                        {
                            JObject obj = item.Value as JObject;
                            LocalData.Instance.SyncData(item.Key, obj);
                            foreach (var info in obj)
                            {
                                if (info.Key.Equals("eoEiId", StringComparison.OrdinalIgnoreCase))
                                {
                                    localData.setExpressOvertime(Convert.ToInt32(info.Value));
                                    break;
                                }
                            }

                        }
                        else if (item.Key.Equals("pboxInfo", StringComparison.OrdinalIgnoreCase)
                             || item.Key.Equals("ontrolCabinet", StringComparison.OrdinalIgnoreCase)
                             || item.Key.Equals("sysVersion", StringComparison.OrdinalIgnoreCase))
                        {
                            LocalData.Instance.SyncData(item.Key, item.Value as JObject);
                        }
                        else
                        {
                            if (item.Key.Equals("express", StringComparison.OrdinalIgnoreCase))
                            {
                                foreach (var key in item.Value)
                                {
                                    LocalData.Instance.SyncData("express", key as JObject);
                                }

                            }
                            foreach (var record in item.Value)
                            {
                                LocalData.Instance.SyncData(item.Key, record as JObject);
                            }
                        }
                    }
                }
                uiData = new UIData();
            }
            service.OnServiceError += new Action<string, string>(service_OnServiceError);
            elcWeight.Init();
            idValidDevice.Init();
            barCodeScanner.Init();
            int cnt = localData.queryStoreArkNum();
            boxDoor.BoardCount = cnt>0?cnt:4;
            boxDoor.Init();
            //boxDoor.Start();
            barCodeScanner.OnCodeScan += new Action<string>(barCodeScanner_OnCodeScan);
            Debugger.Instance.BoxDoor = boxDoor;
            Debugger.Instance.ElcWeight = elcWeight;
            elcWeight.Host = this;
            Debugger.Instance.IDValidDevice = idValidDevice;
            Debugger.Instance.Host = this;
            idValidDevice.Host = this;
            timer.Start();
            coinMachine.OnTouchCoin += new Action(coinMachine_OnTouchCoin);
            coinMachine.Init();

            boxDoor.OnClosed += new Action<string>(boxDoor_OnClosed);
            idValidDevice.OnIDRead += new Action<string>(idValidDevice_OnIDRead);
            elcWeight.OnReadWeight += new Action<float>(elcWeight_OnReadWeight);
        }

        void coinMachine_OnTouchCoin()
        {
            InvokeJs("OnTouchCoin", coinMachine.CoinCount);
        }

        void barCodeScanner_OnCodeScan(string code)
        {
            InvokeJs("OnCodeScan", code);
        }

        void service_OnServiceError(string code, string msg)
        {
            LogHelper.Log("服务异常：" + msg + "，服务器返回代码：" + code);
        }

        void elcWeight_OnReadWeight(float weight)
        {
            //Roy Mark 20150515 weight = 50;
            var money=  elcWeight_money(weight);
            InvokeJs("OnReadWeight", weight.ToString("F1"), money.ToString("F1"));
            if (bizCode == BizCode.EBOX2010.ToString() && weight >=0)
            {
                InvokeJs("OnShowWeight", weight);
                var lcId = 0;
                if (int.TryParse(uiData.CmpID, out lcId))
                {
                    var startcity = uiData.PBoxInfo.PBCITYNO;
                    var endcity = uiData.JiJianCityNo;
                    var wght = Convert.ToInt32(weight);
                    //var money = service.calculateAExpense(lcId, startcity, endcity, wght);
                    var realMoney = float.Parse(money == null ? "-1" : money.ToString());
                    //Roy Mark 20150516//if (realMoney > 0)
                    {
                        uiData.JiIianWeight = wght;
                        uiData.JiJianMoney = realMoney;
                        InvokeJs("OnReadWeight", weight, money);
                    }
                }
            }
        }
        /// <summary>
        /// 计算所需要的金额
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        /// 
        /*
         <add key="FirstHeavy" value="5" />
            <add key="FirstWeightExp" value="29" />
            <add key="UnitHeavy" value="0.5" />
            <add key="UnitExp" value="2.5" />
        */
        float elcWeight_money(float weight)
        {
            int iFirstHeavy;
            int iFirstWeightExp;
            float fUnitHeavy;
            float fUnitExp;
           
            DateTime DiscountEndTime = Setting.Instance.DiscountEnd;

            if (DateTime.Compare(DateTime.Now, DiscountEndTime) > 0)
            {
                iFirstHeavy = Setting.Instance.FirstHeavy;
                iFirstWeightExp = Setting.Instance.FirstWeightExp;
                fUnitHeavy = Setting.Instance.UnitHeavy;
                fUnitExp = Setting.Instance.UnitExp;
            }
            else
            {
                iFirstHeavy = Setting.Instance.uFirstHeavy;
                iFirstWeightExp = Setting.Instance.uFirstWeightExp;
                fUnitHeavy = Setting.Instance.uUnitHeavy;
                fUnitExp = Setting.Instance.uUnitExp;
            }
           
           var money=0f;
           if (weight > 0 && weight <= iFirstHeavy)
           {
               money = iFirstWeightExp;
           }
           else if (weight > iFirstHeavy)
           {
               money = float.Parse((iFirstWeightExp + (weight - iFirstHeavy) / fUnitHeavy * fUnitExp).ToString());
               money = (float)Math.Round(money, 1);
           }

           return money;
        } 

        void idValidDevice_OnIDRead(string idstr)
        {
            if (bizCode == BizCode.EBOX2006.ToString() 
                || bizCode == BizCode.EBOX2027.ToString()
                || bizCode == BizCode.EBOX2017.ToString()
                || bizCode == BizCode.EBOX2033.ToString())
            {
                var id = idstr.Split(',')[0].ToString();
                var realName = idstr.Split(',')[1].ToString();
                uiData.IDCode = id;
                uiData.RealName = realName;

                var name = service.userIdValidate(id, uiData.UserType);
                if (name != null && name.ToString() == "-6")
                {
                    InvokeJs("UserValidated", new object[] { JsonHelper.ToJson(new { success = false,rst = "-6" }) });
                }
                else
                {
                    if (name != null && name.ToString() != "-3" && !string.IsNullOrEmpty(name.ToString()))
                    {
                        uiData.UserName = name.ToString();
                        InvokeJs("UserValidated", new object[] { JsonHelper.ToJson(new { success = true, rst = "-1" }) });
                    }
                    else
                    {
                        InvokeJs("UserValidated", new object[] { JsonHelper.ToJson(new { success = false, rst = "-1" }) });
                    }
                }
                
            }
        }

        void boxDoor_OnClosed(string no)
        {
            if (bizCode == BizCode.EBOX2004.ToString())
                InvokeJs("BoxClosed", new object[] { no });
            else if (bizCode == BizCode.EBOX2005.ToString())
            {
                //service.expressTakeAbnormal();
                InvokeJs("CustExitQujian", new object[] { no });
            }
        }
        public void SetBizCode(string code)
        {
            bizCode = code;
        }

        /// <summary>
        /// 重置容器全局变更
        /// 客户、快递员、管理员会自动退出系统
        /// </summary>
        public void ReInit()
        {
            LogHelper.Log("重置页面缓冲参数---");
            if (firstLoad)
                firstLoad = false;
            else
            {
                var userInfo = uiData == null || uiData.UserInfo == null ? null
                    : JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                //var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                if (null != userInfo && userInfo.ToString() != "{}" && userInfo["userInfo"]!=null)
                {
                    int uiId = userInfo["userInfo"].Value<int>("uiId");
                    if (uiId > 0)
                    {
                        int method = uiData.Method;
                        if (4 == method)
                        {
                            service.userLoginOut(uiId.ToString(), 3);//管理员退出
                        }
                        else if (3 == method)
                        {
                            service.userLoginOut(uiId.ToString(), 4);//快递员退出
                        }
                        else
                        {
                            service.userLoginOut(uiId.ToString(), 5);//客户退出
                        }
                    }
                }
                //uiData = new Entity.UIData();
            }
        }

        /// <summary>
        /// 启动摄像头
        /// </summary>
        public void StartCamera()
        {
            camera.Start();
        }
        /// <summary>
        /// 关闭摄像头
        /// </summary>
        public void CloseCamera()
        {
            camera.Close();
        }
        /// <summary>
        /// 拍照
        /// </summary>
        public void Snapshot()
        {
            camera.Snapshot();
        }

        public void StartCoinMachine()
        {
            coinMachine.Start();
        }

        public void StopCoinMachine()
        {
            coinMachine.Stop();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F6)
            {
                ShowDebug();
                return true;
            }
            else if (keyData == Keys.BrowserBack)
            {
                return true;
            }
            else if (keyData == Keys.Back)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        void ShowDebug()
        {
            new FrmDebug().Show();
        }

        public void Exit()
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //boxDoor.Stop();
            coinMachine.Stop();
            camera.Close();
            timer.Stop();
            idValidDevice.Stop();
            elcWeight.Stop();
            barCodePrinter.Stop();
            barCodeScanner.Stop();
            service.programExit("SYS");
            service.Dispose();
        }

       
    }
}
