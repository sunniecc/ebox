using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Entity
{
    [Serializable]
    public class UserinfoConfig
    {
        private int ucId;

        public int UcId
        {
            get { return ucId; }
            set { ucId = value; }
        }
        private int ucUserId;//用户ID

        public int UcUserId
        {
            get { return ucUserId; }
            set { ucUserId = value; }
        }
        private String ucUserName;//用户姓名

        public String UcUserName
        {
            get { return ucUserName; }
            set { ucUserName = value; }
        }
        private int ucSysKey;//系统常量

        public int UcSysKey
        {
            get { return ucSysKey; }
            set { ucSysKey = value; }
        }
        private String ucSysKeyName;//

        public String UcSysKeyName
        {
            get { return ucSysKeyName; }
            set { ucSysKeyName = value; }
        }
        private int ucSysValue;//系统值

        public int UcSysValue
        {
            get { return ucSysValue; }
            set { ucSysValue = value; }
        }
        private String ucSysValueName;//

        public String UcSysValueName
        {
            get { return ucSysValueName; }
            set { ucSysValueName = value; }
        }
        private String ucSysDesc;//系统描述

        public String UcSysDesc
        {
            get { return ucSysDesc; }
            set { ucSysDesc = value; }
        }
        private String ucValueOne;//配置值一

        public String UcValueOne
        {
            get { return ucValueOne; }
            set { ucValueOne = value; }
        }
        private String ucValueTwo;//配置值二

        public String UcValueTwo
        {
            get { return ucValueTwo; }
            set { ucValueTwo = value; }
        }
        private String ucValueThr;//配置值三

        public String UcValueThr
        {
            get { return ucValueThr; }
            set { ucValueThr = value; }
        }
        private String ucValueFor;//配置值四

        public String UcValueFor
        {
            get { return ucValueFor; }
            set { ucValueFor = value; }
        }
    }
}
