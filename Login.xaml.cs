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

        //Evento para voltar a página MainWindow
        private void VoltarButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //Evento ao clicar no "OK"
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            //Captura os dados inserios nos campos de login
            string usuario = LoginTextBox.Text;
            string senha = SenhaPasswordBox.Password;

            //Verificar se o usuário e senha estão são os mesmos cadasstrados
            if (usuario == "admin" && senha == "admin")
            {
                // Login bem-sucedido
                MessageBox.Show($"Bem-vindo, {usuario}!");

                //Crie e mostre uma nova janela de gestão
                Gestao gestaoWindow = new Gestao();
                gestaoWindow.Show(); 
                Close(); 
                                
            }
            else
            {
                // Login inválido
                MessageBox.Show("Usuário ou senha incorretos. Tente novamente.");
            }
        }
    }
}
