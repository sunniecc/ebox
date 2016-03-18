using EBoxClient.Utils;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;


namespace EBoxClient.Data
{
    class sqliteUtils
    {
        System.Data.SQLite.SQLiteConnection conn;

        public sqliteUtils()
        {
            conn = new SQLiteConnection();
            conn.ConnectionString = getConnStr().ToString();
            conn.Open();
        }
        public System.Data.SQLite.SQLiteConnectionStringBuilder getConnStr()
        {
            System.Data.SQLite.SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
            connstr.DataSource = "Data/ebox.db";
            return connstr;
        }


        public int updateData(string sql)
        {
            LogHelper.Log("SQL语句为："+sql);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            return cmd.ExecuteNonQuery();
        }

        public ExpressInfo getExpressInfo(string sql)
        {
            List<ExpressInfo> lists = getExpressInfos(sql);
            if (lists.Count <= 0)
                return null;
            return lists[0];
        }

        public List<ExpressInfo> getExpressInfos(string sql)
        {
            string sqlStr = "select EI_ID,EI_ORDERNO,EL_LCMAINID,EI_LCID,EI_LCNAME,EI_SENDERID,EI_STORETIME,EI_STOREUSERPHONE,EL_TAKEUSERTYPE,EI_TAKETIME" +
                ",EI_TAKEIDTYPE,EI_TAKEIDCODE,EI_PAYMENTMODE,EI_PAYMENTMONEY,EI_BARCODE,EI_EXPTYPE,EI_MAILTYPE,EI_EBOXID,EI_EBOXNO,EI_EBOXABBR,EI_LATTICENO,EI_VALIDATECODE"
               + ",EL_EXPSAVEMODE,EL_EXPREMARK,EL_OVERTIME,TF_BUZSTATUS" +
                ",EI_SENDERNAME,EI_SENDERPHONE,EI_TAKEUSERNAME,EI_TAKEUSERPHONE from EBOX_EXPRESINFO " + sql;
            LogHelper.Log("getExpressInfos SQL = "+sqlStr);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = sqlStr;
            cmd.Connection = conn;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<ExpressInfo> lists = new List<ExpressInfo>();


            while (reader.Read())
            {
                ExpressInfo result = convertExpressInfo(reader);
                lists.Add(result);
            }

            cmd.Dispose();
            return lists;
        }

