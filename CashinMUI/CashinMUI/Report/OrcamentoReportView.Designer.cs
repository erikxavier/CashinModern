namespace CashinMUI.Report
{
    partial class OrcamentoReportView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ItemOrcamentoReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrcamentoReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ItemOrcamentoReportModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoReportModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ItemDS";
            reportDataSource1.Value = this.ItemOrcamentoReportModelBindingSource;
            reportDataSource2.Name = "OrcamentoDS";
            reportDataSource2.Value = this.OrcamentoReportModelBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CashinMUI.Report.OrcamentoReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1016, 474);
            this.reportViewer1.TabIndex = 0;
            // 
            // ItemOrcamentoReportModelBindingSource
            // 
            this.ItemOrcamentoReportModelBindingSource.DataSource = typeof(CashinMUI.Model.ItemOrcamentoReportModel);
            // 
            // OrcamentoReportModelBindingSource
            // 
            this.OrcamentoReportModelBindingSource.DataSource = typeof(CashinMUI.Model.OrcamentoReportModel);
            // 
            // OrcamentoReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 474);
            this.Controls.Add(this.reportViewer1);
            this.Name = "OrcamentoReportView";
            this.Text = "Imprimir Orçamento";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemOrcamentoReportModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoReportModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ItemOrcamentoReportModelBindingSource;
        private System.Windows.Forms.BindingSource OrcamentoReportModelBindingSource;


    }
}