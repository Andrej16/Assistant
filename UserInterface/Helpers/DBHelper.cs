using Assistant;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace UserInterface
{
    public class DBHelper
    {
        public DataTable Find(object cityId)
        {
            Debug.WriteLine($"Find, View: dgvThreadTest, ThreadID: {Thread.CurrentThread.ManagedThreadId}");
            DataTable ds = new DataTable();

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", cityId } };
            ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }
        public DataTable GetZaporishyaStreets()
        {

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1001 } };
            DataTable ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }
        public DataTable SelectRows2()
        {
            Debug.WriteLine($"SelectRows2, View: dgvThreadTest2, ThreadID: {Thread.CurrentThread.ManagedThreadId}");

            DataTable ds;

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1074 } };
            ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }
        public DataTable SelectRows3()
        {
            Debug.WriteLine($"SelectRows3, View: dgvThreadTest3, ThreadID: {Thread.CurrentThread.ManagedThreadId}");

            DataTable ds = new DataTable();

            BaseFactory ubf = new BaseFactory(Assistant.DbType.Test);
            var pars = new Dictionary<string, object>() { { "p_st_ci_id", 1068 } };
            ds = ubf.SelectToTable("pack_street.find_street", pars);
            return ds;
        }

    }
}
