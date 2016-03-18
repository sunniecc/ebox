using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using DbLinq.Sqlite;
using EBoxClient.Entity;
using System.Windows.Forms;
using System.IO;
using EBoxClient.Data;
using Newtonsoft.Json.Linq;
using EBoxClient.Utils;

namespace EBoxClient
{
    public class LocalData
    {
        public static LocalData Instance = new LocalData();
        private sqliteUtils sqliteU = new sqliteUtils();
        private LocalData()
        {

        }

        Data.Data db = new Data.Data(new SQLiteConnection(@"data source=" + Setting.Instance.DataBase));


        public List<ExpressInfo> getOvertimeExpresses()
        {
            string sqlStr = "where EL_OVERTIME < datetime('now','localtime') and EL_STOREUSERTYPE = 2 and  TF_BUZSTATUS in (3,7);";
            List<ExpressInfo> expressInfos = sqliteU.getExpressInfos(sqlStr);
            int count = 100;
            foreach (ExpressInfo e in expressInfos)
            {
                changeExpressToOverdue(e, count++);
            }
            return expressInfos;
        }


        public ExpressInfo changeExpressToOverdue(ExpressInfo exp, int count)
        {
            exp.TFBUZSTATUS = 7;
            saveOverdueExpress("update EBOX_EXPRESINFO set TF_BUZSTATUS =7 where EI_ORDERNO =" + exp.EIORDERNO);
            DateTime dt = Convert.ToDateTime(exp.ELOVERTIME);
            DateTime now = DateTime.Now;
            TimeSpan ts = now - dt;
            int overDay = Convert.ToInt32(Math.Ceiling(ts.TotalDays));
            int overdueUnitPrice = Setting.Instance.overdueUnitPrice;
            int totalPrice = overDay * overdueUnitPrice;
            var ee = getExceptionExpress(exp.EIORDERNO, exp.EIID);
            if (ee == null)
            {
                saveOverdueExpress("insert into EBOX_EXPRESSEXCEPTION (EO_ID,EO_EIID,EO_LCID,EO_BARCODE,EO_ORDERNO,EO_EXPTYPE,EO_VALIDATECODE,EO_OVERTIMEDAY,EO_OVERTIMEPRICE,EO_OVERTIMEFEE,TF_BUZSTATUS) values" + "( " + getId() + count + "," + exp.EIID + "," + exp.EILCID + ",\"" + exp.EIBARCODE + "\"," + exp.EIORDERNO + "," + 2 + "," + exp.EIVALIDATECODE + "," + overDay + "," + overdueUnitPrice + "," + totalPrice + "," + 2 + ")");
            }
            else
            {
                saveOverdueExpress("update EBOX_EXPRESSEXCEPTION set EO_OVERTIMEDAY = " + overDay + " , EO_OVERTIMECNT = " + overDay + " , EO_OVERTIMEPRICE = " + overdueUnitPrice + " , EO_OVERTIMEFEE = " + totalPrice + " where EO_ORDERNO = " + exp.EIORDERNO);
            }
            return exp;
        }

        private int getId()
        {
            DateTime dt1 = Convert.ToDateTime(DateTime.Now);
            DateTime dt2 = Convert.ToDateTime("2014-12-01 00:00:00.0");
            TimeSpan ts = dt1 - dt2;
            return Convert.ToInt32(Math.Ceiling(ts.TotalSeconds));
        }

        public string GetUserProtocol()
        {
            var protocol = db.EBOXUSERPROTOCOL.FirstOrDefault();
            return protocol == null ? string.Empty : protocol.UPCONTENT;
        }



        public ExpressInfo QueryExpress(string orderNo)
        {
            return sqliteU.getExpressInfo("where EI_ORDERNO = " + orderNo);
        }

        public List<ExpressInfo> QueryExpresses(string eiId)
        {
            return sqliteU.getExpressInfos("where EI_ID in (" + eiId + ")");
        }

