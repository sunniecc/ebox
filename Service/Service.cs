using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Utils;
using System.Threading;

namespace EBoxClient
{
    public class Service : IDisposable
    {
        public static readonly Service Instance = new Service();
        private Service()
        {
        }
        //连接web服务器
        TcpClientHelper tcpHelper = TcpClientHelper.Instance;
        //连接电子称
        TcpWeightHelper tcpWeightHelper = TcpWeightHelper.Instance;
        //连接八达通
        TcpOctopusCardHelper tcpOctopusCardHelper = TcpOctopusCardHelper.Instance;
        public event Action<string, string> OnServiceError;

        public object GetReturnValue(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str) || "{}" == str) return null;
                var obj = JsonHelper.ToObject<SvResult>(str);
                if (obj != null && OnServiceError != null && obj.returnValue != null)
                {
                    var errorCode = obj.returnValue.ToString();
                    if (errorCode == "-6")
                        OnServiceError(errorCode, "系统业务异常");
                    else if (errorCode == "404")
                        OnServiceError(errorCode, "请求参数异常");
                    else if (errorCode == "405")
                        OnServiceError(errorCode, "请求方法异常");
                }

                return obj.returnValue;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        public void Init(int pbId, string pbCrtNo)
        {
            //去连接web
            tcpHelper.Connect();
            //去连接电子称
            tcpWeightHelper.Connect();
            //去连接八达通
            tcpOctopusCardHelper.Connect();

            if (tcpHelper.IsConnected)
            {
                programLogin("SYS", pbId, pbCrtNo);
            }
            var th = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    try
                    {
                        //服务器的连接
                        if (tcpHelper.IsConnected)
                            continue;
                        tcpHelper.Connect();
                        if (!tcpHelper.IsConnected)
                            LogHelper.Log("连接服务器失败,5秒后重试...");
                        //称重的连接
                        if(tcpWeightHelper.IsConnected)
                            continue;
                        tcpWeightHelper.Connect();
                        if (!tcpWeightHelper.IsConnected)
                            LogHelper.Log("连接称重失败,5秒后重试...");
                        //八达通连接
                        if(tcpOctopusCardHelper.IsConnected)
                            continue;
                        tcpOctopusCardHelper.Connect();
                        if (!tcpOctopusCardHelper.IsConnected)
                            LogHelper.Log("连接八达通失败,5秒后重试...");
                    }
                    catch (Exception)
                    {
                    }
                    Thread.Sleep(5000);
                }
            }));
            th.IsBackground = true;
            th.Start();
        }

        public static bool IsValidResult(object r)
        {
            return r != null && r.ToString() != "-6" && r.ToString() != "{}" && r.ToString() !="";
        }

        /// <summary>
        /// 修改派宝箱运营商信息
        /// </summary>
        public object modOperators(int pbId, string pbNo, int opId, string opName,
                object maintainName, string maintainPhone, string address)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "adminOperation";
                root["type"] = "upOperators";
                item_item1["pbId"] = pbId;
                item_item1["pbCrtNo"] = pbNo;
                item_item1["pbOpId"] = opId;
                item_item1["pbOpName"] = opName;
                item_item1["pbMaintainName"] = maintainName;
                item_item1["pbMaintainPhone"] = maintainPhone;
                item_item1["pbAddress"] = address;
                item["pinfo"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        public object programLogin(string username, int boxId, string boxNo)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "programOperation";
                root["type"] = "programLogin";
                item_item1["ssOpenName"] = username;
                item_item1["ssOpenUid"] = "";
                item_item1["pbId"] = boxId;
                item_item1["pbCrtNo"] = boxNo;
                item_item1["ssOpenTime"] = Utils.DateTimeUtils.DateTimeString();
                item["ss"] = item_item1;
                root["parameter"] = item;
                object obj = GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
                //programInit();
                return obj;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 快递员取逾期、异常件
        /// </summary>
        /// <param name="pbId"></param>
        /// <param name="pbCrtNo"></param>
        /// <param name="orderno"></param>
        /// <param name="takeUserId"></param>
        /// <param name="tfBuzStatus"></param>
        /// <param name="eiLcId"></param>
        /// <returns></returns>
        public object expressTakeAbnormal(string pbId, string pbCrtNo, string orderno, string takeUserId,
            string tfBuzStatus, string eiLcId, string eiTakeIdType, string eiTakeIdCode, string eiLatticeNo)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "expressTakeAbnormal";
                item_item1["pbId"] = pbId;
                item_item1["pbCrtNo"] = pbCrtNo;
                item_item1["eiOrderNo"] = orderno;
                item_item1["eiTakeUserId"] = takeUserId;
                item_item1["eiLatticeNo"] = eiLatticeNo;
                item_item1["eiTakeIdType"] = eiTakeIdType;
                item_item1["eiTakeTime"] = Utils.DateTimeUtils.DateTimeString();
                item_item1["eiLcId"] = eiLcId;
                item_item1["eiTakeIdCode"] = eiTakeIdCode;
                item_item1["tfBuzStatus"] = tfBuzStatus;
                item["ei"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        
        /// <summary>
        /// 快递员管理员提取派宝箱快件
        /// </summary>
        /// <param name="pbId"></param>
        /// <param name="pbCrtNo"></param>
        /// <param name="orderno"></param>
        /// <param name="takeUserId"></param>
        /// <param name="tfBuzStatus"></param>
        /// <param name="eiLcId"></param>
        /// <param name="eiTakeIdType"></param>
        /// <param name="eiTakeIdCode"></param>
        /// <returns></returns>
        public object courierTakeSend(string pbId, string pbCrtNo, string orderno, string takeUserId,
            string tfBuzStatus, string eiLcId, string eiTakeIdType, string eiTakeIdCode, string eiLatticeNo)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "courierTakeSend";
                item_item1["pbId"] = pbId;
                item_item1["pbCrtNo"] = pbCrtNo;
                item_item1["eiOrderNo"] = orderno;
                item_item1["eiLatticeNo"] = eiLatticeNo;
                item_item1["eiTakeUserId"] = takeUserId;
                item_item1["eiTakeIdType"] = eiTakeIdType;
                item_item1["eiTakeTime"] = Utils.DateTimeUtils.DateTimeString();
                item_item1["eiLcId"] = eiLcId;
                item_item1["eiTakeIdCode"] = eiTakeIdCode;
                item_item1["tfBuzStatus"] = tfBuzStatus;
                item["ei"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 设置派宝箱格口参数
        /// </summary>
        /// <param name="pbId"></param>
        /// <param name="pbNo"></param>
        /// <param name="moId"></param>
        /// <param name="moNo"></param>
        /// <param name="moTypeId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public object mouthConfig(string pbId, string pbNo, string moId, string moNo, int moTypeId, int status)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "adminOperation";
                root["type"] = "disableMouth";
                item_item1["id"] = moId;
                item_item1["moNo"] = moNo;
                item_item1["moTypeId"] = moTypeId;
                item_item1["tfBuzStatus"] = status;
                item_item1["pbId"] = pbId;
                item_item1["pbNo"] = pbNo;
                item["maId"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }

        }

        /// <summary>
        /// 格口管理
        /// </summary>
        /// <param name="pbId"></param>
        /// <param name="pbNo"></param>
        /// <param name="moTypeIds"></param>
        /// <param name="moPrices"></param>
        /// <returns></returns>
        public object mouthManager(int pbId, string pbNo, string moTypeIds, string moPrices)
        {
            try
            {

                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                List<Dictionary<string, object>> array_items = new List<Dictionary<string, object>>();
                root["action"] = "adminOperation";
                root["type"] = "upMouthArkStandFee";

                var ids = moTypeIds.Split(',');
                var prices = moPrices.Split(',');
                if (ids.Length != prices.Length)
                {
                    return null;
                }
                for (int i = 0; i < ids.Length; i++)
                {
                    Dictionary<string, object> value = new Dictionary<string, object>();
                    value["moPbId"] = pbId;
                    value["pbCrtNo"] = pbNo;
                    value["moTypeId"] = ids[i];
                    value["moStandFee"] = prices[i];
                    array_items.Add(value);
                }
                item["ma"] = array_items;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));

            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 修改派宝箱运营商信息
        /// </summary>
        public object modOperators(int pbId, string pbNo, int opId, string opName,
                string maintainName, string maintainPhone, string address)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "adminOperation";
                root["type"] = "upOperators";
                item_item1["pbId"] = pbId;
                item_item1["pbCrtNo"] = pbNo;
                item_item1["pbOpId"] = opId;
                item_item1["pbOpName"] = opName;
                item_item1["pbMaintainName"] = maintainName;
                item_item1["pbMaintainPhone"] = maintainPhone;
                item_item1["pbAddress"] = address;
                item["pinfo"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        public object programInit()
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "programOperation";
                root["type"] = "programInit";
                item_item1["pbId"] = Setting.Instance.BoxID;
                item_item1["pbCrtNo"] = Setting.Instance.BoxNo;
                item["ss"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));

            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        ///  终端与服务器心跳
        /// </summary>
        public object heartbeat(long cnt)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "programOperation";
                root["type"] = "heartbeat";
                item["heartbeat"] = cnt;
                item_item1["pbId"] = Setting.Instance.BoxID;
                item_item1["pbCrtNo"] = Setting.Instance.BoxNo;
                item["ss"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        ///  终端退出
        /// </summary>
        public object programExit(string username)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "programOperation";
                root["type"] = "programExit";
                item_item1["ssOpenName"] = username;
                item_item1["pbId"] = Setting.Instance.BoxID;
                item_item1["ssId"] = "1";
                item_item1["pbCrtNo"] = Setting.Instance.BoxNo;
                item_item1["ssCloseTime"] = Utils.DateTimeUtils.DateTimeString();
                item_item1["ssCloseInstructions"] = "";
                item["ss"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));

            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 验证客户登录名是否唯一
        /// </summary>
        public object userNameVerification(string username)
        {
            try
            {

                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "userNameeVerification";
                item_item1["ciLoginName"] = username;
                item["ci"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 校验取件客户是不是进行了会员中心设置【禁投、选择时间段投递等】
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public object queryTimeAndForbidden(string phone,string barcode)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "memberCenter";
                root["type"] = "queryTimeAndForbidden";
                item_item1["ciUserPhone"] = phone;
                item_item1["ciPboxNo"] = barcode;//运单编号
                item_item1["ciLasttime"] = "GMT-8";
                item["ci"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 会员中心配置
        /// </summary>
        /// <param name="sysKey"></param>
        /// <param name="sysCode"></param>
        /// <param name="userId"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public object memberProxyConfig(string sysKey, string sysCode,
                string userId, string value1, string value2)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "memberCenter";
                //快件代收设定
                root["type"] = "upUProxyFlag";
                item_item1["ciId"] = userId;
                item_item1["ciProxyUserPhone"] = value1;
                if ("1" == sysCode)
                {
                    item_item1["ciUserProxyFlag"] = "1";
                }
                else
                {
                    item_item1["ciUserProxyFlag"] = "2";
                }

                item["ci"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        public object memberCenterConfig(string sysKey, string sysCode,
                string userId, string value1, string value2)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "memberCenter";
                if ("7007" == sysKey)
                {
                    //禁投设定
                    root["type"] = "forbiddenSetting";
                }
                else if ("7009" == sysKey)
                {
                    //通知方式
                    root["type"] = "informWay";
                }
                else if ("7010" == sysKey)
                {
                    //短信发送设定
                    root["type"] = "textMessagingWay";
                }
                else if ("7011" == sysKey)
                {
                    //投递时间设定
                    root["type"] = "upDeliveryTime";
                }
                item_item1["ucUserId"] = userId;
                item_item1["ucSysKey"] = sysKey;
                item_item1["ucSysValue"] = sysCode;
                item_item1["ucValueOne"] = value1;
                item_item1["ucValueTwo"] = value2;
                item["uc"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 客户、快递员、管理员身份证验证入口
        /// 验证成功返回登录名，否则返回“”
        /// 5-客户 4-快递员 3-管理员
        /// </summary>
        public object userIdValidate(string idcode, int usertype)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                if (5 == usertype)
                {
                    root["action"] = "userOperate";
                    root["type"] = "detectionIdCode";
                    item_item1["ciUserIdCode"] = idcode;
                    item["ci"] = item_item1;
                }
                else if (4 == usertype)
                {
                    root["action"] = "courier";
                    root["type"] = "detectionUserInfo";
                    item_item1["uiUserIdCode"] = idcode;
                    item["ui"] = item_item1;
                }
                else if (3 == usertype)
                {
                    root["action"] = "adminOperation";
                    root["type"] = "detectionAdminOperation";
                    item_item1["uiUserIdCode"] = idcode;
                    item["ui"] = item_item1;
                }
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));

            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        ///  用户名+密码登录验证
        ///  usertype 4-快递员 3-管理员
        /// </summary>
        public object usernameLogin(string username, string password, int usertype)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                if (4 == usertype)
                {
                    root["action"] = "courier";
                    root["type"] = "courierLogin";
                    item_item1["uiLoginName"] = username;
                    item_item1["uiLoginPassword"] = password;
                    item_item1["uiUserType"] = "4";
                    item["ui"] = item_item1;
                }
                else if (3 == usertype)
                {
                    root["action"] = "adminOperation";
                    root["type"] = "adminLogin";
                    item_item1["uiLoginName"] = username;
                    item_item1["uiLoginPassword"] = password;
                    item_item1["uiUserType"] = "3";
                    item["ui"] = item_item1;
                }
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));

            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        ///  用户名+密码登录验证
        ///  usertype 4-快递员 3-管理员
        /// </summary>
        public object mobileLogin(string phone, string password, int usertype)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                if (4 == usertype)
                {
                    root["action"] = "courier";
                    root["type"] = "courierLogin";
                    item_item1["uiUserPhone"] = phone;
                    item_item1["uiLoginPassword"] = password;
                    item_item1["uiUserType"] = "4";
                    item["ui"] = item_item1;
                }
                else if (3 == usertype)
                {
                    root["action"] = "adminOperation";
                    root["type"] = "adminLogin";
                    item_item1["uiUserPhone"] = phone;
                    item_item1["uiLoginPassword"] = password;
                    item_item1["uiUserType"] = "3";
                    item["ui"] = item_item1;
                }
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 快递员扣费
        /// </summary>
        public object courierDeduction(int userId, int eiOrderNo, int pbId, string pbCrtNo, float buzMoney)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "courier";
                root["type"] = "deduction";
                item_item1["pbId"] = pbId;
                item_item1["pbCrtNo"] = pbCrtNo;
                item_item1["uiUserId"] = userId;
                item_item1["eiOrderNo"] = eiOrderNo;
                item["ui"] = item_item1;
                item["buzMoney"] = buzMoney;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        ///  用户名+密码登录验证
        ///  usertype 4-快递员 3-管理员
        /// </summary>
        public object idCodeLogin(string idcode, string password, int usertype)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                if (4 == usertype)
                {
                    root["action"] = "courier";
                    root["type"] = "courierLogin";
                    item_item1["uiUserIdCode"] = idcode;
                    item_item1["uiLoginPassword"] = password;
                    item_item1["uiUserType"] = "4";
                    item["ui"] = item_item1;
                }
                else if (3 == usertype)
                {
                    root["action"] = "adminOperation";
                    root["type"] = "adminLogin";
                    item_item1["uiUserIdCode"] = idcode;
                    item_item1["uiLoginPassword"] = password;
                    item_item1["uiUserType"] = "3";
                    item["ui"] = item_item1;
                }
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        ///  发送注册验证码
        /// </summary>
        public object registrationVerify(string phone)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "registrationVerify";
                item_item1["ciUserPhone"] = phone;
                item["ci"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        ///  客户注册
        /// </summary>
        public object userRegist(string username, string idCode, string phone, string password, string code)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "registration";
                item_item1["ciUserName"] = username;
                item_item1["ciUserIdCode"] = idCode;
                item_item1["ciLoginName"] = phone;
                item_item1["ciUserPhone"] = phone;
                item_item1["ciLoginPassword"] = password;
                item_item1["validation"] = code;
                item["ci"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        ///  通过客户ID查询收件人地址列表
        /// </summary>
        public object customerRecipientsAddress(string userId)
        {
            try
            {

                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "recipients";
                item_item1["ciId"] = userId;
                item["ci"] = item_item1;
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        public object customerSetProxyAddress(string userId, string pUserName, string pUserPhone)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "memberCenter";
                root["type"] = "queryTimeAndForbidden";
                item_item1["ciId"] = userId;
                item_item1["ciProxyUserName"] = pUserName;
                item_item1["ciProxyUserPhone"] = pUserPhone;
                item["ci"] = item_item1;
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 通过客户ID查询代理收件人地址列表
        /// </summary>
        public object customerQueryProxyAddress(string userId)
        {
            try
            {

                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "receiver";
                item_item1["ciId"] = userId;
                item["ci"] = item_item1;
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 校验格口是否被使用
        /// </summary>
        /// <param name="moNo"></param>
        /// <returns></returns>
        public int validateMouthNo(string moNo)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "mouthArk";
                root["type"] = "mouthArkUsed";
                item_item1["moPbId"] = Setting.Instance.BoxID;
                item_item1["moNo"] = moNo;
                item["mou"] = item_item1;
                root["parameter"] = item;
                var rst = GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
                if (null != rst && rst.ToString() == "-1")
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return -1;
            }
            return 0;
        }

        /// <summary>
        ///  会员中心设置配置信息
        ///  userId 客户ID
        ///  key 常量key
        ///  code 常量code，可能存在多个，用逗号分隔
        ///  value1 默认值1，不同的code，存在不同的值
        ///         当只有一个值时，则将值存入此变量
        ///         当有两个值时，则将第一个值存入此变量
        ///  value2 默认值2，类似Value1，当配置变量有两个值时
        ///         将第二个值放入此变量
        /// </summary>
        public object setCustomerMember(string userId, int key, string code, string value1, string value2)
        {
            try
            {

                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "memberCenter";
                root["type"] = "setMemberInfo";
                item_item1["ciId"] = userId;
                item_item1["sysKey"] = key;
                item_item1["syscode"] = code;
                item_item1["value1"] = value1;
                item_item1["value2"] = value2;
                item["mc"] = item_item1;
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 客户短信充值
        /// </summary>
        public object userSMSRecharge(string ciId, double money, string rechargePhone)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "SMSRecharge";
                item_item1["ciId"] = ciId;
                item["buzMoney"] = Math.Round(money, 3);
                item["rechargePhone"] = rechargePhone;
                item["ci"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 深圳通充值
        /// </summary>
        public object cardRecharge(string userId, double money)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "cardRecharge";
                item_item1["ciId"] = userId;
                item["buzMoney"] = money;
                item["ci"] = item_item1;
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 客户扣费方法
        /// </summary>
        public object userDeduction(string userId, double money)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "deduction";
                item_item1["ciId"] = userId;
                item["buzMoney"] = money;
                item["ci"] = item_item1;
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        ///  系统退出功能
        /// 5-客户退出 4-快递员退出 3-管理员退出
        /// </summary>
        public object userLoginOut(string userId, int type)
        {
            try
            {

                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                item_item1["data"] = Utils.DateTimeUtils.DateTimeString();
                if (5 == type)
                {
                    root["action"] = "userOperate";
                    root["type"] = "userExit";
                    //item_item1["ciId"] = userId;
                    item["data"] = Utils.DateTimeUtils.DateTimeString();
                }
                else if (4 == type)
                {
                    root["action"] = "courier";
                    root["type"] = "courierExit";
                    //item_item1["uiId"] = userId;
                    item["data"] = Utils.DateTimeUtils.DateTimeString();
                }
                else if (3 == type)
                {
                    root["action"] = "adminOperation";
                    root["type"] = "adminExit";
                   // item_item1["uiId"] = userId;
                    item["data"] = Utils.DateTimeUtils.DateTimeString();
                }
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 进入会员中心登录
        /// 1-用户名登录 2-手机号登录 3-证件号登录
        /// </summary>
        public object userMemLogin(string logincode, string password, int flag)
        {
            try
            {

                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "userLogin";
                item_item1["ciUserType"] = "5";
                item_item1["ciLoginPassword"] = password;
                if (1 == flag)
                {
                    item_item1["ciLoginName"] = logincode;
                }
                else if (2 == flag)
                {
                    item_item1["ciUserPhone"] = logincode;
                }
                else
                {
                    item_item1["ciUserIdCode"] = logincode;
                }
                item["ci"] = item_item1;
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 客户寄件登录
        /// 1-用户名登录 2-手机号登录 3-证件号登录
        /// </summary>
        public object userSendLogin(string logincode, string password, int flag)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "userSendLogin";
                item_item1["ciUserType"] = "5";
                item_item1["ciLoginPassword"] = password;
                if (1 == flag)
                {
                    item_item1["ciLoginName"] = logincode;
                }
                else if (2 == flag)
                {
                    item_item1["ciUserPhone"] = logincode;
                }
                else
                {
                    item_item1["ciUserIdCode"] = logincode;
                }
                item["ci"] = item_item1;
                root["parameter"] = item;


                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        public object abnormalThing(string orderNo, string eoRemark, string eoLcId,
            string eoBarcode, string eoEiId, string eiEboxId, string eiEboxNo)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "abnormalThing";
                item_item1["eoOrderNo"] = orderNo;
                item_item1["eoRemark"] = eoRemark;
                item_item1["tfCreateDate"] = Utils.DateTimeUtils.DateTimeString();
                item_item1["eoLcId"] = eoLcId;
                item_item1["eoBarcode"] = eoBarcode;
                item_item1["eoEiId"] = eoEiId;
                item_item1["eiEboxNo"] = eiEboxNo;
                item_item1["eiEboxId"] = eiEboxId;
                item["ee"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 取件成功后返回结果
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="barCode"></param>
        /// <param name="buzStatus"></param>
        /// <param name="paymentMode"></param>
        /// <param name="eboxId"></param>
        /// <param name="eboxNo"></param>
        /// <returns></returns>
        public object userToTakeSuccessful(string orderNo, string barCode, string buzStatus, string paymentMode, string eboxId, string eboxNo, string eiLatticeNo)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "userToTakeSuccessful";
                item_item1["eiOrderNo"] = orderNo;
                item_item1["eiTakeIdCode"] = "";
                item_item1["eiTakeIdType"] = "";
                item_item1["tfBuzStatus"] = buzStatus;
                item_item1["eiLatticeNo"] = eiLatticeNo;
                item_item1["eiBarcode"] = barCode;
                item_item1["eiPaymentMode"] = paymentMode;
                item_item1["eiEboxId"] = eboxId;
                item_item1["eiEboxNo"] = eboxNo;
                item_item1["eiTakeTime"] = Utils.DateTimeUtils.DateTimeString();
                item["ei"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        ///	用户取件验证
        ///   1、通过手机号与验证码
        ///	2、验证通过则返回
        /// </summary>
        public object userToTake(string phone, string code)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "userToTake";
                item_item1["eiTakeUserPhone"] = phone;
                item_item1["eiValidateCode"] = code;
                item_item1["pbCrtNo"] = Setting.Instance.BoxNo;
                item_item1["pbId"] = Setting.Instance.BoxID;
                item["ei"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        //eiEboxId		派宝箱id
        //eiOrderNo		派宝箱生产编号
        //eiPaymentMode	Integer	付费方式
        //eiPaymentMoney	Double	付费金额
        //eiStoreUserId	Integer	收件人id
        //eiStoreUserPhone	String	收件人手机号
        //eiStoreUserName	String	收件人姓名
        //eiLcId	Integer	物流公司ID
        //elStoreUserType	Integer	 存件人类型
        //eiLatticeNo	String	格口号
        //elLcMainId	Integer	快递公司总公司ID
        //eiLcName	String	物流公司名称
        //elExpSaveMode	Integer	快件保方式


        //eiOrderNo	String	快件订单系统编号
        //eiLcId	Integer	物流公司ID
        //eiLcName	String	物流公司名称
        //eiOpId	Integer	运营商ID
        //eiOpName	String	运营名称
        //eiExpWeight	Float	快件重量
        //eiExpUnit	Integer	快件重量单位
        //eiLatticePrice	Double	格口费用
        //eiExpName	String	快件名称
        //eiFactalPrice	Double	结算费用
        //eiStandPrice	Double	标准费用
        //eiTotalFee	Double	合计费用
        //eiOneCode	String	一维码
        //eiTwoCode	String	二维码
        //eiProName	String	邮寄省份
        //eiCityName	String	邮寄城市
        //eiCoName	String	邮寄区县
        //eiAddress	String	邮寄地址
        //eiRecepName	String	收件人姓名
        //eiRecepPhone	String	收件人手机
        /// <summary>
        ///  客户寄件
        /// </summary>
        /*
         *uiData.PBoxInfo.PBID,     eiEboxId            派宝箱id    
         *payModel,                 eiPaymentMode       付费方式           
         *uiData.JiJianMoney,       eiPaymentMoney      付费金额
         *uiId,                     eiStoreUserId       存件人ID
         *uiUserPhone,              eiStoreUserPhone    存件人电话
         *uiUserName,               eiStoreUserName     存件人姓名
         *comp.LCLCID ?? 0,         eiLcId              物流公司ID
         *1,                        elStoreUserType     存件人类型
         *uiData.JiJianMouthNo,     eiLatticeNo         格口号
         *comp.LCLCMAINID ?? 0,     elLcMainId          快递公司总公司ID
         *comp.LCLCNAME,            eiLcName            物流公司名称
         *elExpSaveMode,            elExpSaveMode       快件保方式
         *expressId,                eiOrderNo           快件订单系统编号
         *opId,                     eiOpId              运营商ID
         *opName,                   eiOpName            运营商名称
         *uiData.JiIianWeight,      eiExpWeight         快件重量
         *unit,                     eiExpUnit           快件重量单位
         *mouthMoney,               eiLatticePrice      格口费用
         *uiData.JiJianPkgName,     eiExpName           快件名称
         *uiData.JiJianMoney,       eiFactalPrice       结算费用
          uiData.JiJianMoney,       eiStandPrice        标准费用
         *uiData.JiJianMoney + mouthMoney,eiTotalFee    合计费用
         *expressId,                eiOneCode           一维码
         *string.Empty,             eiTwoCode           二维码
         *uiData.JiJianProName,     eiProName           邮寄省份
         *uiData.JiJianCityName,    eiCityName          邮寄城市
         *uiData.JiJianCountyName,  eiCoName            邮寄区县
         *uiData.JiJianAddress,     eiAddress           邮寄地址
         *iData.JiJianRecName,      eiRecepName         收件人姓名
         *uiData.JiJianRecPhone,    eiRecepPhone        收件人手机
         *mouthMoney,               eiMouthMoney
         *3);                       tfBuzStatus
         */
        public object eserSend(int eiEboxId, int eiPaymentMode, Double eiPaymentMoney, int eiStoreUserId, String eiStoreUserPhone, String eiStoreUserName, int eiLcId, int elStoreUserType, String eiLatticeNo, int elLcMainId, String eiLcName, int elExpSaveMode, String eiOrderNo, int? eiOpId, String eiOpName, float eiExpWeight, int eiExpUnit, Double eiLatticePrice, String eiExpName, Double eiFactalPrice, Double eiStandPrice, Double eiTotalFee, String eiOneCode, String eiTwoCode, String eiProName, String eiCityName, String eiCoName, String eiAddress, String eiRecepName, String eiRecepPhone, double eiMouthMoney, int tfBuzStatus, string eiBarcode)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item_item2 = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "eserSend";
                item_item1["eiEboxId"] = eiEboxId;  //	派宝箱id
                item_item1["eiOrderNo"] = eiOrderNo;  //	派宝箱生产编号
                item_item1["eiPaymentMode"] = eiPaymentMode;  //Integer	付费方式
                item_item1["eiPaymentMoney"] = eiPaymentMoney;  //Double	付费金额
                item_item1["eiStoreUserId"] = eiStoreUserId;  //Integer	user id
                item_item1["eiStoreUserPhone"] = eiStoreUserPhone;  //String	user 手机号
                item_item1["eiStoreUserName"] = eiStoreUserName;  //String	user 姓名
                item_item1["eiLcId"] = eiLcId;  //Integer	物流公司ID
                item_item1["elStoreUserType"] = elStoreUserType;  //Integer	 存件人类型
                item_item1["eiLatticeNo"] = eiLatticeNo;  //String	格口号
                item_item1["elLcMainId"] = elLcMainId;  //Integer	快递公司总公司ID
                item_item1["eiLcName"] = eiLcName;  //String	物流公司名称
                item_item1["elExpSaveMode"] = elExpSaveMode;  //Integer	快件保方式
                item_item1["eiMouthMoney"] = eiMouthMoney;  //Double	格口费用
                item_item1["tfBuzStatus"] = tfBuzStatus;  //int 状态
                item_item1["eiBarcode"] = eiBarcode;  //string 用来存八达通的发票抬头
                item_item1["eiTakeUserPhone"] = eiRecepPhone;  //取件人电话号码
        
                item["ei"] = item_item1;
                item_item2["eiOrderNo"] = eiOrderNo;  //String	快件订单系统编号
                item_item2["eiLcId"] = eiLcId;  //Integer	物流公司ID
                item_item2["eiLcName"] = eiLcName;  //String	物流公司名称
                item_item2["eiOpId"] = eiOpId;  //Integer	运营商IDF
                item_item2["eiOpName"] = eiOpName;  //String	运营名称
                item_item2["eiExpWeight"] = eiExpWeight;  //Float	快件重量
                item_item2["eiExpUnit"] = eiExpUnit;  //Integer	快件重量单位
                item_item2["eiLatticePrice"] = eiLatticePrice;  //Double	格口费用
                item_item2["eiExpName"] = eiExpName;  //String	快件名称
                item_item2["eiFactalPrice"] = eiFactalPrice;  //Double	结算费用
                item_item2["eiStandPrice"] = eiStandPrice;  //Double	标准费用
                item_item2["eiTotalFee"] = eiTotalFee;  //Double	合计费用
                item_item2["eiOneCode"] = eiOneCode;  //String	一维码
                item_item2["eiTwoCode"] = eiTwoCode;  //String	二维码
                item_item2["eiProName"] = eiProName;  //String	邮寄省份
                item_item2["eiCityName"] = eiCityName;  //String	邮寄城市
                item_item2["eiCoName"] = eiCoName;  //String	邮寄区县
                item_item2["eiAddress"] = eiAddress;  //String	邮寄地址
                item_item2["eiRecepName"] = eiRecepName;  //String	收件人姓名
                item_item2["eiRecepPhone"] = eiRecepPhone;  //String	收件人手机
                item_item2["eiExpBarcode"] = eiBarcode;  //string 用来存八达通的发票抬头
                item["es"] = item_item2;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
       
        /// <summary>
        /// 管理员
        /// 取寄件、逾期件、异常件
        /// 根据快件ID查询本地快件其他信息，然后发送至服务端
        /// </summary>
        public object administratorToTake(string pbId, string pbCrtNo, string orderno, string takeUserId,
            string tfBuzStatus, string eiLcId, string eiTakeIdType, string eiTakeIdCode, string eiLatticeNo)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "administratorToTake";
                item_item1["pbId"] = pbId;
                item_item1["pbCrtNo"] = pbCrtNo;
                item_item1["eiOrderNo"] = orderno;
                item_item1["eiTakeUserId"] = takeUserId;
                item_item1["eiLatticeNo"] = eiLatticeNo;
                item_item1["eiTakeIdType"] = eiTakeIdType;
                item_item1["eiTakeTime"] = Utils.DateTimeUtils.DateTimeString();
                item_item1["eiTakeIdCode"] = eiTakeIdCode;
                item_item1["tfBuzStatus"] = tfBuzStatus;
                item["ei"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        ///  快递员存件时：
        ///  1、先验证快件是否已经存在
        ///  2、存在时自动带出用户手机和姓名
        /// </summary>
        public object orderCheckExpress(string phone, string code, string eboxNo)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "phoneAndBarcodeCheckExpress";
                item_item1["eiBarcode"] = code;
                item_item1["eiTakeUserPhone"] = phone;
                item_item1["eiEboxNo"] = eboxNo;
                item["ei"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        ///  快递员存件时：
        ///  1、先验证快件是否已经存在
        ///  2、存在时自动带出用户手机和姓名
        /// </summary>
        public object orderCheckExpressByBarCode(string barCode, int lcId)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "orderCheckExpress";
                item_item1["eiBarcode"] = barCode;
                item_item1["tfbuzStatus"] = 1;
                item_item1["elLcMainId"] = lcId;
                item["ei"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        public object phoneVerification(string phone)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "phoneVerification";
                item_item1["ciUserPhone"] = phone;
                item["ci"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }


        /// <summary>
        /// 根据物品重量计算快递费用
        /// </summary>
        /// <param name="lcId">物流公司</param>
        /// <param name="startCity">启动城市编号</param>
        /// <param name="endCity">目的城市编号</param>
        /// <param name="weight">物品重量</param>
        /// <returns></returns>
        public object calculateAExpense(int lcId, string startCity, string endCity, int weight)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressFeeRule";
                root["type"] = "calculateAExpense";
                item_item1["leLcId"] = lcId;
                item_item1["leStartCityNo"] = startCity;
                item_item1["leEndCityNo"] = endCity;
                item_item1["leUnit"] = weight;
                item["efr"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 生成条码
        /// </summary>
        public string expressId()
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "expressId";
                var obj = GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
                if (null == obj)
                {
                    LogHelper.Log("获取快件订单编号异常");
                    return "";
                }
                return obj.ToString();
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        //    pbCrtNo	String	派宝箱生产编号
        //eiBarcode	String	运单编号
        //eiEboxAbbr	String	派宝箱别名
        //eiEboxNo	String	派宝箱编号
        //eiLatticeNo	String	格口号
        //eiLcId	Integer	物流公司ID
        //eiLcName	String	物流公司名称
        //eiPaymentMode	Integer	付费方式
        //eiPaymentMoney	Double	付费额度
        //eiStoreUserId	Integer	收件人ID
        //eiStoreUserName	String	收件人姓名
        //eiStoreUserPhone	String	收件人电话
        //eiTakeUserId	Integer	取件人ID
        //eiTakeUserName	String	取件人姓名
        //eiTakeUserPhone	String	取件人手机
        public object expressSave(
             string eiBarcode, string eiEboxAbbr, string eiEboxNo, string eiLatticeNo,
         int eiLcId, string eiLcName, int eiPaymentMode, string eiPaymentMoney,
         int eiStoreUserId, string eiStoreUserName, string eiStoreUserPhone, int? eiTakeUserId,
            string eiTakeUserName, string eiTakeUserPhone, int? sysId, string expressId, int eiEboxId, string eiMouthMoney,string tfBackupField1)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "expressSave";
                item_item1["eiBarcode"] = eiBarcode ?? string.Empty;
                item_item1["eiEboxAbbr"] = eiEboxAbbr ?? string.Empty;
                item_item1["eiEboxNo"] = eiEboxNo ?? string.Empty;
                item_item1["eiLatticeNo"] = eiLatticeNo ?? string.Empty;
                item_item1["eiLcId"] = eiLcId;
                item_item1["eiLcName"] = eiLcName ?? string.Empty;
                item_item1["eiPaymentMode"] = eiPaymentMode;
                item_item1["eiPaymentMoney"] = eiPaymentMoney;
                item_item1["eiStoreUserId"] = eiStoreUserId;
                item_item1["eiStoreUserName"] = eiStoreUserName ?? string.Empty;
                item_item1["eiStoreUserPhone"] = eiStoreUserPhone ?? string.Empty;
                item_item1["eiMouthMoney"] = eiMouthMoney;
                if (eiTakeUserId.HasValue)
                    item_item1["eiTakeUserId"] = eiTakeUserId;
                item_item1["eiTakeUserName"] = eiTakeUserName ?? string.Empty;
                item_item1["eiTakeUserPhone"] = eiTakeUserPhone ?? string.Empty;
                //备用字段，用来判断是发中文短信，还是英文短信
                item_item1["tfBackupField1"] = tfBackupField1 ?? string.Empty;
                if (sysId.HasValue)
                    item_item1["eiId"] = sysId;
                item_item1["eiEboxId"] = eiEboxId;
                item_item1["eiOrderNo"] = expressId;
                item["ei"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 查询客户帐户余额
        /// </summary>
        /// <param name="ciId"></param>
        /// <returns></returns>
        public object queryMoney(string ciId)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "queryMoney";
                item_item1["ciId"] = ciId;
                item["ci"] = item_item1;
                root["parameter"] = item;

                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

      
        /// <summary>
        /// 客户取逾期件
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="buzStatus"></param>
        /// <param name="eiPaymentMoney"></param>
        /// <returns></returns>
        public object userTakeOverTimeExpress(string orderNo, string buzStatus, double eiPaymentMoney)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "userTakeOverTimeExpress";
                item_item1["eiPaymentMoney"] = eiPaymentMoney/24;
                item_item1["eiTakeTime"] = Utils.DateTimeUtils.DateTimeString();
                item_item1["eiOrderNo"] = orderNo;
                item_item1["tfBuzStatus"] = buzStatus;
                item["ei"] = item_item1;
                root["parameter"] = item;
                object obj = GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
                if (null == obj)
                {
                    LogHelper.Log("用户取逾期件保存失败");
                    return null;
                }
                return obj.ToString();
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        /// <summary>
        /// 逾期费用充值
        /// </summary>
        /// <param name="money"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public object coinsRecharge(double money, string phone)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "userOperate";
                root["type"] = "coinsRecharge";
                item_item1["rechargePhone"] = phone;
                item_item1["buzMoney"] = money;
                item["ci"] = item_item1;
                root["parameter"] = item;
                object obj = GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
                if (null == obj)
                {
                    LogHelper.Log("计算逾期费用充值失败");
                    return 0;
                }
                return Convert.ToDouble(obj.ToString());
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return 0;
            }
        }

        /// <summary>
        /// 通过快件订单编号计算逾期费用
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public double overdueAccount(string orderno)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "overdueAccount";
                item_item1["eiOrderNo"] = orderno;
                item["ei"] = item_item1;
                root["parameter"] = item;
                object obj = GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
                if (null == obj || obj.ToString() == "-6")
                {
                    LogHelper.Log("计算逾期费用错误");
                    return 0;
                }
                return Convert.ToDouble(obj.ToString());
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return 0;
            }
        }

        /// <summary>
        /// 使用二维码取件
        /// </summary>
        /// <param name="elExpRemark"></param>
        /// <returns></returns>
        public object parsingErWei(string elExpRemark)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "expressMail";
                root["type"] = "parsingErWei";
                item_item1["elExpRemark"] = elExpRemark;
                item["ei"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 获得电子称称重
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>

        public string expressWeight(string cmd,string weight,string reply)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
              //  root["action"] = "expressMail";
              //  root["type"] = "parsingErWei";
                //item_item1["cmd"] = cmd;
                //item["c"] = item_item1;Send
                root["Cmd"] = cmd;
                root["Weight"] = weight;
                root["Reply"] = reply;

                //向电子称写入数据
                 GetReturnValue(tcpWeightHelper.Send(JsonHelper.ToJson(root)));
                //向电子称读取数据
                 return tcpWeightHelper.svse();
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }
        /// <summary>
        /// 初始化重量
        /// </summary>
         public void  expressWeightInit( ){
             tcpWeightHelper.InitDate();

         }
        /// <summary>
        /// 初始化八达通
        /// </summary>
        public void expressCardInit()
         {
        tcpOctopusCardHelper.InitDate();
        }
   
        /// <summary>
        /// 八达通连接状态
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
        public void octopusCardCmd(string Cmd, string Lang, string Weight, string Machineid, string Lockerno, string Receiptno,
            string Phoneno, string Extratime, string Extratimecost, string Extraweight, string Extraweightcost, string Totalcost, string Reply, string OTime, string OCardNo, string OAmount)
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();

                root["Cmd"] = Cmd;
                root["Lang"] = Lang;
                root["Weight"] = Weight;
                root["MachineId"] = Machineid;
                root["LockerNo"] = Lockerno;
                root["ReceiptNo"] = Receiptno;
                root["PhoneNo"] = Phoneno;
                root["ExtraTime"] = Extratime;
                root["ExtraTimeCost"] = Extratimecost;
                root["ExtraWeight"] = Extraweight;
                root["ExtraWeightCost"] = Extraweightcost;
                root["TotalCost"] = Totalcost;
                //root["Reply"] = Reply;
                //root["OTime"] = OTime;
                //root["OCardNo"] = OCardNo;
                //root["OAmount"] = OAmount;


                //向八达通写入数据
                GetReturnValue(tcpOctopusCardHelper.Send(JsonHelper.ToJson(root)));
             
              
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                
            }
        }
        public String returnCardReply()
       {
            return tcpOctopusCardHelper.svse();
       }

        public object testDownLoad()
        {
            try
            {
                Dictionary<string, object> root = new Dictionary<string, object>();
                Dictionary<string, object> item_item1 = new Dictionary<string, object>();
                Dictionary<string, object> item = new Dictionary<string, object>();
                root["action"] = "fileTrans";
                root["type"] = "checkFile";
                item_item1["path"] = "D:/2.zip";
                item_item1["pboxId"] = Setting.Instance.BoxID;
                item["fileMsg"] = item_item1;
                root["parameter"] = item;
                return GetReturnValue(tcpHelper.Send(JsonHelper.ToJson(root)));
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return null;
            }
        }

        public void Dispose()
        {
            tcpHelper.Stop();
        }


       
    }
}
