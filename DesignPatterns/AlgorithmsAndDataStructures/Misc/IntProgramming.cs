using System;
using System.Text;

namespace AlgorithmsAndDataStructures.Misc
{
    public class IntProgramming
    {
        public static bool IsPrime(int number)
        {
            // Fermet's Little Theorom.

            //int mod = Math.Abs(number);
            //int a = 10;
            //return Math.Pow(a, number - 1) % number == 1;

            if (number == 0)
            {
                return false;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i < number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetFibonacciSeries(int n)
        {
            int prev = 0;
            int current = 1;
            int temp = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append(current + " ");
            for (int i = 0; i < n - 1; i++)
            {
                temp = current;
                current = prev + current;
                prev = temp;
                sb.Append(current + " ");
            }
            return sb.ToString();
        }
    }
}
