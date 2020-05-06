using Assistant;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using UserControls;

namespace UserInterface
{
    public partial class TestForm : FBaseForm
    {
        private object[] responseAddress = new object[5];
        private List<UnderGroundWorker> underGroundWorkers;

        private delegate void SetDelegate(DataSet d);
        private UnderGroundWaiter ugw;
        public TestForm()
        {
            InitializeComponent();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UcAddressChoice uc = new UcAddressChoice(inp);

            ShowFrame(uc);
        }
        private void inp(object arg1, object arg2, object arg3, object arg4, object arg5)
        {
            responseAddress[0] = arg1;
            responseAddress[1] = arg2;
            responseAddress[2] = arg3;
            responseAddress[3] = arg4;
            responseAddress[4] = arg5;

            MessageBox.Show($"OblId={responseAddress[0]}, " +
                $"CityId={responseAddress[1]}, " +
                $"StreetId={responseAddress[2]}, " +
                $"Build={responseAddress[3]}, " +
                $"Nums={responseAddress[4]}");
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            //thread = new Thread(new ThreadStart(TestThreadingLoad));
            //thread.Start();

            //TestNoThreading();
            //TestunderGroundWorker();
            TestUnderGroundWaiter();
        }
        private void TestThreadingLoad()
        {
            string query = "SELECT * FROM HumanResources.Employee";
            DataSet ds = new DataSet();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.AdventureWorks"];
            // "System.Data.SqlClient"
            SelectRows(ds, settings.ConnectionString, query);
            var sd = new SetDelegate(SetDataSource);
            if (InvokeRequired)
                this.Invoke(sd, new object[] { ds });
            else
                SetDataSource(ds);


        }
        private void TestunderGroundWorker()
        {

            UnderGroundWorkers workers = new UnderGroundWorkers();
            workers.Add(this, SelectRows, SetDataSource);
            workers.Add(this, SelectRows2, SetDataSource2);
            workers.Add(this, SelectRows3, SetDataSource3);
            workers.DoLoad();
            //underGroundWorkers = new List<UnderGroundWorker>();
            //underGroundWorkers.Add(new UnderGroundWorker(this, SelectRows, SetDataSource));
            //underGroundWorkers.Add(new UnderGroundWorker(this, SelectRows2, SetDataSource2));
            //underGroundWorkers.Add(new UnderGroundWorker(this, SelectRows3, SetDataSource3));

            //foreach (var worker in underGroundWorkers)
            //{
            //    worker.RunLoader();
            //}
            //UnderGroundWorker ugw = new UnderGroundWorker(this, SelectRows, SetDataSource);
            //ugw.RunLoader();

            //UnderGroundWorker ugw2 = new UnderGroundWorker(this, SelectRows2, SetDataSource2);
            //ugw2.RunLoader();

            
        }

        private void TestUnderGroundWaiter()
        {
            ugw = new UnderGroundWaiter(this, SelectRows, SetDataSource);
            UnderGroundWaiter ugw2 = new UnderGroundWaiter(this, SelectRows2, SetDataSource2);
            UnderGroundWaiter ugw3 = new UnderGroundWaiter(this, SelectRows3, SetDataSource3);
            Thread.Sleep(1000);
            ugw.RunLoader();
            ugw2.RunLoader();
            ugw3.RunLoader();
        }
        private DataTable SelectRows()
        {
            DataTable ds = new DataTable();

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1141 } };
            ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }
        private DataTable SelectRows2()
        {
            DataTable ds = new DataTable();

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1074 } };
            ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }
        private DataTable SelectRows3()
        {
            DataTable ds = new DataTable();

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1068 } };
            ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }
        private void SetDataSource(DataSet ds)
        {
            dgvThreadTest.AutoGenerateColumns = true;
            dgvThreadTest.DataSource = ds.Tables[0];
        }
        private void SetDataSource(object dsObj)
        {
            DataTable dt = dsObj as DataTable;
            dgvThreadTest.AutoGenerateColumns = true;
            dgvThreadTest.DataSource = dt;
        }
        private void SetDataSource2(object dsObj)
        {
            DataTable dt = dsObj as DataTable;
            dgvThreadTest2.AutoGenerateColumns = true;
            dgvThreadTest2.DataSource = dt;
        }

        private void SetDataSource3(object dsObj)
        {
            DataTable dt = dsObj as DataTable;
            dgvThreadTest3.AutoGenerateColumns = true;
            dgvThreadTest3.DataSource = dt;
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
