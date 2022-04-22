namespace Sistema.Reports.Reports_Personal
{
    partial class ReportePersonal
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
            this.rvpersonal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvpersonal
            // 
            this.rvpersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvpersonal.Location = new System.Drawing.Point(0, 0);
            this.rvpersonal.Name = "rvpersonal";
            this.rvpersonal.ServerReport.BearerToken = null;
            this.rvpersonal.Size = new System.Drawing.Size(800, 450);
            this.rvpersonal.TabIndex = 0;
            // 
            // ReportePersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvpersonal);
            this.Name = "ReportePersonal";
            this.Text = "ReportePersonal";
            this.Load += new System.EventHandler(this.ReportePersonal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvpersonal;
    }
}