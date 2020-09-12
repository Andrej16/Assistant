using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class ControllerBase
    {
        public TestForm MainForm { get; set; }
        public DBHelper DBHelper { get; set; }
        public ControllerBase(TestForm sender)
        {
            MainForm = sender;
            DBHelper = new DBHelper();
        }
    }
}
