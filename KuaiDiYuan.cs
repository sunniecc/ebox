using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Entity;
using Newtonsoft.Json.Linq;
using EBoxClient.Utils;
using System.Threading;

namespace EBoxClient
{
    partial class FrmMain
    {
        public void courierExit()
        {
            var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
            int uiId = userInfo["userInfo"].Value<int>("uiId");
            if (uiId > 0)
            {
                service.userLoginOut(uiId.ToString(), 4);
            }
        }

        public void setBarCode()
        { }

        public void test()
        {
            service.testDownLoad();
        }

        public string CheckOrderByBarCode(string barCode)
        {
            var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
            var onelevelorgid = userInfo["userInfo"].Value<int>("uiDeptId");
            var r = service.orderCheckExpressByBarCode(barCode, onelevelorgid);
            return JsonHelper.ToJson(r);
        }

        public string validateBarCode(string barCode, string phone, int mouthTypeId)
        {
            var a = JsonHelper.ToJson(service.orderCheckExpress(phone, barCode, uiData.PBoxInfo.PBCRTNO));
            uiData.JiJianBarCode = barCode;
            uiData.JiJianPhone = phone;
            uiData.JiJianMouthType = mouthTypeId;
            uiData.JiJianInfo = a;
            var freeMouth = localData.GetBoxLockNoByTypeID(mouthTypeId);
            for (; ; )
            {
                if (null == freeMouth)
                {
                    a = "4";
                    break;
                }
                int rst = service.validateMouthNo(freeMouth.MONO);
                if (rst == 1)
                {
                    var borderNo = -1;
                    int.TryParse(freeMouth.MOCSANO, out borderNo);
                    boxDoor.Open(borderNo, freeMouth.MOLOCKNO);
                    uiData.JiJianMouthNo = freeMouth.MONO;
                    break;
                }
                else if (rst == 0)
                {
                    localData.lockMouthArkState(freeMouth.MONO, Convert.ToInt32(freeMouth.MOPBID));
                    freeMouth = localData.GetBoxLockNoByTypeID(mouthTypeId);
                }
                else
                {
                    a = "networkError";
                    break;
                }
            }


            return a;
        }

        /// <summary>
        /// 验证格口门是否关闭
        /// true  开
        /// false 关
        /// </summary>
        /// <returns></returns>
        public string validateBoxDoorStatus()
        {
            bool[,] statuses = boxDoor.GetStatus();

            string rst = "";
            int mouthArkCnt = 0;
		
            for (int i = 0; i < boxDoor.BoardCount; i++)
            {
                for (int j = 0; j < boxDoor.LockCount; j++)
                {
                    if (statuses[i, j])
                    {
                        LogHelper.Log("当前柜编号为" + (i) + ",当前门编号为" + (j + 1));
                        rst = rst + (j + 1 + mouthArkCnt) + ",";
                    }
                }
                mouthArkCnt = mouthArkCnt + localData.queryMouthArkNum((i + 1) + "");
            }
            if (rst.Length > 1)
            {
                rst = rst.Substring(0, rst.Length - 1);
            }
            return rst;
        }

        public string queryTimeAndForbidden(string phone, string barcode)
        {
            return JsonHelper.ToJson(service.queryTimeAndForbidden(phone, barcode));
        }
     /// <summary>
     /// money用户需要补的钱
     /// selectNo用户补钱的原因
     ///1.超重 2.修理 3.有冷气 4.干洗服务 5.其他情况
     /// </summary>
     /// <param name="money"></param>
     /// <param name="selectNo"></param>
     /// <returns></returns>

