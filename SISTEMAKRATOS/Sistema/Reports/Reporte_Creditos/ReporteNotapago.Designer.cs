namespace Sistema.Reports.Reporte_Creditos
{
    partial class ReporteNotapago
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
            this.rvNotapago = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvNotapago
            // 
            this.rvNotapago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvNotapago.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Creditos.ReporteNotapago.rdlc";
            this.rvNotapago.Location = new System.Drawing.Point(0, 0);
            this.rvNotapago.Name = "rvNotapago";
            this.rvNotapago.ServerReport.BearerToken = null;
            this.rvNotapago.Size = new System.Drawing.Size(632, 568);
            this.rvNotapago.TabIndex = 0;
            // 
            // ReporteNotapago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 568);
            this.Controls.Add(this.rvNotapago);
            this.Name = "ReporteNotapago";
            this.Text = "ReporteNotapago";
            this.Load += new System.EventHandler(this.ReporteNotapago_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvNotapago;
    }
}