using System.Windows;
using RegistroPonto.ViewModels;
using RegistroPonto.Views;



namespace RegistroPonto
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new FuncionarioViewModel();
        }

        //Abrir a janela Gerenciar
        private void GerenciarButton_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show(); 
            Close(); 
        }

        //Abrir a janela Registrar Ponto
        private void RegistrarPontoButton_Click(object sender, RoutedEventArgs e)
        {
            RegistroPontoView registroPontoView = new RegistroPontoView();
            registroPontoView.Show();
            Close(); 
        }


    }
}
 