        public string saveStoreExpress(float money,int selectNo,string language)
        {
            try
            {
                var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                var onelevelorgid = userInfo["userInfo"].Value<int>("onelevelorgid");
                var onelevelorgname = userInfo["userInfo"].Value<string>("onelevelorgname");
                var uiId = userInfo["userInfo"].Value<int>("uiId");
                var uiUserName = userInfo["userInfo"].Value<string>("uiUserName");
                var uiUserPhone = userInfo["userInfo"].Value<string>("uiUserPhone");
                //var jiJianInfo = JsonHelper.ToObject(uiData.JiJianInfo);
                //var eiTakeUserId = jiJianInfo.Value<int?>("eiTakeUserId");
                //var eiTakeUserName = jiJianInfo.Value<string>("eiTakeUserName");
                //var sysId = jiJianInfo.Value<int?>("eiId");

                string expressId = "";
                var tryTimes = 0;
                while (tryTimes++ < 10)
                {
                    expressId = (service.expressId() ?? string.Empty).ToString();
                    if (!(string.IsNullOrEmpty(expressId) || expressId.Length < 5))
                    {
                        break;
                    }
                    Thread.Sleep(200);
                }
                if (string.IsNullOrEmpty(expressId) || expressId.Length < 5)
                {
                    throw new Exception("获取订单号失败");
                }
                // 到付件：快递员与客户都收钱|快递员存件：只有快递员收钱，快递员收钱只传格口费用
                 var payModel=0;
                 if (selectNo==1)
                 {
                     
                      DateTime DiscountEndTime = Setting.Instance.DiscountEnd;

                      if (DateTime.Compare(DateTime.Now, DiscountEndTime) > 0)
                      {

                          uiData.ExtraWeight = float.Parse((money / Setting.Instance.UnitExp) * 0.5 + "");
                      }
                      else
                      {
                          uiData.ExtraWeight = float.Parse((money /Setting.Instance.uUnitExp) * 0.5 + "");
                      }
                }
                if(money>0 && selectNo>0)
                {
                    payModel=1012;
                }
                else{
                    payModel=1010;
                }
              
                var mouthMoney = getMouthMoney(uiData.JiJianMouthNo, uiData.PBoxInfo.PBID);
                var mouthPrice = mouthMoney.ToString("0.0");

                /*
                if (mouthMoney > 0)
                {
                    var r = service.courierDeduction(uiId, expressId, uiData.PBoxInfo.PBID, uiData.PBoxInfo.PBCRTNO, mouthMoney);
                    if (r != null && r.ToString() == "-1")
                        localData.lockMouthArkState(uiData.JiJianMouthNo, uiData.PBoxInfo.PBID);
                }*/
                string rst = "-3";
                //根据barcode来判断语言
               language= uiData.JiJianBarCode.Substring(uiData.JiJianBarCode.Length - 1);
                var info = service.expressSave(uiData.JiJianBarCode, uiData.PBoxInfo.PBABBR, uiData.PBoxInfo.PBCRTNO,
                   uiData.JiJianMouthNo, onelevelorgid, onelevelorgname, payModel, ""+money, uiId, uiUserName, uiUserPhone,
                   null, null, uiData.JiJianPhone, null, expressId, uiData.PBoxInfo.PBID, mouthPrice, language);
                LogHelper.Log("info---------------"+info);
                if (Service.IsValidResult(info) && info.ToString() != expressId.ToString())
                {
                    bool ok = localData.lockMouthArkState(uiData.JiJianMouthNo, uiData.PBoxInfo.PBID);
                    var localInfo = localData.submitStoreExpress(info as JObject);
                    if (localInfo == null || !ok)
                    {
                        rst = "-2";
                    }
                    else
                    {
                        var result = new
                        {
                            barcode = uiData.JiJianBarCode,
                            phone = uiData.JiJianPhone,
                            moNo = uiData.JiJianMouthNo,
                            mouthMoney = mouthPrice
                            

                        };
                        double uaCompanyActMoney = userInfo["userAccount"].Value<double>("uaCompanyActMoney");
                        userInfo["userAccount"]["uaCompanyActMoney"] = (uaCompanyActMoney - Convert.ToDouble(mouthPrice)).ToString("0.00");
                        uiData.UserInfo = userInfo;
                        
                        if (money >0)
                        {
                            //说明是到付件，修改快件状态为代付款状态TF_BUZSTATUS=2
                          var order=localInfo.EIORDERNO;
                          localData.PayMoneyExpress(order, money);

                        }
                        return JsonHelper.ToJson(result);
                    }
                }
                //发生异常后开锁，取消存件
                var ark = localData.GetMouthArkByBoxNo(uiData.JiJianMouthNo);
                if (ark != null)
                {
                    localData.freeMouthArkState(uiData.JiJianMouthNo, uiData.PBoxInfo.PBCRTNO);
                    int boardNo = -1;
                    int.TryParse(ark.MOCSANO, out boardNo);
                    boxDoor.Open(boardNo, ark.MOLOCKNO);
                }
                return rst;
            }
            catch (Exception ex)
            {
                LogHelper.Log("保存包裹信息异常", ex);
                return "-2";
            }
        }

