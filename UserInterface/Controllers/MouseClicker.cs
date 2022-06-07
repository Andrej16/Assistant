using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UserInterface.Core;

namespace UserInterface.Controllers
{
    public class MouseClicker : ITestLib
    {
        Timer timerClicker; //таймер, просто для примера
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
        public void DoAction(object sender)
        {
            timerClicker = new Timer();
            timerClicker.Interval = 2000;
            timerClicker.Tick += new EventHandler(timerClicker_Tick);
            timerClicker.Start();
        }
        private void timerClicker_Tick(object sender, EventArgs e)
        {
            //Вызов импортируемой функции с текущей позиции курсора
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            DoMouseClick(X, Y);
        }
        public void DoMouseClick(uint X, uint Y)
        {
            mouse_event((uint)(MouseEventFlags.LEFTDOWN | MouseEventFlags.LEFTUP), X, Y, 0, UIntPtr.Zero);
        }
    }
}
