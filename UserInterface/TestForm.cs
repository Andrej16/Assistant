using System;
using UserControls;

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
            TesterCurrent = new Tester(new AsyncATP(this));
            TesterCurrent.DoTest();
        }
    }
}
