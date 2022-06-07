using Assistant.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLib.Controllers
{
    public class CharRepeat : ITestLib, IStub
    {
        public void DoAction()
        {
            string input = "bjkaadcdadd";
            string notRepeat = "dghjkly";
            //var repo = RepeatReport(input);
            //Sort(ref input);
            //var repo = GetRepeatCollect(input);
            //Console.WriteLine(input);
            //Print(repo);
            //string charCollection = CharCollection(input);
            HasCharRepeat(input);
            //Console.WriteLine($"Char collection: {charCollection}");
        }

        public object DoSomeAction(object arg)
        {
            return GetRepeatCollect(arg as string);
        }

        #region Char collection 
        private string CharCollection(string input)
        {
            int counter = 1, repeats = 1, i = 1;
            char current;
            char[] chars = input.ToCharArray();
            Array.Sort(chars);
            current = chars[0];
            char cMax = chars[0];

            for (; i < chars.Length; i++)
            {
                if (chars[i] == current)
                    counter++;
                else
                {
                    counter = 1;
                    current = chars[i];
                }
                if (counter > repeats)
                {
                    repeats = counter;
                    cMax = chars[i - 1];
                }
            }
            return new string(cMax, repeats);
        }
        #endregion
        #region Repeat dictionary
        /// <summary>
        /// Некрасивый вариант
        /// </summary>
        private Dictionary<char, short> RepeatReport(string input)
        {
            Sort(ref input);
            char[] chars = input.ToCharArray();
            //Array.Sort(chars);
            char prev = chars[0];
            char curr;
            short count = 1;
            Dictionary<char, short> repo = new Dictionary<char, short>();
            for (int i = 1; i < chars.Length; i++)
            {
                curr = chars[i];

                if (curr == prev)
                    count++;
                else
                {
                    repo[prev] = count;
                    prev = curr;
                    count = 1;
                }
            }
            repo[prev] = count;
            repo = repo.OrderByDescending(r => r.Value).ToDictionary(x => x.Key, x => x.Value);
            return repo;
        }
        private void Print(Dictionary<char, short> pairs)
        {
            Console.WriteLine("Char\tCount");
            foreach (var item in pairs)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
        }
        private void Sort(ref string input)
        {
            char[] source = input.ToCharArray();
            for (int j = 0; j < source.Length; j++)
                for (int i = j; i < source.Length - 1; i++)
                    if (source[i] < source[i + 1])
                    {
                        var tmp = source[i];
                        source[i] = source[i + 1];
                        source[i + 1] = tmp;
                    }
            input = new string(source);
        }
        /// <summary>
        /// Интересный вариант
        /// </summary>
        private Dictionary<char, short> GetRepeatCollect(string input)
        {
            var result = new Dictionary<char, short>();

            foreach (char c in input)
                if (result.ContainsKey(c))
                    result[c] += 1;
                else
                    result.Add(c, 1);

            result = result.OrderByDescending(r => r.Value).ToDictionary(x => x.Key, x => x.Value);

            return result;
        }
        #endregion
        /***************************/
        public static string GetRepeatLinq(string stroka)
        {
            var result = from c in stroka
                         group c by c into g
                         orderby g.Count() descending
                         select g;

            string output = string.Empty;

            foreach (var c in result)   //.Distinct())
                output += c.Key;

            return output;
        }
        public static string GetRepeat(string input)
        {
            int lenght = input.Length;
            char[] inputChr = input.ToArray();
            char[] outChr = new char[lenght];
            int[] outFreq = new int[input.Length];
            char temp;
            int count;

            for (int i = 0; i < lenght; i++)
            {
                if (inputChr[i] != ' ')
                {
                    temp = inputChr[i];
                    count = 0;

                    for (int j = 0; j < lenght; j++)
                    {
                        if (inputChr[j] == temp)
                        {
                            count++;
                            inputChr[j] = ' ';
                        }
                    }
                    outChr[i] = temp;
                    outFreq[i] = count;
                }
            }
            //Sort
            char holdChr;
            for (int j = 0; j < lenght; j++)
                for (int i = 1, hold; i < lenght; i++)
                    if (outFreq[i] > outFreq[i - 1])
                    {
                        hold = outFreq[i];
                        holdChr = outChr[i];

                        outFreq[i] = outFreq[i - 1];
                        outChr[i] = outChr[i - 1];

                        outFreq[i - 1] = hold;
                        outChr[i - 1] = holdChr;
                    }
            string res = new string(outChr);

            return res;
        }

        public void RepeatCalculator(string source)
        {
            short[] vs = new short[127];
            short max = 0, inx = 0;
            foreach (char c in source)
            {
                vs[c]++;
            }

            for (int i = 0; i < source.Length; i++)
            {
                for (short j = 0; j < vs.Length; j++)
                    if (vs[j] > max)
                    {
                        max = vs[j];
                        inx = j;
                    }
                if (max > 0)
                {
                    Console.WriteLine("Symbol {0} - {1}", (char)inx, max);
                    max = 0;
                    vs[inx] = 0;
                }
            }
        }
        public string RepeatUseDictionary(string input)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic[c] = 1;
            }
            int[] sorted = new int[dic.Count];
            dic.Values.CopyTo(sorted, 0);
            for (int j = 0; j < sorted.Length; j++)
                for (int i = j; i < sorted.Length - 1; i++)
                    if (sorted[i] < sorted[i + 1])
                    {
                        var tmp = sorted[i];
                        sorted[i] = sorted[i + 1];
                        sorted[i + 1] = tmp;
                    }

            char[] result = new char[sorted.Length];
            for (int n = 0; n < result.Length; n++)
                for (int m = 0; m < dic.Count; m++)
                {
                    var pair = dic.ElementAt(m);
                    if (pair.Value == sorted[n])
                    {
                        result[n] = pair.Key;
                        dic[pair.Key] = 0;
                    }
                }
            return new string(result);
        }
        /// <summary>
        /// 1. Given a string, find out if there's repeat characters in it.
        /// </summary>
        /// <see>https://www.glassdoor.co.in/Interview/Coding-test-1-Given-a-string-find-out-if-there-s-repeat-characters-in-it-2-SQL-Given-a-Customer-table-and-a-Payment-QTN_2059702.htm</see>
        public void HasCharRepeat(string str)
        {
            char maxChar = '\n';
            int maxCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int count = 1;
                char current = str[i];
                for (int j = 0; j < str.Length; j++)
                {
                    if (i == j)
                        continue;
                    char subChar = str[j];
                    if (current == subChar)
                        count++;

                }
                if(count > maxCount)
                {
                    maxCount = count;       //dic[cur] = count;
                    maxChar = current;
                }
            }
            if(maxCount > 1)
                Console.WriteLine($"Char - {maxChar}, repeated - {maxCount}");
            else
                Console.WriteLine("No repeated char");
        }

    }
}
