using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging; 
using RegistroPonto.Models;
using RegistroPonto.Repositories;

namespace RegistroPonto.Views
{
    public partial class FolhaPonto : Window
    {
        private readonly DatabaseContext _databaseContext;
        private readonly FuncionarioRepository _funcionarioRepository; // Certifique-se de que esta linha está presente
        private readonly RegistroPontoRepository _registroPontoRepository; // Certifique-se de que esta linha está presente

        public FolhaPonto()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
            _funcionarioRepository = new FuncionarioRepository(_databaseContext);
            _registroPontoRepository = new RegistroPontoRepository(_databaseContext);
        }


        
        private void VoltarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            string nomeFuncionario = NomeFuncionarioTextBox.Text;

            if (!string.IsNullOrWhiteSpace(nomeFuncionario))
            {
                Funcionario funcionarioEncontrado = _funcionarioRepository.BuscarFuncionarioPorNome(nomeFuncionario);

                if (funcionarioEncontrado != null)
                {
                    IdFuncionarioTextBlock.Text = funcionarioEncontrado.Id.ToString();
                    NomeFuncionarioTextBlock.Text = funcionarioEncontrado.Nome;
                    CargoFuncionarioTextBlock.Text = funcionarioEncontrado.Cargo;
                    FotoFuncionarioImage.Source = new BitmapImage(new Uri(funcionarioEncontrado.FotoPath));

                    // Exibir os registros de ponto do funcionário
                    List<RegistroPontoItem> registros = _registroPontoRepository.ObterRegistrosPontoPorFuncionario(funcionarioEncontrado);

                    // Criar uma lista de todas as datas do mesmo mês do funcionário
                    int year = DateTime.Now.Year; // Use o ano atual como exemplo, você pode ajustar conforme necessário
                    int month = DateTime.Now.Month; // Use o mês atual como exemplo, você pode ajustar conforme necessário

                    List<DateTime> todasAsDatasDoMes = new List<DateTime>();
                    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                    {
                        todasAsDatasDoMes.Add(new DateTime(year, month, day));
                    }

                    // Encontrar as datas ausentes comparando as listas de datas
                    List<DateTime> datasAusentes = todasAsDatasDoMes.Except(registros.Select(registro => registro.DataHora.Date)).ToList();

                    // Formatar a lista de registros para exibição
                    var registrosFormatados = registros.Select(registro => new { DataHoraFormatada = registro.DataHora.ToString("dd/MM/yyyy HH:mm:ss"), Ausente = false })
                        .Concat(datasAusentes.Select(dataAusente => new { DataHoraFormatada = dataAusente.ToString("dd/MM/yyyy"), Ausente = true }));

                    RegistroPontoListView.ItemsSource = registrosFormatados;
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.");
                    LimparDetalhesFuncionario();
                }
            }
            else
            {
                MessageBox.Show("Digite o nome do funcionário para buscar.");
                LimparDetalhesFuncionario();
            }
        }





        private void LimparDetalhesFuncionario()
        {
            IdFuncionarioTextBlock.Text = string.Empty;
            NomeFuncionarioTextBlock.Text = string.Empty;
            CargoFuncionarioTextBlock.Text = string.Empty;
            FotoFuncionarioImage.Source = null;
            RegistroPontoListView.ItemsSource = null;
        }


    }

}