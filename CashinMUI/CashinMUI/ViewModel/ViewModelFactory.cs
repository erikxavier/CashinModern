using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashinMUI.ViewModel
{
    class ViewModelFactory
    {

        private static LoginViewModel _loginViewModel;
        public LoginViewModel LoginViewModel
        {
            get
            {                
                _loginViewModel = new LoginViewModel();
                return _loginViewModel;
            }
        }

        private static MainViewModel _mainViewModel;
        public MainViewModel MainViewModel
        {
            get
            {
                _mainViewModel = new MainViewModel();
                return _mainViewModel;
            }
        }

        private static ClienteViewModel _clienteViewModel;
        public ClienteViewModel ClienteViewModel
        {
            get
            {
                _clienteViewModel = new ClienteViewModel();
                return _clienteViewModel;
            }
        }

        private static UsuarioViewModel _usuarioViewModel;
        public UsuarioViewModel UsuarioViewModel
        {
            get
            {
                _usuarioViewModel = new UsuarioViewModel();
                return _usuarioViewModel;
            }
        }

        private static OrcamentoViewModel _orcamentoViewModel;
        public OrcamentoViewModel OrcamentoViewModel
        {
            get
            {
                _orcamentoViewModel = new OrcamentoViewModel();
                return _orcamentoViewModel;
            }
        }

        private static ProjetoViewModel _projetoViewModel;
        public ProjetoViewModel ProjetoViewModel
        {
            get
            {
                _projetoViewModel = new ProjetoViewModel();
                return _projetoViewModel;
            }
        }

        private static HomeViewModel _homeViewModel;
        public HomeViewModel HomeViewModel
        {
            get
            {
                _homeViewModel = new HomeViewModel();
                return _homeViewModel;
            }
        }
    }
}
