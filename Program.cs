using EBoxClient.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EBoxClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!CommonBoot.Init("7ee15525-4bec-4393-a401-14af7a266f2b")) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());

        }
    }


}
