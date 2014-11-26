using CashinMUI.Model;
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
                string senha;
                if (string.IsNullOrEmpty(value)) senha = "";
                else senha = GerarHashMd5(value);
                if (senha != _senha)
                {
                    _senha = senha;
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

        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

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
            using (var DB = new CashinDB())
            {
                var usuario = DB.Usuario.Where(u => u.Nomeusuario == Username && u.Senha == Senha);
                if (usuario.Any())
                {
                    Mensagem = "Logado como " + usuario.Single().Nome + "!";
                }
                else
                {
                    Mensagem = "Usuário e/ou Senha Incorretos";
                }
            }
        }

        #endregion
    }
}
