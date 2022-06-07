using Problems.RemoveZeroSumSublists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        public static int SingleNumber2(int[] nums)
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
        /// <summary>
        /// 13. Roman to Integer
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <see cref="https://leetcode.com/problems/roman-to-integer/"/>
        public static int romanToInt(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);
            int temp, sum = 0;
            bool smalstRight = false;

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i + 1])
                {
                    case 'V' when s[i].Equals('I'):
                        temp = 4;
                        smalstRight = true;
                        break;
                    case 'X' when s[i].Equals('I'):
                        temp = 9;
                        smalstRight = true;
                        break;
                    case 'L' when s[i].Equals('X'):
                        temp = 40;
                        break;
                    case 'C' when s[i].Equals('X'):
                        temp = 90;
                        smalstRight = true;
                        break;
                    case 'D' when s[i].Equals('C'):
                        temp = 400;
                        smalstRight = true;
                        break;
                    case 'M' when s[i].Equals('C'):
                        temp = 900;
                        smalstRight = true;
                        break;
                    default:
                        temp = dict[s[i]];
                        break;
                }
                i = smalstRight ? i + 1 : i;
                sum += temp;
                smalstRight = false;
            }
            return sum;
        }
        /// <summary>
        /// 53. Maximum Subarray
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// <see cref="https://leetcode.com/problems/maximum-subarray/"/>
        public static int SubArray(int[] nums)
        {
            int l = 0, r = nums.Length - 1, ce = 0, currentMain = 0, li = 0, ri = 0, i;
            bool isEqual = false;
            int[] sumArray = new int[nums.Length];
            int max = int.MinValue;
            for( i = 0; currentMain < nums.Length - 2; i++)
            {
                int sum = 0;
                for (int m = l; m <= r; m++)
                {
                    sum += nums[m];
                }
                sumArray[i] = sum;
                if (nums[l] == nums[r])
                {
                    isEqual = true;
                    ce = 1;
                    for (li = l + 1, ri = r - 1; nums[li] == nums[ri]; li++, ri--, ce++) ;
                }
                int lindx = isEqual ? li : l;
                int rindx = isEqual ? ri : r;

                if (nums[lindx] > nums[rindx])
                    r -= ce + 1;
                else
                    l += ce + 1;

                isEqual = false;
                currentMain += ce + 1;
                ce = 0;                
            }
            sumArray[i + 1] = nums[l] + nums[r];
            for (int k = 0; k <= i; k++)
            {
                if (sumArray[k] > max)
                    max = sumArray[k];
            }
            return max;
        }
        /// <summary>
        /// 26. Remove Duplicates from Sorted Array (+!Not sorted)
        /// </summary>
        /// <see cref="https://leetcode.com/problems/remove-duplicates-from-sorted-array/"/>
        public static int RemoveDuplicates(ref int?[] nums)
        {
            int? current;
            int count = 0;
           
            for (int i = 0; i < nums.Length; i++)
            {
                current = nums[i];
                if (current is null)
                    continue;
                for (int ii = i + 1; ii < nums.Length; ii++)
                    if(current == nums[ii])
                    { 
                        nums[ii] = null;
                        count++;
                    }
            }

            int customLength = nums.Length;
            int chainNull, ni;
            for (int i = 0; i < customLength; i++)
            {
                current = nums[i];
                if(current is null)
                {
                    for (ni = i; nums[ni] is null; ni++) 
                        ;
                    chainNull = ni - i;
                    for (int mi = i; mi < nums.Length - chainNull; mi++)
                    {
                        int next = mi + chainNull;
                        nums[mi] = nums[next];
                    }
                    customLength -= chainNull;
                }
            }
            Array.Resize(ref nums, customLength);
            return nums.Length;
        }
        /// <summary>
        /// 9. Palindrome Number
        /// </summary>
        /// <see cref="https://leetcode.com/problems/palindrome-number/"/>
        public static bool IsPalindrome(int n)
        {
            if (n < 0)
                return false;
            int current = n, lastInteg, delimeter = 10, reversed = default;

            while(current > 0)
            {
                lastInteg = current % delimeter;
                current -= lastInteg;
                current /= delimeter;
                reversed = reversed * delimeter + lastInteg;
            }
            return reversed == n;
        }
        public static int SingleNumber(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                bool hasDuplicate = false;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                        continue;
                    if (nums[i] == nums[j])
                    {
                        hasDuplicate = true;
                        break;
                    }
                        
                }
                if (!hasDuplicate)
                    return nums[i];
            }
            return -1;
        }
        /// <summary>
        /// 14. Longest Common Prefix
        /// </summary>
        /// <see cref="https://leetcode.com/problems/longest-common-prefix/"/>
        public static string LongestCommonPrefix(string[] strs)
        {
            bool isExists = true;
            char[] current = strs[0].ToCharArray();
            char[] prefix = new char[200];
            Action<int> action = (i) => prefix[i] = ' ';
            Parallel.For(0, prefix.Length, action);
            for (int inx = 0; inx < current.Length; inx++)
            {
                char c = current[inx];
                for (int j = 1; j < strs.Length; j++)
                {
                    string s = strs[j];
                    if(s[inx] != c)
                    {
                        isExists = false;
                        break;
                    }
                }
                if (isExists)
                {
                    prefix[inx] = c;
                }
                else
                {
                    break;
                }
            }

            return new string(prefix);
        }
        /// <summary>
        /// 172. Factorial Trailing Zeroes
        /// </summary>
        /// <see cref="https://leetcode.com/problems/factorial-trailing-zeroes/"/>
        public static int TrailingZeroes(int n)
        {
            int zeroes = 0;
            
            int factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            int divBalance;

            do
            {
                divBalance = factorial % 10;
                factorial /= 10;
                if (divBalance == 0)
                    zeroes++;
            } while (divBalance == 0);
            return zeroes;
        }
        /// <summary>
        /// 190. Reverse Bits
        /// </summary>
        /// <see cref="https://leetcode.com/problems/reverse-bits/"/>
        public static int ReverseBits(int origin)
        {
            int mask = 0b_0000_0001;
            int temp = 0;
            int result = 0;

            for (int i = 1; i <= 8; i++)
            {
                temp = origin & mask;
                origin >>= 1;
                result |= temp;
                if (i == 8)
                    continue;
                result <<= 1;
            }

            return result;
        }
        /// <summary>
        /// 566. Reshape the Matrix
        /// </summary>
        ///<see cref="https://leetcode.com/problems/reshape-the-matrix/"/>
        public static int[] MatrixReshape(int[,] source)
        {
            int sourceCount = source.Length;

            int[] destArray = new int[sourceCount];
            int inx = 0;
            for(int row = 0; row < source.GetLength(0); row++)
            {
                for(int coll = 0; coll < source.GetLength(1); coll++)
                {
                    destArray[inx++] = source[row, coll];
                }
            }
            return destArray;
        }
    }
}
