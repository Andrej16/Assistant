using System;
using System.Data;
using System.Threading;

namespace UserInterface.Controllers
{
    public class TreadPoolLoader : ControllerBase, ITestLib
    {
        private AutoResetEvent[] events;
        private Action _setDelegate;
        private DBHelper dBHelper;
        private DataTable[] tables = new DataTable[3];
        public TreadPoolLoader(TestForm test)
            : base(test)
        {
            dBHelper = new DBHelper();
            events = new AutoResetEvent[] { new AutoResetEvent(false), new AutoResetEvent(false), new AutoResetEvent(false) };
        }
        public void DoAction(object sender)
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
            MainForm.Invoke(_setDelegate);
        }
        private void BindAll()
        {
            SetDataSource(tables[0]);
            SetDataSource2(tables[1]);
            SetDataSource3(tables[2]);
            MainForm.tbOutput.Text += "All grids binded!" + Environment.NewLine;
        }
        private void Load1(object state)
        {
            tables[0] = dBHelper.GetZaporishyaStreets();
            MainForm.Invoke((Action)delegate { MainForm.tbOutput.Text += "Loader1 load data!" + Environment.NewLine; });
            (state as AutoResetEvent).Set();
        }
        private void Load2(object state)
        {
            tables[1] = dBHelper.SelectRows2();
            MainForm.Invoke((Action)delegate { MainForm.tbOutput.Text += "Loader2 load data!" + Environment.NewLine; });
            (state as AutoResetEvent).Set();
        }
        private void Load3(object state)
        {
            tables[2] = dBHelper.SelectRows3();
            MainForm.Invoke((Action)delegate { MainForm.tbOutput.Text += "Loader3 load data!" + Environment.NewLine; });
            (state as AutoResetEvent).Set();
        }
        private void SetDataSource(object dsObj)
        {
            DataTable dt = dsObj as DataTable;
            MainForm.dgvThreadTest.AutoGenerateColumns = true;
            MainForm.dgvThreadTest.DataSource = dt;
        }
        private void SetDataSource2(object dsObj)
        {
            DataTable dt = dsObj as DataTable;
            MainForm.dgvThreadTest2.AutoGenerateColumns = true;
            MainForm.dgvThreadTest2.DataSource = dt;
        }

        private void SetDataSource3(object dsObj)
        {
            DataTable dt = dsObj as DataTable;
            MainForm.dgvThreadTest3.AutoGenerateColumns = true;
            MainForm.dgvThreadTest3.DataSource = dt;
        }

    }
}
