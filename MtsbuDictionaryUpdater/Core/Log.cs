using System;
using System.IO;
using System.Text;

namespace MtsbuDictionaryUpdater
{
    public class Log
    {
        private static string _LogFileName;
        private static string pathLog;
        static Log()
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
                string nf = string.Format(f, "MtsbuDictionaryUpdater", DateTime.Now.ToString("yyyyMMdd_Hmmssfff"));
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
        public static void Add(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Ais others module").Append("\r\n");
            sb.Append(ex.ToString());
            sb.Append(ex.StackTrace).Append("\r\n");

            File.WriteAllText(LogFileName, sb.ToString());
        }
    }
}
