namespace Sistema.Reports.Reporte_RRHH
{
    partial class ReporteHorasExtra
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
            this.rvhorasextra = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvhorasextra
            // 
            this.rvhorasextra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvhorasextra.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_RRHH.ReporteHorasExtra.rdlc";
            this.rvhorasextra.Location = new System.Drawing.Point(0, 0);
            this.rvhorasextra.Name = "rvhorasextra";
            this.rvhorasextra.ServerReport.BearerToken = null;
            this.rvhorasextra.Size = new System.Drawing.Size(800, 450);
            this.rvhorasextra.TabIndex = 0;
            // 
            // ReporteHorasExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvhorasextra);
            this.Name = "ReporteHorasExtra";
            this.Text = "ReporteHorasExtra";
            this.Load += new System.EventHandler(this.ReporteHorasExtra_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvhorasextra;
    }
}