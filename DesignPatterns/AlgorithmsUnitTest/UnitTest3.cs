using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProblemSolving.HackerRank.WarmUp;

namespace AlgorithmsUnitTest
{
    [TestClass]
    public class SockProblemTest
    {
        [TestMethod]
        public void TestGetPairOfSocks()
        {
            int[] socks = new int[] { 0, 1, 3, 1, 3, 1 };
            int totalPairs = SockMerchantProblem.GetPairOfSocks(socks.Length, socks);
            Assert.AreEqual(totalPairs, 2);

            socks = new int[] { 1, 1, 3, 1, 3, 1 };
            totalPairs = SockMerchantProblem.GetPairOfSocks(socks);
            Assert.AreEqual(totalPairs, 3);

            socks = new int[] { 2, 4 };
            totalPairs = SockMerchantProblem.GetPairOfSocks(socks);
            Assert.AreEqual(totalPairs, 0);

        }

        [TestMethod]
        public void TestGetPairOfSocks1()
        {
            int[] socks = new int[] { 0, 1, 3, 1, 3, 1 };
            int totalPairs = SockMerchantProblem.GetPairOfSocks(socks);
            Assert.AreEqual(totalPairs, 2);

            socks = new int[] { 1, 1, 3, 1, 3, 1 };
            totalPairs = SockMerchantProblem.GetPairOfSocks(socks);
            Assert.AreEqual(totalPairs, 3);

            socks = new int[] { 2, 4 };
            totalPairs = SockMerchantProblem.GetPairOfSocks(socks);
            Assert.AreEqual(totalPairs, 0);
        }
    }

    [TestClass]
    public class CountingValleysTest
    {
        [TestMethod]
        public void TestCount()
        {
            string strSteps = "UDDDUDUU";
            int totalValleys = CountingValleys.GetTotalValeysClimbed(strSteps.Length, strSteps);
            Assert.AreEqual(totalValleys, 1);

            strSteps = "UDDDUDUUDDUU";
            totalValleys = CountingValleys.GetTotalValeysClimbed(strSteps.Length, strSteps);
            Assert.AreEqual(totalValleys, 2);

            string test1 = "abcde";
            string test2 = "bcdacecccc";

            string test3 = new string(test1.Except(test2).ToArray());
            //Assert.IsTrue(test3 == "bd");
        }
    }

    [TestClass]
    public class JumpingOnTheCloudTest
    {
        [TestMethod]
        public void TestJump()
        {
            int[] clouds = new int[] { 0, 1, 0, 0, 0, 1, 0 };
            int jumps = JumpingOnTheClouds.GetMinimumJumps(clouds);

            clouds = new int[] { 0, 0, 1, 0, 0, 1, 0 };
            jumps = JumpingOnTheClouds.GetMinimumJumps(clouds);
            Assert.IsTrue(jumps == 4);
        }
    }

    public class QueensAttackOneTest
    {

    }
}
