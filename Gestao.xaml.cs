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
        
    }
}
