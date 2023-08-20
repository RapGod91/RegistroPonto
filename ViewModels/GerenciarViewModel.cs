using System;
using System.Windows.Input;

namespace RegistroPonto.ViewModels
{
    public class GerenciarViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }

        public GerenciarViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login());
        }

        private void Login()
        {
            // Implemente a lógica de login aqui
        }
    }
}
