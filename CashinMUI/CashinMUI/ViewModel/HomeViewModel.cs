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
    class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            UsuarioLogado = (Usuario)App.Current.Properties["UsuarioLogado"];  
            DB = new CashinDB();
            AtualizaProjetos();
            AtualizaOrcamentos();

        }

        #region Variáveis

        private Usuario UsuarioLogado;

        private CashinDB DB;

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
                }
            }
        }

        private bool _editouTarefa = false;
        public bool EditouTarefa
        {
            get { return _editouTarefa; }
            set
            {
                if (_editouTarefa != value)
                {
                    _editouTarefa = value;
                    RaisePropertyChanged("EditouTarefa");
                }
            }
        }

        private bool _enableConclusao;
        public bool EnableConclusao
        {
            get { return _enableConclusao; }
            set
            {
                if (_enableConclusao != value)
                {
                    _enableConclusao = value;
                    RaisePropertyChanged("EnableConclusao");
                }
            }
        }

        private ObservableCollection<Projeto> _projetos;
        public ObservableCollection<Projeto> Projetos
        {
            get { return _projetos; }
            set
            {
                if (_projetos != value)
                {
                    _projetos = value;
                    RaisePropertyChanged("Projetos");
                }
            }
        }

        private Projeto _projetoSelecionado;
        public Projeto ProjetoSelecionado
        {
            get { return _projetoSelecionado; }
            set
            {
                if (_projetoSelecionado != value)
                {
                    _projetoSelecionado = value;
                    RaisePropertyChanged("ProjetoSelecionado");
                    if (_projetoSelecionado != null)
                        Tarefas = new ItemObservableCollection<Tarefa>(ProjetoSelecionado.Tarefa);
                }
            }
        }

        private ItemObservableCollection<Tarefa> _tarefas;
        public ItemObservableCollection<Tarefa> Tarefas
        {
            get { return _tarefas; }
            set
            {
                if (_tarefas != null)
                {
                    _tarefas.CollectionChanged -= TarefasCollectionChanged;
                }
                _tarefas = value;

                if (_tarefas != null) {
                    _tarefas.CollectionChanged += TarefasCollectionChanged;
                }                    
                RaisePropertyChanged("Tarefas");                
            }
        }

        private Tarefa _tarefaSelecionada;
        public Tarefa TarefaSelecionada
        {
            get { return _tarefaSelecionada; }
            set
            {                                
                if (_tarefaSelecionada != null)
                    _tarefaSelecionada.PropertyChanged -= _tarefaSelecionada_PropertyChanged;
                if (_tarefaSelecionada != value)
                    RaisePropertyChanged("TarefaSelecionada");
                _tarefaSelecionada = value;
                if (_tarefaSelecionada != null)
                    _tarefaSelecionada.PropertyChanged -= _tarefaSelecionada_PropertyChanged;
                
            }
        }

        private void _tarefaSelecionada_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            EditouTarefa = true;
            if (TarefaSelecionada.Finalizada)
            {
                EnableConclusao = true;
            }
            else
            {
                EnableConclusao = false;
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

        private ICommand _aprovarOrcamentoCommand;
        public ICommand AprovarOrcamentoCommand
        {
            get
            {
                return _aprovarOrcamentoCommand ?? (_aprovarOrcamentoCommand = new RelayCommand(AprovarOrcamento, CanAprovarOrcamento));
            }
        }
        private ICommand _salvarTarefasCommand;
        public ICommand SalvarTarefasCommand
        {
            get
            {
                return _salvarTarefasCommand ?? (_salvarTarefasCommand = new RelayCommand(SalvarTarefas, CanSalvarTarefas));
            }
        }

        #endregion

        #region Lógicas de negócio

        private bool CanSalvarTarefas()
        {
            return EditouTarefa;
        }

        private void SalvarTarefas()
        {
            ProjetoSelecionado.Tarefa.AddRange(Tarefas);
            DB.SubmitChanges();
        }

        private void AtualizaProjetos()
        {
            var projetos = DB.Projeto.Where(
                p => p.Orcamento.Idusuario == UsuarioLogado.ID
                    && !p.Finalizado
            );
            if (projetos.Any())
                Projetos = new ObservableCollection<Projeto>(projetos);
            else
                Projetos = null;
        }

        private void AtualizaOrcamentos()
        {
            var orcamentos = DB.Orcamento.Where(o => o.Idusuario == UsuarioLogado.ID && !o.Aprovado);
            Orcamentos = new ObservableCollection<Orcamento>(orcamentos);
        }

        private void TarefasCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {            
            EditouTarefa = true;
            MessageBox.Show("Eii");
            //var tarefa = DB.Tarefa.Single(t => t.ID == TarefaSelecionada.ID);
            //tarefa.Finalizada = TarefaSelecionada.Finalizada;
            //DB.SubmitChanges();
        }

        private bool CanAprovarOrcamento()
        {
            return OrcamentoSelecionado != null;
        }

        private void AprovarOrcamento()
        {
            if (OrcamentoSelecionado.Aprovado)
            {
                ModernDialog.ShowMessage("Este orçamento já foi aprovado, e já existe um projeto vinculado", "Orçamento", MessageBoxButton.OK);
            }
            else
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

        #endregion
    }
}
