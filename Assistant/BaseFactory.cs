using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Assistant
{
    /// <summary>
    /// Represents a set of command-related properties that are used to fill the DataSet and update a data source, and is implemented by that access relational databases.
    /// </summary>
    public class BaseFactory : IDisposable
    {
        private OracleConnection connection;
        private OracleCommand command;
        private readonly string conStr;
        private bool IsFunction;
        private Dictionary<string, OracleCommand> commands;
        // Для определения избыточных вызовов
        private bool disposedValue = false;
        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~BaseFactory()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //Освободить управляемые ресурсы
                    commands = null;
                }
                //Освободить не управляемые ресурсы
                connection?.Dispose();
                command?.Dispose();

                disposedValue = true;
            }
        }
        #endregion
        /// <summary>
        /// Set connection string according of the base type
        /// </summary>
        /// <param name="dbType">Database type</param>
        public BaseFactory(DbType dbType)
        {
            ConnectionStringSettings settings;

            if (dbType == DbType.Test)
                settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.Test"];
            else
                settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.Work"];

            conStr = settings.ConnectionString;
            connection = new OracleConnection(conStr);
            connection.Open();

            commands = new Dictionary<string, OracleCommand>();
        }
        #region Service methods
        private void CloseConnection()
        {
            connection.Close();
        }
        /// <summary>
        /// Execution of command object preparation.
        /// </summary>
        /// <param name="program">Name function or procedure.</param>
        /// <param name="tranFlag">Necessity create transaction.</param>
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
            if(trans)
                command.Transaction = connection.BeginTransaction();
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
                //To cut off "p_"
                fieldName = param.ParameterName.Substring(2);
                try
                {
                    param.Value = row[fieldName];
                }
                catch { }
            }
        }
        /// <summary>
        /// Sets the parameter values according to the values the passed into func. Call after PrepareCommand!
        /// </summary>
        /// <param name="parsDict">Parameter array</param>
        private void SetParams(object[] parsDict)
        {
            string name;

            for (int n = 0, v = 1; v < parsDict.Length; n += 2, v += 2)
            {
                name = parsDict[n].ToString().ToUpper();

                command.Parameters[name].Value = parsDict[v];
            }
        }
        /// <summary>
        /// Sets the parameter values according to the values the passed into func or procedure. 
        /// Call after PrepareCommand!
        /// </summary>
        /// <param name="parameters">Parameters collection</param>
        private void SetParams(Dictionary<string, object> parameters)
        {
            foreach(var p in parameters)
                    command.Parameters[p.Key].Value = p.Value;
        }
        #endregion
        #region Public methods
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
        /// <summary>
        /// Execute update program from row.
        /// </summary>
        /// <param name="progName">Name function or procedure.</param>
        /// <param name="row">Row which must updated.</param>
        /// <returns>Updated row ID.</returns>
        public int Update(string progName, DataRow row)
        {
            int retval;
            try
            {
                PrepareCommand(progName, true);

                SetParams(row);

                command.ExecuteNonQuery();

                command.Transaction.Commit();

                retval = (int)command.Parameters[0].Value;
            }
            catch (Exception ex)
            {
                command.Transaction.Rollback();
                throw ex;
            }

            return retval;
        }
        /// <summary>
        /// Используется для вызова функции или процедуры обновления таблицы.
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
            object retval;
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
                throw ex;
            }

            return retval;
        }
        /// <summary>
        /// Use for call stored procedure or function.
        /// </summary>
        /// <param name="progName">Name function or procedure.</param>
        /// <param name="values">Input value for fill parameters.</param>
        /// <returns>ID row is updated or 0 if program - procedure.</returns>
        public int Execute(string progName, params object[] values)
        {
            int p;

            try
            {
                PrepareCommand(progName, true);

                p = IsFunction ? 1 : 0;

                for (int s = 0; s < values.Length; s++, p++)
                    command.Parameters[p].Value = values[s];

                command.ExecuteNonQuery();

                command.Transaction?.Commit();
            }
            catch (Exception ex)
            {
                command.Transaction?.Rollback();
                throw ex;
            }

            return IsFunction ? Convert.ToInt32(command.Parameters[0].Value) : 0;
        }
        /// <summary>
        /// The method used to populate the DataSet by using cursors
        /// </summary>
        /// <param name="progName">Name function or procedure.</param>
        /// <param name="values">Input value for fill parameters.</param>
        /// <returns>DataSet object.</returns>
        /// <example>
        /// <code>
        /// progName = sel_test_lib
        /// DataSet ds = dl.Select("pack_debug_info.sel_test_lib", 1, 2);
        /// DataTable dt = ds.Tables[0];
        /// </code>
        /// </example>
        public DataSet Select(string progName, params object[] values)
        {
            DataSet data = new DataSet();
            int p;

            try
            {
                PrepareCommand(progName);

                p = IsFunction ? 1 : 0;

                for (int s = 0; s < values.Length; s++, p++)
                    command.Parameters[p].Value = values[s];

                command.ExecuteNonQuery();

                OracleDataAdapter adapter = new OracleDataAdapter(command);

                adapter.Fill(data);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return data;
        }
        /// <summary>
        /// The method used to populate the DataTable by using cursors.
        /// <para>Input parameters without their names!!!</para>
        /// </summary>
        /// <param name="progName">Name function or procedure.</param>
        /// <param name="values">Input value for fill parameters.</param>
        /// <returns>DataTable object.</returns>
        /// <example>
        /// <code>
        /// progName = sel_test_lib
        /// DataTable dt = dl.Select("pack_debug_info.sel_test_lib", 1, 2);
        /// </code>
        /// </example>
        public DataTable SelectToTable(string progName, params object[] values)
        {
            DataTable data = new DataTable();
            int p;

            try
            {
                PrepareCommand(progName);

                p = IsFunction ? 1 : 0;

                for (int s = 0; s < values.Length; s++, p++)
                    command.Parameters[p].Value = values[s];

                command.ExecuteNonQuery();

                OracleDataAdapter adapter = new OracleDataAdapter(command);

                adapter.Fill(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return data;
        }
        /// <summary>
        /// The method used to populate the DataTable by using cursors. Bind parameters by name.
        /// </summary>
        /// <param name="progName">Name function or procedure.</param>
        /// <param name="parsDictionary">Input pair of name and value for fill parameters.</param>
        /// <returns>DataSet object.</returns>
        /// <example>
        /// <code>
        /// progName = sel_test_lib
        /// DataTable dt = dl.Select("pack_debug_info.sel_test_lib", 1, 2);
        /// </code>
        /// </example>
        public DataTable SelectToTableByParName(string progName, params object[] parsDictionary)
        {
            DataTable data = new DataTable();

            try
            {
                PrepareCommand(progName);

                if (parsDictionary != null)
                    SetParams(parsDictionary);

                command.ExecuteNonQuery();

                OracleDataAdapter adapter = new OracleDataAdapter(command);

                adapter.Fill(data);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return data;
        }
        public DataTable SelectToTable(string progName, Dictionary<string, object> parameters)
        {
            DataTable data = new DataTable();

            try
            {
                PrepareCommand(progName);

                SetParams(parameters);

                command.ExecuteNonQuery();

                OracleDataAdapter adapter = new OracleDataAdapter(command);

                adapter.Fill(data);
            }
            catch (Exception ex)
            {
                data = null;
                throw new Exception(ex.Message, ex);
            }

            return data;
        }
        #endregion
    }
}
