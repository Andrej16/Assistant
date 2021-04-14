using Problems.RemoveZeroSumSublists;
using System;
using System.Diagnostics;
using System.Threading;

namespace Problems
{
    class Program
    {
        private static Mutex mut = new Mutex(false, "Alone");
        private static void PrintArray(int[] result)
        {
            Console.Write("[ ");
            foreach (var item in result)
            {
                Console.Write(item + ", ");
            }
            Console.Write(']');
        }
        static void Main(string[] args)
        {
            //FindNUniqueIntegers();
            //FinePhones();
            //RemoveZeroSumSublists();
            //SingleNumber();
            //StrongPasswordChecker();
            //MutexUsing();
            //Console.WriteLine(RemoveOuterParentheses());
            //CheckPossibility();
            //KidsWithCandies();
            //RunningSum();
            //FindMinFibonacciNumbers();
            //RomanToInteger();
            //Merge();            
            //SubArray();
            //RemoveDuplicates();
            //IsPolindrome();
            //SingleNumber();
            //LongestCommonPrefix();
            TrailingZeroes();
            Console.ReadKey();
        }

        private static void TrailingZeroes()
        {
            string sourse = Console.ReadLine(); ;
            int number = sourse != "q" ? int.Parse(sourse) : -1; ;
            while (number != -1)
            {

                int zeroes = LitCodeProblems.TrailingZeroes(number);
                Console.WriteLine(zeroes);
                sourse = Console.ReadLine();
                number = sourse != "q" ? int.Parse(sourse) : -1;

            }
        }

        private static void IsPolindrome()
        {
            string sourse = default;
            int number = default;
            while (number != -1)
            {
                sourse = Console.ReadLine();
                number = sourse != "q" ? int.Parse(sourse) : -1;

                if (LitCodeProblems.IsPalindrome(number))
                    Console.WriteLine("Is polindrome");
                else
                    Console.WriteLine("No polindrome");
            }
        }

        private static void RemoveDuplicates()
        {
            int?[] source = { 0, 0, 2, 2, 1, 1, 1, 5, 3, 3, 4 };

            int newSize = LitCodeProblems.RemoveDuplicates(ref source);
            Console.WriteLine("New size is {0}", newSize);
            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }

        private static void FindMinFibonacciNumbers()
        {
            int k = 3;
            int count = LitCodeProblems.FindMinFibonacciNumbers(k);
            Console.WriteLine($"For k = {k} we can use {count}");
        }

        private static void RunningSum()
        {
            int[] input = { 3, 1, 2, 10, 1 };
            var result = LitCodeProblems.RunningSum(input);
            PrintArray(result);
        }
        private static string RemoveOuterParentheses(/*string s*/)
        {
            string s = "(()())(())";

            char[] inpArr = s.ToCharArray();

            for (int i = 0, cnt = 0; i < inpArr.Length; i++)
                if (s[i] == '(' && cnt++ == 0)
                    inpArr[i] = ' ';
                else if (s[i] == ')' && --cnt == 0)
                    inpArr[i] = ' ';

            return new string(inpArr).Replace(" ", "");
        }

        private static void CheckPossibility()
        {
            int[] falseResult = { 3, 4, 2, 3 }; //false
            int[] trueResult = { 4, 2, 3 };  //true
            int[] allEqual = { 1, 1, 1 }; //true
            if (LitCodeProblems.CheckPossibility2(allEqual))
                Console.WriteLine("Result is true!");
            else
                Console.WriteLine("Result is false!");
        }

        private static void MutexUsing()
        {
            if (!mut.WaitOne(1000))
                Process.GetCurrentProcess().Kill();
            Console.WriteLine("I am worked!");
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            mut.ReleaseMutex();
        }

        private static void StrongPasswordChecker()
        {
            string source = "1Qaz2wsx";
            Console.WriteLine(source);
            int min = LitCodeProblems.StrongPasswordChecker(source);
            Console.WriteLine("The MINIMUM change required to make s a strong password ==> {0}", min);
        }

        private static void SingleNumber2()
        {
            int[] input = { 0, 1, 0, 1, 0, 1, 99 };
            int res = LitCodeProblems.SingleNumber2(input);
            Console.WriteLine(res);
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
        private static void Merge()
        {
            LinkedList list = new LinkedList();
            list.Add(2);
            list.Add(4);
            list.Add(5);
            list.Add(9);
            list.Add(10);
            LinkedList second = new LinkedList();
            second.Add(3);
            second.Add(6);
            second.Add(8);
            Console.WriteLine("First list before:");
            Print(list._head);
            Console.WriteLine("Second list before:");
            Print(second._head);
            ListNode current = LinkedList.Merge(list._head, second._head);
            Console.WriteLine("Merged result list:");
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

        static void KidsWithCandies()
        {
            int[] candies = { 2, 3, 5, 1, 3 };
            var result = LitCodeProblems.KidsWithCandies(candies, 3);
            Console.Write('[');
            foreach (var item in result)
            {
                Console.Write(item ? "true, " : "false, ");
            }
            Console.WriteLine(']');
        }
        static void RomanToInteger()
        {
            string roman = "MCMXCIV";
            int result = LitCodeProblems.romanToInt(roman);
            Console.WriteLine($"Roman: {roman}");
            Console.WriteLine($"Integer: {result}");
        }
        static void SubArray()
        {
            int[] input = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int result = LitCodeProblems.SubArray(input);
            Console.WriteLine("Max value - {0}", result);
        }
        private static void SingleNumber()
        {
            int[] input = { 4, 1, 2, 1, 2 };
            int res = LitCodeProblems.SingleNumber(input);
            Console.WriteLine(res);
        }
        private static void LongestCommonPrefix()
        {
            string[] array = { "flower", "flow", "floight" };
            string prefix = LitCodeProblems.LongestCommonPrefix(array);
            Console.WriteLine(prefix);
        }
    }
}

