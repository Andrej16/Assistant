namespace UserInterface
{
    public class Tester
    {
        ITestLib tester;
        public Tester(ITestLib tl)
        {
            tester = tl;
        }
        public void DoTest(object sender)
        {
            tester.DoAction(sender);
        }
    }
}
