using CashinMUI.Model;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace CashinMUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            ContentSource = new Uri("/View/Login.xaml", UriKind.Relative);
            MenuLinkGroups = new LinkGroupCollection();
            MontaLinksDeslogado();
        }

        #region Variáveis

        private Uri _contentSource;
        public Uri ContentSource
        {
            get { return _contentSource; }
            set
            {
                if (_contentSource != value)
                {
                    _contentSource = value;
                    RaisePropertyChanged("ContentSource");
                }
            }
        }

        private string _titulo = "CashIN - Módulo de Gestão de Serviços Autônomos";
        public string Titulo
        {
            get { return _titulo; }

            set
            {
                if (value != _titulo)
                {
                    _titulo = "CashIN Autônomo - Logado como: "+value;
                    RaisePropertyChanged("Titulo");
                }
            }
        }

        private Usuario _usuarioLogado;
        public Usuario UsuarioLogado
        {
            get { return _usuarioLogado; }
            set
            {
                if (_usuarioLogado != value)
                {
                    if (value != null)
                    {
                        Titulo = ((Usuario)value).Nome;
                        MontaLinksLogado();
                    }
                    else
                    {
                        MontaLinksDeslogado();
                    }
                    _usuarioLogado = value;                    
                    RaisePropertyChanged("UsuarioLogado");
                }
            }
        }

        private LinkGroupCollection _menuLinkGroups;
        public LinkGroupCollection MenuLinkGroups
        {
            get
            {
                return _menuLinkGroups;
            }
            private set
            {
                if (value != null)
                {                    
                    _menuLinkGroups = value;
                    RaisePropertyChanged("MenuLinkGroups");
                }
            }
        }

        #endregion

        #region Commands

        private ICommand _logOut;
        public ICommand LogOutCommand
        {
            get
            {
                return _logOut ?? (_logOut = new GalaSoft.MvvmLight.Command.RelayCommand(LogOut, CanLogOut));
            }
        }

        #endregion


        #region Lógicas de negócio

        public bool CanLogOut()
        {
            return true;
        }

        public void LogOut()
        {
            if (ModernDialog.ShowMessage("Deseja mesmo deslogar ?", "Atenção!", MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                App.Current.Properties["UsuarioLogado"] = null;
                UsuarioLogado = null;
                ((MainWindow)App.Current.MainWindow).ContentSource = new Uri("/View/Login.xaml", UriKind.Relative);
            }
        }

        public void MontaLinksLogado()
        {
            LinkGroup inicio = new LinkGroup();
            inicio.DisplayName = "Início";
            inicio.Links.Add(new Link()
            {
                DisplayName = "Dashboard",
                Source = new Uri("/View/Home.xaml", UriKind.Relative)
            });

            LinkGroup entidades = new LinkGroup();
            entidades.DisplayName = "Entidades";
            entidades.Links.Add(new Link()
            {
                DisplayName = "Clientes",
                Source = new System.Uri("/View/ClienteView.xaml", UriKind.Relative)
            });
            entidades.Links.Add(new Link()
            {
                DisplayName = "Usuarios",
                Source = new System.Uri("/View/UsuarioView.xaml", UriKind.Relative)
            });
            LinkGroup orcamentos = new LinkGroup();
            orcamentos.DisplayName = "Orçamentos";            
            orcamentos.Links.Add(new Link()
            {
                DisplayName = "Cadastrar",
                Source = new System.Uri("/View/OrcamentoView.xaml", UriKind.Relative)
            });
            LinkGroup projetos = new LinkGroup();
            projetos.DisplayName = "projetos";
            projetos.Links.Add(new Link()
            {
                DisplayName = "Cadastrar",
                Source = new System.Uri("/View/ProjetoView.xaml", UriKind.Relative)
            });
            
            MenuLinkGroups.Clear();
            MenuLinkGroups.Add(inicio);
            MenuLinkGroups.Add(entidades);
            MenuLinkGroups.Add(orcamentos);
            MenuLinkGroups.Add(projetos);
            RaisePropertyChanged("MenuLinkGroups");

        }

        private void MontaLinksDeslogado()
        {            
            LinkGroup entidades = new LinkGroup();
            entidades.DisplayName = "iniciar";
            entidades.Links.Add(new Link()
            {
                DisplayName = "Login",
                Source = new System.Uri("/View/Login.xaml", UriKind.Relative)
            });
            entidades.Links.Add(new Link()
            {
                DisplayName = "Cadastre-se",
                Source = new System.Uri("/View/UsuarioView.xaml", UriKind.Relative)
            });
            MenuLinkGroups.Clear();
            MenuLinkGroups.Add(entidades);
            RaisePropertyChanged("MenuLinkGroups");
        }
        
        #endregion

    }
}