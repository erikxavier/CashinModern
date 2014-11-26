// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from cashindb on 2014-11-25 23:57:44Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
using System;
using System.ComponentModel;
using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
using System.Diagnostics;

namespace CashinMUI.Model
{

    public partial class CashinDB : DataContext
    {

        #region Extensibility Method Declarations
        partial void OnCreated();
        #endregion


        public CashinDB(string connectionString) :
            base(connectionString)
        {
            this.OnCreated();
        }

        public CashinDB(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public CashinDB(IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public Table<Cliente> Cliente
        {
            get
            {
                return this.GetTable<Cliente>();
            }
        }

        public Table<Itemorcamento> Itemorcamento
        {
            get
            {
                return this.GetTable<Itemorcamento>();
            }
        }

        public Table<Nota> Nota
        {
            get
            {
                return this.GetTable<Nota>();
            }
        }

        public Table<Orcamento> Orcamento
        {
            get
            {
                return this.GetTable<Orcamento>();
            }
        }

        public Table<Projeto> Projeto
        {
            get
            {
                return this.GetTable<Projeto>();
            }
        }

        public Table<Tarefa> Tarefa
        {
            get
            {
                return this.GetTable<Tarefa>();
            }
        }

        public Table<Usuario> Usuario
        {
            get
            {
                return this.GetTable<Usuario>();
            }
        }
    }

    #region Start MONO_STRICT
#if MONO_STRICT

public partial class Cashindb
{
	
	public Cashindb(IDbConnection connection) : 
			base(connection)
	{
		this.OnCreated();
	}
}
    #region End MONO_STRICT
#endregion
#else     // MONO_STRICT

    public partial class CashinDB
    {
        public CashinDB() :
            base(new MySql.Data.MySqlClient.MySqlConnection("server=localhost;uid=root;database=cashindb"), new DbLinq.MySql.MySqlVendor())
        {
            this.OnCreated();
        }

        public CashinDB(IDbConnection connection) :
            base(connection, new DbLinq.MySql.MySqlVendor())
        {
            this.OnCreated();
        }

        public CashinDB(IDbConnection connection, IVendor sqlDialect) :
            base(connection, sqlDialect)
        {
            this.OnCreated();
        }

        public CashinDB(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) :
            base(connection, mappingSource, sqlDialect)
        {
            this.OnCreated();
        }
    }
    #region End Not MONO_STRICT
    #endregion
#endif     // MONO_STRICT
    #endregion

    [Table(Name = "cashindb.cliente")]
    public partial class Cliente : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _cep;

        private string _cidade;

        private string _documento;

        private string _email;

        private string _endereco;

        private string _estado;

        private int _id;

        private int _idusuario;

        private string _nome;

        private string _telefone;

        private string _tipodocumento;

        private EntitySet<Orcamento> _orcamento;

        private EntityRef<Usuario> _usuario = new EntityRef<Usuario>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnCepChanged();

        partial void OnCepChanging(string value);

        partial void OnCidadeChanged();

        partial void OnCidadeChanging(string value);

        partial void OnDocumentoChanged();

        partial void OnDocumentoChanging(string value);

        partial void OnEmailChanged();

        partial void OnEmailChanging(string value);

        partial void OnEnderecoChanged();

        partial void OnEnderecoChanging(string value);

        partial void OnEstadoChanged();

        partial void OnEstadoChanging(string value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIdusuarioChanged();

        partial void OnIdusuarioChanging(int value);

        partial void OnNomeChanged();

        partial void OnNomeChanging(string value);

        partial void OnTelefoneChanged();

        partial void OnTelefoneChanging(string value);

        partial void OnTipodocumentoChanged();

        partial void OnTipodocumentoChanging(string value);
        #endregion


        public Cliente()
        {
            _orcamento = new EntitySet<Orcamento>(new Action<Orcamento>(this.Orcamento_Attach), new Action<Orcamento>(this.Orcamento_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_cep", Name = "CEP", DbType = "varchar(8)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Cep
        {
            get
            {
                return this._cep;
            }
            set
            {
                if (((_cep == value)
                            == false))
                {
                    this.OnCepChanging(value);
                    this.SendPropertyChanging();
                    this._cep = value;
                    this.SendPropertyChanged("Cep");
                    this.OnCepChanged();
                }
            }
        }

        [Column(Storage = "_cidade", Name = "CIDADE", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Cidade
        {
            get
            {
                return this._cidade;
            }
            set
            {
                if (((_cidade == value)
                            == false))
                {
                    this.OnCidadeChanging(value);
                    this.SendPropertyChanging();
                    this._cidade = value;
                    this.SendPropertyChanged("Cidade");
                    this.OnCidadeChanged();
                }
            }
        }

        [Column(Storage = "_documento", Name = "DOCUMENTO", DbType = "varchar(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Documento
        {
            get
            {
                return this._documento;
            }
            set
            {
                if (((_documento == value)
                            == false))
                {
                    this.OnDocumentoChanging(value);
                    this.SendPropertyChanging();
                    this._documento = value;
                    this.SendPropertyChanged("Documento");
                    this.OnDocumentoChanged();
                }
            }
        }

        [Column(Storage = "_email", Name = "EMAIL", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                if (((_email == value)
                            == false))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [Column(Storage = "_endereco", Name = "ENDERECO", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Endereco
        {
            get
            {
                return this._endereco;
            }
            set
            {
                if (((_endereco == value)
                            == false))
                {
                    this.OnEnderecoChanging(value);
                    this.SendPropertyChanging();
                    this._endereco = value;
                    this.SendPropertyChanged("Endereco");
                    this.OnEnderecoChanged();
                }
            }
        }

        [Column(Storage = "_estado", Name = "ESTADO", DbType = "varchar(2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Estado
        {
            get
            {
                return this._estado;
            }
            set
            {
                if (((_estado == value)
                            == false))
                {
                    this.OnEstadoChanging(value);
                    this.SendPropertyChanging();
                    this._estado = value;
                    this.SendPropertyChanged("Estado");
                    this.OnEstadoChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "ID", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_idusuario", Name = "IDUSUARIO", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Idusuario
        {
            get
            {
                return this._idusuario;
            }
            set
            {
                if ((_idusuario != value))
                {
                    this.OnIdusuarioChanging(value);
                    this.SendPropertyChanging();
                    this._idusuario = value;
                    this.SendPropertyChanged("Idusuario");
                    this.OnIdusuarioChanged();
                }
            }
        }

        [Column(Storage = "_nome", Name = "NOME", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Nome
        {
            get
            {
                return this._nome;
            }
            set
            {
                if (((_nome == value)
                            == false))
                {
                    this.OnNomeChanging(value);
                    this.SendPropertyChanging();
                    this._nome = value;
                    this.SendPropertyChanged("Nome");
                    this.OnNomeChanged();
                }
            }
        }

        [Column(Storage = "_telefone", Name = "TELEFONE", DbType = "varchar(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Telefone
        {
            get
            {
                return this._telefone;
            }
            set
            {
                if (((_telefone == value)
                            == false))
                {
                    this.OnTelefoneChanging(value);
                    this.SendPropertyChanging();
                    this._telefone = value;
                    this.SendPropertyChanged("Telefone");
                    this.OnTelefoneChanged();
                }
            }
        }

        [Column(Storage = "_tipodocumento", Name = "TIPODOCUMENTO", DbType = "varchar(4)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Tipodocumento
        {
            get
            {
                return this._tipodocumento;
            }
            set
            {
                if (((_tipodocumento == value)
                            == false))
                {
                    this.OnTipodocumentoChanging(value);
                    this.SendPropertyChanging();
                    this._tipodocumento = value;
                    this.SendPropertyChanged("Tipodocumento");
                    this.OnTipodocumentoChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_orcamento", OtherKey = "Idcliente", ThisKey = "ID", Name = "orcamento_ibfk_1")]
        [DebuggerNonUserCode()]
        public EntitySet<Orcamento> Orcamento
        {
            get
            {
                return this._orcamento;
            }
            set
            {
                this._orcamento = value;
            }
        }
        #endregion

        #region Parents
        [Association(Storage = "_usuario", OtherKey = "ID", ThisKey = "Idusuario", Name = "cliente_ibfk_1", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Usuario Usuario
        {
            get
            {
                return this._usuario.Entity;
            }
            set
            {
                if (((this._usuario.Entity == value)
                            == false))
                {
                    if ((this._usuario.Entity != null))
                    {
                        Usuario previousUsuario = this._usuario.Entity;
                        this._usuario.Entity = null;
                        previousUsuario.Cliente.Remove(this);
                    }
                    this._usuario.Entity = value;
                    if ((value != null))
                    {
                        value.Cliente.Add(this);
                        _idusuario = value.ID;
                    }
                    else
                    {
                        _idusuario = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void Orcamento_Attach(Orcamento entity)
        {
            this.SendPropertyChanging();
            entity.Cliente = this;
        }

        private void Orcamento_Detach(Orcamento entity)
        {
            this.SendPropertyChanging();
            entity.Cliente = null;
        }
        #endregion
    }

    [Table(Name = "cashindb.itemorcamento")]
    public partial class Itemorcamento : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _descricao;

        private int _id;

        private int _idorcamento;

        private System.Nullable<decimal> _valor;

        private EntityRef<Orcamento> _orcamento = new EntityRef<Orcamento>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDescricaoChanged();

        partial void OnDescricaoChanging(string value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIdorcamentoChanged();

        partial void OnIdorcamentoChanging(int value);

        partial void OnValorChanged();

        partial void OnValorChanging(System.Nullable<decimal> value);
        #endregion


        public Itemorcamento()
        {
            this.OnCreated();
        }

        [Column(Storage = "_descricao", Name = "DESCRICAO", DbType = "varchar(200)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Descricao
        {
            get
            {
                return this._descricao;
            }
            set
            {
                if (((_descricao == value)
                            == false))
                {
                    this.OnDescricaoChanging(value);
                    this.SendPropertyChanging();
                    this._descricao = value;
                    this.SendPropertyChanged("Descricao");
                    this.OnDescricaoChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "ID", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_idorcamento", Name = "IDORCAMENTO", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Idorcamento
        {
            get
            {
                return this._idorcamento;
            }
            set
            {
                if ((_idorcamento != value))
                {
                    this.OnIdorcamentoChanging(value);
                    this.SendPropertyChanging();
                    this._idorcamento = value;
                    this.SendPropertyChanged("Idorcamento");
                    this.OnIdorcamentoChanged();
                }
            }
        }

        [Column(Storage = "_valor", Name = "VALOR", DbType = "decimal(7,2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<decimal> Valor
        {
            get
            {
                return this._valor;
            }
            set
            {
                if ((_valor != value))
                {
                    this.OnValorChanging(value);
                    this.SendPropertyChanging();
                    this._valor = value;
                    this.SendPropertyChanged("Valor");
                    this.OnValorChanged();
                }
            }
        }

        #region Parents
        [Association(Storage = "_orcamento", OtherKey = "ID", ThisKey = "Idorcamento", Name = "itemorcamento_ibfk_1", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Orcamento Orcamento
        {
            get
            {
                return this._orcamento.Entity;
            }
            set
            {
                if (((this._orcamento.Entity == value)
                            == false))
                {
                    if ((this._orcamento.Entity != null))
                    {
                        Orcamento previousOrcamento = this._orcamento.Entity;
                        this._orcamento.Entity = null;
                        previousOrcamento.Itemorcamento.Remove(this);
                    }
                    this._orcamento.Entity = value;
                    if ((value != null))
                    {
                        value.Itemorcamento.Add(this);
                        _idorcamento = value.ID;
                    }
                    else
                    {
                        _idorcamento = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "cashindb.nota")]
    public partial class Nota : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<System.DateTime> _dataemissao;

        private int _id;

        private int _idorcamento;

        private decimal _valorpago;

        private EntityRef<Orcamento> _orcamento = new EntityRef<Orcamento>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDataemissaoChanged();

        partial void OnDataemissaoChanging(System.Nullable<System.DateTime> value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIdorcamentoChanged();

        partial void OnIdorcamentoChanging(int value);

        partial void OnValorpagoChanged();

        partial void OnValorpagoChanging(decimal value);
        #endregion


        public Nota()
        {
            this.OnCreated();
        }

        [Column(Storage = "_dataemissao", Name = "DATAEMISSAO", DbType = "date", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> Dataemissao
        {
            get
            {
                return this._dataemissao;
            }
            set
            {
                if ((_dataemissao != value))
                {
                    this.OnDataemissaoChanging(value);
                    this.SendPropertyChanging();
                    this._dataemissao = value;
                    this.SendPropertyChanged("Dataemissao");
                    this.OnDataemissaoChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "ID", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_idorcamento", Name = "IDORCAMENTO", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Idorcamento
        {
            get
            {
                return this._idorcamento;
            }
            set
            {
                if ((_idorcamento != value))
                {
                    this.OnIdorcamentoChanging(value);
                    this.SendPropertyChanging();
                    this._idorcamento = value;
                    this.SendPropertyChanged("Idorcamento");
                    this.OnIdorcamentoChanged();
                }
            }
        }

        [Column(Storage = "_valorpago", Name = "VALORPAGO", DbType = "decimal(7,2)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public decimal Valorpago
        {
            get
            {
                return this._valorpago;
            }
            set
            {
                if ((_valorpago != value))
                {
                    this.OnValorpagoChanging(value);
                    this.SendPropertyChanging();
                    this._valorpago = value;
                    this.SendPropertyChanged("Valorpago");
                    this.OnValorpagoChanged();
                }
            }
        }

        #region Parents
        [Association(Storage = "_orcamento", OtherKey = "ID", ThisKey = "Idorcamento", Name = "nota_ibfk_1", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Orcamento Orcamento
        {
            get
            {
                return this._orcamento.Entity;
            }
            set
            {
                if (((this._orcamento.Entity == value)
                            == false))
                {
                    if ((this._orcamento.Entity != null))
                    {
                        Orcamento previousOrcamento = this._orcamento.Entity;
                        this._orcamento.Entity = null;
                        previousOrcamento.Nota.Remove(this);
                    }
                    this._orcamento.Entity = value;
                    if ((value != null))
                    {
                        value.Nota.Add(this);
                        _idorcamento = value.ID;
                    }
                    else
                    {
                        _idorcamento = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "cashindb.orcamento")]
    public partial class Orcamento : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.DateTime _data;

        private int _id;

        private int _idcliente;

        private int _idusuario;

        private System.DateTime _validade;

        private EntitySet<Itemorcamento> _itemorcamento;

        private EntitySet<Nota> _nota;

        private EntitySet<Projeto> _projeto;

        private EntityRef<Cliente> _cliente = new EntityRef<Cliente>();

        private EntityRef<Usuario> _usuario = new EntityRef<Usuario>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDataChanged();

        partial void OnDataChanging(System.DateTime value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIdclienteChanged();

        partial void OnIdclienteChanging(int value);

        partial void OnIdusuarioChanged();

        partial void OnIdusuarioChanging(int value);

        partial void OnValidadeChanged();

        partial void OnValidadeChanging(System.DateTime value);
        #endregion


        public Orcamento()
        {
            _itemorcamento = new EntitySet<Itemorcamento>(new Action<Itemorcamento>(this.Itemorcamento_Attach), new Action<Itemorcamento>(this.Itemorcamento_Detach));
            _nota = new EntitySet<Nota>(new Action<Nota>(this.Nota_Attach), new Action<Nota>(this.Nota_Detach));
            _projeto = new EntitySet<Projeto>(new Action<Projeto>(this.Projeto_Attach), new Action<Projeto>(this.Projeto_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_data", Name = "DATA", DbType = "date", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime Data
        {
            get
            {
                return this._data;
            }
            set
            {
                if ((_data != value))
                {
                    this.OnDataChanging(value);
                    this.SendPropertyChanging();
                    this._data = value;
                    this.SendPropertyChanged("Data");
                    this.OnDataChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "ID", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_idcliente", Name = "IDCLIENTE", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Idcliente
        {
            get
            {
                return this._idcliente;
            }
            set
            {
                if ((_idcliente != value))
                {
                    this.OnIdclienteChanging(value);
                    this.SendPropertyChanging();
                    this._idcliente = value;
                    this.SendPropertyChanged("Idcliente");
                    this.OnIdclienteChanged();
                }
            }
        }

        [Column(Storage = "_idusuario", Name = "IDUSUARIO", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Idusuario
        {
            get
            {
                return this._idusuario;
            }
            set
            {
                if ((_idusuario != value))
                {
                    this.OnIdusuarioChanging(value);
                    this.SendPropertyChanging();
                    this._idusuario = value;
                    this.SendPropertyChanged("Idusuario");
                    this.OnIdusuarioChanged();
                }
            }
        }

        [Column(Storage = "_validade", Name = "VALIDADE", DbType = "date", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime Validade
        {
            get
            {
                return this._validade;
            }
            set
            {
                if ((_validade != value))
                {
                    this.OnValidadeChanging(value);
                    this.SendPropertyChanging();
                    this._validade = value;
                    this.SendPropertyChanged("Validade");
                    this.OnValidadeChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_itemorcamento", OtherKey = "Idorcamento", ThisKey = "ID", Name = "itemorcamento_ibfk_1")]
        [DebuggerNonUserCode()]
        public EntitySet<Itemorcamento> Itemorcamento
        {
            get
            {
                return this._itemorcamento;
            }
            set
            {
                this._itemorcamento = value;
            }
        }

        [Association(Storage = "_nota", OtherKey = "Idorcamento", ThisKey = "ID", Name = "nota_ibfk_1")]
        [DebuggerNonUserCode()]
        public EntitySet<Nota> Nota
        {
            get
            {
                return this._nota;
            }
            set
            {
                this._nota = value;
            }
        }

        [Association(Storage = "_projeto", OtherKey = "Idorcamento", ThisKey = "ID", Name = "projeto_ibfk_1")]
        [DebuggerNonUserCode()]
        public EntitySet<Projeto> Projeto
        {
            get
            {
                return this._projeto;
            }
            set
            {
                this._projeto = value;
            }
        }
        #endregion

        #region Parents
        [Association(Storage = "_cliente", OtherKey = "ID", ThisKey = "Idcliente", Name = "orcamento_ibfk_1", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Cliente Cliente
        {
            get
            {
                return this._cliente.Entity;
            }
            set
            {
                if (((this._cliente.Entity == value)
                            == false))
                {
                    if ((this._cliente.Entity != null))
                    {
                        Cliente previousCliente = this._cliente.Entity;
                        this._cliente.Entity = null;
                        previousCliente.Orcamento.Remove(this);
                    }
                    this._cliente.Entity = value;
                    if ((value != null))
                    {
                        value.Orcamento.Add(this);
                        _idcliente = value.ID;
                    }
                    else
                    {
                        _idcliente = default(int);
                    }
                }
            }
        }

        [Association(Storage = "_usuario", OtherKey = "ID", ThisKey = "Idusuario", Name = "orcamento_ibfk_2", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Usuario Usuario
        {
            get
            {
                return this._usuario.Entity;
            }
            set
            {
                if (((this._usuario.Entity == value)
                            == false))
                {
                    if ((this._usuario.Entity != null))
                    {
                        Usuario previousUsuario = this._usuario.Entity;
                        this._usuario.Entity = null;
                        previousUsuario.Orcamento.Remove(this);
                    }
                    this._usuario.Entity = value;
                    if ((value != null))
                    {
                        value.Orcamento.Add(this);
                        _idusuario = value.ID;
                    }
                    else
                    {
                        _idusuario = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void Itemorcamento_Attach(Itemorcamento entity)
        {
            this.SendPropertyChanging();
            entity.Orcamento = this;
        }

        private void Itemorcamento_Detach(Itemorcamento entity)
        {
            this.SendPropertyChanging();
            entity.Orcamento = null;
        }

        private void Nota_Attach(Nota entity)
        {
            this.SendPropertyChanging();
            entity.Orcamento = this;
        }

        private void Nota_Detach(Nota entity)
        {
            this.SendPropertyChanging();
            entity.Orcamento = null;
        }

        private void Projeto_Attach(Projeto entity)
        {
            this.SendPropertyChanging();
            entity.Orcamento = this;
        }

        private void Projeto_Detach(Projeto entity)
        {
            this.SendPropertyChanging();
            entity.Orcamento = null;
        }
        #endregion
    }

    [Table(Name = "cashindb.projeto")]
    public partial class Projeto : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<sbyte> _finalizado;

        private int _id;

        private System.Nullable<int> _idorcamento;

        private System.Nullable<System.DateTime> _inicio;

        private System.Nullable<System.DateTime> _prazo;

        private EntitySet<Tarefa> _tarefa;

        private EntityRef<Orcamento> _orcamento = new EntityRef<Orcamento>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnFinalizadoChanged();

        partial void OnFinalizadoChanging(System.Nullable<sbyte> value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIdorcamentoChanged();

        partial void OnIdorcamentoChanging(System.Nullable<int> value);

        partial void OnInicioChanged();

        partial void OnInicioChanging(System.Nullable<System.DateTime> value);

        partial void OnPrazoChanged();

        partial void OnPrazoChanging(System.Nullable<System.DateTime> value);
        #endregion


        public Projeto()
        {
            _tarefa = new EntitySet<Tarefa>(new Action<Tarefa>(this.Tarefa_Attach), new Action<Tarefa>(this.Tarefa_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_finalizado", Name = "FINALIZADO", DbType = "tinyint(1)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> Finalizado
        {
            get
            {
                return this._finalizado;
            }
            set
            {
                if ((_finalizado != value))
                {
                    this.OnFinalizadoChanging(value);
                    this.SendPropertyChanging();
                    this._finalizado = value;
                    this.SendPropertyChanged("Finalizado");
                    this.OnFinalizadoChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "ID", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_idorcamento", Name = "IDORCAMENTO", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> Idorcamento
        {
            get
            {
                return this._idorcamento;
            }
            set
            {
                if ((_idorcamento != value))
                {
                    this.OnIdorcamentoChanging(value);
                    this.SendPropertyChanging();
                    this._idorcamento = value;
                    this.SendPropertyChanged("Idorcamento");
                    this.OnIdorcamentoChanged();
                }
            }
        }

        [Column(Storage = "_inicio", Name = "INICIO", DbType = "date", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> Inicio
        {
            get
            {
                return this._inicio;
            }
            set
            {
                if ((_inicio != value))
                {
                    this.OnInicioChanging(value);
                    this.SendPropertyChanging();
                    this._inicio = value;
                    this.SendPropertyChanged("Inicio");
                    this.OnInicioChanged();
                }
            }
        }

        [Column(Storage = "_prazo", Name = "PRAZO", DbType = "date", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> Prazo
        {
            get
            {
                return this._prazo;
            }
            set
            {
                if ((_prazo != value))
                {
                    this.OnPrazoChanging(value);
                    this.SendPropertyChanging();
                    this._prazo = value;
                    this.SendPropertyChanged("Prazo");
                    this.OnPrazoChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_tarefa", OtherKey = "Idprojeto", ThisKey = "ID", Name = "tarefa_ibfk_1")]
        [DebuggerNonUserCode()]
        public EntitySet<Tarefa> Tarefa
        {
            get
            {
                return this._tarefa;
            }
            set
            {
                this._tarefa = value;
            }
        }
        #endregion

        #region Parents
        [Association(Storage = "_orcamento", OtherKey = "ID", ThisKey = "Idorcamento", Name = "projeto_ibfk_1", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Orcamento Orcamento
        {
            get
            {
                return this._orcamento.Entity;
            }
            set
            {
                if (((this._orcamento.Entity == value)
                            == false))
                {
                    if ((this._orcamento.Entity != null))
                    {
                        Orcamento previousOrcamento = this._orcamento.Entity;
                        this._orcamento.Entity = null;
                        previousOrcamento.Projeto.Remove(this);
                    }
                    this._orcamento.Entity = value;
                    if ((value != null))
                    {
                        value.Projeto.Add(this);
                        _idorcamento = value.ID;
                    }
                    else
                    {
                        _idorcamento = null;
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void Tarefa_Attach(Tarefa entity)
        {
            this.SendPropertyChanging();
            entity.Projeto = this;
        }

        private void Tarefa_Detach(Tarefa entity)
        {
            this.SendPropertyChanging();
            entity.Projeto = null;
        }
        #endregion
    }

    [Table(Name = "cashindb.tarefa")]
    public partial class Tarefa : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _atividade;

        private System.Nullable<sbyte> _finalizada;

        private int _id;

        private int _idprojeto;

        private string _relatorio;

        private EntityRef<Projeto> _projeto = new EntityRef<Projeto>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnAtividadeChanged();

        partial void OnAtividadeChanging(string value);

        partial void OnFinalizadaChanged();

        partial void OnFinalizadaChanging(System.Nullable<sbyte> value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIdprojetoChanged();

        partial void OnIdprojetoChanging(int value);

        partial void OnRelatorioChanged();

        partial void OnRelatorioChanging(string value);
        #endregion


        public Tarefa()
        {
            this.OnCreated();
        }

        [Column(Storage = "_atividade", Name = "ATIVIDADE", DbType = "varchar(300)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Atividade
        {
            get
            {
                return this._atividade;
            }
            set
            {
                if (((_atividade == value)
                            == false))
                {
                    this.OnAtividadeChanging(value);
                    this.SendPropertyChanging();
                    this._atividade = value;
                    this.SendPropertyChanged("Atividade");
                    this.OnAtividadeChanged();
                }
            }
        }

        [Column(Storage = "_finalizada", Name = "FINALIZADA", DbType = "tinyint(1)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> Finalizada
        {
            get
            {
                return this._finalizada;
            }
            set
            {
                if ((_finalizada != value))
                {
                    this.OnFinalizadaChanging(value);
                    this.SendPropertyChanging();
                    this._finalizada = value;
                    this.SendPropertyChanged("Finalizada");
                    this.OnFinalizadaChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "ID", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_idprojeto", Name = "IDPROJETO", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Idprojeto
        {
            get
            {
                return this._idprojeto;
            }
            set
            {
                if ((_idprojeto != value))
                {
                    this.OnIdprojetoChanging(value);
                    this.SendPropertyChanging();
                    this._idprojeto = value;
                    this.SendPropertyChanged("Idprojeto");
                    this.OnIdprojetoChanged();
                }
            }
        }

        [Column(Storage = "_relatorio", Name = "RELATORIO", DbType = "varchar(300)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Relatorio
        {
            get
            {
                return this._relatorio;
            }
            set
            {
                if (((_relatorio == value)
                            == false))
                {
                    this.OnRelatorioChanging(value);
                    this.SendPropertyChanging();
                    this._relatorio = value;
                    this.SendPropertyChanged("Relatorio");
                    this.OnRelatorioChanged();
                }
            }
        }

        #region Parents
        [Association(Storage = "_projeto", OtherKey = "ID", ThisKey = "Idprojeto", Name = "tarefa_ibfk_1", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Projeto Projeto
        {
            get
            {
                return this._projeto.Entity;
            }
            set
            {
                if (((this._projeto.Entity == value)
                            == false))
                {
                    if ((this._projeto.Entity != null))
                    {
                        Projeto previousProjeto = this._projeto.Entity;
                        this._projeto.Entity = null;
                        previousProjeto.Tarefa.Remove(this);
                    }
                    this._projeto.Entity = value;
                    if ((value != null))
                    {
                        value.Tarefa.Add(this);
                        _idprojeto = value.ID;
                    }
                    else
                    {
                        _idprojeto = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "cashindb.usuario")]
    public partial class Usuario : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _cep;

        private string _cidade;

        private string _documento;

        private string _email;

        private string _endereco;

        private string _estado;

        private int _id;

        private string _nome;

        private string _nomefantasia;

        private string _nomeusuario;

        private string _senha;

        private string _telefone;

        private string _tipodocumento;

        private EntitySet<Cliente> _cliente;

        private EntitySet<Orcamento> _orcamento;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnCepChanged();

        partial void OnCepChanging(string value);

        partial void OnCidadeChanged();

        partial void OnCidadeChanging(string value);

        partial void OnDocumentoChanged();

        partial void OnDocumentoChanging(string value);

        partial void OnEmailChanged();

        partial void OnEmailChanging(string value);

        partial void OnEnderecoChanged();

        partial void OnEnderecoChanging(string value);

        partial void OnEstadoChanged();

        partial void OnEstadoChanging(string value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnNomeChanged();

        partial void OnNomeChanging(string value);

        partial void OnNomefantasiaChanged();

        partial void OnNomefantasiaChanging(string value);

        partial void OnNomeusuarioChanged();

        partial void OnNomeusuarioChanging(string value);

        partial void OnSenhaChanged();

        partial void OnSenhaChanging(string value);

        partial void OnTelefoneChanged();

        partial void OnTelefoneChanging(string value);

        partial void OnTipodocumentoChanged();

        partial void OnTipodocumentoChanging(string value);
        #endregion


        public Usuario()
        {
            _cliente = new EntitySet<Cliente>(new Action<Cliente>(this.Cliente_Attach), new Action<Cliente>(this.Cliente_Detach));
            _orcamento = new EntitySet<Orcamento>(new Action<Orcamento>(this.Orcamento_Attach), new Action<Orcamento>(this.Orcamento_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_cep", Name = "CEP", DbType = "varchar(8)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Cep
        {
            get
            {
                return this._cep;
            }
            set
            {
                if (((_cep == value)
                            == false))
                {
                    this.OnCepChanging(value);
                    this.SendPropertyChanging();
                    this._cep = value;
                    this.SendPropertyChanged("Cep");
                    this.OnCepChanged();
                }
            }
        }

        [Column(Storage = "_cidade", Name = "CIDADE", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Cidade
        {
            get
            {
                return this._cidade;
            }
            set
            {
                if (((_cidade == value)
                            == false))
                {
                    this.OnCidadeChanging(value);
                    this.SendPropertyChanging();
                    this._cidade = value;
                    this.SendPropertyChanged("Cidade");
                    this.OnCidadeChanged();
                }
            }
        }

        [Column(Storage = "_documento", Name = "DOCUMENTO", DbType = "varchar(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Documento
        {
            get
            {
                return this._documento;
            }
            set
            {
                if (((_documento == value)
                            == false))
                {
                    this.OnDocumentoChanging(value);
                    this.SendPropertyChanging();
                    this._documento = value;
                    this.SendPropertyChanged("Documento");
                    this.OnDocumentoChanged();
                }
            }
        }

        [Column(Storage = "_email", Name = "EMAIL", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                if (((_email == value)
                            == false))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [Column(Storage = "_endereco", Name = "ENDERECO", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Endereco
        {
            get
            {
                return this._endereco;
            }
            set
            {
                if (((_endereco == value)
                            == false))
                {
                    this.OnEnderecoChanging(value);
                    this.SendPropertyChanging();
                    this._endereco = value;
                    this.SendPropertyChanged("Endereco");
                    this.OnEnderecoChanged();
                }
            }
        }

        [Column(Storage = "_estado", Name = "ESTADO", DbType = "varchar(2)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Estado
        {
            get
            {
                return this._estado;
            }
            set
            {
                if (((_estado == value)
                            == false))
                {
                    this.OnEstadoChanging(value);
                    this.SendPropertyChanging();
                    this._estado = value;
                    this.SendPropertyChanged("Estado");
                    this.OnEstadoChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "ID", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_nome", Name = "NOME", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Nome
        {
            get
            {
                return this._nome;
            }
            set
            {
                if (((_nome == value)
                            == false))
                {
                    this.OnNomeChanging(value);
                    this.SendPropertyChanging();
                    this._nome = value;
                    this.SendPropertyChanged("Nome");
                    this.OnNomeChanged();
                }
            }
        }

        [Column(Storage = "_nomefantasia", Name = "NOMEFANTASIA", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Nomefantasia
        {
            get
            {
                return this._nomefantasia;
            }
            set
            {
                if (((_nomefantasia == value)
                            == false))
                {
                    this.OnNomefantasiaChanging(value);
                    this.SendPropertyChanging();
                    this._nomefantasia = value;
                    this.SendPropertyChanged("Nomefantasia");
                    this.OnNomefantasiaChanged();
                }
            }
        }

        [Column(Storage = "_nomeusuario", Name = "NOMEUSUARIO", DbType = "varchar(20)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Nomeusuario
        {
            get
            {
                return this._nomeusuario;
            }
            set
            {
                if (((_nomeusuario == value)
                            == false))
                {
                    this.OnNomeusuarioChanging(value);
                    this.SendPropertyChanging();
                    this._nomeusuario = value;
                    this.SendPropertyChanged("Nomeusuario");
                    this.OnNomeusuarioChanged();
                }
            }
        }

        [Column(Storage = "_senha", Name = "SENHA", DbType = "varchar(50)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Senha
        {
            get
            {
                return this._senha;
            }
            set
            {
                if (((_senha == value)
                            == false))
                {
                    this.OnSenhaChanging(value);
                    this.SendPropertyChanging();
                    this._senha = value;
                    this.SendPropertyChanged("Senha");
                    this.OnSenhaChanged();
                }
            }
        }

        [Column(Storage = "_telefone", Name = "TELEFONE", DbType = "varchar(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Telefone
        {
            get
            {
                return this._telefone;
            }
            set
            {
                if (((_telefone == value)
                            == false))
                {
                    this.OnTelefoneChanging(value);
                    this.SendPropertyChanging();
                    this._telefone = value;
                    this.SendPropertyChanged("Telefone");
                    this.OnTelefoneChanged();
                }
            }
        }

        [Column(Storage = "_tipodocumento", Name = "TIPODOCUMENTO", DbType = "varchar(4)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Tipodocumento
        {
            get
            {
                return this._tipodocumento;
            }
            set
            {
                if (((_tipodocumento == value)
                            == false))
                {
                    this.OnTipodocumentoChanging(value);
                    this.SendPropertyChanging();
                    this._tipodocumento = value;
                    this.SendPropertyChanged("Tipodocumento");
                    this.OnTipodocumentoChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_cliente", OtherKey = "Idusuario", ThisKey = "ID", Name = "cliente_ibfk_1")]
        [DebuggerNonUserCode()]
        public EntitySet<Cliente> Cliente
        {
            get
            {
                return this._cliente;
            }
            set
            {
                this._cliente = value;
            }
        }

        [Association(Storage = "_orcamento", OtherKey = "Idusuario", ThisKey = "ID", Name = "orcamento_ibfk_2")]
        [DebuggerNonUserCode()]
        public EntitySet<Orcamento> Orcamento
        {
            get
            {
                return this._orcamento;
            }
            set
            {
                this._orcamento = value;
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void Cliente_Attach(Cliente entity)
        {
            this.SendPropertyChanging();
            entity.Usuario = this;
        }

        private void Cliente_Detach(Cliente entity)
        {
            this.SendPropertyChanging();
            entity.Usuario = null;
        }

        private void Orcamento_Attach(Orcamento entity)
        {
            this.SendPropertyChanging();
            entity.Usuario = this;
        }

        private void Orcamento_Detach(Orcamento entity)
        {
            this.SendPropertyChanging();
            entity.Usuario = null;
        }
        #endregion
    }
}