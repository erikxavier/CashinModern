using CashinMUI.ViewModel;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
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
using System.Windows.Shapes;

namespace CashinMUI.View
{
    /// <summary>
    /// Interaction logic for OrcamentoView.xaml
    /// </summary>
    public partial class OrcamentoView : UserControl, IContent
    {
        public OrcamentoView()
        {
            InitializeComponent();            
        }

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {

            var viewModel = DataContext as OrcamentoViewModel;
            if (viewModel != null)
            {
                viewModel.OnFragmnetNavigation(e);                
            }
            
        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {

  
            
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            var viewModel = DataContext as OrcamentoViewModel;
            if (viewModel != null)
            {
                viewModel.OnNavigatingFrom(e);
            }
        }
    }
}
