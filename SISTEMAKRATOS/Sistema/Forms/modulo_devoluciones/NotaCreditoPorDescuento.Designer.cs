namespace Sistema.Forms.modulo_devoluciones
{
    partial class NotaCreditoPorDescuento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotaCreditoPorDescuento));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnaceptar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label3 = new System.Windows.Forms.Label();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtcliente = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtnofactura = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txttotalfactura = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtnodoc = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtdescripcion = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txttotal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtsubtota = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtdesc = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnaceptar);
            this.kryptonPanel1.Controls.Add(this.label3);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel7);
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Controls.Add(this.groupBox2);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(475, 377);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(164, 319);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(114, 28);
            this.btnaceptar.TabIndex = 11;
            this.btnaceptar.Values.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
            this.btnaceptar.Values.Text = "Aceptar";
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(13, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(460, 3);
            this.label3.TabIndex = 10;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel7.Location = new System.Drawing.Point(79, 3);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(284, 29);
            this.kryptonLabel7.TabIndex = 9;
            this.kryptonLabel7.Values.Text = "Nota de Crédito por Descuento";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(460, 3);
            this.label2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(13, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 3);
            this.label1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtcliente);
            this.groupBox2.Controls.Add(this.kryptonLabel10);
            this.groupBox2.Controls.Add(this.txtnofactura);
            this.groupBox2.Controls.Add(this.kryptonLabel8);
            this.groupBox2.Controls.Add(this.txttotalfactura);
            this.groupBox2.Controls.Add(this.kryptonLabel2);
            this.groupBox2.Controls.Add(this.txtnodoc);
            this.groupBox2.Controls.Add(this.kryptonLabel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 99);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // txtcliente
            // 
            this.txtcliente.Location = new System.Drawing.Point(103, 76);
            this.txtcliente.Name = "txtcliente";
            this.txtcliente.ReadOnly = true;
            this.txtcliente.Size = new System.Drawing.Size(163, 23);
            this.txtcliente.TabIndex = 8;
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(6, 73);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel10.TabIndex = 7;
            this.kryptonLabel10.Values.Text = "Cliente";
            // 
            // txtnofactura
            // 
            this.txtnofactura.Location = new System.Drawing.Point(103, 46);
            this.txtnofactura.Name = "txtnofactura";
            this.txtnofactura.ReadOnly = true;
            this.txtnofactura.Size = new System.Drawing.Size(163, 23);
            this.txtnofactura.TabIndex = 6;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(4, 47);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(69, 20);
            this.kryptonLabel8.TabIndex = 5;
            this.kryptonLabel8.Values.Text = "No.Factura";
            // 
            // txttotalfactura
            // 
            this.txttotalfactura.Location = new System.Drawing.Point(340, 60);
            this.txttotalfactura.Name = "txttotalfactura";
            this.txttotalfactura.ReadOnly = true;
            this.txttotalfactura.Size = new System.Drawing.Size(112, 23);
            this.txttotalfactura.TabIndex = 4;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(296, 65);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Total";
            // 
            // txtnodoc
            // 
            this.txtnodoc.Location = new System.Drawing.Point(103, 19);
            this.txtnodoc.Name = "txtnodoc";
            this.txtnodoc.ReadOnly = true;
            this.txtnodoc.Size = new System.Drawing.Size(163, 23);
            this.txtnodoc.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(4, 20);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(97, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "No. Documento";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtdescripcion);
            this.groupBox1.Controls.Add(this.kryptonLabel9);
            this.groupBox1.Controls.Add(this.kryptonLabel6);
            this.groupBox1.Controls.Add(this.txttotal);
            this.groupBox1.Controls.Add(this.txtsubtota);
            this.groupBox1.Controls.Add(this.txtdesc);
            this.groupBox1.Controls.Add(this.kryptonLabel5);
            this.groupBox1.Controls.Add(this.kryptonLabel4);
            this.groupBox1.Controls.Add(this.kryptonLabel3);
            this.groupBox1.Location = new System.Drawing.Point(12, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 160);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(9, 47);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(154, 120);
            this.txtdescripcion.TabIndex = 10;
            this.txtdescripcion.Text = "";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(11, 22);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(74, 20);
            this.kryptonLabel9.TabIndex = 9;
            this.kryptonLabel9.Values.Text = "Descripcion";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(410, 27);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(21, 20);
            this.kryptonLabel6.TabIndex = 8;
            this.kryptonLabel6.Values.Text = "%";
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(296, 118);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(112, 23);
            this.txttotal.TabIndex = 7;
            // 
            // txtsubtota
            // 
            this.txtsubtota.Location = new System.Drawing.Point(296, 74);
            this.txtsubtota.Name = "txtsubtota";
            this.txtsubtota.Size = new System.Drawing.Size(112, 23);
            this.txtsubtota.TabIndex = 6;
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(296, 27);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(112, 23);
            this.txtdesc.TabIndex = 5;
            this.txtdesc.TextChanged += new System.EventHandler(this.txtdesc_TextChanged);
            this.txtdesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdesc_KeyPress);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(182, 121);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel5.TabIndex = 2;
            this.kryptonLabel5.Values.Text = "Total";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(182, 77);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel4.TabIndex = 1;
            this.kryptonLabel4.Values.Text = "Subtotal";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(182, 27);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(68, 20);
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.Values.Text = "Descuento";
            // 
            // NotaCreditoPorDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(475, 377);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotaCreditoPorDescuento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NotaCreditoPorDescuento";
            this.Load += new System.EventHandler(this.NotaCreditoPorDescuento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnaceptar;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttotalfactura;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnodoc;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttotal;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtsubtota;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtdesc;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnofactura;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtdescripcion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcliente;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
    }
}