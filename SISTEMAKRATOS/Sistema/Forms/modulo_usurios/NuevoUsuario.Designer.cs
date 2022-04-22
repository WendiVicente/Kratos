namespace Sistema.Forms.modulo_usurios
{
    partial class NuevoUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoUsuario));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbpermisos = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.correousuario = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.NuevoUser = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.sucursaleslista = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.confirmarcontrasena = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.contrasena = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Nombrestrab = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbpermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursaleslista)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonHeaderGroup1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(525, 352);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanel2);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(525, 352);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Acceso sistema y pos";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.cbpermisos);
            this.kryptonPanel2.Controls.Add(this.correousuario);
            this.kryptonPanel2.Controls.Add(this.NuevoUser);
            this.kryptonPanel2.Controls.Add(this.sucursaleslista);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.confirmarcontrasena);
            this.kryptonPanel2.Controls.Add(this.contrasena);
            this.kryptonPanel2.Controls.Add(this.Nombrestrab);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(523, 299);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(16, 226);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel6.TabIndex = 14;
            this.kryptonLabel6.Values.Text = "Privilegios";
            // 
            // cbpermisos
            // 
            this.cbpermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbpermisos.DropDownWidth = 217;
            this.cbpermisos.Items.AddRange(new object[] {
            "Administrador",
            "Usuario Estandar",
            "Solo Venta",
            "Solo Caja",
            "Solo POS",
            "solo Administracion"});
            this.cbpermisos.Location = new System.Drawing.Point(16, 252);
            this.cbpermisos.Name = "cbpermisos";
            this.cbpermisos.Size = new System.Drawing.Size(217, 21);
            this.cbpermisos.TabIndex = 13;
            // 
            // correousuario
            // 
            this.correousuario.Location = new System.Drawing.Point(11, 42);
            this.correousuario.Name = "correousuario";
            this.correousuario.Size = new System.Drawing.Size(501, 38);
            this.correousuario.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correousuario.TabIndex = 12;
            // 
            // NuevoUser
            // 
            this.NuevoUser.Location = new System.Drawing.Point(422, 252);
            this.NuevoUser.Name = "NuevoUser";
            this.NuevoUser.Size = new System.Drawing.Size(90, 25);
            this.NuevoUser.TabIndex = 11;
            this.NuevoUser.Values.Text = "Guardar";
            this.NuevoUser.Click += new System.EventHandler(this.NuevoUser_Click);
            // 
            // sucursaleslista
            // 
            this.sucursaleslista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sucursaleslista.DropDownWidth = 266;
            this.sucursaleslista.Location = new System.Drawing.Point(246, 123);
            this.sucursaleslista.Name = "sucursaleslista";
            this.sucursaleslista.Size = new System.Drawing.Size(266, 21);
            this.sucursaleslista.TabIndex = 10;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(246, 170);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(130, 20);
            this.kryptonLabel5.TabIndex = 9;
            this.kryptonLabel5.Values.Text = "Confirmar Contraseña";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(11, 170);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Contraseña";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(246, 97);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(111, 20);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Asignar A Sucursal ";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(11, 97);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(141, 20);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Nombres del trabajador";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 16);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Correo";
            // 
            // confirmarcontrasena
            // 
            this.confirmarcontrasena.Location = new System.Drawing.Point(246, 196);
            this.confirmarcontrasena.Name = "confirmarcontrasena";
            this.confirmarcontrasena.Size = new System.Drawing.Size(266, 23);
            this.confirmarcontrasena.TabIndex = 4;
            // 
            // contrasena
            // 
            this.contrasena.Location = new System.Drawing.Point(11, 196);
            this.contrasena.Name = "contrasena";
            this.contrasena.Size = new System.Drawing.Size(213, 23);
            this.contrasena.TabIndex = 3;
            // 
            // Nombrestrab
            // 
            this.Nombrestrab.Location = new System.Drawing.Point(11, 123);
            this.Nombrestrab.Name = "Nombrestrab";
            this.Nombrestrab.Size = new System.Drawing.Size(213, 23);
            this.Nombrestrab.TabIndex = 1;
            // 
            // NuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 352);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NuevoUsuario";
            this.Text = "NuevoUsuario";
            this.Load += new System.EventHandler(this.NuevoUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbpermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursaleslista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton NuevoUser;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox sucursaleslista;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox confirmarcontrasena;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox contrasena;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Nombrestrab;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox correousuario;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbpermisos;
    }
}