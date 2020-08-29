using Problems.RemoveZeroSumSublists;
using System;
using System.Diagnostics;
using System.Threading;

namespace Problems
{
    class Program
    {
        private static Mutex mut = new Mutex(false, "Alone");
        static void Main(string[] args)
        {
            //FindNUniqueIntegers();
            //FinePhones();
            //RemoveZeroSumSublists();
            //SingleNumber();
            //StrongPasswordChecker();
            //MutexUsing();

            Console.WriteLine(RemoveOuterParentheses());
            CheckPossibility();
            Console.ReadKey();
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
            if(LitCodeProblems.CheckPossibility2(allEqual))
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

        private static void SingleNumber()
        {
            int[] input = { 0, 1, 0, 1, 0, 1, 99 };
            int res = LitCodeProblems.SingleNumber(input);
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

