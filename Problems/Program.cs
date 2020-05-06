using System;

namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            FindNUniqueIntegers();

            Console.ReadKey();
        }
        static void FindNUniqueIntegers()
        {
            int nn = 5;
            int[] result = LitCodeProblems.SumZero(nn);
            
            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
