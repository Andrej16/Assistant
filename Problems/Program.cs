using System;

namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindNUniqueIntegers();
            FinePhones();
            Console.ReadKey();
        }

        private static void FinePhones()
        {
            string[] arr = LitCodeProblems.GetCorrectPhones(@"D:\Downloads\file.txt");
            foreach (var item in arr)
            {
                if (item is null)
                    break;
                Console.WriteLine(item);
            }
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
