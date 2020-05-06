using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    public static class DictionaryStatic
    {
        public static Dictionary<int, string> ProgramTypesDictionary => new Dictionary<int, string>
        {
            {(int)ESqlType.Cursor, "Cursor"},
            {(int)ESqlType.Function, "Function"},
            {(int)ESqlType.Procedure, "Procedure"}
        };
    }
}
