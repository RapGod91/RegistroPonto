using System;
using System.Windows;
using System.Windows.Controls;
using RegistroPonto.Models;
using RegistroPonto.Repositories;



namespace RegistroPonto.Views
{
    public partial class RegistroPontoView : Window
    {
        private DatabaseContext _databaseContext;

        public RegistroPontoView()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
        }


        private void VoltarButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IdFuncionarioTextBox.Text, out int funcionarioId))
            {
                _databaseContext.CreateRegistroPontoTable();

                var registroPontoRepository = new RegistroPontoRepository(_databaseContext);

                var novoRegistro = new RegistroPontoItem
                {
                    FuncionarioId = funcionarioId,
                    DataHora = DateTime.Now,
                };

                registroPontoRepository.InserirRegistroPonto(novoRegistro.FuncionarioId, novoRegistro.DataHora);

                MessageBox.Show("Registro de ponto realizado com sucesso!");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();


            }
            else
            {
                MessageBox.Show("Por favor, insira um ID de funcionário válido.");
            }
        }




    }
}
