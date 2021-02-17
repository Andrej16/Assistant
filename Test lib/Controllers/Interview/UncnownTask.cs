using System;

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
