using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    /// <summary>
    /// Database type
    /// </summary>
    public enum DbType
    {
        /// <summary>
        /// Test base
        /// </summary>
        Test,
        /// <summary>
        /// Work base
        /// </summary>
        Work
    }
    /// <summary>
    /// Programm type
    /// </summary>
    public enum TranFlag
    {
        /// <summary>
        /// Not create transaction
        /// </summary>
        WithoutTran,
        /// <summary>
        /// Create transaction
        /// </summary>
        CreateTran
    }
    public enum ESqlType
    {
        None,
        Select,
        Execute,
        Cursor,
        Procedure,
        Function
    }
}
