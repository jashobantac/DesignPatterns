using ProblemSolving.MarsRover;

namespace ProblemSolving
{
    public class MarsRoverDemo : IDemo
    {
        public void Run()
        {
            MarsLand marsLand = new MarsLand(5, 5);
            Rover rover1 = new Rover(new Position(3, 3), Direction.E);
            RoverClient roverClient1 = new RoverClient(rover1, marsLand.Width, marsLand.Height);
            string command = "MMRMMRMRRM";

            roverClient1.ProcessCommand(command);
        }
    }
}
