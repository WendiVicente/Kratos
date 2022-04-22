namespace Sistema.Forms.modulo_Bancos
{
    partial class ValidarTransacciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidarTransacciones));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnpermitir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btndenegar = new System.Windows.Forms.ToolStripButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtsucursal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtcuentadestino = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtcuentaorigen = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtcaja = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txttipomovi = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtestadoactual = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtobservaciones = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtmonto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtfecha = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtnotransac = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtempleado = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnpermitir,
            this.toolStripSeparator1,
            this.btndenegar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(754, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnpermitir
            // 
            this.btnpermitir.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
            this.btnpermitir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnpermitir.Name = "btnpermitir";
            this.btnpermitir.Size = new System.Drawing.Size(84, 24);
            this.btnpermitir.Text = "Permitir";
            this.btnpermitir.Click += new System.EventHandler(this.btnpermitir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btndenegar
            // 
            this.btndenegar.Image = global::Sistema.Properties.Resources.Close_red_16x;
            this.btndenegar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btndenegar.Name = "btndenegar";
            this.btndenegar.Size = new System.Drawing.Size(90, 24);
            this.btndenegar.Text = "Denegar";
            this.btndenegar.Click += new System.EventHandler(this.btndenegar_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.txtsucursal);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel11);
            this.kryptonPanel1.Controls.Add(this.txtcuentadestino);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel10);
            this.kryptonPanel1.Controls.Add(this.txtcuentaorigen);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel9);
            this.kryptonPanel1.Controls.Add(this.txtcaja);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel8);
            this.kryptonPanel1.Controls.Add(this.txttipomovi);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel7);
            this.kryptonPanel1.Controls.Add(this.txtestadoactual);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel1.Controls.Add(this.txtobservaciones);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.txtmonto);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.txtfecha);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.txtnotransac);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.txtempleado);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(754, 559);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // txtsucursal
            // 
            this.txtsucursal.Location = new System.Drawing.Point(159, 47);
            this.txtsucursal.Name = "txtsucursal";
            this.txtsucursal.ReadOnly = true;
            this.txtsucursal.Size = new System.Drawing.Size(151, 27);
            this.txtsucursal.TabIndex = 21;
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Location = new System.Drawing.Point(159, 17);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(68, 24);
            this.kryptonLabel11.TabIndex = 20;
            this.kryptonLabel11.Values.Text = "Sucursal";
            // 
            // txtcuentadestino
            // 
            this.txtcuentadestino.Location = new System.Drawing.Point(452, 344);
            this.txtcuentadestino.Name = "txtcuentadestino";
            this.txtcuentadestino.ReadOnly = true;
            this.txtcuentadestino.Size = new System.Drawing.Size(223, 27);
            this.txtcuentadestino.TabIndex = 19;
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(452, 314);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(120, 24);
            this.kryptonLabel10.TabIndex = 18;
            this.kryptonLabel10.Values.Text = "Cuenta Destino:";
            // 
            // txtcuentaorigen
            // 
            this.txtcuentaorigen.Location = new System.Drawing.Point(452, 270);
            this.txtcuentaorigen.Name = "txtcuentaorigen";
            this.txtcuentaorigen.ReadOnly = true;
            this.txtcuentaorigen.Size = new System.Drawing.Size(223, 27);
            this.txtcuentaorigen.TabIndex = 17;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(452, 240);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(111, 24);
            this.kryptonLabel9.TabIndex = 16;
            this.kryptonLabel9.Values.Text = "Cuenta Origen";
            // 
            // txtcaja
            // 
            this.txtcaja.Location = new System.Drawing.Point(452, 196);
            this.txtcaja.Name = "txtcaja";
            this.txtcaja.ReadOnly = true;
            this.txtcaja.Size = new System.Drawing.Size(223, 27);
            this.txtcaja.TabIndex = 15;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(452, 166);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(44, 24);
            this.kryptonLabel8.TabIndex = 14;
            this.kryptonLabel8.Values.Text = "Caja:";
            // 
            // txttipomovi
            // 
            this.txttipomovi.Location = new System.Drawing.Point(452, 120);
            this.txttipomovi.Name = "txttipomovi";
            this.txttipomovi.ReadOnly = true;
            this.txttipomovi.Size = new System.Drawing.Size(223, 27);
            this.txttipomovi.TabIndex = 13;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(452, 90);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(149, 24);
            this.kryptonLabel7.TabIndex = 12;
            this.kryptonLabel7.Values.Text = "Tipo de Movimiento";
            // 
            // txtestadoactual
            // 
            this.txtestadoactual.Location = new System.Drawing.Point(452, 47);
            this.txtestadoactual.Name = "txtestadoactual";
            this.txtestadoactual.ReadOnly = true;
            this.txtestadoactual.Size = new System.Drawing.Size(223, 27);
            this.txtestadoactual.TabIndex = 11;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(452, 17);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(104, 24);
            this.kryptonLabel6.TabIndex = 10;
            this.kryptonLabel6.Values.Text = "Estado Actual";
            // 
            // txtobservaciones
            // 
            this.txtobservaciones.Location = new System.Drawing.Point(10, 344);
            this.txtobservaciones.Name = "txtobservaciones";
            this.txtobservaciones.ReadOnly = true;
            this.txtobservaciones.Size = new System.Drawing.Size(300, 68);
            this.txtobservaciones.TabIndex = 9;
            this.txtobservaciones.Text = "";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 312);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(114, 24);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "Observaciones:";
            // 
            // txtmonto
            // 
            this.txtmonto.Location = new System.Drawing.Point(12, 270);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.ReadOnly = true;
            this.txtmonto.Size = new System.Drawing.Size(298, 27);
            this.txtmonto.TabIndex = 7;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 240);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(61, 24);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Monto:";
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(12, 196);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.ReadOnly = true;
            this.txtfecha.Size = new System.Drawing.Size(298, 27);
            this.txtfecha.TabIndex = 5;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 166);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(139, 24);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Fecha de Creación:";
            // 
            // txtnotransac
            // 
            this.txtnotransac.Location = new System.Drawing.Point(12, 120);
            this.txtnotransac.Name = "txtnotransac";
            this.txtnotransac.ReadOnly = true;
            this.txtnotransac.Size = new System.Drawing.Size(298, 27);
            this.txtnotransac.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 90);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(123, 24);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "No. Transacción:";
            // 
            // txtempleado
            // 
            this.txtempleado.Location = new System.Drawing.Point(12, 47);
            this.txtempleado.Name = "txtempleado";
            this.txtempleado.ReadOnly = true;
            this.txtempleado.Size = new System.Drawing.Size(139, 27);
            this.txtempleado.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 17);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(90, 24);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Creada por:";
            // 
            // ValidarTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ValidarTransacciones";
            this.Text = "ValidarTransacciones";
            this.Load += new System.EventHandler(this.ValidarTransacciones_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtobservaciones;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtmonto;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtfecha;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnotransac;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtempleado;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttipomovi;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtestadoactual;
        private System.Windows.Forms.ToolStripButton btnpermitir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btndenegar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtsucursal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcuentadestino;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcuentaorigen;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcaja;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
    }
}