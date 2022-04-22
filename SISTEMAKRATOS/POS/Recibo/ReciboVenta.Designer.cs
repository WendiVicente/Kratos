namespace POS.Recibo
{
    partial class ReciboVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReciboVenta));
            this.rvRecibo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvRecibo
            // 
            this.rvRecibo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvRecibo.LocalReport.ReportEmbeddedResource = "POS.Recibo.ReciboVenta.rdlc";
            this.rvRecibo.Location = new System.Drawing.Point(0, 0);
            this.rvRecibo.Name = "rvRecibo";
            this.rvRecibo.ServerReport.BearerToken = null;
            this.rvRecibo.Size = new System.Drawing.Size(824, 948);
            this.rvRecibo.TabIndex = 0;
            // 
            // ReciboVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 948);
            this.Controls.Add(this.rvRecibo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReciboVenta";
            this.Text = "ReciboVenta";
            this.Load += new System.EventHandler(this.ReciboVenta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvRecibo;
    }
}