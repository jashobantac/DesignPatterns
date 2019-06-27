namespace ProblemSolving.HackerRank.WarmUp
{
    //https://www.hackerrank.com/challenges/counting-valleys/
    public class CountingValleys
    {
        public static int GetTotalValeysClimbed(int n, string steps)
        {
            int currentLevel = 0;
            int totalValleysCount = 0;
            //UDDDUDUU
            for (int i = 0; i < n; i++)
            {
                char currentStep = steps[i];
                switch (currentStep)
                {
                    case 'U':
                        currentLevel++;
                        if (currentLevel == 0)
                        {
                            totalValleysCount++;
                        }
                        break;
                    case 'D':
                        currentLevel--;
                        break;
                    default:
                        break;
                }
            }
            return totalValleysCount;
        }
    }
}
