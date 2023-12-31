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
        //Variáveis de contexto e repositório
        private readonly DatabaseContext _databaseContext;
        private readonly FuncionarioRepository _funcionarioRepository; // Certifique-se de que esta linha está presente
        private readonly RegistroPontoRepository _registroPontoRepository; // Certifique-se de que esta linha está presente

        //Construtor
        public FolhaPonto()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
            _funcionarioRepository = new FuncionarioRepository(_databaseContext);
            _registroPontoRepository = new RegistroPontoRepository(_databaseContext);
        }


        //Evento para fechar a janela
        private void VoltarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Evento para o botão Buscar
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            string nomeFuncionario = NomeFuncionarioTextBox.Text;

            if (!string.IsNullOrWhiteSpace(nomeFuncionario))
            {
                Funcionario funcionarioEncontrado = _funcionarioRepository.BuscarFuncionarioPorNome(nomeFuncionario);

                if (funcionarioEncontrado != null)
                {
                    //Preenche informações do funcionario
                    IdFuncionarioTextBlock.Text = funcionarioEncontrado.Id.ToString();
                    NomeFuncionarioTextBlock.Text = funcionarioEncontrado.Nome;
                    CargoFuncionarioTextBlock.Text = funcionarioEncontrado.Cargo;
                    FotoFuncionarioImage.Source = new BitmapImage(new Uri(funcionarioEncontrado.FotoPath));

                    // Exibe os registros de ponto do funcionário
                    List<RegistroPontoItem> registros = _registroPontoRepository.ObterRegistrosPontoPorFuncionario(funcionarioEncontrado);

                    // Formata os registros de ponto para exibição na primeira coluna
                    var registrosFormatados = registros.Select(registro => new { Registro = registro.DataHora.ToString("dd/MM/yyyy HH:mm:ss"), DataAusente = string.Empty });

                    // Cria uma lista de todas as datas do mesmo mês do funcionário
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;

                    List<DateTime> todasAsDatasDoMes = new List<DateTime>();
                    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                    {
                        todasAsDatasDoMes.Add(new DateTime(year, month, day));
                    }

                    // Encontra as datas ausentes comparando as listas de datas
                    List<DateTime> datasAusentes = todasAsDatasDoMes.Except(registros.Select(registro => registro.DataHora.Date)).ToList();

                    // Formata as datas ausentes para exibição na segunda coluna
                    var datasAusentesFormatadas = datasAusentes.Select(dataAusente => new { Registro = string.Empty, DataAusente = dataAusente.ToString("dd/MM/yyyy") });

                    // Combina as listas de registros e datas ausentes formatadas
                    var registrosEDataAusente = registrosFormatados.Concat(datasAusentesFormatadas);

                    // Mostra registros de ponto e datas ausentes no ListView
                    RegistroPontoListView.ItemsSource = registrosEDataAusente;

                    // Mostra quantidade de dias ausentes
                    DiasAusentesTextBlock.Text = $"Dias Ausentes no Mês: {datasAusentes.Count}";
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

        //Limpa detalhes do funcion´pario
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