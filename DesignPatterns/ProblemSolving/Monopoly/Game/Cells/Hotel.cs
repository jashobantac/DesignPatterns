using ProblemSolving.Monopoly.Game.Cells;

namespace ProblemSolving.Monopoly.Game
{
    public class Hotel : Cell
    {
        public override int Worth { get; set; } = 200;
        public override int Rent { get; set; } = 50;
    }
}
