
namespace POS.Forms
{
    partial class IngresoToken
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoToken));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbCancelar = new System.Windows.Forms.PictureBox();
            this.pbAceptar = new System.Windows.Forms.PictureBox();
            this.txtToken = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAceptar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.pbCancelar);
            this.panel1.Controls.Add(this.pbAceptar);
            this.panel1.Controls.Add(this.txtToken);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 178);
            this.panel1.TabIndex = 0;
            // 
            // pbCancelar
            // 
            this.pbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("pbCancelar.Image")));
            this.pbCancelar.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbCancelar.InitialImage")));
            this.pbCancelar.Location = new System.Drawing.Point(284, 92);
            this.pbCancelar.Name = "pbCancelar";
            this.pbCancelar.Size = new System.Drawing.Size(73, 50);
            this.pbCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCancelar.TabIndex = 46;
            this.pbCancelar.TabStop = false;
            this.pbCancelar.Click += new System.EventHandler(this.pbCancelar_Click);
            // 
            // pbAceptar
            // 
            this.pbAceptar.Image = ((System.Drawing.Image)(resources.GetObject("pbAceptar.Image")));
            this.pbAceptar.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbAceptar.InitialImage")));
            this.pbAceptar.Location = new System.Drawing.Point(94, 92);
            this.pbAceptar.Name = "pbAceptar";
            this.pbAceptar.Size = new System.Drawing.Size(67, 50);
            this.pbAceptar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAceptar.TabIndex = 45;
            this.pbAceptar.TabStop = false;
            this.pbAceptar.Click += new System.EventHandler(this.pbAceptar_Click);
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(38, 32);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(380, 43);
            this.txtToken.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToken.TabIndex = 44;
            this.txtToken.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IngresoToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(462, 178);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IngresoToken";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INGRESO DE TOKEN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IngresoToken_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAceptar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbCancelar;
        private System.Windows.Forms.PictureBox pbAceptar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtToken;
    }
}