namespace ProblemSolving.HackerRank.WarmUp
{
    //https://www.hackerrank.com/challenges/jumping-on-the-clouds
    public class JumpingOnTheClouds
    {
        public static int GetMinimumJumps(int[] clouds)
        {
            int totalSteps = 0;
            int current = 0;
            int length = clouds.Length;
            while (current < length - 1)
            {
                int cloud = clouds[current];
                if (current + 2 < length && clouds[current + 2] == 0)
                {
                    current = current + 2;
                }
                else if (current + 1 < length && clouds[current + 1] == 0)
                {
                    current = current + 1;
                }
                else if (current + 1 < length && clouds[current + 1] == 1)
                {
                    return -1;
                }
                totalSteps++;
            }
            return totalSteps;
        }
    }
}
