namespace Assistant.Core
{
    public class Tester
    {
        public ITestLib Test { get; set; }
        public Tester(ITestLib tl)
        {
            Test = tl;
        }
        public void DoTest()
        {
            Test.DoAction();
        }
    }
}
