using System;
using System.Windows.Input;

namespace RegistroPonto.ViewModels
{
    // Classe que implementa ICommand para criar comandos utilizados em ViewModels
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        //Construtor da classe
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        //Verificar se o comando pode ser executado
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        //Metodo para executar o comando
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // Evento disparado quando a habilidade de execução do comando muda
        public event EventHandler CanExecuteChanged;
    }
}
