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

        private Funcionario _funcionarioSelecionado;
        public Funcionario FuncionarioSelecionado
        {
            get { return _funcionarioSelecionado; }
            set
            {
                _funcionarioSelecionado = value;
                OnPropertyChanged(nameof(FuncionarioSelecionado));

                // Atualize a exibição da foto quando um funcionário for selecionado
                FotoPath = _funcionarioSelecionado?.FotoPath;
            }
        }

        private string _fotoPath;
        public string FotoPath
        {
            get { return _fotoPath; }
            set
            {
                _fotoPath = value;
                OnPropertyChanged(nameof(FotoPath));
            }
        }

        public ICommand CadastrarFuncionarioCommand { get; }
        public ICommand AtualizarFuncionarioCommand { get; }
        public ICommand ExcluirFuncionarioCommand { get; }

        public FuncionarioViewModel()
        {
            var databaseContext = new DatabaseContext(); 
            _funcionarioRepository = new FuncionarioRepository(databaseContext);

            Funcionarios = new ObservableCollection<Funcionario>();

            CadastrarFuncionarioCommand = new RelayCommand(CadastrarFuncionario);
            AtualizarFuncionarioCommand = new RelayCommand(AtualizarFuncionario);
            ExcluirFuncionarioCommand = new RelayCommand(ExcluirFuncionario);
        }


        private void CadastrarFuncionario(object parameter)
        {
            Funcionario novoFuncionario = new Funcionario
            {
                Nome = NovoFuncionarioNome,
                Cargo = NovoFuncionarioCargo,
                FotoPath = FotoPath // Use a propriedade FotoPath diretamente, se ela estiver sendo atualizada corretamente
            };

            // Chamar o método de cadastro do repositório
            _funcionarioRepository.CadastrarFuncionario(novoFuncionario);

            // Adicionar o funcionário recém-cadastrado à coleção
            Funcionarios.Add(novoFuncionario);

            OnPropertyChanged(nameof(Funcionarios));
        }


        private string _novoFuncionarioNome;
        public string NovoFuncionarioNome
        {
            get { return _novoFuncionarioNome; }
            set
            {
                _novoFuncionarioNome = value;
                OnPropertyChanged(nameof(NovoFuncionarioNome));
            }
        }

        private string _novoFuncionarioCargo;
        public string NovoFuncionarioCargo
        {
            get { return _novoFuncionarioCargo; }
            set
            {
                _novoFuncionarioCargo = value;
                OnPropertyChanged(nameof(NovoFuncionarioCargo));
            }
        }




        private void AtualizarFuncionario(object parameter)
        {
            if (FuncionarioSelecionado != null)
            {
                // Atualizar os detalhes do funcionário selecionado
                FuncionarioSelecionado.Nome = FuncionarioSelecionado.Nome; // Não é necessário alterar o nome
                FuncionarioSelecionado.Cargo = FuncionarioSelecionado.Cargo; // Não é necessário alterar o cargo

                // Chamar o método de atualização do repositório
                _funcionarioRepository.AtualizarFuncionario(FuncionarioSelecionado);
                OnPropertyChanged(nameof(Funcionarios));
            }
        }

        private void ExcluirFuncionario(object parameter)
        {
            if (FuncionarioSelecionado != null)
            {
                _funcionarioRepository.ExcluirFuncionario(FuncionarioSelecionado);
                Funcionarios.Remove(FuncionarioSelecionado);
                OnPropertyChanged(nameof(Funcionarios));
            }
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
