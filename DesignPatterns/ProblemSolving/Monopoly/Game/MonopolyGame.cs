using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProblemSolving.Monopoly.Game.Players;

namespace ProblemSolving.Monopoly.Game
{
    public class GameRules
    {
        public int MaxMovesPerPlayer = 5;
        public int MinimumPlayerCount = 2;
    }

    public class MonopolyGame
    {
        private readonly GameRules _rule;

        #region Public Properties.

        public Dice Dice { get; set; }
        public Board Board { get; set; }
        public List<Player> Players { get; private set; }

        #endregion

        #region Constructor.

        public MonopolyGame(Board board, Dice dice, GameRules rule)
        {
            _rule = rule;

            Board = board;
            Dice = dice;
            Players = new List<Player>();
        }

        #endregion

        #region Public Method Declarations.

        public void AddPlayer(Player player)
        {
            if (!Players.Contains(player))
            {
                Players.Add(player);
            }
        }

        public string StartGame()
        {
            if (Players.Count < _rule.MinimumPlayerCount)
            {
                return "Minimum Two Players are required to play the game.";
            }
            while (Players.Any(x => x.NumOfMoves < _rule.MaxMovesPerPlayer))
            {
                foreach (Player player in Players.Where(x => x.NumOfMoves < _rule.MaxMovesPerPlayer))
                {
                    int outcome = player.RollDice(Dice);
                    player.HopCell(outcome);
                }
            }
            Console.WriteLine("Game Over");
            return PrintResult();
        }

        #endregion

        #region Private Method Declarations.

        private string PrintResult()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Player player in Players.OrderByDescending(x => x.GetTotalWorth()))
            {
                builder.Append(player + Environment.NewLine);
            }
            return builder.ToString();
        }

        #endregion
    }
}
