namespace Sistema.Forms.modulo_Prestamos
{
    partial class SolicitudPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolicitudPDF));
            this.rvSolicitudPrestamo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvSolicitudPrestamo
            // 
            this.rvSolicitudPrestamo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvSolicitudPrestamo.LocalReport.ReportEmbeddedResource = "Sistema.Forms.modulo_Prestamos.SolicitudPDF.rdlc";
            this.rvSolicitudPrestamo.Location = new System.Drawing.Point(0, 0);
            this.rvSolicitudPrestamo.Name = "rvSolicitudPrestamo";
            this.rvSolicitudPrestamo.ServerReport.BearerToken = null;
            this.rvSolicitudPrestamo.Size = new System.Drawing.Size(632, 450);
            this.rvSolicitudPrestamo.TabIndex = 0;
            // 
            // SolicitudPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.rvSolicitudPrestamo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SolicitudPDF";
            this.Text = "SolicitudPDF";
            this.Load += new System.EventHandler(this.SolicitudPDF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvSolicitudPrestamo;
    }
}