        public List<ExpressInfo> QueryExpress(int[] eiIds)
        {
            int length = eiIds.Length;
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str += eiIds[i];
                if (i < (length - 1))
                {
                    str += ",";
                }
            }
            string sqlStr = "where EI_ORDERNO in (" + str + ")";
            return sqliteU.getExpressInfos(sqlStr);
        }



        public ExpressInfo GetExpressInfo2(string phone, long code)
        {
            return sqliteU.getExpressInfo("where EI_VALIDATECODE =" + code + " and TF_BUZSTATUS in (3,7)");

        }
        //查看快件是否是待付款状态
        public ExpressInfo GetExpressInfo3(string phone, long code)
        {
           return sqliteU.getExpressInfo("where EI_VALIDATECODE ="+code);

        }
        public ExpressException getExceptionExpress(string orderno, int eiId)
        {
            return sqliteU.getExpressException("where EO_EIID = " + eiId + " and EO_ORDERNO = " + orderno);
        }

        /// <summary>
        /// 读取省市县
        /// </summary>
        public List<Data.EBOXPROVINCECODE> GetProviceList()
        {
            return db.EBOXPROVINCECODE.ToList();

        }

        /// <summary>
        /// 根据格口编号查询锁编号
        /// </summary>
        public EboxMouthArk GetMouthArkByBoxNo(string MoNo)
        {
            return sqliteU.getEboxMouthArk("where TF_DELETEFLAG =0 and MO_NO = " + MoNo);

        }

        /// <summary>
        /// 根据格口编号查询锁编号
        /// </summary>
        public List<EboxMouthArk> GetMouthArksByBoxNo(string boxNos)
        {
            /**
            int length = boxNos.Count;
            LogHelper.Log("GetMouthArksByBoxNo:boxNos.Count = "+length);
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str += boxNos[i].EIEBOXNO;
                if (i < (length - 1))
                {
                    str += ",";
                }
            }
             */
            string sqlStr = "where TF_DELETEFLAG = 0 and MO_NO in (" + boxNos + ")";
            return sqliteU.getEboxMouthArks(sqlStr);
        }

        /// <summary>
        /// 根据格口类型查询空闲格口
        /// </summary>
        public EboxMouthArk GetBoxLockNoByTypeID(int typeId)
        {
            return sqliteU.getEboxMouthArk("where TF_DELETEFLAG =0 and TF_BUZSTATUS = 1 and MO_TYPEID =" + typeId);
        }
        /// <summary>
        /// 查看是否有空闲的格口
        /// </summary>
        /// <returns></returns>
        public EboxMouthArk GetFreeBox()
        {
            return sqliteU.getEboxMouthArk("where TF_DELETEFLAG =0 and TF_BUZSTATUS = 1");
        }

        /// <summary>
        /// 通过格口ID查询格口信息
        /// </summary>
        /// <param name="arkId"></param>
        /// <returns></returns>
        public EboxMouthArk GetBoxLockNoById(int arkId)
        {
            return sqliteU.getEboxMouthArk("where TF_DELETEFLAG =0 and  ID = " + arkId);
        }

        /// <summary>
        /// 订单关闭
        /// </summary>
        public void CloseExpressState(string orderNo)
        {
            var order = sqliteU.getExpressInfo("where EI_ORDERNO = " + orderNo);
            if (order != null)
            {
                sqliteU.updateData("update EBOX_EXPRESINFO set TF_BUZSTATUS =4 where EI_ORDERNO =" + orderNo);
            }
        }


        //带付款的件
        public void PayMoneyExpress(string orderNo,float paymoney)
        {
            var order = sqliteU.getExpressInfo("where EI_ORDERNO = " + orderNo);
            if (order != null)
            {
                sqliteU.updateData("update EBOX_EXPRESINFO set EI_PAYMENTMONEY=" + paymoney + " where EI_ORDERNO =" + orderNo);
            }
        }
        /// <summary>
        /// 设置异常件
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="resonId"></param>
        public void setCustExceptionExpress(string orderNo, string resonId)
        {
            var order = sqliteU.getExpressInfo("where EI_ORDERNO = " + orderNo);
            if (order != null)
            {
                sqliteU.updateData("updateData EBOX_EXPRESINFO set TF_BUZSTATUS = 5 ,EL_EXPREMARK =" + resonId + " where EI_ORDERNO =" + orderNo);
            }
        }

