using System;

namespace TestLib
{
    class Program
    {
        public static Tester TesterCurrent { get; set; }
        static void Main(string[] args)
        {
            TesterCurrent = new Tester(new XmlTest());
            TesterCurrent.DoTest();
            Console.ReadKey();
        }
    }
}
