using Assistant;
using Assistant.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using ParametersCollection = System.Collections.Generic.Dictionary<string, object>;

namespace TestLib.Controllers
{
    public class BaseFactoryTest : ITestLib
    {
        public void DoAction()
        {
            throw new NotImplementedException();
        }
        private static void BaseFactoryExecute()
        {
            BaseFactory bf = new BaseFactory(Assistant.DbType.Work);

            DataTable dt = bf.SelectToTable("pack_street.sel_street", 16);
            //DataTable dt = bf.SelectToTableByParName("pack_street.find_street", "p_st_ci_id", 1141);
        }

        private static void BaseFactoryUniversalFunc()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.Test"];
            // "System.Data.OracleClient"
            dt = BaseFactoryUniversal.GetProviderFactoryClasses();
            using (BaseFactoryUniversal ubf = new BaseFactoryUniversal("System.Data.OracleClient", settings.ConnectionString))
            {
                //dt = ubf.GetProviderFactoryClasses();
                //dt = ubf.SelectToTable("pack_street.sel_street", 16);
                //var pars = new Dictionary<string, object>(){ {"p_st_ci_id", 1141} };
                //result = ubf.Scalar("pack_street.find_street", pars);
                //dt = ubf.SelectToTable("pack_street.find_street", pars);

                var pars = new Dictionary<string, object>() { { "p_obl_id", 1002 } };

                ds = ubf.SelectToDataSet("OPEN_TWO_CURSORS", pars);
            }
        }
        private static int TestUpdate()
        {
            BaseFactory dl = new BaseFactory(Assistant.DbType.Test);
            int res;
            var pars = new ParametersCollection() {
                { "p_te_id", 271 },
                { "p_te_parent_id", 123 },
                { "p_te_cod_ibc", 1604 },
                { "p_te_active", "N" }
            };

            //pars.Add("p_te_parent_id", 123);
            //pars.Add("p_te_cod_ibc", 1604);
            //pars.Add("p_te_name", "Test Update");
            //pars.Add("p_te_rate", 777);

            res = Convert.ToInt32(dl.Update("pack_dt_types_estate.upd_dt_types_estate", pars));
            return res;
        }
        private static int TestExecute()
        {
            BaseFactory dl = new BaseFactory(Assistant.DbType.Test);
            int res = dl.Execute("pack_debug_info.upd_debug_info", 16, "Test method execute with call procedure.");
            res = dl.Execute("pack_debug_info.upd_debug_infoFunc", 16, "Test method execute with call function.");
            return res;
        }

    }
}
