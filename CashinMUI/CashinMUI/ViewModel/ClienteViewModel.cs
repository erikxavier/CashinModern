using CashinMUI.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Correios.Net;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace CashinMUI.ViewModel
{
    class ClienteViewModel : ViewModelBase
    {
        public ClienteViewModel()
        {
            Usuario = (Usuario)App.Current.Properties["UsuarioLogado"];
            DB = new CashinDB();
            DB.Log = Console.Out;
            AtualizaClientes();
            //NovoCliente();
        }

        #region Variáveis

        private CashinDB DB;

        private ObservableCollection<Cliente> _clientes;
        public ObservableCollection<Cliente> Clientes
        {
            get
            {
                return _clientes;
                
            }
            set
            {
                if (_clientes != value)
                {
                    _clientes = value;
                    RaisePropertyChanged("Clientes");
                }
            }
        }

        private bool _isEditing = false;
        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                if (_isEditing != value)
                {
                    _isEditing = value;
                    RaisePropertyChanged("IsEditing");
                }
            }
        }

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
                    if (_cliente == null)
                    {
                        IsEditing = false;
                        RaisePropertyChanged("CEP");
                    }
                    else IsEditing = true;
                }
            }
        }
        
        public string CEP
        {
            get {
                if (Cliente != null) return Cliente.Cep;
                else return null;
            }
            set
            {
                if (Cliente != null) {
                    if (Cliente.Cep != value)
                    {
                        Cliente.Cep = value;
                        RaisePropertyChanged("CEP");
                        if (Cliente != null)
                        {
                            ProcuraCep();
                        }
                    }
                }
            }
        }

        #endregion

        #region Commands

        private ICommand _novoCommand;
        public ICommand NovoCommand
        {
            get
            {
                return _novoCommand ?? (_novoCommand = new RelayCommand(Novo, CanNovo));
            }
        }

        private ICommand _cancelarCommand;
        public ICommand CancelarCommand
        {
            get
            {
                return _cancelarCommand ?? (_cancelarCommand = new RelayCommand(Cancelar,CanCancelar));
            }
        }

        private ICommand _salvarCommand;
        public ICommand SalvarCommand
        {
            get
            {
                return _salvarCommand ?? (_salvarCommand = new RelayCommand(Salvar, CanSalvar));
            }
        }

        #endregion

        #region Lógicas de Negócio

        private bool CanSalvar()
        {
            if (Cliente == null || string.IsNullOrEmpty(Cliente.Nome)) 
                return false;
            else return true;
        }

        private void Salvar()
        {
            if (Cliente.ID == 0)                 
                DB.Cliente.InsertOnSubmit(Cliente);
            try
            {                
                DB.SubmitChanges();
                AtualizaClientes();
                Cliente = null;
            }
            catch (Exception)
            {                    
                throw;
            }
        }

        private bool CanCancelar()
        {
            return IsEditing;
        }

        private void Cancelar()
        {
            Cliente = null;
        }

        private bool CanNovo()
        {
            return Cliente == null;
        }

        private void Novo()
        {
            Cliente = new Cliente();
            Cliente.Usuario = Usuario;            
        }

        private void AtualizaClientes()
        {
            //Clientes = new ObservableCollection<Cliente>(from c in DB.Cliente
            //                                                 where c.Usuario == Usuario
            //                                                 select c
            //                                            );

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
