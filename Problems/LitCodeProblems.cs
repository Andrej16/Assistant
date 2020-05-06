using System;

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
    }
}
