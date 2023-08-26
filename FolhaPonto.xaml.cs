using System;
using System.Windows;

namespace RegistroPonto.Views
{
    public partial class FolhaPonto : Window
    {
        public FolhaPonto()
        {
            InitializeComponent();
        }

        private void VoltarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}