        float getMouthMoney(string mouthNo, int pbId)
        {
            var sql = @"select ma.mo_standFee money from ebox_mouth_ark ma where ma.mo_pbId={0} and ma.mo_no={1} and ma.tf_deleteflag=0";
            var money = localData.Query<MouthMoney>(sql, pbId, mouthNo).FirstOrDefault();
            return money == null || !money.money.HasValue ? 0 : money.money.Value;
        }
        class MouthMoney
        {
            public float? money { get; set; }
        }

        public void finishStoreExpress()
        { }
        public string loadUserExpress()
        {
            LogHelper.Log("loadUserExpress:uiData.UserType = " + uiData.UserType);
            generateException();
            if (3 == uiData.UserType)
            {
                return loadUserExpress(uiData.PBoxInfo.PBCRTNO);
            }
            else if (4 == uiData.UserType)
            {
                var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                var onelevelorgid = userInfo["userInfo"].Value<int>("uiDeptId");
                return loadUserExpress(onelevelorgid.ToString(), uiData.PBoxInfo.PBCRTNO);
            }
            return "";
        }

        private void generateException()
        {
            localData.getOvertimeExpresses();
        }

        public string loadUserExpress(string eboxNo)
        {
            var sql = @"select 
ei.ei_id as eiId,
ei.ei_storeUserName as eiStoreUserName,
ei.ei_storeUserPhone as eiStoreUserPhone,
ei.ei_storeTime as eiStoreTime,
ei.ei_paymentMoney as eiPaymentMoney,
ei.ei_latticeNo as eiLatticeNo,
sub.ei_cityName as eiCityName,
ark.mo_lockNo as moLockNo
  from ebox_expresinfo ei
join ebox_expressubinfo sub 
on sub.ei_orderNo=ei.ei_orderNo
join ebox_mouth_ark ark
on (ark.mo_no=ei.ei_latticeNo and ark.mo_pbNo=ei.ei_eboxNo  and ark.TF_DELETEFLAG=0)
where ei.el_storeUserType='1'  
and ei.tf_deleteFlag=0
and ei.tf_buzStatus in (2,3)
and ei.ei_eboxNo={0}
";
            return JsonHelper.ToJson(localData.Query<UserExpress>(sql, eboxNo));
        }
        public string loadUserExpress(string lcId, string eboxNo)
        {
            LogHelper.Log("loadUserExpress(string lcId, string eboxNo):lcId=" + lcId + ",eboxNo=" + eboxNo);
            var sql = @"select 
ei.ei_id as eiId,
ei.ei_storeUserName as eiStoreUserName,
ei.ei_storeUserPhone as eiStoreUserPhone,
ei.ei_storeTime as eiStoreTime,
ei.ei_paymentMoney as eiPaymentMoney,
ei.ei_latticeNo as eiLatticeNo,
sub.ei_cityName as eiCityName,
ark.mo_lockNo as moLockNo
  from ebox_expresinfo ei
join ebox_expressubinfo sub 
on sub.ei_orderNo=ei.ei_orderNo
join ebox_mouth_ark ark
on (ark.mo_no=ei.ei_latticeNo and ark.mo_pbNo=ei.ei_eboxNo  and ark.TF_DELETEFLAG=0)
where ei.el_storeUserType=1  
and ei.tf_deleteFlag=0
and ei.tf_buzStatus in (2,3)
and ei.ei_lcid={0}
and ei.ei_eboxNo={1}
";
            return JsonHelper.ToJson(localData.Query<UserExpress>(sql, lcId, eboxNo));
        }

