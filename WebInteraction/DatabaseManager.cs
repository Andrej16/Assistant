using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace InvalidPassports
{
    public class DatabaseManager
    {
        private OracleCommand command;
        private bool IsFunction { get; set; }
        private OracleConnection connection;
        private readonly string _connectionString;
        private Dictionary<string, OracleCommand> commands;

        public DatabaseManager(string conStr)
        {
            _connectionString = conStr;
            commands = new Dictionary<string, OracleCommand>();
            connection = new OracleConnection(conStr);
            connection.Open();
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
                //Add to dictionary for reuse
                commands.Add(prog, command);
                //Determinete func(1) or proc(0)
                IsFunction = command.Parameters[0].Direction == ParameterDirection.ReturnValue;
            }
            //Use transaction
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
                Logger.Add(e);
            }
        }
        /// <summary>
        /// Используется для вызова функции или процедуры обновления таблицы.
        /// Первый параметр должен быть IN OUT
        /// </summary>
        /// <example>
        /// var pars = new Dictionary<string, object>() {
        ///        { "p_te_id", 271 },
        ///        { "p_te_parent_id", 123 },
        ///        { "p_te_cod_ibc", 1604 },
        ///        { "p_te_active", "N" }
        ///    };   
        /// res = Convert.ToInt32(dl.Update("pack_dt_types_estate.upd_dt_types_estate", pars));
        /// Console.WriteLine($"Updated row Id = {res}, from table dt_types_estate");
        /// </example>
        /// <param name="progName">Название программы.</param>
        /// <param name="parameters">Коллекция параметров.</param>
        /// <returns>Если функция - ID добавляемой записи, иначе null.</returns>
        public object Update(string progName, Dictionary<string, object> parameters)
        {
            object retval = null;
            try
            {
                PrepareCommand(progName, true);

                SetParams(parameters);

                command.ExecuteNonQuery();

                retval = command.Parameters[0].Value;
            }
            catch (Exception ex)
            {
                command.Transaction?.Rollback();
                Logger.Add(ex);
            }
            finally
            {
                command.Transaction?.Commit();
            }

            return retval;
        }
        /// <summary>
        /// Sets the parameter values according to the values in the row. Call after PrepareCommand!
        /// </summary>
        /// <param name="row"></param>
        private void SetParams(DataRow row)
        {
            int p, countParams = command.Parameters.Count;
            OracleParameter param;
            string fieldName;
            //Determinete func(1) or proc(0)
            p = IsFunction ? 1 : 0;

            for (; p < countParams; p++)
            {
                param = command.Parameters[p];
                //To cut off "i"
                fieldName = param.ParameterName.Substring(1);
                try
                {
                    param.Value = row[fieldName];
                }
                catch { }
            }
        }
        /// <summary>
        /// Execute update program from table.
        /// </summary>
        /// <param name="progName">Name function or procedure.</param>
        /// <param name="table">Table which row must updated.</param>
        /// <returns>Number of rows updated.</returns>
        public int Update(string progName, DataTable table)
        {
            DataTable changesTable = table.GetChanges();

            try
            {
                PrepareCommand(progName, true);

                foreach (DataRow r in changesTable.Rows)
                {
                    SetParams(r);
                    command.ExecuteNonQuery();
                }
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                command.Transaction.Rollback();
                throw ex;
            }

            return changesTable.Rows.Count;
        }
        ~DatabaseManager()
        {
            connection.Close();
        }

    }
}
