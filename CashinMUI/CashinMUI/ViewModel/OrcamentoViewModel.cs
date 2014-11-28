using CashinMUI.Model;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CashinMUI.ViewModel
{
    class OrcamentoViewModel : ViewModelBase
    {
        public OrcamentoViewModel()
        {

        }

        #region Variáveis

        private CashinDB DB;

        private Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set
            {
                if (_cliente != value)
                {
                    _cliente = value;
                    RaisePropertyChanged("Cliente");
                }
            }
        }

        #endregion

        #region Commands

        private RelayCommand<NavigationEventArgs> _getClienteCommand;
        public RelayCommand<NavigationEventArgs> GetClienteCommand
        {
            get
            {
                return _getClienteCommand ?? (_getClienteCommand = new RelayCommand<NavigationEventArgs>(GetCliente, CanGetCliente));
            }
        }

        #endregion

        #region Lógicas de Negócio

        private bool CanGetCliente(NavigationEventArgs e)
        {
            return true;
        }

        private void GetCliente(NavigationEventArgs e)
        {
            ModernDialog.ShowMessage("Funcionou!", "Mensagem", MessageBoxButton.OK);
        }

        #endregion
    }
}