        class UserExpress
        {
            public object eiId { get; set; }
            public object eiStoreUserName { get; set; }
            public object eiStoreUserPhone { get; set; }
            public object eiStoreTime { get; set; }
            public object eiPaymentMoney { get; set; }
            public object eiLatticeNo { get; set; }
            public object eiCityName { get; set; }
            public object moLockNo { get; set; }
        }
        public List<JiJianCount> GetJiJianCount(string eboxNo)
        {
            var sql = @"select count(ei.ei_id) as cnt
  from ebox_expresinfo ei
join ebox_expressubinfo sub 
on sub.ei_orderNo=ei.ei_orderNo
where ei.el_storeUserType='1'  
and ei.tf_deleteFlag='0'
and ei.tf_buzStatus in (2,3)
and ei.ei_eboxNo={0}";
            return localData.Query<JiJianCount>(sql, eboxNo).ToList();
        }
        /// <summary>
        /// 快递员查询寄件数量
        /// </summary>
        public List<JiJianCount> GetJiJianCount(string lcId, string eboxNo)
        {
            var sql = @"select count(ei.ei_id) as cnt
  from ebox_expresinfo ei
join ebox_expressubinfo sub 
on sub.ei_orderNo=ei.ei_orderNo
where ei.el_storeUserType='1'  
and ei.tf_deleteFlag='0'
and ei.tf_buzStatus in (2,3)
and ei.EI_LCID={0}
and ei.ei_eboxNo={1}";
            return localData.Query<JiJianCount>(sql, lcId, eboxNo).ToList();
        }

        public class JiJianCount
        {
            public int cnt { get; set; }
        }

        public List<JiJianCount> GetJiJianExceptionCount(string eboxNo)
        {
            var sql = @"SELECT COUNT(ei.ei_id) as cnt 
                        from ebox_expresinfo ei 
                        where ei.ei_mailType=2 and ei.tf_buzStatus=5 and ei.ei_eboxNo={0}";
            return localData.Query<JiJianCount>(sql, eboxNo).ToList();
        }

        public List<JiJianCount> GetJiJianExceptionCount(string lcId, string eboxNo)
        {
            var sql = @"SELECT COUNT(ei.ei_id) as cnt 
                        from ebox_expresinfo ei 
                        where ei.ei_mailType=2 and ei.tf_buzStatus=5 and ei.EI_LCID={0}
                        and ei.ei_eboxNo={1}";
            return localData.Query<JiJianCount>(sql, lcId, eboxNo).ToList();
        }
        public List<JiJianCount> GetJiJianOverTimeCount(string eboxNo)
        {
            var sql = @"SELECT COUNT(ei.ei_id) as cnt from ebox_expresinfo ei 
                        JOIN ebox_expressexception ee on ei.ei_id=ee.eo_eiId
                        where ei.ei_mailType=2 and ei.tf_buzStatus=7  and ei.ei_eboxNo={0} and ei.TF_DELETEFLAG=0";
            return localData.Query<JiJianCount>(sql, eboxNo).ToList();
        }
        public List<JiJianCount> GetJiJianOverTimeCount(string lcId, string eboxNo)
        {
            var sql = @"SELECT COUNT(ei.ei_id) as cnt from ebox_expresinfo ei JOIN ebox_expressexception ee on ei.ei_id=ee.eo_eiId
where ei.ei_mailType=2 and ei.tf_buzStatus=7  and ei.TF_DELETEFLAG=0 and ei.EI_LCID={0} 
and ei.ei_eboxNo={1}";
            return localData.Query<JiJianCount>(sql, lcId, eboxNo).ToList();
        }

