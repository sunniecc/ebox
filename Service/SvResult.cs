using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace EBoxClient
{
    [Serializable]
    public class SvResult
    {
        public string action { get; set; }
        public string type { get; set; }
        public int status { get; set; }
        public object returnValue { get; set; }
    }
}
