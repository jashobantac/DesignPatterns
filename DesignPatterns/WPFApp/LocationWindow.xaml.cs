using System.Windows;
using WPFApp.ViewModels;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LocationWindow.xaml
    /// </summary>
    public partial class LocationWindow : Window
    {
        public LocationWindow()
        {
            InitializeComponent();
            DataContext = new LocationViewModel();
        }
    }
}
