using Oracle.ManagedDataAccess.Client;
using System;

namespace Assistant
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class InfoHelper
    {
        /// <summary>
        /// Расширяющий метод, возвращающий строку с информацией для вызова SQL команды.
        /// </summary>
        /// <param name="cmd">Обьект комманды для которого нужно получить информацию.</param>
        public static string GetInfo(this OracleCommand cmd)
        {
            string info = $"Program called: {cmd.CommandText}" + Environment.NewLine;

            foreach (OracleParameter p in cmd.Parameters)
            {
                string paramValue = p.Value == DBNull.Value ? "<NULL>" : p.Value.ToString();

                info += $"{p.ParameterName} => {paramValue}" + Environment.NewLine;
            }

            return info;
        }
    }
}
