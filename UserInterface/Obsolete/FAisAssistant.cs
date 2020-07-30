using System;
using System.Windows.Forms;
using Assistant;

namespace UserInterface
{
    public partial class FAisAssistant : Form
    {
        public FAisAssistant()
        {
            InitializeComponent();
            luProgType.Properties.DataSource = DictionaryStatic.ProgramTypesDictionary;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            string resultCode = MakeCode(teProgName.EditValue.ToString(), ESqlType.Function);
            meResultCode.EditValue = resultCode;
        }
    }
}
