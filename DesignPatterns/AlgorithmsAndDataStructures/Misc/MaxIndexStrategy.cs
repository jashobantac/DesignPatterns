namespace AlgorithmsAndDataStructures.Misc
{
    public abstract class MaxIndexStrategy
    {
        public abstract int MaximumIndexProblem(int[] inputArray);
    }

    public class NormalStrategy : MaxIndexStrategy
    {
        /// <summary>
        /// Time Complexity is O(N)^2
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public override int MaximumIndexProblem(int[] inputArray)
        {
            int n = inputArray.Length;
            int maxDiff = -1;
            for (int i = 0; i < n; i++)
            {
                int ptr1 = i;
                int ptr2 = i;
                while (ptr2 < n)
                {
                    if (inputArray[ptr1] < inputArray[ptr2] && ptr2 - ptr1 > maxDiff)
                    {
                        maxDiff = ptr2 - ptr1;
                        System.Console.WriteLine("Max Diff : {0} {1} : {2}", ptr2, ptr1, maxDiff);
                    }
                    ptr2++;
                }
            }
            return maxDiff;
        }
    }
}
