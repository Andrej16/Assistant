using System;
using Assistant.Core;

namespace TestLib.Controllers.Interview
{
    public class UnknownTask : ITestLib
    {
        public void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
