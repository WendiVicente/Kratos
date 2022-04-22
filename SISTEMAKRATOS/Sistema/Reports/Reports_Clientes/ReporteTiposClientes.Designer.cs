namespace Sistema.Reports.Reports_Clientes
{
    partial class ReporteTiposClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteTiposClientes));
            this.rvTiposCliente = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvTiposCliente
            // 
            this.rvTiposCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvTiposCliente.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Clientes.ReporteTiposClientes.rdlc";
            this.rvTiposCliente.Location = new System.Drawing.Point(0, 0);
            this.rvTiposCliente.Name = "rvTiposCliente";
            this.rvTiposCliente.ServerReport.BearerToken = null;
            this.rvTiposCliente.Size = new System.Drawing.Size(800, 450);
            this.rvTiposCliente.TabIndex = 0;
            // 
            // ReporteTiposClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvTiposCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteTiposClientes";
            this.Text = "ReporteTiposClientes";
            this.Load += new System.EventHandler(this.ReporteTiposClientes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvTiposCliente;
    }
}