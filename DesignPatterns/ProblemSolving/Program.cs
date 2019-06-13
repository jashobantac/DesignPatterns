using System;
using ProblemSolving.MarsRover;

namespace ProblemSolving
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MarsLand marsLand = new MarsLand(5, 5);
            Rover rover1 = new Rover(new Position(3, 3), Direction.E);
            RoverClient roverClient1 = new RoverClient(rover1, marsLand.Width, marsLand.Height);
            string command = "MMRMMRMRRM";

            //Console.WriteLine(string.Format("Initial Position of Rover is : ({0},{1}),{2}",
            //    rover1.Position.X,
            //    rover1.Position.Y,
            //    rover1.Direction));

            roverClient1.ProcessCommand(command);

            //Console.WriteLine(string.Format("The Final Position of Rover is : ({0},{1}),{2}",
            //    rover1.Position.X,
            //    rover1.Position.Y,
            //    rover1.Direction));

            Console.ReadLine();
        }
    }
}
