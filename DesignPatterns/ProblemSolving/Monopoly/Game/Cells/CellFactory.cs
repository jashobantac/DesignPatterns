namespace ProblemSolving.Monopoly.Game.Cells
{
    public abstract class CellFactory
    {
        public abstract Cell CreateCell(string cellType);
    }

    public class CircularClosedCellFactory : CellFactory
    {
        public override Cell CreateCell(string cellType)
        {
            switch (cellType.ToUpper())
            {
                case "E":
                    return new EmptyCell();
                case "J":
                    return new Jail();
                case "H":
                    return new Hotel();
                case "T":
                    return new Treasure();
                default:
                    break;
            }
            return null;
        }
    }
}
