using CashinMUI.Model;
using CashinMUI.Util;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
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
            Usuario = (Usuario)App.Current.Properties["UsuarioLogado"];  
            DB = new CashinDB();
            AtualizaProjetos();
        }

        #region Variáveis

        private CashinDB DB;

        private Usuario Usuario;

        private bool _isNovo = true;
        public bool IsNovo
        {
            get { return _isNovo; }
            set
            {
                if (_isNovo != value)
                {
                    _isNovo = value;
                    RaisePropertyChanged("IsNovo");
                }
            }
        }

        private bool _readOnly = true;
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                if (_readOnly != value)
                {
                    _readOnly = value;
                    RaisePropertyChanged("ReadOnly");
                }
            }
        }

        private bool _isEditing = false;
        public bool IsEditing
        {
            get { return _isEditing;}
            set {
                if (_isEditing != value)
                {
                    _isEditing = value;
                    ReadOnly = !_isEditing;
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
                    if (_projetoSelecionado != null && !IsEditing)
                        SelecionaProjeto();
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
                    AtualizaProjetos();
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

        public bool CanCancelar()
        {
            return IsEditing && Projeto != null;            
        }

        public void Cancelar()
        {
            if (!IsNovo)
            {                
                Tarefas = new ObservableCollection<Tarefa>(Projeto.Tarefa);
            }
            else
            {
                Projeto = null;
                Tarefas = null;
            }
            IsEditing = false;
            IsNovo = true;
        }

        private bool CanNovo()
        {
            return Orcamento != null;
        }

        private void Novo()
        {
            Projeto = new Projeto();
            Tarefas = new ObservableCollection<Tarefa>();            
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
            string acao;
            if (IsNovo)
            {
                Projeto.Tarefa.Clear();
                Projeto.Tarefa.AddRange(Tarefas);
                Projeto.Orcamento = Orcamento;
                Orcamento.Aprovado = true;
                DB.Projeto.InsertOnSubmit(Projeto);
                acao = "adicionado";
            }
            else
            {
                try
                {
                    //Adiciona items novos do Tarefas para Projeto.Tarefa
                    var novosItens = Tarefas.Except(Projeto.Tarefa, new CompareTarefa());
                    Projeto.Tarefa.AddRange(novosItens);

                    //Remove os itens que estão no Projeto.Tarefa mas não estão no Tarefas (foram removidos)
                    var itensRemovidos = Projeto.Tarefa.Except(Tarefas, new CompareTarefa()).ToList();
                    if (itensRemovidos.Any())
                    {
                        foreach (var item in itensRemovidos)
                        {
                            Projeto.Tarefa.Remove(item);
                            DB.Tarefa.DeleteOnSubmit(item);
                        }
                    }
                    acao = "alterado";
                }
                catch (Exception ex)
                {
                    ModernDialog.ShowMessage("Erro ao alterar projeto:" + ex.Message, "Ops!", MessageBoxButton.OK);
                    Cancelar();
                    return;
                }
            }
            try
            {
                DB.SubmitChanges();
                ModernDialog.ShowMessage("O Projeto Nº " + Projeto.ID.ToString("0:000") + " foi " + acao + " com sucesso!", "Projeto", MessageBoxButton.OK);
                IsEditing = false;
                AtualizaProjetos();
                //ActionString = "Orçamento";
            }
            catch (Exception)
            {
                ModernDialog.ShowMessage("Não foi possível salvar as alterações no banco.", "Ops!", MessageBoxButton.OK);
            }
            //try
            //{
            //    Projeto.Tarefa.AddRange(Tarefas);
            //    DB.Projeto.InsertOnSubmit(Projeto);                    
            //    DB.SubmitChanges();
            //    Orcamento.Aprovado = true;
            //    DB.SubmitChanges();
            //    ModernDialog.ShowMessage("Projeto Criado", "Sucesso!", MessageBoxButton.OK);
            //    IsEditing = false;
            //}
            //catch (Exception ex)
            //{
            //    ModernDialog.ShowMessage("Não foi possível salvar as alterações no banco:\n"+ex.Message, "Ops!", MessageBoxButton.OK);
            //}
        }

        private bool CanRemoverTarefa()
        {
            return TarefaSelecionada != null && IsEditing;
        }

        private void RemoverTarefa()
        {
            Tarefas.Remove(TarefaSelecionada);            
        }

        private bool CanAdicionaTarefa()
        {
            return (Projeto != null && IsEditing);
        }

        private void AdicionaTarefa()
        {
            Tarefas.Add(new Tarefa());            
        }

        private bool CanAlterar()
        {
            return (!IsEditing && Projeto != null);
        }

        private void Alterar()
        {
            if (Projeto.Finalizado)
            {
                ModernDialog.ShowMessage("Você não pode alterar um projeto finalizado.", "Ops!", MessageBoxButton.OK);
                return;
            }
            IsEditing = true;
            IsNovo = false;
            //ActionString = "Alterar Orçamento";
        }

        private void AtualizaProjetos()
        {
            var projetos = from p in DB.Projeto where p.Orcamento.Idusuario == Usuario.ID select p;
            if (!string.IsNullOrEmpty(Busca))
            {
                switch (Criterio)
                {
                    case "cliente":
                        projetos = from c in projetos where c.Orcamento.Cliente.Nome.ToLower().Contains(Busca.ToLower()) select c;
                        break;
                    case "titulo":
                        projetos = from c in projetos where c.Titulo.ToLower().Contains(Busca.ToLower()) select c;
                        break;
                    default:
                        break;
                }
            }
            if (projetos.Any())
                Projetos = new ObservableCollection<Projeto>(projetos);
        }

        private void SelecionaProjeto()
        {
            Projeto = ProjetoSelecionado;
            Orcamento = ProjetoSelecionado.Orcamento;
            Tarefas = new ObservableCollection<Tarefa>(ProjetoSelecionado.Tarefa);
        }

        internal void OnFragmnetNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            Orcamento = DB.Orcamento.Where(o => o.ID == int.Parse(e.Fragment)).SingleOrDefault();
            if (Orcamento != null)
                Novo();
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (IsEditing)
                if (ModernDialog.ShowMessage("Deseja cancelar a edição do projeto atual ?", "Alerta!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
