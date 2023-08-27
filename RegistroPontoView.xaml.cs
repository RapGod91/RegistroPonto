using System;
using System.Windows;
using RegistroPonto.Models;
using RegistroPonto.Repositories;



namespace RegistroPonto.Views
{
    public partial class RegistroPontoView : Window
    {
        private DatabaseContext _databaseContext;

        //Construtor
        public RegistroPontoView()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
        }


        //Evento do botão Voltar
        
        private void VoltarButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //Evento do botão OK ´para registrar o ponto
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IdFuncionarioTextBox.Text, out int funcionarioId))
            {
                // Cria a tabela de registros de ponto se não existir
                _databaseContext.CreateRegistroPontoTable();

                // Cria uma instância do RegistroPontoRepository
                var registroPontoRepository = new RegistroPontoRepository(_databaseContext);

                // Cria um novo registro de ponto
                var novoRegistro = new RegistroPontoItem
                {
                    FuncionarioId = funcionarioId,
                    DataHora = DateTime.Now,
                };

                //Insere o registro de ponto no BD
                registroPontoRepository.InserirRegistroPonto(novoRegistro.FuncionarioId, novoRegistro.DataHora);

                MessageBox.Show("Registro de ponto realizado com sucesso!");

                //Volta para MainWindow quanto o registro é OK
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
