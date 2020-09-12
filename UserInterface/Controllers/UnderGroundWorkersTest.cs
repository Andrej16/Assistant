using Assistant;
using System.Data;

namespace UserInterface.Controllers
{
    public class UnderGroundWorkersTest : ControllerBase, ITestLib
    {
        private DBHelper dBHelper;

        public UnderGroundWorkersTest(TestForm test)
            :base(test)
        {
            dBHelper = new DBHelper();

        }
        public void DoAction()
        {
            TestunderGroundWorker();
        }
        private void TestunderGroundWorker()
        {
            UnderGroundWorkers workers = new UnderGroundWorkers();
            workers.Add(MainForm, dBHelper.SelectRows, SetDataSource);
            workers.Add(MainForm, dBHelper.SelectRows2, SetDataSource2);
            workers.Add(MainForm, dBHelper.SelectRows3, SetDataSource3);
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
