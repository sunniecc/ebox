using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace EBoxClient
{
    public class JsonHelper
    {
        public static string ToJson(object obj)
        {
            var json = string.Empty;
            try
            {
                IsoDateTimeConverter iso = new IsoDateTimeConverter();
                iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

                return JsonConvert.SerializeObject(obj, iso).Replace("\r\n", "");
            }
            catch (Exception ex)
            {
                LogHelper.Log("对象序列化异常1", ex);
            }
            return json;
        }

        public static JObject ToObject(string json)
        {
            JObject obj = default(JObject);
            try
            {
                JObject jsonObj = JObject.Parse(json);
                return jsonObj;

            }
            catch (Exception ex)
            {
                LogHelper.Log("对象序列化异常2,json\n:" + json, ex);
            }
            return obj;
        }

        public static T ToObject<T>(string json) where T : class
        {
            T obj = default(T);
            try
            {
                return JsonConvert.DeserializeObject(json, typeof(T)) as T;
            }
            catch (Exception ex)
            {
                LogHelper.Log("对象序列化异常3,json\n:" + json, ex);
            }
            return obj;
        }
    }
}