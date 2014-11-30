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
            Orcamento = o;
        }

        private Orcamento Orcamento;

        private void Form1_Load(object sender, EventArgs e)
        {
            OrcamentoBindingSource.DataSource = Orcamento;
                        
            this.reportViewer1.RefreshReport();
        }

        private void OrcamentoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
