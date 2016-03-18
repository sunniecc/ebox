using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EBoxClient.Utils;
using System.IO;

namespace EBoxClient
{
    public class TaskTimer
    {
        Thread mainWorker = null;
        bool stop = false;
        DateTime? lastExcuteTime = null;

        public void Start()
        {
            mainWorker = new Thread(DoWork);
            mainWorker.IsBackground = true;
            mainWorker.Start();
        }

        void DoWork()
        {
            while (!stop)
            {
                Thread.Sleep(1000);

                var configTime = TimeSpan.Zero;
                if (!TimeSpan.TryParse(Setting.Instance.ScheduleTime, out configTime))
                {
                    LogHelper.Log("定时时间配置不正确");
                    continue;
                }
                var scheduleTime = DateTime.Today.Add(configTime);
                var diffMinutes = (DateTime.Now - scheduleTime).TotalMinutes;
                if (diffMinutes > 0 && diffMinutes < Setting.Instance.ScheduleDiffMinutes
                    && (!lastExcuteTime.HasValue || lastExcuteTime.Value < DateTime.Today))
                {
                    try
                    {
                        Execute();
                        lastExcuteTime = DateTime.Now;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log("定时执行异常", ex);
                    }
                }
            }
        }

        public void Execute()
        {
            //定时任务每天凌晨扫描一次版本表
            LocalData localData = LocalData.Instance;
            var version = localData.GetSysVersion();
            if (null != version)
            {
                if (null != version.SVDATE &&
                    (DateTime.Now - version.SVDATE).Value.TotalDays <= 1)
                {
                    //当凌晨5时任务启动后，如果终端包更新时间与当前时间小于1天，则说明有更新
                     string rootpath = System.Environment.CurrentDirectory;
                     string host = Setting.Instance.ServerHost + ":" + Setting.Instance.ServerPort;
                     StreamWriter iohost = new StreamWriter(rootpath + "/ip.txt");
                     iohost.Write(host);
                     iohost.Close();
                     string filesize = version.SVFILESIZE;
                     string validatecode = version.SVVALIDATECODE;
                     string filename = version.SVVERSIONBATCH;

                     Dictionary<string, object> root = new Dictionary<string, object>();
                     Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                     root["action"] = "fileTrans";
                     root["type"] = "checkFile";
                     item_item1["fileMsg"] = filename;
                     item_item1["pboxId"] = Setting.Instance.BoxID;
                     root["parameter"] = item_item1;
                     
                     string content = JsonHelper.ToJson(root);
                     long len = Encoding.UTF8.GetBytes(content).Length;
                     var sendCmd = string.Format("EB:{0}E{1}", len, content);
                     StreamWriter sw = new StreamWriter(rootpath + "/msg.txt");
                     sw.Write(sendCmd);
                     sw.Close();
                     LogHelper.Log("更新文件成功写入配置文件！");
                     string exePath = rootpath + "\\AutoUpdate.exe";
                     System.Diagnostics.Process process = new System.Diagnostics.Process();
                     process.StartInfo.FileName = exePath;
                     //process.StartInfo.WorkingDirectory = exePath;
                     process.StartInfo.CreateNoWindow = true;
                     process.Start();
                     if (process.HasExited)
                     {
                         LogHelper.Log("启动终端更新程序成功");
                     }
                }
            }
        }

        public void Stop()
        {
            stop = true;
        }
    }
}
