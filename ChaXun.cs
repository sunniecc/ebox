using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Utils;


namespace EBoxClient
{
    partial class FrmMain
    {
        public string orderCheckExpress(string barCode, string phone)
        {
            var codes = localData.GetBuzStatusCode();
            var r = localData.orderCheckExpress(barCode, phone).Select(c => new
            {
                barNo = c.EIBARCODE,
                takeUserPhone = c.EITAKEUSERPHONE,
                status = GetStatusCodeName(codes, c.TFBUZSTATUS),
                storeTime = c.EISTORETIME == null ? c.EISTORETIME : string.Empty,
                storeUserName = c.EISTOREUSERNAME,
                storeUserPhone = c.EISTOREUSERPHONE
            }).ToList();
            LogHelper.Log(JsonHelper.ToJson(r));
            return JsonHelper.ToJson(r);

        }

        public string GetStatusCodeName(List<Data.EBOXSYSCODE> codes, int? value)
        {
            var c = codes.FirstOrDefault(s => s.SYSCODE == value);
            return c == null ? string.Empty : c.SCNAME;
        }
    }
}
