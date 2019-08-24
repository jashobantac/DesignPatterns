using System;
using System.Collections.Generic;
using ProblemSolving.Demo;

namespace ProblemSolving
{

    internal class Program
    {
        private static int[] rotLeft(int[] arr, int d)
        {
            Dictionary<int, int> arrayMap = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                arrayMap[i] = arr[(i + d) % arr.Length];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arrayMap[i];
            }

            return arr;
        }

        private static long repeatedString(string s, long n)
        {
            //int j = 0;
            //int totalCount = 0;
            //int k = 0;
            //while (k < n)
            //{
            //    k++;
            //    if (j == s.Length)
            //    {
            //        j = 0;
            //    }

            //    if (s[j] == 'a')
            //    {
            //        totalCount++;
            //    }
            //    j++;
            //}
            //return totalCount;

            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            long total = 0;
            int totalAs = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s.ToUpper()[i] == 'A')
                {
                    totalAs++;
                }
            }
            if (totalAs == 0)
            {
                return 0;
            }

            total = n / s.Length * totalAs;
            if (n % s.Length != 0)
            {
                long left = n % s.Length;
                for (int i = 0; i < left; i++)
                {
                    if (s.ToUpper()[i] == 'A')
                    {
                        total++;
                    }
                }
            }
            return total;
        }

        private static IDemo _demo;
        private static void Main(string[] args)
        {
            long test = repeatedString("abb", 100000000);

            //_demo = new MarsRoverDemo();
            //_demo = new IPodInventoryDemo();
            _demo = new SnakeDemo();

            _demo.Run();
            Console.ReadLine();
        }
    }
}
