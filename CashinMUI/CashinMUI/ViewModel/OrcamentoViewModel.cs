using CashinMUI.Model;
using CashinMUI.Report;
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
            AtualizaOrcamentos();
        }

        #region Variáveis

        private CashinDB DB;

        private bool _isNovo = true;
        public bool IsNovo
        {
            get { return _isNovo;}
            set
            {
                if (_isNovo != value)
                {
                    _isNovo = value;
                    RaisePropertyChanged("IsNovo");
                }
            }
        }

        private ObservableCollection<Cliente> _clientes;
        public ObservableCollection<Cliente> Clientes
        {
            get { return _clientes; }
            set
            {
                if (_clientes != value)
                {
                    _clientes = value;
                    RaisePropertyChanged("Clientes");
                }
            }
        }

        private Orcamento _orcamentoSelecionado;
        public Orcamento OrcamentoSelecionado
        {
            get { return _orcamentoSelecionado; }
            set
            {
                if (_orcamentoSelecionado != value)
                {
                    _orcamentoSelecionado = value;
                    RaisePropertyChanged("OrcamentoSelecionado");
                    if (_orcamentoSelecionado != null && !IsEditing)
                        SelecionaOrcamento();
                }
            }
        }

        private string _actionString = "Orçamento";
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
            get { return _busca; }
            set
            {
                if (_busca != value)
                {
                    _busca = value;
                    RaisePropertyChanged("Busca");
                    AtualizaOrcamentos();
                }
            }
        }

        private ObservableCollection<Orcamento> _orcamentos;
        public ObservableCollection<Orcamento> Orcamentos
        {
            get
            {
                return _orcamentos;
            }
            set
            {
                if (_orcamentos != value)
                {
                    _orcamentos = value;
                    RaisePropertyChanged("Orcamentos");
                }
            }
        }

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
                    SomaTotal();
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
                        ClienteString =  Cliente.Nome;
                    else
                        ClienteString = "Nenhum Cliente selecionado.";
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

        private string _clienteString = "Nenhum Cliente selecionado.";
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

        private ICommand _exibirRelatorioCommand;
        public ICommand ExibirRelatorioCommand
        {
            get
            {
                return _exibirRelatorioCommand ?? (_exibirRelatorioCommand = new RelayCommand(ExibirRelatorio, CanExibirRelatorio));
            }
        }

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


        private ICommand _aprovarOrcamentoCommand;
        public ICommand AprovarOrcamentoCommand
        {
            get
            {
                return _aprovarOrcamentoCommand ?? (_aprovarOrcamentoCommand = new RelayCommand(AprovarOrcamento, CanAprovarOrcamento));
            }
        }

        private ICommand _alterarOrcamentoCommand;
        public ICommand AlterarOrcamentoCommand
        {
            get
            {
                return _alterarOrcamentoCommand ?? (_alterarOrcamentoCommand = new RelayCommand(Alterar, CanAlterar));
            }
        }

        private ICommand _excluirOrcamentoCommand;
        public ICommand ExcluirOrcamentoCommand
        {
            get
            {
                return _excluirOrcamentoCommand ?? (_excluirOrcamentoCommand = new RelayCommand(Excluir, CanExcluir));
            }
        }
        #endregion

        #region Lógicas de Negócio

        private bool CanAlterar()
        {
            return (!IsEditing && Orcamento != null);
        }

        private void Alterar()
        {
            IsEditing = true;
            IsNovo = false;
            ActionString = "Alterar Orçamento";
        }

        private bool CanAprovarOrcamento()
        {
            return OrcamentoSelecionado != null;
        }

        private void AprovarOrcamento() {
            ((MainWindow)App.Current.MainWindow).ContentSource = new Uri("/View/ProjetoView.xaml#" + OrcamentoSelecionado.ID, UriKind.Relative);
        }

        private bool CanExibirRelatorio()
        {
            return OrcamentoSelecionado != null;
        }

        private void ExibirRelatorio()
        {
            OrcamentoReportView report = new OrcamentoReportView(OrcamentoSelecionado);
            report.Show();
        }

        private bool CanExcluir()
        {
            return (OrcamentoSelecionado != null && !IsEditing);
        }

        private void Excluir()
        {
            if (OrcamentoSelecionado.Aprovado)
            {
                ModernDialog.ShowMessage("Orçamento aprovados não podem ser excluidos!", "Ops!", MessageBoxButton.OK);
                return;
            }
            if (ModernDialog.ShowMessage("Deseja realmente excluir o orçamento Nº "+OrcamentoSelecionado.ID.ToString("000")+" ?", "Orçamento", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;
            DB.Orcamento.DeleteOnSubmit(OrcamentoSelecionado);
            try
            {
                DB.SubmitChanges();
                ModernDialog.ShowMessage("Orçamento excluído com sucesso!", "Orçamento", MessageBoxButton.OK);
                AtualizaOrcamentos();
            }
            catch (Exception ex)
            {
                ModernDialog.ShowMessage("Erro ao excluir orçamento: "+ex.Message, "Ops!", MessageBoxButton.OK);                 
            }
        }

        private bool CanCancelar()
        {
            return IsEditing;
        }

        private void Cancelar() {
            Orcamento = null;
            ItensOrcamento = null;
            IsEditing = false;
            Cliente = null;
            ActionString = "Orçamento";
        }

        private bool CanSalvar()
        {
            return (IsEditing 
                && Cliente != null
                && !string.IsNullOrEmpty(Orcamento.Titulo));
        }

        private void Salvar()
        {
            string acao;
            if (IsNovo)
            {
                Orcamento.Itemorcamento.Clear();
                Orcamento.Itemorcamento.AddRange(ItensOrcamento);
                Orcamento.Cliente = Cliente;
                DB.Orcamento.InsertOnSubmit(Orcamento);
                acao = "adicionado";
            }
            else
            {
                try
                {
                    //Adiciona items novos do ItensOrcamento para Orcamento.Itemorcamento
                    var novosItens = ItensOrcamento.Except(Orcamento.Itemorcamento, new CompareItem());
                    Orcamento.Itemorcamento.AddRange(novosItens);                    

                    //Remove os itens que estão no Orcamento.Itemorcamento mas não estão no ItensOrcamento (foram removidos)
                    var itensRemovidos = Orcamento.Itemorcamento.Except(ItensOrcamento, new CompareItem()).ToList();
                    if (itensRemovidos.Any())
                    {
                        foreach (var item in itensRemovidos)
                        {
                            Orcamento.Itemorcamento.Remove(item);
                            DB.Itemorcamento.DeleteOnSubmit(item);
                        }
                    }
                    acao = "alterado";
                }
                catch (Exception ex)
                {
                    ModernDialog.ShowMessage("Erro ao alterar orçamento:" + ex.Message, "Ops!", MessageBoxButton.OK);
                    Cancelar();
                    return;
                }
            }
            try
            {                
                DB.SubmitChanges();
                ModernDialog.ShowMessage("O Orçamento Nº "+Orcamento.ID.ToString("000")+" foi "+acao+" com sucesso!", "Orçamento", MessageBoxButton.OK);
                IsEditing = false;                
                AtualizaOrcamentos();
                ActionString = "Orçamento";
            }
            catch (Exception)
            {
                ModernDialog.ShowMessage("Não foi possível salvar as alterações no banco.", "Ops!", MessageBoxButton.OK);                         
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
            return (!IsEditing);
        }

        private void NovoOrcamento()
        {
            Orcamento = new Orcamento();            
            Orcamento.Usuario = Usuario;
            Orcamento.Data = DateTime.Now;
            Orcamento.Validade = DateTime.Now.AddMonths(1);
            ItensOrcamento = new ItemObservableCollection<Itemorcamento>();
            IsEditing = true;
            IsNovo = true;
            ActionString = "Novo Orçamento";
            Cliente = null;
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

        private void AtualizaOrcamentos()
        {            
            var orcamentos = from o in DB.Orcamento where o.Idusuario == Usuario.ID select o;
            if (!string.IsNullOrEmpty(Busca))
            {
                switch (Criterio)
                {
                    case "cliente":                        
                        orcamentos = from c in orcamentos where c.Cliente.Nome.ToLower().Contains(Busca.ToLower()) select c;                        
                        break;
                    case "descricao":
                        orcamentos = from c in orcamentos where c.Descricao.ToLower().Contains(Busca.ToLower()) select c;
                        break;
                    default:
                        break;
                }
            }
            Orcamentos = new ObservableCollection<Orcamento>(orcamentos);
        }

        private void SelecionaOrcamento()
        {
            Orcamento = OrcamentoSelecionado;
            Cliente = OrcamentoSelecionado.Cliente;
            ItensOrcamento = new ItemObservableCollection<Itemorcamento>(OrcamentoSelecionado.Itemorcamento);
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
                if (ModernDialog.ShowMessage("Deseja cancelar a edição do item atual?", "Alerta!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Cancelar();
                }
                else
                {
                    e.Cancel = true;
                }
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Clientes = new ObservableCollection<Cliente>(DB.Cliente.ToList());
        }
        #endregion

    }
}
