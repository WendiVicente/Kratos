
namespace POS.Recibo
{
    partial class ReciboCliente
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
            this.RvFelCarta = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RvFelCarta
            // 
            this.RvFelCarta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RvFelCarta.Location = new System.Drawing.Point(0, 0);
            this.RvFelCarta.Name = "RvFelCarta";
            this.RvFelCarta.ServerReport.BearerToken = null;
            this.RvFelCarta.Size = new System.Drawing.Size(692, 450);
            this.RvFelCarta.TabIndex = 0;
            this.RvFelCarta.Load += new System.EventHandler(this.RvFelCarta_Load);
            // 
            // ReciboCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 450);
            this.Controls.Add(this.RvFelCarta);
            this.Name = "ReciboCliente";
            this.Text = "ReciboCliente";
            this.Load += new System.EventHandler(this.ReciboCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RvFelCarta;
    }
}