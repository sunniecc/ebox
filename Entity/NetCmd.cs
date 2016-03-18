using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Entity
{
    [Serializable]
    public class NetCmd
    {
        public string action { get; set; }
        public string type { get; set; }
        public virtual object parameter { get; set; }

        public virtual string ToJson()
        {
            return JsonHelper.ToJson(this);
        }
    }
}
