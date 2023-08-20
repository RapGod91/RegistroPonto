using System.Windows;
using RegistroPonto.ViewModels;


namespace RegistroPonto.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
