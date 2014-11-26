using CashinMUI.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Correios.Net;
using System.Windows.Forms;

namespace CashinMUI.ViewModel
{
    class ClienteViewModel : ViewModelBase
    {
        public ClienteViewModel()
        {
            Usuario = (Usuario)App.Current.Properties["UsuarioLogado"];
            NovoCliente();
        }

        #region Variáveis
        
        private Usuario Usuario;

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

        private string _cep;
        public string CEP
        {
            get { return _cep; }
            set
            {
                if (_cep != value)
                {
                    _cep = value;
                    RaisePropertyChanged("CEP");
                    if (Cliente != null)
                    {
                        ProcuraCep();
                    }
                }
            }
        }

        #endregion

        #region Commands

        #endregion

        #region Lógicas de Negócio

        private void NovoCliente()
        {
            Cliente = new Cliente();
            Cliente.Usuario = Usuario;            
        }

        private void ProcuraCep()
        {
            try
            {
                Address adr = BuscaCep.GetAddress(CEP);                
                Cliente.Cidade = adr.City;
                Cliente.Endereco = adr.Street;
                Cliente.Estado = adr.State;
                
            }
            catch (Exception ex)
            {
                Cliente.Endereco = ex.Message;
            }
        }

        #endregion

    }
}
