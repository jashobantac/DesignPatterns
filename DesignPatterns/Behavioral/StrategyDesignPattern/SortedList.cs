using System.Collections.Generic;

namespace Behavioral.StrategyDesignPattern
{
    public class SortedList
    {
        #region Private Variable Declarations.

        private readonly List<string> _items;
        private readonly SortStrategy _stategy;

        #endregion

        #region Constructors.

        public SortedList()
        {
            _items = new List<string>();
        }

        #endregion

        #region Public Properties.

        public void AddItem(string str)
        {
            _items.Add(str);
        }

        public void RemoveItem(string str)
        {
            _items.Remove(str);
        }

        public void Sort(SortStrategy strategy)
        {
            strategy.Sort(_items);
        }

        public List<string> GetItems()
        {
            return _items;
        }
        #endregion
    }
}
