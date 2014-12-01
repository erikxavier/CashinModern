using CashinMUI.ViewModel;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CashinMUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            LogoffCommand = new RelayCommand(o => Logoff(o), o => App.Current.Properties["UsuarioLogado"] != null);
            LinkNavigator.Commands.Add(new Uri("cmd://logoff", UriKind.Absolute), LogoffCommand);
            this.Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);                
        }

        public RelayCommand LogoffCommand { get; private set; }

        private void Logoff(object o)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
                viewModel.LogOut();            
        }
    }
}
