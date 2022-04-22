namespace POS.Recibo
{
    partial class FacturaFEL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturaFEL));
            this.rvfacturafel = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ListarDetalleFacturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ListarDetalleFacturasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvfacturafel
            // 
            this.rvfacturafel.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "detalleFactura";
            reportDataSource1.Value = this.ListarDetalleFacturasBindingSource;
            this.rvfacturafel.LocalReport.DataSources.Add(reportDataSource1);
            this.rvfacturafel.LocalReport.ReportEmbeddedResource = "POS.Recibo.RVprueba.rdlc";
            this.rvfacturafel.Location = new System.Drawing.Point(0, 0);
            this.rvfacturafel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rvfacturafel.Name = "rvfacturafel";
            this.rvfacturafel.ServerReport.BearerToken = null;
            this.rvfacturafel.Size = new System.Drawing.Size(538, 671);
            this.rvfacturafel.TabIndex = 0;
            // 
            // ListarDetalleFacturasBindingSource
            // 
            this.ListarDetalleFacturasBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarDetalleFacturas);
            // 
            // FacturaFEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 671);
            this.Controls.Add(this.rvfacturafel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FacturaFEL";
            this.Text = "FacturaFEL";
            this.Load += new System.EventHandler(this.FacturaFEL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListarDetalleFacturasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvfacturafel;
        private System.Windows.Forms.BindingSource ListarDetalleFacturasBindingSource;
    }
}