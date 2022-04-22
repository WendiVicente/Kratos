namespace Sistema.Forms.modulo_devoluciones
{
    partial class NotaCreditoFEL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotaCreditoFEL));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtmotivo = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnaceptar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvdetalleFactura = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdireccion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtnombres = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtnit = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtfechaemision = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtnoAutorizacion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtnofactura = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetalleFactura)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.groupBox3);
            this.kryptonPanel1.Controls.Add(this.btnaceptar);
            this.kryptonPanel1.Controls.Add(this.groupBox2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(507, 458);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtmotivo);
            this.groupBox3.Controls.Add(this.kryptonLabel5);
            this.groupBox3.Location = new System.Drawing.Point(10, 162);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(475, 85);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Complemento";
            // 
            // txtmotivo
            // 
            this.txtmotivo.Location = new System.Drawing.Point(114, 15);
            this.txtmotivo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtmotivo.Name = "txtmotivo";
            this.txtmotivo.Size = new System.Drawing.Size(346, 45);
            this.txtmotivo.TabIndex = 2;
            this.txtmotivo.Text = "";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(11, 28);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(105, 20);
            this.kryptonLabel5.TabIndex = 1;
            this.kryptonLabel5.Values.Text = "Motivo del ajuste";
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(179, 411);
            this.btnaceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(126, 26);
            this.btnaceptar.TabIndex = 3;
            this.btnaceptar.Values.Text = "Aceptar";
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvdetalleFactura);
            this.groupBox2.Location = new System.Drawing.Point(9, 261);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(476, 145);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dgvdetalleFactura
            // 
            this.dgvdetalleFactura.AllowUserToAddRows = false;
            this.dgvdetalleFactura.AllowUserToDeleteRows = false;
            this.dgvdetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdetalleFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdetalleFactura.Location = new System.Drawing.Point(2, 15);
            this.dgvdetalleFactura.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvdetalleFactura.Name = "dgvdetalleFactura";
            this.dgvdetalleFactura.ReadOnly = true;
            this.dgvdetalleFactura.RowTemplate.Height = 24;
            this.dgvdetalleFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdetalleFactura.Size = new System.Drawing.Size(472, 128);
            this.dgvdetalleFactura.TabIndex = 0;
            this.dgvdetalleFactura.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdetalleFactura_CellClick);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(188, 10);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(186, 29);
            this.kryptonLabel4.TabIndex = 1;
            this.kryptonLabel4.Values.Text = "Nota de Credito FEL";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtdireccion);
            this.groupBox1.Controls.Add(this.txtnombres);
            this.groupBox1.Controls.Add(this.txtnit);
            this.groupBox1.Controls.Add(this.kryptonLabel9);
            this.groupBox1.Controls.Add(this.kryptonLabel8);
            this.groupBox1.Controls.Add(this.kryptonLabel7);
            this.groupBox1.Controls.Add(this.kryptonLabel6);
            this.groupBox1.Controls.Add(this.txtfechaemision);
            this.groupBox1.Controls.Add(this.txtnoAutorizacion);
            this.groupBox1.Controls.Add(this.txtnofactura);
            this.groupBox1.Controls.Add(this.kryptonLabel3);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Location = new System.Drawing.Point(9, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(476, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(256, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 84);
            this.label1.TabIndex = 13;
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(330, 80);
            this.txtdireccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(142, 23);
            this.txtdireccion.TabIndex = 12;
            // 
            // txtnombres
            // 
            this.txtnombres.Location = new System.Drawing.Point(330, 52);
            this.txtnombres.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtnombres.Name = "txtnombres";
            this.txtnombres.Size = new System.Drawing.Size(142, 23);
            this.txtnombres.TabIndex = 11;
            // 
            // txtnit
            // 
            this.txtnit.Location = new System.Drawing.Point(330, 28);
            this.txtnit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtnit.Name = "txtnit";
            this.txtnit.Size = new System.Drawing.Size(142, 23);
            this.txtnit.TabIndex = 10;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(283, 82);
            this.kryptonLabel9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(62, 20);
            this.kryptonLabel9.TabIndex = 9;
            this.kryptonLabel9.Values.Text = "Direccion";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(283, 56);
            this.kryptonLabel8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel8.TabIndex = 8;
            this.kryptonLabel8.Values.Text = "Nombres";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(283, 28);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(30, 20);
            this.kryptonLabel7.TabIndex = 7;
            this.kryptonLabel7.Values.Text = "NIT";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(266, 7);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(51, 20);
            this.kryptonLabel6.TabIndex = 6;
            this.kryptonLabel6.Values.Text = "Cliente";
            // 
            // txtfechaemision
            // 
            this.txtfechaemision.Location = new System.Drawing.Point(95, 80);
            this.txtfechaemision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtfechaemision.Name = "txtfechaemision";
            this.txtfechaemision.Size = new System.Drawing.Size(146, 23);
            this.txtfechaemision.TabIndex = 5;
            // 
            // txtnoAutorizacion
            // 
            this.txtnoAutorizacion.Location = new System.Drawing.Point(95, 54);
            this.txtnoAutorizacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtnoAutorizacion.Name = "txtnoAutorizacion";
            this.txtnoAutorizacion.Size = new System.Drawing.Size(146, 23);
            this.txtnoAutorizacion.TabIndex = 4;
            // 
            // txtnofactura
            // 
            this.txtnofactura.Location = new System.Drawing.Point(95, 23);
            this.txtnofactura.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtnofactura.Name = "txtnofactura";
            this.txtnofactura.Size = new System.Drawing.Size(146, 23);
            this.txtnofactura.TabIndex = 3;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 82);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Fecha Emision";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 54);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "No. Autorizacion";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 26);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(71, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "No. factura";
            // 
            // NotaCreditoFEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 458);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NotaCreditoFEL";
            this.Text = "NotaCreditoFEL";
            this.Load += new System.EventHandler(this.NotaCreditoFEL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetalleFactura)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtmotivo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnaceptar;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvdetalleFactura;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtdireccion;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnombres;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnit;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtfechaemision;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnoAutorizacion;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnofactura;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}