        public ExpressInfo convertExpressInfo(SQLiteDataReader reader)
        {
            ExpressInfo expressInfo = new ExpressInfo();
            expressInfo.EIID = reader.GetInt32(0);
            if (!Convert.IsDBNull(reader.GetValue(1)))
                expressInfo.EIORDERNO = reader.GetString(1);
            if (!Convert.IsDBNull(reader.GetValue(2)))
                expressInfo.ELLCMAINID = reader.GetInt32(2);
            if (!Convert.IsDBNull(reader.GetValue(3)))
                expressInfo.EILCID = reader.GetInt32(3);
            if (!Convert.IsDBNull(reader.GetValue(4)))
                expressInfo.EILCNAME = reader.GetString(4);
            if (!Convert.IsDBNull(reader.GetValue(5)))
                expressInfo.EISENDERID = reader.GetInt32(5);
            if (!Convert.IsDBNull(reader.GetValue(6)))
                expressInfo.EISTORETIME = reader.GetString(6);
            if (!Convert.IsDBNull(reader.GetValue(7)))
                expressInfo.EISTOREUSERPHONE = reader.GetString(7);
            if (!Convert.IsDBNull(reader.GetValue(8)))
                expressInfo.ELTAKEUSERTYPE = reader.GetInt32(8);
            if (!Convert.IsDBNull(reader.GetValue(9)))
                expressInfo.EITAKETIME = reader.GetString(9);
            if (!Convert.IsDBNull(reader.GetValue(10)))
                expressInfo.EITAKEIDTYPE = reader.GetInt32(10);
            if (!Convert.IsDBNull(reader.GetValue(11)))
                expressInfo.EITAKEIDCODE = reader.GetString(11);
            if (!Convert.IsDBNull(reader.GetValue(12)))
                expressInfo.EIPAYMENTMODE = reader.GetInt32(12);
            if (!Convert.IsDBNull(reader.GetValue(13)))
                expressInfo.EIPAYMENTMONEY = reader.GetDouble(13);
            if (!Convert.IsDBNull(reader.GetValue(14)))
                expressInfo.EIBARCODE = reader.GetString(14);
            if (!Convert.IsDBNull(reader.GetValue(15)))
                expressInfo.EIEXPTYPE = reader.GetInt32(15);
            if (!Convert.IsDBNull(reader.GetValue(16)))
                expressInfo.EIMAILTYPE = reader.GetInt32(16);
            if (!Convert.IsDBNull(reader.GetValue(17)))
                expressInfo.EIEBOXID = reader.GetInt32(17);
            if (!Convert.IsDBNull(reader.GetValue(18)))
                expressInfo.EIEBOXNO = reader.GetString(18);
            if (!Convert.IsDBNull(reader.GetValue(19)))
                expressInfo.EIEBOXABBR = reader.GetString(19);
            if (!Convert.IsDBNull(reader.GetValue(20)))
                expressInfo.EILATTICENO = reader.GetString(20);
            if (!Convert.IsDBNull(reader.GetValue(21)))
                expressInfo.EIVALIDATECODE = reader.GetInt64(21);
            if (!Convert.IsDBNull(reader.GetValue(22)))
                expressInfo.ELEXPSAVEMODE = reader.GetInt32(22);
            if (!Convert.IsDBNull(reader.GetValue(23)))
                expressInfo.ELEXPREMARK = reader.GetString(23);
            if (!Convert.IsDBNull(reader.GetValue(24)))
                expressInfo.ELOVERTIME = reader.GetString(24);
            if (!Convert.IsDBNull(reader.GetValue(25)))
                expressInfo.TFBUZSTATUS = reader.GetInt32(25);
            if (!Convert.IsDBNull(reader.GetValue(26)))
                expressInfo.EISENDERNAME = reader.GetString(26);
            if (!Convert.IsDBNull(reader.GetValue(27)))
                expressInfo.EISENDERPHONE = reader.GetString(27);
            if (!Convert.IsDBNull(reader.GetValue(28)))
                expressInfo.EITAKEUSERNAME = reader.GetString(28);
            if (!Convert.IsDBNull(reader.GetValue(29)))
                expressInfo.EITAKEUSERPHONE = reader.GetString(29);
            return expressInfo;

        }

        public EboxMouthArk getEboxMouthArk(string sql)
        {
            List<EboxMouthArk> lists = getEboxMouthArks(sql);
            if (lists.Count <= 0)
                return null;
            return lists[0];
        }
        
        public List<EboxMouthArk> getEboxMouthArks(string sql)
        {
            string sqlStr = "select ID,MO_PBID,MO_PBNO,MO_CSAID,MO_CSANO,MO_TYPEID,MO_LOCKNO,MO_FULLNO,MO_NO,MO_SCALE,MO_SIZE,MO_STANDFEE,TF_BUZSTATUS from EBOX_MOUTH_ARK " + sql;
            LogHelper.Log("getEboxMouthArks= " + sqlStr);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = sqlStr;
            cmd.Connection = conn;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<EboxMouthArk> lists = new List<EboxMouthArk>();


            while (reader.Read())
            {
                EboxMouthArk result = convertMouthArk(reader);
                lists.Add(result);
            }

            cmd.Dispose();
            return lists;
        }

        public EboxMouthArk convertMouthArk(SQLiteDataReader reader)
        {
            EboxMouthArk eboxMouthArk = new EboxMouthArk();
            if (!Convert.IsDBNull(reader.GetValue(0)))
                eboxMouthArk.ID = reader.GetInt32(0);
            if (!Convert.IsDBNull(reader.GetValue(1)))
                eboxMouthArk.MOPBID = reader.GetInt32(1);
            if (!Convert.IsDBNull(reader.GetValue(2)))
                eboxMouthArk.MOPBNO = reader.GetString(2);
            if (!Convert.IsDBNull(reader.GetValue(3)))
                eboxMouthArk.MOCSAID = reader.GetInt32(3);
            if (!Convert.IsDBNull(reader.GetValue(4)))
                eboxMouthArk.MOCSANO = reader.GetString(4);
            if (!Convert.IsDBNull(reader.GetValue(5)))
                eboxMouthArk.MOTYPEID = reader.GetInt32(5);
            if (!Convert.IsDBNull(reader.GetValue(6)))
                eboxMouthArk.MOLOCKNO = reader.GetString(6);
            if (!Convert.IsDBNull(reader.GetValue(7)))
                eboxMouthArk.MOFULLNO = reader.GetString(7);
            if (!Convert.IsDBNull(reader.GetValue(8)))
                eboxMouthArk.MONO = reader.GetString(8);
            if (!Convert.IsDBNull(reader.GetValue(9)))
                eboxMouthArk.MOSCALE = reader.GetString(9);
            if (!Convert.IsDBNull(reader.GetValue(10)))
                eboxMouthArk.MOSIZE = reader.GetString(10);
            if (!Convert.IsDBNull(reader.GetValue(11)))
                eboxMouthArk.MOSTANDFEE = reader.GetDouble(11);
            if (!Convert.IsDBNull(reader.GetValue(12)))
                eboxMouthArk.TFBUZSTATUS = reader.GetInt32(12);
            return eboxMouthArk;
        }

