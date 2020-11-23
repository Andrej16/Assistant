using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace MtsbuDictionaryUpdater
{
    public class DatabaseManager : IDisposable
    {
        private OracleCommand command;
        private bool IsFunction;
        private OracleConnection connection;
        private readonly string oraConStr;
        private Dictionary<string, OracleCommand> commands;
        public DatabaseManager()
        {
            //Prod 5
            //oraConStr = "Data Source=hercules.ingo.office:1521/insbcp.ingo.office;Persist Security Info=True;User ID=Insuradm;Password=AisIngo";
            //Test
            oraConStr = @"Data Source=dboracledev.ingo.office:1521/insbcp;Persist Security Info=True;User ID=INSURADM;Password=AisIngo";
            oraConStr = ConfigurationManager.ConnectionStrings["Failover"].ConnectionString;
            connection = new OracleConnection(oraConStr);
            connection.Open();

            commands = new Dictionary<string, OracleCommand>();
        }
        private void PrepareCommand(string prog, bool trans = false)
        {
            if (commands.ContainsKey(prog))
                commands.TryGetValue(prog, out command);
            else
            {
                command = new OracleCommand(prog, connection);
                command.CommandType = CommandType.StoredProcedure;

                OracleCommandBuilder.DeriveParameters(command);
                commands.Add(prog, command);
                IsFunction = command.Parameters[0].Direction == ParameterDirection.ReturnValue;
            }
            if (trans)
                command.Transaction = connection.BeginTransaction();
        }
        private void SetParams(Dictionary<string, object> parameters)
        {
            try
            {
                foreach (var p in parameters)
                    command.Parameters[p.Key].Value = p.Value;
            }
            catch (Exception e)
            {
                Log.Add(e);
            }
        }
        public object Execute(string progName, params object[] values)
        {
            int p;

            try
            {
                PrepareCommand(progName, true);

                p = IsFunction ? 1 : 0;

                for (int s = 0; s < values.Length; s++, p++)
                    command.Parameters[p].Value = values[s];

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                command.Transaction.Rollback();
                Log.Add(ex);
            }
            finally
            {
                command.Transaction.Commit();
                connection.Close();
            }

            return IsFunction ? command.Parameters[0].Value : null;
        }
        public object Update(string progName, Dictionary<string, object> parameters)
        {
            object retval = null;
            try
            {
                PrepareCommand(progName, true);

                SetParams(parameters);

                command.ExecuteNonQuery();

                command.Transaction?.Commit();

                retval = IsFunction ? command.Parameters[0].Value : null;
            }
            catch (Exception ex)
            {
                command.Transaction?.Rollback();
                Log.Add(ex);
            }
            return retval;
        }
        ~DatabaseManager()
        {
            Dispose();
        }
        public void Dispose()
        {
            connection?.Dispose();
            command?.Dispose();
        }
    }
}
