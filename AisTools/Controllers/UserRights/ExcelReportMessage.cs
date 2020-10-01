using System.Collections;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace AisTools
{
    public class ExcelReportMessage : IMessage
    {
        public IDictionary Properties { get; }
        public ExcelReportMessage(DataTable data, int x = 1, int y = 1)
        {
            Properties = new Hashtable();
            Properties.Add("tableToExport", data);
            Properties.Add("startX", x);
            Properties.Add("startY", y);
        }
    }
}
