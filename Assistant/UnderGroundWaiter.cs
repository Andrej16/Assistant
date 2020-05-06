using System;
using System.Threading;
using System.Windows.Forms;

namespace Assistant
{
    /// <summary>
    /// Загрузка в потоках
    /// </summary>
    /// <example>
    ///private void TestUnderGroundWaiter()
    ///{
    ///    UnderGroundWaiter ugw = new UnderGroundWaiter(this, SelectRows, SetDataSource);
    ///    UnderGroundWaiter ugw2 = new UnderGroundWaiter(this, SelectRows2, SetDataSource2);
    ///    UnderGroundWaiter ugw3 = new UnderGroundWaiter(this, SelectRows3, SetDataSource3);
    ///    ugw.RunLoader();
    ///    ugw2.RunLoader();
    ///    ugw3.RunLoader();
    ///}
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
    public class UnderGroundWaiter
    {
        private readonly Form _form;
        private readonly Action<object> _setDelegate;
        private readonly Func<object> _loadDelegate;
        private object _dataSource;
        private readonly object _locker = new object();
        private bool _go;
        public UnderGroundWaiter(Form f, Func<object> loadAction, Action<object> setAction)
        {
            _form = f;
            _setDelegate = setAction;
            _loadDelegate = loadAction;
            Thread thread = new Thread(Loading);
            thread.IsBackground = true;
            thread.Start();
        }
        public void RunLoader()
        {
            lock (_locker)
            {
                _go = true;
                Monitor.Pulse(_locker);
            }
        }
        private void Loading()
        {
            lock (_locker)
            {
                while (!_go)
                    Monitor.Wait(_locker);

                _dataSource = _loadDelegate.Invoke();
                SetToControls();
            }

        }
        private void SetToControls()
        {
            if (_form.InvokeRequired)
                _form.Invoke(_setDelegate, new object[] { _dataSource });
            else
                _setDelegate.Invoke(_dataSource);
        }
    }
}
