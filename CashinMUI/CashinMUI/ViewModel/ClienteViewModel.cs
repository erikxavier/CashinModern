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
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;

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

            //inicia  ItensBusca

            
            //NovoCliente();
        }

        #region Variáveis

        private CashinDB DB;

        private string _criterio;
        public string Criterio
        {
            get { return _criterio; }
            set
            {
                if (_criterio != value)
                {
                    _criterio = value;
                    RaisePropertyChanged("Criterio");
                    Busca = string.Empty;                    
                }
            }
        }

        private string _busca;
        public string Busca
        {
            get { return _busca;  }
            set
            {
                if (_busca != value)
                {
                    _busca = value;
                    RaisePropertyChanged("Busca");
                    AtualizaClientes();
                }
            }
        }

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

        private Cliente _clienteSelecionado;
        public Cliente ClienteSelecionado
        {
            get { return _clienteSelecionado; }
            set
            {
                if (_clienteSelecionado != value)
                {
                    _clienteSelecionado = value;
                    RaisePropertyChanged("ClienteSelecionado");
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

        private ICommand _excluirCommand;
        public ICommand ExcluirCommand
        {
            get
            {
                return _excluirCommand ?? (_excluirCommand = new RelayCommand(Excluir, CanExcluir));
            }
        }

        private ICommand _alterarCommand;
        public ICommand AlterarCommand
        {
            get
            {
                return _alterarCommand ?? (_alterarCommand = new RelayCommand(Alterar, CanAlterar));
            }
        }

        #endregion

        #region Lógicas de Negócio

        private bool CanAlterar()
        {
            return (ClienteSelecionado != null && !IsEditing);
        }

        private void Alterar()
        {
            Cliente = ClienteSelecionado;
        }

        private bool CanExcluir()
        {
            return ClienteSelecionado != null;
        }

        private void Excluir()
        {
            if (ModernDialog.ShowMessage(
                "Deseja realmente remover o Cliente selecionado ?", 
                "Aviso!", 
                MessageBoxButton.YesNo)
            == MessageBoxResult.Yes)
            {
                if (ClienteSelecionado.Orcamento.Any())
                {
                    ModernDialog.ShowMessage("Não foi possível remover o Cliente selecionado, pois ele \npossui Orçamentos vinculados.\nExclua os orçamentos deste cliente e tente novamente.", "Erro", MessageBoxButton.OK);
                    return;
                }
                else
                {
                    try
                    {
                        DB.Cliente.DeleteOnSubmit(ClienteSelecionado);
                        DB.SubmitChanges();
                        AtualizaClientes();
                    }
                    catch (Exception)
                    {
                        ModernDialog.ShowMessage("Algum erro ocorreu ao tentar excluir o Cliente", "Erro", MessageBoxButton.OK);
                    }
                }
            }
        }

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
            //var busca = new ObservableCollection<Cliente>(DB.Cliente.Where(c => c.Idusuario == Usuario.ID));
            var clientes = from c in DB.Cliente where c.Idusuario == Usuario.ID select c;
            if (!string.IsNullOrEmpty(Busca))
            {
                switch (Criterio)
                {
                    case "nome":
                        //busca = new ObservableCollection<Model.Cliente>(busca.Where(c => c.Nome.ToLower().Contains(Busca.ToLower())));
                        clientes = from c in clientes where  c.Nome.ToLower().Contains(Busca) select c;
                        break;
                    case "email":
                        clientes = from c in clientes where c.Email.ToLower().Contains(Busca) select c;
                        break;
                    case "documento":
                        clientes = from c in clientes where c.Documento.ToLower().Contains(Busca) select c;
                        break;
                    case "cidade":
                        clientes = from c in clientes where c.Cidade.ToLower().Contains(Busca) select c;
                        break;
                    default:                        
                        break;
                }
            }
            Clientes = new ObservableCollection<Cliente>(clientes);
            

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
