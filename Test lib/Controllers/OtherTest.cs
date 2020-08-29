using Assistant;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace TestLib.Controllers
{
    public class OtherTest : ITestLib
    {
        public void DoAction()
        {
            throw new NotImplementedException();
        }
        private static void TestRound()
        {
            decimal amt = 56.50M;
            decimal percent = 15M;

            decimal subtrahend = Math.Round(amt * percent / 100, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine($"delim = {subtrahend}");

            decimal newAmt = amt - subtrahend;

            Console.WriteLine($"{amt} - ({amt} * {percent} / 100) = {newAmt}");
        }
        /// <summary>
        /// Формирование кода - запроса в базу данных
        /// </summary>
        /// <param name="progName">Название пакета, процедура. Ex. PkTaskJob.Find</param>
        /// <param name="type">Тип исполняемой комманды. Ex. ESqlType.Function</param>
        /// <returns></returns>
        /// <example>
        /// Console.WriteLine(MakeCode("PkTaskJob.GetById", ESqlType.Function));
        /// </example>
        public static string MakeCode(string progName, ESqlType type)
        {
            string header = "using (Sql sql = new Sql(0, \"Main\", \"@ProgramName\", ESqlType.@Type))\r\n{\r\nusing (Query query = new Query(this))\r\n{\r\n";
            string body = "";
            string footer = "if (query.Run(sql))\r\n{\r\nInit(query.Table);\r\nreturn true;\r\n}\r\n}\r\n}\r\nreturn false;\r\n";

            header = header.Replace("@ProgramName", progName).Replace("@Type", type.ToString());
            string connectionString = "Data Source = 10.44.0.71:1521/insbcp; Persist Security Info = True; User ID = INSURADM; Password = AisIngo";
            OracleConnection cn = new OracleConnection(connectionString);
            cn.Open();
            OracleCommand cmd = new OracleCommand(progName, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleCommandBuilder.DeriveParameters(cmd);
            string parameter = "query.Params.Add(\"@Name\", OracleDbType.@DataType).Value = @Name;";
            foreach (OracleParameter p in cmd.Parameters)
            {
                string temp = parameter.Replace("@Name", p.ParameterName).Replace("@DataType", p.OracleDbType.ToString()) + Environment.NewLine;
                body = string.Concat(body, temp);
            }

            return header + body + footer;
        }

    }

}
