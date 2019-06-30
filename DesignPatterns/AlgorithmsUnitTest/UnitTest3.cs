using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemSolving.HackerRank.Backtracking;
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

    [TestClass]
    public class QueensAttackOneTest
    {
        [TestMethod]
        public void TestTotalHorizontalPossibleMoves()
        {
            int[,] obstacles = new int[,] {
                {5, 5},
                {4, 2},
                {2, 3}
            };
            foreach (int item in obstacles)
            {
                System.Console.WriteLine(item);
            }

            int totalMoves = QueensAttackProblem.GetTotalHorizontalPossibleMoves(4, 4, 4, obstacles);
            Assert.AreEqual(totalMoves, 3);

            //totalMoves = QueensAttackProblem.GetTotalHorizontalPossibleMoves(4, 4, new int[][] { });
            //Assert.AreEqual(totalMoves, 3);
        }

        [TestMethod]
        public void TestQueensAttackOne()
        {
            int totalMoves = QueensAttackProblem.QueensAttack(4, 0, 4, 4, new int[][] { });
            Assert.AreEqual(totalMoves, 9);
        }

        [TestMethod]
        public void TestNQueenAttack()
        {
            Position[] sol = NQueenProblem.GetPositions(4);
            Assert.IsTrue(sol.Length == 4);
        }
    }

    [TestClass]
    public class RemoveInvalidParanthesesTest
    {
        [TestMethod]
        public void TestBalancedString()
        {
            RemoveInvalidParenthesesProblem test = new RemoveInvalidParenthesesProblem();

            string str = "(())";
            bool isValidString = test.IsBalancedString(str);
            Assert.IsTrue(isValidString);

            str = ")(())";
            isValidString = test.IsBalancedString(str);
            Assert.IsFalse(isValidString);

            str = ")";
            isValidString = test.IsBalancedString(str);
            Assert.IsFalse(isValidString);

            str = "(aaaa((v)))";
            isValidString = test.IsBalancedString(str);
            Assert.IsTrue(isValidString);

            str = "()())()";
            System.Collections.Generic.List<string> possibleStrings = test.RemoveInvalidParantheses(str);
            Assert.IsTrue(possibleStrings.Count == 2);
        }
    }
}
