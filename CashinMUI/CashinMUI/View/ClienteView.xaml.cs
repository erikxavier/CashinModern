using CashinMUI.Util;
using FirstFloor.ModernUI.Presentation;
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

namespace CashinMUI.Pages
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class ClienteView : UserControl
    {
        public ClienteView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            btnNovo.Focus();            
            cbTipoDoc.Items.Add(TipoDeDocumento.CPF);
            cbTipoDoc.Items.Add(TipoDeDocumento.CNPJ);
        }

        private void NovoOrcamento(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).ContentSource = new Uri("/View/OrcamentoView.xaml", UriKind.Relative);
        }
    }
}
