namespace Sistema.Reports.Reporte_Cotizacion
{
    partial class ReporteCotizacion
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
            this.rvcotizacion = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvcotizacion
            // 
            this.rvcotizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvcotizacion.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Cotizacion.ReporteCotizacion.rdlc";
            this.rvcotizacion.Location = new System.Drawing.Point(0, 0);
            this.rvcotizacion.Name = "rvcotizacion";
            this.rvcotizacion.ServerReport.BearerToken = null;
            this.rvcotizacion.Size = new System.Drawing.Size(717, 680);
            this.rvcotizacion.TabIndex = 0;
            // 
            // ReporteCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 680);
            this.Controls.Add(this.rvcotizacion);
            this.Name = "ReporteCotizacion";
            this.Text = "ReporteCotizacion";
            this.Load += new System.EventHandler(this.ReporteCotizacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvcotizacion;
    }
}