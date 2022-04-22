namespace Sistema.Reports.Reporte_RRHH
{
    partial class ReporteLlegadasTarde
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
            this.llegadastarde = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // llegadastarde
            // 
            this.llegadastarde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llegadastarde.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_RRHH.ReporteLlegadasTarde.rdlc";
            this.llegadastarde.Location = new System.Drawing.Point(0, 0);
            this.llegadastarde.Name = "llegadastarde";
            this.llegadastarde.ServerReport.BearerToken = null;
            this.llegadastarde.Size = new System.Drawing.Size(800, 450);
            this.llegadastarde.TabIndex = 0;
            // 
            // ReporteLlegadasTarde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.llegadastarde);
            this.Name = "ReporteLlegadasTarde";
            this.Text = "ReporteLlegadasTarde";
            this.Load += new System.EventHandler(this.ReporteLlegadasTarde_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer llegadastarde;
    }
}