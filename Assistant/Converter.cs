using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    public class Converter
    {
        public static string AsStr(object o)
        {
            return o is DBNull || o == null ? "" : o.ToString();
        }
        public static int AsInt(object o)
        {
            return o is DBNull || o == null ? 0 : Convert.ToInt32(o);
        }
        public static T JsonAsObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static string ObjectAsJson<T>(T content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}
