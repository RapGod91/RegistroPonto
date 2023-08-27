using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
 