using System.Drawing;
using System.Windows.Forms;

namespace UserControls
{
    public partial class FBaseForm : Form
    {
        public FBaseForm()
        {
            InitializeComponent();
        }
        protected void ShowFrame(Control control, bool center = true)
        {
            control.Parent = this;
            control.Visible = true;
            control.Enabled = true;
            control.BringToFront();

            if (center)
                SetCenter(this, control);
        }
        private void SetCenter(Form parent, Control control)
        {
            control.Location = new Point(parent.Width / 2 - control.Width / 2, parent.Height / 2 - control.Height / 2);
        }
    }
}