        public ExpressException getExpressException(string sql)
        {
            List<ExpressException> lists = getExpressExceptions(sql);
            if (lists.Count <= 0)
                return null;
            return lists[0];
        }

        public List<ExpressException> getExpressExceptions(string sql)
        {
            string sqlStr = "select EO_ID,EO_EIID,EO_LCID,EO_BARCODE,EO_ORDERNO,EO_EXPTYPE,EO_VALIDATECODE,EO_OVERTIMEDAY,EO_OVERTIMECNT,EO_OVERTIMEPRICE,EO_OVERTIMEFEE,EO_REMARK,TF_BUZSTATUS,TF_DELETEFLAG,TF_CREATERID,TF_CREATERNAME,TF_CREATEDATE,TF_UPDATERID,TF_UPDATERNAME,TF_UPDATEDATE,TF_BACKUPFIELD1,TF_BACKUPFIELD2,TF_BACKUPFIELD3 from EBOX_EXPRESSEXCEPTION " + sql;
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = sqlStr;
            cmd.Connection = conn;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<ExpressException> lists = new List<ExpressException>();
            while (reader.Read())
            {
                ExpressException result = convertExpressException(reader);
                lists.Add(result);
            }
            cmd.Dispose();
            return lists;
        }

        public ExpressException convertExpressException(SQLiteDataReader reader)
        {
            ExpressException expressException = new ExpressException();

            expressException.EOID = reader.GetInt32(0);

            if (!Convert.IsDBNull(reader.GetValue(1)))
                expressException.EOEIID = reader.GetInt32(1);
            if (!Convert.IsDBNull(reader.GetValue(2)))
                expressException.EOLCID = reader.GetInt32(2);
            if (!Convert.IsDBNull(reader.GetValue(3)))
                expressException.EOBARCODE = reader.GetString(3);
            if (!Convert.IsDBNull(reader.GetValue(4)))
                expressException.EOORDERNO = reader.GetString(4);
            if (!Convert.IsDBNull(reader.GetValue(5)))
                expressException.EOEXPTYPE = reader.GetInt32(5);
            if (!Convert.IsDBNull(reader.GetValue(6)))
                expressException.EOVALIDATECODE = reader.GetInt32(6);
            if (!Convert.IsDBNull(reader.GetValue(7)))
                expressException.EOOVERTIMEDAY = reader.GetInt32(7);
            if (!Convert.IsDBNull(reader.GetValue(8)))
                expressException.EOOVERTIMECNT = reader.GetInt32(8);
            if (!Convert.IsDBNull(reader.GetValue(9)))
                expressException.EOOVERTIMEPRICE = reader.GetDouble(9);
            if (!Convert.IsDBNull(reader.GetValue(10)))
                expressException.EOOVERTIMEFEE = reader.GetDouble(10);
            if (!Convert.IsDBNull(reader.GetValue(11)))
                expressException.EOREMARK = reader.GetString(11);
            if (!Convert.IsDBNull(reader.GetValue(12)))
                expressException.TFBUZSTATUS = reader.GetInt32(12);
            if (!Convert.IsDBNull(reader.GetValue(13)))
                expressException.TFDELETEFLAG = reader.GetInt32(13);
            if (!Convert.IsDBNull(reader.GetValue(14)))
                expressException.TFCREATERID = reader.GetInt32(14);
            if (!Convert.IsDBNull(reader.GetValue(15)))
                expressException.TFCREATERNAME = reader.GetString(15);
            if (!Convert.IsDBNull(reader.GetValue(16)))
                expressException.TFCREATEDATE = reader.GetString(16);
            if (!Convert.IsDBNull(reader.GetValue(17)))
                expressException.TFUPDATERID = reader.GetInt32(17);
            if (!Convert.IsDBNull(reader.GetValue(18)))
                expressException.TFUPDATERNAME = reader.GetString(18);
            if (!Convert.IsDBNull(reader.GetValue(19)))
                expressException.TFUPDATEDATE = reader.GetString(19);
            if (!Convert.IsDBNull(reader.GetValue(20)))
                expressException.TFBACKUPFIELD1 = reader.GetDouble(20);
            if (!Convert.IsDBNull(reader.GetValue(21)))
                expressException.TFBACKUPFIELD2 = reader.GetString(21);
            if (!Convert.IsDBNull(reader.GetValue(22)))
                expressException.TFBACKUPFIELD3 = reader.GetString(22);
            return expressException;
        }
    }

