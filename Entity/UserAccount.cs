using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Entity
{
    [Serializable]
    public class UserAccount
    {
        private String uaUserActNo;//用户帐户编号

        public String UaUserActNo
        {
            get { return uaUserActNo; }
            set { uaUserActNo = value; }
        }
        private int uaType;//用户类型

        public int UaType
        {
            get { return uaType; }
            set { uaType = value; }
        }
        private String uaTypeName;//

        public String UaTypeName
        {
            get { return uaTypeName; }
            set { uaTypeName = value; }
        }
        private int uaUserId;//用户ID

        public int UaUserId
        {
            get { return uaUserId; }
            set { uaUserId = value; }
        }
        private String uaUserName;//用户姓名

        public String UaUserName
        {
            get { return uaUserName; }
            set { uaUserName = value; }
        }
        private int uaUserIdType;//用户证件类型

        public int UaUserIdType
        {
            get { return uaUserIdType; }
            set { uaUserIdType = value; }
        }
        private String uaUserIdCode;//用户证件号码

        public String UaUserIdCode
        {
            get { return uaUserIdCode; }
            set { uaUserIdCode = value; }
        }
        private Double uaTotalActMoney;//用户充值总资金

        public Double UaTotalActMoney
        {
            get { return uaTotalActMoney; }
            set { uaTotalActMoney = value; }
        }
        private Double uaTotalActGif;//用户赠送总资金

        public Double UaTotalActGif
        {
            get { return uaTotalActGif; }
            set { uaTotalActGif = value; }
        }
        private Double uaCurrActMoney;//可用充值资金

        public Double UaCurrActMoney
        {
            get { return uaCurrActMoney; }
            set { uaCurrActMoney = value; }
        }
        private Double uaCurrActGif;//可用赠送资金

        public Double UaCurrActGif
        {
            get { return uaCurrActGif; }
            set { uaCurrActGif = value; }
        }
        private Double uaTotalMoney;//用户总资金

        public Double UaTotalMoney
        {
            get { return uaTotalMoney; }
            set { uaTotalMoney = value; }
        }
        private Double uaCompanyActMoney;//公司公共资金

        public Double UaCompanyActMoney
        {
            get { return uaCompanyActMoney; }
            set { uaCompanyActMoney = value; }
        }
        private Double actMoney;//

        public Double ActMoney
        {
            get { return actMoney; }
            set { actMoney = value; }
        }
        private String depts;//

        public String Depts
        {
            get { return depts; }
            set { depts = value; }
        }
    }
}
