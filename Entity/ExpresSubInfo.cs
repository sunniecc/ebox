using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Entity
{
    [Serializable]
    public class ExpresSubInfo
    {
        private int eiId;//主键

        public int EiId
        {
            get { return eiId; }
            set { eiId = value; }
        }
        private string eiOrderNo;//快件订单系统编号

        public string EiOrderNo
        {
            get { return eiOrderNo; }
            set { eiOrderNo = value; }
        }
        private int eiLcId;//物流公司ID

        public int EiLcId
        {
            get { return eiLcId; }
            set { eiLcId = value; }
        }
        private string eiLcName;//物流公司名称

        public string EiLcName
        {
            get { return eiLcName; }
            set { eiLcName = value; }
        }
        private int eiOpId;//运营商ID

        public int EiOpId
        {
            get { return eiOpId; }
            set { eiOpId = value; }
        }
        private string eiOpName;//运营商名称

        public string EiOpName
        {
            get { return eiOpName; }
            set { eiOpName = value; }
        }
        private int eiLcSettleRuleId;//快递公司结算规则ID

        public int EiLcSettleRuleId
        {
            get { return eiLcSettleRuleId; }
            set { eiLcSettleRuleId = value; }
        }
        private int eiEboxSettleRuleId;//派宝箱结算规则ID

        public int EiEboxSettleRuleId
        {
            get { return eiEboxSettleRuleId; }
            set { eiEboxSettleRuleId = value; }
        }
        private string eiExpName;//快件名称

        public string EiExpName
        {
            get { return eiExpName; }
            set { eiExpName = value; }
        }
        private string eiExpBarcode;///快件条形码

        public string EiExpBarcode
        {
            get { return eiExpBarcode; }
            set { eiExpBarcode = value; }
        }
        private float eiExpWeight;/////快件重量

        public float EiExpWeight
        {
            get { return eiExpWeight; }
            set { eiExpWeight = value; }
        }
        private int eiExpUnit;//快件重量单位

        public int EiExpUnit
        {
            get { return eiExpUnit; }
            set { eiExpUnit = value; }
        }
        private double eiLatticePrice;//格口费用

        public double EiLatticePrice
        {
            get { return eiLatticePrice; }
            set { eiLatticePrice = value; }
        }
        private int eiFeeRuleFlag;//费用计算规则【1-标准费用 2-折扣费用】

        public int EiFeeRuleFlag
        {
            get { return eiFeeRuleFlag; }
            set { eiFeeRuleFlag = value; }
        }
        private int eiDiscountValue;//折扣率

        public int EiDiscountValue
        {
            get { return eiDiscountValue; }
            set { eiDiscountValue = value; }
        }
        private double eiFactalPrice;///结算费用，没有折扣费用时，将标准费用填充

        public double EiFactalPrice
        {
            get { return eiFactalPrice; }
            set { eiFactalPrice = value; }
        }
        private double eiStandPrice;//标准费用

        public double EiStandPrice
        {
            get { return eiStandPrice; }
            set { eiStandPrice = value; }
        }
        private double eiTotalFee;//合计费用

        public double EiTotalFee
        {
            get { return eiTotalFee; }
            set { eiTotalFee = value; }
        }
        private string eiOneCode;//一维码

        public string EiOneCode
        {
            get { return eiOneCode; }
            set { eiOneCode = value; }
        }
        private string eiTwoCode;//二维码

        public string EiTwoCode
        {
            get { return eiTwoCode; }
            set { eiTwoCode = value; }
        }
        private string eiProName;//邮寄省份

        public string EiProName
        {
            get { return eiProName; }
            set { eiProName = value; }
        }
        private string eiCityName;//邮寄城市

        public string EiCityName
        {
            get { return eiCityName; }
            set { eiCityName = value; }
        }
        private string eiCoName;//邮寄区县

        public string EiCoName
        {
            get { return eiCoName; }
            set { eiCoName = value; }
        }
        private string eiAddress;//邮寄地址

        public string EiAddress
        {
            get { return eiAddress; }
            set { eiAddress = value; }
        }
        private string eiRecepName;//收件人姓名

        public string EiRecepName
        {
            get { return eiRecepName; }
            set { eiRecepName = value; }
        }
        private string eiRecepPhone;//收件人手机

        public string EiRecepPhone
        {
            get { return eiRecepPhone; }
            set { eiRecepPhone = value; }
        }

    }
}
