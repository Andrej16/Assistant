using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidPassports
{
    public abstract class DataTableFileBinderBase
    {
        protected DataTable Table { get; set; }
        internal void Make()
        {
            PrepareTable();
            FillTable();
        }
        protected abstract void PrepareTable();
        protected abstract void FillTable();
    }
}
