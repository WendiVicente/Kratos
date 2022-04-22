namespace Sistema.Forms.modulo_Prestamos
{
    partial class ReporteCuotasbyprestamo
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
            this.rvcuotasbyprestamo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvcuotasbyprestamo
            // 
            this.rvcuotasbyprestamo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvcuotasbyprestamo.LocalReport.ReportEmbeddedResource = "Sistema.Forms.modulo_Prestamos.ReporteCuotasbyPrestamo.rdlc";
            this.rvcuotasbyprestamo.Location = new System.Drawing.Point(0, 0);
            this.rvcuotasbyprestamo.Name = "rvcuotasbyprestamo";
            this.rvcuotasbyprestamo.ServerReport.BearerToken = null;
            this.rvcuotasbyprestamo.Size = new System.Drawing.Size(484, 708);
            this.rvcuotasbyprestamo.TabIndex = 0;
            // 
            // ReporteCuotasbyprestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 708);
            this.Controls.Add(this.rvcuotasbyprestamo);
            this.Name = "ReporteCuotasbyprestamo";
            this.Text = "ReporteCuotasbyprestamo";
            this.Load += new System.EventHandler(this.ReporteCuotasbyprestamo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvcuotasbyprestamo;
    }
}