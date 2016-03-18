using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Entity
{
    [Serializable]
    public class NCHeartBeat : NetCmd
    {
        //{action:'programOperation',type:'programExit',parameter:{ss:{ssOpenName:'1231',pbId:'11'}}}
        public class item
        {
            public item_item1 ss { get; set; }
        }
        public class item_item1
        {
            public string ssOpenName { get; set; }
            public string pbId { get; set; }
            public string ssId { get; set; }
            public string pbCrtNo { get; set; }
            public string ssCloseTime { get; set; }
            public string ssCloseInstructions { get; set; }
        }
    }
}
