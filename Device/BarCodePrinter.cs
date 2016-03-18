using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using EBoxClient.Utils;

namespace EBoxClient.Device
{
    public class BarCodePrinter
    {
        public void Init()
        {
        }

        public void Print(string orderNo, string recName, string recPhone, string recAddress, float weight, string senderName,string senderPhone)
        {
            try
            {
                if (recAddress.Length > 11)
                    recAddress = recAddress.Insert(11, "\n");
                if (recAddress.Length > 22)
                    recAddress = recAddress.Insert(22, "\n");
                var str = string.Format(Setting.Instance.PrintTemplate, senderName, senderPhone, recName, recPhone, recAddress, (Math.Round(weight / 1000, 2) + "千克"));
                TSCLIB.openport(Setting.Instance.BarCodePrinterName);
                var config = GetConfig(Setting.Instance.PrinterSetupConfig,
                    new string[] { "50", "40", "4", "8", "0", "0", "0" });
                TSCLIB.setup(config[0], config[1], config[2], config[3], config[4], config[5], config[6]);
                TSCLIB.clearbuffer();
                var barCodeConfig = GetConfig(Setting.Instance.BarCodePrintConfig,
                    new string[] { "100", "100", "128", "100", "1", "0", "2", "2" });
                TSCLIB.barcode(barCodeConfig[0], barCodeConfig[1], barCodeConfig[2], barCodeConfig[3], barCodeConfig[4], barCodeConfig[5], barCodeConfig[6], barCodeConfig[7], orderNo);

                var offsetArr = Setting.Instance.MultyPrintOffset.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                var lines = str.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var offset = new string[] { "0", "0" };
                for (int i = 0; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (i <= Math.Min(lines.Length, offsetArr.Length) && i > 0)
                        offset = GetConfig(offsetArr[i - 1], new string[] { "0", "0" });
                    if (i > offsetArr.Length)
                    {
                        offset[1] = (Convert.ToInt32(offset[1]) + Setting.Instance.LineHeight).ToString();
                    }
                    if (Setting.Instance.PrintModel == 1)
                    {
                        var printerFontConfig = GetConfig(Setting.Instance.PrinterFontConfig,
                           new string[] { "100", "250", "3", "0", "1", "1" });
                        var x = Convert.ToInt32(printerFontConfig[0]) + Convert.ToInt32(offset[0]);
                        var y = Convert.ToInt32(printerFontConfig[1]) + Convert.ToInt32(offset[1]);
                        TSCLIB.printerfont(x.ToString(), y.ToString(), printerFontConfig[2], printerFontConfig[3], printerFontConfig[4], printerFontConfig[5], line);

                    }
                    else
                    {
                        var windowsfontConfig = GetConfig(Setting.Instance.WindowsfontConfig,
                                 new string[] { "100", "300", "24", "0", "0", "0", "ARIAL" });
                        var x = Convert.ToInt32(windowsfontConfig[0]) + Convert.ToInt32(offset[0]);
                        var y = Convert.ToInt32(windowsfontConfig[1]) + Convert.ToInt32(offset[1]);
                        TSCLIB.windowsfont(x, y, Convert.ToInt32(windowsfontConfig[2]), Convert.ToInt32(windowsfontConfig[3]), Convert.ToInt32(windowsfontConfig[4]), Convert.ToInt32(windowsfontConfig[5]), windowsfontConfig[6], line);
                    }
                }

                //var downloadpcxConfig = GetConfig(Setting.Instance.DownloadpcxConfig,
                //             new string[] { "UL.PCX", "UL.PCX" });
                //TSCLIB.downloadpcx(downloadpcxConfig[0], downloadpcxConfig[1]);

                //TSCLIB.sendcommand("PUTPCX 100,400,\"UL.PCX\"");
                TSCLIB.sendcommand("BOX " + Setting.Instance.PrintBoxConfig);

                var printlabelConfig = GetConfig(Setting.Instance.PrintlabelConfig,
                            new string[] { "1", "1" });
                TSCLIB.printlabel(printlabelConfig[0], printlabelConfig[1]);

                TSCLIB.closeport();
            }
            catch (Exception ex)
            {
                LogHelper.Log("打印条码失败", ex);
            }
        }

        private static string[] GetConfig(string config, string[] defaultConfig)
        {
            var configArr = config.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var len = Math.Min(configArr.Length, defaultConfig.Length);
            for (int i = 0; i < len; i++)
            {
                defaultConfig[i] = configArr[i];
            }
            return defaultConfig;
        }

        public void Stop()
        { }

        class TSCLIB
        {
            [DllImport("TSCLIB.dll", EntryPoint = "about")]
            public static extern int about();

            [DllImport("TSCLIB.dll", EntryPoint = "openport")]
            public static extern int openport(string printername);

            [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
            public static extern int barcode(string x, string y, string type,
                        string height, string readable, string rotation,
                        string narrow, string wide, string code);

            [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
            public static extern int clearbuffer();

            [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
            public static extern int closeport();

            [DllImport("TSCLIB.dll", EntryPoint = "downloadpcx")]
            public static extern int downloadpcx(string filename, string image_name);

            [DllImport("TSCLIB.dll", EntryPoint = "formfeed")]
            public static extern int formfeed();

            [DllImport("TSCLIB.dll", EntryPoint = "nobackfeed")]
            public static extern int nobackfeed();

            [DllImport("TSCLIB.dll", EntryPoint = "printerfont")]
            public static extern int printerfont(string x, string y, string fonttype,
                            string rotation, string xmul, string ymul,
                            string text);

            [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
            public static extern int printlabel(string set, string copy);

            [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
            public static extern int sendcommand(string printercommand);

            [DllImport("TSCLIB.dll", EntryPoint = "setup")]
            public static extern int setup(string width, string height,
                      string speed, string density,
                      string sensor, string vertical,
                      string offset);

            [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
            public static extern int windowsfont(int x, int y, int fontheight,
                            int rotation, int fontstyle, int fontunderline,
                            string szFaceName, string content);

        }

    }
}