        public void saveOverdueExpress(String sql)
        {
            sqliteU.updateData(sql);
        }

        public void closeOvertimeExpress(string orderNo)
        {
            var order = sqliteU.getExpressInfo("where EI_ORDERNO = " + orderNo);
            if (order != null)
            {
                sqliteU.updateData("update EBOX_EXPRESINFO set TF_BUZSTATUS =8 where EI_ORDERNO =" + orderNo);
            }
        }

        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="provId"></param>
        /// <returns></returns>
        public List<Data.EBOXCITYCODE> GetCityList(string provId)
        {
            var id = 0;
            int.TryParse(provId, out id);
            return db.EBOXCITYCODE.Where(c => c.PROVINCEID == id).ToList();
        }

        /// <summary>
        /// 获取县区列表
        /// </summary>
        public List<Data.EBOXCOUNTYCODE> GetCountyList(string cityNo)
        {
            var id = 0;
            int.TryParse(cityNo, out id);
            return db.EBOXCOUNTYCODE.Where(c => c.CITYID == id).ToList();
        }

        /// <summary>
        /// 获取派宝箱的配置
        /// </summary>
        public Data.EBOXPBOX GetPBoxConfig()
        {
            var id = Convert.ToInt32(Setting.Instance.BoxID);
            return db.EBOXPBOX.ToList().FirstOrDefault(c => c.PBCRTNO == Setting.Instance.BoxNo
                && c.PBID == id && c.TFDELETEFLAG == 0);
        }

        /// <summary>
        /// 查询快递公司列表
        /// </summary>
        public List<Data.EBOXLOGISTICSCOMPANYCONFIG> GetLogisticsCompanyConfig()
        {
            return db.EBOXLOGISTICSCOMPANYCONFIG.Where(c => c.LCLCMAINNAME != null && c.LCLCMAINID > 0 && c.TFDELETEFLAG == 0).ToList();
        }

        public string loadMouthArkStoreStatus(string eboxNo)
        {
            var sql = @"select count(ark.ID) as Data from ebox_mouth_ark ark where ark.TF_BUZSTATUS =1 and ark.TF_DELETEFLAG=0
                        and ark.MO_PBNO={0}";
            var d = db.ExecuteQuery<SingleData>(sql, eboxNo).FirstOrDefault();
            if (null != d)
            {
                return d.Data.ToString();
            }
            return "0";
        }

        /// <summary>
        /// 客户寄件时选择格口
        /// </summary>
        /// <returns></returns>
        public object GetFreeMouthToCust()
        {
            var pbox = db.EBOXPBOX.FirstOrDefault();
            var r = (from ark in db.EBOXMOUTHARK
                     join m in db.EBOXMOUTH on ark.MOTYPEID equals m.MOID
                     where ark.TFBUZSTATUS == 1 && ark.TFDELETEFLAG == 0 && ark.MOPBID == pbox.PBID && ark.MOTYPEID == m.MOID
                     select new
                     {
                         mo_model = m.MOMODEL,
                         mo_typeId = ark.MOTYPEID
                     }).ToList();
            var g = (from m in r
                     group m by new { m.mo_typeId, m.mo_model } into a
                     select new
                     {
                         momodel = a.Key.mo_model,
                         moTypeId = a.Key.mo_typeId,
                         count = a.Count()
                     }).ToList();

            return g;
        }

