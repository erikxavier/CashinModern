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
            DB = new CashinDB();
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

        #endregion

        #region Lógicas de Negócio


        public void GetCliente(FragmentNavigationEventArgs e)
        {
            Cliente = DB.Cliente.Where(c => c.ID == int.Parse(e.Fragment)).Single();
        }

        #endregion
    }
}
