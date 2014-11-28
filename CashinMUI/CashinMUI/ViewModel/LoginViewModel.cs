using CashinMUI.Model;
using CashinMUI.Util;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CashinMUI.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        #region Variáveis

        private Usuario _usuario;
        public Usuario Usuario
        {
            get { return _usuario; }
            set {
                if (value != _usuario) {
                    _usuario = value;
                    RaisePropertyChanged("Usuario");
                }
            }
        }

        private string _mensagem;
        public string Mensagem
        {
            get { return _mensagem; }
            private set
            {
                _mensagem = value;
                RaisePropertyChanged("Mensagem");
            }
        }

        private string _username;
        public string Username
        {
            private get { return _username; }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    RaisePropertyChanged("Username");
                }
            }
        }

        private string _senha;
        public string Senha
        {
            private get { return _senha; }
            set
            {
                if (value != _senha)
                {
                    _senha = value;
                    RaisePropertyChanged("Senha");
                }

             }
        }

        #endregion


        #region Commands

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(Login,CanLogin));
            }
        }

        

        #endregion


        #region Lógica de negócios

        public bool CanLogin()
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Senha))
            {                
                return true;
            }
            else return false;
        }
        public void Login()
        {
            try
            {
                using (var DB = new CashinDB())
                {
                    var usuario = DB.Usuario.Where(u => u.Nomeusuario == Username && u.Senha == Senha);
                    if (usuario.Any())
                    {
                        App.Current.Properties["UsuarioLogado"] = usuario.Single();
                        MainViewModel mvm = (MainViewModel)App.Current.MainWindow.DataContext;
                        mvm.UsuarioLogado = usuario.Single();
                        mvm.ContentSource = new Uri("/View/Home.xaml", UriKind.Relative);
                        //((MainWindow)App.Current.MainWindow).ContentSource = new Uri("/View/Home.xaml", UriKind.Relative);
                    }
                    else
                    {
                        Mensagem = "Usuário e/ou Senha Incorretos";
                    }
                }
            }
            catch
            {
                Mensagem = "Falha ao conectar no banco de dados!";
            }
        }

        #endregion
    }
}
