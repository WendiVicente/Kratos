namespace Sistema.Reports.Reporte_Facturacion
{
    partial class ReporteFactura
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
            this.rvFactura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvFactura
            // 
            this.rvFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvFactura.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Facturacion.ReporteFactura.rdlc";
            this.rvFactura.Location = new System.Drawing.Point(0, 0);
            this.rvFactura.Name = "rvFactura";
            this.rvFactura.ServerReport.BearerToken = null;
            this.rvFactura.Size = new System.Drawing.Size(537, 610);
            this.rvFactura.TabIndex = 0;
            // 
            // ReporteFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 610);
            this.Controls.Add(this.rvFactura);
            this.Name = "ReporteFactura";
            this.Text = "ReporteFactura";
            this.Load += new System.EventHandler(this.ReporteFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvFactura;
    }
}