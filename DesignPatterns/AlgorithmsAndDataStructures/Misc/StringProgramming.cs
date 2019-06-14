using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Misc
{
    public class StringProgramming
    {
        public static List<int> GetSubarrayIndex(int[] items, int sum)
        {
            List<int> indexes = new List<int>();
            int index = 0;
            for (int i = 0; i < items.Length; i++)
            {
                int current = index;
                int calculatedSum = 0;
                while (calculatedSum <= sum && current < items.Length)
                {
                    calculatedSum += items[current];
                    if (calculatedSum == sum)
                    {
                        indexes.Add(index + 1);
                        indexes.Add(current + 1);
                        return indexes;
                    }
                    current++;
                }
                index++;
            }
            return indexes;
        }

        public static long SwapOddBits(int input)
        {
            long evenBits = input & 0xAAAAAAAA;
            long oddBits = input & 0x55555555;

            evenBits >>= 1;
            oddBits <<= 1;

            return evenBits | oddBits;
        }

        public static int MaximumIndexProblem(int[] inputArray, MaxIndexStrategy strategy)
        {
            #region Problem Statement.

            // Given an array A[] of N positive integers. 
            // The task is to find the maximum of j -i subjected to the constraint of 
            // A[i] <= A[j].

            // Input : 34 8 10 3 2 80 30 33 1
            // Output : Index of (80) - Index of (34)= 6 - 0 = 6 
            #endregion

            return strategy.MaximumIndexProblem(inputArray);
        }

        //public static 
    }
}
