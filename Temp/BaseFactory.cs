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
    public class BaseFactory
    {
        private OracleConnection orclCn;
        private OracleCommand command;
        private string conStr;
        private bool IsFunction;
        private Dictionary<string, OracleCommand> commands;
        /// <summary>
        /// Set connection string according of the base type
        /// </summary>
        public BaseFactory()
        {
            //orclCn = DatabaseManager.Active.Connection;  
            commands = new Dictionary<string, OracleCommand>();
        }
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
            orclCn = new OracleConnection(conStr);
            orclCn.Open();

            commands = new Dictionary<string, OracleCommand>();
        }
        #region Service methods
        private void CloseConnection()
        {
            orclCn.Close();
        }
        /// <summary>
        /// Execution of command object preparation.
        /// </summary>
        /// <param name="program">Name function or procedure.</param>
        /// <param name="tranFlag">Necessity create transaction.</param>
        private void PrepareCommand(string prog)
        {
            if (commands.ContainsKey(prog))
                commands.TryGetValue(prog, out command);
            else
            {
                command = new OracleCommand(prog, orclCn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                OracleCommandBuilder.DeriveParameters(command);
                //Add to dictionary for reuse
                commands.Add(prog, command);
                //Determinete func(1) or proc(0)
                IsFunction = command.Parameters[0].Direction == ParameterDirection.ReturnValue;
            }
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

            for(int n = 0, v = 1; v < parsDict.Length; n += 2, v += 2)
            {
                name = parsDict[n].ToString().ToUpper();

                command.Parameters[name].Value = parsDict[v];                   
            }
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
            try
            {
                PrepareCommand(progName);

                foreach (DataRow r in table.Rows)
                    SetParams(r);

                command.ExecuteNonQuery();

                return table.Rows.Count;
            }
            catch (Exception ex)
            {
                command.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                command.Transaction.Commit();
            }
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
                PrepareCommand(progName);

                SetParams(row);

                command.ExecuteNonQuery();

                retval = (int)command.Parameters[0].Value;

                return retval;
            }
            catch (Exception ex)
            {
                command.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                command.Transaction.Commit();
            }
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
                PrepareCommand(progName);

                p = IsFunction ? 1 : 0;

                for (int s = 0; s < values.Length; s++, p++)
                    command.Parameters[p].Value = values[s];

                command.ExecuteNonQuery();

                return IsFunction ? Convert.ToInt32(command.Parameters[0].Value) : 0;
            }
            catch (Exception ex)
            {
                command.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                command.Transaction.Commit();
            }
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

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// The method used to populate the DataTable by using cursors
        /// </summary>
        /// <param name="progName">Name function or procedure.</param>
        /// <param name="values">Input value for fill parameters.</param>
        /// <returns>DataSet object.</returns>
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

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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

                if(parsDictionary != null)
                    SetParams(parsDictionary);

                command.ExecuteNonQuery();

                OracleDataAdapter adapter = new OracleDataAdapter(command);

                adapter.Fill(data);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
    }
}
