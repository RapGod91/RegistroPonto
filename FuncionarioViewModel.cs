using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RegistroPonto.Models;
using RegistroPonto.Repositories;

namespace RegistroPonto.ViewModels
{
    public class FuncionarioViewModel : INotifyPropertyChanged
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        public ObservableCollection<Funcionario> Funcionarios { get; set; }

        public Funcionario FuncionarioSelecionado { get; set; } // Adicione esta propriedade

        public ICommand CadastrarFuncionarioCommand { get; }
        public ICommand AtualizarFuncionarioCommand { get; }
        public ICommand ExcluirFuncionarioCommand { get; }

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

        private void AtualizarFuncionario(object parameter)
        {
            _funcionarioRepository.AtualizarFuncionario(FuncionarioSelecionado);
        }

        private void ExcluirFuncionario(object parameter)
        {
            _funcionarioRepository.ExcluirFuncionario(FuncionarioSelecionado);
            Funcionarios.Remove(FuncionarioSelecionado);
        }

        private Funcionario BuscarFuncionarioPorId(int id)
        {
            return _funcionarioRepository.BuscarFuncionarioPorId(id);
        }        
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
