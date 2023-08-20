using System.Windows.Input;

namespace RegistroPonto.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand AbrirRegistrarPontoCommand { get; }
        public ICommand AbrirGerenciarCommand { get; }

        public MainWindowViewModel()
        {
            AbrirRegistrarPontoCommand = new RelayCommand(AbrirRegistrarPonto);
            AbrirGerenciarCommand = new RelayCommand(AbrirGerenciar);
        }

        private void AbrirRegistrarPonto(object parameter)
        {
            // Implementação para abrir a janela de registro de ponto
        }

        private void AbrirGerenciar(object parameter)
        {
            // Implementação para abrir a janela de gerenciamento
        }
    }
}
