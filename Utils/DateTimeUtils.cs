using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Utils
{
    public class DateTimeUtils
    {
        public static string DateTimeString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
