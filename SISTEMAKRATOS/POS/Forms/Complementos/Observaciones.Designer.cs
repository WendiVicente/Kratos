
namespace POS.Forms
{
    partial class Observaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Observaciones));
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pbGuardar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(0, 0);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObservaciones.Size = new System.Drawing.Size(323, 400);
            this.txtObservaciones.TabIndex = 0;
            // 
            // pbGuardar
            // 
            this.pbGuardar.BackColor = System.Drawing.Color.Transparent;
            this.pbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("pbGuardar.Image")));
            this.pbGuardar.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbGuardar.InitialImage")));
            this.pbGuardar.Location = new System.Drawing.Point(243, 330);
            this.pbGuardar.Name = "pbGuardar";
            this.pbGuardar.Size = new System.Drawing.Size(78, 68);
            this.pbGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGuardar.TabIndex = 1;
            this.pbGuardar.TabStop = false;
            this.pbGuardar.Click += new System.EventHandler(this.pbGuardar_Click);
            // 
            // Observaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 400);
            this.Controls.Add(this.pbGuardar);
            this.Controls.Add(this.txtObservaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Observaciones";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Observaciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Observaciones_FormClosing);
            this.Load += new System.EventHandler(this.Observaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.PictureBox pbGuardar;
    }
}