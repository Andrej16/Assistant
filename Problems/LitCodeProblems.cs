using Problems.RemoveZeroSumSublists;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Problems
{
    public static class LitCodeProblems
    {
        public static int[] SumZero(int n)
        {
            Random rnd = new Random();
            int[] arr = new int[n];
            int total = 0;

            for (int i = 0; i < n; i++)
            {
                if(i < n / 2)
                    arr[i] = rnd.Next(-10, 10);                   
                else
                    arr[i] = total > 0 ? rnd.Next(-total, 0) : rnd.Next(0, total);
                total += arr[i];
            }
            arr[n - 1] += total * -1;
            return arr;
        }
        public static string[] GetCorrectPhones(string file)
        {
            string[] phones = new string[100];
            int count = 0;
            string pattern = @"^(\(\d{3}\)\s\d{3}-\d{4})|(\d{3}-\d{3}-\d{4})$", line;
            StreamReader sr = new StreamReader(file);
            while((line = sr.ReadLine()) != null)
            {
                if(Regex.IsMatch(line.Trim(), pattern))
                    phones[count++] = line;

            }
            return phones;
        }
        public static ListNode RemoveZeroSumSublists(ListNode head)
        {
            ListNode headLocal = head;
            ListNode prevNode = head;
            ListNode curr = head.Next;
            ListNode beforeCortege = null;

            for (int pass = 0; curr != null; )
            {
                int res = prevNode.val + curr.val;
                if (res == 0)
                {
                    if (pass == 0) //first node delete
                    {
                        headLocal = curr.Next;
                    }
                    else
                    {
                        beforeCortege.Next = curr.Next;
                    }
                    pass = 0;
                    curr = headLocal;
                }
                else
                {
                    beforeCortege = prevNode;
                    pass++;
                    prevNode = curr;
                    curr = curr.Next;
                }
            }
            return headLocal;
        }
        /// <summary>
        /// 137. Single Number II
        /// </summary>
        /// <see cref="https://leetcode.com/problems/single-number-ii/"/>
        public static int SingleNumber(int[] nums)
        {
            int[] indHolder = new int[1000];

            for(int i = 0; i < nums.Length; i++)
                indHolder[nums[i]]++;

            for (int c = 0; c < indHolder.Length; c++)
                if (indHolder[c] == 1)
                    return c;
            return 0;
        }
    }
}
