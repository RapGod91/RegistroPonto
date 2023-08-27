using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RegistroPonto.Models;
using RegistroPonto.Repositories;


namespace RegistroPonto.ViewModels
{
    // Classe que fornece os dados e comportamentos relacionados a funcionários na interface
    public class FuncionarioViewModel : INotifyPropertyChanged
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        // Coleção de funcionários para exibição na interface
        public ObservableCollection<Funcionario> Funcionarios { get; set; }

        // Funcionário selecionado na interface
        private Funcionario _funcionarioSelecionado;
        public Funcionario FuncionarioSelecionado
        {
            get { return _funcionarioSelecionado; }
            set
            {
                _funcionarioSelecionado = value;
                OnPropertyChanged(nameof(FuncionarioSelecionado));

                // Atualiza a exibição da foto quando um funcionário for selecionado
                FotoPath = _funcionarioSelecionado?.FotoPath;
            }
        }

        // Caminho da foto do funcionário
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

        // Método para atualizar o caminho da foto
        public void AtualizarFotoPath(string novoCaminho)
        {
            FotoPath = novoCaminho;
        }


        // Comandos para interação com a interface
        public ICommand CadastrarFuncionarioCommand { get; }
        public ICommand AtualizarFuncionarioCommand { get; }
        public ICommand ExcluirFuncionarioCommand { get; }

        //Construtor
        public FuncionarioViewModel()
        {
            var databaseContext = new DatabaseContext(); 
            _funcionarioRepository = new FuncionarioRepository(databaseContext);

            Funcionarios = new ObservableCollection<Funcionario>();

            CarregarFuncionarios();
            
            CadastrarFuncionarioCommand = new RelayCommand(CadastrarFuncionario);
            AtualizarFuncionarioCommand = new RelayCommand(AtualizarFuncionario);
            ExcluirFuncionarioCommand = new RelayCommand(ExcluirFuncionario);
        }

        // Método para carregar funcionários do banco de dados na coleção
        private void CarregarFuncionarios()
        {
            // Limpar a coleção antes de recarregar os dados
            Funcionarios.Clear();

            // Carregar os funcionários do banco de dados e adicioná-los à coleção
            var funcionariosDoBanco = _funcionarioRepository.ObterTodosFuncionarios();
            foreach (var funcionario in funcionariosDoBanco)
            {
                Funcionarios.Add(funcionario);
            }
        }


        //Método para cadastrar um novo funcionario
        private void CadastrarFuncionario(object parameter)
        {
            Funcionario novoFuncionario = new Funcionario
            {
                Nome = NovoFuncionarioNome,
                Cargo = NovoFuncionarioCargo,
                FotoPath = FotoPath 
            };

            // Chamar o método de cadastro do repositório
            _funcionarioRepository.CadastrarFuncionario(novoFuncionario);

            
            // Adicionar o funcionário recém-cadastrado à coleção
            Funcionarios.Add(novoFuncionario);

            OnPropertyChanged(nameof(Funcionarios));
        }


        // Propriedades para a interface de cadastro de funcionários
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

        
        // Métodos para atualizar e excluir funcionários
        //Sendo que o atualizar será implementado posteriormente
        private void AtualizarFuncionario(object parameter)
        {
            if (FuncionarioSelecionado != null)
            {
                // Chamar o método de atualização do repositório
                _funcionarioRepository.AtualizarFuncionario(FuncionarioSelecionado);
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

        //Método para buscar por ID
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
