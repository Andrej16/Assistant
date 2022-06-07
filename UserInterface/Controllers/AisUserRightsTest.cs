using AisTools;
using System.Collections.Specialized;
using System.Data;

namespace UserInterface.Controllers
{
    public class AisUserRightsTest : ITestLib
    {
        private readonly UserRightsStore _userRightsStore;
        public bool isDepth { get; private set; }
        public AisUserRightsTest(bool isDepth)
        {
            _userRightsStore = new UserRightsStore();
            this.isDepth = isDepth;
        }
        public void DoAction(object sender)
        {
            DataTable expTable = PrepareTable(isDepth);
            ExcelReportMessage mess = new ExcelReportMessage(expTable);
            _userRightsStore.CreateReport(new ExcelFactory(mess));
        }
        /// <summary>
        /// Prepare table
        /// </summary>
        /// <param name="deptSign">Формировать отчет для всех пользователей подразделения</param>
        private DataTable PrepareTable(bool deptSign)
        {
            DataTable sourceTable;
            DataTable destinationTable = new DataTable();

            if (deptSign)
                sourceTable = null;//Query.Data(this, "pack_sub_de_rights.get_rights", new object[] { "p_su_id", _userId, "p_fromdept", 1 });
            else
                sourceTable = null;// Query.Data(this, "pack_sub_de_rights.get_rights", new object[] { "p_su_id", _userId });

            NameValueCollection obligCollect = new NameValueCollection
            {
                { "DEPT_NAME", "Департамент" },
                { "SUB_NAMEFULL", "Имя пользователя" }
            };

            DataTableFactory tableFactory = new DataTableFactory("FO_ID", "SDR_VALUE", "FO_NAME", destinationTable, sourceTable, obligCollect);
            tableFactory.AxisSwap();
            tableFactory.FillSwapedTable("SU_ID");

            return destinationTable;
        }

    }
}
