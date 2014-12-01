using CashinMUI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CashinMUI.View
{
    /// <summary>
    /// Interaction logic for UsuarioView.xaml
    /// </summary>
    public partial class UsuarioView : UserControl
    {
        public UsuarioView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
       
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                string senha;
                if (!string.IsNullOrEmpty(((PasswordBox)sender).Password))
                    senha = Utilitarios.GerarHashMD5(((PasswordBox)sender).Password);
                else
                    senha = string.Empty;
                ((dynamic)this.DataContext).Usuario.Senha = senha;
            }
        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                string senha;
                if (!string.IsNullOrEmpty(((PasswordBox)sender).Password))
                    senha = Utilitarios.GerarHashMD5(((PasswordBox)sender).Password);
                else
                    senha = string.Empty;
                ((dynamic)this.DataContext).ConfirmaSenha = senha;
            }
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            cbTipoDeDocumento.Items.Add(TipoDeDocumento.CPF);
            cbTipoDeDocumento.Items.Add(TipoDeDocumento.CNPJ);     
        }

        private void PasswordBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            pb1.Password = "";
            pb2.Password = "";
        }
    }
}
