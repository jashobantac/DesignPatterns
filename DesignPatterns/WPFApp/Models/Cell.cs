using WPFApp.Models.Base;

namespace WPFApp.Models
{
    public class Cell : ModelBase
    {
        private int _x;
        public int X
        {
            get => _x;
            set
            {
                _x = value;
                RaisePropertyChanged(nameof(X));
            }
        }

        private int _y;
        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                RaisePropertyChanged(nameof(Y));
            }
        }

        private string _type;
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                RaisePropertyChanged(nameof(Type));
            }
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
