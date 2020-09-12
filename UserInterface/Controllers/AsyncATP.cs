using System;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace UserInterface
{
    public class StateArgs
    {
        public DataGridView View { get; set; }
        public DataTable Data { get; set; }
        public Action<object> SetAction { get; set; }
        public StateArgs(DataGridView view, Action<object> action)
        {
            View = view;
            SetAction = action;
        }
    }
    public class AsyncATP : ITestLib
    {
        public DBHelper DBHelper { get; set; }
        public TestForm Form { get; set; }
        public AsyncATP(TestForm sender)
        {
            Form = sender;
            DBHelper = new DBHelper();
        }
        public void DoAction()
        {
            int cityId = 1141;
            Func<object, object> funcFind = new Func<object, object>(DBHelper.Find);
            Func<object> funcSelectRows2 = new Func<object>(DBHelper.SelectRows2);

            _ = (new Func<object>(DBHelper.SelectRows3)).BeginInvoke(CallBackNoArgs, new StateArgs(Form.dgvThreadTest3, SetDataSource));

            funcFind.BeginInvoke(cityId, CallBack, new StateArgs(Form.dgvThreadTest, SetDataSource));
            funcSelectRows2.BeginInvoke(CallBackNoArgs, new StateArgs(Form.dgvThreadTest2, SetDataSource));
        }
        private void CallBack(IAsyncResult asyncResult)
        {
            AsyncResult ar = asyncResult as AsyncResult;
            Func<object, object> func = (Func<object, object>)ar.AsyncDelegate;

            StateArgs args = (StateArgs)asyncResult.AsyncState;

            args.Data = func.EndInvoke(asyncResult) as DataTable;

            Form.Invoke(args.SetAction, args);

        }
        private void CallBackNoArgs(IAsyncResult asyncResult)
        {
            AsyncResult ar = asyncResult as AsyncResult;
            Func<object> func = (Func<object>)ar.AsyncDelegate;

            StateArgs args = (StateArgs)asyncResult.AsyncState;

            args.Data = func.EndInvoke(asyncResult) as DataTable;

            Form.Invoke(args.SetAction, args);
        }

        private void SetDataSource(object state)
        {
            StateArgs args = state as StateArgs;           
            args.View.AutoGenerateColumns = true;
            args.View.DataSource = args.Data;
        }
    }
}
