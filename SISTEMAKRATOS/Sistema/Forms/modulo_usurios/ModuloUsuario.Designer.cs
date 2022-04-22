
namespace Sistema.Forms.modulo_usurios
{
    partial class ModuloUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuloUsuario));
            this.toolProductos = new System.Windows.Forms.ToolStrip();
            this.BtnVolver = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.kryptonNavigator2 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.dgvusuarios = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.TslEliminar = new System.Windows.Forms.ToolStrip();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.kryptonPage3 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.LblPrivilegios = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbpermisos = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.correousuario = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnGuadar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.sucursaleslista = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.LblConfContraseña = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblContraseña = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblAgregarSucursal = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblNombTrabajador = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblCorreo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.confirmarcontrasena = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.contrasena = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Nombrestrab = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonHeader5 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.toolProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator2)).BeginInit();
            this.kryptonNavigator2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuarios)).BeginInit();
            this.TslEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
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
            // toolProductos
            // 
            this.toolProductos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolProductos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnVolver,
            this.toolStripSeparator9,
            this.toolStripButton1,
            this.toolStripLabel1});
            this.toolProductos.Location = new System.Drawing.Point(0, 0);
            this.toolProductos.Name = "toolProductos";
            this.toolProductos.Size = new System.Drawing.Size(884, 27);
            this.toolProductos.TabIndex = 6;
            this.toolProductos.Text = "ToolStrip";
            // 
            // BtnVolver
            // 
            this.BtnVolver.Image = ((System.Drawing.Image)(resources.GetObject("BtnVolver.Image")));
            this.BtnVolver.ImageTransparentColor = System.Drawing.Color.Black;
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(24, 24);
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(71, 24);
            this.toolStripLabel1.Text = "Usuarios";
            // 
            // kryptonNavigator2
            // 
            this.kryptonNavigator2.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator2.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator2.Location = new System.Drawing.Point(0, 27);
            this.kryptonNavigator2.Name = "kryptonNavigator2";
            this.kryptonNavigator2.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage3});
            this.kryptonNavigator2.SelectedIndex = 1;
            this.kryptonNavigator2.Size = new System.Drawing.Size(884, 534);
            this.kryptonNavigator2.TabIndex = 7;
            this.kryptonNavigator2.Text = "Gestión";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.dgvusuarios);
            this.kryptonPage1.Controls.Add(this.TslEliminar);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(882, 507);
            this.kryptonPage1.Text = "Listado";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "9EC726F42E4A40A1D38EC449F14E2428";
            // 
            // dgvusuarios
            // 
            this.dgvusuarios.AllowUserToAddRows = false;
            this.dgvusuarios.AllowUserToDeleteRows = false;
            this.dgvusuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvusuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvusuarios.Location = new System.Drawing.Point(0, 25);
            this.dgvusuarios.Name = "dgvusuarios";
            this.dgvusuarios.Size = new System.Drawing.Size(882, 482);
            this.dgvusuarios.TabIndex = 2;
            // 
            // TslEliminar
            // 
            this.TslEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TslEliminar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEliminar});
            this.TslEliminar.Location = new System.Drawing.Point(0, 0);
            this.TslEliminar.Name = "TslEliminar";
            this.TslEliminar.Size = new System.Drawing.Size(882, 25);
            this.TslEliminar.TabIndex = 1;
            this.TslEliminar.Text = "toolStrip1";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(70, 22);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.kryptonHeaderGroup1);
            this.kryptonPage3.Controls.Add(this.kryptonHeader5);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(882, 507);
            this.kryptonPage3.Text = "Gestión";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "DCA0BBFC0E0C45A0F0940C8E1DFB9980";
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 34);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanel2);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(882, 473);
            this.kryptonHeaderGroup1.TabIndex = 38;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Acceso sistema y pos";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.LblPrivilegios);
            this.kryptonPanel2.Controls.Add(this.cbpermisos);
            this.kryptonPanel2.Controls.Add(this.correousuario);
            this.kryptonPanel2.Controls.Add(this.BtnGuadar);
            this.kryptonPanel2.Controls.Add(this.sucursaleslista);
            this.kryptonPanel2.Controls.Add(this.LblConfContraseña);
            this.kryptonPanel2.Controls.Add(this.LblContraseña);
            this.kryptonPanel2.Controls.Add(this.LblAgregarSucursal);
            this.kryptonPanel2.Controls.Add(this.LblNombTrabajador);
            this.kryptonPanel2.Controls.Add(this.LblCorreo);
            this.kryptonPanel2.Controls.Add(this.confirmarcontrasena);
            this.kryptonPanel2.Controls.Add(this.contrasena);
            this.kryptonPanel2.Controls.Add(this.Nombrestrab);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(880, 420);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // LblPrivilegios
            // 
            this.LblPrivilegios.Location = new System.Drawing.Point(16, 226);
            this.LblPrivilegios.Name = "LblPrivilegios";
            this.LblPrivilegios.Size = new System.Drawing.Size(66, 20);
            this.LblPrivilegios.TabIndex = 14;
            this.LblPrivilegios.Values.Text = "Privilegios";
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
            // BtnGuadar
            // 
            this.BtnGuadar.Location = new System.Drawing.Point(333, 247);
            this.BtnGuadar.Name = "BtnGuadar";
            this.BtnGuadar.Size = new System.Drawing.Size(90, 25);
            this.BtnGuadar.TabIndex = 11;
            this.BtnGuadar.Values.Text = "Guardar";
            this.BtnGuadar.Click += new System.EventHandler(this.BtnGuadar_Click);
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
            // LblConfContraseña
            // 
            this.LblConfContraseña.Location = new System.Drawing.Point(246, 170);
            this.LblConfContraseña.Name = "LblConfContraseña";
            this.LblConfContraseña.Size = new System.Drawing.Size(130, 20);
            this.LblConfContraseña.TabIndex = 9;
            this.LblConfContraseña.Values.Text = "Confirmar Contraseña";
            // 
            // LblContraseña
            // 
            this.LblContraseña.Location = new System.Drawing.Point(11, 170);
            this.LblContraseña.Name = "LblContraseña";
            this.LblContraseña.Size = new System.Drawing.Size(72, 20);
            this.LblContraseña.TabIndex = 8;
            this.LblContraseña.Values.Text = "Contraseña";
            // 
            // LblAgregarSucursal
            // 
            this.LblAgregarSucursal.Location = new System.Drawing.Point(246, 97);
            this.LblAgregarSucursal.Name = "LblAgregarSucursal";
            this.LblAgregarSucursal.Size = new System.Drawing.Size(111, 20);
            this.LblAgregarSucursal.TabIndex = 7;
            this.LblAgregarSucursal.Values.Text = "Asignar A Sucursal ";
            // 
            // LblNombTrabajador
            // 
            this.LblNombTrabajador.Location = new System.Drawing.Point(11, 97);
            this.LblNombTrabajador.Name = "LblNombTrabajador";
            this.LblNombTrabajador.Size = new System.Drawing.Size(141, 20);
            this.LblNombTrabajador.TabIndex = 6;
            this.LblNombTrabajador.Values.Text = "Nombres del trabajador";
            // 
            // LblCorreo
            // 
            this.LblCorreo.Location = new System.Drawing.Point(11, 16);
            this.LblCorreo.Name = "LblCorreo";
            this.LblCorreo.Size = new System.Drawing.Size(48, 20);
            this.LblCorreo.TabIndex = 5;
            this.LblCorreo.Values.Text = "Correo";
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
            // kryptonHeader5
            // 
            this.kryptonHeader5.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.kryptonHeader5.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader5.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader5.Name = "kryptonHeader5";
            this.kryptonHeader5.Size = new System.Drawing.Size(882, 34);
            this.kryptonHeader5.TabIndex = 37;
            this.kryptonHeader5.Values.Description = "";
            this.kryptonHeader5.Values.Heading = "Gestión Usuario";
            this.kryptonHeader5.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonHeader5.Values.Image")));
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.UniqueName = "7BB20270B3FB4C85A49069ED1ED01E6B";
            // 
            // ModuloUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.kryptonNavigator2);
            this.Controls.Add(this.toolProductos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModuloUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Red Owl Software";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModuloUsuario_FormClosing);
            this.Load += new System.EventHandler(this.ModuloUsuario_Load);
            this.toolProductos.ResumeLayout(false);
            this.toolProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator2)).EndInit();
            this.kryptonNavigator2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.kryptonPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuarios)).EndInit();
            this.TslEliminar.ResumeLayout(false);
            this.TslEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            this.kryptonPage3.PerformLayout();
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolProductos;
        private System.Windows.Forms.ToolStripButton BtnVolver;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator2;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage3;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader5;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblPrivilegios;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbpermisos;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox correousuario;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnGuadar;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox sucursaleslista;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblConfContraseña;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblContraseña;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAgregarSucursal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblNombTrabajador;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblCorreo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox confirmarcontrasena;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox contrasena;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Nombrestrab;
        private System.Windows.Forms.ToolStrip TslEliminar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvusuarios;
    }
}