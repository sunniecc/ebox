using System;
using System.Collections.Generic;
using System.Linq;
using EBoxClient.Device;
using System.Text;
using EBoxClient.Utils;
namespace EBoxClient
{
    partial class FrmMain
    {
        /// <summary>
        /// 修改格口参数
        /// </summary>
        /// <param name="id">格口ID</param>
        /// <param name="type">格口类型名称</param>
        /// <param name="no">格口编号</param>
        /// <param name="state">格口状态名称</param>
        public void modifyMouthArk(string id, string type, string no, string state)
        {
            LogHelper.Log("modifyMouthArk:id:" + id + ",type:" + type + ",no:" + no + ",state:" + state);
            int stateValue = 0;
            if ("占用" == state)
            {
                stateValue = 3;
            }
            else if ("使用" == state)
            {
                stateValue = 2;
            }
            else
            {
                stateValue = 1;
            }
            if (stateValue == 1)
            {
                releaseExpress(no);
            }
            var ark = localData.GetBoxLockNoById(Convert.ToInt32(id));
            string typeId = localData.queryTypeIdByTypeName(type);
            LogHelper.Log("modifyMouthArk:" + JsonHelper.ToJson(typeId));
            var rst = service.mouthConfig(Setting.Instance.BoxID, Setting.Instance.BoxNo, id, no, Convert.ToInt32(typeId), stateValue);
            if (rst.ToString() == "-1")
            {
                localData.modifyMouthArkInfo(Convert.ToInt32(id), Convert.ToInt32(typeId), no, stateValue);
            }
        }

        /// <summary>
        /// 管理员修改格口状态从使用到空闲时，释放当前格口内所有快件
        /// </summary>
        /// <param name="moNo"></param>
        public void releaseExpress(string moNo)
        {
            var sql = @"              select 
                    ei.ei_id as eiId,
                    ei.ei_storeUserName as eiStoreUserName,
                    ei.ei_storeUserPhone as eiStoreUserPhone,
                    ei.EI_BARCODE as eiBarcode,
                    ei.EI_ORDERNO as eiOrderNo,
                    ei.tf_buzStatus as tfBuzStatus,
                    ei.ei_latticeNo as eiLatticeNo,
                    ei.EI_LCID as eiLcId
                    from ebox_expresinfo ei 
                    where ei.tf_deleteFlag=0
                    and ei.tf_buzStatus in (3,5,7)
                    and ei.ei_latticeNo={0}
                    and ei.ei_eboxNo={1}
                    ";
            var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
            var userId = userInfo["userInfo"].Value<string>("uiId");
            var uaUserIdCode = userInfo["userInfo"].Value<string>("uiUserIdCode");
            var uaUserIdType = userInfo["userInfo"].Value<string>("uiUserIdType");
            var eboxNo = Setting.Instance.BoxNo;
            var eboxId = Setting.Instance.BoxID;
            var expressList = localData.Query<ExpressList>(sql, moNo, eboxNo);
            if (null != expressList)
            {
                foreach (var e in expressList)
                {
                  
                    var rst = service.administratorToTake(eboxId, eboxNo, e.eiOrderNo.ToString(),
                                userId.ToString(), e.tfBuzStatus.ToString(), e.eiLcId.ToString(),
                                uaUserIdType.ToString(), uaUserIdCode.ToString(), e.eiLatticeNo.ToString());
                    if (null != rst && rst.ToString() == "-1")
                    {
                        localData.finishExpressBuz(Convert.ToInt32(e.eiId), Convert.ToInt32(e.tfBuzStatus) + 1);

                    }
                }
            }

        }
        public void adminExit()
        {
            var userInfo = JsonHelper.ToObject(JsonHelper.ToJson(uiData.UserInfo));
            int uiId = userInfo["userInfo"].Value<int>("uiId");
            if (uiId > 0)
            {
                service.userLoginOut(uiId.ToString(), 3);
            }
        }
        public string loadAllMouthList()
        {
            LogHelper.Log("开始读取所有格口数据！");
            var sql1 = @"SELECT ARK.ID as id,
ARK.MO_TYPEID AS moTypeId,
(SELECT EM.MO_MODEL FROM EBOX_MOUTH EM WHERE EM.MO_ID = ARK.MO_TYPEID ) AS moTypeName,
(SELECT EM.MO_COLOR FROM EBOX_MOUTH EM WHERE EM.MO_ID = ARK.MO_TYPEID ) AS moColor,
ARK.MO_LOCKNO AS moLockNo,
ARK.MO_CSANO AS moCsaNo,
ARK.MO_NO AS moNo,
ARK.TF_BUZSTATUS AS buzStatus,
(select s.scname from 
ebox_sys_code s where s.ctno=5012 and 
s.syscode=ARK.TF_BUZSTATUS) as buzStatusName
 FROM EBOX_MOUTH_ARK ARK WHERE ARK.tf_deleteFlag=0 ORDER BY ARK.tf_backupField1";
            var sql = @"select 
                        ei.ei_storeUserName as eiStoreUserName,
                        ei.ei_storeUserPhone as eiStoreUserPhone,
                        ei.EI_LCNAME as eiLcName,
                        ei.EI_BARCODE as eiBarcode,
                        ei.EI_MAILTYPE as eiMailType,
                        ei.EI_TAKEUSERNAME as eiTakeUserName,
                        ei.EI_TAKEUSERPHONE as eiTakeUserPhone,
                        ei.ei_latticeNo as eiLatticeNo
                        from ebox_expresinfo ei
                        where ei.el_storeUserType in (1,2)
                        and ei.tf_deleteFlag=0
                        and ei.tf_buzStatus in (2,3,5,7)
                        and ei.ei_eboxNo={0}";
            var sql2 = @"
                select m.mo_id as moId,m.mo_model as moModel from ebox_mouth m where m.TF_DELETEFLAG=0";
            var data = new
            {
                mouthArk = localData.Query<MouthArk>(sql1),
                expressList = localData.Query<ExpressList>(sql, Setting.Instance.BoxNo),
                mouth = localData.Query<Mouth>(sql2),
            };
            LogHelper.Log("格口数据读取完成！");
            return JsonHelper.ToJson(data);

        }
        class MouthArk
        {
            public object id { get; set; }
            public object moTypeId { get; set; }
            public object moTypeName { get; set; }
            public object moColor { get; set; }
            public object moLockNo { get; set; }
            public object moCsaNo { get; set; }
            public object moNo { get; set; }
            public object buzStatus { get; set; }
            public object buzStatusName { get; set; }
        }

