using CashinMUI.Model;
using CashinMUI.Util;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
            Usuario = (Usuario)App.Current.Properties["UsuarioLogado"];  
            DB = new CashinDB();            

        }

        #region Variáveis

        private CashinDB DB;

        private Usuario Usuario;

        private Orcamento _orcamento;
        public Orcamento Orcamento
        {
            get { return _orcamento; }
            set
            {
                if (_orcamento != value)
                {
                    _orcamento = value;
                    RaisePropertyChanged("Orcamento");
                }
            }
        }

        private ItemObservableCollection<Itemorcamento> _itensOrcamento;
        public ItemObservableCollection<Itemorcamento> ItensOrcamento
        {
            get { return _itensOrcamento; }
            set
            {
                // Detach the event handler from current instance, if any:
                if (_itensOrcamento != null)
                {
                    _itensOrcamento.CollectionChanged -= _itensOrcamento_CollectionChanged;                    
                }

                _itensOrcamento = value;

                // Attatach the event handler to the new instance, if any:
                if (_itensOrcamento != null)
                {
                    _itensOrcamento.CollectionChanged += _itensOrcamento_CollectionChanged;
                }

                // Notify that the 'Answers' property has changed:
                RaisePropertyChanged("ItensOrcamento");
            }
        }
        

        private decimal _total;
        public decimal Total
        {
            get { return _total; }
            set
            {
                if (_total != value)
                {
                    _total = value;
                    RaisePropertyChanged("Total");
                }
            }
        }

        private int _indexSelecionado;
        public int IndexSelecionado
        {
            get { return _indexSelecionado; }
            set
            {
                if (_indexSelecionado != value)
                {
                    _indexSelecionado = value;
                    RaisePropertyChanged("IndexSelecionado");
                }
            }
        }

        private Itemorcamento _itemSelecionado;
        public Itemorcamento ItemSelecionado
        {
            get { return _itemSelecionado; }
            set
            {
                if (_itemSelecionado != value)
                {
                    _itemSelecionado = value;
                    RaisePropertyChanged("ItemSelecionado");
                }
            }
        }

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
                    if (_cliente != null)
                        ClienteString =  Cliente.Nome + " | " + Cliente.Email;
                    else
                        ClienteString = "[url=/View/ClienteView.xaml]Clique aqui para selecionar um cliente.[/url]";
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

        private string _clienteString = "[url=/View/ClienteView.xaml]Clique aqui para selecionar um cliente.[/url]";
        public string ClienteString
        {
            get
            {
                return _clienteString;
            }

            set
            {
                if (_clienteString != value)
                {
                    _clienteString = value;
                    RaisePropertyChanged("ClienteString");
                }
            }
        }

        #endregion

        #region Commands

        private ICommand _adicionaItemCommand;
        public ICommand AdicionaItemCommand
        {
            get
            {
                return _adicionaItemCommand ?? (_adicionaItemCommand = new RelayCommand(AdicionaItem, CanAdicionaItem));
            }
        }

        private ICommand _novoOrcamentoCommand;
        public ICommand NovoOrcamentoCommand
        {
            get
            {
                return _novoOrcamentoCommand ?? (_novoOrcamentoCommand = new RelayCommand(NovoOrcamento, CanNovoOrcamento));
            }
        }

        private ICommand _salvarCommand;
        public ICommand SalvarCommand
        {
            get
            {
                return _salvarCommand ?? (_salvarCommand = new RelayCommand(Salvar,CanSalvar));
            }
        }

        private ICommand _removerItemCommand;
        public ICommand RemoverItemCommand
        {
            get
            {
                return _removerItemCommand ?? (_removerItemCommand = new RelayCommand(RemoverItem, CanRemoverItem));
            }
        }

        private ICommand _cancelarCommand;
        public ICommand CancelarCommand
        {
            get
            {
                return _cancelarCommand ?? (_cancelarCommand = new RelayCommand(Cancelar, CanCancelar));
            }
        }

        #endregion

        #region Lógicas de Negócio

        private bool CanCancelar()
        {
            return IsEditing;
        }

        private void Cancelar() {
            Orcamento = null;
            ItensOrcamento = null;
            IsEditing = false;
        }

        private bool CanSalvar()
        {
            return IsEditing;
        }

        private void Salvar()
        {
            Orcamento.Itemorcamento.Clear();
            Orcamento.Itemorcamento.AddRange(ItensOrcamento);
            try
            {
                DB.Orcamento.InsertOnSubmit(Orcamento);
                DB.SubmitChanges();
                ModernDialog.ShowMessage("Orçamento criado", "Sucesso!", MessageBoxButton.OK);
                IsEditing = false;
                Orcamento = null;
                ItensOrcamento = null;
            }
            catch (Exception)
            {
                                
            }
        }

        private bool CanRemoverItem()
        {
            return ItemSelecionado != null;
        }

        private void RemoverItem()
        {
            ItensOrcamento.Remove(ItemSelecionado);
            
        }

        private bool CanNovoOrcamento() {
            return (Cliente != null && !IsEditing);
        }

        private void NovoOrcamento()
        {
            Orcamento = new Orcamento();
            Orcamento.Cliente = Cliente;
            Orcamento.Usuario = Usuario;
            Orcamento.Data = DateTime.Now;
            Orcamento.Validade = DateTime.Now.AddMonths(1);
            ItensOrcamento = new ItemObservableCollection<Itemorcamento>();
            IsEditing = true;
        }

        private bool CanAdicionaItem()
        {            
            return (Orcamento != null && IsEditing);
        }

        private void AdicionaItem()
        {
            ItensOrcamento.Add(new Itemorcamento());            
        }

        private void SelectCliente(int id)
        {
            Cliente = DB.Cliente.Where(c => c.ID == id).Single();
        }

        private void SomaTotal()
        {            
            Total = ItensOrcamento.Sum(i => i.Valor.GetValueOrDefault());
        }

        private void _itensOrcamento_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {            
            SomaTotal();
            RaisePropertyChanged("ItensOrcamento");
        }

        public void OnFragmnetNavigation(FragmentNavigationEventArgs e)
        {
            SelectCliente(int.Parse(e.Fragment));
            NovoOrcamento();
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (IsEditing)
                if (ModernDialog.ShowMessage("Deseja cancelar a edição do item atual ?", "Alerta!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Cancelar();
                }
                else
                {
                    e.Cancel = true;
                }
        }

        #endregion
    }
}
