using System.Collections.Generic;

namespace ProblemSolving.MarsRover
{
    public class MarsLand
    {
        #region Public Properties.

        private List<RoverClient> Rovers { get; set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        #endregion

        #region Constructors.

        public MarsLand(int height, int width)
        {
            Height = height;
            Width = width;

            Rovers = new List<RoverClient>();
        }

        #endregion

        #region Public Method Declarations.

        public void AddRover(RoverClient rover)
        {
            Rovers.Add(rover);
        }

        private List<RoverClient> GetRovers()
        {
            return Rovers;
        }

        #endregion
    }
}