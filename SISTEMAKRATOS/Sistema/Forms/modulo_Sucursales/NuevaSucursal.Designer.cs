namespace Sistema.Forms.modulo_Sucursales
{
    partial class NuevaSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaSucursal));
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnguardar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtencargado = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txttelefono = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtsucursal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtdireccion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanel1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(546, 547);
            this.kryptonHeaderGroup1.TabIndex = 1;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Nueva Sucursal";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = global::Sistema.Properties.Resources.Business_16x;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Descripción";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnguardar);
            this.kryptonPanel1.Controls.Add(this.txtencargado);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel9);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.txttelefono);
            this.kryptonPanel1.Controls.Add(this.txtsucursal);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel7);
            this.kryptonPanel1.Controls.Add(this.txtdireccion);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(544, 484);
            this.kryptonPanel1.TabIndex = 23;
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(317, 403);
            this.btnguardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(144, 31);
            this.btnguardar.TabIndex = 5;
            this.btnguardar.Values.Text = "Guardar";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtencargado
            // 
            this.txtencargado.Location = new System.Drawing.Point(173, 303);
            this.txtencargado.Margin = new System.Windows.Forms.Padding(4);
            this.txtencargado.Name = "txtencargado";
            this.txtencargado.Size = new System.Drawing.Size(288, 27);
            this.txtencargado.TabIndex = 4;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(27, 238);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(75, 24);
            this.kryptonLabel5.TabIndex = 13;
            this.kryptonLabel5.Values.Text = "Direccion";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(27, 306);
            this.kryptonLabel9.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(84, 24);
            this.kryptonLabel9.TabIndex = 22;
            this.kryptonLabel9.Values.Text = "Encargado";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(27, 71);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(129, 24);
            this.kryptonLabel4.TabIndex = 11;
            this.kryptonLabel4.Values.Text = "Nombre Sucursal";
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(173, 154);
            this.txttelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(288, 27);
            this.txttelefono.TabIndex = 3;
            // 
            // txtsucursal
            // 
            this.txtsucursal.Location = new System.Drawing.Point(173, 68);
            this.txtsucursal.Margin = new System.Windows.Forms.Padding(4);
            this.txtsucursal.Name = "txtsucursal";
            this.txtsucursal.Size = new System.Drawing.Size(288, 27);
            this.txtsucursal.TabIndex = 1;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(27, 157);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(71, 24);
            this.kryptonLabel7.TabIndex = 17;
            this.kryptonLabel7.Values.Text = "Telefono";
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(173, 235);
            this.txtdireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(288, 27);
            this.txtdireccion.TabIndex = 2;
            // 
            // NuevaSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 547);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NuevaSucursal";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnguardar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtencargado;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttelefono;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtdireccion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtsucursal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}