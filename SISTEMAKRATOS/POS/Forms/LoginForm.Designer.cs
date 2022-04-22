namespace POS.Forms
{
    partial class LoginForm
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.checkRemenber = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.contrasenatxt = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.correotxt = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnloggin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.checkRemenber);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.contrasenatxt);
            this.kryptonPanel1.Controls.Add(this.correotxt);
            this.kryptonPanel1.Controls.Add(this.btnloggin);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(357, 388);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // checkRemenber
            // 
            this.checkRemenber.Location = new System.Drawing.Point(106, 299);
            this.checkRemenber.Margin = new System.Windows.Forms.Padding(2);
            this.checkRemenber.Name = "checkRemenber";
            this.checkRemenber.Size = new System.Drawing.Size(117, 20);
            this.checkRemenber.TabIndex = 8;
            this.checkRemenber.Values.Text = "Recordar Usuario";
            this.checkRemenber.CheckedChanged += new System.EventHandler(this.checkRemenber_CheckedChanged);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(23, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.pictureBox1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(313, 150);
            this.kryptonGroupBox1.TabIndex = 7;
            this.kryptonGroupBox1.Values.Heading = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::POS.Properties.Resources.l1;
            this.pictureBox1.Location = new System.Drawing.Point(100, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(139, 168);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(82, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Iniciar Sesión";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(106, 194);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Correo";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(106, 245);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Contraseña";
            // 
            // contrasenatxt
            // 
            this.contrasenatxt.Location = new System.Drawing.Point(106, 271);
            this.contrasenatxt.Name = "contrasenatxt";
            this.contrasenatxt.PasswordChar = '*';
            this.contrasenatxt.Size = new System.Drawing.Size(144, 23);
            this.contrasenatxt.TabIndex = 5;
            this.contrasenatxt.TextChanged += new System.EventHandler(this.contrasenatxt_TextChanged);
            this.contrasenatxt.Enter += new System.EventHandler(this.contrasenatxt_Enter);
            // 
            // correotxt
            // 
            this.correotxt.Location = new System.Drawing.Point(106, 219);
            this.correotxt.Name = "correotxt";
            this.correotxt.Size = new System.Drawing.Size(144, 23);
            this.correotxt.TabIndex = 4;
            // 
            // btnloggin
            // 
            this.btnloggin.Location = new System.Drawing.Point(106, 332);
            this.btnloggin.Name = "btnloggin";
            this.btnloggin.Size = new System.Drawing.Size(144, 25);
            this.btnloggin.TabIndex = 6;
            this.btnloggin.Values.Text = "Entrar";
            this.btnloggin.Click += new System.EventHandler(this.btnloggin_Click);
            this.btnloggin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnloggin_KeyPress);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 388);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox contrasenatxt;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox correotxt;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnloggin;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkRemenber;
    }
}