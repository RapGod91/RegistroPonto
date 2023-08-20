using System.Windows;

namespace RegistroPonto
{
    public partial class Login : Window
    {
        public Login()
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