        public string openStoreExpress()
        {
            if (uiData.Method == 4)
            {
                var r = new
                {
                    exceptionExpress = GetJiJianExceptionCount(uiData.PBoxInfo.PBCRTNO).FirstOrDefault().cnt,
                    overtimeExpress = GetJiJianOverTimeCount(uiData.PBoxInfo.PBCRTNO).FirstOrDefault().cnt,
                    custExpress = GetJiJianCount(uiData.PBoxInfo.PBCRTNO).FirstOrDefault().cnt
                };
                return JsonHelper.ToJson(r);
            }
            else
            {
                var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                var onelevelorgid = userInfo["userInfo"].Value<int>("onelevelorgid");
                var r = new
                {
                    exceptionExpress = GetJiJianExceptionCount(onelevelorgid.ToString(), uiData.PBoxInfo.PBCRTNO).FirstOrDefault().cnt,
                    overtimeExpress = GetJiJianOverTimeCount(onelevelorgid.ToString(), uiData.PBoxInfo.PBCRTNO).FirstOrDefault().cnt,
                    custExpress = GetJiJianCount(onelevelorgid.ToString(), uiData.PBoxInfo.PBCRTNO).FirstOrDefault().cnt,
                    data = localData.loadMouthArkStoreStatus(uiData.PBoxInfo.PBCRTNO)
                };
                return JsonHelper.ToJson(r);
            }

        }
        public string loadOvertimeExpress()
        {
            generateException();
            if (3 == uiData.UserType)
            {
                return loadOvertimeExpress(uiData.PBoxInfo.PBCRTNO);
            }
            else if (4 == uiData.UserType)
            {
                var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                var onelevelorgid = userInfo["userInfo"].Value<int>("onelevelorgid");
                return loadOvertimeExpress(onelevelorgid.ToString(), uiData.PBoxInfo.PBCRTNO);
            }
            return "";
        }
        public string loadOvertimeExpress(string eboxNo)
        {
            var sql = @"select 
ei.ei_id as eiId,
ei.ei_barcode as eiBarcode,
ei.EI_TAKEUSERPHONE as eiTakeUserPhone,
ei.ei_storeTime as eiStoreTime,
ei.ei_paymentMoney as eiPaymentMoney,
ei.ei_latticeNo as eiLatticeNo,
ee.eo_overtimeDay as overTimeDay,
ark.mo_lockNo as moLockNo
  from ebox_expresinfo ei
join ebox_expressexception ee
on ei.ei_id=ee.eo_eiId
join ebox_mouth_ark ark
on (ark.mo_no=ei.ei_latticeNo and ark.mo_pbNo=ei.ei_eboxNo and ark.TF_DELETEFLAG=0)
where ei.el_storeUserType=2 
and ei.tf_deleteFlag=0
and ei.tf_buzStatus in (7)
and ee.eo_expType=2
and ei.ei_eboxNo={0}
";
            var a = localData.Query<OvertimeExpress>(sql, eboxNo).ToList();
            var b = JsonHelper.ToJson(a);
            return b;
        }
        public string loadOvertimeExpress(string lcId, string eboxNo)
        {
            var sql = @"select 
ei.ei_id as eiId,
ei.ei_barcode as eiBarcode,
ei.EI_TAKEUSERPHONE as eiTakeUserPhone,
ei.ei_storeTime as eiStoreTime,
ei.ei_paymentMoney as eiPaymentMoney,
ei.ei_latticeNo as eiLatticeNo,
ee.eo_overtimeDay as overTimeDay,
ark.mo_lockNo as moLockNo
  from ebox_expresinfo ei
join ebox_expressexception ee
on ei.ei_id=ee.eo_eiId
join ebox_mouth_ark ark
on (ark.mo_no=ei.ei_latticeNo and ark.mo_pbNo=ei.ei_eboxNo and ark.TF_DELETEFLAG=0)
where ei.el_storeUserType=2  
and ei.tf_deleteFlag=0
and ei.tf_buzStatus in (7)
and ee.eo_expType=2
and ei.EI_LCID={0}
and ei.ei_eboxNo={1}
";
            var a = localData.Query<OvertimeExpress>(sql, lcId, eboxNo).ToList();
            var b = JsonHelper.ToJson(a);
            return b;
        }
        class OvertimeExpress
        {
            public object moTypeId { get; set; }
            public object momodel { get; set; }
            public object cnt { get; set; }
            public object eiId { get; set; }
            public object eiBarcode { get; set; }
            public object eiStoreUserName { get; set; }
            public object eiTakeUserPhone { get; set; }
            public object eiStoreTime { get; set; }
            public object eiPaymentMoney { get; set; }
            public object eiLatticeNo { get; set; }
            public object overTimeDay { get; set; }
            public object moLockNo { get; set; }
        }

