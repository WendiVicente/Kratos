namespace Sistema.Forms.modulo_compras
{
    partial class SolicitudCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolicitudCompra));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnguardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConfirmarPed = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnagregarproducto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCantidad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbuscar = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbsolicitud = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpEntrega = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtcomprobante = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbproveedor = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ListaProductSelect = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbimpuesto = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbsubt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbtotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Codbarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseImponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idprod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbproveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaProductSelect)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnguardar,
            this.toolStripSeparator1,
            this.btnConfirmarPed,
            this.toolStripSeparator2,
            this.btnagregarproducto,
            this.toolStripSeparator4,
            this.btnCantidad,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(964, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnguardar
            // 
            this.btnguardar.Image = global::Sistema.Properties.Resources.SaveStatusBar1_16x;
            this.btnguardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(73, 24);
            this.btnguardar.Text = "Guardar";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnConfirmarPed
            // 
            this.btnConfirmarPed.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
            this.btnConfirmarPed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirmarPed.Name = "btnConfirmarPed";
            this.btnConfirmarPed.Size = new System.Drawing.Size(125, 24);
            this.btnConfirmarPed.Text = "Confirmar Pedido";
            this.btnConfirmarPed.Click += new System.EventHandler(this.btnConfirmarPed_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnagregarproducto
            // 
            this.btnagregarproducto.Image = global::Sistema.Properties.Resources.Add_8x_16x;
            this.btnagregarproducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnagregarproducto.Name = "btnagregarproducto";
            this.btnagregarproducto.Size = new System.Drawing.Size(130, 24);
            this.btnagregarproducto.Text = "Agregar Productos";
            this.btnagregarproducto.Click += new System.EventHandler(this.btnagregarproducto_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btnCantidad
            // 
            this.btnCantidad.Image = global::Sistema.Properties.Resources.Add_8x_16x;
            this.btnCantidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCantidad.Name = "btnCantidad";
            this.btnCantidad.Size = new System.Drawing.Size(139, 24);
            this.btnCantidad.Text = "Cambiar la Cantidad";
            this.btnCantidad.Click += new System.EventHandler(this.btnCantidad_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtbuscar);
            this.panel1.Controls.Add(this.kryptonLabel5);
            this.panel1.Controls.Add(this.lbsolicitud);
            this.panel1.Controls.Add(this.dtpEntrega);
            this.panel1.Controls.Add(this.kryptonLabel4);
            this.panel1.Controls.Add(this.kryptonLabel3);
            this.panel1.Controls.Add(this.txtcomprobante);
            this.panel1.Controls.Add(this.kryptonLabel2);
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Controls.Add(this.cbproveedor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 228);
            this.panel1.TabIndex = 3;
            // 
            // txtbuscar
            // 
            this.txtbuscar.Location = new System.Drawing.Point(86, 186);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(703, 23);
            this.txtbuscar.TabIndex = 28;
            this.txtbuscar.Enter += new System.EventHandler(this.txtbuscar_Enter);
            this.txtbuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbuscar_KeyUp);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(24, 186);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel5.TabIndex = 27;
            this.kryptonLabel5.Values.Text = "Buscar ";
            // 
            // lbsolicitud
            // 
            this.lbsolicitud.Location = new System.Drawing.Point(680, 32);
            this.lbsolicitud.Margin = new System.Windows.Forms.Padding(2);
            this.lbsolicitud.Name = "lbsolicitud";
            this.lbsolicitud.Size = new System.Drawing.Size(92, 20);
            this.lbsolicitud.TabIndex = 26;
            this.lbsolicitud.Values.Text = "DD/MM/YY-YY";
            // 
            // dtpEntrega
            // 
            this.dtpEntrega.Location = new System.Drawing.Point(637, 129);
            this.dtpEntrega.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEntrega.Name = "dtpEntrega";
            this.dtpEntrega.Size = new System.Drawing.Size(204, 21);
            this.dtpEntrega.TabIndex = 25;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(458, 22);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(109, 20);
            this.kryptonLabel4.TabIndex = 24;
            this.kryptonLabel4.Values.Text = "Fecha de Solicitud";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(458, 105);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(95, 20);
            this.kryptonLabel3.TabIndex = 23;
            this.kryptonLabel3.Values.Text = "Fecha Estimada";
            // 
            // txtcomprobante
            // 
            this.txtcomprobante.Location = new System.Drawing.Point(24, 41);
            this.txtcomprobante.Margin = new System.Windows.Forms.Padding(2);
            this.txtcomprobante.Name = "txtcomprobante";
            this.txtcomprobante.Size = new System.Drawing.Size(271, 23);
            this.txtcomprobante.TabIndex = 22;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(24, 105);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel2.TabIndex = 21;
            this.kryptonLabel2.Values.Text = "Proveedor";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(24, 22);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(109, 20);
            this.kryptonLabel1.TabIndex = 20;
            this.kryptonLabel1.Values.Text = "No. Comprobante";
            // 
            // cbproveedor
            // 
            this.cbproveedor.DropDownWidth = 326;
            this.cbproveedor.Location = new System.Drawing.Point(24, 129);
            this.cbproveedor.Margin = new System.Windows.Forms.Padding(2);
            this.cbproveedor.Name = "cbproveedor";
            this.cbproveedor.Size = new System.Drawing.Size(271, 21);
            this.cbproveedor.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(597, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 2);
            this.label2.TabIndex = 1;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(964, 611);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 611);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ListaProductSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 234);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 283);
            this.panel2.TabIndex = 4;
            // 
            // ListaProductSelect
            // 
            this.ListaProductSelect.AllowUserToAddRows = false;
            this.ListaProductSelect.ColumnHeadersHeight = 20;
            this.ListaProductSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ListaProductSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codbarras,
            this.Descripcion,
            this.costo,
            this.Cantidad,
            this.Impuesto,
            this.BaseImponible,
            this.subtotal,
            this.Idprod});
            this.ListaProductSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaProductSelect.Location = new System.Drawing.Point(0, 0);
            this.ListaProductSelect.Margin = new System.Windows.Forms.Padding(2);
            this.ListaProductSelect.Name = "ListaProductSelect";
            this.ListaProductSelect.RowHeadersWidth = 51;
            this.ListaProductSelect.RowTemplate.Height = 24;
            this.ListaProductSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaProductSelect.Size = new System.Drawing.Size(960, 283);
            this.ListaProductSelect.TabIndex = 1;
            this.ListaProductSelect.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaProductSelect_CellEndEdit);
            this.ListaProductSelect.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ListaProductSelect_RowsAdded);
            this.ListaProductSelect.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.ListaProductSelect_RowsRemoved);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lbimpuesto);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.lbsubt);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.lbtotal);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 521);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(960, 88);
            this.panel3.TabIndex = 5;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lbimpuesto
            // 
            this.lbimpuesto.AutoSize = true;
            this.lbimpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbimpuesto.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbimpuesto.Location = new System.Drawing.Point(784, 25);
            this.lbimpuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbimpuesto.Name = "lbimpuesto";
            this.lbimpuesto.Size = new System.Drawing.Size(40, 17);
            this.lbimpuesto.TabIndex = 27;
            this.lbimpuesto.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label16.Location = new System.Drawing.Point(694, 25);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 15);
            this.label16.TabIndex = 26;
            this.label16.Text = "Impuesto: Q.";
            // 
            // lbsubt
            // 
            this.lbsubt.AutoSize = true;
            this.lbsubt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsubt.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbsubt.Location = new System.Drawing.Point(784, 7);
            this.lbsubt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbsubt.Name = "lbsubt";
            this.lbsubt.Size = new System.Drawing.Size(40, 17);
            this.lbsubt.TabIndex = 25;
            this.lbsubt.Text = "0.00";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.RoyalBlue;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(680, 5);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 2);
            this.label10.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(661, 9);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "base imponible: Q.";
            // 
            // lbtotal
            // 
            this.lbtotal.AutoSize = true;
            this.lbtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotal.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbtotal.Location = new System.Drawing.Point(777, 51);
            this.lbtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbtotal.Name = "lbtotal";
            this.lbtotal.Size = new System.Drawing.Size(44, 20);
            this.lbtotal.TabIndex = 22;
            this.lbtotal.Text = "0.00";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.RoyalBlue;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(682, 49);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 2);
            this.label12.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label11.Location = new System.Drawing.Point(686, 51);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Total: Q.";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Codbarras
            // 
            this.Codbarras.FillWeight = 150F;
            this.Codbarras.HeaderText = "Codigo de Referencia";
            this.Codbarras.MinimumWidth = 6;
            this.Codbarras.Name = "Codbarras";
            this.Codbarras.Width = 217;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 200;
            // 
            // costo
            // 
            this.costo.HeaderText = "Precio de Compra";
            this.costo.Name = "costo";
            this.costo.Width = 150;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 80;
            // 
            // Impuesto
            // 
            this.Impuesto.HeaderText = "Impuesto";
            this.Impuesto.MinimumWidth = 6;
            this.Impuesto.Name = "Impuesto";
            this.Impuesto.Width = 125;
            // 
            // BaseImponible
            // 
            this.BaseImponible.HeaderText = "Base Imponible";
            this.BaseImponible.MinimumWidth = 6;
            this.BaseImponible.Name = "BaseImponible";
            this.BaseImponible.Width = 125;
            // 
            // subtotal
            // 
            this.subtotal.HeaderText = "Total";
            this.subtotal.MinimumWidth = 6;
            this.subtotal.Name = "subtotal";
            this.subtotal.Width = 125;
            // 
            // Idprod
            // 
            this.Idprod.HeaderText = "id";
            this.Idprod.MinimumWidth = 6;
            this.Idprod.Name = "Idprod";
            this.Idprod.Visible = false;
            this.Idprod.Width = 125;
            // 
            // SolicitudCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 638);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SolicitudCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SolicitudCompra";
            this.Load += new System.EventHandler(this.SolicitudCompra_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbproveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListaProductSelect)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnguardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnConfirmarPed;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbproveedor;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnagregarproducto;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcomprobante;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbsolicitud;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpEntrega;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnCantidad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbimpuesto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbsubt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbtotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public ComponentFactory.Krypton.Toolkit.KryptonDataGridView ListaProductSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codbarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseImponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idprod;
    }
}