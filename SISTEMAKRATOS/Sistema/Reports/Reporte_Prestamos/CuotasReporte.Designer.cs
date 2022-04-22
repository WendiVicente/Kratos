namespace Sistema.Reports.Reporte_Prestamos
{
    partial class CuotasReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuotasReporte));
            this.rvreportecuotas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvreportecuotas
            // 
            this.rvreportecuotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvreportecuotas.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Prestamos.CuotasReporte.rdlc";
            this.rvreportecuotas.Location = new System.Drawing.Point(0, 0);
            this.rvreportecuotas.Name = "rvreportecuotas";
            this.rvreportecuotas.ServerReport.BearerToken = null;
            this.rvreportecuotas.Size = new System.Drawing.Size(482, 617);
            this.rvreportecuotas.TabIndex = 0;
            // 
            // CuotasReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 617);
            this.Controls.Add(this.rvreportecuotas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CuotasReporte";
            this.Text = "CuotasReporte";
            this.Load += new System.EventHandler(this.CuotasReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvreportecuotas;
    }
}