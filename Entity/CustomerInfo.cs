using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Entity
{
    [Serializable]
    public class CustomerInfo
    {
        private int ciId;

        public int CiId
        {
            get { return ciId; }
            set { ciId = value; }
        }
        private int ciUserId;//用户ID

        public int CiUserId
        {
            get { return ciUserId; }
            set { ciUserId = value; }
        }
        private int ciUserType;//用户类型

        public int CiUserType
        {
            get { return ciUserType; }
            set { ciUserType = value; }
        }
        private String ciUserTypeName;//

        public String CiUserTypeName
        {
            get { return ciUserTypeName; }
            set { ciUserTypeName = value; }
        }
        private String ciUserName;//用户姓名

        public String CiUserName
        {
            get { return ciUserName; }
            set { ciUserName = value; }
        }
        private int ciUserAge;//用户年龄

        public int CiUserAge
        {
            get { return ciUserAge; }
            set { ciUserAge = value; }
        }
        private DateTime ciUserBriday;//用户生日

        public DateTime CiUserBriday
        {
            get { return ciUserBriday; }
            set { ciUserBriday = value; }
        }
        private int ciUserGender;//用户性别

        public int CiUserGender
        {
            get { return ciUserGender; }
            set { ciUserGender = value; }
        }
        private int ciUserIdType;//用户证件类型

        public int CiUserIdType
        {
            get { return ciUserIdType; }
            set { ciUserIdType = value; }
        }
        private String ciUserIdCode;//用户证件号码

        public String CiUserIdCode
        {
            get { return ciUserIdCode; }
            set { ciUserIdCode = value; }
        }
        private String ciUserPhone;//用户手机

        public String CiUserPhone
        {
            get { return ciUserPhone; }
            set { ciUserPhone = value; }
        }
        private String ciUserBackupPhone;//用户备用手机

        public String CiUserBackupPhone
        {
            get { return ciUserBackupPhone; }
            set { ciUserBackupPhone = value; }
        }
        private String ciIcCard;//IC卡

        public String CiIcCard
        {
            get { return ciIcCard; }
            set { ciIcCard = value; }
        }
        private String ciLoginName;//用户登录名

        public String CiLoginName
        {
            get { return ciLoginName; }
            set { ciLoginName = value; }
        }
        private String ciLoginPassword;//用户登录密码

        public String CiLoginPassword
        {
            get { return ciLoginPassword; }
            set { ciLoginPassword = value; }
        }
        private String ciUserMicroMsg;//用户微信号

        public String CiUserMicroMsg
        {
            get { return ciUserMicroMsg; }
            set { ciUserMicroMsg = value; }
        }
        private String ciUserEmail;//用户邮箱

        public String CiUserEmail
        {
            get { return ciUserEmail; }
            set { ciUserEmail = value; }
        }
        private DateTime ciLasttime;//上次登录时间

        public DateTime CiLasttime
        {
            get { return ciLasttime; }
            set { ciLasttime = value; }
        }
        private String ciUserQq;//用户QQ

        public String CiUserQq
        {
            get { return ciUserQq; }
            set { ciUserQq = value; }
        }
        private int ciRegMode;//注册方式

        public int CiRegMode
        {
            get { return ciRegMode; }
            set { ciRegMode = value; }
        }
        private String ciPboxNo;//终端编号

        public String CiPboxNo
        {
            get { return ciPboxNo; }
            set { ciPboxNo = value; }
        }
        private int ciUserProxyFlag;//用户快递代收标识

        public int CiUserProxyFlag
        {
            get { return ciUserProxyFlag; }
            set { ciUserProxyFlag = value; }
        }
        private int ciProxyUserId;//代收人用户ID

        public int CiProxyUserId
        {
            get { return ciProxyUserId; }
            set { ciProxyUserId = value; }
        }
        private String ciProxyUserName;//代步人姓名

        public String CiProxyUserName
        {
            get { return ciProxyUserName; }
            set { ciProxyUserName = value; }
        }
        private String ciProxyUserPhone;//代收人手机号

        public String CiProxyUserPhone
        {
            get { return ciProxyUserPhone; }
            set { ciProxyUserPhone = value; }
        }
    }
}
