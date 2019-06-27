namespace AlgorithmsAndDataStructures.SearchAndSort
{
    public partial class SortingAlgorithms
    {
        // Insertion sort is an effective algorithm to sort small number of elements.
        // E.g sorting cards during a card game.
        public static int[] InsertionSort(int[] inputArray)
        {
            if (inputArray.Length < 2)
            {
                return inputArray;
            }

            for (int i = 1; i < inputArray.Length; i++)
            {
                int next = inputArray[i];
                System.Console.WriteLine("Placing element {0}", next);

                int j = i - 1;
                int prev = inputArray[j];
                int current = inputArray[i];

                while (inputArray[j] > current && j > 0)
                {
                    inputArray[j] = current;
                    inputArray[j + 1] = prev;
                    j--;
                    prev = inputArray[j];
                }

                System.Console.WriteLine("Re-Ordered Array : Iteration {0}", i);

                foreach (int item in inputArray)
                {
                    System.Console.Write("{0} ", item);
                }
            }
            return inputArray;
        }
    }
}
