using Problems.RemoveZeroSumSublists;
using System;

namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindNUniqueIntegers();
            //FinePhones();
            RemoveZeroSumSublists();
            Console.ReadKey();
        }

        private static void RemoveZeroSumSublists()
        {
            LinkedList list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(-3);
            list.Add(-2);
            Console.WriteLine("Before:");
            Print(list._head);
            ListNode current = LitCodeProblems.RemoveZeroSumSublists(list._head);
            Console.WriteLine("After:");
            Print(current);
            void Print(ListNode cur)
            {
                while (cur != null)
                {
                    Console.WriteLine(cur.val);
                    cur = cur.Next;
                }
            }
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

