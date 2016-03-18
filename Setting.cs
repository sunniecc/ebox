using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Utils;

namespace EBoxClient
{
    public class Setting
    {
        private Setting()
        { }

        public static readonly Setting Instance = new Setting();

        public bool IsDebug
        {
            get
            {
                var r = false;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.IsDebug), "false");
                bool.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.IsDebug), value.ToString()); }
        }

        public bool isShowMouse
        {
            get
            {
                var r = false;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.isShowMouse), "false");
                bool.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.isShowMouse), value.ToString()); }
        }

        public string ServerHost
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ServerHost), "127.0.0.1");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ServerHost), value.ToString()); }
        }

        public int ServerPort
        {
            get
            {
                var r = 20000;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ServerPort), "20000");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ServerPort), value.ToString()); }
        }

        public int HeartBeatInterval
        {
            get
            {
                var r = 5000;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.HeartBeatInterval), "15000");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.HeartBeatInterval), value.ToString()); }
        }

        public string DataBase
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.DataBase), "Data/ebox.db");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.DataBase), value.ToString()); }
        }

        public string BoxID
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BoxID), "5");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BoxID), value.ToString()); }
        }

        public string BoxNo
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BoxNo), "P201410001");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BoxNo), value.ToString()); }
        }

        public int overdueUnitPrice
        {
            get
            {
                var r = 24;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.overdueUnitPrice), "24");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.overdueUnitPrice), value.ToString()); }
        }

        public int IDCardDeviceCOMPort
        {
            get
            {
                var r = 3;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.IDCardDeviceCOMPort), "5");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.IDCardDeviceCOMPort), value.ToString()); }
        }

        public int ElcWeightCOMPort
        {
            get
            {
                var r = 3;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ElcWeightCOMPort), "3");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ElcWeightCOMPort), value.ToString()); }
        }


        public float ElcWeightBaseValue
        {
            get
            {
                var r = 0f;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ElcWeightBaseValue), "0");
                float.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ElcWeightBaseValue), value.ToString()); }
        }

        public int BarCodeScannerCOMPort
        {
            get
            {
                var r = 7;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BarCodeScannerCOMPort), "7");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BarCodeScannerCOMPort), value.ToString()); }
        }

        public int ElcLockCOMPort
        {
            get
            {
                var r = 3;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ElcLockCOMPort), "1");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ElcLockCOMPort), value.ToString()); }
        }


        public string IndexPage
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.IndexPage), "Page/index.html");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.IndexPage), value.ToString()); }
        }

        public string BarCodePrinterName
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BarCodePrinterName), "TSC TDP-245");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BarCodePrinterName), value.ToString()); }
        }

        public string PrinterSetupConfig
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrinterSetupConfig), "50, 40, 4, 8, 0, 0, 0");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrinterSetupConfig), value.ToString()); }
        }

        public string BarCodePrintConfig
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BarCodePrintConfig), "100, 100, 128, 100, 1, 0, 2, 2");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.BarCodePrintConfig), value.ToString()); }
        }

        public string PrinterFontConfig
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrinterFontConfig), "100, 250, 3, 0, 1, 1, 2, 2");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrinterFontConfig), value.ToString()); }
        }

        public string WindowsfontConfig
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.WindowsfontConfig), "100, 250, 3, 0, 1, 1, 2, 2");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.WindowsfontConfig), value.ToString()); }
        }

        public string PrintlabelConfig
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrintlabelConfig), "1,1");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrintlabelConfig), value.ToString()); }
        }

        public string DownloadpcxConfig
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.DownloadpcxConfig), "UL.PCX,UL.PCX");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.DownloadpcxConfig), value.ToString()); }
        }

        public string PrintTemplate
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrintTemplate), "收件人:{0} 电话：{1} 地址:{2}");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrintTemplate), value.ToString()); }
        }

        public int PrintModel
        {
            get
            {
                var r = 1;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrintModel), "1");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrintModel), value.ToString()); }
        }


        public string PrintBoxConfig
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrintBoxConfig), "3,10,385,310,3");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrintBoxConfig), value.ToString()); }
        }

        public string MultyPrintOffset
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.MultyPrintOffset), "0,1|0,1");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.MultyPrintOffset), value.ToString()); }
        }
        public int CameraIndex
        {
            get
            {
                var r = 0;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.CameraIndex), "0");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.CameraIndex), value.ToString()); }
        }
        public string PictureSaveDir
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PictureSaveDir), "Picture");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PictureSaveDir), value.ToString()); }
        }

        public string PrivateKey
        {
            get
            {
                var key = @"MIICeAIBADANBgkqhkiG9w0BAQEFAASCAmIwggJeAgEAAoGBALKKXen1t7KHEyZ6L/fKbutAZRLD2p7QbwywrZS1ljaBuKyguI66vvKzsyUodz04dJmc0fxtg2LR2gPQklYWJNSMnOmpo9ccb4iO7cj8qUbIn8lBZL0kCe9JepnvgToxzoEYnFZUaWpijXaYQI8qWxaDDy5DX5QfOtll/iLgM3jtAgMBAAECgYEAo7hwcDeL8SEeNX18eSxf1EhjpvaEhne6LZfiROjTSz5fW6WyN+gVa7fPgjZ+SVx4x9hfUqwV/EtVMYRUfK6nq9x8GwgPiKW1W3KrWMjdHcq6nIN7+uC1f6YWEe9EofVlxWUMJI3MCM1QtQBnvR9H+hUTFoMqvljL8Rgyd2gqzuECQQDhFyp2rrSmAF9/rTOCXiLZ8kZ4gvLKrGEEc9DbAbfVwJ3fLre2ew+VxGGv2PcvYswJ9npnARm8uVjEkiZiYK/1AkEAyw7II75UXFSMgzZ/wq0WQlRh6VxXvssg5+M6n4FMH7p4HgBe51VFzmbq/tEER+nzcPWnpZ30gqhPPOFOfDziGQJBAMsqDrDa1cDzmz7xhQmJkClp7UN+5kgauOK86mmSrmxnk9dLIpS5lIKYo5eF3O5PXV0stKReMO3P2ZhrVev72zUCQQCKbDU7SJAxsOFowUou59d4uBVXA8A9LDPuYBSij33ZU0B3E0Ge6Z6AqeAgfVQxweZWZuA2IouAVkRN+DmMr+RhAkAb5PEKKfxGYGicWepIUlkidPRJ53gzhCc6RD6R7wBkY1lFFV65luumGll/NbM17n5FcFj8MScu1/xnDjxgE9Xl";
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrivateKey), key);
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PrivateKey), value.ToString()); }
        }
        public string PublicKey
        {
            get
            {
                var key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCyil3p9beyhxMmei/3ym7rQGUSw9qe0G8MsK2UtZY2gbisoLiOur7ys7MlKHc9OHSZnNH8bYNi0doD0JJWFiTUjJzpqaPXHG+Iju3I/KlGyJ/JQWS9JAnvSXqZ74E6Mc6BGJxWVGlqYo12mECPKlsWgw8uQ1+UHzrZZf4i4DN47QIDAQAB";

                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PublicKey), key);
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PublicKey), value.ToString()); }
        }

        public string ScheduleTime
        {
            get
            {
                return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PublicKey), "23:11");
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.PublicKey), value.ToString()); }
        }
        public float ScheduleDiffMinutes
        {
            get
            {
                var r = 1f;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ScheduleDiffMinutes), "1");
                float.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.ScheduleDiffMinutes), value.ToString()); }
        }

        public int CoinMachineCOMPort
        {
            get
            {
                var r = 6;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.CoinMachineCOMPort), "6");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.CoinMachineCOMPort), value.ToString()); }
        }
        public int LineHeight
        {
            get
            {
                var r = 5;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.LineHeight), "5");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.LineHeight), value.ToString()); }
        }

          /*  <!--阳光洗衣价格配置-->
            <add key="FirstHeavy" value="5" />
            <add key="FirstWeightExp" value="29" />
            <add key="UnitHeavy" value="0.5" />
            <add key="UnitExp" value="2.5" />
           */
        public int FirstHeavy
        {
            get
            {
                var r = 5;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.FirstHeavy), "5");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.FirstHeavy), value.ToString()); }
        }

        public int FirstWeightExp
        {
            get
            {
                var r = 30;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.FirstWeightExp), "30");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.FirstWeightExp), value.ToString()); }
        }

        public float UnitHeavy
        {
            get
            {
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.UnitHeavy), "0.5");
                //float.Parse(config);
                return float.Parse(config);
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.UnitHeavy), value.ToString()); }
        }

        public float UnitExp
        {
            get
            {
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.UnitExp), "2.5");  
                return float.Parse(config);
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.UnitExp), value.ToString()); }
        }

        /*  
 
       <!--阳光洗衣推广价格配置-->
       <add key="DiscountEnd" value="2015-06-15" />
       <add key="uFirstHeavy" value="5" />
       <add key="uFirstWeightExp" value="24" />
       <add key="uUnitHeavy" value="0.5" />
       <add key="uUnitExp" value="2.4" /> */
        public DateTime DiscountEnd
        {
            get
            {
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.DiscountEnd), "2015-06-15");
                return DateTime.Parse(config);
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.DiscountEnd), value.ToString()); }
        }
        public int uFirstHeavy
        {
            get
            {
                var r = 5;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.uFirstHeavy), "5");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.uFirstHeavy), value.ToString()); }
        }

        public int uFirstWeightExp
        {
            get
            {
                var r = 30;
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.uFirstWeightExp), "30");
                int.TryParse(config, out r);
                return r;
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.uFirstWeightExp), value.ToString()); }
        }

        public float uUnitHeavy
        {
            get
            {
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.uUnitHeavy), "0.5");
                //float.Parse(config);
                return float.Parse(config);
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.uUnitHeavy), value.ToString()); }
        }

        public float uUnitExp
        {
            get
            {
                var config = SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.uUnitExp), "2.5");
                return float.Parse(config);
            }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.uUnitExp), value.ToString()); }
        }
        public String Machineid {

            get { return SettingsUtils.GetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.Machineid), "SSCW0001"); }
            set { SettingsUtils.SetConfig(ExpressionUtils.GetPropertyName<Setting>(c => c.Machineid), value.ToString()); }
        }

    }
}

