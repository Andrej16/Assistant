using System;
using TestLib.Controllers;

namespace TestLib
{
    class Program
    {
        public static Tester CurrentTester { get; set; }
        static void Main()
        {
            CurrentTester = new Tester(new XmlTest());
            CurrentTester.DoTest();
            Console.ReadKey();
        }
    }
}