        /// <summary>
        /// 获取空闲的格口列表
        /// </summary>
        /// <returns></returns>
        public object GetFreeMouth()
        {
            var pbox = db.EBOXPBOX.FirstOrDefault();
            var r = (from ark in db.EBOXMOUTHARK
                     join m in db.EBOXMOUTH on ark.MOTYPEID equals m.MOID
                     where ark.TFBUZSTATUS != 3 && ark.TFDELETEFLAG == 0 && ark.MOPBID == pbox.PBID && ark.MOTYPEID == m.MOID && m.TFDELETEFLAG == 0
                     select new
                     {
                         mo_model = m.MOMODEL,
                         mo_typeId = ark.MOTYPEID,
                         status = ark.TFBUZSTATUS
                     }).ToList();
            var g = (from m in r
                     group m by new { m.mo_typeId, m.mo_model, m.status } into a
                     select new
                     {
                         momodel = a.Key.mo_model,
                         moTypeId = a.Key.mo_typeId,
                         status = a.Key.status,
                         count = a.Count()
                     }).ToList();

            return g;
        }

        /// <summary>
        /// 快件信息查询
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<ExpressInfo> orderCheckExpress(string barCode, string phone)
        {
            var barCodeResult = new List<ExpressInfo>();
            var phoneResult = new List<ExpressInfo>();
            if (!string.IsNullOrEmpty(barCode))
            {
                barCodeResult = sqliteU.getExpressInfos("where TF_DELETEFLAG =0 and EI_BARCODE =" + barCode);

            }
            if (!string.IsNullOrEmpty(phone))
            {
                phoneResult = sqliteU.getExpressInfos("where TF_DELETEFLAG = 0 and EI_TAKEUSERPHONE = " + phone);
            }
            if (!string.IsNullOrEmpty(barCode) && !string.IsNullOrEmpty(phone))
                return barCodeResult.Intersect(phoneResult).Distinct(new ExpressInfoCompare()).ToList();
            else
                return barCodeResult.Union(phoneResult).Distinct(new ExpressInfoCompare()).ToList();
        }

        class ExpressInfoCompare : IEqualityComparer<ExpressInfo>
        {
            public bool Equals(ExpressInfo x, ExpressInfo y)
            {
                if (x == null && y == null)
                    return true;
                else if (x != null && y != null)
                    return x.EIORDERNO == y.EIORDERNO;
                else
                    return false;
            }

            public int GetHashCode(ExpressInfo obj)
            {
                return (obj == null || obj.EIORDERNO == null) ? GetHashCode() : obj.EIORDERNO.GetHashCode();
            }
        }

        public List<Data.EBOXSYSCODE> GetBuzStatusCode()
        {
            return db.EBOXSYSCODE.Where(c => c.CTNO == 5016).ToList();
        }

        public IEnumerable<T> Query<T>(string sql, params object[] paramArr)
         where T : class,new()
        {
            return db.ExecuteQuery<T>(sql, paramArr);
        }


        /// <summary>
        /// 保存快件信息到本地
        /// </summary>
        public ExpressInfo submitStoreExpress(JObject info)
        {
            if (info == null) return null;
            var ps = string.Empty;
            var colstr = string.Empty;
            var param = new List<object>();
            try
            {
                var i = 0;
                foreach (var item in info)
                {
                    ps += "{" + (i++) + "},";
                    colstr += "`" + (item.Key.Length > 2 ? (item.Key.Substring(0, 2) + "_" + item.Key.Substring(2)) : item.Key) + "`,";
                    param.Add(item.Value);
                }
                ps = ps.Trim(',');
                colstr = colstr.Trim(',');
                var sql = @"REPLACE INTO `ebox_expresinfo` (" + colstr + @") VALUES (" + ps + ");";
                db.ExecuteCommand(sql, param.ToArray());
                db.SubmitChanges();
                var newId = Convert.ToInt32(info.GetValue("eiId"));
                return sqliteU.getExpressInfo("where EI_ID = " + newId);
            }
            catch (Exception ex)
            {
                LogHelper.Log("保存终端快件信息异常", ex);
                return null;
            }
        }

