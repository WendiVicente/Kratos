namespace Sistema.Forms.modulo_Caja
{
    partial class IngresoExtra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoExtra));
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtmontoingreso = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtdescripcion = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnadd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.txtmontoingreso);
            this.kryptonPanel3.Controls.Add(this.txtdescripcion);
            this.kryptonPanel3.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel3.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(499, 256);
            this.kryptonPanel3.TabIndex = 5;
            // 
            // txtmontoingreso
            // 
            this.txtmontoingreso.Location = new System.Drawing.Point(200, 89);
            this.txtmontoingreso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtmontoingreso.Name = "txtmontoingreso";
            this.txtmontoingreso.Size = new System.Drawing.Size(197, 23);
            this.txtmontoingreso.TabIndex = 4;
            this.txtmontoingreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmontoingreso_KeyPress_1);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(200, 162);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(197, 51);
            this.txtdescripcion.TabIndex = 3;
            this.txtdescripcion.Text = "";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(119, 150);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(74, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Descripción";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(77, 91);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(127, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Monto de Ingreso: Q.";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.toolStrip2);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(499, 27);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnadd,
            this.toolStripSeparator4});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(499, 27);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnadd
            // 
            this.btnadd.Image = global::Sistema.Properties.Resources.Add_8x_16x;
            this.btnadd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(112, 24);
            this.btnadd.Text = "Agregar Monto";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 283);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(499, 34);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // IngresoExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 317);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "IngresoExtra";
            this.Text = "IngresoExtra";
            this.Load += new System.EventHandler(this.IngresoExtra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.kryptonPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnadd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtdescripcion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtmontoingreso;
    }
}