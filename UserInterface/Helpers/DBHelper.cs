using Assistant;
using System;
using System.Collections.Generic;
using System.Data;

namespace UserInterface.Helpers
{
    class DBHelper
    {
        public DataTable SelectRows()
        {
            DataTable ds = new DataTable();

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1141 } };
            ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }
        public DataTable SelectRows2()
        {
            DataTable ds = new DataTable();

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1074 } };
            ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }
        public DataTable SelectRows3()
        {
            DataTable ds = new DataTable();

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1068 } };
            ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }

    }
}
