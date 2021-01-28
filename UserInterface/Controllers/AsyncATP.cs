using System;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using UserInterface.Helpers;

namespace UserInterface
{
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
            //CreateAsync();
            WinFormsParallel(); //Хрень 
        }
        
        private void WinFormsParallel()
        {
            Task.Factory.StartNew(() => { Form.BeginInvoke(new Action(() => { PrintOne(); })); }); 
            Form.BeginInvoke(new Action(() => { PrintTwo(); }));
        }
        private void PrintOne()
        {
            for (int i = 0; i < 1000; i++)
            {
                //Thread.Sleep(100);
                Form.tbFirst.Text += "1";
            }

        }
        private void PrintTwo()
        {
            for (int i = 0; i < 1000; i++)
            {
                //Thread.Sleep(100);
                Form.tbSecond.Text += "2";
            }

        }

        public void CreateAsync()
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
            //Всегда выполняется в основном потоке, CurrentThread.ManagedThreadId = 1
            Form.Invoke(args.SetAction, args);

        }
        private void CallBackNoArgs(IAsyncResult asyncResult)
        {
            AsyncResult ar = asyncResult as AsyncResult;
            Func<object> func = (Func<object>)ar.AsyncDelegate;

            StateArgs args = (StateArgs)asyncResult.AsyncState;

            args.Data = func.EndInvoke(asyncResult) as DataTable;
            //Всегда выполняется в основном потоке, CurrentThread.ManagedThreadId = 1
            Form.Invoke(args.SetAction, args);
        }

        private void SetDataSource(object state)
        {
            StateArgs args = state as StateArgs;
            args.View.AutoGenerateColumns = true;
            args.View.DataSource = args.Data;
            Form.tbOutput.Text += $"SetDataSource, ViewName: {args.View.Name}, ThreadId:{Thread.CurrentThread.ManagedThreadId}\r\n";
        }
        //private void UcSmsHistoryOnLoad(object sender, EventArgs e)
        //{
        //    Task load = Task.Run(() =>
        //    {
        //        DataTable table = GetDataSourse(RefId);
        //        Invoke(new Action(delegate { IdentPeps.BindGrid(gcPep); }));
        //        Invoke(new Action(() => { gcMain.DataSource = table; }));
        //    });
        //}

    }
}
