
namespace POS.Forms
{
    partial class DocumentoPOS
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentoPOS));
            this.rvDocumentoPOS = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvDocumentoPOS
            // 
            this.rvDocumentoPOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvDocumentoPOS.LocalReport.ReportEmbeddedResource = "POS.Forms.Complementos.DocumentoPOS.rdlc";
            this.rvDocumentoPOS.Location = new System.Drawing.Point(0, 0);
            this.rvDocumentoPOS.Name = "rvDocumentoPOS";
            this.rvDocumentoPOS.ServerReport.BearerToken = null;
            this.rvDocumentoPOS.Size = new System.Drawing.Size(792, 559);
            this.rvDocumentoPOS.TabIndex = 0;
            // 
            // DocumentoPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 559);
            this.Controls.Add(this.rvDocumentoPOS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DocumentoPOS";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Text = "Documento";
            this.Load += new System.EventHandler(this.DocumentoPOS_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvDocumentoPOS;
    }
}

