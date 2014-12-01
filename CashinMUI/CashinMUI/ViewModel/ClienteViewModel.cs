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
using CashinMUI.Util;
using System.Windows.Navigation;

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

        public string DocTipo
        {
            get {
                if (Cliente != null) return Cliente.Tipodocumento;
                else return null;
                }
            set
            {
                if (Cliente != null)
                    if (Cliente.Tipodocumento != value)
                    {
                        Cliente.Tipodocumento = value;
                        RaisePropertyChanged("DocTipo");
                        if (Cliente.Tipodocumento == TipoDeDocumento.CPF.ToString())
                        {
                            DocLenght = "14";
                        }
                        else
                        {
                            DocLenght = "18";
                        }
                        Cliente.Documento = null;
                    }
            }
        }


        private string _docLenght;
        public string DocLenght
        {
            get { return _docLenght; }
            set
            {
                if (_docLenght != value)
                {
                    _docLenght = value;
                    RaisePropertyChanged("DocLenght");
                }
            }
        }

        private string _docMask;
        public string DocMask
        {
            get { return _docMask; }
            set
            {
                if (_docMask != value)
                {
                    _docMask = value;
                    RaisePropertyChanged("DocMask");
                }
            }
        }

        private string _actionString = "Cliente";
        public string ActionString
        {
            get { return _actionString; }
            set
            {
                if (_actionString != value)
                {
                    _actionString = value;
                    RaisePropertyChanged("ActionString");
                }
            }
        }

        private bool _criterioExiste = false;
        public bool CriterioExiste
        {
            get { return _criterioExiste; }
            set
            {
                if (_criterioExiste != value)
                {
                    _criterioExiste = value;
                    RaisePropertyChanged("CriterioExiste");
                }
            }
        }

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
                    if (!string.IsNullOrEmpty(_criterio))
                        CriterioExiste = true;
                    else
                        CriterioExiste = false;
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
                        ProcuraCep();
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

        private ICommand _novoOrcamento;
        public ICommand NovoOrcamentoCommand
        {
            get
            {
                return _novoOrcamento ?? (_novoOrcamento = new RelayCommand(NovoOrcamento, CanNovoOrcamento));
            }
        }

        #endregion

        #region Lógicas de Negócio

        private bool CanNovoOrcamento()
        {
            return (ClienteSelecionado != null && !IsEditing);
        }

        private void NovoOrcamento()
        {
            ((MainWindow)App.Current.MainWindow).ContentSource = new Uri("/View/OrcamentoView.xaml#"+ClienteSelecionado.ID, UriKind.Relative);
        }

        private bool CanAlterar()
        {
            return (ClienteSelecionado != null && !IsEditing);
        }

        private void Alterar()
        {
            Cliente = ClienteSelecionado;
            ActionString = "Alterar Cliente";
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
                Cancelar();
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
            DocTipo = null;
            Cliente = null;
            ActionString = "Cliente";
        }

        private bool CanNovo()
        {
            return Cliente == null;
        }

        private void Novo()
        {
            Cliente = new Cliente();
            Cliente.Usuario = Usuario;
            DocTipo = TipoDeDocumento.CPF.ToString();
            ActionString = "Novo Cliente";
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
                        clientes = from c in clientes where c.Nome.ToLower().Contains(Busca.ToLower()) select c;
                        break;
                    case "email":
                        clientes = from c in clientes where c.Email.ToLower().Contains(Busca.ToLower()) select c;
                        break;
                    case "documento":
                        clientes = from c in clientes where c.Documento.ToLower().Contains(Busca.ToLower()) select c;
                        break;
                    case "cidade":
                        clientes = from c in clientes where c.Cidade.ToLower().Contains(Busca.ToLower()) select c;
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
