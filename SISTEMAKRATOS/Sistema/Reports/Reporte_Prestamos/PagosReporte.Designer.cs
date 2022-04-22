namespace Sistema.Reports.Reporte_Prestamos
{
    partial class PagosReporte
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
            this.rvpagoreporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvpagoreporte
            // 
            this.rvpagoreporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvpagoreporte.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Prestamos.PagosReporte.rdlc";
            this.rvpagoreporte.Location = new System.Drawing.Point(0, 0);
            this.rvpagoreporte.Name = "rvpagoreporte";
            this.rvpagoreporte.ServerReport.BearerToken = null;
            this.rvpagoreporte.Size = new System.Drawing.Size(511, 746);
            this.rvpagoreporte.TabIndex = 0;
            // 
            // PagosReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 746);
            this.Controls.Add(this.rvpagoreporte);
            this.Name = "PagosReporte";
            this.Text = "PagosReporte";
            this.Load += new System.EventHandler(this.PagosReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvpagoreporte;
    }
}