using System;
using System.Threading;
using System.Windows.Forms;

namespace Assistant
{
    /// <summary>
    /// Загрузка в потоках
    /// </summary>
    /// <example>
    /// pivate void TestunderGroundWorker()
    /// {
    ///     UnderGroundWorker ugw = new UnderGroundWorker(this, SelectRows, SetDataSource);
    ///     ugw.RunLoader();
    ///
    ///     UnderGroundWorker ugw2 = new UnderGroundWorker(this, SelectRows2, SetDataSource2);
    ///     ugw2.RunLoader();
    ///
    ///     UnderGroundWorker ugw3 = new UnderGroundWorker(this, SelectRows3, SetDataSource3);
    ///     ugw3.RunLoader();
    /// }
    /// private DataTable SelectRows()
    /// {
    ///     DataTable ds = new DataTable();
    ///     BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
    ///     var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1141 } };
    ///     ds = ubf.SelectToTable("pack_street.find_street", pars);
    ///        return ds;
    ///}
    ///private void SetDataSource(DataSet ds)
    ///{
    ///    dgvThreadTest.AutoGenerateColumns = true;
    ///    dgvThreadTest.DataSource = ds.Tables[0];
    ///}
    /// </example>
    public class UnderGroundWorker
    {
        private Thread thread;
        private Form form;
        private Action<object> setDelegate;
        private Func<object> loadDelegate;
        private object dataSource;
        readonly object _locker = new object();
        bool _go;
        public UnderGroundWorker(Form f, Func<object> loadAction, Action<object> setAction)
        {
            form = f;
            setDelegate = setAction;
            loadDelegate = loadAction;
        }
        public void RunLoader()
        {
            thread = new Thread(new ThreadStart(Loading));
            thread.IsBackground = true;
            thread.Start();
        }
        private void Loading()
        {
            dataSource = loadDelegate.Invoke();
            SetToControls();
        }
        private void SetToControls()
        {
            //lock (lockOn)
            //{
                if (form.InvokeRequired)
                    form.Invoke(setDelegate, new object[] { dataSource });
                else
                    setDelegate.Invoke(dataSource);
                //Monitor.Pulse(lockOn);
                //Monitor.Wait(lockOn);
            //}
        }
    }
}
