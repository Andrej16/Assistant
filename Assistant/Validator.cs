using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    public class Validator
    {
        public static bool IsValidParams(object args)
        {
            foreach (var prop in args.GetType().GetProperties())
            {
                object value = prop.GetValue(args, null);
                if (value is null)
                {
                    return false;
                }

                if (value is string strValue && string.IsNullOrEmpty(strValue))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
