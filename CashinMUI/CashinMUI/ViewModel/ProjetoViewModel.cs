using CashinMUI.Model;
using CashinMUI.Util;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CashinMUI.ViewModel
{
    class ProjetoViewModel : ViewModelBase
    {

        public ProjetoViewModel()
        {
            DB = new CashinDB();
        }

        #region Variáveis

        private CashinDB DB;

        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing;}
            set {
                if (_isEditing != value)
                {
                    _isEditing = value;
                    RaisePropertyChanged("IsEditing");
                }
            }
        }

        private string _orcamentoString = "Nenhum orçamento selecionado para projeto";
        public string OrcamentoString
        {
            get { return _orcamentoString; }
            set
            {
                if (_orcamentoString != value)
                {
                    _orcamentoString = value;
                    RaisePropertyChanged("OrcamentoString");
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

        private Tarefa _tarefaSelecionada;
        public Tarefa TarefaSelecionada
        {
            get { return _tarefaSelecionada; }
            set
            {
                if (_tarefaSelecionada != value)
                {
                    _tarefaSelecionada = value;
                    RaisePropertyChanged("TarefaSelecionada");
                }
            }
        }

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
                    if (_orcamento != null)
                        OrcamentoString = "Nº:" + Orcamento.ID + " Cliente: " + Orcamento.Cliente.Nome;
                    else
                        OrcamentoString = "Nenhum orçamento selecionado para projeto";
                }
            }
        }

        private Projeto _projeto;
        public Projeto Projeto
        {
            get { return _projeto; }
            set
            {
                if (_projeto != value)
                {
                    _projeto = value;
                    RaisePropertyChanged("Projeto");
                }
            }
        }

        private ObservableCollection<Tarefa> _tarefas;
        public ObservableCollection<Tarefa> Tarefas
        {
            get { return _tarefas; }
            set
            {
                if (_tarefas != value)
                {
                    _tarefas = value;
                    RaisePropertyChanged("Tarefas");
                }
            }
        }

        #endregion

        #region Commands

        private ICommand _adicionaTarefaCommand;
        public ICommand AdicionaTarefaCommand
        {
            get
            {
                return _adicionaTarefaCommand ?? (_adicionaTarefaCommand = new RelayCommand(AdicionaTarefa, CanAdicionaTarefa));
            }
        }

        private ICommand _removerTarefaCommand;
        public ICommand RemoverTarefaCommand
        {
            get
            {
                return _removerTarefaCommand ?? (_removerTarefaCommand = new RelayCommand(RemoverTarefa, CanRemoverTarefa));
            }
        }

        private ICommand _novoCommand;
        public ICommand NovoCommand
        {
            get
            {
                return _novoCommand ?? (_novoCommand = new RelayCommand(Novo, CanNovo));
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

        public bool CanCancelar()
        {
            return Projeto != null;
        }

        public void Cancelar()
        {
            Projeto = null;
            IsEditing = false;
        }

        private bool CanNovo()
        {
            return Orcamento != null;
        }

        private void Novo()
        {
            Projeto = new Projeto();
            Tarefas = new ObservableCollection<Tarefa>();
            Projeto.Orcamento = Orcamento;
            Projeto.Inicio = DateTime.Now;
            Projeto.Titulo = Orcamento.Titulo;
            Projeto.Descricao = Orcamento.Descricao;
            IsEditing = true;
        }

        private bool CanSalvar()
        {
            return (Projeto != null && IsEditing);
        }

        private void Salvar()
        {
            try
            {
                Projeto.Tarefa.AddRange(Tarefas);
                DB.Projeto.InsertOnSubmit(Projeto);                    
                DB.SubmitChanges();
                Orcamento.Aprovado = true;
                DB.SubmitChanges();
                ModernDialog.ShowMessage("Projeto Criado", "Sucesso!", MessageBoxButton.OK);
                IsEditing = false;
            }
            catch (Exception ex)
            {
                ModernDialog.ShowMessage("Não foi possível salvar as alterações no banco:\n"+ex.Message, "Ops!", MessageBoxButton.OK);
            }
        }

        private bool CanRemoverTarefa()
        {
            return TarefaSelecionada != null;
        }

        private void RemoverTarefa()
        {
            Tarefas.RemoveAt(IndexSelecionado);            
        }

        private bool CanAdicionaTarefa()
        {
            return (Projeto != null);
        }

        private void AdicionaTarefa()
        {
            Tarefas.Add(new Tarefa());            
        }

        internal void OnFragmnetNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            Orcamento = DB.Orcamento.Where(o => o.ID == int.Parse(e.Fragment)).SingleOrDefault();
            if (Orcamento != null)
                Novo();
        }

        #endregion

    }
}
