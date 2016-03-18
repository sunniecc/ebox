using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Utils;
using EBoxClient.Data;

namespace EBoxClient.Entity
{
    public class UIData
    {
        public UIData()
        {
            try
            {
                PBoxInfo = LocalData.Instance.GetPBoxConfig();
                UserProtocol = LocalData.Instance.GetUserProtocol();
            }
            catch (Exception ex)
            {
                LogHelper.Log("程序初始化异常", ex);
            }
        }
        /// <summary>
        /// 当前操作类型
        /// </summary>
        public int Method { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }
        /// <summary>
        /// 派宝箱配置
        /// </summary>
        public Data.EBOXPBOX PBoxInfo { get; set; }
        /// <summary>
        /// 终端会员对象
        /// </summary>
        public float MemberAccount { get; set; }
        /// <summary>
        /// 快件ID集合
        /// </summary>
        public string ExpressIdList { get; set; }
        /// <summary>
        /// 用户协议
        /// </summary>
        public string UserProtocol { get; set; }

        public ExpressInfo QuJianOrder { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IDCode { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 注册时的验证码
        /// </summary>
        public string RegisterCode { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        public object UserInfo { get; set; }

        public string RealName { get; set; }
        /// <summary>
        /// 寄件时选择的快递公司编号
        /// </summary>
        public string CmpID { get; set; }
        /// <summary>
        /// 寄件时选择的城市编号
        /// </summary>
        public string JiJianCityNo { get; set; }
        public string JiJianProNo { get; set; }
        public string JiJianCountyNo { get; set; }
        public string JiJianAddress { get; set; }
        public string JiJianCountyName { get; set; }
        public string JiJianCityName { get; set; }
        public string JiJianProName { get; set; }
        ///连接电子称是要的参数
        public string Weightparam { get; set; }
        ///连接电子称的状态
        public string FitCmd { get; set; }
        ///电子称称的物品的重量
        public string Weight { get; set; }

        ///电子称返回重量的状态
        public string FitReply { get; set; }
        ///八達通需要的數據
        ///
          
         public string CardCmd{get;set;}
         public string CardLang{get;set;}
         public string CardWeight{get;set;}
         public string CardMachineid{get;set;}

         public string CardLockerno{get;set;}
         public string CardReceiptno{get;set;}
         public string CardPhoneno{get;set;}
         public string CardExtratime{get;set;}
         public string CardExtratimecost{get;set;}
         public string CardExtraweight{get;set;}
         public string CardExtraweightcost{get;set;}
         public string CardTotalcost{get;set;}
         public string CardReply{get;set;}
         public string CardOTime{get;set;}
         public string CardOCardNo{get;set;}
         public string CardOAmount{get;set;}
        
        /// <summary>
        /// 寄件时称得的重量
        /// </summary>
        public float JiIianWeight { get; set; }
        
        /// <summary>
        /// 寄件称重后计算出的费用
        /// </summary>
        public float JiJianMoney { get; set; }
        //取件电话号码
        public string QuJianSendPhone { get; set; }
        public string JiJianRecPhone { get; set; }
       
        public string eiBarcode { get; set; }

        public string JiJianRecName { get; set; }

        public string JiJianPkgName { get; set; }

        public string JiJianPhone { get; set; }

        public int JiJianMouthType { get; set; }

        public string JiJianBarCode { get; set; }

        public string JiJianMouthNo { get; set; }

        public string JiJianInfo { get; set; }

        /// <summary>
        /// 逾期件ID
        /// </summary>
        public int ExceptionExpressId { get; set; }
        /// <summary>
        /// 逾期件交纳额度
        /// </summary>
        public double ExceptionExpressFee { get; set; }
        /// <summary>
        /// 其他情況需要支付的金額
        /// </summary>
        public double ExceptionPayMoney { get; set; }
        public double ExtraWeight { get; set; }
        /// <summary>
        /// 逾期的天数
        /// </summary>
        public int ExceptionOverTime{get;set;}
    }
}