        public string loadExceptionExpress()
        {
            if (3 == uiData.UserType)
            {
                return loadExceptionExpress(uiData.PBoxInfo.PBCRTNO);
            }
            else if (4 == uiData.UserType)
            {
                var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                var onelevelorgid = userInfo["userInfo"].Value<int>("onelevelorgid");
                return loadExceptionExpress(onelevelorgid.ToString(), uiData.PBoxInfo.PBCRTNO);
            }
            return "";
        }

        public string loadExceptionExpress(string eboxNo)
        {
            var sql = @"              select 
ei.ei_id as eiId,
ei.ei_storeUserName as eiStoreUserName,
ei.ei_storeUserPhone as eiStoreUserPhone,
ei.ei_storeTime as eiStoreTime,
ei.ei_paymentMoney as eiPaymentMoney,
ei.EI_BARCODE as eiBarcode,
ei.ei_latticeNo as eiLatticeNo,
ei.EL_EXPREMARK as eoRemark,
ark.mo_lockNo as moLockNo
  from ebox_expresinfo ei
join ebox_mouth_ark ark
on (ark.mo_no=ei.ei_latticeNo and ark.mo_pbNo=ei.ei_eboxNo and ark.TF_DELETEFLAG=0 )
where ei.tf_deleteFlag=0
and ei.tf_buzStatus =5
and ei.ei_eboxNo={0}
";
            return JsonHelper.ToJson(localData.Query<ExceptionExpress>(sql, eboxNo));
        }

        public string loadExceptionExpress(string lcid, string eboxNo)
        {
            var sql = @"              select 
ei.ei_id as eiId,
ei.ei_storeUserName as eiStoreUserName,
ei.ei_storeUserPhone as eiStoreUserPhone,
ei.ei_storeTime as eiStoreTime,
ei.ei_paymentMoney as eiPaymentMoney,
ei.EI_BARCODE as eiBarcode,
ei.ei_latticeNo as eiLatticeNo,
ei.EL_EXPREMARK as eoRemark,
ark.mo_lockNo as moLockNo
  from ebox_expresinfo ei
join ebox_mouth_ark ark
on (ark.mo_no=ei.ei_latticeNo and ark.mo_pbNo=ei.ei_eboxNo and ark.TF_DELETEFLAG=0 )
where ei.tf_deleteFlag=0
and ei.tf_buzStatus =5
and ei.EI_LCID={0}
and ei.ei_eboxNo={1}
";
            return JsonHelper.ToJson(localData.Query<ExceptionExpress>(sql, lcid, eboxNo));
        }
        class ExceptionExpress
        {
            public object eiId { get; set; }
            public object eiStoreUserName { get; set; }
            public object eiBarcode { get; set; }
            public object eiStoreUserPhone { get; set; }
            public object eiStoreTime { get; set; }
            public object eiPaymentMoney { get; set; }
            public object eiLatticeNo { get; set; }
            public object eoRemark { get; set; }
            public object moLockNo { get; set; }
        }

        public void InitBarCodeScannerToRead()
        {
            barCodeScanner.StartRead();
        }

