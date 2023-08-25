using System.Windows;
using System.Windows.Controls;

namespace RegistroPonto.Views
{
    public partial class RegistroPontoView : Window
    {
        public RegistroPontoView()
        {
            InitializeComponent();
        }

        private void VoltarButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
