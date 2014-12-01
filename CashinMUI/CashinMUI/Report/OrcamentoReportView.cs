using CashinMUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashinMUI.Report
{
    public partial class OrcamentoReportView : Form
    {
        public OrcamentoReportView()
        {
            InitializeComponent();
        }

        public OrcamentoReportView(Orcamento o)
        {
            InitializeComponent();
            orc = new OrcamentoReportModel();
            orc.Cliente = o.Cliente.Nome;
            orc.Cidade = o.Usuario.Cidade;
            orc.Data = o.Data;
            orc.Documento = o.Usuario.Tipodocumento + ": " + o.Usuario.Documento;
            orc.EmailUsuario = o.Usuario.Email;
            orc.EndUsuario = o.Usuario.Endereco + ", " + o.Usuario.Cidade + " - " + o.Usuario.Estado + " - CEP " + o.Usuario.Cep;
            orc.FoneUsuario = o.Usuario.Telefone;
            orc.NomeFantasia = o.Usuario.Nomefantasia;
            orc.Titulo = o.Titulo;
            orc.Descricao = "\t\t\t\t" + o.Descricao;
            orc.Usuario = o.Usuario.Nome;
            orc.Validade = o.Validade;
            orc.Codigo = o.ID.ToString("000");

            orc.Itens = new List<ItemOrcamentoReportModel>();
            foreach (Itemorcamento item in o.Itemorcamento)
            {
                orc.Itens.Add(new ItemOrcamentoReportModel(item.Descricao, item.Valor.GetValueOrDefault()));
            }
        }

        private OrcamentoReportModel orc;

        private void Form1_Load(object sender, EventArgs e)
        {
            OrcamentoReportModelBindingSource.DataSource = orc;
            ItemOrcamentoReportModelBindingSource.DataSource = orc.Itens;         
            this.reportViewer1.RefreshReport();
        }

        private void OrcamentoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
