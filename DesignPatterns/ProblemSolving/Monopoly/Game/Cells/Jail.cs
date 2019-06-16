namespace ProblemSolving.Monopoly.Game.Cells
{
    public class Jail : Cell
    {
        public override int Worth { get; set; }
        public override int Fine { get; set; } = 150;
    }
}
