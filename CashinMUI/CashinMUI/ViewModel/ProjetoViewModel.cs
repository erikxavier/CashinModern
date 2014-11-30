using CashinMUI.Model;
using CashinMUI.Util;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashinMUI.ViewModel
{
    class ProjetoViewModel : ViewModelBase
    {

        public ProjetoViewModel()
        {

        }

        #region Variáveis

        private CashinDB DB;

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

        #endregion

        #region Lógicas de Negócio

        internal void OnFragmnetNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
