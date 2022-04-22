namespace Sistema.Reports.Reports_Proveedores
{
    partial class ReporteProveedoresGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteProveedoresGeneral));
            this.rvProveedores = new Microsoft.Reporting.WinForms.ReportViewer();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.ListarProveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListarProveedoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvProveedores
            // 
            this.rvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "listageneralproveedores";
            reportDataSource1.Value = this.ListarProveedoresBindingSource;
            this.rvProveedores.LocalReport.DataSources.Add(reportDataSource1);
            this.rvProveedores.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Proveedores.ReporteProveedoresGeneral.rdlc";
            this.rvProveedores.Location = new System.Drawing.Point(0, 0);
            this.rvProveedores.Name = "rvProveedores";
            this.rvProveedores.ServerReport.BearerToken = null;
            this.rvProveedores.Size = new System.Drawing.Size(800, 450);
            this.rvProveedores.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.rvProveedores);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // ListarProveedoresBindingSource
            // 
            this.ListarProveedoresBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarProveedores);
            // 
            // ReporteProveedoresGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteProveedoresGeneral";
            this.Text = "ReporteProveedoresGeneral";
            this.Load += new System.EventHandler(this.ReporteProveedoresGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListarProveedoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvProveedores;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.BindingSource ListarProveedoresBindingSource;
    }
}