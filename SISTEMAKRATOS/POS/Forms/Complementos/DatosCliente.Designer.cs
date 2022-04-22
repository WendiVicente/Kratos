
namespace POS.Forms
{
    partial class DatosCliente
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatosCliente));
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDireccion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNombre = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNit = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pbCancelar = new System.Windows.Forms.PictureBox();
            this.pbAceptar = new System.Windows.Forms.PictureBox();
            this.errorNit = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNombre)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.kryptonLabel3);
            this.panel1.Controls.Add(this.kryptonLabel2);
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Controls.Add(this.txtDireccion);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.txtNit);
            this.panel1.Controls.Add(this.pbCancelar);
            this.panel1.Controls.Add(this.pbAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 273);
            this.panel1.TabIndex = 1;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(93, 43);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel3.Size = new System.Drawing.Size(35, 20);
            this.kryptonLabel3.TabIndex = 55;
            this.kryptonLabel3.Values.Text = "NIT:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(61, 89);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel2.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel2.TabIndex = 54;
            this.kryptonLabel2.Values.Text = "NOMBRE:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(48, 135);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel1.Size = new System.Drawing.Size(80, 20);
            this.kryptonLabel1.TabIndex = 53;
            this.kryptonLabel1.Values.Text = "DIRECCIÓN:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(150, 134);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(278, 52);
            this.txtDireccion.TabIndex = 52;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(150, 88);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(278, 23);
            this.txtNombre.TabIndex = 51;
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(150, 43);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(278, 23);
            this.txtNit.TabIndex = 50;
            this.txtNit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNit_KeyPress);
            // 
            // pbCancelar
            // 
            this.pbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("pbCancelar.Image")));
            this.pbCancelar.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbCancelar.InitialImage")));
            this.pbCancelar.Location = new System.Drawing.Point(340, 204);
            this.pbCancelar.Name = "pbCancelar";
            this.pbCancelar.Size = new System.Drawing.Size(48, 38);
            this.pbCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCancelar.TabIndex = 46;
            this.pbCancelar.TabStop = false;
            this.pbCancelar.Click += new System.EventHandler(this.pbCancelar_Click);
            // 
            // pbAceptar
            // 
            this.pbAceptar.Image = ((System.Drawing.Image)(resources.GetObject("pbAceptar.Image")));
            this.pbAceptar.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbAceptar.InitialImage")));
            this.pbAceptar.Location = new System.Drawing.Point(182, 204);
            this.pbAceptar.Name = "pbAceptar";
            this.pbAceptar.Size = new System.Drawing.Size(39, 38);
            this.pbAceptar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAceptar.TabIndex = 45;
            this.pbAceptar.TabStop = false;
            this.pbAceptar.Click += new System.EventHandler(this.pbAceptar_Click);
            // 
            // errorNit
            // 
            this.errorNit.ContainerControl = this;
            // 
            // errorNombre
            // 
            this.errorNombre.ContainerControl = this;
            // 
            // DatosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 273);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatosCliente";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATOS CLIENTE";
            this.Load += new System.EventHandler(this.DatosCliente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNombre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDireccion;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNombre;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNit;
        private System.Windows.Forms.PictureBox pbCancelar;
        private System.Windows.Forms.PictureBox pbAceptar;
        private System.Windows.Forms.ErrorProvider errorNit;
        private System.Windows.Forms.ErrorProvider errorNombre;
    }
}