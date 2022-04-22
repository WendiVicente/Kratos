namespace Sistema.Forms.modulo_producto
{
    partial class SeleccionProductoColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionProductoColor));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnDetalleP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvProductosColor = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosColor)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDetalleP,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1216, 27);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "ToolStrip";
            // 
            // btnDetalleP
            // 
            this.btnDetalleP.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleP.Image")));
            this.btnDetalleP.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnDetalleP.Name = "btnDetalleP";
            this.btnDetalleP.Size = new System.Drawing.Size(109, 24);
            this.btnDetalleP.Text = "Seleccionar";
            this.btnDetalleP.Click += new System.EventHandler(this.btnDetalleP_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.dgvProductosColor);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1216, 582);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // dgvProductosColor
            // 
            this.dgvProductosColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductosColor.Location = new System.Drawing.Point(0, 0);
            this.dgvProductosColor.Name = "dgvProductosColor";
            this.dgvProductosColor.RowHeadersWidth = 51;
            this.dgvProductosColor.RowTemplate.Height = 24;
            this.dgvProductosColor.Size = new System.Drawing.Size(1216, 582);
            this.dgvProductosColor.TabIndex = 0;
            // 
            // SeleccionProductoColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 609);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeleccionProductoColor";
            this.Text = "AgregarColor";
            this.Load += new System.EventHandler(this.AgregarColor_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnDetalleP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvProductosColor;
    }
}