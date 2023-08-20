using System;
using System.Windows.Input;

namespace RegistroPonto.ViewModels
{
    public class GestaoViewModel : BaseViewModel
    {
        public ICommand OpenFolhaPontoCommand { get; }

        public GestaoViewModel()
        {
            OpenFolhaPontoCommand = new RelayCommand(_ => OpenFolhaPonto());
        }

        private void OpenFolhaPonto()
        {
            // Implemente a lógica para abrir a FolhaPontoView aqui
        }
    }
}