        /// <summary>
        /// 快递员、管理员取件完成后调用
        /// </summary>
        public void finishGetExpress(string eiId)
        {
            LogHelper.Log("finishGetExpress:uiData.UserType = " + uiData.UserType + ",eboxOrderNo:" + eiId);
            var expressList = localData.QueryExpresses(eiId);
            switch (uiData.UserType)
            {

                //3是管理员
                case 3:
                    {
                        var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                        var userId = userInfo["userInfo"].Value<string>("uiId");
                        var uaUserIdType = "";
                        var uaUserIdCode = "";
                        var ids = uiData.ExpressIdList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => Convert.ToInt32(c));
                        foreach (var e in expressList)
                        {
                            var rst = service.administratorToTake(e.EIEBOXID.ToString(), e.EIEBOXNO, e.EIORDERNO,
                                    userId.ToString(), "" + e.TFBUZSTATUS, e.EILCID.ToString(),
                                    uaUserIdType.ToString(), uaUserIdCode.ToString(), e.EILATTICENO);
                            LogHelper.Log("KuaiDiYuan:rst = " + rst);
                            if (rst.ToString() == "-1")
                            {
                                localData.freeMouthArkState(e.EILATTICENO, e.EIEBOXNO);

                                localData.finishExpressBuz(e.EIID, e.TFBUZSTATUS + 1);

                            }
                        }
                        break;
                    }
                //userType=4是快递员
                case 4:
                    {
                        var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                        var userId = userInfo["userInfo"].Value<string>("uiId");
                        var uaUserIdCode = userInfo["userAccount"].Value<string>("uaUserIdCode");
                        var uaUserIdType = userInfo["userAccount"].Value<string>("uaUserIdType");
                        var ids = uiData.ExpressIdList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => Convert.ToInt32(c));
                        foreach (var e in expressList)
                        {
                            // var ark = localData.GetMouthArkByBoxNo(e.EILATTICENO);
                            if (e.EIMAILTYPE == 2)
                            {


                                var rst = service.courierTakeSend(e.EIEBOXID.ToString(), e.EIEBOXNO, e.EIORDERNO,
                                    userId.ToString(), "3", e.EILCID.ToString(),
                                    uaUserIdType.ToString(), uaUserIdCode.ToString(), e.EILATTICENO);
                                if (rst.ToString() == "-1")
                                {
                                    localData.freeMouthArkState(e.EILATTICENO, e.EIEBOXNO);
                                    localData.finishExpressBuz(e.EIID, 4);
                                }
                            }

                            else
                            {

                                var rst = service.expressTakeAbnormal(e.EIEBOXID.ToString(), e.EIEBOXNO, e.EIORDERNO,
                                    userId.ToString(), "" + e.TFBUZSTATUS, e.EILCID.ToString(),
                                    uaUserIdType.ToString(), uaUserIdCode.ToString(), e.EILATTICENO);
                                if (rst.ToString() == "-1")
                                {
                                    localData.freeMouthArkState(e.EILATTICENO, e.EIEBOXNO);
                                    localData.finishExpressBuz(e.EIID, e.TFBUZSTATUS + 1);
                                }
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        public void finishGetExpressForTakeAbnormal(string eiId)
        {
            LogHelper.Log("finishGetExpressForTakeAbnormal:uiData.UserType = " + uiData.UserType + ",eboxOrderNo:" + eiId);
            var expressList = localData.QueryExpresses(eiId);
            switch (uiData.UserType)
            {

                //3是管理员
                case 3:
                    {
                        var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                        var userId = userInfo["userInfo"].Value<string>("uiId");
                        var uaUserIdType = "";
                        var uaUserIdCode = "";
                        var ids = uiData.ExpressIdList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => Convert.ToInt32(c));
                        foreach (var e in expressList)
                        {
                            var rst = service.administratorToTake(e.EIEBOXID.ToString(), e.EIEBOXNO, e.EIORDERNO,
                                    userId.ToString(), "" + e.TFBUZSTATUS, e.EILCID.ToString(),
                                    uaUserIdType.ToString(), uaUserIdCode.ToString(), e.EILATTICENO);
                            LogHelper.Log("KuaiDiYuan:rst = " + rst);
                            if (rst.ToString() == "-1")
                            {
                                localData.freeMouthArkState(e.EILATTICENO, e.EIEBOXNO);

                                localData.finishExpressBuz(e.EIID, e.TFBUZSTATUS + 1);

                            }
                        }
                        break;
                    }
                //userType=4是快递员
                case 4:
                    {
                        var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                        var userId = userInfo["userInfo"].Value<string>("uiId");
                        var uaUserIdCode = userInfo["userAccount"].Value<string>("uaUserIdCode");
                        var uaUserIdType = userInfo["userAccount"].Value<string>("uaUserIdType");
                        var ids = uiData.ExpressIdList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => Convert.ToInt32(c));
                        foreach (var e in expressList)
                        {
                            // var ark = localData.GetMouthArkByBoxNo(e.EILATTICENO);
                            var rst = service.expressTakeAbnormal(e.EIEBOXID.ToString(), e.EIEBOXNO, e.EIORDERNO,
                                userId.ToString(), "" + e.TFBUZSTATUS, e.EILCID.ToString(),
                                uaUserIdType.ToString(), uaUserIdCode.ToString(), e.EILATTICENO);
                            if (rst.ToString() == "-1")
                            {
                                localData.freeMouthArkState(e.EILATTICENO, e.EIEBOXNO);
                                localData.finishExpressBuz(e.EIID, e.TFBUZSTATUS + 1);
                            }

                        }
                        break;
                    }
                default:
                    break;
            }
        }

        public void finishGetExpressForTakeSend(string eiId)
        {
            LogHelper.Log("finishGetExpressForTakeSend:uiData.UserType = " + uiData.UserType + ",eboxOrderNo:" + eiId);
            var expressList = localData.QueryExpresses(eiId);
            switch (uiData.UserType)
            {

                //3是管理员
                case 3:
                    {
                        var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                        var userId = userInfo["userInfo"].Value<string>("uiId");
                        var uaUserIdType = "";
                        var uaUserIdCode = "";
                        var ids = uiData.ExpressIdList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => Convert.ToInt32(c));
                        foreach (var e in expressList)
                        {
                            var rst = service.administratorToTake(e.EIEBOXID.ToString(), e.EIEBOXNO, e.EIORDERNO,
                                    userId.ToString(), "" + e.TFBUZSTATUS, e.EILCID.ToString(),
                                    uaUserIdType.ToString(), uaUserIdCode.ToString(), e.EILATTICENO);
                            LogHelper.Log("KuaiDiYuan:rst = " + rst);
                            if (rst.ToString() == "-1")
                            {
                                localData.freeMouthArkState(e.EILATTICENO, e.EIEBOXNO);

                                localData.finishExpressBuz(e.EIID, e.TFBUZSTATUS + 1);

                            }
                        }
                        break;
                    }
                //userType=4是快递员
                case 4:
                    {
                        var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                        var userId = userInfo["userInfo"].Value<string>("uiId");
                        var uaUserIdCode = userInfo["userAccount"].Value<string>("uaUserIdCode");
                        var uaUserIdType = userInfo["userAccount"].Value<string>("uaUserIdType");
                        var ids = uiData.ExpressIdList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => Convert.ToInt32(c));
                        foreach (var e in expressList)
                        {
                            // var ark = localData.GetMouthArkByBoxNo(e.EILATTICENO);
                            var rst = service.courierTakeSend(e.EIEBOXID.ToString(), e.EIEBOXNO, e.EIORDERNO,
                                userId.ToString(), "3", e.EILCID.ToString(),
                                uaUserIdType.ToString(), uaUserIdCode.ToString(), e.EILATTICENO);
                            if (rst.ToString() == "-1")
                            {
                                localData.freeMouthArkState(e.EILATTICENO, e.EIEBOXNO);
                                localData.finishExpressBuz(e.EIID, 4);
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        public string setOpenBoxAttr(string expIDs)
        {
            LogHelper.Log("setOpenBoxAttr:expIDs = " + expIDs);
            //var ids = expIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => Convert.ToInt32(c));
            //var mouthNos = localData.QueryExpress(ids.ToArray()).Select(c => c.EILATTICENO);
            //var mouthNos = localData.QueryExpresses(expIDs);
            LogHelper.Log("mouthNos query success");
            var arks = localData.GetMouthArksByBoxNo(expIDs);
            var r = string.Empty;
            uiData.ExpressIdList = expIDs;
            foreach (var ark in arks)
            {
                int boardNo = -1;
                int.TryParse(ark.MOCSANO, out boardNo);
                LogHelper.Log("执行开锁命令：boardNo = " + boardNo + " ，ark.MOLOCKNO = " + ark.MOLOCKNO);
                boxDoor.Open(boardNo, ark.MOLOCKNO);
                r += ark.MONO + ",";
                Thread.Sleep(2500);
            }
            string rst = r.Trim(',');
            uiData.JiJianMouthNo = rst;
            return rst;
        }
        /*
                public void startCheckDoor()
                {
                    if (Setting.Instance.IsDebug)
                        LogHelper.Log("开始检测电子锁状态");
                    boxDoor.Start();
                }

                public void stopCheckDoor()
                {
                    if (Setting.Instance.IsDebug)
                        LogHelper.Log("停止检测电子锁状态");
                    boxDoor.Stop();
                }
         */
        public void startCheckDoor()
        { }
        public void stopCheckDoor()
        { }
    }
}
