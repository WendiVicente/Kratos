namespace Sistema.Forms.modulo_Prestamos
{
    partial class ComprobantePago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprobantePago));
            this.rvcomprobantepago = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvcomprobantepago
            // 
            this.rvcomprobantepago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvcomprobantepago.Location = new System.Drawing.Point(0, 0);
            this.rvcomprobantepago.Name = "rvcomprobantepago";
            this.rvcomprobantepago.ServerReport.BearerToken = null;
            this.rvcomprobantepago.Size = new System.Drawing.Size(559, 700);
            this.rvcomprobantepago.TabIndex = 0;
            // 
            // ComprobantePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 700);
            this.Controls.Add(this.rvcomprobantepago);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComprobantePago";
            this.Text = "ComprobantePago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComprobantePago_FormClosing);
            this.Load += new System.EventHandler(this.ComprobantePago_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvcomprobantepago;
    }
}