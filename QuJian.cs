using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Device;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using EBoxClient.Utils;
using System.IO;

namespace EBoxClient
{
    partial class FrmMain
    {

        public string GetUserProtocol()
        {
            return localData.GetUserProtocol();
        }
        public string registrationVerify(string phone)
        {
            var r = service.phoneVerification(phone);
            if (r == null || string.IsNullOrEmpty(r.ToString()))
            {
                var code = service.registrationVerify(phone);
                if (code != null && !string.IsNullOrEmpty(code.ToString()))
                {
                    uiData.RegisterCode = code.ToString();
                    return JsonHelper.ToJson(new
                    {
                        success = true,
                        msg = "验证码已发送"
                    });
                }
                else
                {
                    return JsonHelper.ToJson(new
                        {
                            success = false,
                            msg = "验证码发送失败"
                        });
                }
            }
            else
            {
                return JsonHelper.ToJson(new
                {
                    success = false,
                    msg = "手机号码已注册"
                });
            }
        }
        public string userRegist(string phone, string code)
        {
            if (code != uiData.RegisterCode)
            {
                return JsonHelper.ToJson(new
                {
                    success = false,
                    method = uiData.Method
                });
            }
            var r = service.userRegist(uiData.RealName, uiData.IDCode, phone, phone, code);
            if (r != null && r.ToString() == "-1")
            {
                uiData.Phone = phone;
                uiData.UserName = phone;
                if (uiData.Method == 1)
                {
                    // uiData.UserInfo = service.userSendLogin(phone, phone, 2);
                }  
                else 
                {
                    // uiData.UserInfo = service.userMemLogin(phone, phone, 2);
                }
                    
                return JsonHelper.ToJson(new
                {
                    success = true,
                    method = uiData.Method
                });
            }
            return JsonHelper.ToJson(new
            {
                success = false,
                method = uiData.Method
            });
        }

        public string GetUiData()
        {
            return JsonHelper.ToJson(uiData);
        }
        public bool Login(string logincode, string password)
        {
            var loginType = GetLoginType(logincode);
            uiData.UserInfo = null;
            if (uiData.Method == 1)
            {
                uiData.UserInfo = service.userSendLogin(logincode, password, loginType);
            }
            else if (uiData.Method == 2)
            {
                uiData.UserInfo = service.userMemLogin(logincode, password, loginType);
            }
            else if (uiData.Method == 3 || uiData.Method == 4)
            {
                if (loginType == 1)
                {
                    uiData.UserInfo = service.usernameLogin(logincode, password, uiData.UserType);
                }
                else if (loginType == 2)
                {
                    uiData.UserInfo = service.mobileLogin(logincode, password, uiData.UserType);
                }
                else if (loginType == 3)
                {
                    uiData.UserInfo = service.idCodeLogin(logincode, password, uiData.UserType);
                }
            }
            return !(uiData.UserInfo == null || uiData.UserInfo.ToString() == "{}" || uiData.UserInfo.ToString() == "-6");
        }

        int GetLoginType(string loginCode)
        {
            if (Regex.IsMatch(loginCode.Trim(), "[A-Za-z]"))
                return 1;
            if (Regex.IsMatch(loginCode.Trim(), "\\d{11}"))
                return 2;
            return 3;
        }

        public string LoadExpressInfo()
        {
            throw new NotImplementedException();
        }
        
        public string LoadProList()
        {
            throw new NotImplementedException();
        }
        public string loadCityList()
        {
            throw new NotImplementedException();
        }
        public string loadCoList()
        {
            throw new NotImplementedException();
        }
        public void OpenBox()
        {
            if (uiData.QuJianOrder == null || string.IsNullOrEmpty(uiData.QuJianOrder.EILATTICENO))
                return;
            var ark = localData.GetMouthArkByBoxNo(uiData.QuJianOrder.EILATTICENO);

            if (ark != null)
            {
                int boardNo = -1;
                int.TryParse(ark.MOCSANO, out boardNo);
                boxDoor.Open(boardNo, ark.MOLOCKNO);
            }
        }

        /// <summary>
        /// 客户完成取件后调用的方法
        /// 正常件或逾期件
        /// </summary>
        public void closeExpress()
        {
         
            try
            {
                //string orderNo = uiData.QuJianOrder.EIORDERNO;
                string orderNo = eiOrderNo;
                var exp = localData.QueryExpress(orderNo);
                if (exp.EIPAYMENTMODE == 1012 || exp.TFBUZSTATUS == 7)
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
                

                if (null != exp && exp.TFBUZSTATUS == 7)
                {
                                     
                    localData.freeMouthArkState(uiData.QuJianOrder.EILATTICENO, uiData.QuJianOrder.EIEBOXNO);
                    object rst = service.userTakeOverTimeExpress(orderNo.ToString(), "7", uiData.ExceptionExpressFee);
                    if (null != rst && rst.ToString() == "-1")
                    {
                        if (uiData.QuJianOrder == null)
                        {
                            uiData.QuJianOrder = localData.GetExpressInfo2(pickupPhoneNumber, pickupIntcode);
                        }
                        localData.CloseExpressState(orderNo);
                    }
                }
                else
                {
                    localData.freeMouthArkState(uiData.QuJianOrder.EILATTICENO, uiData.QuJianOrder.EIEBOXNO);
                    localData.CloseExpressState(orderNo);  
                    object rst = service.userToTakeSuccessful(orderNo, uiData.QuJianOrder.EIBARCODE, "3",
                        uiData.QuJianOrder.EIPAYMENTMODE.ToString(),
                        uiData.QuJianOrder.EIEBOXID.ToString(), uiData.QuJianOrder.EIEBOXNO.ToString(), uiData.QuJianOrder.EILATTICENO);
                    if (rst.ToString() != "-1")
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log("TEST:"+ex.StackTrace);
            }
            //ReInit();
        }
      
        public void failFreeMouthArk()
        {
            localData.freeMouthArkState(uiData.QuJianOrder.EILATTICENO, uiData.QuJianOrder.EIEBOXNO);
        }

        public string validateQRCode(string code)
        {
           // code = "BArFpF+Nyqlwcg44hwzXtx0sb63tKl4MJ0QOCEUnHGLJvhYqx+qVZLipxIA+zRboolbxPSebwXPjGjVSO00+yW1nNOBno5G66HslfS2LDostb/bkJFWl+6ZOUtsnuZe7+XrEtw5Wye6UATjVq3byH8svZV+Um8wIC2p9feHTOv0ipDiY4F94JHAfaT4PFkl4Ema1QLSSzcahIkQRr65m0xizbGXG4iwQ7FX24ObUqNm+D8omqXnuv4FaGzfM6S0x";
            return JsonHelper.ToJson(service.parsingErWei(code));
        }
        public void CustSetExpressReason(int reasonId)
        {
            var r = service.abnormalThing(uiData.QuJianOrder.EIORDERNO, reasonId.ToString(), uiData.QuJianOrder.EILCID.ToString(),
                uiData.QuJianOrder.EIBARCODE, uiData.QuJianOrder.EIID.ToString(), "",uiData.QuJianOrder.EIEBOXNO);
            if (Service.IsValidResult(r))
            {
                localData.setCustExceptionExpress(uiData.QuJianOrder.EIORDERNO, reasonId.ToString());
                var info = localData.SaveExceptionException(r as JObject);
            }
        }
    }
}
