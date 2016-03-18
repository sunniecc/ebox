using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Entity;
using EBoxClient.Device;
using EBoxClient.Utils;
using Newtonsoft.Json.Linq;
using EBoxClient.Data;
using System.Threading;
using System.IO;

namespace EBoxClient
{

    partial class FrmMain
    {
        bool stop = false;
        public string isConnected()
        {
            return JsonHelper.ToJson(new { isConnected = TcpClientHelper.Instance.IsConnected });
        }

        /// <summary>
        /// 用户在页面上输入手机号码和验证码，点击确定，调用CustQuJian方法，容器调用本地数据库获取用户快件数据，将取件数据保存到快件全局变量中
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// 
        public string CustQuJian(string phone, string code)
        {
            try
            {
                //初始化一下逾期费用
                uiData.ExceptionExpressFee = 0;
                //初始化一下逾期时间
                uiData.ExceptionOverTime = 0;
                //var orderNo = service.userToTake(phone, code);
                var money = 0.0;
                double fee = 0.00;
                var intcode = 0L;
                long.TryParse(code, out intcode);
                var overTimeDay="";

                var exp = localData.GetExpressInfo3(phone, intcode);
                uiData.QuJianSendPhone=exp.EITAKEUSERPHONE;
                //自定义一个值给exp

                uiData.Phone = phone;
                if (exp != null)
                {
                    if (exp.TFBUZSTATUS.ToString() == "4" || exp.TFBUZSTATUS.ToString() == "8")
                    {
                        return JsonHelper.ToJson(new { success = false });
                    }
                    if (Convert.ToDouble(exp.EIPAYMENTMONEY) > 0)
                    {
                        money = Convert.ToDouble(exp.EIPAYMENTMONEY);
                    }
                    if (contrastDateIsOverdue(exp.ELOVERTIME))
                    {
                        LogHelper.Log("快件已经逾期，将在本地自行计算逾期金额");
                        exp = localData.changeExpressToOverdue(exp, 0);
                       
                    }
                   
                    eiOrderNo = exp.EIORDERNO;
                    pickupPhoneNumber = phone;
                    pickupIntcode = intcode;
                    uiData.QuJianOrder = exp;
                    LogHelper.Log("CustQuJian：code:" + exp.EIVALIDATECODE + ",tf_buzstatus:" + exp.TFBUZSTATUS + ",ei_barcode" + exp.EIBARCODE + ",ei_takeuserphone:" + exp.EITAKEUSERPHONE);




                    if (exp.TFBUZSTATUS == 3 || exp.TFBUZSTATUS == 7)
                    {


                        //有其他费用要支付
                        if (money > 0)
                        {
                            var ee = localData.getExceptionExpress(exp.EIORDERNO, exp.EIID);
                            LogHelper.Log("expressException:" + JsonHelper.ToJson(ee));
                            JsonHelper jh = new JsonHelper();
                            if (null != ee)
                            {
                                uiData.ExceptionExpressId = ee.EOID;
                                uiData.ExceptionExpressFee = Convert.ToDouble(ee.EOOVERTIMEFEE == null ? 0 : ee.EOOVERTIMEFEE);
                                uiData.ExceptionOverTime = Convert.ToInt32(ee.EOOVERTIMEDAY);
                                fee = Convert.ToDouble(ee.EOOVERTIMEFEE == null ? 0 : ee.EOOVERTIMEFEE);
                                //是逾期件
                                if (fee > 0)
                                {
                                    uiData.ExceptionPayMoney = money;
                                    return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(), substatus = ee.TFBUZSTATUS, status = exp.TFBUZSTATUS.ToString(), paymoney = money });
                                }
                              
                            }
                            uiData.ExceptionPayMoney = money;
                            return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(),  status = exp.TFBUZSTATUS.ToString(), paymoney = money });
                        }
                        //没有其他费用要支付
                        else if (money <= 0)
                        {
                            var ee = localData.getExceptionExpress(exp.EIORDERNO, exp.EIID);
                            LogHelper.Log("expressException:" + JsonHelper.ToJson(ee));
                            JsonHelper jh = new JsonHelper();
                            if (null != ee)
                            {
                                uiData.ExceptionExpressId = ee.EOID;
                                uiData.ExceptionExpressFee = Convert.ToDouble(ee.EOOVERTIMEFEE == null ? 0 : ee.EOOVERTIMEFEE);
                                uiData.ExceptionOverTime = Convert.ToInt32(ee.EOOVERTIMEDAY);
                                fee = Convert.ToDouble(ee.EOOVERTIMEFEE == null ? 0 : ee.EOOVERTIMEFEE);
                                //是逾期件
                                if (fee > 0)
                                {
                                    uiData.ExceptionPayMoney = money;
                                   
                                    return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(), substatus = ee.TFBUZSTATUS, status = exp.TFBUZSTATUS.ToString(), paymoney = money });
                                }
                            }
                         
