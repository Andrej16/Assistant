using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace UserInterface
{
    public class ThreadindLoader : ControllerBase, ITestLib
    {
        private delegate void SetDelegate(DataSet d);
        public ThreadindLoader(TestForm test) 
            :base(test)
        {

        }
        public void DoAction(object sender)
        {
            Thread thread = new Thread(new ThreadStart(TestThreadingLoad));
            thread.Start();

            TestNoThreading();
        }
        private void TestThreadingLoad()
        {
            string query = "SELECT * FROM HumanResources.Employee";
            DataSet ds = new DataSet();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.AdventureWorks"];
            // "System.Data.SqlClient"
            SelectRows(ds, settings.ConnectionString, query);
            var sd = new SetDelegate(SetDataSource);
            if (MainForm.InvokeRequired)
                MainForm.Invoke(sd, new object[] { ds });
            else
                SetDataSource(ds);
        }
        private void TestNoThreading()
        {
            string query = "SELECT * FROM HumanResources.Employee";
            DataSet ds = new DataSet();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.AdventureWorks"];
            // "System.Data.SqlClient"
            SelectRows(ds, settings.ConnectionString, query);
            SetDataSource(ds);
        }
        private void SetDataSource(DataSet ds)
        {
            MainForm.dgvThreadTest.AutoGenerateColumns = true;
            MainForm.dgvThreadTest.DataSource = ds.Tables[0];
        }

        private DataSet SelectRows(DataSet dataset, string connectionString, string queryString)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(queryString, connection);
                for (long i = 0; i < 10000000000; i++)
                {

                }
                adapter.Fill(dataset);
                return dataset;
            }
        }

    }
}
