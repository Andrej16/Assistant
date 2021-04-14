using System;
using Assistant.Core;
using TestLib.Controllers;

namespace TestLib
{
    class Program
    {
        public static Tester CurrentTester { get; set; }
        static void Main()
        {
            CurrentTester = new Tester(new CharRepeat());
            CurrentTester.DoTest();
            Console.ReadKey();
        }
    }
}
