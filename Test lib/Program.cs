using System;
using TestLib.Controllers;

namespace TestLib
{
    class Program
    {
        public static Tester CurrentTester { get; set; }
        static void Main()
        {
            CurrentTester = new Tester(new BinaryTreeTest());
            CurrentTester.DoTest();
            Console.ReadKey();
        }
    }
}
