using System.Collections.Generic;

namespace ProblemSolving.HackerRank.WarmUp
{
    //https://www.hackerrank.com/challenges/sock-merchant/problem
    public class SockMerchantProblem
    {
        public static int GetPairOfSocks(int totalSocks, int[] socks)
        {
            int totalPairs = 0;
            Dictionary<int, int> sockPairs = new Dictionary<int, int>();
            for (int i = 0; i < totalSocks; i++)
            {
                int sock = socks[i];
                if (sockPairs.ContainsKey(sock))
                {
                    if (sockPairs[sock] == 1)
                    {
                        sockPairs[sock] = 0;
                        totalPairs++;
                    }
                    else
                    {
                        sockPairs[sock] = 1;
                    }
                }
                else
                {
                    sockPairs.Add(sock, 1);
                }
            }
            return totalPairs;
        }

        public static int GetPairOfSocks(int[] socks)
        {
            int totalSocks = socks.Length;
            int totalPairedSock = 0;
            Dictionary<int, bool> pairedSocks = new Dictionary<int, bool>();
            if (totalSocks <= 1)
            {
                return 0;
            }

            for (int i = 0; i < totalSocks; i++)
            {
                int sock = socks[i];
                // If the sock already is present.
                if (pairedSocks.ContainsKey(sock))
                {
                    pairedSocks[sock] = !pairedSocks[sock];
                }
                else
                {
                    pairedSocks.Add(sock, false);
                }
                if (pairedSocks[sock] == true)
                {
                    totalPairedSock++;
                }
            }
            return totalPairedSock;
        }
    }
}
