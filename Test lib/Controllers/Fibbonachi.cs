using System;
using Assistant.Core;

namespace TestLib.Controllers
{
    public class Fibbonachi : ITestLib
    {
        public void DoAction()
        {
            int input = 0;
            Console.WriteLine(GetFibbonachi(input));
            input = 1;
            Console.WriteLine(GetFibbonachi(input));
            input = 10;
            Console.WriteLine(GetFibbonachi(input));
            input = 11;
            Console.WriteLine(GetFibbonachi(input));

        }
        private long GetFibbonachi(int n)
        {
            long prev_2 = 0, prev_1 = 1, fib = 0;
            if (n == 0 || n == 1)
                return n;
            for (int i = 2; i <= n; i++)
            {
                fib = prev_1 + prev_2;
                prev_2 = prev_1;
                prev_1 = fib;
            }
            return fib;
        }
        private int GetFibbonachi1(int n)
        {
            int[] data = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                if (i == 0 || i == 1)
                    data[i] = i;
                else
                    data[i] = data[i - 2] + data[i - 1];
            }
            return data[n];
        }
        private int GetFibbinachi2(int n)
        {
            int current = 0, prew = 0, temp;

            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    current = 1;
                    continue;
                }
                temp = prew;
                prew = current;
                current += temp;
            }
            return current;
        }
    }

}

