using System.Collections.Generic;
using System.Text;

namespace Structural.AdapterDesignPattern
{
    public class Adaptee
    {
        private readonly List<string> _names;

        public Adaptee()
        {
            _names = new List<string>()
            {
                "Jasho",
                "Ritu"
            };
        }

        public virtual string GetNameString()
        {
            if (_names == null)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            foreach (string name in _names)
            {
                sb.Append(name + " ");
            }
            return sb.ToString().Trim();
        }
    }
}