    public class ExpressInfo
    {
        public int EIID;
        public string EIORDERNO;
        public System.Nullable<int> ELLCMAINID;
        public System.Nullable<int> EILCID;
        public string EILCNAME;
        public System.Nullable<int> EISENDERID;
        public string EISENDERNAME;
        public string EISENDERPHONE;
        public string EISTOREUSERNAME;
        public string EISTOREUSERPHONE;
        public string EISTORETIME;
        public System.Nullable<int> ELTAKEUSERTYPE;
        public string EITAKEUSERID;
        public string EITAKEUSERNAME;
        public string EITAKEUSERPHONE;
        public string EITAKETIME;
        public System.Nullable<int> EITAKEIDTYPE;
        public string EITAKEIDCODE;
        public System.Nullable<int> EIPAYMENTMODE;
        public System.Nullable<double> EIPAYMENTMONEY;
        public string EIBARCODE;
        public System.Nullable<int> EIEXPTYPE;
        public System.Nullable<int> EIMAILTYPE;
        public System.Nullable<int> EIEBOXID;
        public string EIEBOXNO;
        public string EIEBOXABBR;
        public string EILATTICENO;
        public System.Nullable<long> EIVALIDATECODE;
        public System.Nullable<int> ELEXPSAVEMODE;
        public string ELEXPREMARK;
        public string ELOVERTIME;
        public int TFBUZSTATUS;
        public System.Nullable<int> TFDELETEFLAG;
        public System.Nullable<double> EIMOUTHMONEY;
    }



    public class EboxMouthArk
    {
        public System.Nullable<int> ID;
        public System.Nullable<int> MOPBID;
        public string MOPBNO;
        public System.Nullable<int> MOCSAID;
        public string MOCSANO;
        public System.Nullable<int> MOTYPEID;
        public string MOLOCKNO;
        public string MOFULLNO;
        public string MONO;
        public string MOSCALE;
        public string MOSIZE;
        public System.Nullable<double> MOSTANDFEE;
        public System.Nullable<int> TFBUZSTATUS;
    }

    public class ExpressException
    {
        public int EOID;
        public System.Nullable<int> EOEIID;
        public System.Nullable<int> EOLCID;
        public string EOBARCODE;
        public string EOORDERNO;
        public System.Nullable<int> EOEXPTYPE;
        public System.Nullable<int> EOVALIDATECODE;
        public System.Nullable<int> EOOVERTIMEDAY;
        public System.Nullable<int> EOOVERTIMECNT;
        public System.Nullable<double> EOOVERTIMEPRICE;
        public System.Nullable<double> EOOVERTIMEFEE;
        public string EOREMARK;
        public System.Nullable<int> TFBUZSTATUS;
        public System.Nullable<int> TFDELETEFLAG;
        public System.Nullable<int> TFCREATERID;
        public string TFCREATERNAME;
        public string TFCREATEDATE;
        public System.Nullable<int> TFUPDATERID;
        public string TFUPDATERNAME;
        public string TFUPDATEDATE;
        public System.Nullable<double> TFBACKUPFIELD1;
        public string TFBACKUPFIELD2;
        public string TFBACKUPFIELD3;
    }
}

