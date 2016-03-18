using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Utils;

namespace EBoxClient
{
    partial class FrmMain
    {
        public void InitIdCard(int usertype, int method)
        {
            uiData.UserType = usertype;
            uiData.Method = method;
            
        }

        public void startReadIdCard()
        {
            LogHelper.Log("开始读取身份证信息");
            idValidDevice.StartRead();
        }

        public void StopIdCardRead()
        {
            LogHelper.Log("停止读取身份证信息");
            idValidDevice.Stop();
        }

        public string loadMemInfo()
        {
            throw new NotImplementedException();
        }
    }
}
