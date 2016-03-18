using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient
{
    partial class FrmMain
    {
        public string memberConfig(string key, string syscode, string value1, string value2, int userId)
        {
            if ("7008" == key)
            {
                object rst = service.memberProxyConfig(key, syscode, userId.ToString(), value1, value2);
                return rst == null ? string.Empty : rst.ToString();
            }
            else
            {
                object rst = service.memberCenterConfig(key, syscode, userId.ToString(), value1, value2);
                return rst == null ? string.Empty : rst.ToString();
            }
        }

        public void setMemberCenterMoney(float money)
        {
            uiData.MemberAccount = money;
        }

        public float getMemberCenterMoney()
        {
            return uiData.MemberAccount;
        }
    }
}
