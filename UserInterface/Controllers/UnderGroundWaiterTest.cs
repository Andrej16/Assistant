using Assistant;
using System.Data;
using System.Threading;

namespace UserInterface.Controllers
{
    public class UnderGroundWaiterTest : ControllerBase, ITestLib
    {
        public UnderGroundWaiterTest(TestForm test)
            :base(test)
        {

        }
        public void DoAction()
        {
            TestUnderGroundWaiter();
        }
        private void TestUnderGroundWaiter()
        {
            UnderGroundWaiter ugw = new UnderGroundWaiter(MainForm, DBHelper.GetZaporishyaStreets, SetDataSource);
            UnderGroundWaiter ugw2 = new UnderGroundWaiter(MainForm, DBHelper.SelectRows2, SetDataSource2);
            UnderGroundWaiter ugw3 = new UnderGroundWaiter(MainForm, DBHelper.SelectRows3, SetDataSource3);
            Thread.Sleep(1000);
            ugw.RunLoader();
            ugw2.RunLoader();
            ugw3.RunLoader();
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
