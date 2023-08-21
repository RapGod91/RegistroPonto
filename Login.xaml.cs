using System.Windows;
using System.Windows.Controls;

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

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string usuario = LoginTextBox.Text;
            string senha = SenhaPasswordBox.Password;

            if (usuario == "admin" && senha == "admin")
            {
                // Login bem-sucedido
                MessageBox.Show($"Bem-vindo, {usuario}!");
            }
            else
            {
                // Login inválido
                MessageBox.Show("Usuário ou senha incorretos. Tente novamente.");
            }
        }
    }
}
