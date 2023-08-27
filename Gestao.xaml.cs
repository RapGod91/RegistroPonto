using System;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using RegistroPonto.Repositories;
using RegistroPonto.Models;
using RegistroPonto.ViewModels;
using RegistroPonto.Views;


namespace RegistroPonto
{
    //Classe da janela Gestão
    public partial class Gestao : Window
    {
        
        private FuncionarioViewModel _viewModel;

        public Funcionario NovoFuncionario { get; set; } = new Funcionario();
        public Gestao()
        {
            InitializeComponent();

            InitializeDatabase();

            _viewModel = new FuncionarioViewModel();

            DataContext = _viewModel;
        }

        //Inicia o BD e cria tabela funcionarios
        private void InitializeDatabase()
        {
            var databaseContext = new DatabaseContext();
            databaseContext.CreateFuncionarioTable();
        }

        //Evento para "Deslogar", fecha a janela atual e abre a de Login novamente
        private void DeslogarButton_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        //Evento de "selecionar foto"
        private void SelecionarFotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg, *.png)|*.jpg;*.png|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                // Atualize a propriedade FotoPath no ViewModel
                ((FuncionarioViewModel)DataContext).AtualizarFotoPath(openFileDialog.FileName);

                // Atualize a imagem exibida
                FotoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        //Evento para abrir em nova janela o Folha Ponto
        private void FolhaPontoButton_Click(object sender, RoutedEventArgs e)
        {
            FolhaPonto folhaPontoWindow = new FolhaPonto();
            folhaPontoWindow.ShowDialog();
        }
        


                
    }
}
