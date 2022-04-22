namespace Sistema.Reports.Reports_Caja
{
    partial class ReporteCajaAbierta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCajaAbierta));
            this.ListarCajaDetallesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnsucursal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cajareporte = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ListarCajaDetallesBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListarCajaDetallesBindingSource
            // 
            this.ListarCajaDetallesBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarCajaDetalles);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 30);
            this.panel2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnsucursal,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnsucursal
            // 
            this.btnsucursal.Image = global::Sistema.Properties.Resources.Business_16x;
            this.btnsucursal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsucursal.Name = "btnsucursal";
            this.btnsucursal.Size = new System.Drawing.Size(134, 24);
            this.btnsucursal.Text = "Buscar Sucursal";
            this.btnsucursal.Click += new System.EventHandler(this.btnsucursal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.reportViewer1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 30);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 420);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CajaActual";
            reportDataSource1.Value = this.ListarCajaDetallesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Caja.CajaAbiertas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 420);
            this.reportViewer1.TabIndex = 0;
            // 
            // cajareporte
            // 
            this.cajareporte.Location = new System.Drawing.Point(0, 0);
            this.cajareporte.Name = "cajareporte";
            this.cajareporte.ServerReport.BearerToken = null;
            this.cajareporte.Size = new System.Drawing.Size(396, 246);
            this.cajareporte.TabIndex = 0;
            // 
            // ReporteCajaAbierta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteCajaAbierta";
            this.Text = "ReporteCajaAbierta";
            this.Load += new System.EventHandler(this.ReporteCajaAbierta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListarCajaDetallesBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnsucursal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer cajareporte;
        private System.Windows.Forms.BindingSource ListarCajaDetallesBindingSource;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}