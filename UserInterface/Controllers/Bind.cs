using System.Data;
using System.Windows.Forms;

namespace UserInterface.Controllers
{
    public class Bind : ITestLib
    {
        public DBHelper DBHelper { get; set; }
        public TestForm Form { get; set; }
        private DataTable data;
        private BindingSource bindingSource;
        public Bind(TestForm sender)
        {
            Form = sender;
            DBHelper = new DBHelper();
            bindingSource = new BindingSource();
        }
        public void DoAction()
        {
            data = DBHelper.GetZaporishyaStreets();
            bindingSource.DataSource = data;
            Form.dgBinding.DataSource = bindingSource;
            //Init simple controls
            Form.tbCityName.DataBindings.Add("Text", bindingSource, "ST_CITY", true, DataSourceUpdateMode.OnPropertyChanged);
            Form.tbStreetName.DataBindings.Add("Text", bindingSource, "ST_NAME", true, DataSourceUpdateMode.OnPropertyChanged);
            Form.tbIndex.DataBindings.Add("Text", bindingSource, "ST_INDEX", true, DataSourceUpdateMode.OnPropertyChanged);
            bindingSource.BindingComplete += new BindingCompleteEventHandler(bindingSource_BindingComplete);
        }
        //Для обновления данный на других контролах
        private void bindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            // Check if the data source has been updated, and that no error has occurred.
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate && e.Exception == null)

                // If not, end the current edit.
                e.Binding.BindingManagerBase.EndCurrentEdit();
        }
    }
}
