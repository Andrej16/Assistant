using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Controllers
{
    public class ParallelLibraryTPL : ITestLib
    {
        public DBHelper DBHelper { get; set; }
        public TestForm Form { get; set; }
        public ParallelLibraryTPL(TestForm sender)
        {
            Form = sender;
            DBHelper = new DBHelper();

        }
        public void DoAction()
        {
            //CreateTask();
            WaitTask();
        }

        private void WaitTask()
        {
            int cityId = 1141;

            Task t1 = Task.Run(() =>
            {
                //Thread.Sleep(10000);
                DataTable source = DBHelper.Find(cityId);
                Action<DataGridView, object> action = new Action<DataGridView, object>(SetDataSource);
                Form.BeginInvoke(action, Form.dgvThreadTest, source);
            });
            Form.tbOutput.Text += "Ожидание\r\n";
            t1.Wait();
            Form.tbOutput.Text += "Загрузка завершена\r\n";

        }

        private void CreateTask()
        {
            int cityId = 1141;

            Task t1 = Task.Run(() =>
            {
                Thread.Sleep(10000);
                DataTable source = DBHelper.Find(cityId);
                Action<DataGridView, object> action = new Action<DataGridView, object>(SetDataSource);
                Form.Invoke(action, Form.dgvThreadTest, source);
            });
            Task g2 = Task.Run(() =>
            {
                DataTable source = DBHelper.SelectRows2();
                Form.Invoke(new Action<DataGridView, object>(SetDataSource), Form.dgvThreadTest2, source);
            });
            Task g3 = Task.Run(() =>
            {
                Form.Invoke(new Action<DataGridView, object>(SetDataSource), Form.dgvThreadTest3, DBHelper.SelectRows3());
            });

        }
        private void SetDataSource(DataGridView view, object data)
        {            
            view.AutoGenerateColumns = true;
            view.DataSource = data;
            Form.tbOutput.Text += $"SetDataSource, ViewName: {view.Name}, ThreadId:{Thread.CurrentThread.ManagedThreadId}\r\n";
        }

    }
}
