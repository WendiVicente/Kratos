namespace Sistema.Forms.modulo_compras
{
    partial class VerCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerCompras));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnnueva = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDetalle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscarSucursal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lbMostrarSucursal = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbtotal = new System.Windows.Forms.ToolStripLabel();
            this.totalventashoyselect = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.listadodeSolicitudes = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadodeSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.toolStrip1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1021, 28);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.btnnueva,
            this.toolStripSeparator4,
            this.btnBorrar,
            this.toolStripSeparator3,
            this.btnDetalle,
            this.toolStripSeparator2,
            this.btnRefrescar,
            this.toolStripSeparator6,
            this.btnBuscarSucursal,
            this.toolStripSeparator7,
            this.toolStripLabel1,
            this.lbMostrarSucursal,
            this.toolStripSeparator8,
            this.tlbtotal,
            this.totalventashoyselect,
            this.toolStripSeparator9});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1021, 27);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "ToolStrip";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // btnnueva
            // 
            this.btnnueva.Image = ((System.Drawing.Image)(resources.GetObject("btnnueva.Image")));
            this.btnnueva.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnnueva.Name = "btnnueva";
            this.btnnueva.Size = new System.Drawing.Size(114, 24);
            this.btnnueva.Text = "Nueva Solicitud";
            this.btnnueva.Click += new System.EventHandler(this.btnnueva_Click);
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
            this.btnBorrar.Size = new System.Drawing.Size(74, 24);
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalle.Image")));
            this.btnDetalle.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(67, 24);
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::Sistema.Properties.Resources.Refresh_16x;
            this.btnRefrescar.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(79, 24);
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // btnBuscarSucursal
            // 
            this.btnBuscarSucursal.Image = global::Sistema.Properties.Resources.Business_16x;
            this.btnBuscarSucursal.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnBuscarSucursal.Name = "btnBuscarSucursal";
            this.btnBuscarSucursal.Size = new System.Drawing.Size(138, 24);
            this.btnBuscarSucursal.Text = "Seleccionar Sucursal";
            this.btnBuscarSucursal.Click += new System.EventHandler(this.btnBuscarSucursal_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(67, 24);
            this.toolStripLabel1.Text = "SUCURSAL:";
            // 
            // lbMostrarSucursal
            // 
            this.lbMostrarSucursal.Name = "lbMostrarSucursal";
            this.lbMostrarSucursal.Size = new System.Drawing.Size(37, 24);
            this.lbMostrarSucursal.Text = "Todas";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // tlbtotal
            // 
            this.tlbtotal.Name = "tlbtotal";
            this.tlbtotal.Size = new System.Drawing.Size(45, 24);
            this.tlbtotal.Text = "TOTAL: ";
            // 
            // totalventashoyselect
            // 
            this.totalventashoyselect.Name = "totalventashoyselect";
            this.totalventashoyselect.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 497);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1021, 60);
            this.kryptonPanel2.TabIndex = 5;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.listadodeSolicitudes);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 28);
            this.kryptonPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(1021, 469);
            this.kryptonPanel3.TabIndex = 5;
            // 
            // listadodeSolicitudes
            // 
            this.listadodeSolicitudes.AllowUserToAddRows = false;
            this.listadodeSolicitudes.AllowUserToDeleteRows = false;
            this.listadodeSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listadodeSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadodeSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listadodeSolicitudes.Location = new System.Drawing.Point(0, 0);
            this.listadodeSolicitudes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listadodeSolicitudes.Name = "listadodeSolicitudes";
            this.listadodeSolicitudes.ReadOnly = true;
            this.listadodeSolicitudes.RowHeadersWidth = 51;
            this.listadodeSolicitudes.RowTemplate.Height = 24;
            this.listadodeSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listadodeSolicitudes.Size = new System.Drawing.Size(1021, 469);
            this.listadodeSolicitudes.TabIndex = 0;
            // 
            // VerCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 557);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "VerCompras";
            this.Text = "Solicitudes de Compras";
            this.Load += new System.EventHandler(this.VerCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listadodeSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView listadodeSolicitudes;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnnueva;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnBorrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDetalle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnBuscarSucursal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ToolStripLabel lbMostrarSucursal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel tlbtotal;
        private System.Windows.Forms.ToolStripLabel totalventashoyselect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    }
}