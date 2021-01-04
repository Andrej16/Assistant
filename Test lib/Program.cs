using System;

namespace TestLib
{
    class Program
    {
        public static Tester CurrentTester { get; set; }
        static void Main(string[] args)
        {
            CurrentTester = new Tester(new ParseJson());
            CurrentTester.DoTest();
            Console.ReadKey();
        }
    }
}
