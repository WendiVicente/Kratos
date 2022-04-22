namespace Sistema.Forms.modulo_ventas
{
    partial class VentasGenerales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasGenerales));
            this.listventagenerales = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnbuscarVenta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDetalleP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscarSucursal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lbMostrarSucursal = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.listventagenerales)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listventagenerales
            // 
            this.listventagenerales.AllowUserToAddRows = false;
            this.listventagenerales.AllowUserToDeleteRows = false;
            this.listventagenerales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listventagenerales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listventagenerales.Location = new System.Drawing.Point(0, 27);
            this.listventagenerales.Margin = new System.Windows.Forms.Padding(4);
            this.listventagenerales.Name = "listventagenerales";
            this.listventagenerales.ReadOnly = true;
            this.listventagenerales.RowHeadersWidth = 51;
            this.listventagenerales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listventagenerales.Size = new System.Drawing.Size(1039, 550);
            this.listventagenerales.TabIndex = 7;
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.btnbuscarVenta,
            this.toolStripSeparator4,
            this.toolStripSeparator3,
            this.btnDetalleP,
            this.toolStripSeparator1,
            this.btnActualizar,
            this.toolStripSeparator2,
            this.btnBuscarSucursal,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.lbMostrarSucursal});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1039, 27);
            this.toolStrip.TabIndex = 6;
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
            this.btnbuscarVenta.Size = new System.Drawing.Size(80, 24);
            this.btnbuscarVenta.Text = "Buscar ";
            this.btnbuscarVenta.Click += new System.EventHandler(this.btnbuscarVenta_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
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
            this.lbMostrarSucursal.Size = new System.Drawing.Size(17, 24);
            this.lbMostrarSucursal.Text = "0";
            // 
            // VentasGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 577);
            this.Controls.Add(this.listventagenerales);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VentasGenerales";
            this.Text = "VentasGenerales";
            this.Load += new System.EventHandler(this.VentasGenerales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listventagenerales)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView listventagenerales;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnbuscarVenta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDetalleP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBuscarSucursal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ToolStripLabel lbMostrarSucursal;
    }
}