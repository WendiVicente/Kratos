namespace Sistema.Forms.modulo_devoluciones
{
    partial class Confirmar
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
            this.txtmontosalida = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtcajaActiva = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.rbpagocaja = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbfuturascompras = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.lbtotalfactura = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnaceptar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.txtmontosalida);
            this.kryptonPanel1.Controls.Add(this.txtcajaActiva);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.rbpagocaja);
            this.kryptonPanel1.Controls.Add(this.rbfuturascompras);
            this.kryptonPanel1.Controls.Add(this.lbtotalfactura);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.btnaceptar);
            this.kryptonPanel1.Controls.Add(this.label4);
            this.kryptonPanel1.Controls.Add(this.label3);
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(334, 358);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // txtmontosalida
            // 
            this.txtmontosalida.Location = new System.Drawing.Point(101, 245);
            this.txtmontosalida.Name = "txtmontosalida";
            this.txtmontosalida.Size = new System.Drawing.Size(111, 23);
            this.txtmontosalida.TabIndex = 12;
            // 
            // txtcajaActiva
            // 
            this.txtcajaActiva.Location = new System.Drawing.Point(101, 216);
            this.txtcajaActiva.Name = "txtcajaActiva";
            this.txtcajaActiva.Size = new System.Drawing.Size(111, 23);
            this.txtcajaActiva.TabIndex = 11;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(25, 250);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(58, 20);
            this.kryptonLabel4.TabIndex = 10;
            this.kryptonLabel4.Values.Text = "Salida Q:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(25, 216);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel3.TabIndex = 9;
            this.kryptonLabel3.Values.Text = "Caja Activa:";
            // 
            // rbpagocaja
            // 
            this.rbpagocaja.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbpagocaja.Location = new System.Drawing.Point(31, 145);
            this.rbpagocaja.Name = "rbpagocaja";
            this.rbpagocaja.Size = new System.Drawing.Size(98, 20);
            this.rbpagocaja.TabIndex = 8;
            this.rbpagocaja.Values.Text = "Pago de Caja";
            // 
            // rbfuturascompras
            // 
            this.rbfuturascompras.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbfuturascompras.Location = new System.Drawing.Point(22, 84);
            this.rbfuturascompras.Name = "rbfuturascompras";
            this.rbfuturascompras.Size = new System.Drawing.Size(272, 20);
            this.rbfuturascompras.TabIndex = 7;
            this.rbfuturascompras.Values.Text = "Usar Nota de Crédito para futuras compras";
            // 
            // lbtotalfactura
            // 
            this.lbtotalfactura.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lbtotalfactura.Location = new System.Drawing.Point(123, 42);
            this.lbtotalfactura.Name = "lbtotalfactura";
            this.lbtotalfactura.Size = new System.Drawing.Size(48, 20);
            this.lbtotalfactura.TabIndex = 6;
            this.lbtotalfactura.Values.Text = "Q.0.00";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = false;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(37, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(285, 33);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Total de la Nota de Crédito";
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(61, 294);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(196, 40);
            this.btnaceptar.TabIndex = 4;
            this.btnaceptar.Values.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
            this.btnaceptar.Values.Text = "Aceptar";
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(25, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 3);
            this.label4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(25, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 3);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(25, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 3);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 3);
            this.label1.TabIndex = 0;
            // 
            // Confirmar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 358);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "Confirmar";
            this.Text = "Confirmar";
            this.Load += new System.EventHandler(this.Confirmar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbpagocaja;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbfuturascompras;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbtotalfactura;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnaceptar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtmontosalida;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcajaActiva;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    }
}