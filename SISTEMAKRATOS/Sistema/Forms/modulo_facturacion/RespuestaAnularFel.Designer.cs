namespace Sistema.Forms.modulo_facturacion
{
    partial class RespuestaAnularFel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RespuestaAnularFel));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.rvRespuestaSat = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.rvRespuestaSat);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(477, 492);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // rvRespuestaSat
            // 
            this.rvRespuestaSat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvRespuestaSat.LocalReport.ReportEmbeddedResource = "Sistema.Forms.modulo_facturacion.RespuestaAnularFel.rdlc";
            this.rvRespuestaSat.Location = new System.Drawing.Point(0, 0);
            this.rvRespuestaSat.Name = "rvRespuestaSat";
            this.rvRespuestaSat.ServerReport.BearerToken = null;
            this.rvRespuestaSat.Size = new System.Drawing.Size(477, 492);
            this.rvRespuestaSat.TabIndex = 0;
            // 
            // RespuestaAnularFel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 492);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RespuestaAnularFel";
            this.Text = "RespuestaAnularFel";
            this.Load += new System.EventHandler(this.RespuestaAnularFel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer rvRespuestaSat;
    }
}