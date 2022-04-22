namespace POS.Forms
{
    partial class Descuento
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
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lbproducto = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnAplicar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txttotal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtahorro = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtdescuento = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtsubtotal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtcantidad = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtpreciounit = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonHeaderGroup1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(469, 499);
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
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(469, 499);
            this.kryptonHeaderGroup1.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.lbproducto);
            this.kryptonPanel2.Controls.Add(this.btnAplicar);
            this.kryptonPanel2.Controls.Add(this.txttotal);
            this.kryptonPanel2.Controls.Add(this.txtahorro);
            this.kryptonPanel2.Controls.Add(this.txtdescuento);
            this.kryptonPanel2.Controls.Add(this.txtsubtotal);
            this.kryptonPanel2.Controls.Add(this.txtcantidad);
            this.kryptonPanel2.Controls.Add(this.txtpreciounit);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(467, 446);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // lbproducto
            // 
            this.lbproducto.AutoSize = false;
            this.lbproducto.Location = new System.Drawing.Point(2, 3);
            this.lbproducto.Name = "lbproducto";
            this.lbproducto.Size = new System.Drawing.Size(154, 20);
            this.lbproducto.TabIndex = 13;
            this.lbproducto.Values.Text = "Producto obtenido";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(189, 339);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(104, 32);
            this.btnAplicar.TabIndex = 12;
            this.btnAplicar.Values.Text = "Aplicar";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(165, 280);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(185, 23);
            this.txttotal.TabIndex = 11;
            // 
            // txtahorro
            // 
            this.txtahorro.Location = new System.Drawing.Point(289, 226);
            this.txtahorro.Name = "txtahorro";
            this.txtahorro.ReadOnly = true;
            this.txtahorro.Size = new System.Drawing.Size(61, 23);
            this.txtahorro.TabIndex = 10;
            // 
            // txtdescuento
            // 
            this.txtdescuento.Location = new System.Drawing.Point(165, 226);
            this.txtdescuento.Name = "txtdescuento";
            this.txtdescuento.Size = new System.Drawing.Size(69, 23);
            this.txtdescuento.TabIndex = 9;
            this.txtdescuento.TextChanged += new System.EventHandler(this.txtdescuento_TextChanged);
            this.txtdescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdescuento_KeyPress);
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Location = new System.Drawing.Point(165, 168);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(185, 23);
            this.txtsubtotal.TabIndex = 8;
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(165, 109);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(185, 23);
            this.txtcantidad.TabIndex = 7;
            this.txtcantidad.TextChanged += new System.EventHandler(this.txtcantidad_TextChanged);
            this.txtcantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcantidad_KeyPress);
            // 
            // txtpreciounit
            // 
            this.txtpreciounit.Location = new System.Drawing.Point(165, 47);
            this.txtpreciounit.Name = "txtpreciounit";
            this.txtpreciounit.Size = new System.Drawing.Size(185, 23);
            this.txtpreciounit.TabIndex = 6;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(244, 229);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel6.TabIndex = 5;
            this.kryptonLabel6.Values.Text = "Ahorro";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(65, 283);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel5.TabIndex = 4;
            this.kryptonLabel5.Values.Text = "Total";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(65, 229);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(82, 20);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Porcentaje %";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(65, 171);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Subtotal";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(65, 112);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Cantidad";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(65, 51);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Precio Unitario";
            // 
            // Descuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 499);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "Descuento";
            this.Text = "Descuento";
            this.Load += new System.EventHandler(this.Descuento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAplicar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttotal;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtahorro;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtdescuento;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtsubtotal;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcantidad;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtpreciounit;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbproducto;
    }
}