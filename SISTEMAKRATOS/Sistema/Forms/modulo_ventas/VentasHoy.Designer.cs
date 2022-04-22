namespace Sistema.Forms.modulo_ventas
{
    partial class VentasHoy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasHoy));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.listventashoy = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnbuscarVenta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDetalleP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscarSucursal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lbMostrarSucursal = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.totalventashoyselect = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listventashoy)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.listventashoy);
            this.kryptonPanel1.Controls.Add(this.toolStrip);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1067, 554);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // listventashoy
            // 
            this.listventashoy.AllowUserToAddRows = false;
            this.listventashoy.AllowUserToDeleteRows = false;
            this.listventashoy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listventashoy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listventashoy.Location = new System.Drawing.Point(0, 27);
            this.listventashoy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listventashoy.Name = "listventashoy";
            this.listventashoy.ReadOnly = true;
            this.listventashoy.RowHeadersWidth = 51;
            this.listventashoy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listventashoy.Size = new System.Drawing.Size(1067, 527);
            this.listventashoy.TabIndex = 5;
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.btnbuscarVenta,
            this.toolStripSeparator4,
            this.btnBorrar,
            this.toolStripSeparator3,
            this.btnDetalleP,
            this.toolStripSeparator1,
            this.btnActualizar,
            this.toolStripSeparator2,
            this.btnBuscarSucursal,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.lbMostrarSucursal,
            this.toolStripSeparator7,
            this.toolStripLabel2,
            this.totalventashoyselect});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1067, 27);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // btnbuscarVenta
            // 
            this.btnbuscarVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnbuscarVenta.Image")));
            this.btnbuscarVenta.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnbuscarVenta.Name = "btnbuscarVenta";
            this.btnbuscarVenta.Size = new System.Drawing.Size(76, 24);
            this.btnbuscarVenta.Text = "Buscar";
            this.btnbuscarVenta.Click += new System.EventHandler(this.btnbuscarVenta_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::Sistema.Properties.Resources._0405_20_delete;
            this.btnBorrar.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(87, 24);
            this.btnBorrar.Text = "Eliminar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnBuscarSucursal
            // 
            this.btnBuscarSucursal.Image = global::Sistema.Properties.Resources.Business_16x;
            this.btnBuscarSucursal.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnBuscarSucursal.Name = "btnBuscarSucursal";
            this.btnBuscarSucursal.Size = new System.Drawing.Size(167, 24);
            this.btnBuscarSucursal.Text = "Seleccionar Sucursal";
            this.btnBuscarSucursal.Click += new System.EventHandler(this.btnBuscarSucursal_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(83, 24);
            this.toolStripLabel1.Text = "SUCURSAL:";
            // 
            // lbMostrarSucursal
            // 
            this.lbMostrarSucursal.Name = "lbMostrarSucursal";
            this.lbMostrarSucursal.Size = new System.Drawing.Size(48, 24);
            this.lbMostrarSucursal.Text = "Todas";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(57, 24);
            this.toolStripLabel2.Text = "TOTAL: ";
            // 
            // totalventashoyselect
            // 
            this.totalventashoyselect.Name = "totalventashoyselect";
            this.totalventashoyselect.Size = new System.Drawing.Size(0, 24);
            // 
            // VentasHoy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VentasHoy";
            this.Text = "VentasHoy";
            this.Load += new System.EventHandler(this.VentasHoy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listventashoy)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnbuscarVenta;
        private System.Windows.Forms.ToolStripButton btnDetalleP;
        private System.Windows.Forms.ToolStripButton btnBuscarSucursal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView listventashoy;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnBorrar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ToolStripLabel lbMostrarSucursal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel totalventashoyselect;
    }
}