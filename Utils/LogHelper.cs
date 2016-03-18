using System;
using System.Collections.Generic;

using System.Text;
using System.IO;

namespace EBoxClient.Utils
{
    public class LogHelper
    {
        static object locker = new object();

        public static void Log(Exception e)
        {
            Flush(GetLog(e));
        }

        private static void BuildMessage(Exception e, StringBuilder sb)
        {
            if (e == null) return;
            sb.Append(string.Format("[{0}] {1}" + Environment.NewLine, Utils.DateTimeUtils.DateTimeString()
                   , "异常信息:" + Environment.NewLine + e.Message +
                   Environment.NewLine + "引发方法：" + Environment.NewLine +
                   (e.TargetSite == null ? string.Empty : e.TargetSite.ToString())
                  + Environment.NewLine + "调用堆栈：" + Environment.NewLine + e.StackTrace));
            if (e.InnerException != null)
                BuildMessage(e.InnerException, sb);
        }

        private static string GetLog(Exception e)
        {
            if (e == null) return string.Empty;
            var log = new StringBuilder();
            log.Append(Environment.NewLine + "==================================================" + Environment.NewLine);
            BuildMessage(e, log);
            log.Append(Environment.NewLine + "==================================================" + Environment.NewLine);
            return log.ToString();
        }

        private static void Flush(string log)
        {
            try
            {
                lock (locker)
                {
                    var logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
                    if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
                    File.AppendAllText(Path.Combine(logDir, "log" +
                        DateTime.Today.ToString("yyyyMMdd") + ".txt"), log, Encoding.UTF8);
                }
            }
            catch (Exception)
            {
            }
        }

        private static string GetLog(string msg)
        {
            return string.Format("[{0}] {1}" + Environment.NewLine, Utils.DateTimeUtils.DateTimeString(), msg);
        }

        public static void Log(string msg)
        {
            Flush(GetLog(msg));
        }

        public static void Log(string msg, Exception e)
        {
            Log(msg + Environment.NewLine + GetLog(e));
        }
    }
}
