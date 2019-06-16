using System.Collections.Generic;

namespace ProblemSolving.Monopoly.Game
{
    public class Dice
    {
        private int _currentDiceIndex;
        private List<int> _diceOutputs;

        #region Constructors

        public Dice(string outcomes)
        {
            string[] outputs = outcomes.Split(',');
            PopulateOutcomes(outputs);
        }

        #endregion

        #region Public Method Declarations.

        public int Roll()
        {
            System.Console.WriteLine("Rolling Dice.");
            int diceOutput = _diceOutputs[_currentDiceIndex];

            _currentDiceIndex++;
            if (_currentDiceIndex == _diceOutputs.Count)
            {
                _currentDiceIndex = 0;
            }

            System.Console.WriteLine("Dice-Output", _currentDiceIndex);
            return diceOutput;
        } 

        #endregion

        #region Private Method Declarations.

        private void PopulateOutcomes(string[] outputs)
        {
            _diceOutputs = new List<int>();
            foreach (string item in outputs)
            {
                if (int.TryParse(item, out int output))
                {
                    _diceOutputs.Add(output);
                }
            }
        }

        #endregion
    }
}