        class ExpressList
        {
            public object eiId { get; set; }
            public object eiLcId { get; set; }
            public object eiOrderNo { get; set; }
            public object eiStoreUserName { get; set; }
            public object eiStoreUserPhone { get; set; }
            public object eiLcName { get; set; }
            public object eiMailType { get; set; }
            public object eiTakeUserName { get; set; }
            public object eiTakeUserPhone { get; set; }
            public object eiLatticeNo { get; set; }
            public object eiBarcode { get; set; }
            public object tfBuzStatus { get; set; }
        }

        class Mouth
        {
            public object moId { get; set; }
            public object moModel { get; set; }
        }

        public string loadSysInfo()
        {
            var sql1 = @"select eo.op_no as opNo,
eo.op_name as opName,
eo.op_address as opAddress,
eo.op_contacts as opContacts,
eo.op_conPhone as opConPhone
 from ebox_operators eo
";
            var sql2 = @"select ep.pb_crtNo as pbCrtNo,
ep.pb_abbr as pbAbbr,
(select count(sc.sca_id) from 
ebox_storecontentark sc
where sc.sca_boxId=ep.pb_id and sc.TF_DELETEFLAG=0 and sc.TF_BUZSTATUS=1) as storeNum,
(select count(ma.id) from
ebox_mouth_ark ma 
where ma.mo_pbId=ep.pb_id and ma.TF_DELETEFLAG=0) as mouthNum
 from ebox_pbox ep
";

            var sql3 = @"select em.mo_id as moId,
em.mo_model as moModel,
em.mo_price as moPrice,
em.tf_buzStatus as buzStatus,
(select s.scname from 
ebox_sys_code s where s.ctno=5012 and 
s.syscode=em.tf_buzStatus) as buzStatusName
 from ebox_mouth em where em.TF_DELETEFLAG=0
";
            var sql4 = @"
    select ('V'||s.SV_MAINVERSION||'.'||s.SV_SUBVERSION||'.'||s.SV_SYSNO) as version,
S.SV_SYSNO AS SYSNO from ebox_sys_version s
";
            var data = new
            {
                op = localData.Query<SysInfo>(sql1),
                sys = localData.Query<PboxInfo>(sql2),
                mouth = localData.Query<MouthInfo>(sql3),
                version = localData.Query<SysVersion>(sql4).FirstOrDefault<SysVersion>(),
            };
            return JsonHelper.ToJson(data);
        }
        class SysInfo
        {
            public object opNo { get; set; }
            public object opName { get; set; }
            public object opAddress { get; set; }
            public object opContacts { get; set; }
            public object opConPhone { get; set; }
        }
        class PboxInfo
        {
            public object pbCrtNo { get; set; }
            public object pbAbbr { get; set; }
            public object storeNum { get; set; }
            public object mouthNum { get; set; }

        }
        class MouthInfo
        {
            public object moId { get; set; }
            public object moModel { get; set; }
            public object moPrice { get; set; }
            public object buzStatus { get; set; }
            public object buzStatusName { get; set; }
        }
        class SysVersion
        {
            public object sysNo { get; set; }
            public object version { get; set; }
        }
    }
}
