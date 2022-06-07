using Assistant;
using Assistant.Core;
using Assistant.Helpers;
using System;
using System.IO;

namespace TestLib.Controllers
{
    public class CoreToolTest : ITestLib
    {
        public void DoAction()
        {
            string insertSQL = CoreTool.MakeInsertSQLStatement(typeof(UserProfile));
            Console.WriteLine(insertSQL);
        }
    }

    public class UserProfile
    {
        public int Id { get; set; }

        public string ManagerName { get; set; }

        public string Department { get; set; }

        public string ChangeNotes { get; set; }
    }

}
