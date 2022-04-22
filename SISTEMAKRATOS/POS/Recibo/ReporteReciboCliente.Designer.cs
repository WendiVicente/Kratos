namespace POS.Recibo
{
    partial class ReporteReciboCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteReciboCliente));
            this.rvporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvporte
            // 
            this.rvporte.LocalReport.ReportEmbeddedResource = "POS.Recibo.ReporteReciboCliente.rdlc";
            this.rvporte.Location = new System.Drawing.Point(2, 1);
            this.rvporte.Name = "rvporte";
            this.rvporte.ServerReport.BearerToken = null;
            this.rvporte.Size = new System.Drawing.Size(398, 608);
            this.rvporte.TabIndex = 0;
            // 
            // ReporteReciboCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 610);
            this.Controls.Add(this.rvporte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteReciboCliente";
            this.Text = "ReporteReciboCliente";
            this.Load += new System.EventHandler(this.ReporteReciboCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvporte;
    }
}