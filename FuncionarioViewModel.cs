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
            Funcionario novoFuncionario = new Funcionario
            {
                Nome = "Novo Funcionário",
                Cargo = "Desconhecido",
                FotoPath = "CaminhoDaFoto"
            };

            // Chamar o método de cadastro do repositório
            _funcionarioRepository.CadastrarFuncionario(novoFuncionario);

            // Adicionar o funcionário recém-cadastrado à coleção
            Funcionarios.Add(novoFuncionario);
            
        }

        private void AtualizarFuncionario(Funcionario funcionario)
        {
            _funcionarioRepository.AtualizarFuncionario(funcionario);
        }

        private void ExcluirFuncionario(Funcionario funcionario)
        {
            _funcionarioRepository.ExcluirFuncionario(funcionario);
            Funcionarios.Remove(funcionario);
        }

        private Funcionario BuscarFuncionarioPorId(int id)
        {
            return _funcionarioRepository.BuscarFuncionarioPorId(id);
        }



        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
