using System.Windows;
using System.Windows.Controls;
using RegistroPonto.Repositories;
using RegistroPonto.Models;

namespace RegistroPonto
{
    public partial class Gestao : Window
    {
        public Gestao()
        {
            InitializeComponent();

            InitializeDatabase();
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
        private void CadastrarFuncionarioButton_Click(object sender, RoutedEventArgs e)
        {
            // Crie um objeto Funcionario com os dados do novo funcionário
            var novoFuncionario = new Funcionario
            {
                Nome = "Nome do Novo Funcionário",
                Cargo = "Cargo do Novo Funcionário",
                FotoPath = "Caminho da Foto"
            };

            var databaseContext = new DatabaseContext();
            // Crie uma instância do repositório de funcionários
            var funcionarioRepository = new FuncionarioRepository(databaseContext);

            // Chame o método para cadastrar o novo funcionário
            funcionarioRepository.CadastrarFuncionario(novoFuncionario);

            // Você pode adicionar aqui uma mensagem de sucesso, atualizar a lista de funcionários exibidos na interface, etc.
        }
        
    }
}
