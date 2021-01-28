namespace Uwp.Core
{
    public class Tester
    {
        ITest tester;
        public Tester(ITest tl)
        {
            tester = tl;
        }
        public void DoTest()
        {
            tester.DoAction();
        }
    }
}