        /// <summary>
        /// 统计从柜数量
        /// </summary>
        /// <returns></returns>
        public int queryStoreArkNum()
        {
            try
            {
                var sql = @"select COUNT(SCA_ID) as Data from EBOX_STORECONTENTARK where SCA_BOXID={0} AND TF_DELETEFLAG=0";
                var d = db.ExecuteQuery<SingleData>(sql, Setting.Instance.BoxID).FirstOrDefault();
                if (null != d)
                {
                    return Convert.ToInt32(d.Data);
                }
            }
            catch (Exception e)
            {
                LogHelper.Log("统计从柜数量异常", e);
            }
            return 0;
        }

        /// <summary>
        /// 统计某从柜中格口数量
        /// </summary>
        /// <param name="csano"></param>
        /// <returns></returns>
        public int queryMouthArkNum(string csano)
        {
            try
            {
                var sql = @"select COUNT(ID) as Data from EBOX_MOUTH_ARK where MO_PBNO={0} AND MO_CSANO={1} AND TF_DELETEFLAG=0";
                var d = db.ExecuteQuery<SingleData>(sql, Setting.Instance.BoxNo, csano).FirstOrDefault();
                if (null != d)
                {
                    return Convert.ToInt32(d.Data);
                }
            }
            catch (Exception e)
            {
                LogHelper.Log("统计某从柜格口数量异常", e);
            }
            return 0;
        }
        class SingleData
        {
            public int Data { get; set; }
        }

