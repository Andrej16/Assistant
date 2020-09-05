using Problems.RemoveZeroSumSublists;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// 420. Strong Password Checker
        /// </summary>
        /// <see cref="https://leetcode.com/problems/strong-password-checker/"/>
        public static int StrongPasswordChecker(string s)
        {
            char holdChar = s.Length > 0 ? s[0] : ' ';
            bool isLowercaseCheck = false, isUpperCaseCheck = false, isDigitCheck = false;
            int repeatCounter = 1, changesCounter = 3; //for must contain at least one lowercase letter, at least one uppercase letter, and at least one digit.

            for (int i = 0; i < s.Length; i++)
            {
                char symb = s[i];
                if (holdChar.Equals(symb))
                    repeatCounter++;
                else
                {
                    repeatCounter = 1;
                    holdChar = symb;
                }                   
                if (repeatCounter >= 3)
                    changesCounter++;

                if (!isLowercaseCheck && symb >= 97 && symb <= 122)
                {
                    changesCounter--;
                    isLowercaseCheck = true;
                }                    
                if (!isUpperCaseCheck && symb >= 65 && symb <= 90)
                {
                    changesCounter--;
                    isUpperCaseCheck = true;
                }                    
                if (!isDigitCheck && symb >= 48 && symb <= 57)
                {
                    changesCounter--;
                    isDigitCheck = true;
                }
            }
            if(s.Length >= 6 && s.Length <= 20)
                return changesCounter;
            else if(s.Length < 6)
            {
                changesCounter += 6 - s.Length;
            }
            else if(s.Length > 20)
            {
                changesCounter += s.Length - 20;
            }
            return changesCounter;
        }
        /// <summary>
        /// 665. Non-decreasing Array
        /// </summary>
        /// <see cref="https://leetcode.com/problems/non-decreasing-array/"/>
        public static bool CheckPossibility(int[] nums)
        {
            int max = -100000;
            int indx = 0;
            int count = 0;
            for (int pass = 0; pass < nums.Length; pass++)
            {
                int cond = nums.Length - pass;
                for (int i = 0; i < cond; i++)
                {
                    if (nums[i] > max)
                    {
                        max = nums[i];
                        indx = i;
                    }                      
                }

                if(indx < cond - 1)
                {
                    count++;
                    for (int m = indx + 1; m < cond; m++)
                    {
                        nums[m - 1] = nums[m];
                    }
                    nums[cond - 1] = max;
                }
                max = -100000;
            }
            return count <= 1;
        }
        public static bool CheckPossibility2(int[] nums)
        {
            int max = nums[0];
            int indx = 0;
            int count = 0;
            bool nm = false;

            for (int pass = 0; pass < nums.Length; pass++)
            {
                int cond = nums.Length - pass;
                for (int c = 0; c < cond; c++)
                {
                    if (max > nums[c])
                        nm = true;
                    else if(max != nums[c])
                    {
                        max = nums[c];
                        indx = c;
                    }
                }
                if (nm)
                {
                    for (int m = indx + 1; m < cond; m++)
                    {
                        nums[m - 1] = nums[m];

                    }
                    nums[cond - 1] = max;
                    count++;
                }
                max = nums[0];
                indx = 0;
                nm = false;
            }
            return count <= 1;
        }
        /// <summary>
        /// 1431. Kids With the Greatest Number of Candies
        /// </summary>
        /// <see cref="https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/"/>
        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            List<bool> resultList = new List<bool>();
            int max = int.MinValue;
            foreach (int num in candies)
            {
                if (num > max)
                    max = num;
            }
            foreach (int num in candies)
            {
                int tempCount = num + extraCandies;
                resultList.Add(tempCount >= max);
            }
            return resultList;
        }
        /// <summary>
        /// 1480. Running Sum of 1d Array
        /// </summary>
        /// <see cref="https://leetcode.com/problems/running-sum-of-1d-array/"/>
        public static int[] RunningSum(int[] nums)
        {
            int[] ra = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    ra[i] += nums[j];
                }
                ra[i] += nums[i];
            }
            return ra;
        }
        /// <summary>
        /// 1414. Find the Minimum Number of Fibonacci Numbers Whose Sum Is K
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        /// <see cref="https://leetcode.com/problems/find-the-minimum-number-of-fibonacci-numbers-whose-sum-is-k/"/>
        public static int FindMinFibonacciNumbers(int k)
        {
            int[] fibArr = new int[k + 2];
            int optimumIndx = 1;
            for (int i = 1; i < fibArr.Length; i++)
            {
                if (i == 1 || i == 2)
                    fibArr[i] = 1;
                else
                    fibArr[i] = fibArr[i - 1] + fibArr[i - 2];
                if (fibArr[i] <= k)
                    optimumIndx = i;
            }
            int counter = 0;
            int tempSum = 0;
            for(int n = optimumIndx; tempSum < k; n--)
            {
                if (fibArr[n] + tempSum <= k)
                {
                    tempSum += fibArr[n];
                    counter++;
                }                   
            }
            return counter;
        }
    }
}
