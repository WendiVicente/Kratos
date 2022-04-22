namespace POS.Recibo
{
    partial class ComprobanteVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprobanteVenta));
            this.rvComprobante = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvComprobante
            // 
            this.rvComprobante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvComprobante.LocalReport.ReportEmbeddedResource = "POS.Recibo.ComprobanteTalonario.rdlc";
            this.rvComprobante.Location = new System.Drawing.Point(0, 0);
            this.rvComprobante.Name = "rvComprobante";
            this.rvComprobante.ServerReport.BearerToken = null;
            this.rvComprobante.Size = new System.Drawing.Size(591, 584);
            this.rvComprobante.TabIndex = 0;
            // 
            // ComprobanteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 584);
            this.Controls.Add(this.rvComprobante);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComprobanteVenta";
            this.Text = "ComprobanteVenta";
            this.Load += new System.EventHandler(this.ComprobanteVenta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvComprobante;
    }
}