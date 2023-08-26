using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using RegistroPonto.Repositories;
using RegistroPonto.Models;
using RegistroPonto.ViewModels;
using System.Windows.Data;
using RegistroPonto.Views;


namespace RegistroPonto
{
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

        private void InitializeDatabase()
        {
            var databaseContext = new DatabaseContext();
            databaseContext.CreateFuncionarioTable();
        }

        private void DeslogarButton_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

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

        private void FolhaPontoButton_Click(object sender, RoutedEventArgs e)
        {
            FolhaPonto folhaPontoWindow = new FolhaPonto();
            folhaPontoWindow.ShowDialog();
        }
        


                
    }
}
