using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Threading;
using EBoxClient.Utils;

namespace EBoxClient
{
    public class CommonBoot
    {
        static Mutex mtx;
        public static bool Init(string proudctCode, bool single = true)
        {
            bool createNew = false;
            mtx = new Mutex(false, proudctCode, out  createNew);
            if (single && !createNew)
            {
                MessageBox.Show("程序已经在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return false;
            }

            Init();
            return true;

        }

        public static void Init()
        {
            //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is ObjectDisposedException) return;
            try
            {
                if (e.ExceptionObject is Exception) LogHelper.Log(e.ExceptionObject as Exception);
                MessageBox.Show("发生未捕获到的异常，已记录到日志！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is ObjectDisposedException) return;
            try
            {
                LogHelper.Log(e.Exception);
                MessageBox.Show("发生未捕获到的异常，已记录到日志！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
            }
        }

    }
}
