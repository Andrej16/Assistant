using Assistant;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using UserControls;
using UserInterface.Helpers;

namespace UserInterface
{
    public partial class TestForm : FBaseForm
    {
        private object[] responseAddress = new object[5];
        private List<UnderGroundWorker> underGroundWorkers;
        private DBHelper dBHelper;
        private delegate void SetDelegate(DataSet d);
        private AutoResetEvent[] events;
        private DataTable[] tables = new DataTable[3];
        private Action _setDelegate;
        public TestForm()
        {
            InitializeComponent();
            InitializeCustom();            
        }

        private void InitializeCustom()
        {
            dBHelper = new DBHelper();
            events = new AutoResetEvent[] { new AutoResetEvent(false), new AutoResetEvent(false), new AutoResetEvent(false) };
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            //thread = new Thread(new ThreadStart(TestThreadingLoad));
            //thread.Start();

            //TestNoThreading();
            //TestunderGroundWorker();
            //TestUnderGroundWaiter();
            TreadPoolLoader();
        }
        #region ThreadPool loader
        private void TreadPoolLoader()
        {
            ThreadPool.QueueUserWorkItem(Load1, events[0]);
            ThreadPool.QueueUserWorkItem(Load2, events[1]);
            ThreadPool.QueueUserWorkItem(Load3, events[2]);
            new Thread(Binder).Start();
        }
        private void Binder()
        {
            _setDelegate = BindAll;
            WaitHandle.WaitAll(events);
            Invoke(_setDelegate);
        }
        private void BindAll()
        {
            SetDataSource(tables[0]);
            SetDataSource2(tables[1]);
            SetDataSource3(tables[2]);
            tbOutput.Text += "All grids binded!" + Environment.NewLine;
        }
        private void Load1(object state)
        {
            tables[0] = dBHelper.SelectRows();
            Invoke((Action)delegate { tbOutput.Text += "Loader1 load data!" + Environment.NewLine; });
            (state as AutoResetEvent).Set();
        }
        private void Load2(object state)
        {
            tables[1] = dBHelper.SelectRows2();
            Invoke((Action)delegate { tbOutput.Text += "Loader2 load data!" + Environment.NewLine; });
            (state as AutoResetEvent).Set();
        }
        private void Load3(object state)
        {
            tables[2] = dBHelper.SelectRows3();
            Invoke((Action)delegate { tbOutput.Text += "Loader3 load data!" + Environment.NewLine; });
            (state as AutoResetEvent).Set();
        }
        #endregion
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
            workers.Add(this, dBHelper.SelectRows, SetDataSource);
            workers.Add(this, dBHelper.SelectRows2, SetDataSource2);
            workers.Add(this, dBHelper.SelectRows3, SetDataSource3);
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
            UnderGroundWaiter ugw = new UnderGroundWaiter(this, dBHelper.SelectRows, SetDataSource);
            UnderGroundWaiter ugw2 = new UnderGroundWaiter(this, dBHelper.SelectRows2, SetDataSource2);
            UnderGroundWaiter ugw3 = new UnderGroundWaiter(this, dBHelper.SelectRows3, SetDataSource3);
            Thread.Sleep(1000);
            ugw.RunLoader();
            ugw2.RunLoader();
            ugw3.RunLoader();
        }
        //private void SetDataSource(DataSet ds)
        //{
        //    dgvThreadTest.AutoGenerateColumns = true;
        //    dgvThreadTest.DataSource = ds.Tables[0];
        //}
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
        #region AddressChoice control
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
        #endregion
    }
}
