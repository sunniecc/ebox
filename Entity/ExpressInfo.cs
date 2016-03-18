using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Entity
{
    [Serializable]
    public class ExpressInfo
    {
        private int eiId; // 主键

        public int EiId
        {
            get { return eiId; }
            set { eiId = value; }
        }
        private String eiOrderNo;// 快件订单系统编号

        public String EiOrderNo
        {
            get { return eiOrderNo; }
            set { eiOrderNo = value; }
        }
        private String elLcMainId;// 快递公司总公司ID

        public String ElLcMainId
        {
            get { return elLcMainId; }
            set { elLcMainId = value; }
        }
        private int eiLcId;// 物流公司ID

        public int EiLcId
        {
            get { return eiLcId; }
            set { eiLcId = value; }
        }
        private String eiLcName;// 物流公司名称

        public String EiLcName
        {
            get { return eiLcName; }
            set { eiLcName = value; }
        }
        private int eiSenderId;// 寄件人ID

        public int EiSenderId
        {
            get { return eiSenderId; }
            set { eiSenderId = value; }
        }
        private String eiSenderName;// 寄件人姓名

        public String EiSenderName
        {
            get { return eiSenderName; }
            set { eiSenderName = value; }
        }
        private String eiSenderPhone;// 寄件人电话

        public String EiSenderPhone
        {
            get { return eiSenderPhone; }
            set { eiSenderPhone = value; }
        }
        private int elStoreUserType;// 存件人类型【1-用户 2-快递员】

        public int ElStoreUserType
        {
            get { return elStoreUserType; }
            set { elStoreUserType = value; }
        }
        private int eiStoreUserId;// 存件人ID

        public int EiStoreUserId
        {
            get { return eiStoreUserId; }
            set { eiStoreUserId = value; }
        }
        private String eiStoreUserName;// 存件人姓名

        public String EiStoreUserName
        {
            get { return eiStoreUserName; }
            set { eiStoreUserName = value; }
        }
        private String eiStoreUserPhone;// 存件人电话

        public String EiStoreUserPhone
        {
            get { return eiStoreUserPhone; }
            set { eiStoreUserPhone = value; }
        }
        private DateTime eiStoreTime;// 入格时间

        public DateTime EiStoreTime
        {
            get { return eiStoreTime; }
            set { eiStoreTime = value; }
        }
        private int elTakeUserType;// 取件人类型【1-用户 2-快递员】

        public int ElTakeUserType
        {
            get { return elTakeUserType; }
            set { elTakeUserType = value; }
        }
        private int eiTakeUserId;// 取件人ID

        public int EiTakeUserId
        {
            get { return eiTakeUserId; }
            set { eiTakeUserId = value; }
        }
        private String eiTakeUserName;// 取件人姓名

        public String EiTakeUserName
        {
            get { return eiTakeUserName; }
            set { eiTakeUserName = value; }
        }
        private String eiTakeUserPhone;// 取件人手机

        public String EiTakeUserPhone
        {
            get { return eiTakeUserPhone; }
            set { eiTakeUserPhone = value; }
        }
        private DateTime eiTakeTime;// 出格时间

        public DateTime EiTakeTime
        {
            get { return eiTakeTime; }
            set { eiTakeTime = value; }
        }
        private int eiPaymentMode;// 付费方式【1：结清 2：存件人支付 3：取件人支付 4：到付】

        public int EiPaymentMode
        {
            get { return eiPaymentMode; }
            set { eiPaymentMode = value; }
        }
        private Double eiPaymentMoney;// 付费额度

        public Double EiPaymentMoney
        {
            get { return eiPaymentMoney; }
            set { eiPaymentMoney = value; }
        }
        private String eiBarcode;// 运单编号

        public String EiBarcode
        {
            get { return eiBarcode; }
            set { eiBarcode = value; }
        }
        private int eiExpType;// 快件类型[1：衣物 2：食品]

        public int EiExpType
        {
            get { return eiExpType; }
            set { eiExpType = value; }
        }
        private int eiMailType;// 快件类型[1-寄件 2-收件]

        public int EiMailType
        {
            get { return eiMailType; }
            set { eiMailType = value; }
        }
        private int eiEboxId;// 派宝箱ID

        public int EiEboxId
        {
            get { return eiEboxId; }
            set { eiEboxId = value; }
        }
        private String eiEboxNo;// 派宝箱编号

        public String EiEboxNo
        {
            get { return eiEboxNo; }
            set { eiEboxNo = value; }
        }
        private String eiEboxAbbr;// 派宝箱别名

        public String EiEboxAbbr
        {
            get { return eiEboxAbbr; }
            set { eiEboxAbbr = value; }
        }
        private String eiLatticeNo;// //格口编号

        public String EiLatticeNo
        {
            get { return eiLatticeNo; }
            set { eiLatticeNo = value; }
        }
        private int eiValiDateTimeCode;// 快件验证码

        public int EiValiDateTimeCode
        {
            get { return eiValiDateTimeCode; }
            set { eiValiDateTimeCode = value; }
        }
        private int elExpSaveMode;// 快件保方式【1-派宝箱录入 2-单条录入 3-批量导入】

        public int ElExpSaveMode
        {
            get { return elExpSaveMode; }
            set { elExpSaveMode = value; }
        }
        private String elExpRemark;// 快件备注

        public String ElExpRemark
        {
            get { return elExpRemark; }
            set { elExpRemark = value; }
        }
        private DateTime elOvertime;//

        public DateTime ElOvertime
        {
            get { return elOvertime; }
            set { elOvertime = value; }
        }

        private String tfDeleteFlag; // 删除标志

        public String TfDeleteFlag
        {
            get { return tfDeleteFlag; }
            set { tfDeleteFlag = value; }
        }

        private String eiTakeIdType;// 取件人证件类型

        public String EiTakeIdType
        {
            get { return eiTakeIdType; }
            set { eiTakeIdType = value; }
        }
        private String eiTakeIdCode;// 取件人证件号码

        public String EiTakeIdCode
        {
            get { return eiTakeIdCode; }
            set { eiTakeIdCode = value; }
        }
    }
}
