using System;
using System.Data;
using System.Windows.Forms;

namespace UserInterface.Helpers
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
}
