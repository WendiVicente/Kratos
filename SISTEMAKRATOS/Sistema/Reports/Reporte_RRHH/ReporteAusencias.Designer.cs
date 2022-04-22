namespace Sistema.Reports.Reporte_RRHH
{
    partial class ReporteAusencias
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
            this.rvAusencias = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvAusencias
            // 
            this.rvAusencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvAusencias.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_RRHH.ReporteAusencias.rdlc";
            this.rvAusencias.Location = new System.Drawing.Point(0, 0);
            this.rvAusencias.Name = "rvAusencias";
            this.rvAusencias.ServerReport.BearerToken = null;
            this.rvAusencias.Size = new System.Drawing.Size(800, 450);
            this.rvAusencias.TabIndex = 0;
            // 
            // ReporteAusencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvAusencias);
            this.Name = "ReporteAusencias";
            this.Text = "ReporteAusencias";
            this.Load += new System.EventHandler(this.ReporteAusencias_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvAusencias;
    }
}