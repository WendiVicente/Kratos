namespace Sistema.Reports.Reports_Clientes
{
    partial class ReporteFechaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteFechaCliente));
            this.ListarClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvfechacliente = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ListarClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ListarClientesBindingSource
            // 
            this.ListarClientesBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarClientes);
            // 
            // rvfechacliente
            // 
            this.rvfechacliente.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ClientesFecha";
            reportDataSource1.Value = this.ListarClientesBindingSource;
            this.rvfechacliente.LocalReport.DataSources.Add(reportDataSource1);
            this.rvfechacliente.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Clientes.ReporteFechaCliente.rdlc";
            this.rvfechacliente.Location = new System.Drawing.Point(0, 0);
            this.rvfechacliente.Name = "rvfechacliente";
            this.rvfechacliente.ServerReport.BearerToken = null;
            this.rvfechacliente.Size = new System.Drawing.Size(800, 450);
            this.rvfechacliente.TabIndex = 0;
            // 
            // ReporteFechaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvfechacliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteFechaCliente";
            this.Text = "ReporteFechaCliente";
            this.Load += new System.EventHandler(this.ReporteFechaCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListarClientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvfechacliente;
        private System.Windows.Forms.BindingSource ListarClientesBindingSource;
    }
}