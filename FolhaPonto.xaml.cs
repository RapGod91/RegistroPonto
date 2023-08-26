using System;
using System.Linq;
using System.Windows;
using RegistroPonto.Models;
using RegistroPonto.Repositories;

namespace RegistroPonto.Views
{
    public partial class FolhaPonto : Window
    {
        private DatabaseContext _databaseContext;

        public FolhaPonto()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            string nomeFuncionario = NomeFuncionarioTextBox.Text;
            
            
        }

        private void VoltarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}