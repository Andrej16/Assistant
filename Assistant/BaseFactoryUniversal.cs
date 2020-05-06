using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Assistant
{
    /// <summary>
    /// Represents a set of command-related properties that are used to fill the DataSet and update a data source, 
    /// and is implemented by that access relational databases.
    /// </summary>
    public class BaseFactoryUniversal : IDisposable
    {
        private DbProviderFactory factory;
        private DbConnection connection;
        private DbCommand command;
        private Dictionary<string, DbCommand> commands;
        private bool IsFunction;
        // Для определения избыточных вызовов
        private bool disposedValue = false;
        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~BaseFactoryUniversal()
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
        /// Create the DbProviderFactory and DbConnection, and open last.
        /// </summary>
        /// <remarks>
        /// Set a DbConnection on success; generate exception on failure.
        /// </remarks>
        /// <param name="providerName"></param>
        /// <param name="connectionString"></param>
        public BaseFactoryUniversal(string providerName, string connectionString)
        {
            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    factory = DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    commands = new Dictionary<string, DbCommand>();
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                        connection = null;
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Retrieve the installed providers and factories.
        /// </summary>
        public static DataTable GetProviderFactoryClasses()
        {
            // Retrieve the installed providers and factories.
            DataTable table = DbProviderFactories.GetFactoryClasses();

            // Display each row and column value.
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine(row[column]);
                }
            }
            return table;
        }
        /// <summary>
        /// Execution of command object preparation.
        /// </summary>
        /// <param name="programm">Name function or procedure.</param>
        /// <param name="needTransaction">Necessity create transaction.</param>
        private void PrepareCommand(string programm, bool needTransaction = false)
        {
            if (commands.ContainsKey(programm))
                commands.TryGetValue(programm, out command);
            else
            {
                // Check for valid DbConnection.
                if (connection != null)
                {
                    // Create the command.
                    command = connection.CreateCommand();
                    command.CommandText = programm;
                    command.CommandType = CommandType.StoredProcedure;

                    DeriveParameters();
                    //Add to dictionary for reuse
                    commands.Add(programm, command);
                    //Determinete func(1) or proc(0)
                    IsFunction = command.Parameters[0].Direction == ParameterDirection.ReturnValue;
                }
                else
                {
                    throw new Exception("Failed: DbConnection is null.");
                }
            }
            //Use transaction
            if (needTransaction)
                command.Transaction = connection.BeginTransaction();
        }
        /// <summary>
        /// Derives the parameters.
        /// </summary>
        private void DeriveParameters()
        {
            DbCommandBuilder commandBuilder = factory.CreateCommandBuilder();
            Type commandBuilderType = commandBuilder.GetType();
            MethodInfo method = commandBuilderType.GetMethod("DeriveParameters");

            if (method != null)
                method.Invoke(commandBuilder, new object[] { command });
            else
                throw new ArgumentException($"The specified provider factory does not support stored procedures: {factory.GetType().Name}");
        }
        /// <summary>
        /// Sets the parameter values according to the values the passed into func or procedure. 
        /// Call after PrepareCommand!
        /// </summary>
        /// <param name="parameters">Parameters collection</param>
        private void SetParams(Dictionary<string, object> parameters)
        {
            foreach (var p in parameters)
                command.Parameters[p.Key].Value = p.Value;
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
        #region Select section
        /// <summary>
        /// The method used to populate the DataSet by using cursors
        /// </summary>
        /// <param name="progName">Name function or procedure.</param>
        /// <param name="values">Input value for fill parameters.</param>
        /// <returns>DataSet object.</returns>
        /// <example>
        /// DataSet ds = new DataSet();
        /// ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.Test"];   
        /// using (BaseFactoryUniversal ubf = new BaseFactoryUniversal("Oracle.ManagedDataAccess.Client", settings.ConnectionString))
        /// {
        ///     var pars = new Dictionary<string, object>(){ {"p_obl_id", 1002} };
        ///     ds = ubf.SelectToDataSet("OPEN_TWO_CURSORS", pars);
        /// }
        /// </example>
        public DataSet SelectToDataSet(string progName, Dictionary<string, object> parameters)
        {
            DataSet data = new DataSet();

            try
            {
                PrepareCommand(progName);

                SetParams(parameters);

                command.ExecuteNonQuery();

                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

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
        /// <para>
        /// Returns a DataTable on success; null on failure.
        /// </para>
        /// </summary>
        /// <param name="progName">Name function or procedure.</param>
        /// <param name="values">Input parameters collection.</param>
        /// <returns>DataSet object.</returns>
        /// <example>
        /// <code>
        /// DataTable dt = new DataTable();
        /// ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.Test"];   
        /// using (BaseFactoryUniversal ubf = new BaseFactoryUniversal("Oracle.ManagedDataAccess.Client", settings.ConnectionString))
        /// {
        ///     var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1141 } };
        ///     dt = ubf.SelectToTable("pack_street.find_street", pars);
        /// }
        /// </code>
        /// </example>
        /// <returns>Если функция - ID добавляемой записи, иначе null.</returns>
        public DataTable SelectToTable(string progName, Dictionary<string, object> parameters)
        {
            DataTable data = new DataTable();

            try
            {
                PrepareCommand(progName);

                SetParams(parameters);

                command.ExecuteNonQuery();

                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                adapter.Fill(data);                
            }
            catch (Exception ex)
            {
                data = null;
                throw new Exception(ex.Message, ex);
            }

            return data;
        }
        /// <summary>
        /// Executes the query and returns the first column of the first row in the result set returned by the query. All other columns and rows are ignored.
        /// </summary>
        /// <example>
        /// ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.Test"];   
        /// using (BaseFactoryUniversal ubf = new BaseFactoryUniversal("Oracle.ManagedDataAccess.Client", settings.ConnectionString))
        /// {
        ///     var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1141 } };
        ///     object result = ubf.Scalar("pack_street.find_street", pars);
        /// }
        /// </example>
        /// <param name="progName">Procedure/Function name</param>
        /// <param name="parameters">Parameters dictionary.</param>
        /// <returns>The first column of the first row in the result set.</returns>
        public object Scalar(string progName, Dictionary<string, object> parameters)
        {
            object retval = null;

            try
            {
                PrepareCommand(progName);

                SetParams(parameters);

                retval = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return retval;
        }
        #endregion
        #region Update region
        /// <summary>
        /// Используется для вызова функции или процедуры обновления таблицы.
        /// </summary>
        /// <para>
        /// Returns a value stored programm on success; null on failure.
        /// </para>
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
        public object Execute(string progName, Dictionary<string, object> parameters)
        {
            object retval = null;

            try
            {
                PrepareCommand(progName, true);

                SetParams(parameters);

                command.ExecuteNonQuery();

                command.Transaction.Commit();

                retval = IsFunction ? command.Parameters[0].Value : null;
            }
            catch (Exception ex)
            {
                command.Transaction.Rollback();
                throw ex;
            }

            return retval;
        }
        #endregion

    }
}