                            uiData.ExceptionPayMoney = money;
                            return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(),status = exp.TFBUZSTATUS.ToString(), paymoney = money });

                        }
                        return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(), status = exp.TFBUZSTATUS.ToString() });
                  
                    }
                   

                }
                else
                {
                    LogHelper.Log("exp == null! JiJian.cs 28");
                    return JsonHelper.ToJson(new { success = false, type = 0 });
                }
                //    if (exp.TFBUZSTATUS == 3 && money <= 0)
                //    {
                //        return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(), status = exp.TFBUZSTATUS.ToString() });
                //    }
                //    //有其他费用要支付
                //    else if (money > 0)
                //    {
                //        var ee = localData.getExceptionExpress(exp.EIORDERNO, exp.EIID);
                //        LogHelper.Log("expressException:" + JsonHelper.ToJson(ee));
                //        JsonHelper jh = new JsonHelper();
                //        if (null != ee)
                //        {
                //            uiData.ExceptionExpressId = ee.EOID;
                //            uiData.ExceptionExpressFee = Convert.ToDouble(ee.EOOVERTIMEFEE == null ? 0 : ee.EOOVERTIMEFEE);
                //            fee = Convert.ToDouble(ee.EOOVERTIMEFEE == null ? 0 : ee.EOOVERTIMEFEE);
                //            //是逾期件
                //            if (fee > 0)
                //            {

                //                uiData.ExceptionExpressFee = fee;
                //                uiData.ExceptionPayMoney = money;
                //                return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(), substatus = ee.TFBUZSTATUS, status = exp.TFBUZSTATUS.ToString(), paymoney = money });
                //            }
                //            else
                //            { //不是逾期件
                //                uiData.ExceptionExpressFee = fee;
                //                uiData.ExceptionPayMoney = money;
                //                return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(), substatus = ee.TFBUZSTATUS, status = exp.TFBUZSTATUS.ToString(), paymoney = money });
                //            }

                //        }
                //        uiData.ExceptionExpressFee = fee;
                //        uiData.ExceptionPayMoney = money;
                //        return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(), status = exp.TFBUZSTATUS.ToString(), paymoney = money });



                //    }
                //    //没有其他费用要支付
                //    else if (money <= 0)
                //    {
                //        var ee = localData.getExceptionExpress(exp.EIORDERNO, exp.EIID);
                //        LogHelper.Log("expressException:" + JsonHelper.ToJson(ee));
                //        JsonHelper jh = new JsonHelper();
                //        if (null != ee)
                //        {
                //            uiData.ExceptionExpressId = ee.EOID;
                //            uiData.ExceptionExpressFee = Convert.ToDouble(ee.EOOVERTIMEFEE == null ? 0 : ee.EOOVERTIMEFEE);
                //            fee = Convert.ToDouble(ee.EOOVERTIMEFEE == null ? 0 : ee.EOOVERTIMEFEE);
                //            //是逾期件
                //            if (fee > 0)
                //            {
                //                uiData.ExceptionPayMoney = money;
                //                uiData.ExceptionExpressFee = fee;
                //                return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(), substatus = ee.TFBUZSTATUS, status = exp.TFBUZSTATUS.ToString(), paymoney = money });
                //            }
                //        }
                //        uiData.ExceptionExpressFee = fee;
                //        uiData.ExceptionPayMoney = money;
                //        return JsonHelper.ToJson(new { success = true, type = (exp.EIPAYMENTMODE ?? 0).ToString(), status = exp.TFBUZSTATUS.ToString(), paymoney = money });

                //    }

                //}
            }
            catch (Exception e)
            {
                LogHelper.Log("" + e.StackTrace);
            }
            return JsonHelper.ToJson(new { success = false, type = 0 });
        }

        private Boolean contrastDateIsOverdue(String date)
        {
            DateTime dt = Convert.ToDateTime(date);
            DateTime now = DateTime.Now;
            Boolean isOverdue = DateTime.Compare(dt, now) <= 0;
            return isOverdue;
        }
        //拿到逾期几天
        private int OverdueDay(String date)
        {
            DateTime dt = Convert.ToDateTime(date);
            DateTime now = Convert.ToDateTime(DateTime.Now);
            TimeSpan ts = now - dt;
            return Convert.ToInt32(ts);
        }


        public string paymentOvertimeExpress(double money)
        {
            service.coinsRecharge(money, uiData.Phone);
            return JsonHelper.ToJson(new { success = true });
        }

        public double getPaymentMoney()
        {
            return uiData.ExceptionExpressFee;
        }
        public double getPayOtherMoney()
        {
            return uiData.ExceptionPayMoney;
        }
        public double getExtraWeight()
        {

            return uiData.ExtraWeight;
        }
        public double getOverTimeDay()
        {
            return uiData.ExceptionOverTime;
        }



        /// <summary>
        /// 设置快递公司
        /// </summary>
        /// <param name="id"></param>
        public void SetCmpID(string id)
        {
            uiData.CmpID = id;
        }

        public void SaveJiJianInfo(string proNo, string proName, string cityNo, string cityName, string conNo, string conName,
            string pkgName, string recName, string recPhone, string recAddr)
        {
            uiData.JiJianProNo = proNo;
            uiData.JiJianProName = proName;
            uiData.JiJianCityNo = cityNo;
            uiData.JiJianCityName = cityName;
            uiData.JiJianCountyNo = conNo;
            uiData.JiJianCountyName = conName;
            uiData.JiJianPkgName = pkgName;
            uiData.JiJianRecName = recName;
            uiData.JiJianRecPhone = recPhone;
            uiData.JiJianAddress = recAddr;
        }
        public void SaveJiJianInfo1( string recPhone)
        {
          
            uiData.JiJianRecPhone = recPhone;
         
        }

        public string GetJiJianInfo()
        {
            if (uiData.JiJianPkgName == null)
            {
                return null;
            }
            var info = "JiJianInfo:{\"JiJianProNo\":\"" + uiData.JiJianProNo
                + "\",\"JiJianProName:\":\"" + uiData.JiJianProName
                + "\",\"JiJianCityNo:\":\"" + uiData.JiJianCityNo
                + "\",\"JiJianCityName:\":\"" + uiData.JiJianCityName
                + "\",\"JiJianCountyNo:\":\"" + uiData.JiJianCountyNo
                + "\",\"JiJianCountyName:\":\"" + uiData.JiJianCountyName
                + "\",\"JiJianPkgName:\":\"" + uiData.JiJianPkgName
                + "\",\"JiJianCountyName:\":\"" + uiData.JiJianCountyName
                + "\",\"JiJianRecName:\":\"" + uiData.JiJianRecName
                + "\",\"JiJianRecPhone:\":\"" + uiData.JiJianRecPhone
                + "\",\"JiJianAddress:\":\"" + uiData.JiJianAddress
                + "\"}";
            return JsonHelper.ToJson(info);
        }

        /// <summary>
        /// 页面自动等待超时跳转时，触发autoClose事件，容器清空快件缓冲
        /// </summary>
        /// <returns></returns>
        public string autoClose()
        {
            LogHelper.Log(" auto close Mark");  
            throw new NotImplementedException();
        }

        public void calcExpressFee()
        {
            throw new NotImplementedException();
        }

        public void setPayFee(float money)
        {

        }

        public void confirmDeduction(float money)
        {

        }

        public string GetProviceList()
        {
            var a = JsonHelper.ToJson(localData.GetProviceList());
            return a;
        }

        public string GetCityList(string provId)
        { return JsonHelper.ToJson(localData.GetCityList(provId)); }

        public string GetCountyList(string cityNo)
        { return JsonHelper.ToJson(localData.GetCountyList(cityNo)); }

        /// <summary>
        /// 获取派宝箱配置
        /// </summary>
        public string GetPBoxConfig()
        {
            return JsonHelper.ToJson(localData.GetPBoxConfig());
        }

        public string GetLogisticsCompanyConfig()
        {
            return JsonHelper.ToJson(localData.GetLogisticsCompanyConfig());
        }

        /// <summary>
        /// 寄件时打印条码
        /// </summary>
        public void PrintBarCode()
        {
            var id = (service.expressId() ?? string.Empty).ToString();
            if (id != null && id.ToString() != "-6" && id.ToString() != "{}")
            {
                var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
                var uiUserName = userInfo["userInfo"].Value<string>("ciUserName");
                var uiUserPhone = userInfo["userInfo"].Value<string>("ciUserPhone");
                barCodePrinter.Print(id.ToString(), uiData.JiJianRecName, uiData.JiJianRecPhone, (uiData.JiJianProName + " " + uiData.JiJianCityName
                    + " " + uiData.JiJianCountyName + " " + uiData.JiJianAddress), uiData.JiIianWeight, uiUserName, uiUserPhone);
            }
        }

        /// <summary>
        /// 获取空闲格口列表
        /// </summary>
        public string GetFreeMouthList()
        {
            string rst = JsonHelper.ToJson(localData.GetFreeMouth());
            return rst;
        }

        /// <summary>
        /// 客户寄件选择空闲格口
        /// </summary>
        /// <returns></returns>
        public string GetFreeMouthToCust()
        {
            return JsonHelper.ToJson(localData.GetFreeMouthToCust());
        }
        /// <summary>
        /// 随机打开一个空闲格口
        /// </summary>
        public string OpenBoxByTypeID(int typeId)
        {
            var ark = localData.GetBoxLockNoByTypeID(typeId);
            string result = "";
            for (; ; )
            {
                if (null == ark)
                {
                    break;
                }
                int rst = service.validateMouthNo(ark.MONO);
                if (rst == 1)
                {
                    var borderNo = -1;
                    int.TryParse(ark.MOCSANO, out borderNo);
                    boxDoor.Open(borderNo, ark.MOLOCKNO);
                    result = ark.MONO;
                    break;
                }
                else if (rst == 0)
                {
                    localData.lockMouthArkState(ark.MONO, Convert.ToInt32(ark.MOPBID));
                    ark = localData.GetBoxLockNoByTypeID(typeId);
                }
                else
                {
                    return "";
                }
            }
            return result;

        }
        /// <summary>
        /// 拿到格口号
        /// </summary>
        public string BoxByTypeID(int typeId)
        {
            var ark = localData.GetBoxLockNoByTypeID(typeId);
            string result = "";
            for (; ; )
            {
                if (null == ark)
                {
                    break;
                }
                int rst = service.validateMouthNo(ark.MONO);
                if (rst == 1)
                {
                    var borderNo = -1;
                    int.TryParse(ark.MOCSANO, out borderNo);
                  
                    result = ark.MONO;
                    break;
                }
                else if (rst == 0)
                {
                    localData.lockMouthArkState(ark.MONO, Convert.ToInt32(ark.MOPBID));
                    ark = localData.GetBoxLockNoByTypeID(typeId);
                }
                else
                {
                    return "";
                }
            }
            return result;

        }

        public void OpenBoxByArkId(int arkId)
        {
            var ark = localData.GetBoxLockNoById(arkId);
            if (null != ark)
            {
                var borderNo = -1;
                int.TryParse(ark.MOCSANO, out borderNo);
                boxDoor.Open(borderNo, ark.MOLOCKNO);
            }
        }

        /// <summary>
        /// /打印一维码
        /// </summary>
        public void PrintOneCode()
        { }

        public void pasteOneCode()
        { }

        public void selectMouth()
        { }

        public void openEboxRand()
        { }

        public void OpenRanderBox()
        { }

        /// <summary>
        /// 客户寄件快件数据提交
        /// </summary>
        /// <param name="mouthNo"></param>
        /// <returns></returns>
        public string finishExpress(string mouthNo)
        {
            uiData.JiJianMouthNo = mouthNo;
            //Login("18666668888", "888888");
            

            var loginType = GetLoginType("18666668888");
           
            service.userSendLogin("18666668888", "888888", loginType);
          
            //var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
           // var uiDeptName = userInfo["userInfo"].Value<string>("onelevelorgname");
           // var uiId = userInfo["userInfo"].Value<int>("ciId");
           // var uiUserName = userInfo["userInfo"].Value<string>("ciUserName");
           // var uiUserPhone = userInfo["userInfo"].Value<string>("ciUserPhone");
            //RoyMark 20150515
            var unit = 1;  //克
            var compId = 9;//Convert.ToInt32(uiData.CmpID);
            var comp = localData.GetLogisticsCompanyConfig()
              .FirstOrDefault(c => c.LCLCMAINID.HasValue && c.LCLCMAINID.Value == compId);
            if (comp == null)
            {
                LogHelper.Log("在本地库中没有查询到对应的快递公司，查询编号为：" + compId);
                return "-1";
            }
            var opId = uiData.PBoxInfo.PBOPID;
            var opName = uiData.PBoxInfo.PBOPNAME;
            var elExpSaveMode = 1;

            var expressId = (service.expressId() ?? string.Empty).ToString();
            var payModel = 2030;// uiData.JiJianMoney > 0 ? 3 : 1;
            var mouthMoney = 0;// getMouthMoney(uiData.JiJianMouthNo, uiData.PBoxInfo.PBID);客户寄件暂不收费
            // if (mouthMoney > 0)
            //{
            //var r = service.courierDeduction(uiId, expressId, uiData.PBoxInfo.PBID, uiData.PBoxInfo.PBCRTNO, mouthMoney);
            //if (r != null && r.ToString() == "-1")
            string rst = "0";
            localData.lockMouthArkState(uiData.JiJianMouthNo, uiData.PBoxInfo.PBID);
            //var r = service.eserSend(
            //    uiData.PBoxInfo.PBID, payModel, uiData.JiJianMoney, uiId, uiUserPhone, uiUserName, comp.LCLCID ?? 0, 1, uiData.JiJianMouthNo, comp.LCLCMAINID ?? 0, comp.LCLCNAME, elExpSaveMode, expressId, opId, opName, uiData.JiIianWeight, unit, mouthMoney, uiData.JiJianPkgName, uiData.JiJianMoney,
            //    uiData.JiJianMoney, uiData.JiJianMoney + mouthMoney, expressId, string.Empty, uiData.JiJianProName, uiData.JiJianCityName, uiData.JiJianCountyName, uiData.JiJianAddress, uiData.JiJianRecName, uiData.JiJianRecPhone, mouthMoney, 3);

            var r = service.eserSend(
              uiData.PBoxInfo.PBID, payModel, uiData.JiJianMoney, 173, "18666668888", "阳光存衣", 26, 1, uiData.JiJianMouthNo, 9, "广州顺丰", 1, expressId, opId, opName, uiData.JiJianMoney, unit, mouthMoney, "clothes", uiData.JiJianMoney,
              uiData.JiJianMoney, uiData.JiJianMoney + mouthMoney, expressId, "", "北京", "北京", "东城区", "胡同巷", "李晨", uiData.JiJianRecPhone, mouthMoney, 3,uiData.eiBarcode);
            try
            {
                //将编号自动加1
                String Receiptno1 = Read();
                String now = DateTime.Now.Year + "";
                String lockerNo = Receiptno1.Substring(0, 2);
                now = now.Substring(2, 2);
                if (Receiptno1 == null || Receiptno1 == "")
                {

                    Receiptno1 = "";
                }
                else
                {
                    //将其拼接成01（15是年份）00001
                    int Receiptno2 = int.Parse(Receiptno1);
                    Receiptno2++;
                    Receiptno1 = Receiptno2 + "";
                    Receiptno1 = lockerNo + Receiptno1.Substring(1, Receiptno1.Length - 1);
                    String numNO = Receiptno1.Substring(0, 2);
                    string number = Receiptno1.Substring(4);
                    Receiptno1 = numNO + now + number;
                }
                Write(Receiptno1);
                Console.WriteLine(Receiptno1);
            }
            catch (Exception ex)
            {
                LogHelper.Log("读取打印单号异常", ex);
            }
            if (Service.IsValidResult(r) && r.ToString() != expressId)
            {
                var info = localData.SaveJiJianInfo(r as JObject);
                if (null != info)
                {
                    rst = "1";
                }
                 
            }
            if (null != r && r.ToString() == "-3")
            {
                rst = "-3";
            }
            if (rst != "1")
            {
                localData.freeMouthArkState(uiData.JiJianMouthNo, Setting.Instance.BoxNo);
                var ark = localData.GetMouthArkByBoxNo(uiData.JiJianMouthNo);
                if (null != ark)
                {
                   

                    var borderNo = -1;
                    int.TryParse(ark.MOCSANO, out borderNo);
                    boxDoor.Open(borderNo, ark.MOLOCKNO);
                     
                }
            }
            return rst;
            // }
        }
        /// <summary>
        /// 初始化重量
        /// </summary>
        public void expressWeightInit()
        {
            service.expressWeightInit();
        }
        /// <summary>
        /// 初始化八达通
        /// </summary>
        public void expressCardInit()
        {
            service.expressCardInit();
        }
        
        //查看电子称状态
        public void expressWeight()
        {
            var cmd = "0";
            var weight = "0.0";
            var reply = "0";
            float w = 0f;
            var Weight = service.expressWeight(cmd, weight, reply);
            float.TryParse(Weight, out w);
            string w1 = w.ToString("0.0");
            stop = false;
               
            try
            {
           
            elcWeight_OnReadWeight(float.Parse(w1));
              
            }
            catch (Exception ex)
            {
                LogHelper.Log("读取重量失败", ex);
            }
           
            /*
            var th = new Thread(new ThreadStart(() =>
            {
                var Weight = service.expressWeight(cmd, weight, reply);
                float.TryParse(Weight, out w);
                string w1 = w.ToString("0.0");
                stop = false;
                while (!stop)
                {
                    Thread.Sleep(500);
                    try
                    {
                        if ( float.Parse(w1)!=0)
                        {
                            elcWeight_OnReadWeight(float.Parse(w1));
                            LogHelper.Log("OnReadWeight" + w1);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log("读取重量失败", ex);
                    }
                }
            }));
            th.IsBackground = true;
            th.Start(); */
        }
        //停止拿到电子称
        public void Weightstop()
        {
            stop = true;
        }

        //查看是否有空闲的格口
        public string LookFreeBox()
        {
            var ark = localData.GetFreeBox();
            var retu="";
            if (ark == null)
            {
                retu = "0";
            }
            else {
                retu = "1";
            }
            return retu;

        }
        //MOTYPEID M 1 S 2 MINI-S 3 L 4 XL 5 XXL 6
        // 3 2 1 4 5 6
        public string GetDoorNo(string Weight)
        {
            float fWeight;
         
            fWeight = float.Parse(Weight);
            int LockType = 0;
            int weightType = 0;
            if (fWeight <= 10)
                weightType = 2;
            else if (fWeight <= 15)
                weightType = 3;
            else if (fWeight > 15)
                weightType = 4;
            //else if (fWeight >= 20)
            //    weightType = 4;
            //else if (fWeight < 25)
            //    weightType = 5;
            //else
            //    weightType = 6;
            //oMouthList = localData.GetFreeMouth();


            if ((weightType < 2) && localData.GetBoxLockNoByTypeID(3) != null)
            {
                LockType = 3;
                return OpenBoxByTypeID(LockType);
            }
            else if ((weightType < 3) && localData.GetBoxLockNoByTypeID(2) != null)
            {
                LockType = 2;
                return OpenBoxByTypeID(LockType);
            }
            else if ((weightType < 4) && localData.GetBoxLockNoByTypeID(1) != null)
            {
                LockType = 1;
                return OpenBoxByTypeID(LockType);
            }
            else if ((weightType < 5) && localData.GetBoxLockNoByTypeID(4) != null)
            {
                LockType = 4;
                return OpenBoxByTypeID(LockType);
            }
            //else if (localData.GetBoxLockNoByTypeID(5) != null && (weightType < 6))
            //{
            //    LockType = 5;
            //    return OpenBoxByTypeID(LockType);
            //}
            //else if (localData.GetBoxLockNoByTypeID(6) != null && (weightType < 7))
            //{
            //    LockType = 6;
            //    return OpenBoxByTypeID(LockType);
            //}

            return OpenBoxByTypeID(LockType); ;

        }

        public string onlyGetDoorNo(string Weight)
        {
            float fWeight;

            fWeight = float.Parse(Weight);
            int LockType = 0;
            int weightType = 0;
            if (fWeight <= 10)
                weightType = 2;
            else if (fWeight <= 15)
                weightType = 3;
            else if (fWeight >15)
                weightType = 4;
            //else if (fWeight >=20)
            //    weightType = 4;
            //else if (fWeight < 25)
            //    weightType = 5;
            //else
            //    weightType = 6;
            //oMouthList = localData.GetFreeMouth();


            if ((weightType < 2) && localData.GetBoxLockNoByTypeID(3) != null)
            {
                LockType = 3;
                return BoxByTypeID(LockType);
            }
            else if ((weightType < 3) && localData.GetBoxLockNoByTypeID(2) != null)
            {
                LockType = 2;
                return BoxByTypeID(LockType);
            }
            else if ((weightType < 4) && localData.GetBoxLockNoByTypeID(1) != null)
            {
                LockType = 1;
                return BoxByTypeID(LockType);
            }
            else if ((weightType < 5) && localData.GetBoxLockNoByTypeID(4) != null)
            {
                LockType = 4;
                return BoxByTypeID(LockType);
            }
            //else if (localData.GetBoxLockNoByTypeID(5) != null && (weightType < 6))
            //{
            //    LockType = 5;
            //    return BoxByTypeID(LockType);
            //}
            //else if (localData.GetBoxLockNoByTypeID(6) != null && (weightType < 7))
            //{
            //    LockType = 6;
            //    return BoxByTypeID(LockType);
            //}
            if (LockType == 0)
            {
                return "0";
            }
            return "0"; ;
        }
        public  void ReOpenDoor(string ArkID)
        {
            int iArkID;

            iArkID = int.Parse(ArkID);
            var ark = localData.GetMouthArkByBoxNo(ArkID);

            if (ark != null)
            {
                int boardNo = -1;
                int.TryParse(ark.MOCSANO, out boardNo);
                boxDoor.Open(boardNo, ark.MOLOCKNO);
            }
           //penBoxByArkId(iArkID); 

            
        }
        /// <summary>
        /// 连接八达通
        /// </summary>
        /// <param name="Cmd"></param>
        /// <param name="Lang"></param>
        /// <param name="Weight"></param>
        /// <param name="Machineid"></param>
        /// <param name="Lockerno"></param>
        /// <param name="Receiptno"></param>
        /// <param name="Phoneno"></param>
        /// <param name="Extratime"></param>
        /// <param name="Extratimecost"></param>
        /// <param name="Extraweight"></param>
        /// <param name="Extraweightcost"></param>
        /// <param name="Totalcost"></param>
        /// <param name="Reply"></param>
        /// <param name="OTime"></param>
        /// <param name="OCardNo"></param>
        /// <param name="OAmount"></param>
        /// <returns></returns>
        public void octopusCardCmd(string Cmd,string Lang,string Weight,string Machineid,string Lockerno,string Receiptno,
            string Phoneno,string Extratime,string Extratimecost,string Extraweight,string Extraweightcost,string Totalcost,string Reply,string OTime,string OCardNo,string OAmount) 
        {
            //从文件夹里读取Receiptno

            //将新的Receiptno加入到文件夹中
            try {
            String Receiptno1 = Read();
            String now = DateTime.Now.Year+"";
            now = now.Substring(2,2);
            if (Receiptno1 == null || Receiptno1=="")
            {

                Receiptno1 = Lockerno + now + "00001";
                Write(Receiptno1);
                Console.WriteLine(Receiptno1);
            }
            String numNO = Receiptno1.Substring(0, 2);
            string number = Receiptno1.Substring(4);
            if (Lang.Equals("1")) {
                Receiptno1 = numNO + now + number + Receiptno+"1";
            }
            else
            {
                Receiptno1 = numNO + now + number + Receiptno+"0";
            }
           
            if (Cmd == "2")
            {
                DateTime DiscountEndTime = Setting.Instance.DiscountEnd;

                if (DateTime.Compare(DateTime.Now, DiscountEndTime) > 0)
                {

                    uiData.ExtraWeight = float.Parse((int.Parse(Extraweightcost) / Setting.Instance.UnitExp) * 0.5 + "");
                }
                else
                {
                    uiData.ExtraWeight = float.Parse((int.Parse(Extraweightcost) / Setting.Instance.uUnitExp) * 0.5 + "");
                }
             
                service.octopusCardCmd(Cmd, Lang, Weight, Setting.Instance.Machineid, Lockerno, Receiptno1, uiData.QuJianSendPhone, Extratime, Extratimecost, uiData.ExtraWeight.ToString("F1"), Extraweightcost, Totalcost, Reply, OTime, OCardNo, OAmount);
            }
            else
            {
                service.octopusCardCmd(Cmd, Lang, Weight, Setting.Instance.Machineid, Lockerno, Receiptno1, Phoneno, Extratime, Extratimecost, Extraweight, Extraweightcost, Totalcost, Reply, OTime, OCardNo, OAmount);
            }
            uiData.CardPhoneno = Phoneno;
            uiData.JiJianRecPhone = Phoneno;
            uiData.eiBarcode = Receiptno1;
            
                 }
            catch (Exception ex)
            {
                LogHelper.Log("没有读到数据", ex);
            }
         
        }

        private static String Read()
        {
            String str ="";
            StreamReader sr = new StreamReader("D:\\Debug\\TestTxt.txt");
            //每次读一行，读完为止
            while (!sr.EndOfStream)
            {

                str = sr.ReadLine();
                if (str == null)
                {
                    str = "";
                }
            }
            sr.Close();
            return str;
        }
        private static void Write(String i)
        {
            if (!File.Exists("D:\\Debug\\TestTxt.txt"))
            {
                FileStream fs1 = new FileStream("D:\\Debug\\TestTxt.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(i); //开始写入值
                sw.Close();
                fs1.Close();
            }
            else
            {
                FileStream fs = new FileStream("D:\\Debug\\TestTxt.txt", FileMode.Open, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(i); //开始写入值
                sr.Close();
                fs.Close();

            }


        }

        public String returnCardReply()
        {
            return service.returnCardReply();

        }
       
        public string validateMoney()
        {
            var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
            float accountMoney = userInfo["userAccount"].Value<float>("uaCurrActMoney");
            var ciId = userInfo["userInfo"].Value<string>("ciId");
            var r = service.queryMoney(ciId);
            var obj = JsonHelper.ToObject(JsonHelper.ToJson(r));
            float currAccountMoney = obj.Value<float>("uaCurrActMoney");
            if ((accountMoney + uiData.MemberAccount) <= currAccountMoney && currAccountMoney > 0)
            {
                return JsonHelper.ToJson(new { success = true });
            }
            else
            {
                return JsonHelper.ToJson(new { success = false });
            }
            //var result = JToken.FromObject(false);
            //obj.TryGetValue("uaCurrActMoney", out result);
        }

        public void cardPayFee()
        { }

        public void smsPayFee()
        { }

        public void InitElcWeight()
        {
           //elcWeight.StartRead();
        }

        public void StopWeightRead()
        {
            elcWeight.Stop();
        }

        public void userSMSRecharge(float needPay, string phone)
        {
            var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
            var ciId = userInfo["userInfo"].Value<string>("ciId");
            if (!string.IsNullOrEmpty(ciId))
            {
                service.userSMSRecharge(ciId, needPay, phone);
            }
        }
    }
}
