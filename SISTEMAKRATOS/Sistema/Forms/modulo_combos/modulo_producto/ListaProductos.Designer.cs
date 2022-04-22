namespace Sistema.Forms.modulo_producto
{
    partial class ListaProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaProductos));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.listproductos = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buscarprod = new System.Windows.Forms.ToolStripButton();
            this.btnBorrar = new System.Windows.Forms.ToolStripButton();
            this.btnDetalleP = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReportes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listproductos)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.listproductos);
            this.kryptonPanel1.Controls.Add(this.toolStrip);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1509, 689);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // listproductos
            // 
            this.listproductos.AllowUserToAddRows = false;
            this.listproductos.AllowUserToDeleteRows = false;
            this.listproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listproductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listproductos.Location = new System.Drawing.Point(0, 27);
            this.listproductos.Margin = new System.Windows.Forms.Padding(4);
            this.listproductos.Name = "listproductos";
            this.listproductos.ReadOnly = true;
            this.listproductos.RowHeadersWidth = 51;
            this.listproductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listproductos.Size = new System.Drawing.Size(1509, 662);
            this.listproductos.TabIndex = 4;
            this.listproductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listproductos_CellContentClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarprod,
            this.btnBorrar,
            this.btnDetalleP,
            this.btnActualizar,
            this.toolStripSeparator1,
            this.btnReportes,
            this.toolStripSeparator2});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1509, 27);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "ToolStrip";
            // 
            // buscarprod
            // 
            this.buscarprod.Image = ((System.Drawing.Image)(resources.GetObject("buscarprod.Image")));
            this.buscarprod.ImageTransparentColor = System.Drawing.Color.Black;
            this.buscarprod.Name = "buscarprod";
            this.buscarprod.Size = new System.Drawing.Size(76, 24);
            this.buscarprod.Text = "Buscar";
            this.buscarprod.Click += new System.EventHandler(this.buscarprod_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::Sistema.Properties.Resources._0405_20_delete;
            this.btnBorrar.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(87, 24);
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnDetalleP
            // 
            this.btnDetalleP.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleP.Image")));
            this.btnDetalleP.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnDetalleP.Name = "btnDetalleP";
            this.btnDetalleP.Size = new System.Drawing.Size(81, 24);
            this.btnDetalleP.Text = "Detalle";
            this.btnDetalleP.Click += new System.EventHandler(this.btnDetalleP_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::Sistema.Properties.Resources.Refresh_16x;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(94, 24);
            this.btnActualizar.Text = "Refrescar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnReportes
            // 
            this.btnReportes.Image = global::Sistema.Properties.Resources.HistoryTable_16x;
            this.btnReportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(92, 24);
            this.btnReportes.Text = "Reportes";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // ListaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 689);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListaProductos";
            this.Text = "ListaProductos";
            this.Load += new System.EventHandler(this.ListaProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listproductos)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buscarprod;
        private System.Windows.Forms.ToolStripButton btnBorrar;
        private System.Windows.Forms.ToolStripButton btnDetalleP;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView listproductos;
        private System.Windows.Forms.ToolStripButton btnReportes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}