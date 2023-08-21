using System.Windows;
using System.Windows.Controls;

namespace RegistroPonto
{
    public partial class Gestao : Window
    {
        public Gestao()
        {
            InitializeComponent();
        }

        private void DeslogarButton_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
