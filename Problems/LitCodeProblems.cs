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
    }
}
