namespace Sistema.Reports.Reporte_Creditos
{
    partial class TalonariosReporte
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
            this.rvtalonarios = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvtalonarios
            // 
            this.rvtalonarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvtalonarios.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Creditos.TalonariosReporte.rdlc";
            this.rvtalonarios.Location = new System.Drawing.Point(0, 0);
            this.rvtalonarios.Name = "rvtalonarios";
            this.rvtalonarios.ServerReport.BearerToken = null;
            this.rvtalonarios.Size = new System.Drawing.Size(689, 642);
            this.rvtalonarios.TabIndex = 0;
            // 
            // TalonariosReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 642);
            this.Controls.Add(this.rvtalonarios);
            this.Name = "TalonariosReporte";
            this.Text = "Talonarios";
            this.Load += new System.EventHandler(this.TalonariosReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvtalonarios;
    }
}