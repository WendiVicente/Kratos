namespace Sistema.Reports.Reports_Clientes
{
    partial class ReporteClientes
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.rvlistaclientesSelect = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ListarClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListarClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1337, 31);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.rvlistaclientesSelect);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 31);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1337, 547);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 521);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(1337, 57);
            this.kryptonPanel3.TabIndex = 2;
            // 
            // rvlistaclientesSelect
            // 
            this.rvlistaclientesSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "listaclientesseleccionados";
            reportDataSource1.Value = this.ListarClientesBindingSource;
            this.rvlistaclientesSelect.LocalReport.DataSources.Add(reportDataSource1);
            this.rvlistaclientesSelect.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Clientes.ReporteClientes.rdlc";
            this.rvlistaclientesSelect.Location = new System.Drawing.Point(0, 0);
            this.rvlistaclientesSelect.Name = "rvlistaclientesSelect";
            this.rvlistaclientesSelect.ServerReport.BearerToken = null;
            this.rvlistaclientesSelect.Size = new System.Drawing.Size(1337, 547);
            this.rvlistaclientesSelect.TabIndex = 0;
            // 
            // ListarClientesBindingSource
            // 
            this.ListarClientesBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarClientes);
            // 
            // ReporteClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 578);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ReporteClientes";
            this.Text = "ReporteClientes";
            this.Load += new System.EventHandler(this.ReporteClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListarClientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Microsoft.Reporting.WinForms.ReportViewer rvlistaclientesSelect;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private System.Windows.Forms.BindingSource ListarClientesBindingSource;
    }
}