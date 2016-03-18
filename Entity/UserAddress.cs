using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Entity
{
    [Serializable]
   public class UserAddress
    {
        private int adId;//

        public int AdId
        {
            get { return adId; }
            set { adId = value; }
        }
        private int adUserId;//用户ID

        public int AdUserId
        {
            get { return adUserId; }
            set { adUserId = value; }
        }
        private String adUserName;//用户姓名

        public String AdUserName
        {
            get { return adUserName; }
            set { adUserName = value; }
        }
        private String adRecipientName;//收件人姓名

        public String AdRecipientName
        {
            get { return adRecipientName; }
            set { adRecipientName = value; }
        }
        private String adRecipientPhone;//收件人电话

        public String AdRecipientPhone
        {
            get { return adRecipientPhone; }
            set { adRecipientPhone = value; }
        }
        private String adProNo;//省份编号

        public String AdProNo
        {
            get { return adProNo; }
            set { adProNo = value; }
        }
        private String adProName;//省份名称

        public String AdProName
        {
            get { return adProName; }
            set { adProName = value; }
        }
        private String adCityNo;//城市编号

        public String AdCityNo
        {
            get { return adCityNo; }
            set { adCityNo = value; }
        }
        private String adCityName;//城市名称

        public String AdCityName
        {
            get { return adCityName; }
            set { adCityName = value; }
        }
        private String adCoNo;//区县编号

        public String AdCoNo
        {
            get { return adCoNo; }
            set { adCoNo = value; }
        }
        private String adCoName;//区县名称

        public String AdCoName
        {
            get { return adCoName; }
            set { adCoName = value; }
        }
        private String adAddress;//寄件地址

        public String AdAddress
        {
            get { return adAddress; }
            set { adAddress = value; }
        }
        private String adZipCode;//邮编

        public String AdZipCode
        {
            get { return adZipCode; }
            set { adZipCode = value; }
        }
        private int adAddressFlag;//默认地址标识

        public int AdAddressFlag
        {
            get { return adAddressFlag; }
            set { adAddressFlag = value; }
        }
    }
}