        /// <summary>
        /// 锁格口
        /// </summary>
        /// <param name="moNo"></param>
        /// <param name="pbId"></param>
        /// <returns></returns>
        public bool lockMouthArkState(string moNo, int pbId)
        {
            try
            {
                var ark = sqliteU.getEboxMouthArk("where TF_DELETEFLAG = 0 and MO_NO = " + moNo + " and MO_PBID = " + pbId);
                if (null != ark)
                {
                    sqliteU.updateData("update EBOX_MOUTH_ARK set TF_BUZSTATUS = 2 " + ",TF_UPDATEDATE =  datetime('now','localtime') where TF_DELETEFLAG = 0 and MO_NO = " + moNo + " and MO_PBID = " + pbId);
                    LogHelper.Log("格口锁成功！");
                    EboxMouthArk eboxMouthArk = sqliteU.getEboxMouthArk("where MO_NO = " + moNo);
                    LogHelper.Log("格口状态：MoNo = " + eboxMouthArk.MONO + ",TfBuz = " + eboxMouthArk.TFBUZSTATUS + ",Id = " + eboxMouthArk.ID);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Log("更新格口状态失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 更新快件状态
        /// 1-完成正常件
        /// 2-完成异常件
        /// 3-完成逾期件
        /// </summary>
        /// <param name="expId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool finishExpressBuz(int expId, int type)
        {
            try
            {
                //var expinfo = db.EBOXEXPRESINFO.FirstOrDefault(c => c.EIID == expId);
                string sqlStr = "update  EBOX_EXPRESINFO set TF_BUZSTATUS = " + type + " where EI_ID = " + expId;
                int col = sqliteU.updateData(sqlStr);
                if (col == 1)
                {
                    return true;
                }
                else
                {
                    LogHelper.Log("更新快件异常！，SQL语句：" + sqlStr);
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log("更新快件状态异常", ex);
                return false;
            }
        }

        /// <summary>
        /// 减锁格口
        /// </summary>
        /// <param name="moNo"></param>
        /// <param name="pbCrtNo"></param>
        /// <returns></returns>
        public bool freeMouthArkState(string moNo, string pbCrtNo)
        {
            try
            {
                int result = sqliteU.updateData("update EBOX_MOUTH_ARK set TF_BUZSTATUS = 1,TF_UPDATEDATE =  datetime('now','localtime')  where MO_NO = " + moNo + " and TF_DELETEFLAG = 0");
                EboxMouthArk eboxMouthArk = sqliteU.getEboxMouthArk("where MO_NO = " + moNo);
                LogHelper.Log("格口状态(格口原始状态为:2)：MoNo = " + eboxMouthArk.MONO + ",TfBuz = " + eboxMouthArk.TFBUZSTATUS + ",Id = " + eboxMouthArk.ID);
                if (result == 1)
                {
                    LogHelper.Log("格口减锁成功！");

                    return true;

                }
                else
                {
                    LogHelper.Log("更新格口状态失败,格口减锁失败！");
                    return false;

                }
            }
            catch (Exception ex)
            {
                LogHelper.Log("更新格口状态失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 设置逾期件状态
        /// </summary>
        /// <param name="eiId"></param>
        public void setExpressOvertime(int eiId)
        {
            var sql1 = @"update ebox_expresinfo set TF_BUZSTATUS={0} where EI_ID={1}";
            db.ExecuteCommand(sql1, 7, eiId);
            db.SubmitChanges();
        }

        public SaveJiJianInfoResult SaveExceptionException(JObject info)
        {
            if (info == null) return null;
            try
            {
                if (Setting.Instance.IsDebug)
                {
                    LogHelper.Log("正在保存异常件");
                }
                var expressException = info as JObject;
                var map1 = MapInsert(expressException, "ebox_expressException");
                if (null != map1)
                {
                    var paraArr = map1.ParamDataList;
                    db.ExecuteCommand(map1.Sql, paraArr.ToArray());
                    var newId = expressException.GetValue("eoOrderNo");
                    if (Setting.Instance.IsDebug)
                    {
                        LogHelper.Log("保存异常件成功,id:" + newId);
                    }
                    return new SaveJiJianInfoResult
                    {
                        ExpressInfo = db.EBOXEXPRESINFO.FirstOrDefault(c => c.EIORDERNO == newId.ToString()),
                        ExpressException = db.EBOXEXPRESSEXCEPTION.FirstOrDefault(c => c.EOORDERNO == newId.ToString())
                    };
                }
                else
                {
                    LogHelper.Log("映射服务器数据到本地异常，请检查服务器返回格式是否和本地库字段匹配");
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log("保存异常件失败", ex);
                return null;
            }
        }

        public SaveJiJianInfoResult SaveJiJianInfo(JObject info)
        {
            if (info == null) return null;
            try
            {
                var expressInfo = info.GetValue("expressInfo") as JObject;
                var subInfo = info.GetValue("expresSubInfo") as JObject;
                var map1 = MapInsert(expressInfo, "ebox_expresinfo");
                var map2 = MapInsert(subInfo, "ebox_expressubinfo", map1.ParamDataList.Count);
                if (map1 != null && map2 != null)
                {
                    var paraArr = map1.ParamDataList;
                    paraArr.AddRange(map2.ParamDataList);
                    db.ExecuteCommand(map1.Sql + ";" + map2.Sql, paraArr.ToArray());
                    var newId = Convert.ToInt32(expressInfo.GetValue("eiId"));
                    LogHelper.Log("寄件信息保存成功，ID:" + newId);
                    return new SaveJiJianInfoResult
                    {
                        ExpressInfo = db.EBOXEXPRESINFO.FirstOrDefault(c => c.EIID == newId),
                        ExpressSubInfo = db.EBOXEXPRESSUBINFO.FirstOrDefault(c => c.EIID == newId)
                    };
                }
                else
                {
                    LogHelper.Log("映射服务器数据到本地异常，请检查服务器返回格式是否和本地库字段匹配");
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log("保存终端寄件信息异常", ex);
                return null;
            }
        }

        public MapInsertResult MapInsert(JObject info, string tableName, int start = 0)
        {
            if (info == null) return null;
            var ps = string.Empty;
            var colstr = string.Empty;
            var param = new List<object>();
            try
            {
                foreach (var item in info)
                {
                    if (tableName.Equals("EBOX_HANDWARE_CONFIG", StringComparison.OrdinalIgnoreCase)
                        && item.Key.StartsWith("pbId", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    else if (tableName.Equals("EBOX_STORECONTENTARK", StringComparison.OrdinalIgnoreCase)
                      && item.Key.StartsWith("sca", StringComparison.OrdinalIgnoreCase))
                    {
                        ps += "{" + (start++) + "},";
                        colstr += "`" + (item.Key.Substring(0, 3) + "_" + item.Key.Substring(3)) + "`,";
                    }
                    else
                    {
                        ps += "{" + (start++) + "},";
                        colstr += "`" + (item.Key.Length > 2 ? (item.Key.Substring(0, 2) + "_" + item.Key.Substring(2)) : item.Key) + "`,";
                    }
                    param.Add(item.Value);
                }
                ps = ps.Trim(',');
                colstr = colstr.Trim(',');
                return new MapInsertResult
                {
                    Sql = "REPLACE INTO `" + tableName + "` (" + colstr + @") VALUES (" + ps + ");",
                    ParamDataList = param
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log("映射服务器数据到本地异常，请检查服务器返回格式是否和本地库字段匹配", ex);
                return null;
            }
        }

        /// <summary>
        /// 初始化同步、基础数据同步入口
        /// </summary>
        /// <param name="table">同步表名</param>
        /// <param name="data">同步表结构</param>
        public void SyncData(string table, JObject data)
        {
            if (table.Equals("pboxInfo", StringComparison.OrdinalIgnoreCase))
                table = "pbox";
            else if (table.Equals("handwareConfig", StringComparison.OrdinalIgnoreCase))
                table = "handware_config";
            else if (table.Equals("mouthArk", StringComparison.OrdinalIgnoreCase))
                table = "mouth_ark";
            else if (table.Equals("logisticscompanyConfig", StringComparison.OrdinalIgnoreCase))
                table = "logisticscompany_config";
            else if (table.Equals("sysVersion", StringComparison.OrdinalIgnoreCase))
                table = "sys_version";
            else if (table.Equals("sysCode", StringComparison.OrdinalIgnoreCase))
                table = "sys_code";
            else if (table.Equals("countyCode", StringComparison.OrdinalIgnoreCase))
                table = "county_code";
            else if (table.Equals("cityCode", StringComparison.OrdinalIgnoreCase))
                table = "city_code";
            else if (table.Equals("mouth", StringComparison.OrdinalIgnoreCase))
                table = "mouth";
            else if (table.Equals("provinceCode", StringComparison.OrdinalIgnoreCase))
                table = "province_code";
            else if (table.Equals("userProtocol", StringComparison.OrdinalIgnoreCase))
                table = "user_protocol";
            else if (table.Equals("express", StringComparison.OrdinalIgnoreCase))
                table = "expresinfo";
            else if (table.Equals("overdueBusiness", StringComparison.OrdinalIgnoreCase))
            {
                table = "expressException";
            }
            if (Setting.Instance.IsDebug)
            {
                LogHelper.Log("正在同步" + table + "\n内容:" + data.ToString());
            }
            var map1 = MapInsert(data, "ebox_" + table);
            if (map1 != null)
            {
                if (Setting.Instance.IsDebug)
                {
                    LogHelper.Log("正在同步" + table + "\nSQL:" + map1.Sql);
                }
                try
                {
                    db.ExecuteCommand(map1.Sql, map1.ParamDataList.ToArray());
                    LogHelper.Log("成功同步" + table);
                }
                catch (Exception ex)
                {
                    LogHelper.Log("同步数据失败", ex);
                }
                if ("mouth_ark" == table)
                {
                    int mouthId = 0;
                    double mouthPrice = 0.0;
                    string flag = "";
                    foreach (var item in data)
                    {
                        if (item.Key.StartsWith("MOTYPEID", StringComparison.OrdinalIgnoreCase))
                        {
                            mouthId = Convert.ToInt32(item.Value);
                        }
                        if (item.Key.StartsWith("MOSTANDFEE", StringComparison.OrdinalIgnoreCase))
                        {
                            mouthPrice = Convert.ToDouble(item.Value);
                        }
                        if (item.Key.StartsWith("TFBACKUPFIELD2", StringComparison.OrdinalIgnoreCase))
                        {
                            flag = item.Value == null ? "" : item.Value.ToString();
                        }
                        if (mouthId > 0 && mouthPrice > 0 && flag == "1")
                        {
                            break;
                        }
                    }
                    if (mouthId > 0 && mouthPrice > 0 && flag == "1")
                    {
                        var sql1 = @"update ebox_mouth_ark set MO_STANDFEE={0},TF_UPDATEDATE =  datetime('now','localtime') where MO_TYPEID={1}";
                        db.ExecuteCommand(sql1, mouthPrice, mouthId);
                        db.SubmitChanges();
                        var sql2 = @"update ebox_mouth set MO_PRICE={0},TF_UPDATEDATE =  datetime('now','localtime') where MO_ID={1}";
                        db.ExecuteCommand(sql2, mouthPrice, mouthId);
                        db.SubmitChanges();
                    }
                }
                if ("expressException" == table)
                {
                    foreach (var info in data)
                    {
                        if (info.Key.Equals("eoEiId", StringComparison.OrdinalIgnoreCase))
                        {
                            setExpressOvertime(Convert.ToInt32(info.Value));
                            break;
                        }
                    }
                }
            }
            else
            {
                LogHelper.Log("映射服务器数据" + table + "到本地异常，请检查服务器返回格式是否和本地库字段匹配");
            }
          //  ....

        }

        public class MapInsertResult
        {
            public string Sql { get; set; }
            public List<object> ParamDataList { get; set; }
        }

        public class SaveJiJianInfoResult
        {
            public Data.EBOXEXPRESINFO ExpressInfo { get; set; }
            public Data.EBOXEXPRESSUBINFO ExpressSubInfo { get; set; }
            public Data.EBOXEXPRESSEXCEPTION ExpressException { get; set; }
        }

        public string queryTypeIdByTypeName(string type)
        {
            var sql2 = @"select MO_ID as Data from ebox_mouth where MO_MODEL={0} and TF_DELETEFLAG=0";
            var mouthData = db.ExecuteQuery<SingleData>(sql2, type).FirstOrDefault();
            if (null != mouthData)
            {
                return mouthData.Data.ToString();
            }
            return "";
        }

        public bool modifyMouthArkInfo(int id, int typeId, string no, int state)
        {
            //var sql1 = @"update ebox_mouth_ark set TF_BUZSTATUS={0},MO_NO={1},MO_TYPEID={2} where ID={3} and TF_DELETEFLAG=0";
            //db.ExecuteCommand(sql1, state, no, typeId, id);
            var ark = sqliteU.getEboxMouthArk("where TF_DELETEFLAG =0 and ID = " + id);
            if (null != ark)
            {
                int result = sqliteU.updateData("update EBOX_MOUTH_ARK set TF_BUZSTATUS =" + state + ",TF_UPDATEDATE =  datetime('now','localtime') where TF_DELETEFLAG = 0 and ID = " + id);
                if (result == 1)
                {
                    LogHelper.Log("格口更新成功！");
                    EboxMouthArk eboxMouthArk = sqliteU.getEboxMouthArk("where ID = " + id);
                    LogHelper.Log("格口状态：MoNo = " + eboxMouthArk.MONO + ",TfBuz = " + eboxMouthArk.TFBUZSTATUS + ",Id = " + eboxMouthArk.ID);
                    return true;
                }
                else
                {
                    LogHelper.Log("格口更新失败！");
                    return false;
                }
            }
            return false;
        }

        public Data.EBOXSYSVERSION GetSysVersion()
        {
            return db.EBOXSYSVERSION.FirstOrDefault();
        }
    }
}
