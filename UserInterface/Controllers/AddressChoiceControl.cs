using Assistant;
using System.Windows.Forms;

namespace UserInterface
{
    public class AddressChoiceControl : ITestLib
    {
        public TestForm MainForm { get; private set; }

        public AddressChoiceControl(TestForm sender)
        {
            MainForm = sender;
        }
        public void DoAction()
        {
            UcAddressChoice uc = new UcAddressChoice(inp);

            MainForm.ShowFrame(uc);

        }
        private void inp(object arg1, object arg2, object arg3, object arg4, object arg5)
        {
            object[] responseAddress = new object[5];

            responseAddress[0] = arg1;
            responseAddress[1] = arg2;
            responseAddress[2] = arg3;
            responseAddress[3] = arg4;
            responseAddress[4] = arg5;

            MessageBox.Show($"OblId={responseAddress[0]}, " +
                $"CityId={responseAddress[1]}, " +
                $"StreetId={responseAddress[2]}, " +
                $"Build={responseAddress[3]}, " +
                $"Nums={responseAddress[4]}");
        }

    }
}
