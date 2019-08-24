using System.Windows;
using System.Windows.Controls;

namespace WPFApp.Controls
{
    /// <summary>
    /// Interaction logic for FieldControl.xaml
    /// </summary>
    public partial class FieldControl : UserControl
    {


        public int Breadth
        {
            get => (int)GetValue(BreadthProperty);
            set => SetValue(BreadthProperty, value);
        }

        // Using a DependencyProperty as the backing store for Breadth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BreadthProperty =
            DependencyProperty.Register("Breadth", typeof(int), typeof(FieldControl), new PropertyMetadata(10));

        public int Length
        {
            get => (int)GetValue(LengthProperty);
            set => SetValue(LengthProperty, value);
        }

        // Using a DependencyProperty as the backing store for Length.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LengthProperty =
            DependencyProperty.Register("Length", typeof(int), typeof(FieldControl), new PropertyMetadata(10));



        public FieldControl()
        {
            InitializeComponent();
        }
    }
}
