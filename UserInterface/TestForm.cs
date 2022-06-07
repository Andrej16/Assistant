using System;
using UserControls;
using UserInterface.Controllers;

namespace UserInterface
{
    public partial class TestForm : FBaseForm
    {
        public static Tester TesterCurrent { get; set; }
        public TestForm()
        {
            InitializeComponent();
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            //TesterCurrent = new Tester(new AsyncATP(this));
            //TesterCurrent = new Tester(new Bind(this));
            //TesterCurrent = new Tester(new MouseClicker());
            //TesterCurrent = new Tester(new ParallelLibraryTPL(this));
            TesterCurrent = new Tester(new AsyncAwait(this));

            //TesterCurrent.DoTest(sender);           
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            TesterCurrent.DoTest(sender);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            TesterCurrent.DoTest(sender);    
        }
    }
}
