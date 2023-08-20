using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RegistroPonto
{
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Ocorreu um erro inesperado: {e.Exception.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
