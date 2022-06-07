using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace UserInterface.Controllers
{
    public class AsyncAwait : ITestLib
    {
        public TestForm Form { get; set; }
        private System.Windows.Forms.Timer _timer;
        public AsyncAwait(TestForm sender)
        {
            this.Form = sender;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 2000;
            _timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Form.tbProccesOutput.Text += "Data was loaded!\r\n";
        }

        public void DoAction(object sender)
        {
            Button button = sender as Button;
            if(button == Form.btnGetData)
            {
                _timer.Start();
                GetDataAsync();               
            }
            else
            {
                DisconnectAsync();
            }
        }

        public async void GetDataAsync()
        {
            Form.tbProccesOutput.Text += "Подключение к БД...\r\n";
            Task<int> task = Task.Run(GetData);
            int data = await task;
            Form.tbProccesOutput.Text += $"Proccess result - {data}\r\n";
        }

        private int GetData()
        {
            Thread.Sleep(2000);
            return 777;
        }

        public async void DisconnectAsync()
        {
            Form.tbProccesOutput.Text += "Закрытие подключения к БД...\r\n";
            Task task = Task.Run(Disconnect);
            await task;
            Form.tbProccesOutput.Text += "Подключение к БД закрыто\r\n";
        }

        private void Disconnect()
        {
            _timer.Stop();
            
            Thread.Sleep(2000);           
        }
    }
}
