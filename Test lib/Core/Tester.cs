﻿namespace TestLib
{
    public class Tester
    {
        ITestLib tester;
        public Tester(ITestLib tl)
        {
            tester = tl;
        }
        public void DoTest()
        {
            tester.DoAction();
        }
    }
}