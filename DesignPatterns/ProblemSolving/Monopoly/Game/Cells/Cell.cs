using ProblemSolving.Monopoly.Game.Players;

namespace ProblemSolving.Monopoly.Game.Cells
{
    public abstract class Cell
    {
        #region Public Properties.
        public abstract int Worth { get; set; }
        public virtual int Fine { get; set; } = 0;
        public virtual int Rent { get; set; } = 0;
        public virtual Player Owner { get; set; }
        public Cell Next { get; set; }

        #endregion

        #region Constructor.

        public Cell()
        {
        }

        #endregion

        #region Public Method Declarations.

        public int GetWorth()
        {
            return Worth - Fine;
        }

        #endregion
    }
}
