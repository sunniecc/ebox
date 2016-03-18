// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from Data on 2014-06-04 22:14:49Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace EBoxClient.Data
{
    using System;
    using System.ComponentModel;
    using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
    using DbLinq.Data.Linq;
    using DbLinq.Vendor;
#endif  // MONO_STRICT
    using System.Data.Linq.Mapping;
    using System.Diagnostics;
    using System.IO;
    using EBoxClient.Utils;

    public partial class Data : DataContext
    {

        #region Extensibility Method Declarations
        partial void OnCreated();
        #endregion


        public Data(string connectionString) :
            base(connectionString)
        {
            this.OnCreated();
        }

        public Data(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public Data(IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public Table<EBOXCITYCODE> EBOXCITYCODE
        {
            get
            {
                return this.GetTable<EBOXCITYCODE>();
            }
        }

        public Table<EBOXCODETYPE> EBOXCODETYPE
        {
            get
            {
                return this.GetTable<EBOXCODETYPE>();
            }
        }

        public Table<EBOXCOUNTYCODE> EBOXCOUNTYCODE
        {
            get
            {
                return this.GetTable<EBOXCOUNTYCODE>();
            }
        }

        public Table<EBOXEXPRESINFO> EBOXEXPRESINFO
        {
            get
            {
                return this.GetTable<EBOXEXPRESINFO>();
            }
        }

        public Table<EBOXEXPRESSEXCEPTION> EBOXEXPRESSEXCEPTION
        {
            get
            {
                return this.GetTable<EBOXEXPRESSEXCEPTION>();
            }
        }

        public Table<EBOXEXPRESSUBINFO> EBOXEXPRESSUBINFO
        {
            get
            {
                return this.GetTable<EBOXEXPRESSUBINFO>();
            }
        }

        public Table<EBOXHANDWARECONFIG> EBOXHANDWARECONFIG
        {
            get
            {
                return this.GetTable<EBOXHANDWARECONFIG>();
            }
        }

        public Table<EBOXHANDWAREINFO> EBOXHANDWAREINFO
        {
            get
            {
                return this.GetTable<EBOXHANDWAREINFO>();
            }
        }

        public Table<EBOXHANDWARERECORD> EBOXHANDWARERECORD
        {
            get
            {
                return this.GetTable<EBOXHANDWARERECORD>();
            }
        }

        public Table<EBOXHANDWAREVALIDATE> EBOXHANDWAREVALIDATE
        {
            get
            {
                return this.GetTable<EBOXHANDWAREVALIDATE>();
            }
        }

        public Table<EBOXLOGISTICSCOMPANYCONFIG> EBOXLOGISTICSCOMPANYCONFIG
        {
            get
            {
                return this.GetTable<EBOXLOGISTICSCOMPANYCONFIG>();
            }
        }

        public Table<EBOXMOUTH> EBOXMOUTH
        {
            get
            {
                return this.GetTable<EBOXMOUTH>();
            }
        }

        public Table<EBOXMOUTHARK> EBOXMOUTHARK
        {
            get
            {
                return this.GetTable<EBOXMOUTHARK>();
            }
        }

        public Table<EBOXONTROLCABINET> EBOXONTROLCABINET
        {
            get
            {
                return this.GetTable<EBOXONTROLCABINET>();
            }
        }

        public Table<EBOXOPERATORS> EBOXOPERATORS
        {
            get
            {
                return this.GetTable<EBOXOPERATORS>();
            }
        }

        public Table<EBOXPBOX> EBOXPBOX
        {
            get
            {
                return this.GetTable<EBOXPBOX>();
            }
        }

        public Table<EBOXPROVINCECODE> EBOXPROVINCECODE
        {
            get
            {
                return this.GetTable<EBOXPROVINCECODE>();
            }
        }

        public Table<EBOXSTORECONTENTARK> EBOXSTORECONTENTARK
        {
            get
            {
                return this.GetTable<EBOXSTORECONTENTARK>();
            }
        }

        public Table<EBOXSYSCODE> EBOXSYSCODE
        {
            get
            {
                return this.GetTable<EBOXSYSCODE>();
            }
        }

        public Table<EBOXSYSTEMSWITCH> EBOXSYSTEMSWITCH
        {
            get
            {
                return this.GetTable<EBOXSYSTEMSWITCH>();
            }
        }

        public Table<EBOXSYSVERSION> EBOXSYSVERSION
        {
            get
            {
                return this.GetTable<EBOXSYSVERSION>();
            }
        }

        public Table<EBOXUSERLOGINLOG> EBOXUSERLOGINLOG
        {
            get
            {
                return this.GetTable<EBOXUSERLOGINLOG>();
            }
        }

        public Table<EBOXUSEROPTLOG> EBOXUSEROPTLOG
        {
            get
            {
                return this.GetTable<EBOXUSEROPTLOG>();
            }
        }

        public Table<EBOXUSERPROTOCOL> EBOXUSERPROTOCOL
        {
            get
            {
                return this.GetTable<EBOXUSERPROTOCOL>();
            }
        }
    }

    #region Start MONO_STRICT
#if MONO_STRICT

	public partial class Data
	{
		
		public Data(IDbConnection connection) : 
				base(connection)
		{
			this.OnCreated();
		}
	}
    #region End MONO_STRICT
    #endregion
#else     // MONO_STRICT

    public partial class Data
    {

        public Data(IDbConnection connection) :
            base(connection, new DbLinq.Sqlite.SqliteVendor())
        {
            FileStream logFile = new FileStream("sqlLog.txt",FileMode.OpenOrCreate);
            TextWriter tw = new StreamWriter(logFile);
            this.Log = tw;
            this.OnCreated();
        }

        public Data(IDbConnection connection, IVendor sqlDialect) :
            base(connection, sqlDialect)
        {
            this.OnCreated();
        }

        public Data(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) :
            base(connection, mappingSource, sqlDialect)
        {
            this.OnCreated();
        }
    }
    #region End Not MONO_STRICT
    #endregion
#endif     // MONO_STRICT
    #endregion

    [Table(Name = "main.EBOX_CITY_CODE")]
    public partial class EBOXCITYCODE : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _abbre;

        private string _cityename;

        private int _cityid;

        private string _cityname;

        private string _cityno;

        private System.Nullable<int> _provinceid;

        private string _provinceno;

        private System.Nullable<int> _sortno;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        //private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        //private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        //private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnABBREChanged();

        partial void OnABBREChanging(string value);

        partial void OnCITYENAMEChanged();

        partial void OnCITYENAMEChanging(string value);

        partial void OnCITYIDChanged();

        partial void OnCITYIDChanging(int value);

        partial void OnCITYNAMEChanged();

        partial void OnCITYNAMEChanging(string value);

        partial void OnCITYNOChanged();

        partial void OnCITYNOChanging(string value);

        partial void OnPROVINCEIDChanged();

        partial void OnPROVINCEIDChanging(System.Nullable<int> value);

        partial void OnPROVINCENOChanged();

        partial void OnPROVINCENOChanging(string value);

        partial void OnSORTNOChanged();

        partial void OnSORTNOChanging(System.Nullable<int> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXCITYCODE()
        {
            this.OnCreated();
        }

        [Column(Storage = "_abbre", Name = "ABBRE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ABBRE
        {
            get
            {
                return this._abbre;
            }
            set
            {
                if (((_abbre == value)
                            == false))
                {
                    this.OnABBREChanging(value);
                    this.SendPropertyChanging();
                    this._abbre = value;
                    this.SendPropertyChanged("ABBRE");
                    this.OnABBREChanged();
                }
            }
        }

        [Column(Storage = "_cityename", Name = "CITYENAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string CITYENAME
        {
            get
            {
                return this._cityename;
            }
            set
            {
                if (((_cityename == value)
                            == false))
                {
                    this.OnCITYENAMEChanging(value);
                    this.SendPropertyChanging();
                    this._cityename = value;
                    this.SendPropertyChanged("CITYENAME");
                    this.OnCITYENAMEChanged();
                }
            }
        }

        [Column(Storage = "_cityid", Name = "CITYID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int CITYID
        {
            get
            {
                return this._cityid;
            }
            set
            {
                if ((_cityid != value))
                {
                    this.OnCITYIDChanging(value);
                    this.SendPropertyChanging();
                    this._cityid = value;
                    this.SendPropertyChanged("CITYID");
                    this.OnCITYIDChanged();
                }
            }
        }

        [Column(Storage = "_cityname", Name = "CITYNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string CITYNAME
        {
            get
            {
                return this._cityname;
            }
            set
            {
                if (((_cityname == value)
                            == false))
                {
                    this.OnCITYNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._cityname = value;
                    this.SendPropertyChanged("CITYNAME");
                    this.OnCITYNAMEChanged();
                }
            }
        }

        [Column(Storage = "_cityno", Name = "CITYNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string CITYNO
        {
            get
            {
                return this._cityno;
            }
            set
            {
                if (((_cityno == value)
                            == false))
                {
                    this.OnCITYNOChanging(value);
                    this.SendPropertyChanging();
                    this._cityno = value;
                    this.SendPropertyChanged("CITYNO");
                    this.OnCITYNOChanged();
                }
            }
        }

        [Column(Storage = "_provinceid", Name = "PROVINCEID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PROVINCEID
        {
            get
            {
                return this._provinceid;
            }
            set
            {
                if ((_provinceid != value))
                {
                    this.OnPROVINCEIDChanging(value);
                    this.SendPropertyChanging();
                    this._provinceid = value;
                    this.SendPropertyChanged("PROVINCEID");
                    this.OnPROVINCEIDChanged();
                }
            }
        }

        [Column(Storage = "_provinceno", Name = "PROVINCENO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PROVINCENO
        {
            get
            {
                return this._provinceno;
            }
            set
            {
                if (((_provinceno == value)
                            == false))
                {
                    this.OnPROVINCENOChanging(value);
                    this.SendPropertyChanging();
                    this._provinceno = value;
                    this.SendPropertyChanged("PROVINCENO");
                    this.OnPROVINCENOChanged();
                }
            }
        }

        [Column(Storage = "_sortno", Name = "SORTNO", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SORTNO
        {
            get
            {
                return this._sortno;
            }
            set
            {
                if ((_sortno != value))
                {
                    this.OnSORTNOChanging(value);
                    this.SendPropertyChanging();
                    this._sortno = value;
                    this.SendPropertyChanged("SORTNO");
                    this.OnSORTNOChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        //[Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        //[DebuggerNonUserCode()]
        //public System.Nullable<System.DateTime> TFBACKUPFIELD3
        //{
        //    get
        //    {
        //        return this._tfbackupfield3;
        //    }
        //    set
        //    {
        //        if ((_tfbackupfield3 != value))
        //        {
        //            this.OnTFBACKUPFIELD3Changing(value);
        //            this.SendPropertyChanging();
        //            this._tfbackupfield3 = value;
        //            this.SendPropertyChanged("TFBACKUPFIELD3");
        //            this.OnTFBACKUPFIELD3Changed();
        //        }
        //    }
        //}

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {

                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        //[Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        //[DebuggerNonUserCode()]
        //public System.Nullable<System.DateTime> TFCREATEDATE
        //{
        //    get
        //    {
        //        return this._tfcreatedate;
        //    }
        //    set
        //    {
        //        if ((_tfcreatedate != value))
        //        {
        //            this.OnTFCREATEDATEChanging(value);
        //            this.SendPropertyChanging();
        //            this._tfcreatedate = value;
        //            this.SendPropertyChanged("TFCREATEDATE");
        //            this.OnTFCREATEDATEChanged();
        //        }
        //    }
        //}

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        //[Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        //[DebuggerNonUserCode()]
        //public System.Nullable<System.DateTime> TFUPDATEDATE
        //{
        //    get
        //    {
        //        return this._tfupdatedate;
        //    }
        //    set
        //    {
        //        if ((_tfupdatedate != value))
        //        {
        //            this.OnTFUPDATEDATEChanging(value);
        //            this.SendPropertyChanging();
        //            this._tfupdatedate = value;
        //            this.SendPropertyChanged("TFUPDATEDATE");
        //            this.OnTFUPDATEDATEChanged();
        //        }
        //    }
        //}

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_CODE_TYPE")]
    public partial class EBOXCODETYPE : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<sbyte> _codetype;

        private string _ctname;

        private string _ctno;

        private System.Nullable<int> _parentct;

        private string _remark;

        private System.Nullable<int> _sortno;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnCODETYPEChanged();

        partial void OnCODETYPEChanging(System.Nullable<sbyte> value);

        partial void OnCTNAMEChanged();

        partial void OnCTNAMEChanging(string value);

        partial void OnCTNOChanged();

        partial void OnCTNOChanging(string value);

        partial void OnPARENTCTChanged();

        partial void OnPARENTCTChanging(System.Nullable<int> value);

        partial void OnREMARKChanged();

        partial void OnREMARKChanging(string value);

        partial void OnSORTNOChanged();

        partial void OnSORTNOChanging(System.Nullable<int> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXCODETYPE()
        {
            this.OnCreated();
        }

        [Column(Storage = "_codetype", Name = "CODETYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> CODETYPE
        {
            get
            {
                return this._codetype;
            }
            set
            {
                if ((_codetype != value))
                {
                    this.OnCODETYPEChanging(value);
                    this.SendPropertyChanging();
                    this._codetype = value;
                    this.SendPropertyChanged("CODETYPE");
                    this.OnCODETYPEChanged();
                }
            }
        }

        [Column(Storage = "_ctname", Name = "CTNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string CTNAME
        {
            get
            {
                return this._ctname;
            }
            set
            {
                if (((_ctname == value)
                            == false))
                {
                    this.OnCTNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._ctname = value;
                    this.SendPropertyChanged("CTNAME");
                    this.OnCTNAMEChanged();
                }
            }
        }

        [Column(Storage = "_ctno", Name = "CTNO", DbType = "VARCHAR(20)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string CTNO
        {
            get
            {
                return this._ctno;
            }
            set
            {
                if (((_ctno == value)
                            == false))
                {
                    this.OnCTNOChanging(value);
                    this.SendPropertyChanging();
                    this._ctno = value;
                    this.SendPropertyChanged("CTNO");
                    this.OnCTNOChanged();
                }
            }
        }

        [Column(Storage = "_parentct", Name = "PARENTCT", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PARENTCT
        {
            get
            {
                return this._parentct;
            }
            set
            {
                if ((_parentct != value))
                {
                    this.OnPARENTCTChanging(value);
                    this.SendPropertyChanging();
                    this._parentct = value;
                    this.SendPropertyChanged("PARENTCT");
                    this.OnPARENTCTChanged();
                }
            }
        }

        [Column(Storage = "_remark", Name = "REMARK", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string REMARK
        {
            get
            {
                return this._remark;
            }
            set
            {
                if (((_remark == value)
                            == false))
                {
                    this.OnREMARKChanging(value);
                    this.SendPropertyChanging();
                    this._remark = value;
                    this.SendPropertyChanged("REMARK");
                    this.OnREMARKChanged();
                }
            }
        }

        [Column(Storage = "_sortno", Name = "SORTNO", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SORTNO
        {
            get
            {
                return this._sortno;
            }
            set
            {
                if ((_sortno != value))
                {
                    this.OnSORTNOChanging(value);
                    this.SendPropertyChanging();
                    this._sortno = value;
                    this.SendPropertyChanged("SORTNO");
                    this.OnSORTNOChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_COUNTY_CODE")]
    public partial class EBOXCOUNTYCODE : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _abbre;

        private System.Nullable<int> _cityid;

        private string _cityno;

        private int _coid;

        private string _coname;

        private string _cono;

        private System.Nullable<int> _sortno;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        //private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        //private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        //private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnABBREChanged();

        partial void OnABBREChanging(string value);

        partial void OnCITYIDChanged();

        partial void OnCITYIDChanging(System.Nullable<int> value);

        partial void OnCITYNOChanged();

        partial void OnCITYNOChanging(string value);

        partial void OnCOIDChanged();

        partial void OnCOIDChanging(int value);

        partial void OnCONAMEChanged();

        partial void OnCONAMEChanging(string value);

        partial void OnCONOChanged();

        partial void OnCONOChanging(string value);

        partial void OnSORTNOChanged();

        partial void OnSORTNOChanging(System.Nullable<int> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXCOUNTYCODE()
        {
            this.OnCreated();
        }

        [Column(Storage = "_abbre", Name = "ABBRE", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ABBRE
        {
            get
            {
                return this._abbre;
            }
            set
            {
                if (((_abbre == value)
                            == false))
                {
                    this.OnABBREChanging(value);
                    this.SendPropertyChanging();
                    this._abbre = value;
                    this.SendPropertyChanged("ABBRE");
                    this.OnABBREChanged();
                }
            }
        }

        [Column(Storage = "_cityid", Name = "CITYID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> CITYID
        {
            get
            {
                return this._cityid;
            }
            set
            {
                if ((_cityid != value))
                {
                    this.OnCITYIDChanging(value);
                    this.SendPropertyChanging();
                    this._cityid = value;
                    this.SendPropertyChanged("CITYID");
                    this.OnCITYIDChanged();
                }
            }
        }

        [Column(Storage = "_cityno", Name = "CITYNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string CITYNO
        {
            get
            {
                return this._cityno;
            }
            set
            {
                if (((_cityno == value)
                            == false))
                {
                    this.OnCITYNOChanging(value);
                    this.SendPropertyChanging();
                    this._cityno = value;
                    this.SendPropertyChanged("CITYNO");
                    this.OnCITYNOChanged();
                }
            }
        }

        [Column(Storage = "_coid", Name = "COID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int COID
        {
            get
            {
                return this._coid;
            }
            set
            {
                if ((_coid != value))
                {
                    this.OnCOIDChanging(value);
                    this.SendPropertyChanging();
                    this._coid = value;
                    this.SendPropertyChanged("COID");
                    this.OnCOIDChanged();
                }
            }
        }

        [Column(Storage = "_coname", Name = "CONAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string CONAME
        {
            get
            {
                return this._coname;
            }
            set
            {
                if (((_coname == value)
                            == false))
                {
                    this.OnCONAMEChanging(value);
                    this.SendPropertyChanging();
                    this._coname = value;
                    this.SendPropertyChanged("CONAME");
                    this.OnCONAMEChanged();
                }
            }
        }

        [Column(Storage = "_cono", Name = "CONO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string CONO
        {
            get
            {
                return this._cono;
            }
            set
            {
                if (((_cono == value)
                            == false))
                {
                    this.OnCONOChanging(value);
                    this.SendPropertyChanging();
                    this._cono = value;
                    this.SendPropertyChanged("CONO");
                    this.OnCONOChanged();
                }
            }
        }

        [Column(Storage = "_sortno", Name = "SORTNO", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SORTNO
        {
            get
            {
                return this._sortno;
            }
            set
            {
                if ((_sortno != value))
                {
                    this.OnSORTNOChanging(value);
                    this.SendPropertyChanging();
                    this._sortno = value;
                    this.SendPropertyChanged("SORTNO");
                    this.OnSORTNOChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        //[Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        //[DebuggerNonUserCode()]
        //public System.Nullable<System.DateTime> TFBACKUPFIELD3
        //{
        //    get
        //    {
        //        return this._tfbackupfield3;
        //    }
        //    set
        //    {
        //        if ((_tfbackupfield3 != value))
        //        {
        //            this.OnTFBACKUPFIELD3Changing(value);
        //            this.SendPropertyChanging();
        //            this._tfbackupfield3 = value;
        //            this.SendPropertyChanged("TFBACKUPFIELD3");
        //            this.OnTFBACKUPFIELD3Changed();
        //        }
        //    }
        //}

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        //[Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        //[DebuggerNonUserCode()]
        //public System.Nullable<System.DateTime> TFCREATEDATE
        //{
        //    get
        //    {
        //        return this._tfcreatedate;
        //    }
        //    set
        //    {
        //        if ((_tfcreatedate != value))
        //        {
        //            this.OnTFCREATEDATEChanging(value);
        //            this.SendPropertyChanging();
        //            this._tfcreatedate = value;
        //            this.SendPropertyChanged("TFCREATEDATE");
        //            this.OnTFCREATEDATEChanged();
        //        }
        //    }
        //}

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        //[Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        //[DebuggerNonUserCode()]
        //public System.Nullable<System.DateTime> TFUPDATEDATE
        //{
        //    get
        //    {
        //        return this._tfupdatedate;
        //    }
        //    set
        //    {
        //        if ((_tfupdatedate != value))
        //        {
        //            this.OnTFUPDATEDATEChanging(value);
        //            this.SendPropertyChanging();
        //            this._tfupdatedate = value;
        //            this.SendPropertyChanged("TFUPDATEDATE");
        //            this.OnTFUPDATEDATEChanged();
        //        }
        //    }
        //}

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }


    [Table(Name = "main.EBOX_EXPRESINFO")]
    public partial class EBOXEXPRESINFO : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _eibarcode;

        private string _eieboxabbr;

        private System.Nullable<int> _eieboxid;

        private string _eieboxno;

        private System.Nullable<sbyte> _eiexptype;

        private int _eiid;

        private string _eilatticeno;

        private System.Nullable<int> _eilcid;

        private string _eilcname;

        private System.Nullable<sbyte> _eimailtype;

        private string _eiorderno;

        private System.Nullable<int> _eipaymentmode;

        private System.Nullable<double> _eipaymentmoney;

        private System.Nullable<int> _eisenderid;

        private string _eisendername;

        private string _eisenderphone;

        private System.Nullable<System.DateTime> _eistoretime;

        private System.Nullable<int> _eistoreuserid;

        private string _eistoreusername;

        private string _eistoreuserphone;

        private string _eitakeidcode;

        private System.Nullable<sbyte> _eitakeidtype;

        private System.Nullable<System.DateTime> _eitaketime;

        private System.Nullable<int> _eitakeuserid;

        private string _eitakeusername;

        private string _eitakeuserphone;

        private System.Nullable<long> _eivalidatecode;

        private string _elexpremark;

        private System.Nullable<int> _elexpsavemode;

        private System.Nullable<int> _ellcmainid;

        private System.Nullable<System.DateTime> _elovertime;

        private System.Nullable<sbyte> _elstoreusertype;

        private System.Nullable<sbyte> _eltakeusertype;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnEIBARCODEChanged();

        partial void OnEIBARCODEChanging(string value);

        partial void OnEIEBOXABBRChanged();

        partial void OnEIEBOXABBRChanging(string value);

        partial void OnEIEBOXIDChanged();

        partial void OnEIEBOXIDChanging(System.Nullable<int> value);

        partial void OnEIEBOXNOChanged();

        partial void OnEIEBOXNOChanging(string value);

        partial void OnEIEXPTYPEChanged();

        partial void OnEIEXPTYPEChanging(System.Nullable<sbyte> value);

        partial void OnEIIDChanged();

        partial void OnEIIDChanging(int value);

        partial void OnEILATTICENOChanged();

        partial void OnEILATTICENOChanging(string value);

        partial void OnEILCIDChanged();

        partial void OnEILCIDChanging(System.Nullable<int> value);

        partial void OnEILCNAMEChanged();

        partial void OnEILCNAMEChanging(string value);

        partial void OnEIMAILTYPEChanged();

        partial void OnEIMAILTYPEChanging(System.Nullable<sbyte> value);

        partial void OnEIORDERNOChanged();

        partial void OnEIORDERNOChanging(string value);

        partial void OnEIPAYMENTMODEChanged();

        partial void OnEIPAYMENTMODEChanging(System.Nullable<int> value);

        partial void OnEIPAYMENTMONEYChanged();

        partial void OnEIPAYMENTMONEYChanging(System.Nullable<double> value);

        partial void OnEISENDERIDChanged();

        partial void OnEISENDERIDChanging(System.Nullable<int> value);

        partial void OnEISENDERNAMEChanged();

        partial void OnEISENDERNAMEChanging(string value);

        partial void OnEISENDERPHONEChanged();

        partial void OnEISENDERPHONEChanging(string value);

        partial void OnEISTORETIMEChanged();

        partial void OnEISTORETIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnEISTOREUSERIDChanged();

        partial void OnEISTOREUSERIDChanging(System.Nullable<int> value);

        partial void OnEISTOREUSERNAMEChanged();

        partial void OnEISTOREUSERNAMEChanging(string value);

        partial void OnEISTOREUSERPHONEChanged();

        partial void OnEISTOREUSERPHONEChanging(string value);

        partial void OnEITAKEIDCODEChanged();

        partial void OnEITAKEIDCODEChanging(string value);

        partial void OnEITAKEIDTYPEChanged();

        partial void OnEITAKEIDTYPEChanging(System.Nullable<sbyte> value);

        partial void OnEITAKETIMEChanged();

        partial void OnEITAKETIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnEITAKEUSERIDChanged();

        partial void OnEITAKEUSERIDChanging(System.Nullable<int> value);

        partial void OnEITAKEUSERNAMEChanged();

        partial void OnEITAKEUSERNAMEChanging(string value);

        partial void OnEITAKEUSERPHONEChanged();

        partial void OnEITAKEUSERPHONEChanging(string value);

        partial void OnEIVALIDATECODEChanged();

        partial void OnEIVALIDATECODEChanging(System.Nullable<long> value);

        partial void OnELEXPREMARKChanged();

        partial void OnELEXPREMARKChanging(string value);

        partial void OnELEXPSAVEMODEChanged();

        partial void OnELEXPSAVEMODEChanging(System.Nullable<int> value);

        partial void OnELLCMAINIDChanged();

        partial void OnELLCMAINIDChanging(System.Nullable<int> value);

        partial void OnELOVERTIMEChanged();

        partial void OnELOVERTIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnELSTOREUSERTYPEChanged();

        partial void OnELSTOREUSERTYPEChanging(System.Nullable<sbyte> value);

        partial void OnELTAKEUSERTYPEChanged();

        partial void OnELTAKEUSERTYPEChanging(System.Nullable<sbyte> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXEXPRESINFO()
        {
            this.OnCreated();
        }

        [Column(Storage = "_eibarcode", Name = "EI_BARCODE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIBARCODE
        {
            get
            {
                return this._eibarcode;
            }
            set
            {
                if (((_eibarcode == value)
                            == false))
                {
                    this.OnEIBARCODEChanging(value);
                    this.SendPropertyChanging();
                    this._eibarcode = value;
                    this.SendPropertyChanged("EIBARCODE");
                    this.OnEIBARCODEChanged();
                }
            }
        }

        [Column(Storage = "_eieboxabbr", Name = "EI_EBOXABBR", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIEBOXABBR
        {
            get
            {
                return this._eieboxabbr;
            }
            set
            {
                if (((_eieboxabbr == value)
                            == false))
                {
                    this.OnEIEBOXABBRChanging(value);
                    this.SendPropertyChanging();
                    this._eieboxabbr = value;
                    this.SendPropertyChanged("EIEBOXABBR");
                    this.OnEIEBOXABBRChanged();
                }
            }
        }

        [Column(Storage = "_eieboxid", Name = "EI_EBOXID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EIEBOXID
        {
            get
            {
                return this._eieboxid;
            }
            set
            {
                if ((_eieboxid != value))
                {
                    this.OnEIEBOXIDChanging(value);
                    this.SendPropertyChanging();
                    this._eieboxid = value;
                    this.SendPropertyChanged("EIEBOXID");
                    this.OnEIEBOXIDChanged();
                }
            }
        }

        [Column(Storage = "_eieboxno", Name = "EI_EBOXNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIEBOXNO
        {
            get
            {
                return this._eieboxno;
            }
            set
            {
                if (((_eieboxno == value)
                            == false))
                {
                    this.OnEIEBOXNOChanging(value);
                    this.SendPropertyChanging();
                    this._eieboxno = value;
                    this.SendPropertyChanged("EIEBOXNO");
                    this.OnEIEBOXNOChanged();
                }
            }
        }

        [Column(Storage = "_eiexptype", Name = "EI_EXPTYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> EIEXPTYPE
        {
            get
            {
                return this._eiexptype;
            }
            set
            {
                if ((_eiexptype != value))
                {
                    this.OnEIEXPTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._eiexptype = value;
                    this.SendPropertyChanged("EIEXPTYPE");
                    this.OnEIEXPTYPEChanged();
                }
            }
        }

        [Column(Storage = "_eiid", Name = "EI_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int EIID
        {
            get
            {
                return this._eiid;
            }
            set
            {
                if ((_eiid != value))
                {
                    this.OnEIIDChanging(value);
                    this.SendPropertyChanging();
                    this._eiid = value;
                    this.SendPropertyChanged("EIID");
                    this.OnEIIDChanged();
                }
            }
        }

        [Column(Storage = "_eilatticeno", Name = "EI_LATTICENO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EILATTICENO
        {
            get
            {
                return this._eilatticeno;
            }
            set
            {
                if (((_eilatticeno == value)
                            == false))
                {
                    this.OnEILATTICENOChanging(value);
                    this.SendPropertyChanging();
                    this._eilatticeno = value;
                    this.SendPropertyChanged("EILATTICENO");
                    this.OnEILATTICENOChanged();
                }
            }
        }

        [Column(Storage = "_eilcid", Name = "EI_LCID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EILCID
        {
            get
            {
                return this._eilcid;
            }
            set
            {
                if ((_eilcid != value))
                {
                    this.OnEILCIDChanging(value);
                    this.SendPropertyChanging();
                    this._eilcid = value;
                    this.SendPropertyChanged("EILCID");
                    this.OnEILCIDChanged();
                }
            }
        }

        [Column(Storage = "_eilcname", Name = "EI_LCNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EILCNAME
        {
            get
            {
                return this._eilcname;
            }
            set
            {
                if (((_eilcname == value)
                            == false))
                {
                    this.OnEILCNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eilcname = value;
                    this.SendPropertyChanged("EILCNAME");
                    this.OnEILCNAMEChanged();
                }
            }
        }

        [Column(Storage = "_eimailtype", Name = "EI_MAILTYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> EIMAILTYPE
        {
            get
            {
                return this._eimailtype;
            }
            set
            {
                if ((_eimailtype != value))
                {
                    this.OnEIMAILTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._eimailtype = value;
                    this.SendPropertyChanged("EIMAILTYPE");
                    this.OnEIMAILTYPEChanged();
                }
            }
        }

        [Column(Storage = "_eiorderno", Name = "EI_ORDERNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIORDERNO
        {
            get
            {
                return this._eiorderno;
            }
            set
            {
                if (((_eiorderno == value)
                            == false))
                {
                    this.OnEIORDERNOChanging(value);
                    this.SendPropertyChanging();
                    this._eiorderno = value;
                    this.SendPropertyChanged("EIORDERNO");
                    this.OnEIORDERNOChanged();
                }
            }
        }

        [Column(Storage = "_eipaymentmode", Name = "EI_PAYMENTMODE", DbType = "SMARTINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EIPAYMENTMODE
        {
            get
            {
                return this._eipaymentmode;
            }
            set
            {
                if ((_eipaymentmode != value))
                {
                    this.OnEIPAYMENTMODEChanging(value);
                    this.SendPropertyChanging();
                    this._eipaymentmode = value;
                    this.SendPropertyChanged("EIPAYMENTMODE");
                    this.OnEIPAYMENTMODEChanged();
                }
            }
        }

        [Column(Storage = "_eipaymentmoney", Name = "EI_PAYMENTMONEY", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> EIPAYMENTMONEY
        {
            get
            {
                return this._eipaymentmoney;
            }
            set
            {
                if ((_eipaymentmoney != value))
                {
                    this.OnEIPAYMENTMONEYChanging(value);
                    this.SendPropertyChanging();
                    this._eipaymentmoney = value;
                    this.SendPropertyChanged("EIPAYMENTMONEY");
                    this.OnEIPAYMENTMONEYChanged();
                }
            }
        }

        [Column(Storage = "_eisenderid", Name = "EI_SENDERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EISENDERID
        {
            get
            {
                return this._eisenderid;
            }
            set
            {
                if ((_eisenderid != value))
                {
                    this.OnEISENDERIDChanging(value);
                    this.SendPropertyChanging();
                    this._eisenderid = value;
                    this.SendPropertyChanged("EISENDERID");
                    this.OnEISENDERIDChanged();
                }
            }
        }

        [Column(Storage = "_eisendername", Name = "EI_SENDERNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EISENDERNAME
        {
            get
            {
                return this._eisendername;
            }
            set
            {
                if (((_eisendername == value)
                            == false))
                {
                    this.OnEISENDERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eisendername = value;
                    this.SendPropertyChanged("EISENDERNAME");
                    this.OnEISENDERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_eisenderphone", Name = "EI_SENDERPHONE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EISENDERPHONE
        {
            get
            {
                return this._eisenderphone;
            }
            set
            {
                if (((_eisenderphone == value)
                            == false))
                {
                    this.OnEISENDERPHONEChanging(value);
                    this.SendPropertyChanging();
                    this._eisenderphone = value;
                    this.SendPropertyChanged("EISENDERPHONE");
                    this.OnEISENDERPHONEChanged();
                }
            }
        }

        [Column(Storage = "_eistoretime", Name = "EI_STORETIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> EISTORETIME
        {
            get
            {
                return this._eistoretime;
            }
            set
            {
                if ((_eistoretime != value))
                {
                    this.OnEISTORETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._eistoretime = value;
                    this.SendPropertyChanged("EISTORETIME");
                    this.OnEISTORETIMEChanged();
                }
            }
        }

        [Column(Storage = "_eistoreuserid", Name = "EI_STOREUSERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EISTOREUSERID
        {
            get
            {
                return this._eistoreuserid;
            }
            set
            {
                if ((_eistoreuserid != value))
                {
                    this.OnEISTOREUSERIDChanging(value);
                    this.SendPropertyChanging();
                    this._eistoreuserid = value;
                    this.SendPropertyChanged("EISTOREUSERID");
                    this.OnEISTOREUSERIDChanged();
                }
            }
        }

        [Column(Storage = "_eistoreusername", Name = "EI_STOREUSERNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EISTOREUSERNAME
        {
            get
            {
                return this._eistoreusername;
            }
            set
            {
                if (((_eistoreusername == value)
                            == false))
                {
                    this.OnEISTOREUSERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eistoreusername = value;
                    this.SendPropertyChanged("EISTOREUSERNAME");
                    this.OnEISTOREUSERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_eistoreuserphone", Name = "EI_STOREUSERPHONE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EISTOREUSERPHONE
        {
            get
            {
                return this._eistoreuserphone;
            }
            set
            {
                if (((_eistoreuserphone == value)
                            == false))
                {
                    this.OnEISTOREUSERPHONEChanging(value);
                    this.SendPropertyChanging();
                    this._eistoreuserphone = value;
                    this.SendPropertyChanged("EISTOREUSERPHONE");
                    this.OnEISTOREUSERPHONEChanged();
                }
            }
        }

        [Column(Storage = "_eitakeidcode", Name = "EI_TAKEIDCODE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EITAKEIDCODE
        {
            get
            {
                return this._eitakeidcode;
            }
            set
            {
                if (((_eitakeidcode == value)
                            == false))
                {
                    this.OnEITAKEIDCODEChanging(value);
                    this.SendPropertyChanging();
                    this._eitakeidcode = value;
                    this.SendPropertyChanged("EITAKEIDCODE");
                    this.OnEITAKEIDCODEChanged();
                }
            }
        }

        [Column(Storage = "_eitakeidtype", Name = "EI_TAKEIDTYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> EITAKEIDTYPE
        {
            get
            {
                return this._eitakeidtype;
            }
            set
            {
                if ((_eitakeidtype != value))
                {
                    this.OnEITAKEIDTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._eitakeidtype = value;
                    this.SendPropertyChanged("EITAKEIDTYPE");
                    this.OnEITAKEIDTYPEChanged();
                }
            }
        }

        [Column(Storage = "_eitaketime", Name = "EI_TAKETIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> EITAKETIME
        {
            get
            {
                return this._eitaketime;
            }
            set
            {
                if ((_eitaketime != value))
                {
                    this.OnEITAKETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._eitaketime = value;
                    this.SendPropertyChanged("EITAKETIME");
                    this.OnEITAKETIMEChanged();
                }
            }
        }

        [Column(Storage = "_eitakeuserid", Name = "EI_TAKEUSERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EITAKEUSERID
        {
            get
            {
                return this._eitakeuserid;
            }
            set
            {
                if ((_eitakeuserid != value))
                {
                    this.OnEITAKEUSERIDChanging(value);
                    this.SendPropertyChanging();
                    this._eitakeuserid = value;
                    this.SendPropertyChanged("EITAKEUSERID");
                    this.OnEITAKEUSERIDChanged();
                }
            }
        }

        [Column(Storage = "_eitakeusername", Name = "EI_TAKEUSERNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EITAKEUSERNAME
        {
            get
            {
                return this._eitakeusername;
            }
            set
            {
                if (((_eitakeusername == value)
                            == false))
                {
                    this.OnEITAKEUSERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eitakeusername = value;
                    this.SendPropertyChanged("EITAKEUSERNAME");
                    this.OnEITAKEUSERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_eitakeuserphone", Name = "EI_TAKEUSERPHONE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EITAKEUSERPHONE
        {
            get
            {
                return this._eitakeuserphone;
            }
            set
            {
                if (((_eitakeuserphone == value)
                            == false))
                {
                    this.OnEITAKEUSERPHONEChanging(value);
                    this.SendPropertyChanging();
                    this._eitakeuserphone = value;
                    this.SendPropertyChanged("EITAKEUSERPHONE");
                    this.OnEITAKEUSERPHONEChanged();
                }
            }
        }

        [Column(Storage = "_eivalidatecode", Name = "EI_VALIDATECODE", DbType = "long", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<long> EIVALIDATECODE
        {
            get
            {
                return this._eivalidatecode;
            }
            set
            {
                if ((_eivalidatecode != value))
                {
                    this.OnEIVALIDATECODEChanging(value);
                    this.SendPropertyChanging();
                    this._eivalidatecode = value;
                    this.SendPropertyChanged("EIVALIDATECODE");
                    this.OnEIVALIDATECODEChanged();
                }
            }
        }

        [Column(Storage = "_elexpremark", Name = "EL_EXPREMARK", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ELEXPREMARK
        {
            get
            {
                return this._elexpremark;
            }
            set
            {
                if (((_elexpremark == value)
                            == false))
                {
                    this.OnELEXPREMARKChanging(value);
                    this.SendPropertyChanging();
                    this._elexpremark = value;
                    this.SendPropertyChanged("ELEXPREMARK");
                    this.OnELEXPREMARKChanged();
                }
            }
        }

        [Column(Storage = "_elexpsavemode", Name = "EL_EXPSAVEMODE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> ELEXPSAVEMODE
        {
            get
            {
                return this._elexpsavemode;
            }
            set
            {
                if ((_elexpsavemode != value))
                {
                    this.OnELEXPSAVEMODEChanging(value);
                    this.SendPropertyChanging();
                    this._elexpsavemode = value;
                    this.SendPropertyChanged("ELEXPSAVEMODE");
                    this.OnELEXPSAVEMODEChanged();
                }
            }
        }

        [Column(Storage = "_ellcmainid", Name = "EL_LCMAINID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> ELLCMAINID
        {
            get
            {
                return this._ellcmainid;
            }
            set
            {
                if ((_ellcmainid != value))
                {
                    this.OnELLCMAINIDChanging(value);
                    this.SendPropertyChanging();
                    this._ellcmainid = value;
                    this.SendPropertyChanged("ELLCMAINID");
                    this.OnELLCMAINIDChanged();
                }
            }
        }

        [Column(Storage = "_elovertime", Name = "EL_OVERTIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> ELOVERTIME
        {
            get
            {
                return this._elovertime;
            }
            set
            {
                if ((_elovertime != value))
                {
                    this.OnELOVERTIMEChanging(value);
                    this.SendPropertyChanging();
                    this._elovertime = value;
                    this.SendPropertyChanged("ELOVERTIME");
                    this.OnELOVERTIMEChanged();
                }
            }
        }

        [Column(Storage = "_elstoreusertype", Name = "EL_STOREUSERTYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> ELSTOREUSERTYPE
        {
            get
            {
                return this._elstoreusertype;
            }
            set
            {
                if ((_elstoreusertype != value))
                {
                    this.OnELSTOREUSERTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._elstoreusertype = value;
                    this.SendPropertyChanged("ELSTOREUSERTYPE");
                    this.OnELSTOREUSERTYPEChanged();
                }
            }
        }

        [Column(Storage = "_eltakeusertype", Name = "EL_TAKEUSERTYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> ELTAKEUSERTYPE
        {
            get
            {
                return this._eltakeusertype;
            }
            set
            {
                if ((_eltakeusertype != value))
                {
                    this.OnELTAKEUSERTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._eltakeusertype = value;
                    this.SendPropertyChanged("ELTAKEUSERTYPE");
                    this.OnELTAKEUSERTYPEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
	

    [Table(Name = "main.EBOX_EXPRESSEXCEPTION")]
    public partial class EBOXEXPRESSEXCEPTION : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _eobarcode;

        private System.Nullable<int> _eoeiid;

        private System.Nullable<sbyte> _eoexptype;

        private int _eoid;

        private System.Nullable<int> _eolcid;

        private string _eoorderno;

        private System.Nullable<int> _eoovertimecnt;

        private System.Nullable<int> _eoovertimeday;

        private System.Nullable<double> _eoovertimefee;

        private System.Nullable<double> _eoovertimeprice;

        private string _eoremark;

        private System.Nullable<long> _eovalidatecode;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnEOBARCODEChanged();

        partial void OnEOBARCODEChanging(string value);

        partial void OnEOEIIDChanged();

        partial void OnEOEIIDChanging(System.Nullable<int> value);

        partial void OnEOEXPTYPEChanged();

        partial void OnEOEXPTYPEChanging(System.Nullable<sbyte> value);

        partial void OnEOIDChanged();

        partial void OnEOIDChanging(int value);

        partial void OnEOLCIDChanged();

        partial void OnEOLCIDChanging(System.Nullable<int> value);

        partial void OnEOORDERNOChanged();

        partial void OnEOORDERNOChanging(string value);

        partial void OnEOOVERTIMECNTChanged();

        partial void OnEOOVERTIMECNTChanging(System.Nullable<int> value);

        partial void OnEOOVERTIMEDAYChanged();

        partial void OnEOOVERTIMEDAYChanging(System.Nullable<int> value);

        partial void OnEOOVERTIMEFEEChanged();

        partial void OnEOOVERTIMEFEEChanging(System.Nullable<double> value);

        partial void OnEOOVERTIMEPRICEChanged();

        partial void OnEOOVERTIMEPRICEChanging(System.Nullable<double> value);

        partial void OnEOREMARKChanged();

        partial void OnEOREMARKChanging(string value);

        partial void OnEOVALIDATECODEChanged();

        partial void OnEOVALIDATECODEChanging(System.Nullable<long> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXEXPRESSEXCEPTION()
        {
            this.OnCreated();
        }

        [Column(Storage = "_eobarcode", Name = "EO_BARCODE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EOBARCODE
        {
            get
            {
                return this._eobarcode;
            }
            set
            {
                if (((_eobarcode == value)
                            == false))
                {
                    this.OnEOBARCODEChanging(value);
                    this.SendPropertyChanging();
                    this._eobarcode = value;
                    this.SendPropertyChanged("EOBARCODE");
                    this.OnEOBARCODEChanged();
                }
            }
        }

        [Column(Storage = "_eoeiid", Name = "EO_EIID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EOEIID
        {
            get
            {
                return this._eoeiid;
            }
            set
            {
                if ((_eoeiid != value))
                {
                    this.OnEOEIIDChanging(value);
                    this.SendPropertyChanging();
                    this._eoeiid = value;
                    this.SendPropertyChanged("EOEIID");
                    this.OnEOEIIDChanged();
                }
            }
        }

        [Column(Storage = "_eoexptype", Name = "EO_EXPTYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> EOEXPTYPE
        {
            get
            {
                return this._eoexptype;
            }
            set
            {
                if ((_eoexptype != value))
                {
                    this.OnEOEXPTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._eoexptype = value;
                    this.SendPropertyChanged("EOEXPTYPE");
                    this.OnEOEXPTYPEChanged();
                }
            }
        }

        [Column(Storage = "_eoid", Name = "EO_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int EOID
        {
            get
            {
                return this._eoid;
            }
            set
            {
                if ((_eoid != value))
                {
                    this.OnEOIDChanging(value);
                    this.SendPropertyChanging();
                    this._eoid = value;
                    this.SendPropertyChanged("EOID");
                    this.OnEOIDChanged();
                }
            }
        }

        [Column(Storage = "_eolcid", Name = "EO_LCID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EOLCID
        {
            get
            {
                return this._eolcid;
            }
            set
            {
                if ((_eolcid != value))
                {
                    this.OnEOLCIDChanging(value);
                    this.SendPropertyChanging();
                    this._eolcid = value;
                    this.SendPropertyChanged("EOLCID");
                    this.OnEOLCIDChanged();
                }
            }
        }

        [Column(Storage = "_eoorderno", Name = "EO_ORDERNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EOORDERNO
        {
            get
            {
                return this._eoorderno;
            }
            set
            {
                if (((_eoorderno == value)
                            == false))
                {
                    this.OnEOORDERNOChanging(value);
                    this.SendPropertyChanging();
                    this._eoorderno = value;
                    this.SendPropertyChanged("EOORDERNO");
                    this.OnEOORDERNOChanged();
                }
            }
        }

        [Column(Storage = "_eoovertimecnt", Name = "EO_OVERTIMECNT", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EOOVERTIMECNT
        {
            get
            {
                return this._eoovertimecnt;
            }
            set
            {
                if ((_eoovertimecnt != value))
                {
                    this.OnEOOVERTIMECNTChanging(value);
                    this.SendPropertyChanging();
                    this._eoovertimecnt = value;
                    this.SendPropertyChanged("EOOVERTIMECNT");
                    this.OnEOOVERTIMECNTChanged();
                }
            }
        }

        [Column(Storage = "_eoovertimeday", Name = "EO_OVERTIMEDAY", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EOOVERTIMEDAY
        {
            get
            {
                return this._eoovertimeday;
            }
            set
            {
                if ((_eoovertimeday != value))
                {
                    this.OnEOOVERTIMEDAYChanging(value);
                    this.SendPropertyChanging();
                    this._eoovertimeday = value;
                    this.SendPropertyChanged("EOOVERTIMEDAY");
                    this.OnEOOVERTIMEDAYChanged();
                }
            }
        }

        [Column(Storage = "_eoovertimefee", Name = "EO_OVERTIMEFEE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> EOOVERTIMEFEE
        {
            get
            {
                return this._eoovertimefee;
            }
            set
            {
                if ((_eoovertimefee != value))
                {
                    this.OnEOOVERTIMEFEEChanging(value);
                    this.SendPropertyChanging();
                    this._eoovertimefee = value;
                    this.SendPropertyChanged("EOOVERTIMEFEE");
                    this.OnEOOVERTIMEFEEChanged();
                }
            }
        }

        [Column(Storage = "_eoovertimeprice", Name = "EO_OVERTIMEPRICE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> EOOVERTIMEPRICE
        {
            get
            {
                return this._eoovertimeprice;
            }
            set
            {
                if ((_eoovertimeprice != value))
                {
                    this.OnEOOVERTIMEPRICEChanging(value);
                    this.SendPropertyChanging();
                    this._eoovertimeprice = value;
                    this.SendPropertyChanged("EOOVERTIMEPRICE");
                    this.OnEOOVERTIMEPRICEChanged();
                }
            }
        }

        [Column(Storage = "_eoremark", Name = "EO_REMARK", DbType = "VARCHAR(500)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EOREMARK
        {
            get
            {
                return this._eoremark;
            }
            set
            {
                if (((_eoremark == value)
                            == false))
                {
                    this.OnEOREMARKChanging(value);
                    this.SendPropertyChanging();
                    this._eoremark = value;
                    this.SendPropertyChanged("EOREMARK");
                    this.OnEOREMARKChanged();
                }
            }
        }

        [Column(Storage = "_eovalidatecode", Name = "EO_VALIDATECODE", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<long> EOVALIDATECODE
        {
            get
            {
                return this._eovalidatecode;
            }
            set
            {
                if ((_eovalidatecode != value))
                {
                    this.OnEOVALIDATECODEChanging(value);
                    this.SendPropertyChanging();
                    this._eovalidatecode = value;
                    this.SendPropertyChanged("EOVALIDATECODE");
                    this.OnEOVALIDATECODEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_EXPRESSUBINFO")]
    public partial class EBOXEXPRESSUBINFO : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _eiaddress;

        private string _eicityname;

        private string _eiconame;

        private System.Nullable<int> _eidiscountvalue;

        private System.Nullable<int> _eieboxsettleruleid;

        private string _eiexpbarcode;

        private string _eiexpname;

        private System.Nullable<sbyte> _eiexpunit;

        private System.Nullable<float> _eiexpweight;

        private System.Nullable<double> _eifactalprice;

        private System.Nullable<sbyte> _eifeeruleflag;

        private int _eiid;

        private System.Nullable<double> _eilatticeprice;

        private System.Nullable<int> _eilcid;

        private string _eilcname;

        private System.Nullable<int> _eilcsettleruleid;

        private string _eionecode;

        private System.Nullable<int> _eiopid;

        private string _eiopname;

        private string _eiorderno;

        private string _eiproname;

        private string _eirecepname;

        private string _eirecepphone;

        private System.Nullable<double> _eistandprice;

        private System.Nullable<double> _eitotalfee;

        private string _eitwocode;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnEIADDRESSChanged();

        partial void OnEIADDRESSChanging(string value);

        partial void OnEICITYNAMEChanged();

        partial void OnEICITYNAMEChanging(string value);

        partial void OnEICONAMEChanged();

        partial void OnEICONAMEChanging(string value);

        partial void OnEIDISCOUNTVALUEChanged();

        partial void OnEIDISCOUNTVALUEChanging(System.Nullable<int> value);

        partial void OnEIEBOXSETTLERULEIDChanged();

        partial void OnEIEBOXSETTLERULEIDChanging(System.Nullable<int> value);

        partial void OnEIEXPBARCODEChanged();

        partial void OnEIEXPBARCODEChanging(string value);

        partial void OnEIEXPNAMEChanged();

        partial void OnEIEXPNAMEChanging(string value);

        partial void OnEIEXPUNITChanged();

        partial void OnEIEXPUNITChanging(System.Nullable<sbyte> value);

        partial void OnEIEXPWEIGHTChanged();

        partial void OnEIEXPWEIGHTChanging(System.Nullable<float> value);

        partial void OnEIFACTALPRICEChanged();

        partial void OnEIFACTALPRICEChanging(System.Nullable<double> value);

        partial void OnEIFEERULEFLAGChanged();

        partial void OnEIFEERULEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnEIIDChanged();

        partial void OnEIIDChanging(int value);

        partial void OnEILATTICEPRICEChanged();

        partial void OnEILATTICEPRICEChanging(System.Nullable<double> value);

        partial void OnEILCIDChanged();

        partial void OnEILCIDChanging(System.Nullable<int> value);

        partial void OnEILCNAMEChanged();

        partial void OnEILCNAMEChanging(string value);

        partial void OnEILCSETTLERULEIDChanged();

        partial void OnEILCSETTLERULEIDChanging(System.Nullable<int> value);

        partial void OnEIONECODEChanged();

        partial void OnEIONECODEChanging(string value);

        partial void OnEIOPIDChanged();

        partial void OnEIOPIDChanging(System.Nullable<int> value);

        partial void OnEIOPNAMEChanged();

        partial void OnEIOPNAMEChanging(string value);

        partial void OnEIORDERNOChanged();

        partial void OnEIORDERNOChanging(string value);

        partial void OnEIPRONAMEChanged();

        partial void OnEIPRONAMEChanging(string value);

        partial void OnEIRECEPNAMEChanged();

        partial void OnEIRECEPNAMEChanging(string value);

        partial void OnEIRECEPPHONEChanged();

        partial void OnEIRECEPPHONEChanging(string value);

        partial void OnEISTANDPRICEChanged();

        partial void OnEISTANDPRICEChanging(System.Nullable<double> value);

        partial void OnEITOTALFEEChanged();

        partial void OnEITOTALFEEChanging(System.Nullable<double> value);

        partial void OnEITWOCODEChanged();

        partial void OnEITWOCODEChanging(string value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXEXPRESSUBINFO()
        {
            this.OnCreated();
        }

        [Column(Storage = "_eiaddress", Name = "EI_ADDRESS", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIADDRESS
        {
            get
            {
                return this._eiaddress;
            }
            set
            {
                if (((_eiaddress == value)
                            == false))
                {
                    this.OnEIADDRESSChanging(value);
                    this.SendPropertyChanging();
                    this._eiaddress = value;
                    this.SendPropertyChanged("EIADDRESS");
                    this.OnEIADDRESSChanged();
                }
            }
        }

        [Column(Storage = "_eicityname", Name = "EI_CITYNAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EICITYNAME
        {
            get
            {
                return this._eicityname;
            }
            set
            {
                if (((_eicityname == value)
                            == false))
                {
                    this.OnEICITYNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eicityname = value;
                    this.SendPropertyChanged("EICITYNAME");
                    this.OnEICITYNAMEChanged();
                }
            }
        }

        [Column(Storage = "_eiconame", Name = "EI_CONAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EICONAME
        {
            get
            {
                return this._eiconame;
            }
            set
            {
                if (((_eiconame == value)
                            == false))
                {
                    this.OnEICONAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eiconame = value;
                    this.SendPropertyChanged("EICONAME");
                    this.OnEICONAMEChanged();
                }
            }
        }

        [Column(Storage = "_eidiscountvalue", Name = "EI_DISCOUNTVALUE", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EIDISCOUNTVALUE
        {
            get
            {
                return this._eidiscountvalue;
            }
            set
            {
                if ((_eidiscountvalue != value))
                {
                    this.OnEIDISCOUNTVALUEChanging(value);
                    this.SendPropertyChanging();
                    this._eidiscountvalue = value;
                    this.SendPropertyChanged("EIDISCOUNTVALUE");
                    this.OnEIDISCOUNTVALUEChanged();
                }
            }
        }

        [Column(Storage = "_eieboxsettleruleid", Name = "EI_EBOXSETTLERULEID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EIEBOXSETTLERULEID
        {
            get
            {
                return this._eieboxsettleruleid;
            }
            set
            {
                if ((_eieboxsettleruleid != value))
                {
                    this.OnEIEBOXSETTLERULEIDChanging(value);
                    this.SendPropertyChanging();
                    this._eieboxsettleruleid = value;
                    this.SendPropertyChanged("EIEBOXSETTLERULEID");
                    this.OnEIEBOXSETTLERULEIDChanged();
                }
            }
        }

        [Column(Storage = "_eiexpbarcode", Name = "EI_EXPBARCODE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIEXPBARCODE
        {
            get
            {
                return this._eiexpbarcode;
            }
            set
            {
                if (((_eiexpbarcode == value)
                            == false))
                {
                    this.OnEIEXPBARCODEChanging(value);
                    this.SendPropertyChanging();
                    this._eiexpbarcode = value;
                    this.SendPropertyChanged("EIEXPBARCODE");
                    this.OnEIEXPBARCODEChanged();
                }
            }
        }

        [Column(Storage = "_eiexpname", Name = "EI_EXPNAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIEXPNAME
        {
            get
            {
                return this._eiexpname;
            }
            set
            {
                if (((_eiexpname == value)
                            == false))
                {
                    this.OnEIEXPNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eiexpname = value;
                    this.SendPropertyChanged("EIEXPNAME");
                    this.OnEIEXPNAMEChanged();
                }
            }
        }

        [Column(Storage = "_eiexpunit", Name = "EI_EXPUNIT", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> EIEXPUNIT
        {
            get
            {
                return this._eiexpunit;
            }
            set
            {
                if ((_eiexpunit != value))
                {
                    this.OnEIEXPUNITChanging(value);
                    this.SendPropertyChanging();
                    this._eiexpunit = value;
                    this.SendPropertyChanged("EIEXPUNIT");
                    this.OnEIEXPUNITChanged();
                }
            }
        }

        [Column(Storage = "_eiexpweight", Name = "EI_EXPWEIGHT", DbType = "FLOAT(5)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<float> EIEXPWEIGHT
        {
            get
            {
                return this._eiexpweight;
            }
            set
            {
                if ((_eiexpweight != value))
                {
                    this.OnEIEXPWEIGHTChanging(value);
                    this.SendPropertyChanging();
                    this._eiexpweight = value;
                    this.SendPropertyChanged("EIEXPWEIGHT");
                    this.OnEIEXPWEIGHTChanged();
                }
            }
        }

        [Column(Storage = "_eifactalprice", Name = "EI_FACTALPRICE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> EIFACTALPRICE
        {
            get
            {
                return this._eifactalprice;
            }
            set
            {
                if ((_eifactalprice != value))
                {
                    this.OnEIFACTALPRICEChanging(value);
                    this.SendPropertyChanging();
                    this._eifactalprice = value;
                    this.SendPropertyChanged("EIFACTALPRICE");
                    this.OnEIFACTALPRICEChanged();
                }
            }
        }

        [Column(Storage = "_eifeeruleflag", Name = "EI_FEERULEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> EIFEERULEFLAG
        {
            get
            {
                return this._eifeeruleflag;
            }
            set
            {
                if ((_eifeeruleflag != value))
                {
                    this.OnEIFEERULEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._eifeeruleflag = value;
                    this.SendPropertyChanged("EIFEERULEFLAG");
                    this.OnEIFEERULEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_eiid", Name = "EI_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int EIID
        {
            get
            {
                return this._eiid;
            }
            set
            {
                if ((_eiid != value))
                {
                    this.OnEIIDChanging(value);
                    this.SendPropertyChanging();
                    this._eiid = value;
                    this.SendPropertyChanged("EIID");
                    this.OnEIIDChanged();
                }
            }
        }

        [Column(Storage = "_eilatticeprice", Name = "EI_LATTICEPRICE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> EILATTICEPRICE
        {
            get
            {
                return this._eilatticeprice;
            }
            set
            {
                if ((_eilatticeprice != value))
                {
                    this.OnEILATTICEPRICEChanging(value);
                    this.SendPropertyChanging();
                    this._eilatticeprice = value;
                    this.SendPropertyChanged("EILATTICEPRICE");
                    this.OnEILATTICEPRICEChanged();
                }
            }
        }

        [Column(Storage = "_eilcid", Name = "EI_LCID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EILCID
        {
            get
            {
                return this._eilcid;
            }
            set
            {
                if ((_eilcid != value))
                {
                    this.OnEILCIDChanging(value);
                    this.SendPropertyChanging();
                    this._eilcid = value;
                    this.SendPropertyChanged("EILCID");
                    this.OnEILCIDChanged();
                }
            }
        }

        [Column(Storage = "_eilcname", Name = "EI_LCNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EILCNAME
        {
            get
            {
                return this._eilcname;
            }
            set
            {
                if (((_eilcname == value)
                            == false))
                {
                    this.OnEILCNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eilcname = value;
                    this.SendPropertyChanged("EILCNAME");
                    this.OnEILCNAMEChanged();
                }
            }
        }

        [Column(Storage = "_eilcsettleruleid", Name = "EI_LCSETTLERULEID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EILCSETTLERULEID
        {
            get
            {
                return this._eilcsettleruleid;
            }
            set
            {
                if ((_eilcsettleruleid != value))
                {
                    this.OnEILCSETTLERULEIDChanging(value);
                    this.SendPropertyChanging();
                    this._eilcsettleruleid = value;
                    this.SendPropertyChanged("EILCSETTLERULEID");
                    this.OnEILCSETTLERULEIDChanged();
                }
            }
        }

        [Column(Storage = "_eionecode", Name = "EI_ONECODE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIONECODE
        {
            get
            {
                return this._eionecode;
            }
            set
            {
                if (((_eionecode == value)
                            == false))
                {
                    this.OnEIONECODEChanging(value);
                    this.SendPropertyChanging();
                    this._eionecode = value;
                    this.SendPropertyChanged("EIONECODE");
                    this.OnEIONECODEChanged();
                }
            }
        }

        [Column(Storage = "_eiopid", Name = "EI_OPID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> EIOPID
        {
            get
            {
                return this._eiopid;
            }
            set
            {
                if ((_eiopid != value))
                {
                    this.OnEIOPIDChanging(value);
                    this.SendPropertyChanging();
                    this._eiopid = value;
                    this.SendPropertyChanged("EIOPID");
                    this.OnEIOPIDChanged();
                }
            }
        }

        [Column(Storage = "_eiopname", Name = "EI_OPNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIOPNAME
        {
            get
            {
                return this._eiopname;
            }
            set
            {
                if (((_eiopname == value)
                            == false))
                {
                    this.OnEIOPNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eiopname = value;
                    this.SendPropertyChanged("EIOPNAME");
                    this.OnEIOPNAMEChanged();
                }
            }
        }

        [Column(Storage = "_eiorderno", Name = "EI_ORDERNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIORDERNO
        {
            get
            {
                return this._eiorderno;
            }
            set
            {
                if (((_eiorderno == value)
                            == false))
                {
                    this.OnEIORDERNOChanging(value);
                    this.SendPropertyChanging();
                    this._eiorderno = value;
                    this.SendPropertyChanged("EIORDERNO");
                    this.OnEIORDERNOChanged();
                }
            }
        }

        [Column(Storage = "_eiproname", Name = "EI_PRONAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIPRONAME
        {
            get
            {
                return this._eiproname;
            }
            set
            {
                if (((_eiproname == value)
                            == false))
                {
                    this.OnEIPRONAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eiproname = value;
                    this.SendPropertyChanged("EIPRONAME");
                    this.OnEIPRONAMEChanged();
                }
            }
        }

        [Column(Storage = "_eirecepname", Name = "EI_RECEPNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIRECEPNAME
        {
            get
            {
                return this._eirecepname;
            }
            set
            {
                if (((_eirecepname == value)
                            == false))
                {
                    this.OnEIRECEPNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._eirecepname = value;
                    this.SendPropertyChanged("EIRECEPNAME");
                    this.OnEIRECEPNAMEChanged();
                }
            }
        }

        [Column(Storage = "_eirecepphone", Name = "EI_RECEPPHONE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EIRECEPPHONE
        {
            get
            {
                return this._eirecepphone;
            }
            set
            {
                if (((_eirecepphone == value)
                            == false))
                {
                    this.OnEIRECEPPHONEChanging(value);
                    this.SendPropertyChanging();
                    this._eirecepphone = value;
                    this.SendPropertyChanged("EIRECEPPHONE");
                    this.OnEIRECEPPHONEChanged();
                }
            }
        }

        [Column(Storage = "_eistandprice", Name = "EI_STANDPRICE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> EISTANDPRICE
        {
            get
            {
                return this._eistandprice;
            }
            set
            {
                if ((_eistandprice != value))
                {
                    this.OnEISTANDPRICEChanging(value);
                    this.SendPropertyChanging();
                    this._eistandprice = value;
                    this.SendPropertyChanged("EISTANDPRICE");
                    this.OnEISTANDPRICEChanged();
                }
            }
        }

        [Column(Storage = "_eitotalfee", Name = "EI_TOTALFEE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> EITOTALFEE
        {
            get
            {
                return this._eitotalfee;
            }
            set
            {
                if ((_eitotalfee != value))
                {
                    this.OnEITOTALFEEChanging(value);
                    this.SendPropertyChanging();
                    this._eitotalfee = value;
                    this.SendPropertyChanged("EITOTALFEE");
                    this.OnEITOTALFEEChanged();
                }
            }
        }

        [Column(Storage = "_eitwocode", Name = "EI_TWOCODE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string EITWOCODE
        {
            get
            {
                return this._eitwocode;
            }
            set
            {
                if (((_eitwocode == value)
                            == false))
                {
                    this.OnEITWOCODEChanging(value);
                    this.SendPropertyChanging();
                    this._eitwocode = value;
                    this.SendPropertyChanged("EITWOCODE");
                    this.OnEITWOCODEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_HANDWARE_CONFIG")]
    public partial class EBOXHANDWARECONFIG : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<int> _hchandid;

        private string _hchandname;

        private string _hchandno;

        private int _hcid;

        private string _hcocno;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnHCHANDIDChanged();

        partial void OnHCHANDIDChanging(System.Nullable<int> value);

        partial void OnHCHANDNAMEChanged();

        partial void OnHCHANDNAMEChanging(string value);

        partial void OnHCHANDNOChanged();

        partial void OnHCHANDNOChanging(string value);

        partial void OnHCIDChanged();

        partial void OnHCIDChanging(int value);

        partial void OnHCOCNOChanged();

        partial void OnHCOCNOChanging(string value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXHANDWARECONFIG()
        {
            this.OnCreated();
        }

        [Column(Storage = "_hchandid", Name = "HC_HANDID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> HCHANDID
        {
            get
            {
                return this._hchandid;
            }
            set
            {
                if ((_hchandid != value))
                {
                    this.OnHCHANDIDChanging(value);
                    this.SendPropertyChanging();
                    this._hchandid = value;
                    this.SendPropertyChanged("HCHANDID");
                    this.OnHCHANDIDChanged();
                }
            }
        }

        [Column(Storage = "_hchandname", Name = "HC_HANDNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HCHANDNAME
        {
            get
            {
                return this._hchandname;
            }
            set
            {
                if (((_hchandname == value)
                            == false))
                {
                    this.OnHCHANDNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._hchandname = value;
                    this.SendPropertyChanged("HCHANDNAME");
                    this.OnHCHANDNAMEChanged();
                }
            }
        }

        [Column(Storage = "_hchandno", Name = "HC_HANDNO", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HCHANDNO
        {
            get
            {
                return this._hchandno;
            }
            set
            {
                if (((_hchandno == value)
                            == false))
                {
                    this.OnHCHANDNOChanging(value);
                    this.SendPropertyChanging();
                    this._hchandno = value;
                    this.SendPropertyChanged("HCHANDNO");
                    this.OnHCHANDNOChanged();
                }
            }
        }

        [Column(Storage = "_hcid", Name = "HC_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int HCID
        {
            get
            {
                return this._hcid;
            }
            set
            {
                if ((_hcid != value))
                {
                    this.OnHCIDChanging(value);
                    this.SendPropertyChanging();
                    this._hcid = value;
                    this.SendPropertyChanged("HCID");
                    this.OnHCIDChanged();
                }
            }
        }

        [Column(Storage = "_hcocno", Name = "HC_OCNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HCOCNO
        {
            get
            {
                return this._hcocno;
            }
            set
            {
                if (((_hcocno == value)
                            == false))
                {
                    this.OnHCOCNOChanging(value);
                    this.SendPropertyChanging();
                    this._hcocno = value;
                    this.SendPropertyChanged("HCOCNO");
                    this.OnHCOCNOChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_HANDWAREINFO")]
    public partial class EBOXHANDWAREINFO : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _hiid;

        private string _hiinstructions;

        private string _himodel;

        private string _hiname;

        private string _hino;

        private System.Nullable<double> _hiprice;

        private System.Nullable<sbyte> _hitype;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnHIIDChanged();

        partial void OnHIIDChanging(int value);

        partial void OnHIINSTRUCTIONSChanged();

        partial void OnHIINSTRUCTIONSChanging(string value);

        partial void OnHIMODELChanged();

        partial void OnHIMODELChanging(string value);

        partial void OnHINAMEChanged();

        partial void OnHINAMEChanging(string value);

        partial void OnHINOChanged();

        partial void OnHINOChanging(string value);

        partial void OnHIPRICEChanged();

        partial void OnHIPRICEChanging(System.Nullable<double> value);

        partial void OnHITYPEChanged();

        partial void OnHITYPEChanging(System.Nullable<sbyte> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXHANDWAREINFO()
        {
            this.OnCreated();
        }

        [Column(Storage = "_hiid", Name = "HI_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int HIID
        {
            get
            {
                return this._hiid;
            }
            set
            {
                if ((_hiid != value))
                {
                    this.OnHIIDChanging(value);
                    this.SendPropertyChanging();
                    this._hiid = value;
                    this.SendPropertyChanged("HIID");
                    this.OnHIIDChanged();
                }
            }
        }

        [Column(Storage = "_hiinstructions", Name = "HI_INSTRUCTIONS", DbType = "VARCHAR(500)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HIINSTRUCTIONS
        {
            get
            {
                return this._hiinstructions;
            }
            set
            {
                if (((_hiinstructions == value)
                            == false))
                {
                    this.OnHIINSTRUCTIONSChanging(value);
                    this.SendPropertyChanging();
                    this._hiinstructions = value;
                    this.SendPropertyChanged("HIINSTRUCTIONS");
                    this.OnHIINSTRUCTIONSChanged();
                }
            }
        }

        [Column(Storage = "_himodel", Name = "HI_MODEL", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HIMODEL
        {
            get
            {
                return this._himodel;
            }
            set
            {
                if (((_himodel == value)
                            == false))
                {
                    this.OnHIMODELChanging(value);
                    this.SendPropertyChanging();
                    this._himodel = value;
                    this.SendPropertyChanged("HIMODEL");
                    this.OnHIMODELChanged();
                }
            }
        }

        [Column(Storage = "_hiname", Name = "HI_NAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HINAME
        {
            get
            {
                return this._hiname;
            }
            set
            {
                if (((_hiname == value)
                            == false))
                {
                    this.OnHINAMEChanging(value);
                    this.SendPropertyChanging();
                    this._hiname = value;
                    this.SendPropertyChanged("HINAME");
                    this.OnHINAMEChanged();
                }
            }
        }

        [Column(Storage = "_hino", Name = "HI_NO", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HINO
        {
            get
            {
                return this._hino;
            }
            set
            {
                if (((_hino == value)
                            == false))
                {
                    this.OnHINOChanging(value);
                    this.SendPropertyChanging();
                    this._hino = value;
                    this.SendPropertyChanged("HINO");
                    this.OnHINOChanged();
                }
            }
        }

        [Column(Storage = "_hiprice", Name = "HI_PRICE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> HIPRICE
        {
            get
            {
                return this._hiprice;
            }
            set
            {
                if ((_hiprice != value))
                {
                    this.OnHIPRICEChanging(value);
                    this.SendPropertyChanging();
                    this._hiprice = value;
                    this.SendPropertyChanged("HIPRICE");
                    this.OnHIPRICEChanged();
                }
            }
        }

        [Column(Storage = "_hitype", Name = "HI_TYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> HITYPE
        {
            get
            {
                return this._hitype;
            }
            set
            {
                if ((_hitype != value))
                {
                    this.OnHITYPEChanging(value);
                    this.SendPropertyChanging();
                    this._hitype = value;
                    this.SendPropertyChanged("HITYPE");
                    this.OnHITYPEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_HANDWARERECORD")]
    public partial class EBOXHANDWARERECORD : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<int> _hiid;

        private int _hrid;

        private string _hrinstructions;

        private string _hrmodel;

        private string _hrname;

        private System.Nullable<sbyte> _hrnode;

        private System.Nullable<int> _hroperationsgroup;

        private System.Nullable<System.DateTime> _hroperatortime;

        private string _hroperatortype;

        private System.Nullable<sbyte> _hrresults;

        private System.Nullable<sbyte> _hrsequence;

        private System.Nullable<int> _pbid;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnHIIDChanged();

        partial void OnHIIDChanging(System.Nullable<int> value);

        partial void OnHRIDChanged();

        partial void OnHRIDChanging(int value);

        partial void OnHRINSTRUCTIONSChanged();

        partial void OnHRINSTRUCTIONSChanging(string value);

        partial void OnHRMODELChanged();

        partial void OnHRMODELChanging(string value);

        partial void OnHRNAMEChanged();

        partial void OnHRNAMEChanging(string value);

        partial void OnHRNODEChanged();

        partial void OnHRNODEChanging(System.Nullable<sbyte> value);

        partial void OnHROPERATIONSGROUPChanged();

        partial void OnHROPERATIONSGROUPChanging(System.Nullable<int> value);

        partial void OnHROPERATORTIMEChanged();

        partial void OnHROPERATORTIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnHROPERATORTYPEChanged();

        partial void OnHROPERATORTYPEChanging(string value);

        partial void OnHRRESULTSChanged();

        partial void OnHRRESULTSChanging(System.Nullable<sbyte> value);

        partial void OnHRSEQUENCEChanged();

        partial void OnHRSEQUENCEChanging(System.Nullable<sbyte> value);

        partial void OnPBIDChanged();

        partial void OnPBIDChanging(System.Nullable<int> value);
        #endregion


        public EBOXHANDWARERECORD()
        {
            this.OnCreated();
        }

        [Column(Storage = "_hiid", Name = "HI_ID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> HIID
        {
            get
            {
                return this._hiid;
            }
            set
            {
                if ((_hiid != value))
                {
                    this.OnHIIDChanging(value);
                    this.SendPropertyChanging();
                    this._hiid = value;
                    this.SendPropertyChanged("HIID");
                    this.OnHIIDChanged();
                }
            }
        }

        [Column(Storage = "_hrid", Name = "HR_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int HRID
        {
            get
            {
                return this._hrid;
            }
            set
            {
                if ((_hrid != value))
                {
                    this.OnHRIDChanging(value);
                    this.SendPropertyChanging();
                    this._hrid = value;
                    this.SendPropertyChanged("HRID");
                    this.OnHRIDChanged();
                }
            }
        }

        [Column(Storage = "_hrinstructions", Name = "HR_INSTRUCTIONS", DbType = "VARCHAR(500)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HRINSTRUCTIONS
        {
            get
            {
                return this._hrinstructions;
            }
            set
            {
                if (((_hrinstructions == value)
                            == false))
                {
                    this.OnHRINSTRUCTIONSChanging(value);
                    this.SendPropertyChanging();
                    this._hrinstructions = value;
                    this.SendPropertyChanged("HRINSTRUCTIONS");
                    this.OnHRINSTRUCTIONSChanged();
                }
            }
        }

        [Column(Storage = "_hrmodel", Name = "HR_MODEL", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HRMODEL
        {
            get
            {
                return this._hrmodel;
            }
            set
            {
                if (((_hrmodel == value)
                            == false))
                {
                    this.OnHRMODELChanging(value);
                    this.SendPropertyChanging();
                    this._hrmodel = value;
                    this.SendPropertyChanged("HRMODEL");
                    this.OnHRMODELChanged();
                }
            }
        }

        [Column(Storage = "_hrname", Name = "HR_NAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HRNAME
        {
            get
            {
                return this._hrname;
            }
            set
            {
                if (((_hrname == value)
                            == false))
                {
                    this.OnHRNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._hrname = value;
                    this.SendPropertyChanged("HRNAME");
                    this.OnHRNAMEChanged();
                }
            }
        }

        [Column(Storage = "_hrnode", Name = "HR_NODE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> HRNODE
        {
            get
            {
                return this._hrnode;
            }
            set
            {
                if ((_hrnode != value))
                {
                    this.OnHRNODEChanging(value);
                    this.SendPropertyChanging();
                    this._hrnode = value;
                    this.SendPropertyChanged("HRNODE");
                    this.OnHRNODEChanged();
                }
            }
        }

        [Column(Storage = "_hroperationsgroup", Name = "HR_OPERATIONSGROUP", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> HROPERATIONSGROUP
        {
            get
            {
                return this._hroperationsgroup;
            }
            set
            {
                if ((_hroperationsgroup != value))
                {
                    this.OnHROPERATIONSGROUPChanging(value);
                    this.SendPropertyChanging();
                    this._hroperationsgroup = value;
                    this.SendPropertyChanged("HROPERATIONSGROUP");
                    this.OnHROPERATIONSGROUPChanged();
                }
            }
        }

        [Column(Storage = "_hroperatortime", Name = "HR_OPERATORTIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> HROPERATORTIME
        {
            get
            {
                return this._hroperatortime;
            }
            set
            {
                if ((_hroperatortime != value))
                {
                    this.OnHROPERATORTIMEChanging(value);
                    this.SendPropertyChanging();
                    this._hroperatortime = value;
                    this.SendPropertyChanged("HROPERATORTIME");
                    this.OnHROPERATORTIMEChanged();
                }
            }
        }

        [Column(Storage = "_hroperatortype", Name = "HR_OPERATORTYPE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HROPERATORTYPE
        {
            get
            {
                return this._hroperatortype;
            }
            set
            {
                if (((_hroperatortype == value)
                            == false))
                {
                    this.OnHROPERATORTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._hroperatortype = value;
                    this.SendPropertyChanged("HROPERATORTYPE");
                    this.OnHROPERATORTYPEChanged();
                }
            }
        }

        [Column(Storage = "_hrresults", Name = "HR_RESULTS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> HRRESULTS
        {
            get
            {
                return this._hrresults;
            }
            set
            {
                if ((_hrresults != value))
                {
                    this.OnHRRESULTSChanging(value);
                    this.SendPropertyChanging();
                    this._hrresults = value;
                    this.SendPropertyChanged("HRRESULTS");
                    this.OnHRRESULTSChanged();
                }
            }
        }

        [Column(Storage = "_hrsequence", Name = "HR_SEQUENCE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> HRSEQUENCE
        {
            get
            {
                return this._hrsequence;
            }
            set
            {
                if ((_hrsequence != value))
                {
                    this.OnHRSEQUENCEChanging(value);
                    this.SendPropertyChanging();
                    this._hrsequence = value;
                    this.SendPropertyChanged("HRSEQUENCE");
                    this.OnHRSEQUENCEChanged();
                }
            }
        }

        [Column(Storage = "_pbid", Name = "PB_ID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBID
        {
            get
            {
                return this._pbid;
            }
            set
            {
                if ((_pbid != value))
                {
                    this.OnPBIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbid = value;
                    this.SendPropertyChanged("PBID");
                    this.OnPBIDChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_HANDWAREVALIDATE")]
    public partial class EBOXHANDWAREVALIDATE : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<System.DateTime> _hwcreatedate;

        private int _hwid;

        private string _hwmessage;

        private string _hwname;

        private System.Nullable<sbyte> _hwstatus;

        private string _hwtype;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnHWCREATEDATEChanged();

        partial void OnHWCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnHWIDChanged();

        partial void OnHWIDChanging(int value);

        partial void OnHWMESSAGEChanged();

        partial void OnHWMESSAGEChanging(string value);

        partial void OnHWNAMEChanged();

        partial void OnHWNAMEChanging(string value);

        partial void OnHWSTATUSChanged();

        partial void OnHWSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnHWTYPEChanged();

        partial void OnHWTYPEChanging(string value);
        #endregion


        public EBOXHANDWAREVALIDATE()
        {
            this.OnCreated();
        }

        [Column(Storage = "_hwcreatedate", Name = "HW_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> HWCREATEDATE
        {
            get
            {
                return this._hwcreatedate;
            }
            set
            {
                if ((_hwcreatedate != value))
                {
                    this.OnHWCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._hwcreatedate = value;
                    this.SendPropertyChanged("HWCREATEDATE");
                    this.OnHWCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_hwid", Name = "HW_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int HWID
        {
            get
            {
                return this._hwid;
            }
            set
            {
                if ((_hwid != value))
                {
                    this.OnHWIDChanging(value);
                    this.SendPropertyChanging();
                    this._hwid = value;
                    this.SendPropertyChanged("HWID");
                    this.OnHWIDChanged();
                }
            }
        }

        [Column(Storage = "_hwmessage", Name = "HW_MESSAGE", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HWMESSAGE
        {
            get
            {
                return this._hwmessage;
            }
            set
            {
                if (((_hwmessage == value)
                            == false))
                {
                    this.OnHWMESSAGEChanging(value);
                    this.SendPropertyChanging();
                    this._hwmessage = value;
                    this.SendPropertyChanged("HWMESSAGE");
                    this.OnHWMESSAGEChanged();
                }
            }
        }

        [Column(Storage = "_hwname", Name = "HW_NAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HWNAME
        {
            get
            {
                return this._hwname;
            }
            set
            {
                if (((_hwname == value)
                            == false))
                {
                    this.OnHWNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._hwname = value;
                    this.SendPropertyChanged("HWNAME");
                    this.OnHWNAMEChanged();
                }
            }
        }

        [Column(Storage = "_hwstatus", Name = "HW_STATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> HWSTATUS
        {
            get
            {
                return this._hwstatus;
            }
            set
            {
                if ((_hwstatus != value))
                {
                    this.OnHWSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._hwstatus = value;
                    this.SendPropertyChanged("HWSTATUS");
                    this.OnHWSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_hwtype", Name = "HW_TYPE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string HWTYPE
        {
            get
            {
                return this._hwtype;
            }
            set
            {
                if (((_hwtype == value)
                            == false))
                {
                    this.OnHWTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._hwtype = value;
                    this.SendPropertyChanged("HWTYPE");
                    this.OnHWTYPEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_LOGISTICSCOMPANY_CONFIG")]
    public partial class EBOXLOGISTICSCOMPANYCONFIG : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<int> _lcbpoxid;

        private int _lcid;

        private System.Nullable<int> _lclcid;

        private System.Nullable<int> _lclcmainid;

        private string _lclcmainname;

        private string _lclcname;

        private System.Nullable<int> _lcopid;

        private string _lcopname;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnLCBPOXIDChanged();

        partial void OnLCBPOXIDChanging(System.Nullable<int> value);

        partial void OnLCIDChanged();

        partial void OnLCIDChanging(int value);

        partial void OnLCLCIDChanged();

        partial void OnLCLCIDChanging(System.Nullable<int> value);

        partial void OnLCLCMAINIDChanged();

        partial void OnLCLCMAINIDChanging(System.Nullable<int> value);

        partial void OnLCLCMAINNAMEChanged();

        partial void OnLCLCMAINNAMEChanging(string value);

        partial void OnLCLCNAMEChanged();

        partial void OnLCLCNAMEChanging(string value);

        partial void OnLCOPIDChanged();

        partial void OnLCOPIDChanging(System.Nullable<int> value);

        partial void OnLCOPNAMEChanged();

        partial void OnLCOPNAMEChanging(string value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXLOGISTICSCOMPANYCONFIG()
        {
            this.OnCreated();
        }

        [Column(Storage = "_lcbpoxid", Name = "LC_BPOXID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> LCBPOXID
        {
            get
            {
                return this._lcbpoxid;
            }
            set
            {
                if ((_lcbpoxid != value))
                {
                    this.OnLCBPOXIDChanging(value);
                    this.SendPropertyChanging();
                    this._lcbpoxid = value;
                    this.SendPropertyChanged("LCBPOXID");
                    this.OnLCBPOXIDChanged();
                }
            }
        }

        [Column(Storage = "_lcid", Name = "LC_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int LCID
        {
            get
            {
                return this._lcid;
            }
            set
            {
                if ((_lcid != value))
                {
                    this.OnLCIDChanging(value);
                    this.SendPropertyChanging();
                    this._lcid = value;
                    this.SendPropertyChanged("LCID");
                    this.OnLCIDChanged();
                }
            }
        }

        [Column(Storage = "_lclcid", Name = "LC_LCID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> LCLCID
        {
            get
            {
                return this._lclcid;
            }
            set
            {
                if ((_lclcid != value))
                {
                    this.OnLCLCIDChanging(value);
                    this.SendPropertyChanging();
                    this._lclcid = value;
                    this.SendPropertyChanged("LCLCID");
                    this.OnLCLCIDChanged();
                }
            }
        }

        [Column(Storage = "_lclcmainid", Name = "LC_LCMAINID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> LCLCMAINID
        {
            get
            {
                return this._lclcmainid;
            }
            set
            {
                if ((_lclcmainid != value))
                {
                    this.OnLCLCMAINIDChanging(value);
                    this.SendPropertyChanging();
                    this._lclcmainid = value;
                    this.SendPropertyChanged("LCLCMAINID");
                    this.OnLCLCMAINIDChanged();
                }
            }
        }

        [Column(Storage = "_lclcmainname", Name = "LC_LCMAINNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string LCLCMAINNAME
        {
            get
            {
                return this._lclcmainname;
            }
            set
            {
                if (((_lclcmainname == value)
                            == false))
                {
                    this.OnLCLCMAINNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._lclcmainname = value;
                    this.SendPropertyChanged("LCLCMAINNAME");
                    this.OnLCLCMAINNAMEChanged();
                }
            }
        }

        [Column(Storage = "_lclcname", Name = "LC_LCNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string LCLCNAME
        {
            get
            {
                return this._lclcname;
            }
            set
            {
                if (((_lclcname == value)
                            == false))
                {
                    this.OnLCLCNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._lclcname = value;
                    this.SendPropertyChanged("LCLCNAME");
                    this.OnLCLCNAMEChanged();
                }
            }
        }

        [Column(Storage = "_lcopid", Name = "LC_OPID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> LCOPID
        {
            get
            {
                return this._lcopid;
            }
            set
            {
                if ((_lcopid != value))
                {
                    this.OnLCOPIDChanging(value);
                    this.SendPropertyChanging();
                    this._lcopid = value;
                    this.SendPropertyChanged("LCOPID");
                    this.OnLCOPIDChanged();
                }
            }
        }

        [Column(Storage = "_lcopname", Name = "LC_OPNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string LCOPNAME
        {
            get
            {
                return this._lcopname;
            }
            set
            {
                if (((_lcopname == value)
                            == false))
                {
                    this.OnLCOPNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._lcopname = value;
                    this.SendPropertyChanged("LCOPNAME");
                    this.OnLCOPNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_MOUTH")]
    public partial class EBOXMOUTH : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _mocolor;

        private System.Nullable<sbyte> _modefine;

        private System.Nullable<int> _modefineid;

        private string _modefinename;

        private System.Nullable<int> _mohigh;

        private int _moid;

        private string _moinstructions;

        private System.Nullable<int> _molength;

        private string _momodel;

        private System.Nullable<double> _moprice;

        private System.Nullable<sbyte> _moscale;

        private System.Nullable<int> _mospace;

        private string _mospacedesc;

        private System.Nullable<sbyte> _mounit;

        private System.Nullable<int> _mowidth;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnMOCOLORChanged();

        partial void OnMOCOLORChanging(string value);

        partial void OnMODEFINEChanged();

        partial void OnMODEFINEChanging(System.Nullable<sbyte> value);

        partial void OnMODEFINEIDChanged();

        partial void OnMODEFINEIDChanging(System.Nullable<int> value);

        partial void OnMODEFINENAMEChanged();

        partial void OnMODEFINENAMEChanging(string value);

        partial void OnMOHIGHChanged();

        partial void OnMOHIGHChanging(System.Nullable<int> value);

        partial void OnMOIDChanged();

        partial void OnMOIDChanging(int value);

        partial void OnMOINSTRUCTIONSChanged();

        partial void OnMOINSTRUCTIONSChanging(string value);

        partial void OnMOLENGTHChanged();

        partial void OnMOLENGTHChanging(System.Nullable<int> value);

        partial void OnMOMODELChanged();

        partial void OnMOMODELChanging(string value);

        partial void OnMOPRICEChanged();

        partial void OnMOPRICEChanging(System.Nullable<double> value);

        partial void OnMOSCALEChanged();

        partial void OnMOSCALEChanging(System.Nullable<sbyte> value);

        partial void OnMOSPACEChanged();

        partial void OnMOSPACEChanging(System.Nullable<int> value);

        partial void OnMOSPACEDESCChanged();

        partial void OnMOSPACEDESCChanging(string value);

        partial void OnMOUNITChanged();

        partial void OnMOUNITChanging(System.Nullable<sbyte> value);

        partial void OnMOWIDTHChanged();

        partial void OnMOWIDTHChanging(System.Nullable<int> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXMOUTH()
        {
            this.OnCreated();
        }

        [Column(Storage = "_mocolor", Name = "MO_COLOR", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOCOLOR
        {
            get
            {
                return this._mocolor;
            }
            set
            {
                if (((_mocolor == value)
                            == false))
                {
                    this.OnMOCOLORChanging(value);
                    this.SendPropertyChanging();
                    this._mocolor = value;
                    this.SendPropertyChanged("MOCOLOR");
                    this.OnMOCOLORChanged();
                }
            }
        }

        [Column(Storage = "_modefine", Name = "MO_DEFINE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> MODEFINE
        {
            get
            {
                return this._modefine;
            }
            set
            {
                if ((_modefine != value))
                {
                    this.OnMODEFINEChanging(value);
                    this.SendPropertyChanging();
                    this._modefine = value;
                    this.SendPropertyChanged("MODEFINE");
                    this.OnMODEFINEChanged();
                }
            }
        }

        [Column(Storage = "_modefineid", Name = "MO_DEFINEID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> MODEFINEID
        {
            get
            {
                return this._modefineid;
            }
            set
            {
                if ((_modefineid != value))
                {
                    this.OnMODEFINEIDChanging(value);
                    this.SendPropertyChanging();
                    this._modefineid = value;
                    this.SendPropertyChanged("MODEFINEID");
                    this.OnMODEFINEIDChanged();
                }
            }
        }

        [Column(Storage = "_modefinename", Name = "MO_DEFINENAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MODEFINENAME
        {
            get
            {
                return this._modefinename;
            }
            set
            {
                if (((_modefinename == value)
                            == false))
                {
                    this.OnMODEFINENAMEChanging(value);
                    this.SendPropertyChanging();
                    this._modefinename = value;
                    this.SendPropertyChanged("MODEFINENAME");
                    this.OnMODEFINENAMEChanged();
                }
            }
        }

        [Column(Storage = "_mohigh", Name = "MO_HIGH", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> MOHIGH
        {
            get
            {
                return this._mohigh;
            }
            set
            {
                if ((_mohigh != value))
                {
                    this.OnMOHIGHChanging(value);
                    this.SendPropertyChanging();
                    this._mohigh = value;
                    this.SendPropertyChanged("MOHIGH");
                    this.OnMOHIGHChanged();
                }
            }
        }

        [Column(Storage = "_moid", Name = "MO_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int MOID
        {
            get
            {
                return this._moid;
            }
            set
            {
                if ((_moid != value))
                {
                    this.OnMOIDChanging(value);
                    this.SendPropertyChanging();
                    this._moid = value;
                    this.SendPropertyChanged("MOID");
                    this.OnMOIDChanged();
                }
            }
        }

        [Column(Storage = "_moinstructions", Name = "MO_INSTRUCTIONS", DbType = "VARCHAR(500)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOINSTRUCTIONS
        {
            get
            {
                return this._moinstructions;
            }
            set
            {
                if (((_moinstructions == value)
                            == false))
                {
                    this.OnMOINSTRUCTIONSChanging(value);
                    this.SendPropertyChanging();
                    this._moinstructions = value;
                    this.SendPropertyChanged("MOINSTRUCTIONS");
                    this.OnMOINSTRUCTIONSChanged();
                }
            }
        }

        [Column(Storage = "_molength", Name = "MO_LENGTH", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> MOLENGTH
        {
            get
            {
                return this._molength;
            }
            set
            {
                if ((_molength != value))
                {
                    this.OnMOLENGTHChanging(value);
                    this.SendPropertyChanging();
                    this._molength = value;
                    this.SendPropertyChanged("MOLENGTH");
                    this.OnMOLENGTHChanged();
                }
            }
        }

        [Column(Storage = "_momodel", Name = "MO_MODEL", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOMODEL
        {
            get
            {
                return this._momodel;
            }
            set
            {
                if (((_momodel == value)
                            == false))
                {
                    this.OnMOMODELChanging(value);
                    this.SendPropertyChanging();
                    this._momodel = value;
                    this.SendPropertyChanged("MOMODEL");
                    this.OnMOMODELChanged();
                }
            }
        }

        [Column(Storage = "_moprice", Name = "MO_PRICE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> MOPRICE
        {
            get
            {
                return this._moprice;
            }
            set
            {
                if ((_moprice != value))
                {
                    this.OnMOPRICEChanging(value);
                    this.SendPropertyChanging();
                    this._moprice = value;
                    this.SendPropertyChanged("MOPRICE");
                    this.OnMOPRICEChanged();
                }
            }
        }

        [Column(Storage = "_moscale", Name = "MO_SCALE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> MOSCALE
        {
            get
            {
                return this._moscale;
            }
            set
            {
                if ((_moscale != value))
                {
                    this.OnMOSCALEChanging(value);
                    this.SendPropertyChanging();
                    this._moscale = value;
                    this.SendPropertyChanged("MOSCALE");
                    this.OnMOSCALEChanged();
                }
            }
        }

        [Column(Storage = "_mospace", Name = "MO_SPACE", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> MOSPACE
        {
            get
            {
                return this._mospace;
            }
            set
            {
                if ((_mospace != value))
                {
                    this.OnMOSPACEChanging(value);
                    this.SendPropertyChanging();
                    this._mospace = value;
                    this.SendPropertyChanged("MOSPACE");
                    this.OnMOSPACEChanged();
                }
            }
        }

        [Column(Storage = "_mospacedesc", Name = "MO_SPACEDESC", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOSPACEDESC
        {
            get
            {
                return this._mospacedesc;
            }
            set
            {
                if (((_mospacedesc == value)
                            == false))
                {
                    this.OnMOSPACEDESCChanging(value);
                    this.SendPropertyChanging();
                    this._mospacedesc = value;
                    this.SendPropertyChanged("MOSPACEDESC");
                    this.OnMOSPACEDESCChanged();
                }
            }
        }

        [Column(Storage = "_mounit", Name = "MO_UNIT", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> MOUNIT
        {
            get
            {
                return this._mounit;
            }
            set
            {
                if ((_mounit != value))
                {
                    this.OnMOUNITChanging(value);
                    this.SendPropertyChanging();
                    this._mounit = value;
                    this.SendPropertyChanged("MOUNIT");
                    this.OnMOUNITChanged();
                }
            }
        }

        [Column(Storage = "_mowidth", Name = "MO_WIDTH", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> MOWIDTH
        {
            get
            {
                return this._mowidth;
            }
            set
            {
                if ((_mowidth != value))
                {
                    this.OnMOWIDTHChanging(value);
                    this.SendPropertyChanging();
                    this._mowidth = value;
                    this.SendPropertyChanged("MOWIDTH");
                    this.OnMOWIDTHChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_MOUTH_ARK")]
    public partial class EBOXMOUTHARK : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _id;

        private System.Nullable<int> _mocsaid;

        private string _mocsano;

        private string _mofullno;

        private string _molockno;

        private string _mono;

        private System.Nullable<int> _mopbid;

        private string _mopbno;

        private string _moscale;

        private string _mosize;

        private System.Nullable<double> _mostandfee;

        private System.Nullable<int> _motypeid;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;


        private System.Nullable<sbyte> _tfbuzstatus;


        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;


        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnMOCSAIDChanged();

        partial void OnMOCSAIDChanging(System.Nullable<int> value);

        partial void OnMOCSANOChanged();

        partial void OnMOCSANOChanging(string value);

        partial void OnMOFULLNOChanged();

        partial void OnMOFULLNOChanging(string value);

        partial void OnMOLOCKNOChanged();

        partial void OnMOLOCKNOChanging(string value);

        partial void OnMONOChanged();

        partial void OnMONOChanging(string value);

        partial void OnMOPBIDChanged();

        partial void OnMOPBIDChanging(System.Nullable<int> value);

        partial void OnMOPBNOChanged();

        partial void OnMOPBNOChanging(string value);

        partial void OnMOSCALEChanged();

        partial void OnMOSCALEChanging(string value);

        partial void OnMOSIZEChanged();

        partial void OnMOSIZEChanging(string value);

        partial void OnMOSTANDFEEChanged();

        partial void OnMOSTANDFEEChanging(System.Nullable<double> value);

        partial void OnMOTYPEIDChanged();

        partial void OnMOTYPEIDChanging(System.Nullable<int> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXMOUTHARK()
        {
            this.OnCreated();
        }

        [Column(Storage = "_id", Name = "ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_mocsaid", Name = "MO_CSAID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> MOCSAID
        {
            get
            {
                return this._mocsaid;
            }
            set
            {
                if ((_mocsaid != value))
                {
                    this.OnMOCSAIDChanging(value);
                    this.SendPropertyChanging();
                    this._mocsaid = value;
                    this.SendPropertyChanged("MOCSAID");
                    this.OnMOCSAIDChanged();
                }
            }
        }

        [Column(Storage = "_mocsano", Name = "MO_CSANO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOCSANO
        {
            get
            {
                return this._mocsano;
            }
            set
            {
                if (((_mocsano == value)
                            == false))
                {
                    this.OnMOCSANOChanging(value);
                    this.SendPropertyChanging();
                    this._mocsano = value;
                    this.SendPropertyChanged("MOCSANO");
                    this.OnMOCSANOChanged();
                }
            }
        }

        [Column(Storage = "_mofullno", Name = "MO_FULLNO", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOFULLNO
        {
            get
            {
                return this._mofullno;
            }
            set
            {
                if (((_mofullno == value)
                            == false))
                {
                    this.OnMOFULLNOChanging(value);
                    this.SendPropertyChanging();
                    this._mofullno = value;
                    this.SendPropertyChanged("MOFULLNO");
                    this.OnMOFULLNOChanged();
                }
            }
        }

        [Column(Storage = "_molockno", Name = "MO_LOCKNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOLOCKNO
        {
            get
            {
                return this._molockno;
            }
            set
            {
                if (((_molockno == value)
                            == false))
                {
                    this.OnMOLOCKNOChanging(value);
                    this.SendPropertyChanging();
                    this._molockno = value;
                    this.SendPropertyChanged("MOLOCKNO");
                    this.OnMOLOCKNOChanged();
                }
            }
        }

        [Column(Storage = "_mono", Name = "MO_NO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MONO
        {
            get
            {
                return this._mono;
            }
            set
            {
                if (((_mono == value)
                            == false))
                {
                    this.OnMONOChanging(value);
                    this.SendPropertyChanging();
                    this._mono = value;
                    this.SendPropertyChanged("MONO");
                    this.OnMONOChanged();
                }
            }
        }

        [Column(Storage = "_mopbid", Name = "MO_PBID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> MOPBID
        {
            get
            {
                return this._mopbid;
            }
            set
            {
                if ((_mopbid != value))
                {
                    this.OnMOPBIDChanging(value);
                    this.SendPropertyChanging();
                    this._mopbid = value;
                    this.SendPropertyChanged("MOPBID");
                    this.OnMOPBIDChanged();
                }
            }
        }

        [Column(Storage = "_mopbno", Name = "MO_PBNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOPBNO
        {
            get
            {
                return this._mopbno;
            }
            set
            {
                if (((_mopbno == value)
                            == false))
                {
                    this.OnMOPBNOChanging(value);
                    this.SendPropertyChanging();
                    this._mopbno = value;
                    this.SendPropertyChanged("MOPBNO");
                    this.OnMOPBNOChanged();
                }
            }
        }

        [Column(Storage = "_moscale", Name = "MO_SCALE", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOSCALE
        {
            get
            {
                return this._moscale;
            }
            set
            {
                if (((_moscale == value)
                            == false))
                {
                    this.OnMOSCALEChanging(value);
                    this.SendPropertyChanging();
                    this._moscale = value;
                    this.SendPropertyChanged("MOSCALE");
                    this.OnMOSCALEChanged();
                }
            }
        }

        [Column(Storage = "_mosize", Name = "MO_SIZE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MOSIZE
        {
            get
            {
                return this._mosize;
            }
            set
            {
                if (((_mosize == value)
                            == false))
                {
                    this.OnMOSIZEChanging(value);
                    this.SendPropertyChanging();
                    this._mosize = value;
                    this.SendPropertyChanged("MOSIZE");
                    this.OnMOSIZEChanged();
                }
            }
        }

        [Column(Storage = "_mostandfee", Name = "MO_STANDFEE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> MOSTANDFEE
        {
            get
            {
                return this._mostandfee;
            }
            set
            {
                if ((_mostandfee != value))
                {
                    this.OnMOSTANDFEEChanging(value);
                    this.SendPropertyChanging();
                    this._mostandfee = value;
                    this.SendPropertyChanged("MOSTANDFEE");
                    this.OnMOSTANDFEEChanged();
                }
            }
        }

        [Column(Storage = "_motypeid", Name = "MO_TYPEID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> MOTYPEID
        {
            get
            {
                return this._motypeid;
            }
            set
            {
                if ((_motypeid != value))
                {
                    this.OnMOTYPEIDChanging(value);
                    this.SendPropertyChanging();
                    this._motypeid = value;
                    this.SendPropertyChanged("MOTYPEID");
                    this.OnMOTYPEIDChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

       

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

       

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }


        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
	

    [Table(Name = "main.EBOX_ONTROLCABINET")]
    public partial class EBOXONTROLCABINET : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<sbyte> _ocdefine;

        private System.Nullable<int> _ocdefineid;

        private string _ocdefinename;

        private System.Nullable<double> _ocfloorarea;

        private int _ocid;

        private string _ocinstructions;

        private string _ocmodel;

        private string _ocno;

        private System.Nullable<double> _ocprice;

        private string _ocsize;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private string _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private string _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnOCDEFINEChanged();

        partial void OnOCDEFINEChanging(System.Nullable<sbyte> value);

        partial void OnOCDEFINEIDChanged();

        partial void OnOCDEFINEIDChanging(System.Nullable<int> value);

        partial void OnOCDEFINENAMEChanged();

        partial void OnOCDEFINENAMEChanging(string value);

        partial void OnOCFLOORAREAChanged();

        partial void OnOCFLOORAREAChanging(System.Nullable<double> value);

        partial void OnOCIDChanged();

        partial void OnOCIDChanging(int value);

        partial void OnOCINSTRUCTIONSChanged();

        partial void OnOCINSTRUCTIONSChanging(string value);

        partial void OnOCMODELChanged();

        partial void OnOCMODELChanging(string value);

        partial void OnOCNOChanged();

        partial void OnOCNOChanging(string value);

        partial void OnOCPRICEChanged();

        partial void OnOCPRICEChanging(System.Nullable<double> value);

        partial void OnOCSIZEChanged();

        partial void OnOCSIZEChanging(string value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(string value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(string value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXONTROLCABINET()
        {
            this.OnCreated();
        }

        [Column(Storage = "_ocdefine", Name = "OC_DEFINE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> OCDEFINE
        {
            get
            {
                return this._ocdefine;
            }
            set
            {
                if ((_ocdefine != value))
                {
                    this.OnOCDEFINEChanging(value);
                    this.SendPropertyChanging();
                    this._ocdefine = value;
                    this.SendPropertyChanged("OCDEFINE");
                    this.OnOCDEFINEChanged();
                }
            }
        }

        [Column(Storage = "_ocdefineid", Name = "OC_DEFINEID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> OCDEFINEID
        {
            get
            {
                return this._ocdefineid;
            }
            set
            {
                if ((_ocdefineid != value))
                {
                    this.OnOCDEFINEIDChanging(value);
                    this.SendPropertyChanging();
                    this._ocdefineid = value;
                    this.SendPropertyChanged("OCDEFINEID");
                    this.OnOCDEFINEIDChanged();
                }
            }
        }

        [Column(Storage = "_ocdefinename", Name = "OC_DEFINENAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OCDEFINENAME
        {
            get
            {
                return this._ocdefinename;
            }
            set
            {
                if (((_ocdefinename == value)
                            == false))
                {
                    this.OnOCDEFINENAMEChanging(value);
                    this.SendPropertyChanging();
                    this._ocdefinename = value;
                    this.SendPropertyChanged("OCDEFINENAME");
                    this.OnOCDEFINENAMEChanged();
                }
            }
        }

        [Column(Storage = "_ocfloorarea", Name = "OC_FLOORAREA", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> OCFLOORAREA
        {
            get
            {
                return this._ocfloorarea;
            }
            set
            {
                if ((_ocfloorarea != value))
                {
                    this.OnOCFLOORAREAChanging(value);
                    this.SendPropertyChanging();
                    this._ocfloorarea = value;
                    this.SendPropertyChanged("OCFLOORAREA");
                    this.OnOCFLOORAREAChanged();
                }
            }
        }

        [Column(Storage = "_ocid", Name = "OC_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int OCID
        {
            get
            {
                return this._ocid;
            }
            set
            {
                if ((_ocid != value))
                {
                    this.OnOCIDChanging(value);
                    this.SendPropertyChanging();
                    this._ocid = value;
                    this.SendPropertyChanged("OCID");
                    this.OnOCIDChanged();
                }
            }
        }

        [Column(Storage = "_ocinstructions", Name = "OC_INSTRUCTIONS", DbType = "VARCHAR(500)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OCINSTRUCTIONS
        {
            get
            {
                return this._ocinstructions;
            }
            set
            {
                if (((_ocinstructions == value)
                            == false))
                {
                    this.OnOCINSTRUCTIONSChanging(value);
                    this.SendPropertyChanging();
                    this._ocinstructions = value;
                    this.SendPropertyChanged("OCINSTRUCTIONS");
                    this.OnOCINSTRUCTIONSChanged();
                }
            }
        }

        [Column(Storage = "_ocmodel", Name = "OC_MODEL", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OCMODEL
        {
            get
            {
                return this._ocmodel;
            }
            set
            {
                if (((_ocmodel == value)
                            == false))
                {
                    this.OnOCMODELChanging(value);
                    this.SendPropertyChanging();
                    this._ocmodel = value;
                    this.SendPropertyChanged("OCMODEL");
                    this.OnOCMODELChanged();
                }
            }
        }

        [Column(Storage = "_ocno", Name = "OC_NO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OCNO
        {
            get
            {
                return this._ocno;
            }
            set
            {
                if (((_ocno == value)
                            == false))
                {
                    this.OnOCNOChanging(value);
                    this.SendPropertyChanging();
                    this._ocno = value;
                    this.SendPropertyChanged("OCNO");
                    this.OnOCNOChanged();
                }
            }
        }

        [Column(Storage = "_ocprice", Name = "OC_PRICE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> OCPRICE
        {
            get
            {
                return this._ocprice;
            }
            set
            {
                if ((_ocprice != value))
                {
                    this.OnOCPRICEChanging(value);
                    this.SendPropertyChanging();
                    this._ocprice = value;
                    this.SendPropertyChanged("OCPRICE");
                    this.OnOCPRICEChanged();
                }
            }
        }

        [Column(Storage = "_ocsize", Name = "OC_SIZE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OCSIZE
        {
            get
            {
                return this._ocsize;
            }
            set
            {
                if (((_ocsize == value)
                            == false))
                {
                    this.OnOCSIZEChanging(value);
                    this.SendPropertyChanging();
                    this._ocsize = value;
                    this.SendPropertyChanged("OCSIZE");
                    this.OnOCSIZEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "CHAR(2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if (((_tfbuzstatus == value)
                            == false))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "CHAR(2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if (((_tfdeleteflag == value)
                            == false))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_OPERATORS")]
    public partial class EBOXOPERATORS : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _opaddress;

        private string _opcityname;

        private string _opcityno;

        private string _opconame;

        private string _opconidcode;

        private System.Nullable<sbyte> _opconidtype;

        private string _opcono;

        private string _opconphone;

        private string _opcontacts;

        private string _opdesc;

        private int _opid;

        private System.Nullable<sbyte> _oplevel;

        private string _oplicense;

        private string _opmanager;

        private string _opmanidcode;

        private System.Nullable<sbyte> _opmanidtype;

        private string _opmanphone;

        private string _opname;

        private string _opno;

        private string _oporgcode;

        private System.Nullable<int> _opparentid;

        private string _opparentname;

        private string _opproname;

        private string _opprono;

        private string _optel;

        private string _opwebsite;

        private string _opzone;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnOPADDRESSChanged();

        partial void OnOPADDRESSChanging(string value);

        partial void OnOPCITYNAMEChanged();

        partial void OnOPCITYNAMEChanging(string value);

        partial void OnOPCITYNOChanged();

        partial void OnOPCITYNOChanging(string value);

        partial void OnOPCONAMEChanged();

        partial void OnOPCONAMEChanging(string value);

        partial void OnOPCONIDCODEChanged();

        partial void OnOPCONIDCODEChanging(string value);

        partial void OnOPCONIDTYPEChanged();

        partial void OnOPCONIDTYPEChanging(System.Nullable<sbyte> value);

        partial void OnOPCONOChanged();

        partial void OnOPCONOChanging(string value);

        partial void OnOPCONPHONEChanged();

        partial void OnOPCONPHONEChanging(string value);

        partial void OnOPCONTACTSChanged();

        partial void OnOPCONTACTSChanging(string value);

        partial void OnOPDESCChanged();

        partial void OnOPDESCChanging(string value);

        partial void OnOPIDChanged();

        partial void OnOPIDChanging(int value);

        partial void OnOPLEVELChanged();

        partial void OnOPLEVELChanging(System.Nullable<sbyte> value);

        partial void OnOPLICENSEChanged();

        partial void OnOPLICENSEChanging(string value);

        partial void OnOPMANAGERChanged();

        partial void OnOPMANAGERChanging(string value);

        partial void OnOPMANIDCODEChanged();

        partial void OnOPMANIDCODEChanging(string value);

        partial void OnOPMANIDTYPEChanged();

        partial void OnOPMANIDTYPEChanging(System.Nullable<sbyte> value);

        partial void OnOPMANPHONEChanged();

        partial void OnOPMANPHONEChanging(string value);

        partial void OnOPNAMEChanged();

        partial void OnOPNAMEChanging(string value);

        partial void OnOPNOChanged();

        partial void OnOPNOChanging(string value);

        partial void OnOPORGCODEChanged();

        partial void OnOPORGCODEChanging(string value);

        partial void OnOPPARENTIDChanged();

        partial void OnOPPARENTIDChanging(System.Nullable<int> value);

        partial void OnOPPARENTNAMEChanged();

        partial void OnOPPARENTNAMEChanging(string value);

        partial void OnOPPRONAMEChanged();

        partial void OnOPPRONAMEChanging(string value);

        partial void OnOPPRONOChanged();

        partial void OnOPPRONOChanging(string value);

        partial void OnOPTELChanged();

        partial void OnOPTELChanging(string value);

        partial void OnOPWEBSITEChanged();

        partial void OnOPWEBSITEChanging(string value);

        partial void OnOPZONEChanged();

        partial void OnOPZONEChanging(string value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXOPERATORS()
        {
            this.OnCreated();
        }

        [Column(Storage = "_opaddress", Name = "OP_ADDRESS", DbType = "VARCHAR(1000)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPADDRESS
        {
            get
            {
                return this._opaddress;
            }
            set
            {
                if (((_opaddress == value)
                            == false))
                {
                    this.OnOPADDRESSChanging(value);
                    this.SendPropertyChanging();
                    this._opaddress = value;
                    this.SendPropertyChanged("OPADDRESS");
                    this.OnOPADDRESSChanged();
                }
            }
        }

        [Column(Storage = "_opcityname", Name = "OP_CITYNAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPCITYNAME
        {
            get
            {
                return this._opcityname;
            }
            set
            {
                if (((_opcityname == value)
                            == false))
                {
                    this.OnOPCITYNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._opcityname = value;
                    this.SendPropertyChanged("OPCITYNAME");
                    this.OnOPCITYNAMEChanged();
                }
            }
        }

        [Column(Storage = "_opcityno", Name = "OP_CITYNO", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPCITYNO
        {
            get
            {
                return this._opcityno;
            }
            set
            {
                if (((_opcityno == value)
                            == false))
                {
                    this.OnOPCITYNOChanging(value);
                    this.SendPropertyChanging();
                    this._opcityno = value;
                    this.SendPropertyChanged("OPCITYNO");
                    this.OnOPCITYNOChanged();
                }
            }
        }

        [Column(Storage = "_opconame", Name = "OP_CONAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPCONAME
        {
            get
            {
                return this._opconame;
            }
            set
            {
                if (((_opconame == value)
                            == false))
                {
                    this.OnOPCONAMEChanging(value);
                    this.SendPropertyChanging();
                    this._opconame = value;
                    this.SendPropertyChanged("OPCONAME");
                    this.OnOPCONAMEChanged();
                }
            }
        }

        [Column(Storage = "_opconidcode", Name = "OP_CONIDCODE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPCONIDCODE
        {
            get
            {
                return this._opconidcode;
            }
            set
            {
                if (((_opconidcode == value)
                            == false))
                {
                    this.OnOPCONIDCODEChanging(value);
                    this.SendPropertyChanging();
                    this._opconidcode = value;
                    this.SendPropertyChanged("OPCONIDCODE");
                    this.OnOPCONIDCODEChanged();
                }
            }
        }

        [Column(Storage = "_opconidtype", Name = "OP_CONIDTYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> OPCONIDTYPE
        {
            get
            {
                return this._opconidtype;
            }
            set
            {
                if ((_opconidtype != value))
                {
                    this.OnOPCONIDTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._opconidtype = value;
                    this.SendPropertyChanged("OPCONIDTYPE");
                    this.OnOPCONIDTYPEChanged();
                }
            }
        }

        [Column(Storage = "_opcono", Name = "OP_CONO", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPCONO
        {
            get
            {
                return this._opcono;
            }
            set
            {
                if (((_opcono == value)
                            == false))
                {
                    this.OnOPCONOChanging(value);
                    this.SendPropertyChanging();
                    this._opcono = value;
                    this.SendPropertyChanged("OPCONO");
                    this.OnOPCONOChanged();
                }
            }
        }

        [Column(Storage = "_opconphone", Name = "OP_CONPHONE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPCONPHONE
        {
            get
            {
                return this._opconphone;
            }
            set
            {
                if (((_opconphone == value)
                            == false))
                {
                    this.OnOPCONPHONEChanging(value);
                    this.SendPropertyChanging();
                    this._opconphone = value;
                    this.SendPropertyChanged("OPCONPHONE");
                    this.OnOPCONPHONEChanged();
                }
            }
        }

        [Column(Storage = "_opcontacts", Name = "OP_CONTACTS", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPCONTACTS
        {
            get
            {
                return this._opcontacts;
            }
            set
            {
                if (((_opcontacts == value)
                            == false))
                {
                    this.OnOPCONTACTSChanging(value);
                    this.SendPropertyChanging();
                    this._opcontacts = value;
                    this.SendPropertyChanged("OPCONTACTS");
                    this.OnOPCONTACTSChanged();
                }
            }
        }

        [Column(Storage = "_opdesc", Name = "OP_DESC", DbType = "VARCHAR(1000)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPDESC
        {
            get
            {
                return this._opdesc;
            }
            set
            {
                if (((_opdesc == value)
                            == false))
                {
                    this.OnOPDESCChanging(value);
                    this.SendPropertyChanging();
                    this._opdesc = value;
                    this.SendPropertyChanged("OPDESC");
                    this.OnOPDESCChanged();
                }
            }
        }

        [Column(Storage = "_opid", Name = "OP_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int OPID
        {
            get
            {
                return this._opid;
            }
            set
            {
                if ((_opid != value))
                {
                    this.OnOPIDChanging(value);
                    this.SendPropertyChanging();
                    this._opid = value;
                    this.SendPropertyChanged("OPID");
                    this.OnOPIDChanged();
                }
            }
        }

        [Column(Storage = "_oplevel", Name = "OP_LEVEL", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> OPLEVEL
        {
            get
            {
                return this._oplevel;
            }
            set
            {
                if ((_oplevel != value))
                {
                    this.OnOPLEVELChanging(value);
                    this.SendPropertyChanging();
                    this._oplevel = value;
                    this.SendPropertyChanged("OPLEVEL");
                    this.OnOPLEVELChanged();
                }
            }
        }

        [Column(Storage = "_oplicense", Name = "OP_LICENSE", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPLICENSE
        {
            get
            {
                return this._oplicense;
            }
            set
            {
                if (((_oplicense == value)
                            == false))
                {
                    this.OnOPLICENSEChanging(value);
                    this.SendPropertyChanging();
                    this._oplicense = value;
                    this.SendPropertyChanged("OPLICENSE");
                    this.OnOPLICENSEChanged();
                }
            }
        }

        [Column(Storage = "_opmanager", Name = "OP_MANAGER", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPMANAGER
        {
            get
            {
                return this._opmanager;
            }
            set
            {
                if (((_opmanager == value)
                            == false))
                {
                    this.OnOPMANAGERChanging(value);
                    this.SendPropertyChanging();
                    this._opmanager = value;
                    this.SendPropertyChanged("OPMANAGER");
                    this.OnOPMANAGERChanged();
                }
            }
        }

        [Column(Storage = "_opmanidcode", Name = "OP_MANIDCODE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPMANIDCODE
        {
            get
            {
                return this._opmanidcode;
            }
            set
            {
                if (((_opmanidcode == value)
                            == false))
                {
                    this.OnOPMANIDCODEChanging(value);
                    this.SendPropertyChanging();
                    this._opmanidcode = value;
                    this.SendPropertyChanged("OPMANIDCODE");
                    this.OnOPMANIDCODEChanged();
                }
            }
        }

        [Column(Storage = "_opmanidtype", Name = "OP_MANIDTYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> OPMANIDTYPE
        {
            get
            {
                return this._opmanidtype;
            }
            set
            {
                if ((_opmanidtype != value))
                {
                    this.OnOPMANIDTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._opmanidtype = value;
                    this.SendPropertyChanged("OPMANIDTYPE");
                    this.OnOPMANIDTYPEChanged();
                }
            }
        }

        [Column(Storage = "_opmanphone", Name = "OP_MANPHONE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPMANPHONE
        {
            get
            {
                return this._opmanphone;
            }
            set
            {
                if (((_opmanphone == value)
                            == false))
                {
                    this.OnOPMANPHONEChanging(value);
                    this.SendPropertyChanging();
                    this._opmanphone = value;
                    this.SendPropertyChanged("OPMANPHONE");
                    this.OnOPMANPHONEChanged();
                }
            }
        }

        [Column(Storage = "_opname", Name = "OP_NAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPNAME
        {
            get
            {
                return this._opname;
            }
            set
            {
                if (((_opname == value)
                            == false))
                {
                    this.OnOPNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._opname = value;
                    this.SendPropertyChanged("OPNAME");
                    this.OnOPNAMEChanged();
                }
            }
        }

        [Column(Storage = "_opno", Name = "OP_NO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPNO
        {
            get
            {
                return this._opno;
            }
            set
            {
                if (((_opno == value)
                            == false))
                {
                    this.OnOPNOChanging(value);
                    this.SendPropertyChanging();
                    this._opno = value;
                    this.SendPropertyChanged("OPNO");
                    this.OnOPNOChanged();
                }
            }
        }

        [Column(Storage = "_oporgcode", Name = "OP_ORGCODE", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPORGCODE
        {
            get
            {
                return this._oporgcode;
            }
            set
            {
                if (((_oporgcode == value)
                            == false))
                {
                    this.OnOPORGCODEChanging(value);
                    this.SendPropertyChanging();
                    this._oporgcode = value;
                    this.SendPropertyChanged("OPORGCODE");
                    this.OnOPORGCODEChanged();
                }
            }
        }

        [Column(Storage = "_opparentid", Name = "OP_PARENTID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> OPPARENTID
        {
            get
            {
                return this._opparentid;
            }
            set
            {
                if ((_opparentid != value))
                {
                    this.OnOPPARENTIDChanging(value);
                    this.SendPropertyChanging();
                    this._opparentid = value;
                    this.SendPropertyChanged("OPPARENTID");
                    this.OnOPPARENTIDChanged();
                }
            }
        }

        [Column(Storage = "_opparentname", Name = "OP_PARENTNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPPARENTNAME
        {
            get
            {
                return this._opparentname;
            }
            set
            {
                if (((_opparentname == value)
                            == false))
                {
                    this.OnOPPARENTNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._opparentname = value;
                    this.SendPropertyChanged("OPPARENTNAME");
                    this.OnOPPARENTNAMEChanged();
                }
            }
        }

        [Column(Storage = "_opproname", Name = "OP_PRONAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPPRONAME
        {
            get
            {
                return this._opproname;
            }
            set
            {
                if (((_opproname == value)
                            == false))
                {
                    this.OnOPPRONAMEChanging(value);
                    this.SendPropertyChanging();
                    this._opproname = value;
                    this.SendPropertyChanged("OPPRONAME");
                    this.OnOPPRONAMEChanged();
                }
            }
        }

        [Column(Storage = "_opprono", Name = "OP_PRONO", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPPRONO
        {
            get
            {
                return this._opprono;
            }
            set
            {
                if (((_opprono == value)
                            == false))
                {
                    this.OnOPPRONOChanging(value);
                    this.SendPropertyChanging();
                    this._opprono = value;
                    this.SendPropertyChanged("OPPRONO");
                    this.OnOPPRONOChanged();
                }
            }
        }

        [Column(Storage = "_optel", Name = "OP_TEL", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPTEL
        {
            get
            {
                return this._optel;
            }
            set
            {
                if (((_optel == value)
                            == false))
                {
                    this.OnOPTELChanging(value);
                    this.SendPropertyChanging();
                    this._optel = value;
                    this.SendPropertyChanged("OPTEL");
                    this.OnOPTELChanged();
                }
            }
        }

        [Column(Storage = "_opwebsite", Name = "OP_WEBSITE", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPWEBSITE
        {
            get
            {
                return this._opwebsite;
            }
            set
            {
                if (((_opwebsite == value)
                            == false))
                {
                    this.OnOPWEBSITEChanging(value);
                    this.SendPropertyChanging();
                    this._opwebsite = value;
                    this.SendPropertyChanged("OPWEBSITE");
                    this.OnOPWEBSITEChanged();
                }
            }
        }

        [Column(Storage = "_opzone", Name = "OP_ZONE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string OPZONE
        {
            get
            {
                return this._opzone;
            }
            set
            {
                if (((_opzone == value)
                            == false))
                {
                    this.OnOPZONEChanging(value);
                    this.SendPropertyChanging();
                    this._opzone = value;
                    this.SendPropertyChanged("OPZONE");
                    this.OnOPZONEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_PBOX")]
    public partial class EBOXPBOX : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<int> _bpoverday;

        private string _pbabbr;

        private string _pbaddress;

        private string _pbaddressalias;

        private string _pbbuzno;

        private string _pbcityname;

        private string _pbcityno;

        private string _pbconame;

        private string _pbcono;

        private string _pbcrtno;

        private int _pbid;

        private string _pbmaintainname;

        private string _pbmaintainphone;

        private System.Nullable<int> _pbmaintainuid;

        private string _pbname;

        private System.Nullable<int> _pbocid;

        private string _pbocmode;

        private System.Nullable<int> _pbopid;

        private string _pbopname;

        private System.Nullable<int> _pbplaceid;

        private string _pbplacename;

        private System.Nullable<System.DateTime> _pbplacetime;

        private System.Nullable<sbyte> _pbplacetype;

        private System.Nullable<int> _pbprincipald;

        private string _pbprincipalname;

        private string _pbprincipalphone;

        private System.Nullable<System.DateTime> _pbproductiontime;

        private string _pbproname;

        private string _pbprono;

        private System.Nullable<int> _pbsmsopid;

        private string _pbsmsopname;

        private System.Nullable<int> _pbsoftid;

        private string _pbsoftname;

        private string _pbsoftversion;

        private System.Nullable<int> _pbsurveyor;

        private string _pbsurveyorname;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnBPOVERDAYChanged();

        partial void OnBPOVERDAYChanging(System.Nullable<int> value);

        partial void OnPBABBRChanged();

        partial void OnPBABBRChanging(string value);

        partial void OnPBADDRESSChanged();

        partial void OnPBADDRESSChanging(string value);

        partial void OnPBADDRESSALIASChanged();

        partial void OnPBADDRESSALIASChanging(string value);

        partial void OnPBBUZNOChanged();

        partial void OnPBBUZNOChanging(string value);

        partial void OnPBCITYNAMEChanged();

        partial void OnPBCITYNAMEChanging(string value);

        partial void OnPBCITYNOChanged();

        partial void OnPBCITYNOChanging(string value);

        partial void OnPBCONAMEChanged();

        partial void OnPBCONAMEChanging(string value);

        partial void OnPBCONOChanged();

        partial void OnPBCONOChanging(string value);

        partial void OnPBCRTNOChanged();

        partial void OnPBCRTNOChanging(string value);

        partial void OnPBIDChanged();

        partial void OnPBIDChanging(int value);

        partial void OnPBMAINTAINNAMEChanged();

        partial void OnPBMAINTAINNAMEChanging(string value);

        partial void OnPBMAINTAINPHONEChanged();

        partial void OnPBMAINTAINPHONEChanging(string value);

        partial void OnPBMAINTAINUIDChanged();

        partial void OnPBMAINTAINUIDChanging(System.Nullable<int> value);

        partial void OnPBNAMEChanged();

        partial void OnPBNAMEChanging(string value);

        partial void OnPBOCIDChanged();

        partial void OnPBOCIDChanging(System.Nullable<int> value);

        partial void OnPBOCMODEChanged();

        partial void OnPBOCMODEChanging(string value);

        partial void OnPBOPIDChanged();

        partial void OnPBOPIDChanging(System.Nullable<int> value);

        partial void OnPBOPNAMEChanged();

        partial void OnPBOPNAMEChanging(string value);

        partial void OnPBPLACEIDChanged();

        partial void OnPBPLACEIDChanging(System.Nullable<int> value);

        partial void OnPBPLACENAMEChanged();

        partial void OnPBPLACENAMEChanging(string value);

        partial void OnPBPLACETIMEChanged();

        partial void OnPBPLACETIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnPBPLACETYPEChanged();

        partial void OnPBPLACETYPEChanging(System.Nullable<sbyte> value);

        partial void OnPBPRINCIPALDChanged();

        partial void OnPBPRINCIPALDChanging(System.Nullable<int> value);

        partial void OnPBPRINCIPALNAMEChanged();

        partial void OnPBPRINCIPALNAMEChanging(string value);

        partial void OnPBPRINCIPALPHONEChanged();

        partial void OnPBPRINCIPALPHONEChanging(string value);

        partial void OnPBPRODUCTIONTIMEChanged();

        partial void OnPBPRODUCTIONTIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnPBPRONAMEChanged();

        partial void OnPBPRONAMEChanging(string value);

        partial void OnPBPRONOChanged();

        partial void OnPBPRONOChanging(string value);

        partial void OnPBSMSOPIDChanged();

        partial void OnPBSMSOPIDChanging(System.Nullable<int> value);

        partial void OnPBSMSOPNAMEChanged();

        partial void OnPBSMSOPNAMEChanging(string value);

        partial void OnPBSOFTIDChanged();

        partial void OnPBSOFTIDChanging(System.Nullable<int> value);

        partial void OnPBSOFTNAMEChanged();

        partial void OnPBSOFTNAMEChanging(string value);

        partial void OnPBSOFTVERSIONChanged();

        partial void OnPBSOFTVERSIONChanging(string value);

        partial void OnPBSURVEYORChanged();

        partial void OnPBSURVEYORChanging(System.Nullable<int> value);

        partial void OnPBSURVEYORNAMEChanged();

        partial void OnPBSURVEYORNAMEChanging(string value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXPBOX()
        {
            this.OnCreated();
        }

        [Column(Storage = "_bpoverday", Name = "BP_OVERDAY", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> BPOVERDAY
        {
            get
            {
                return this._bpoverday;
            }
            set
            {
                if ((_bpoverday != value))
                {
                    this.OnBPOVERDAYChanging(value);
                    this.SendPropertyChanging();
                    this._bpoverday = value;
                    this.SendPropertyChanged("BPOVERDAY");
                    this.OnBPOVERDAYChanged();
                }
            }
        }

        [Column(Storage = "_pbabbr", Name = "PB_ABBR", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBABBR
        {
            get
            {
                return this._pbabbr;
            }
            set
            {
                if (((_pbabbr == value)
                            == false))
                {
                    this.OnPBABBRChanging(value);
                    this.SendPropertyChanging();
                    this._pbabbr = value;
                    this.SendPropertyChanged("PBABBR");
                    this.OnPBABBRChanged();
                }
            }
        }

        [Column(Storage = "_pbaddress", Name = "PB_ADDRESS", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBADDRESS
        {
            get
            {
                return this._pbaddress;
            }
            set
            {
                if (((_pbaddress == value)
                            == false))
                {
                    this.OnPBADDRESSChanging(value);
                    this.SendPropertyChanging();
                    this._pbaddress = value;
                    this.SendPropertyChanged("PBADDRESS");
                    this.OnPBADDRESSChanged();
                }
            }
        }

        [Column(Storage = "_pbaddressalias", Name = "PB_ADDRESSALIAS", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBADDRESSALIAS
        {
            get
            {
                return this._pbaddressalias;
            }
            set
            {
                if (((_pbaddressalias == value)
                            == false))
                {
                    this.OnPBADDRESSALIASChanging(value);
                    this.SendPropertyChanging();
                    this._pbaddressalias = value;
                    this.SendPropertyChanged("PBADDRESSALIAS");
                    this.OnPBADDRESSALIASChanged();
                }
            }
        }

        [Column(Storage = "_pbbuzno", Name = "PB_BUZNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBBUZNO
        {
            get
            {
                return this._pbbuzno;
            }
            set
            {
                if (((_pbbuzno == value)
                            == false))
                {
                    this.OnPBBUZNOChanging(value);
                    this.SendPropertyChanging();
                    this._pbbuzno = value;
                    this.SendPropertyChanged("PBBUZNO");
                    this.OnPBBUZNOChanged();
                }
            }
        }

        [Column(Storage = "_pbcityname", Name = "PB_CITYNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBCITYNAME
        {
            get
            {
                return this._pbcityname;
            }
            set
            {
                if (((_pbcityname == value)
                            == false))
                {
                    this.OnPBCITYNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbcityname = value;
                    this.SendPropertyChanged("PBCITYNAME");
                    this.OnPBCITYNAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbcityno", Name = "PB_CITYNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBCITYNO
        {
            get
            {
                return this._pbcityno;
            }
            set
            {
                if (((_pbcityno == value)
                            == false))
                {
                    this.OnPBCITYNOChanging(value);
                    this.SendPropertyChanging();
                    this._pbcityno = value;
                    this.SendPropertyChanged("PBCITYNO");
                    this.OnPBCITYNOChanged();
                }
            }
        }

        [Column(Storage = "_pbconame", Name = "PB_CONAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBCONAME
        {
            get
            {
                return this._pbconame;
            }
            set
            {
                if (((_pbconame == value)
                            == false))
                {
                    this.OnPBCONAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbconame = value;
                    this.SendPropertyChanged("PBCONAME");
                    this.OnPBCONAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbcono", Name = "PB_CONO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBCONO
        {
            get
            {
                return this._pbcono;
            }
            set
            {
                if (((_pbcono == value)
                            == false))
                {
                    this.OnPBCONOChanging(value);
                    this.SendPropertyChanging();
                    this._pbcono = value;
                    this.SendPropertyChanged("PBCONO");
                    this.OnPBCONOChanged();
                }
            }
        }

        [Column(Storage = "_pbcrtno", Name = "PB_CRTNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBCRTNO
        {
            get
            {
                return this._pbcrtno;
            }
            set
            {
                if (((_pbcrtno == value)
                            == false))
                {
                    this.OnPBCRTNOChanging(value);
                    this.SendPropertyChanging();
                    this._pbcrtno = value;
                    this.SendPropertyChanged("PBCRTNO");
                    this.OnPBCRTNOChanged();
                }
            }
        }

        [Column(Storage = "_pbid", Name = "PB_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int PBID
        {
            get
            {
                return this._pbid;
            }
            set
            {
                if ((_pbid != value))
                {
                    this.OnPBIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbid = value;
                    this.SendPropertyChanged("PBID");
                    this.OnPBIDChanged();
                }
            }
        }

        [Column(Storage = "_pbmaintainname", Name = "PB_MAINTAINNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBMAINTAINNAME
        {
            get
            {
                return this._pbmaintainname;
            }
            set
            {
                if (((_pbmaintainname == value)
                            == false))
                {
                    this.OnPBMAINTAINNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbmaintainname = value;
                    this.SendPropertyChanged("PBMAINTAINNAME");
                    this.OnPBMAINTAINNAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbmaintainphone", Name = "PB_MAINTAINPHONE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBMAINTAINPHONE
        {
            get
            {
                return this._pbmaintainphone;
            }
            set
            {
                if (((_pbmaintainphone == value)
                            == false))
                {
                    this.OnPBMAINTAINPHONEChanging(value);
                    this.SendPropertyChanging();
                    this._pbmaintainphone = value;
                    this.SendPropertyChanged("PBMAINTAINPHONE");
                    this.OnPBMAINTAINPHONEChanged();
                }
            }
        }

        [Column(Storage = "_pbmaintainuid", Name = "PB_MAINTAINUID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBMAINTAINUID
        {
            get
            {
                return this._pbmaintainuid;
            }
            set
            {
                if ((_pbmaintainuid != value))
                {
                    this.OnPBMAINTAINUIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbmaintainuid = value;
                    this.SendPropertyChanged("PBMAINTAINUID");
                    this.OnPBMAINTAINUIDChanged();
                }
            }
        }

        [Column(Storage = "_pbname", Name = "PB_NAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBNAME
        {
            get
            {
                return this._pbname;
            }
            set
            {
                if (((_pbname == value)
                            == false))
                {
                    this.OnPBNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbname = value;
                    this.SendPropertyChanged("PBNAME");
                    this.OnPBNAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbocid", Name = "PB_OCID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBOCID
        {
            get
            {
                return this._pbocid;
            }
            set
            {
                if ((_pbocid != value))
                {
                    this.OnPBOCIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbocid = value;
                    this.SendPropertyChanged("PBOCID");
                    this.OnPBOCIDChanged();
                }
            }
        }

        [Column(Storage = "_pbocmode", Name = "PB_OCMODE", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBOCMODE
        {
            get
            {
                return this._pbocmode;
            }
            set
            {
                if (((_pbocmode == value)
                            == false))
                {
                    this.OnPBOCMODEChanging(value);
                    this.SendPropertyChanging();
                    this._pbocmode = value;
                    this.SendPropertyChanged("PBOCMODE");
                    this.OnPBOCMODEChanged();
                }
            }
        }

        [Column(Storage = "_pbopid", Name = "PB_OPID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBOPID
        {
            get
            {
                return this._pbopid;
            }
            set
            {
                if ((_pbopid != value))
                {
                    this.OnPBOPIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbopid = value;
                    this.SendPropertyChanged("PBOPID");
                    this.OnPBOPIDChanged();
                }
            }
        }

        [Column(Storage = "_pbopname", Name = "PB_OPNAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBOPNAME
        {
            get
            {
                return this._pbopname;
            }
            set
            {
                if (((_pbopname == value)
                            == false))
                {
                    this.OnPBOPNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbopname = value;
                    this.SendPropertyChanged("PBOPNAME");
                    this.OnPBOPNAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbplaceid", Name = "PB_PLACEID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBPLACEID
        {
            get
            {
                return this._pbplaceid;
            }
            set
            {
                if ((_pbplaceid != value))
                {
                    this.OnPBPLACEIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbplaceid = value;
                    this.SendPropertyChanged("PBPLACEID");
                    this.OnPBPLACEIDChanged();
                }
            }
        }

        [Column(Storage = "_pbplacename", Name = "PB_PLACENAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBPLACENAME
        {
            get
            {
                return this._pbplacename;
            }
            set
            {
                if (((_pbplacename == value)
                            == false))
                {
                    this.OnPBPLACENAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbplacename = value;
                    this.SendPropertyChanged("PBPLACENAME");
                    this.OnPBPLACENAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbplacetime", Name = "PB_PLACETIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> PBPLACETIME
        {
            get
            {
                return this._pbplacetime;
            }
            set
            {
                if ((_pbplacetime != value))
                {
                    this.OnPBPLACETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbplacetime = value;
                    this.SendPropertyChanged("PBPLACETIME");
                    this.OnPBPLACETIMEChanged();
                }
            }
        }

        [Column(Storage = "_pbplacetype", Name = "PB_PLACETYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> PBPLACETYPE
        {
            get
            {
                return this._pbplacetype;
            }
            set
            {
                if ((_pbplacetype != value))
                {
                    this.OnPBPLACETYPEChanging(value);
                    this.SendPropertyChanging();
                    this._pbplacetype = value;
                    this.SendPropertyChanged("PBPLACETYPE");
                    this.OnPBPLACETYPEChanged();
                }
            }
        }

        [Column(Storage = "_pbprincipald", Name = "PB_PRINCIPALD", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBPRINCIPALD
        {
            get
            {
                return this._pbprincipald;
            }
            set
            {
                if ((_pbprincipald != value))
                {
                    this.OnPBPRINCIPALDChanging(value);
                    this.SendPropertyChanging();
                    this._pbprincipald = value;
                    this.SendPropertyChanged("PBPRINCIPALD");
                    this.OnPBPRINCIPALDChanged();
                }
            }
        }

        [Column(Storage = "_pbprincipalname", Name = "PB_PRINCIPALNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBPRINCIPALNAME
        {
            get
            {
                return this._pbprincipalname;
            }
            set
            {
                if (((_pbprincipalname == value)
                            == false))
                {
                    this.OnPBPRINCIPALNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbprincipalname = value;
                    this.SendPropertyChanged("PBPRINCIPALNAME");
                    this.OnPBPRINCIPALNAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbprincipalphone", Name = "PB_PRINCIPALPHONE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBPRINCIPALPHONE
        {
            get
            {
                return this._pbprincipalphone;
            }
            set
            {
                if (((_pbprincipalphone == value)
                            == false))
                {
                    this.OnPBPRINCIPALPHONEChanging(value);
                    this.SendPropertyChanging();
                    this._pbprincipalphone = value;
                    this.SendPropertyChanged("PBPRINCIPALPHONE");
                    this.OnPBPRINCIPALPHONEChanged();
                }
            }
        }

        [Column(Storage = "_pbproductiontime", Name = "PB_PRODUCTIONTIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> PBPRODUCTIONTIME
        {
            get
            {
                return this._pbproductiontime;
            }
            set
            {
                if ((_pbproductiontime != value))
                {
                    this.OnPBPRODUCTIONTIMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbproductiontime = value;
                    this.SendPropertyChanged("PBPRODUCTIONTIME");
                    this.OnPBPRODUCTIONTIMEChanged();
                }
            }
        }

        [Column(Storage = "_pbproname", Name = "PB_PRONAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBPRONAME
        {
            get
            {
                return this._pbproname;
            }
            set
            {
                if (((_pbproname == value)
                            == false))
                {
                    this.OnPBPRONAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbproname = value;
                    this.SendPropertyChanged("PBPRONAME");
                    this.OnPBPRONAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbprono", Name = "PB_PRONO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBPRONO
        {
            get
            {
                return this._pbprono;
            }
            set
            {
                if (((_pbprono == value)
                            == false))
                {
                    this.OnPBPRONOChanging(value);
                    this.SendPropertyChanging();
                    this._pbprono = value;
                    this.SendPropertyChanged("PBPRONO");
                    this.OnPBPRONOChanged();
                }
            }
        }

        [Column(Storage = "_pbsmsopid", Name = "PB_SMSOPID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBSMSOPID
        {
            get
            {
                return this._pbsmsopid;
            }
            set
            {
                if ((_pbsmsopid != value))
                {
                    this.OnPBSMSOPIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbsmsopid = value;
                    this.SendPropertyChanged("PBSMSOPID");
                    this.OnPBSMSOPIDChanged();
                }
            }
        }

        [Column(Storage = "_pbsmsopname", Name = "PB_SMSOPNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBSMSOPNAME
        {
            get
            {
                return this._pbsmsopname;
            }
            set
            {
                if (((_pbsmsopname == value)
                            == false))
                {
                    this.OnPBSMSOPNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbsmsopname = value;
                    this.SendPropertyChanged("PBSMSOPNAME");
                    this.OnPBSMSOPNAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbsoftid", Name = "PB_SOFTID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBSOFTID
        {
            get
            {
                return this._pbsoftid;
            }
            set
            {
                if ((_pbsoftid != value))
                {
                    this.OnPBSOFTIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbsoftid = value;
                    this.SendPropertyChanged("PBSOFTID");
                    this.OnPBSOFTIDChanged();
                }
            }
        }

        [Column(Storage = "_pbsoftname", Name = "PB_SOFTNAME", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBSOFTNAME
        {
            get
            {
                return this._pbsoftname;
            }
            set
            {
                if (((_pbsoftname == value)
                            == false))
                {
                    this.OnPBSOFTNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbsoftname = value;
                    this.SendPropertyChanged("PBSOFTNAME");
                    this.OnPBSOFTNAMEChanged();
                }
            }
        }

        [Column(Storage = "_pbsoftversion", Name = "PB_SOFTVERSION", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBSOFTVERSION
        {
            get
            {
                return this._pbsoftversion;
            }
            set
            {
                if (((_pbsoftversion == value)
                            == false))
                {
                    this.OnPBSOFTVERSIONChanging(value);
                    this.SendPropertyChanging();
                    this._pbsoftversion = value;
                    this.SendPropertyChanged("PBSOFTVERSION");
                    this.OnPBSOFTVERSIONChanged();
                }
            }
        }

        [Column(Storage = "_pbsurveyor", Name = "PB_SURVEYOR", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBSURVEYOR
        {
            get
            {
                return this._pbsurveyor;
            }
            set
            {
                if ((_pbsurveyor != value))
                {
                    this.OnPBSURVEYORChanging(value);
                    this.SendPropertyChanging();
                    this._pbsurveyor = value;
                    this.SendPropertyChanged("PBSURVEYOR");
                    this.OnPBSURVEYORChanged();
                }
            }
        }

        [Column(Storage = "_pbsurveyorname", Name = "PB_SURVEYORNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PBSURVEYORNAME
        {
            get
            {
                return this._pbsurveyorname;
            }
            set
            {
                if (((_pbsurveyorname == value)
                            == false))
                {
                    this.OnPBSURVEYORNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._pbsurveyorname = value;
                    this.SendPropertyChanged("PBSURVEYORNAME");
                    this.OnPBSURVEYORNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_PROVINCE_CODE")]
    public partial class EBOXPROVINCECODE : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _abbre;

        private System.Nullable<int> _parentid;

        private int _provinceid;

        private string _provinceno;

        private string _provname;

        private System.Nullable<int> _sortno;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        //private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        //private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        //private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnABBREChanged();

        partial void OnABBREChanging(string value);

        partial void OnPARENTIDChanged();

        partial void OnPARENTIDChanging(System.Nullable<int> value);

        partial void OnPROVINCEIDChanged();

        partial void OnPROVINCEIDChanging(int value);

        partial void OnPROVINCENOChanged();

        partial void OnPROVINCENOChanging(string value);

        partial void OnPROVNAMEChanged();

        partial void OnPROVNAMEChanging(string value);

        partial void OnSORTNOChanged();

        partial void OnSORTNOChanging(System.Nullable<int> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXPROVINCECODE()
        {
            this.OnCreated();
        }

        [Column(Storage = "_abbre", Name = "ABBRE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ABBRE
        {
            get
            {
                return this._abbre;
            }
            set
            {
                if (((_abbre == value)
                            == false))
                {
                    this.OnABBREChanging(value);
                    this.SendPropertyChanging();
                    this._abbre = value;
                    this.SendPropertyChanged("ABBRE");
                    this.OnABBREChanged();
                }
            }
        }

        [Column(Storage = "_parentid", Name = "PARENTID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PARENTID
        {
            get
            {
                return this._parentid;
            }
            set
            {
                if ((_parentid != value))
                {
                    this.OnPARENTIDChanging(value);
                    this.SendPropertyChanging();
                    this._parentid = value;
                    this.SendPropertyChanged("PARENTID");
                    this.OnPARENTIDChanged();
                }
            }
        }

        [Column(Storage = "_provinceid", Name = "PROVINCEID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int PROVINCEID
        {
            get
            {
                return this._provinceid;
            }
            set
            {
                if ((_provinceid != value))
                {
                    this.OnPROVINCEIDChanging(value);
                    this.SendPropertyChanging();
                    this._provinceid = value;
                    this.SendPropertyChanged("PROVINCEID");
                    this.OnPROVINCEIDChanged();
                }
            }
        }

        [Column(Storage = "_provinceno", Name = "PROVINCENO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PROVINCENO
        {
            get
            {
                return this._provinceno;
            }
            set
            {
                if (((_provinceno == value)
                            == false))
                {
                    this.OnPROVINCENOChanging(value);
                    this.SendPropertyChanging();
                    this._provinceno = value;
                    this.SendPropertyChanged("PROVINCENO");
                    this.OnPROVINCENOChanged();
                }
            }
        }

        [Column(Storage = "_provname", Name = "PROVNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PROVNAME
        {
            get
            {
                return this._provname;
            }
            set
            {
                if (((_provname == value)
                            == false))
                {
                    this.OnPROVNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._provname = value;
                    this.SendPropertyChanged("PROVNAME");
                    this.OnPROVNAMEChanged();
                }
            }
        }

        [Column(Storage = "_sortno", Name = "SORTNO", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SORTNO
        {
            get
            {
                return this._sortno;
            }
            set
            {
                if ((_sortno != value))
                {
                    this.OnSORTNOChanging(value);
                    this.SendPropertyChanging();
                    this._sortno = value;
                    this.SendPropertyChanged("SORTNO");
                    this.OnSORTNOChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        //[Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        //[DebuggerNonUserCode()]
        //public System.Nullable<System.DateTime> TFBACKUPFIELD3
        //{
        //    get
        //    {
        //        return this._tfbackupfield3;
        //    }
        //    set
        //    {
        //        if ((_tfbackupfield3 != value))
        //        {
        //            this.OnTFBACKUPFIELD3Changing(value);
        //            this.SendPropertyChanging();
        //            this._tfbackupfield3 = value;
        //            this.SendPropertyChanged("TFBACKUPFIELD3");
        //            this.OnTFBACKUPFIELD3Changed();
        //        }
        //    }
        //}

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        //[Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        //[DebuggerNonUserCode()]
        //public System.Nullable<System.DateTime> TFCREATEDATE
        //{
        //    get
        //    {
        //        return this._tfcreatedate;
        //    }
        //    set
        //    {
        //        if ((_tfcreatedate != value))
        //        {
        //            this.OnTFCREATEDATEChanging(value);
        //            this.SendPropertyChanging();
        //            this._tfcreatedate = value;
        //            this.SendPropertyChanged("TFCREATEDATE");
        //            this.OnTFCREATEDATEChanged();
        //        }
        //    }
        //}

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        //[Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        //[DebuggerNonUserCode()]
        //public System.Nullable<System.DateTime> TFUPDATEDATE
        //{
        //    get
        //    {
        //        return this._tfupdatedate;
        //    }
        //    set
        //    {
        //        if ((_tfupdatedate != value))
        //        {
        //            this.OnTFUPDATEDATEChanging(value);
        //            this.SendPropertyChanging();
        //            this._tfupdatedate = value;
        //            this.SendPropertyChanged("TFUPDATEDATE");
        //            this.OnTFUPDATEDATEChanged();
        //        }
        //    }
        //}

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_STORECONTENTARK")]
    public partial class EBOXSTORECONTENTARK : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<sbyte> _pabuyingmode;

        private System.Nullable<sbyte> _pacontrolplate;

        private System.Nullable<int> _painspectorid;

        private string _painspectorname;

        private System.Nullable<System.DateTime> _paproductiontime;

        private System.Nullable<sbyte> _pasort;

        private System.Nullable<int> _scaarkmonth;

        private System.Nullable<int> _scaboxid;

        private string _scaboxno;

        private string _scabuzno;

        private string _scacrtno;

        private System.Nullable<sbyte> _scadefine;

        private System.Nullable<int> _scadefineld;

        private string _scadefinename;

        private System.Nullable<double> _scafloorarea;

        private int _scaid;

        private string _scainstructions;

        private System.Nullable<double> _scaprice;

        private System.Nullable<sbyte> _scasacal;

        private string _scasize;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnPABUYINGMODEChanged();

        partial void OnPABUYINGMODEChanging(System.Nullable<sbyte> value);

        partial void OnPACONTROLPLATEChanged();

        partial void OnPACONTROLPLATEChanging(System.Nullable<sbyte> value);

        partial void OnPAINSPECTORIDChanged();

        partial void OnPAINSPECTORIDChanging(System.Nullable<int> value);

        partial void OnPAINSPECTORNAMEChanged();

        partial void OnPAINSPECTORNAMEChanging(string value);

        partial void OnPAPRODUCTIONTIMEChanged();

        partial void OnPAPRODUCTIONTIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnPASORTChanged();

        partial void OnPASORTChanging(System.Nullable<sbyte> value);

        partial void OnSCAARKMONTHChanged();

        partial void OnSCAARKMONTHChanging(System.Nullable<int> value);

        partial void OnSCABOXIDChanged();

        partial void OnSCABOXIDChanging(System.Nullable<int> value);

        partial void OnSCABOXNOChanged();

        partial void OnSCABOXNOChanging(string value);

        partial void OnSCABUZNOChanged();

        partial void OnSCABUZNOChanging(string value);

        partial void OnSCACRTNOChanged();

        partial void OnSCACRTNOChanging(string value);

        partial void OnSCADEFINEChanged();

        partial void OnSCADEFINEChanging(System.Nullable<sbyte> value);

        partial void OnSCADEFINELDChanged();

        partial void OnSCADEFINELDChanging(System.Nullable<int> value);

        partial void OnSCADEFINENAMEChanged();

        partial void OnSCADEFINENAMEChanging(string value);

        partial void OnSCAFLOORAREAChanged();

        partial void OnSCAFLOORAREAChanging(System.Nullable<double> value);

        partial void OnSCAIDChanged();

        partial void OnSCAIDChanging(int value);

        partial void OnSCAINSTRUCTIONSChanged();

        partial void OnSCAINSTRUCTIONSChanging(string value);

        partial void OnSCAPRICEChanged();

        partial void OnSCAPRICEChanging(System.Nullable<double> value);

        partial void OnSCASACALChanged();

        partial void OnSCASACALChanging(System.Nullable<sbyte> value);

        partial void OnSCASIZEChanged();

        partial void OnSCASIZEChanging(string value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXSTORECONTENTARK()
        {
            this.OnCreated();
        }

        [Column(Storage = "_pabuyingmode", Name = "PA_BUYINGMODE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> PABUYINGMODE
        {
            get
            {
                return this._pabuyingmode;
            }
            set
            {
                if ((_pabuyingmode != value))
                {
                    this.OnPABUYINGMODEChanging(value);
                    this.SendPropertyChanging();
                    this._pabuyingmode = value;
                    this.SendPropertyChanged("PABUYINGMODE");
                    this.OnPABUYINGMODEChanged();
                }
            }
        }

        [Column(Storage = "_pacontrolplate", Name = "PA_CONTROLPLATE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> PACONTROLPLATE
        {
            get
            {
                return this._pacontrolplate;
            }
            set
            {
                if ((_pacontrolplate != value))
                {
                    this.OnPACONTROLPLATEChanging(value);
                    this.SendPropertyChanging();
                    this._pacontrolplate = value;
                    this.SendPropertyChanged("PACONTROLPLATE");
                    this.OnPACONTROLPLATEChanged();
                }
            }
        }

        [Column(Storage = "_painspectorid", Name = "PA_INSPECTORID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PAINSPECTORID
        {
            get
            {
                return this._painspectorid;
            }
            set
            {
                if ((_painspectorid != value))
                {
                    this.OnPAINSPECTORIDChanging(value);
                    this.SendPropertyChanging();
                    this._painspectorid = value;
                    this.SendPropertyChanged("PAINSPECTORID");
                    this.OnPAINSPECTORIDChanged();
                }
            }
        }

        [Column(Storage = "_painspectorname", Name = "PA_INSPECTORNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PAINSPECTORNAME
        {
            get
            {
                return this._painspectorname;
            }
            set
            {
                if (((_painspectorname == value)
                            == false))
                {
                    this.OnPAINSPECTORNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._painspectorname = value;
                    this.SendPropertyChanged("PAINSPECTORNAME");
                    this.OnPAINSPECTORNAMEChanged();
                }
            }
        }

        [Column(Storage = "_paproductiontime", Name = "PA_PRODUCTIONTIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> PAPRODUCTIONTIME
        {
            get
            {
                return this._paproductiontime;
            }
            set
            {
                if ((_paproductiontime != value))
                {
                    this.OnPAPRODUCTIONTIMEChanging(value);
                    this.SendPropertyChanging();
                    this._paproductiontime = value;
                    this.SendPropertyChanged("PAPRODUCTIONTIME");
                    this.OnPAPRODUCTIONTIMEChanged();
                }
            }
        }

        [Column(Storage = "_pasort", Name = "PA_SORT", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> PASORT
        {
            get
            {
                return this._pasort;
            }
            set
            {
                if ((_pasort != value))
                {
                    this.OnPASORTChanging(value);
                    this.SendPropertyChanging();
                    this._pasort = value;
                    this.SendPropertyChanged("PASORT");
                    this.OnPASORTChanged();
                }
            }
        }

        [Column(Storage = "_scaarkmonth", Name = "SCA_ARKMONTH", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SCAARKMONTH
        {
            get
            {
                return this._scaarkmonth;
            }
            set
            {
                if ((_scaarkmonth != value))
                {
                    this.OnSCAARKMONTHChanging(value);
                    this.SendPropertyChanging();
                    this._scaarkmonth = value;
                    this.SendPropertyChanged("SCAARKMONTH");
                    this.OnSCAARKMONTHChanged();
                }
            }
        }

        [Column(Storage = "_scaboxid", Name = "SCA_BOXID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SCABOXID
        {
            get
            {
                return this._scaboxid;
            }
            set
            {
                if ((_scaboxid != value))
                {
                    this.OnSCABOXIDChanging(value);
                    this.SendPropertyChanging();
                    this._scaboxid = value;
                    this.SendPropertyChanged("SCABOXID");
                    this.OnSCABOXIDChanged();
                }
            }
        }

        [Column(Storage = "_scaboxno", Name = "SCA_BOXNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SCABOXNO
        {
            get
            {
                return this._scaboxno;
            }
            set
            {
                if (((_scaboxno == value)
                            == false))
                {
                    this.OnSCABOXNOChanging(value);
                    this.SendPropertyChanging();
                    this._scaboxno = value;
                    this.SendPropertyChanged("SCABOXNO");
                    this.OnSCABOXNOChanged();
                }
            }
        }

        [Column(Storage = "_scabuzno", Name = "SCA_BUZNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SCABUZNO
        {
            get
            {
                return this._scabuzno;
            }
            set
            {
                if (((_scabuzno == value)
                            == false))
                {
                    this.OnSCABUZNOChanging(value);
                    this.SendPropertyChanging();
                    this._scabuzno = value;
                    this.SendPropertyChanged("SCABUZNO");
                    this.OnSCABUZNOChanged();
                }
            }
        }

        [Column(Storage = "_scacrtno", Name = "SCA_CRTNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SCACRTNO
        {
            get
            {
                return this._scacrtno;
            }
            set
            {
                if (((_scacrtno == value)
                            == false))
                {
                    this.OnSCACRTNOChanging(value);
                    this.SendPropertyChanging();
                    this._scacrtno = value;
                    this.SendPropertyChanged("SCACRTNO");
                    this.OnSCACRTNOChanged();
                }
            }
        }

        [Column(Storage = "_scadefine", Name = "SCA_DEFINE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> SCADEFINE
        {
            get
            {
                return this._scadefine;
            }
            set
            {
                if ((_scadefine != value))
                {
                    this.OnSCADEFINEChanging(value);
                    this.SendPropertyChanging();
                    this._scadefine = value;
                    this.SendPropertyChanged("SCADEFINE");
                    this.OnSCADEFINEChanged();
                }
            }
        }

        [Column(Storage = "_scadefineld", Name = "SCA_DEFINELD", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SCADEFINELD
        {
            get
            {
                return this._scadefineld;
            }
            set
            {
                if ((_scadefineld != value))
                {
                    this.OnSCADEFINELDChanging(value);
                    this.SendPropertyChanging();
                    this._scadefineld = value;
                    this.SendPropertyChanged("SCADEFINELD");
                    this.OnSCADEFINELDChanged();
                }
            }
        }

        [Column(Storage = "_scadefinename", Name = "SCA_DEFINENAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SCADEFINENAME
        {
            get
            {
                return this._scadefinename;
            }
            set
            {
                if (((_scadefinename == value)
                            == false))
                {
                    this.OnSCADEFINENAMEChanging(value);
                    this.SendPropertyChanging();
                    this._scadefinename = value;
                    this.SendPropertyChanged("SCADEFINENAME");
                    this.OnSCADEFINENAMEChanged();
                }
            }
        }

        [Column(Storage = "_scafloorarea", Name = "SCA_FLOORAREA", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> SCAFLOORAREA
        {
            get
            {
                return this._scafloorarea;
            }
            set
            {
                if ((_scafloorarea != value))
                {
                    this.OnSCAFLOORAREAChanging(value);
                    this.SendPropertyChanging();
                    this._scafloorarea = value;
                    this.SendPropertyChanged("SCAFLOORAREA");
                    this.OnSCAFLOORAREAChanged();
                }
            }
        }

        [Column(Storage = "_scaid", Name = "SCA_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int SCAID
        {
            get
            {
                return this._scaid;
            }
            set
            {
                if ((_scaid != value))
                {
                    this.OnSCAIDChanging(value);
                    this.SendPropertyChanging();
                    this._scaid = value;
                    this.SendPropertyChanged("SCAID");
                    this.OnSCAIDChanged();
                }
            }
        }

        [Column(Storage = "_scainstructions", Name = "SCA_INSTRUCTIONS", DbType = "VARCHAR(500)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SCAINSTRUCTIONS
        {
            get
            {
                return this._scainstructions;
            }
            set
            {
                if (((_scainstructions == value)
                            == false))
                {
                    this.OnSCAINSTRUCTIONSChanging(value);
                    this.SendPropertyChanging();
                    this._scainstructions = value;
                    this.SendPropertyChanged("SCAINSTRUCTIONS");
                    this.OnSCAINSTRUCTIONSChanged();
                }
            }
        }

        [Column(Storage = "_scaprice", Name = "SCA_PRICE", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> SCAPRICE
        {
            get
            {
                return this._scaprice;
            }
            set
            {
                if ((_scaprice != value))
                {
                    this.OnSCAPRICEChanging(value);
                    this.SendPropertyChanging();
                    this._scaprice = value;
                    this.SendPropertyChanged("SCAPRICE");
                    this.OnSCAPRICEChanged();
                }
            }
        }

        [Column(Storage = "_scasacal", Name = "SCA_SACAL", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> SCASACAL
        {
            get
            {
                return this._scasacal;
            }
            set
            {
                if ((_scasacal != value))
                {
                    this.OnSCASACALChanging(value);
                    this.SendPropertyChanging();
                    this._scasacal = value;
                    this.SendPropertyChanged("SCASACAL");
                    this.OnSCASACALChanged();
                }
            }
        }

        [Column(Storage = "_scasize", Name = "SCA_SIZE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SCASIZE
        {
            get
            {
                return this._scasize;
            }
            set
            {
                if (((_scasize == value)
                            == false))
                {
                    this.OnSCASIZEChanging(value);
                    this.SendPropertyChanging();
                    this._scasize = value;
                    this.SendPropertyChanged("SCASIZE");
                    this.OnSCASIZEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }


    [Table(Name = "main.EBOX_SYS_CODE")]
    public partial class EBOXSYSCODE : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<int> _ctno;

        private string _parsyscode;

        private string _remark;

        private string _scname;

        private int _sid;

        private System.Nullable<int> _sortno;

        private System.Nullable<int> _syscode;

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnCTNOChanged();

        partial void OnCTNOChanging(System.Nullable<int> value);

        partial void OnPARSYSCODEChanged();

        partial void OnPARSYSCODEChanging(string value);

        partial void OnREMARKChanged();

        partial void OnREMARKChanging(string value);

        partial void OnSCNAMEChanged();

        partial void OnSCNAMEChanging(string value);

        partial void OnSIDChanged();

        partial void OnSIDChanging(int value);

        partial void OnSORTNOChanged();

        partial void OnSORTNOChanging(System.Nullable<int> value);

        partial void OnSYSCODEChanged();

        partial void OnSYSCODEChanging(System.Nullable<int> value);

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);
        #endregion


        public EBOXSYSCODE()
        {
            this.OnCreated();
        }

        [Column(Storage = "_ctno", Name = "CTNO", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> CTNO
        {
            get
            {
                return this._ctno;
            }
            set
            {
                if ((_ctno != value))
                {
                    this.OnCTNOChanging(value);
                    this.SendPropertyChanging();
                    this._ctno = value;
                    this.SendPropertyChanged("CTNO");
                    this.OnCTNOChanged();
                }
            }
        }

        [Column(Storage = "_parsyscode", Name = "PAR_SYSCODE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PARSYSCODE
        {
            get
            {
                return this._parsyscode;
            }
            set
            {
                if (((_parsyscode == value)
                            == false))
                {
                    this.OnPARSYSCODEChanging(value);
                    this.SendPropertyChanging();
                    this._parsyscode = value;
                    this.SendPropertyChanged("PARSYSCODE");
                    this.OnPARSYSCODEChanged();
                }
            }
        }

        [Column(Storage = "_remark", Name = "REMARK", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string REMARK
        {
            get
            {
                return this._remark;
            }
            set
            {
                if (((_remark == value)
                            == false))
                {
                    this.OnREMARKChanging(value);
                    this.SendPropertyChanging();
                    this._remark = value;
                    this.SendPropertyChanged("REMARK");
                    this.OnREMARKChanged();
                }
            }
        }

        [Column(Storage = "_scname", Name = "SCNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SCNAME
        {
            get
            {
                return this._scname;
            }
            set
            {
                if (((_scname == value)
                            == false))
                {
                    this.OnSCNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._scname = value;
                    this.SendPropertyChanged("SCNAME");
                    this.OnSCNAMEChanged();
                }
            }
        }

        [Column(Storage = "_sid", Name = "SID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int SID
        {
            get
            {
                return this._sid;
            }
            set
            {
                if ((_sid != value))
                {
                    this.OnSIDChanging(value);
                    this.SendPropertyChanging();
                    this._sid = value;
                    this.SendPropertyChanged("SID");
                    this.OnSIDChanged();
                }
            }
        }

        [Column(Storage = "_sortno", Name = "SORTNO", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SORTNO
        {
            get
            {
                return this._sortno;
            }
            set
            {
                if ((_sortno != value))
                {
                    this.OnSORTNOChanging(value);
                    this.SendPropertyChanging();
                    this._sortno = value;
                    this.SendPropertyChanged("SORTNO");
                    this.OnSORTNOChanged();
                }
            }
        }

        [Column(Storage = "_syscode", Name = "SYSCODE", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SYSCODE
        {
            get
            {
                return this._syscode;
            }
            set
            {
                if ((_syscode != value))
                {
                    this.OnSYSCODEChanging(value);
                    this.SendPropertyChanging();
                    this._syscode = value;
                    this.SendPropertyChanged("SYSCODE");
                    this.OnSYSCODEChanged();
                }
            }
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_SYSTEMSWITCH")]
    public partial class EBOXSYSTEMSWITCH : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<int> _pbid;

        private string _sscloseinstructions;

        private string _ssclosename;

        private System.Nullable<System.DateTime> _ssclosetime;

        private System.Nullable<int> _sscloseuid;

        private string _ssclosewhy;

        private int _ssid;

        private string _ssopenname;

        private System.Nullable<System.DateTime> _ssopentime;

        private System.Nullable<int> _ssopenuid;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnPBIDChanged();

        partial void OnPBIDChanging(System.Nullable<int> value);

        partial void OnSSCLOSEINSTRUCTIONSChanged();

        partial void OnSSCLOSEINSTRUCTIONSChanging(string value);

        partial void OnSSCLOSENAMEChanged();

        partial void OnSSCLOSENAMEChanging(string value);

        partial void OnSSCLOSETIMEChanged();

        partial void OnSSCLOSETIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnSSCLOSEUIDChanged();

        partial void OnSSCLOSEUIDChanging(System.Nullable<int> value);

        partial void OnSSCLOSEWHYChanged();

        partial void OnSSCLOSEWHYChanging(string value);

        partial void OnSSIDChanged();

        partial void OnSSIDChanging(int value);

        partial void OnSSOPENNAMEChanged();

        partial void OnSSOPENNAMEChanging(string value);

        partial void OnSSOPENTIMEChanged();

        partial void OnSSOPENTIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnSSOPENUIDChanged();

        partial void OnSSOPENUIDChanging(System.Nullable<int> value);
        #endregion


        public EBOXSYSTEMSWITCH()
        {
            this.OnCreated();
        }

        [Column(Storage = "_pbid", Name = "PB_ID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBID
        {
            get
            {
                return this._pbid;
            }
            set
            {
                if ((_pbid != value))
                {
                    this.OnPBIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbid = value;
                    this.SendPropertyChanged("PBID");
                    this.OnPBIDChanged();
                }
            }
        }

        [Column(Storage = "_sscloseinstructions", Name = "SS_CLOSEINSTRUCTIONS", DbType = "VARCHAR(500)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SSCLOSEINSTRUCTIONS
        {
            get
            {
                return this._sscloseinstructions;
            }
            set
            {
                if (((_sscloseinstructions == value)
                            == false))
                {
                    this.OnSSCLOSEINSTRUCTIONSChanging(value);
                    this.SendPropertyChanging();
                    this._sscloseinstructions = value;
                    this.SendPropertyChanged("SSCLOSEINSTRUCTIONS");
                    this.OnSSCLOSEINSTRUCTIONSChanged();
                }
            }
        }

        [Column(Storage = "_ssclosename", Name = "SS_CLOSENAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SSCLOSENAME
        {
            get
            {
                return this._ssclosename;
            }
            set
            {
                if (((_ssclosename == value)
                            == false))
                {
                    this.OnSSCLOSENAMEChanging(value);
                    this.SendPropertyChanging();
                    this._ssclosename = value;
                    this.SendPropertyChanged("SSCLOSENAME");
                    this.OnSSCLOSENAMEChanged();
                }
            }
        }

        [Column(Storage = "_ssclosetime", Name = "SS_CLOSETIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> SSCLOSETIME
        {
            get
            {
                return this._ssclosetime;
            }
            set
            {
                if ((_ssclosetime != value))
                {
                    this.OnSSCLOSETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._ssclosetime = value;
                    this.SendPropertyChanged("SSCLOSETIME");
                    this.OnSSCLOSETIMEChanged();
                }
            }
        }

        [Column(Storage = "_sscloseuid", Name = "SS_CLOSEUID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SSCLOSEUID
        {
            get
            {
                return this._sscloseuid;
            }
            set
            {
                if ((_sscloseuid != value))
                {
                    this.OnSSCLOSEUIDChanging(value);
                    this.SendPropertyChanging();
                    this._sscloseuid = value;
                    this.SendPropertyChanged("SSCLOSEUID");
                    this.OnSSCLOSEUIDChanged();
                }
            }
        }

        [Column(Storage = "_ssclosewhy", Name = "SS_CLOSEWHY", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SSCLOSEWHY
        {
            get
            {
                return this._ssclosewhy;
            }
            set
            {
                if (((_ssclosewhy == value)
                            == false))
                {
                    this.OnSSCLOSEWHYChanging(value);
                    this.SendPropertyChanging();
                    this._ssclosewhy = value;
                    this.SendPropertyChanged("SSCLOSEWHY");
                    this.OnSSCLOSEWHYChanged();
                }
            }
        }

        [Column(Storage = "_ssid", Name = "SS_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int SSID
        {
            get
            {
                return this._ssid;
            }
            set
            {
                if ((_ssid != value))
                {
                    this.OnSSIDChanging(value);
                    this.SendPropertyChanging();
                    this._ssid = value;
                    this.SendPropertyChanged("SSID");
                    this.OnSSIDChanged();
                }
            }
        }

        [Column(Storage = "_ssopenname", Name = "SS_OPENNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SSOPENNAME
        {
            get
            {
                return this._ssopenname;
            }
            set
            {
                if (((_ssopenname == value)
                            == false))
                {
                    this.OnSSOPENNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._ssopenname = value;
                    this.SendPropertyChanged("SSOPENNAME");
                    this.OnSSOPENNAMEChanged();
                }
            }
        }

        [Column(Storage = "_ssopentime", Name = "SS_OPENTIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> SSOPENTIME
        {
            get
            {
                return this._ssopentime;
            }
            set
            {
                if ((_ssopentime != value))
                {
                    this.OnSSOPENTIMEChanging(value);
                    this.SendPropertyChanging();
                    this._ssopentime = value;
                    this.SendPropertyChanged("SSOPENTIME");
                    this.OnSSOPENTIMEChanged();
                }
            }
        }

        [Column(Storage = "_ssopenuid", Name = "SS_OPENUID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SSOPENUID
        {
            get
            {
                return this._ssopenuid;
            }
            set
            {
                if ((_ssopenuid != value))
                {
                    this.OnSSOPENUIDChanging(value);
                    this.SendPropertyChanging();
                    this._ssopenuid = value;
                    this.SendPropertyChanged("SSOPENUID");
                    this.OnSSOPENUIDChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_SYS_VERSION")]
    public partial class EBOXSYSVERSION : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _svcopyright;

        private System.Nullable<int> _svcount;

        private System.Nullable<System.DateTime> _svdate;

        private int _svid;

        private string _svmainversion;

        private System.Nullable<sbyte> _svstatus;

        private string _svsubversion;

        private string _svsysno;

        private string _svversionbatch;

        private string _svwebsite;

        private string _svfilesize;

        private string _svvalidatecode;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnSVCOPYRIGHTChanged();

        partial void OnSVCOPYRIGHTChanging(string value);

        partial void OnSVCOUNTChanged();

        partial void OnSVCOUNTChanging(System.Nullable<int> value);

        partial void OnSVDATEChanged();

        partial void OnSVDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnSVIDChanged();

        partial void OnSVIDChanging(int value);

        partial void OnSVMAINVERSIONChanged();

        partial void OnSVMAINVERSIONChanging(string value);

        partial void OnSVSTATUSChanged();

        partial void OnSVSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnSVSUBVERSIONChanged();

        partial void OnSVSUBVERSIONChanging(string value);

        partial void OnSVSYSNOChanged();

        partial void OnSVSYSNOChanging(string value);

        partial void OnSVVERSIONBATCHChanged();

        partial void OnSVVERSIONBATCHChanging(string value);

        partial void OnSVWEBSITEChanged();

        partial void OnSVWEBSITEChanging(string value);
        #endregion


        public EBOXSYSVERSION()
        {
            this.OnCreated();
        }

        [Column(Storage = "_svcopyright", Name = "SV_COPYRIGHT", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SVCOPYRIGHT
        {
            get
            {
                return this._svcopyright;
            }
            set
            {
                if (((_svcopyright == value)
                            == false))
                {
                    this.OnSVCOPYRIGHTChanging(value);
                    this.SendPropertyChanging();
                    this._svcopyright = value;
                    this.SendPropertyChanged("SVCOPYRIGHT");
                    this.OnSVCOPYRIGHTChanged();
                }
            }
        }

        [Column(Storage = "_svcount", Name = "SV_COUNT", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> SVCOUNT
        {
            get
            {
                return this._svcount;
            }
            set
            {
                if ((_svcount != value))
                {
                    this.OnSVCOUNTChanging(value);
                    this.SendPropertyChanging();
                    this._svcount = value;
                    this.SendPropertyChanged("SVCOUNT");
                    this.OnSVCOUNTChanged();
                }
            }
        }

        [Column(Storage = "_svdate", Name = "SV_DATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> SVDATE
        {
            get
            {
                return this._svdate;
            }
            set
            {
                if ((_svdate != value))
                {
                    this.OnSVDATEChanging(value);
                    this.SendPropertyChanging();
                    this._svdate = value;
                    this.SendPropertyChanged("SVDATE");
                    this.OnSVDATEChanged();
                }
            }
        }

        [Column(Storage = "_svid", Name = "SV_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int SVID
        {
            get
            {
                return this._svid;
            }
            set
            {
                if ((_svid != value))
                {
                    this.OnSVIDChanging(value);
                    this.SendPropertyChanging();
                    this._svid = value;
                    this.SendPropertyChanged("SVID");
                    this.OnSVIDChanged();
                }
            }
        }

        [Column(Storage = "_svmainversion", Name = "SV_MAINVERSION", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SVMAINVERSION
        {
            get
            {
                return this._svmainversion;
            }
            set
            {
                if (((_svmainversion == value)
                            == false))
                {
                    this.OnSVMAINVERSIONChanging(value);
                    this.SendPropertyChanging();
                    this._svmainversion = value;
                    this.SendPropertyChanged("SVMAINVERSION");
                    this.OnSVMAINVERSIONChanged();
                }
            }
        }

        [Column(Storage = "_svstatus", Name = "SV_STATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> SVSTATUS
        {
            get
            {
                return this._svstatus;
            }
            set
            {
                if ((_svstatus != value))
                {
                    this.OnSVSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._svstatus = value;
                    this.SendPropertyChanged("SVSTATUS");
                    this.OnSVSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_svfilesize", Name = "sv_filesize", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SVFILESIZE
        {
            get
            {
                return this._svfilesize;
            }
            set
            {
                if (((_svfilesize == value)
                            == false))
                {
                    this.OnSVMAINVERSIONChanging(value);
                    this.SendPropertyChanging();
                    this._svfilesize = value;
                    this.SendPropertyChanged("SVFILESIZE");
                    this.OnSVMAINVERSIONChanged();
                }
            }
        }

        [Column(Storage = "_svvalidatecode", Name = "SV_VALIDATECODE", DbType = "VARCHAR(500)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SVVALIDATECODE
        {
            get
            {
                return this._svvalidatecode;
            }
            set
            {
                if (((_svvalidatecode == value)
                            == false))
                {
                    this.OnSVMAINVERSIONChanging(value);
                    this.SendPropertyChanging();
                    this._svvalidatecode = value;
                    this.SendPropertyChanged("SVFILESIZE");
                    this.OnSVMAINVERSIONChanged();
                }
            }
        }

        [Column(Storage = "_svsubversion", Name = "SV_SUBVERSION", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SVSUBVERSION
        {
            get
            {
                return this._svsubversion;
            }
            set
            {
                if (((_svsubversion == value)
                            == false))
                {
                    this.OnSVSUBVERSIONChanging(value);
                    this.SendPropertyChanging();
                    this._svsubversion = value;
                    this.SendPropertyChanged("SVSUBVERSION");
                    this.OnSVSUBVERSIONChanged();
                }
            }
        }

        [Column(Storage = "_svsysno", Name = "SV_SYSNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SVSYSNO
        {
            get
            {
                return this._svsysno;
            }
            set
            {
                if (((_svsysno == value)
                            == false))
                {
                    this.OnSVSYSNOChanging(value);
                    this.SendPropertyChanging();
                    this._svsysno = value;
                    this.SendPropertyChanged("SVSYSNO");
                    this.OnSVSYSNOChanged();
                }
            }
        }

        [Column(Storage = "_svversionbatch", Name = "SV_VERSIONBATCH", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SVVERSIONBATCH
        {
            get
            {
                return this._svversionbatch;
            }
            set
            {
                if (((_svversionbatch == value)
                            == false))
                {
                    this.OnSVVERSIONBATCHChanging(value);
                    this.SendPropertyChanging();
                    this._svversionbatch = value;
                    this.SendPropertyChanged("SVVERSIONBATCH");
                    this.OnSVVERSIONBATCHChanged();
                }
            }
        }

        [Column(Storage = "_svwebsite", Name = "SV_WEBSITE", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SVWEBSITE
        {
            get
            {
                return this._svwebsite;
            }
            set
            {
                if (((_svwebsite == value)
                            == false))
                {
                    this.OnSVWEBSITEChanging(value);
                    this.SendPropertyChanging();
                    this._svwebsite = value;
                    this.SendPropertyChanged("SVWEBSITE");
                    this.OnSVWEBSITEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_USERLOGINLOG")]
    public partial class EBOXUSERLOGINLOG : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _ulid;

        private string _ulloginaddress;

        private string _ulloginip;

        private System.Nullable<sbyte> _ulloginmode;

        private System.Nullable<System.DateTime> _ullogintime;

        private System.Nullable<System.DateTime> _ullogouttime;

        private string _ulpboxno;

        private System.Nullable<int> _uluserid;

        private string _ulusername;

        private System.Nullable<sbyte> _ulusertype;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnULIDChanged();

        partial void OnULIDChanging(int value);

        partial void OnULLOGINADDRESSChanged();

        partial void OnULLOGINADDRESSChanging(string value);

        partial void OnULLOGINIPChanged();

        partial void OnULLOGINIPChanging(string value);

        partial void OnULLOGINMODEChanged();

        partial void OnULLOGINMODEChanging(System.Nullable<sbyte> value);

        partial void OnULLOGINTIMEChanged();

        partial void OnULLOGINTIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnULLOGOUTTIMEChanged();

        partial void OnULLOGOUTTIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnULPBOXNOChanged();

        partial void OnULPBOXNOChanging(string value);

        partial void OnULUSERIDChanged();

        partial void OnULUSERIDChanging(System.Nullable<int> value);

        partial void OnULUSERNAMEChanged();

        partial void OnULUSERNAMEChanging(string value);

        partial void OnULUSERTYPEChanged();

        partial void OnULUSERTYPEChanging(System.Nullable<sbyte> value);
        #endregion


        public EBOXUSERLOGINLOG()
        {
            this.OnCreated();
        }

        [Column(Storage = "_ulid", Name = "UL_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ULID
        {
            get
            {
                return this._ulid;
            }
            set
            {
                if ((_ulid != value))
                {
                    this.OnULIDChanging(value);
                    this.SendPropertyChanging();
                    this._ulid = value;
                    this.SendPropertyChanged("ULID");
                    this.OnULIDChanged();
                }
            }
        }

        [Column(Storage = "_ulloginaddress", Name = "UL_LOGINADDRESS", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ULLOGINADDRESS
        {
            get
            {
                return this._ulloginaddress;
            }
            set
            {
                if (((_ulloginaddress == value)
                            == false))
                {
                    this.OnULLOGINADDRESSChanging(value);
                    this.SendPropertyChanging();
                    this._ulloginaddress = value;
                    this.SendPropertyChanged("ULLOGINADDRESS");
                    this.OnULLOGINADDRESSChanged();
                }
            }
        }

        [Column(Storage = "_ulloginip", Name = "UL_LOGINIP", DbType = "VARCHAR(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ULLOGINIP
        {
            get
            {
                return this._ulloginip;
            }
            set
            {
                if (((_ulloginip == value)
                            == false))
                {
                    this.OnULLOGINIPChanging(value);
                    this.SendPropertyChanging();
                    this._ulloginip = value;
                    this.SendPropertyChanged("ULLOGINIP");
                    this.OnULLOGINIPChanged();
                }
            }
        }

        [Column(Storage = "_ulloginmode", Name = "UL_LOGINMODE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> ULLOGINMODE
        {
            get
            {
                return this._ulloginmode;
            }
            set
            {
                if ((_ulloginmode != value))
                {
                    this.OnULLOGINMODEChanging(value);
                    this.SendPropertyChanging();
                    this._ulloginmode = value;
                    this.SendPropertyChanged("ULLOGINMODE");
                    this.OnULLOGINMODEChanged();
                }
            }
        }

        [Column(Storage = "_ullogintime", Name = "UL_LOGINTIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> ULLOGINTIME
        {
            get
            {
                return this._ullogintime;
            }
            set
            {
                if ((_ullogintime != value))
                {
                    this.OnULLOGINTIMEChanging(value);
                    this.SendPropertyChanging();
                    this._ullogintime = value;
                    this.SendPropertyChanged("ULLOGINTIME");
                    this.OnULLOGINTIMEChanged();
                }
            }
        }

        [Column(Storage = "_ullogouttime", Name = "UL_LOGOUTTIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> ULLOGOUTTIME
        {
            get
            {
                return this._ullogouttime;
            }
            set
            {
                if ((_ullogouttime != value))
                {
                    this.OnULLOGOUTTIMEChanging(value);
                    this.SendPropertyChanging();
                    this._ullogouttime = value;
                    this.SendPropertyChanged("ULLOGOUTTIME");
                    this.OnULLOGOUTTIMEChanged();
                }
            }
        }

        [Column(Storage = "_ulpboxno", Name = "UL_PBOXNO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ULPBOXNO
        {
            get
            {
                return this._ulpboxno;
            }
            set
            {
                if (((_ulpboxno == value)
                            == false))
                {
                    this.OnULPBOXNOChanging(value);
                    this.SendPropertyChanging();
                    this._ulpboxno = value;
                    this.SendPropertyChanged("ULPBOXNO");
                    this.OnULPBOXNOChanged();
                }
            }
        }

        [Column(Storage = "_uluserid", Name = "UL_USERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> ULUSERID
        {
            get
            {
                return this._uluserid;
            }
            set
            {
                if ((_uluserid != value))
                {
                    this.OnULUSERIDChanging(value);
                    this.SendPropertyChanging();
                    this._uluserid = value;
                    this.SendPropertyChanged("ULUSERID");
                    this.OnULUSERIDChanged();
                }
            }
        }

        [Column(Storage = "_ulusername", Name = "UL_USERNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ULUSERNAME
        {
            get
            {
                return this._ulusername;
            }
            set
            {
                if (((_ulusername == value)
                            == false))
                {
                    this.OnULUSERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._ulusername = value;
                    this.SendPropertyChanged("ULUSERNAME");
                    this.OnULUSERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_ulusertype", Name = "UL_USERTYPE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> ULUSERTYPE
        {
            get
            {
                return this._ulusertype;
            }
            set
            {
                if ((_ulusertype != value))
                {
                    this.OnULUSERTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._ulusertype = value;
                    this.SendPropertyChanged("ULUSERTYPE");
                    this.OnULUSERTYPEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_USEROPTLOG")]
    public partial class EBOXUSEROPTLOG : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<int> _pbid;

        private System.Nullable<int> _uobuzinlet;

        private int _uoid;

        private string _uoinstructions;

        private System.Nullable<sbyte> _uomode;

        private System.Nullable<int> _uooperationsgroup;

        private System.Nullable<int> _uooperatorid;

        private string _uooperatorname;

        private System.Nullable<System.DateTime> _uooperatortime;

        private string _uooperatortype;

        private System.Nullable<sbyte> _uoresults;

        private System.Nullable<int> _uosequence;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnPBIDChanged();

        partial void OnPBIDChanging(System.Nullable<int> value);

        partial void OnUOBUZINLETChanged();

        partial void OnUOBUZINLETChanging(System.Nullable<int> value);

        partial void OnUOIDChanged();

        partial void OnUOIDChanging(int value);

        partial void OnUOINSTRUCTIONSChanged();

        partial void OnUOINSTRUCTIONSChanging(string value);

        partial void OnUOMODEChanged();

        partial void OnUOMODEChanging(System.Nullable<sbyte> value);

        partial void OnUOOPERATIONSGROUPChanged();

        partial void OnUOOPERATIONSGROUPChanging(System.Nullable<int> value);

        partial void OnUOOPERATORIDChanged();

        partial void OnUOOPERATORIDChanging(System.Nullable<int> value);

        partial void OnUOOPERATORNAMEChanged();

        partial void OnUOOPERATORNAMEChanging(string value);

        partial void OnUOOPERATORTIMEChanged();

        partial void OnUOOPERATORTIMEChanging(System.Nullable<System.DateTime> value);

        partial void OnUOOPERATORTYPEChanged();

        partial void OnUOOPERATORTYPEChanging(string value);

        partial void OnUORESULTSChanged();

        partial void OnUORESULTSChanging(System.Nullable<sbyte> value);

        partial void OnUOSEQUENCEChanged();

        partial void OnUOSEQUENCEChanging(System.Nullable<int> value);
        #endregion


        public EBOXUSEROPTLOG()
        {
            this.OnCreated();
        }

        [Column(Storage = "_pbid", Name = "PB_ID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> PBID
        {
            get
            {
                return this._pbid;
            }
            set
            {
                if ((_pbid != value))
                {
                    this.OnPBIDChanging(value);
                    this.SendPropertyChanging();
                    this._pbid = value;
                    this.SendPropertyChanged("PBID");
                    this.OnPBIDChanged();
                }
            }
        }

        [Column(Storage = "_uobuzinlet", Name = "UO_BUZINLET", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> UOBUZINLET
        {
            get
            {
                return this._uobuzinlet;
            }
            set
            {
                if ((_uobuzinlet != value))
                {
                    this.OnUOBUZINLETChanging(value);
                    this.SendPropertyChanging();
                    this._uobuzinlet = value;
                    this.SendPropertyChanged("UOBUZINLET");
                    this.OnUOBUZINLETChanged();
                }
            }
        }

        [Column(Storage = "_uoid", Name = "UO_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int UOID
        {
            get
            {
                return this._uoid;
            }
            set
            {
                if ((_uoid != value))
                {
                    this.OnUOIDChanging(value);
                    this.SendPropertyChanging();
                    this._uoid = value;
                    this.SendPropertyChanged("UOID");
                    this.OnUOIDChanged();
                }
            }
        }

        [Column(Storage = "_uoinstructions", Name = "UO_INSTRUCTIONS", DbType = "VARCHAR(500)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string UOINSTRUCTIONS
        {
            get
            {
                return this._uoinstructions;
            }
            set
            {
                if (((_uoinstructions == value)
                            == false))
                {
                    this.OnUOINSTRUCTIONSChanging(value);
                    this.SendPropertyChanging();
                    this._uoinstructions = value;
                    this.SendPropertyChanged("UOINSTRUCTIONS");
                    this.OnUOINSTRUCTIONSChanged();
                }
            }
        }

        [Column(Storage = "_uomode", Name = "UO_MODE", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> UOMODE
        {
            get
            {
                return this._uomode;
            }
            set
            {
                if ((_uomode != value))
                {
                    this.OnUOMODEChanging(value);
                    this.SendPropertyChanging();
                    this._uomode = value;
                    this.SendPropertyChanged("UOMODE");
                    this.OnUOMODEChanged();
                }
            }
        }

        [Column(Storage = "_uooperationsgroup", Name = "UO_OPERATIONSGROUP", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> UOOPERATIONSGROUP
        {
            get
            {
                return this._uooperationsgroup;
            }
            set
            {
                if ((_uooperationsgroup != value))
                {
                    this.OnUOOPERATIONSGROUPChanging(value);
                    this.SendPropertyChanging();
                    this._uooperationsgroup = value;
                    this.SendPropertyChanged("UOOPERATIONSGROUP");
                    this.OnUOOPERATIONSGROUPChanged();
                }
            }
        }

        [Column(Storage = "_uooperatorid", Name = "UO_OPERATORID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> UOOPERATORID
        {
            get
            {
                return this._uooperatorid;
            }
            set
            {
                if ((_uooperatorid != value))
                {
                    this.OnUOOPERATORIDChanging(value);
                    this.SendPropertyChanging();
                    this._uooperatorid = value;
                    this.SendPropertyChanged("UOOPERATORID");
                    this.OnUOOPERATORIDChanged();
                }
            }
        }

        [Column(Storage = "_uooperatorname", Name = "UO_OPERATORNAME", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string UOOPERATORNAME
        {
            get
            {
                return this._uooperatorname;
            }
            set
            {
                if (((_uooperatorname == value)
                            == false))
                {
                    this.OnUOOPERATORNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._uooperatorname = value;
                    this.SendPropertyChanged("UOOPERATORNAME");
                    this.OnUOOPERATORNAMEChanged();
                }
            }
        }

        [Column(Storage = "_uooperatortime", Name = "UO_OPERATORTIME", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> UOOPERATORTIME
        {
            get
            {
                return this._uooperatortime;
            }
            set
            {
                if ((_uooperatortime != value))
                {
                    this.OnUOOPERATORTIMEChanging(value);
                    this.SendPropertyChanging();
                    this._uooperatortime = value;
                    this.SendPropertyChanged("UOOPERATORTIME");
                    this.OnUOOPERATORTIMEChanged();
                }
            }
        }

        [Column(Storage = "_uooperatortype", Name = "UO_OPERATORTYPE", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string UOOPERATORTYPE
        {
            get
            {
                return this._uooperatortype;
            }
            set
            {
                if (((_uooperatortype == value)
                            == false))
                {
                    this.OnUOOPERATORTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._uooperatortype = value;
                    this.SendPropertyChanged("UOOPERATORTYPE");
                    this.OnUOOPERATORTYPEChanged();
                }
            }
        }

        [Column(Storage = "_uoresults", Name = "UO_RESULTS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> UORESULTS
        {
            get
            {
                return this._uoresults;
            }
            set
            {
                if ((_uoresults != value))
                {
                    this.OnUORESULTSChanging(value);
                    this.SendPropertyChanging();
                    this._uoresults = value;
                    this.SendPropertyChanged("UORESULTS");
                    this.OnUORESULTSChanged();
                }
            }
        }

        [Column(Storage = "_uosequence", Name = "UO_SEQUENCE", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> UOSEQUENCE
        {
            get
            {
                return this._uosequence;
            }
            set
            {
                if ((_uosequence != value))
                {
                    this.OnUOSEQUENCEChanging(value);
                    this.SendPropertyChanging();
                    this._uosequence = value;
                    this.SendPropertyChanged("UOSEQUENCE");
                    this.OnUOSEQUENCEChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "main.EBOX_USER_PROTOCOL")]
    public partial class EBOXUSERPROTOCOL : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<double> _tfbackupfield1;

        private string _tfbackupfield2;

        private System.Nullable<System.DateTime> _tfbackupfield3;

        private System.Nullable<sbyte> _tfbuzstatus;

        private System.Nullable<System.DateTime> _tfcreatedate;

        private System.Nullable<int> _tfcreaterid;

        private string _tfcreatername;

        private System.Nullable<sbyte> _tfdeleteflag;

        private System.Nullable<System.DateTime> _tfupdatedate;

        private System.Nullable<int> _tfupdaterid;

        private string _tfupdatername;

        private string _upcontent;

        private int _upid;

        private string _upno;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnTFBACKUPFIELD1Changed();

        partial void OnTFBACKUPFIELD1Changing(System.Nullable<double> value);

        partial void OnTFBACKUPFIELD2Changed();

        partial void OnTFBACKUPFIELD2Changing(string value);

        partial void OnTFBACKUPFIELD3Changed();

        partial void OnTFBACKUPFIELD3Changing(System.Nullable<System.DateTime> value);

        partial void OnTFBUZSTATUSChanged();

        partial void OnTFBUZSTATUSChanging(System.Nullable<sbyte> value);

        partial void OnTFCREATEDATEChanged();

        partial void OnTFCREATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFCREATERIDChanged();

        partial void OnTFCREATERIDChanging(System.Nullable<int> value);

        partial void OnTFCREATERNAMEChanged();

        partial void OnTFCREATERNAMEChanging(string value);

        partial void OnTFDELETEFLAGChanged();

        partial void OnTFDELETEFLAGChanging(System.Nullable<sbyte> value);

        partial void OnTFUPDATEDATEChanged();

        partial void OnTFUPDATEDATEChanging(System.Nullable<System.DateTime> value);

        partial void OnTFUPDATERIDChanged();

        partial void OnTFUPDATERIDChanging(System.Nullable<int> value);

        partial void OnTFUPDATERNAMEChanged();

        partial void OnTFUPDATERNAMEChanging(string value);

        partial void OnUPCONTENTChanged();

        partial void OnUPCONTENTChanging(string value);

        partial void OnUPIDChanged();

        partial void OnUPIDChanging(int value);

        partial void OnUPNOChanged();

        partial void OnUPNOChanging(string value);
        #endregion


        public EBOXUSERPROTOCOL()
        {
            this.OnCreated();
        }

        [Column(Storage = "_tfbackupfield1", Name = "TF_BACKUPFIELD1", DbType = "DOUBLE(10,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<double> TFBACKUPFIELD1
        {
            get
            {
                return this._tfbackupfield1;
            }
            set
            {
                if ((_tfbackupfield1 != value))
                {
                    this.OnTFBACKUPFIELD1Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield1 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD1");
                    this.OnTFBACKUPFIELD1Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield2", Name = "TF_BACKUPFIELD2", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFBACKUPFIELD2
        {
            get
            {
                return this._tfbackupfield2;
            }
            set
            {
                if (((_tfbackupfield2 == value)
                            == false))
                {
                    this.OnTFBACKUPFIELD2Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield2 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD2");
                    this.OnTFBACKUPFIELD2Changed();
                }
            }
        }

        [Column(Storage = "_tfbackupfield3", Name = "TF_BACKUPFIELD3", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFBACKUPFIELD3
        {
            get
            {
                return this._tfbackupfield3;
            }
            set
            {
                if ((_tfbackupfield3 != value))
                {
                    this.OnTFBACKUPFIELD3Changing(value);
                    this.SendPropertyChanging();
                    this._tfbackupfield3 = value;
                    this.SendPropertyChanged("TFBACKUPFIELD3");
                    this.OnTFBACKUPFIELD3Changed();
                }
            }
        }

        [Column(Storage = "_tfbuzstatus", Name = "TF_BUZSTATUS", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFBUZSTATUS
        {
            get
            {
                return this._tfbuzstatus;
            }
            set
            {
                if ((_tfbuzstatus != value))
                {
                    this.OnTFBUZSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._tfbuzstatus = value;
                    this.SendPropertyChanged("TFBUZSTATUS");
                    this.OnTFBUZSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatedate", Name = "TF_CREATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFCREATEDATE
        {
            get
            {
                return this._tfcreatedate;
            }
            set
            {
                if ((_tfcreatedate != value))
                {
                    this.OnTFCREATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatedate = value;
                    this.SendPropertyChanged("TFCREATEDATE");
                    this.OnTFCREATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfcreaterid", Name = "TF_CREATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFCREATERID
        {
            get
            {
                return this._tfcreaterid;
            }
            set
            {
                if ((_tfcreaterid != value))
                {
                    this.OnTFCREATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreaterid = value;
                    this.SendPropertyChanged("TFCREATERID");
                    this.OnTFCREATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfcreatername", Name = "TF_CREATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFCREATERNAME
        {
            get
            {
                return this._tfcreatername;
            }
            set
            {
                if (((_tfcreatername == value)
                            == false))
                {
                    this.OnTFCREATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfcreatername = value;
                    this.SendPropertyChanged("TFCREATERNAME");
                    this.OnTFCREATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_tfdeleteflag", Name = "TF_DELETEFLAG", DbType = "TINYINT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> TFDELETEFLAG
        {
            get
            {
                return this._tfdeleteflag;
            }
            set
            {
                if ((_tfdeleteflag != value))
                {
                    this.OnTFDELETEFLAGChanging(value);
                    this.SendPropertyChanging();
                    this._tfdeleteflag = value;
                    this.SendPropertyChanged("TFDELETEFLAG");
                    this.OnTFDELETEFLAGChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatedate", Name = "TF_UPDATEDATE", DbType = "DATETIME", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> TFUPDATEDATE
        {
            get
            {
                return this._tfupdatedate;
            }
            set
            {
                if ((_tfupdatedate != value))
                {
                    this.OnTFUPDATEDATEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatedate = value;
                    this.SendPropertyChanged("TFUPDATEDATE");
                    this.OnTFUPDATEDATEChanged();
                }
            }
        }

        [Column(Storage = "_tfupdaterid", Name = "TF_UPDATERID", DbType = "INT", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> TFUPDATERID
        {
            get
            {
                return this._tfupdaterid;
            }
            set
            {
                if ((_tfupdaterid != value))
                {
                    this.OnTFUPDATERIDChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdaterid = value;
                    this.SendPropertyChanged("TFUPDATERID");
                    this.OnTFUPDATERIDChanged();
                }
            }
        }

        [Column(Storage = "_tfupdatername", Name = "TF_UPDATERNAME", DbType = "VARCHAR(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string TFUPDATERNAME
        {
            get
            {
                return this._tfupdatername;
            }
            set
            {
                if (((_tfupdatername == value)
                            == false))
                {
                    this.OnTFUPDATERNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._tfupdatername = value;
                    this.SendPropertyChanged("TFUPDATERNAME");
                    this.OnTFUPDATERNAMEChanged();
                }
            }
        }

        [Column(Storage = "_upcontent", Name = "UP_CONTENT", DbType = "VARCHAR(4000)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string UPCONTENT
        {
            get
            {
                return this._upcontent;
            }
            set
            {
                if (((_upcontent == value)
                            == false))
                {
                    this.OnUPCONTENTChanging(value);
                    this.SendPropertyChanging();
                    this._upcontent = value;
                    this.SendPropertyChanged("UPCONTENT");
                    this.OnUPCONTENTChanged();
                }
            }
        }

        [Column(Storage = "_upid", Name = "UP_ID", DbType = "INT", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int UPID
        {
            get
            {
                return this._upid;
            }
            set
            {
                if ((_upid != value))
                {
                    this.OnUPIDChanging(value);
                    this.SendPropertyChanging();
                    this._upid = value;
                    this.SendPropertyChanged("UPID");
                    this.OnUPIDChanged();
                }
            }
        }

        [Column(Storage = "_upno", Name = "UP_NO", DbType = "VARCHAR(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string UPNO
        {
            get
            {
                return this._upno;
            }
            set
            {
                if (((_upno == value)
                            == false))
                {
                    this.OnUPNOChanging(value);
                    this.SendPropertyChanging();
                    this._upno = value;
                    this.SendPropertyChanged("UPNO");
                    this.OnUPNOChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
