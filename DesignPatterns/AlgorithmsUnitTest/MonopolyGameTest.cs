using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProblemSolving.Monopoly.Game;
using ProblemSolving.Monopoly.Game.Cells;
using ProblemSolving.Monopoly.Game.Players;

namespace AlgorithmsUnitTest
{
    [TestClass]
    public class MonopolyGameTest
    {
        [TestMethod]
        public void TestCellCount()
        {
            CellFactory factory = new CircularClosedCellFactory();
            string input = "E,E,J,H,E,T,J";
            string[] cellInput = input.Split(',');
            Board board = new Board(factory, input);
            Assert.IsTrue(board.TotalCells() == cellInput.Length);
        }

        [TestMethod]
        public void GetCurrentCellIndex()
        {
            CellFactory factory = new CircularClosedCellFactory();
            string input = "E,E,J,H,E,T,J";
            string[] cellInput = input.Split(',');
            Board board = new Board(factory, input);

            Player p1 = new Player(1, 1000, board.StartCell);
            Cell cell = p1.HopCell(3);
            Assert.IsTrue(board.GetCurrentCellIndex(cell) == 4);

            Cell badCell = new EmptyCell();
            Assert.IsTrue(board.GetCurrentCellIndex(badCell) == -1);
        }

        [TestMethod]
        public void HopCellTest()
        {
            CellFactory factory = new CircularClosedCellFactory();
            string input = "E,E,J,H,E,T,J";
            Board board = new Board(factory, input);

            Cell cell = board.StartCell;
            Player p1 = new Player(1, 1000, cell);
            p1.HopCell(7);
            Assert.IsTrue(board.GetCurrentCellIndex(p1.CurrentCell) == 1);

            p1.HopCell(3);
            Assert.IsTrue(board.GetCurrentCellIndex(p1.CurrentCell) == 4);
        }

        [TestMethod]
        public void DiceOutputTest()
        {
            string outComes = "4,5,6";
            Dice dice = new Dice(outComes);

            int outcome1 = dice.Roll();
            Assert.IsTrue(outcome1 == 4);

            int outcome2 = dice.Roll();
            Assert.IsTrue(outcome2 == 5);

            int outcome3 = dice.Roll();
            Assert.IsTrue(outcome3 == 6);

            int outcome4 = dice.Roll();
            Assert.IsTrue(outcome4 == 4);
        }

        [TestMethod]
        public void BuyHotel()
        {
            Cell start = new EmptyCell
            {
                Next = new Hotel()
            };

            Player p1 = new Player(1, 1000, start);
            p1.HopCell(1);
            int p1Money = p1.GetCash();

            Player p2 = new Player(2, 1000, start);
            p2.HopCell(1);
            int p2Money = p2.GetCash();

            Assert.IsTrue(start.Next.Owner == p1);

            Assert.IsTrue(p1Money == 800);
            Assert.IsTrue(p2Money == 950);
        }

        [TestMethod]
        public void RentHotel()
        {
            Cell start = new EmptyCell
            {
                Next = new Hotel()
            };
            Player p1 = new Player(1, 1000, start);
            p1.HopCell(1);
            int p1Money = p1.GetCash();
            Assert.IsTrue(p1Money == 800);

            Player p3 = new Player(1, 100, start);
            p3.HopCell(1);
            Assert.IsTrue(p3.GetCash() == 50);

            Assert.IsTrue(p1.GetCash() == 850);
        }

        [TestMethod]
        public void TestJail()
        {
            Cell start = new EmptyCell
            {
                Next = new Jail()
            };
            Player p1 = new Player(1, 1000, start);
            Player p2 = new Player(2, 1000, start);
            p1.HopCell(1);
            int p1Money = p1.GetCash();
            p2.HopCell(1);
            int p2Money = p2.GetCash();
            Assert.IsTrue(p1Money == 850);
            Assert.IsTrue(p2Money == 850);
        }

        [TestMethod]
        public void TestTreasure()
        {
            Cell start = new EmptyCell
            {
                Next = new Treasure()
            };
            Player p1 = new Player(1, 1000, start);
            Player p2 = new Player(2, 1000, start);
            p1.HopCell(1);
            int p1Money = p1.GetCash();
            p2.HopCell(1);
            int p2Money = p2.GetCash();
            Assert.IsTrue(p1Money == 1200);
            Assert.IsTrue(p2Money == 1200);
        }

        [TestMethod]
        public void TestBoard()
        {
            CellFactory factory = new CircularClosedCellFactory();

            //string input = "E,E,J,H,E,T,J,T,E,E,H,J,T,H,E,E,J,H,E,T,J,T,E,E,H,J,T,H,J,E,E,J,H,E,T,J,T,E,E,H,J,T,E,H,E";
            //string outComes = "4,4,4,6,7,8,5,11,10,12,2,3,5,6,7,8,5,11,10,12,2,3,5,6,7,8,5,11,10,12";

            string input = "E,E,J,H,E,T,J";
            string outComes = "1,1,2,1,2,3";
            Board board = new Board(factory, input);

            Dice dice = new Dice(outComes);

            GameRules gameRule = new GameRules
            {
                MaxMovesPerPlayer = 3,
                MinimumPlayerCount = 2
            };
            MonopolyGame game = new MonopolyGame(board, dice, gameRule);

            Player p1 = new Player(1, 1000, board.StartCell);
            Player p2 = new Player(2, 1000, board.StartCell);

            game.AddPlayer(p1);
            game.AddPlayer(p2);

            string outCome = game.StartGame();
            Assert.IsTrue(board.GetCurrentCellIndex(p1.CurrentCell) == 6);
            Assert.IsTrue(board.GetCurrentCellIndex(p2.CurrentCell) == 6);

            Assert.IsTrue(p1.GetTotalWorth() == 1200);
            Assert.IsTrue(p2.GetTotalWorth() == 1050);
        }
    }
}
