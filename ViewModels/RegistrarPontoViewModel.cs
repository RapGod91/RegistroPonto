using System;
using System.Windows.Input;

namespace RegistroPonto.ViewModels
{
    public class RegistrarPontoViewModel : BaseViewModel
    {
        public ICommand RegistrarPontoCommand { get; }

        public RegistrarPontoViewModel()
        {
            RegistrarPontoCommand = new RelayCommand(_ => RegistrarPonto());
        }

        private void RegistrarPonto()
        {
            // Implemente a lógica para registrar o ponto aqui
        }
    }
}
