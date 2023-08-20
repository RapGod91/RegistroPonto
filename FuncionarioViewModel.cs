using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using RegistroPonto.Models;
using RegistroPonto.Repositories;

namespace RegistroPonto.ViewModels
{
    public class FuncionarioViewModel : INotifyPropertyChanged
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        public ObservableCollection<Funcionario> Funcionarios { get; set; }

        public ICommand CadastrarFuncionarioCommand { get; }

        public FuncionarioViewModel()
        {
            var databaseContext = new DatabaseContext(); 
            
            _funcionarioRepository = new FuncionarioRepository(databaseContext);

            Funcionarios = new ObservableCollection<Funcionario>();

            CadastrarFuncionarioCommand = new RelayCommand(CadastrarFuncionario);
            
        }

        private void CadastrarFuncionario(object parameter)
        {
            
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
