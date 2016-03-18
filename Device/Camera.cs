using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using EBoxClient.Utils;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace EBoxClient.Device
{
    public class Camera
    {
        VideoCaptureDevice videoSource = null;
        string saveDir = Application.StartupPath;
        bool snapFlag = false;

        public event Action<string, string> OnPictureSave;

        public void Init()
        {
            //bool r = pbx.initCamera();
            //pbx.onCap();
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                LogHelper.Log("没有找到任何视频输入设备");
                return;
            }
            if (videoDevices.Count <= Setting.Instance.CameraIndex)
            {
                LogHelper.Log("配置的视频设备编号超出列表范围,找到的视频设备数量为" + videoDevices.Count);
                return;
            }
            videoSource = new VideoCaptureDevice(videoDevices[Setting.Instance.CameraIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (snapFlag)
            {
                snapFlag = false;
                SavePicture((Bitmap)eventArgs.Frame.Clone());
            }
        }

        void SavePicture(Bitmap pic)
        {
            try
            {
                saveDir = System.IO.Path.Combine(Application.StartupPath, Setting.Instance.PictureSaveDir + "\\" + DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);
                var fileName = DateTime.Now.ToString("HHmmss") + ".jpg";
                var filePath = Path.Combine(saveDir, fileName);
                pic.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (OnPictureSave != null)
                    OnPictureSave(filePath, fileName);
            }
            catch (Exception ex)
            {
                LogHelper.Log("保存拍照失败", ex);
            }
        }

        public void Start()
        {
            if (videoSource == null)
                Init();
            if (videoSource != null)
                videoSource.Start();
            LogHelper.Log("开启摄像头。。。");
        }

        public void Snapshot()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                snapFlag = true;
            }
            else
            {
                LogHelper.Log("视频设备为初始化或者未启动");
            }
        }

        public void Close()
        {
            try
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                    videoSource = null;
                }
                LogHelper.Log("关闭摄像头。。。");
            }
            catch (Exception)
            {
            }
        }
    }
}
