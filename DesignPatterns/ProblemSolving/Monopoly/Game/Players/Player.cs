using System.Collections.Generic;
using System.Linq;

using ProblemSolving.Monopoly.Game.Cells;

namespace ProblemSolving.Monopoly.Game.Players
{
    public class Player
    {
        #region Private Variable Declarations.

        private int _money;
        private readonly List<Cell> _playerCells;

        #endregion

        #region Public Properties.

        public int NumOfMoves { get; private set; }
        public int Number { get; set; }
        public List<Cell> OwnedHotels { get; private set; }
        public Cell CurrentCell { get; private set; }

        #endregion

        #region Constructors.

        public Player(int number, int intialMoney, Cell startCell)
        {
            Number = number;
            _money = intialMoney;
            CurrentCell = startCell;

            _playerCells = new List<Cell>();
            OwnedHotels = new List<Cell>();
        }

        #endregion

        #region Public Method Declarations.

        public int RollDice(Dice dice)
        {
            return dice.Roll();
        }

        public Cell HopCell(int cellCount)
        {
            CurrentCell = GetNthCell(cellCount, CurrentCell);
            if (CurrentCell is Hotel)
            {
                TryBuyHotel(CurrentCell as Hotel);
            }
            else
            {
                _money += CurrentCell.GetWorth();
            }
            NumOfMoves++;
            return CurrentCell;
        }

        public void ReceiveRent(int rentAmount)
        {
            _money += rentAmount;
        }

        public override string ToString()
        {
            return string.Format("Player-{0} has total worth {1}", Number, GetTotalWorth());
        }

        public int GetTotalWorth()
        {
            int hotelWorth = OwnedHotels.Sum(x => x.Worth);
            return _money + hotelWorth;
        }

        public int GetCash()
        {
            return _money;
        }

        #endregion

        #region Private Method Declarations.

        private Cell GetNthCell(int cellsToMove, Cell cell)
        {
            Cell nextCell = cell;
            for (int i = 0; i < cellsToMove; i++)
            {
                if (cell.Next != null)
                {
                    nextCell = nextCell.Next;
                }
            }
            return nextCell;
        }

        private bool TryBuyHotel(Hotel hotel)
        {
            // If hotel already belongs to the owner.
            if (hotel.Owner == this)
            {
                return false;
            }

            // For non owned hotel.
            if (hotel.Owner == null && _money > hotel.Worth)
            {
                hotel.Owner = this;
                _money = _money - hotel.GetWorth();
                OwnedHotels.Add(hotel);
                return true;
            }
            else
            {
                // If owner is available, pay rent.
                if (hotel.Owner != null && _money > hotel.Rent)
                {
                    Player owner = hotel.Owner;
                    PayRent(owner, hotel.Rent);
                }
                return false;
            }
        }

        private void PayRent(Player owner, int rentAmount)
        {
            _money -= rentAmount;
            owner.ReceiveRent(rentAmount);
        }

        #endregion
    }
}
