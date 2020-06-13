using System;
using System.IO;
using System.Text;
using StrObjPair = System.Collections.Generic.Dictionary<string, object>;

namespace InvalidPassports
{
    public class Logger
    {
        private static string _LogFileName;
        private static string pathLog;
        static Logger()
        {
            pathLog = @"\\ORION\Install\!CLIENT\AIS\log\";
        }
        /// <summary>
        /// Имя файла логирования
        /// </summary>
        private static string LogFileName
        {
            get
            {
                string f = "{0:D7}_{1}.log";
                string nf = string.Format(f, "ReferenceService", DateTime.Now.ToString("yyyyMMdd_Hmmssfff"));
                while (File.Exists(pathLog + @"\" + nf))
                {
                    nf = string.Format(f, Environment.UserName, DateTime.Now.ToString("yyyyMMdd_Hmmssfff"));
                }
                _LogFileName = nf;
                return pathLog + _LogFileName;
            }
            set
            {
                _LogFileName = value;
            }
        }
        public static void Add(Exception ex, StrObjPair param = null)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Ais others module").Append("\r\n");
            sb.Append(ex.ToString());
            sb.Append(ex.StackTrace).Append("\r\n");

            if (param != null)
                sb.Append(LogParameters(param));

            File.WriteAllText(LogFileName, sb.ToString());
        }
        private static string LogParameters(StrObjPair pars)
        {
            string pStr = "";
            foreach (var kvp in pars)
                pStr += string.Format("{0} => {1}" + Environment.NewLine, kvp.Key, kvp.Value);

            return pStr;
        }
    }
}
