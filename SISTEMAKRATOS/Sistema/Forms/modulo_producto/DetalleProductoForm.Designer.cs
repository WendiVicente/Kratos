namespace Sistema.Forms.modulo_producto
{
    partial class DetalleProductoForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleProductoForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DgvDetalle = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.listarDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolDetalle = new System.Windows.Forms.ToolStrip();
            this.BtnVolver = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.LbNombreProd = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAgregar = new System.Windows.Forms.ToolStripButton();
            this.listarDetalleColorTallasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Acciones = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listarDetalleBindingSource)).BeginInit();
            this.toolDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listarDetalleColorTallasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DgvDetalle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolDetalle, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(511, 304);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.AllowUserToDeleteRows = false;
            this.DgvDetalle.AutoGenerateColumns = false;
            this.DgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Acciones,
            this.ProductoId,
            this.Detalle,
            this.Cantidad});
            this.DgvDetalle.DataSource = this.listarDetalleBindingSource;
            this.DgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDetalle.Location = new System.Drawing.Point(3, 28);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.ReadOnly = true;
            this.DgvDetalle.Size = new System.Drawing.Size(505, 273);
            this.DgvDetalle.TabIndex = 8;
            this.DgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellContentClick);
            // 
            // listarDetalleBindingSource
            // 
            this.listarDetalleBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarDetalle);
            // 
            // toolDetalle
            // 
            this.toolDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolDetalle.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolDetalle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnVolver,
            this.toolStripLabel2,
            this.toolStripSeparator8,
            this.LbNombreProd,
            this.toolStripSeparator1,
            this.BtnAgregar});
            this.toolDetalle.Location = new System.Drawing.Point(0, 0);
            this.toolDetalle.Name = "toolDetalle";
            this.toolDetalle.Size = new System.Drawing.Size(511, 25);
            this.toolDetalle.TabIndex = 7;
            this.toolDetalle.Text = "ToolStrip";
            // 
            // BtnVolver
            // 
            this.BtnVolver.Image = global::Sistema.Properties.Resources.volver;
            this.BtnVolver.ImageTransparentColor = System.Drawing.Color.Black;
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(24, 22);
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel2.Text = "DETALLES";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // LbNombreProd
            // 
            this.LbNombreProd.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbNombreProd.Name = "LbNombreProd";
            this.LbNombreProd.Size = new System.Drawing.Size(117, 22);
            this.LbNombreProd.Text = "Nombre del Producto";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::Sistema.Properties.Resources.Add_8x_16x;
            this.BtnAgregar.ImageTransparentColor = System.Drawing.Color.Black;
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(73, 22);
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click_1);
            // 
            // listarDetalleColorTallasBindingSource
            // 
            this.listarDetalleColorTallasBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarDetalleColorTallas);
            // 
            // Acciones
            // 
            this.Acciones.DataPropertyName = "Acciones";
            this.Acciones.HeaderText = "Acciones";
            this.Acciones.Name = "Acciones";
            this.Acciones.ReadOnly = true;
            this.Acciones.Width = 65;
            // 
            // ProductoId
            // 
            this.ProductoId.DataPropertyName = "ProductoId";
            this.ProductoId.HeaderText = "ProductoId";
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.ReadOnly = true;
            this.ProductoId.Width = 95;
            // 
            // Detalle
            // 
            this.Detalle.DataPropertyName = "Detalle";
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Width = 72;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 84;
            // 
            // DetalleProductoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 304);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetalleProductoForm";
            this.Text = "Detalle Productos";
            this.Load += new System.EventHandler(this.DetalleProductoForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listarDetalleBindingSource)).EndInit();
            this.toolDetalle.ResumeLayout(false);
            this.toolDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listarDetalleColorTallasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolDetalle;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.BindingSource listarDetalleBindingSource;
        private System.Windows.Forms.ToolStripButton BtnAgregar;
        private System.Windows.Forms.ToolStripLabel LbNombreProd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnVolver;
        private System.Windows.Forms.BindingSource listarDetalleColorTallasBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Acciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        public ComponentFactory.Krypton.Toolkit.KryptonDataGridView DgvDetalle;
    }
}