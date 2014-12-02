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

namespace CashinMUI.ViewModel
{
    class UsuarioViewModel : ViewModelBase
    {

        public UsuarioViewModel()
        {
            DB = new CashinDB();
            UsuarioLogado = GetUsuarioLogado();            
            
        }

        #region Variáveis

        private CashinDB DB;


        private Usuario UsuarioLogado;
        

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

        private string _confirmaSenha;
        public string ConfirmaSenha
        {
            get { return _confirmaSenha; }
            set
            {
                if (_confirmaSenha != value)
                {
                    _confirmaSenha = value;
                    RaisePropertyChanged("ConfirmaSenha");

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

        private Usuario _usuario;
        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    RaisePropertyChanged("Usuario");
                    if (_usuario == null)
                    {
                        IsEditing = false;
                        //RaisePropertyChanged("CEP");
                    }
                    else IsEditing = true;
                    RaisePropertyChanged("CEP");
                }
            }
        }

        public string CEP
        {
            get
            {
                if (Usuario != null) return Usuario.Cep;
                else return null;
            }
            set
            {
                if (Usuario != null)
                {
                    if (Usuario.Cep != value)
                    {
                        Usuario.Cep = value;
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
                return _cancelarCommand ?? (_cancelarCommand = new RelayCommand(Cancelar, CanCancelar));
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

        private bool CanAlterar()
        {
            return (!IsEditing && GetUsuarioLogado() != null);
        }

        private void Alterar()
        {
            var usuario = DB.Usuario.Single(u => u.ID == GetUsuarioLogado().ID);
            Usuario = usuario;
            IsEditing = true;
            IsNovo = false;
        }       

        private bool CanSalvar()
        {
            if (Usuario != null)
            {
                if (string.IsNullOrEmpty(Usuario.Nome)
                || string.IsNullOrEmpty(Usuario.Nomeusuario)
                || string.IsNullOrEmpty(Usuario.Senha)
                || !IsEditing)
                    return false;
                else return true;
            }
            else return false;
        }

        private void Salvar()
        {
            string acao = "alterado";
            if (ConfirmaSenha != Usuario.Senha)
            {
                ModernDialog.ShowMessage("A senha é diferente da confirmação da senha.", "Ops!", MessageBoxButton.OK);
                return;
            }
            if (IsNovo)
            {
                if (DB.Usuario.Where(u => u.Nomeusuario == Usuario.Nomeusuario).Any())
                {
                    ModernDialog.ShowMessage("O nome de usuário " + Usuario.Nomeusuario + " já existe.", "Ops!", MessageBoxButton.OK);
                    return;
                }
                DB.Usuario.InsertOnSubmit(Usuario);
                acao = "cadastrado";
            }
            try
            {
                DB.SubmitChanges();
                IsEditing = false;
                ModernDialog.ShowMessage("Usuário " + Usuario.Nomeusuario + " "+acao+" com Sucesso!", "Usuário", MessageBoxButton.OK);                
                Usuario = null;
                IsNovo = true;
                if (GetUsuarioLogado() == null)
                {
                    ((MainWindow)App.Current.MainWindow).ContentSource = new Uri("/View/Login.xaml", UriKind.Relative);
                }
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
            Usuario = null;
            IsEditing = false;
            IsNovo = true;
        }

        private bool CanNovo()
        {
            return !IsEditing;
        }

        private void Novo()
        {
            Usuario = new Usuario();
            Usuario.Tipodocumento = TipoDeDocumento.CPF.ToString();
            IsEditing = true;
            IsNovo = true;
        }

        private void ProcuraCep()
        {
            try
            {                
                Address adr = BuscaCep.GetAddress(CEP);
                Usuario.Cidade = adr.City;
                Usuario.Endereco = adr.Street;
                Usuario.Estado = adr.State;

            }
            catch (Exception ex)
            {
                Usuario.Endereco = ex.Message;
            }
        }

        private Usuario GetUsuarioLogado()
        {
            return (Usuario)App.Current.Properties["UsuarioLogado"];    
            //if ((Usuario)App.Current.Properties["UsuarioLogado"] != null)
            //    return (Usuario)DB.Usuario.Where(u => u.ID ==
            //        ((Usuario)App.Current.Properties["UsuarioLogado"]).ID
            //    ).Single();
            //else return null;            
        }

        #endregion
    }
}
