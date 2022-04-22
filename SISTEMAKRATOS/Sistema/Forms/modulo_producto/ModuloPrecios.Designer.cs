
namespace Sistema.Forms.modulo_producto
{
    partial class ModuloPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuloPrecios));
            this.groupPrecios = new System.Windows.Forms.GroupBox();
            this.txtprecioventa = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel15 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtpreciorevendedor = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtpreciogobierno = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtpreciocuentaclave = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtpreciomayorista = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupGeneral = new System.Windows.Forms.GroupBox();
            this.TxtCodigoBarras = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtDescripcion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolEscalas = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.TxtBuscador = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DgvEscalasProducto = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPrecioIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiposDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.escalaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rangoInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rangoFinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiposIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listarDetallePreciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.toolListadoProducto = new System.Windows.Forms.ToolStrip();
            this.BtnVolver = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupPrecios.SuspendLayout();
            this.groupGeneral.SuspendLayout();
            this.toolEscalas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEscalasProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listarDetallePreciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.toolListadoProducto.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPrecios
            // 
            this.groupPrecios.Controls.Add(this.txtprecioventa);
            this.groupPrecios.Controls.Add(this.kryptonLabel15);
            this.groupPrecios.Controls.Add(this.txtpreciorevendedor);
            this.groupPrecios.Controls.Add(this.kryptonLabel12);
            this.groupPrecios.Controls.Add(this.txtpreciogobierno);
            this.groupPrecios.Controls.Add(this.kryptonLabel10);
            this.groupPrecios.Controls.Add(this.txtpreciocuentaclave);
            this.groupPrecios.Controls.Add(this.kryptonLabel2);
            this.groupPrecios.Controls.Add(this.txtpreciomayorista);
            this.groupPrecios.Controls.Add(this.kryptonLabel8);
            this.groupPrecios.Location = new System.Drawing.Point(333, 2);
            this.groupPrecios.Margin = new System.Windows.Forms.Padding(2);
            this.groupPrecios.Name = "groupPrecios";
            this.groupPrecios.Padding = new System.Windows.Forms.Padding(2);
            this.groupPrecios.Size = new System.Drawing.Size(293, 165);
            this.groupPrecios.TabIndex = 49;
            this.groupPrecios.TabStop = false;
            this.groupPrecios.Text = "Precios";
            // 
            // txtprecioventa
            // 
            this.txtprecioventa.Location = new System.Drawing.Point(146, 12);
            this.txtprecioventa.Margin = new System.Windows.Forms.Padding(2);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.Size = new System.Drawing.Size(126, 23);
            this.txtprecioventa.TabIndex = 55;
            this.txtprecioventa.Text = "0.00";
            this.txtprecioventa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtprecioventa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDecimal_KeyDown);
            this.txtprecioventa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDecimal_KeyPress);
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(4, 14);
            this.kryptonLabel15.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel15.TabIndex = 54;
            this.kryptonLabel15.Values.Text = "Precio Unitario";
            // 
            // txtpreciorevendedor
            // 
            this.txtpreciorevendedor.Location = new System.Drawing.Point(146, 132);
            this.txtpreciorevendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtpreciorevendedor.Name = "txtpreciorevendedor";
            this.txtpreciorevendedor.Size = new System.Drawing.Size(126, 23);
            this.txtpreciorevendedor.TabIndex = 52;
            this.txtpreciorevendedor.Text = "0.00";
            this.txtpreciorevendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpreciorevendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDecimal_KeyDown);
            this.txtpreciorevendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDecimal_KeyPress);
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(4, 132);
            this.kryptonLabel12.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(113, 20);
            this.kryptonLabel12.TabIndex = 53;
            this.kryptonLabel12.Values.Text = "Precio Revendedor";
            // 
            // txtpreciogobierno
            // 
            this.txtpreciogobierno.Location = new System.Drawing.Point(147, 103);
            this.txtpreciogobierno.Margin = new System.Windows.Forms.Padding(2);
            this.txtpreciogobierno.Name = "txtpreciogobierno";
            this.txtpreciogobierno.Size = new System.Drawing.Size(125, 23);
            this.txtpreciogobierno.TabIndex = 50;
            this.txtpreciogobierno.Text = "0.00";
            this.txtpreciogobierno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpreciogobierno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDecimal_KeyDown);
            this.txtpreciogobierno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDecimal_KeyPress);
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(3, 104);
            this.kryptonLabel10.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(140, 20);
            this.kryptonLabel10.TabIndex = 51;
            this.kryptonLabel10.Values.Text = "Entidad Gubernamental";
            // 
            // txtpreciocuentaclave
            // 
            this.txtpreciocuentaclave.Location = new System.Drawing.Point(147, 72);
            this.txtpreciocuentaclave.Margin = new System.Windows.Forms.Padding(2);
            this.txtpreciocuentaclave.Name = "txtpreciocuentaclave";
            this.txtpreciocuentaclave.Size = new System.Drawing.Size(125, 23);
            this.txtpreciocuentaclave.TabIndex = 48;
            this.txtpreciocuentaclave.Text = "0.00";
            this.txtpreciocuentaclave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpreciocuentaclave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDecimal_KeyDown);
            this.txtpreciocuentaclave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDecimal_KeyPress);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(4, 74);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(119, 20);
            this.kryptonLabel2.TabIndex = 49;
            this.kryptonLabel2.Values.Text = "Precio Cuenta Clave";
            // 
            // txtpreciomayorista
            // 
            this.txtpreciomayorista.Location = new System.Drawing.Point(147, 42);
            this.txtpreciomayorista.Margin = new System.Windows.Forms.Padding(2);
            this.txtpreciomayorista.Name = "txtpreciomayorista";
            this.txtpreciomayorista.Size = new System.Drawing.Size(125, 23);
            this.txtpreciomayorista.TabIndex = 45;
            this.txtpreciomayorista.Text = "0.00";
            this.txtpreciomayorista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpreciomayorista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDecimal_KeyDown);
            this.txtpreciomayorista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDecimal_KeyPress);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(4, 44);
            this.kryptonLabel8.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(101, 20);
            this.kryptonLabel8.TabIndex = 47;
            this.kryptonLabel8.Values.Text = "Precio Mayorista";
            // 
            // groupGeneral
            // 
            this.groupGeneral.BackColor = System.Drawing.Color.Transparent;
            this.groupGeneral.Controls.Add(this.TxtCodigoBarras);
            this.groupGeneral.Controls.Add(this.kryptonLabel9);
            this.groupGeneral.Controls.Add(this.TxtDescripcion);
            this.groupGeneral.Controls.Add(this.kryptonLabel1);
            this.groupGeneral.Location = new System.Drawing.Point(8, 2);
            this.groupGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.groupGeneral.Name = "groupGeneral";
            this.groupGeneral.Padding = new System.Windows.Forms.Padding(2);
            this.groupGeneral.Size = new System.Drawing.Size(307, 165);
            this.groupGeneral.TabIndex = 11;
            this.groupGeneral.TabStop = false;
            this.groupGeneral.Text = "General";
            // 
            // TxtCodigoBarras
            // 
            this.TxtCodigoBarras.Location = new System.Drawing.Point(5, 35);
            this.TxtCodigoBarras.Margin = new System.Windows.Forms.Padding(2);
            this.TxtCodigoBarras.Name = "TxtCodigoBarras";
            this.TxtCodigoBarras.ReadOnly = true;
            this.TxtCodigoBarras.Size = new System.Drawing.Size(279, 23);
            this.TxtCodigoBarras.TabIndex = 9;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(4, 16);
            this.kryptonLabel9.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(104, 20);
            this.kryptonLabel9.TabIndex = 8;
            this.kryptonLabel9.Values.Text = "Codigo de Barras";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(5, 86);
            this.TxtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.Size = new System.Drawing.Size(279, 23);
            this.TxtDescripcion.TabIndex = 6;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(4, 62);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(74, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Descripción";
            // 
            // toolEscalas
            // 
            this.toolEscalas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolEscalas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolEscalas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolEscalas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.TxtBuscador,
            this.toolStripSeparator1});
            this.toolEscalas.Location = new System.Drawing.Point(0, 210);
            this.toolEscalas.Name = "toolEscalas";
            this.toolEscalas.Size = new System.Drawing.Size(642, 30);
            this.toolEscalas.TabIndex = 6;
            this.toolEscalas.Text = "ToolStrip";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 27);
            // 
            // TxtBuscador
            // 
            this.TxtBuscador.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtBuscador.Name = "TxtBuscador";
            this.TxtBuscador.Size = new System.Drawing.Size(200, 30);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // DgvEscalasProducto
            // 
            this.DgvEscalasProducto.AllowUserToAddRows = false;
            this.DgvEscalasProducto.AllowUserToDeleteRows = false;
            this.DgvEscalasProducto.AutoGenerateColumns = false;
            this.DgvEscalasProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvEscalasProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEscalasProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.tipoPrecioIdDataGridViewTextBoxColumn,
            this.tiposDataGridViewTextBoxColumn,
            this.escalaDataGridViewTextBoxColumn,
            this.rangoInicioDataGridViewTextBoxColumn,
            this.rangoFinalDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.tiposIdDataGridViewTextBoxColumn});
            this.DgvEscalasProducto.DataSource = this.listarDetallePreciosBindingSource;
            this.DgvEscalasProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvEscalasProducto.Location = new System.Drawing.Point(3, 243);
            this.DgvEscalasProducto.MultiSelect = false;
            this.DgvEscalasProducto.Name = "DgvEscalasProducto";
            this.DgvEscalasProducto.ReadOnly = true;
            this.DgvEscalasProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEscalasProducto.Size = new System.Drawing.Size(636, 242);
            this.DgvEscalasProducto.TabIndex = 7;
            this.DgvEscalasProducto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEscalasProducto_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // tipoPrecioIdDataGridViewTextBoxColumn
            // 
            this.tipoPrecioIdDataGridViewTextBoxColumn.DataPropertyName = "TipoPrecioId";
            this.tipoPrecioIdDataGridViewTextBoxColumn.HeaderText = "TipoPrecioId";
            this.tipoPrecioIdDataGridViewTextBoxColumn.Name = "tipoPrecioIdDataGridViewTextBoxColumn";
            this.tipoPrecioIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoPrecioIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // tiposDataGridViewTextBoxColumn
            // 
            this.tiposDataGridViewTextBoxColumn.DataPropertyName = "Tipos";
            this.tiposDataGridViewTextBoxColumn.HeaderText = "Tipos";
            this.tiposDataGridViewTextBoxColumn.Name = "tiposDataGridViewTextBoxColumn";
            this.tiposDataGridViewTextBoxColumn.ReadOnly = true;
            this.tiposDataGridViewTextBoxColumn.Width = 64;
            // 
            // escalaDataGridViewTextBoxColumn
            // 
            this.escalaDataGridViewTextBoxColumn.DataPropertyName = "Escala";
            this.escalaDataGridViewTextBoxColumn.HeaderText = "Escala";
            this.escalaDataGridViewTextBoxColumn.Name = "escalaDataGridViewTextBoxColumn";
            this.escalaDataGridViewTextBoxColumn.ReadOnly = true;
            this.escalaDataGridViewTextBoxColumn.Width = 68;
            // 
            // rangoInicioDataGridViewTextBoxColumn
            // 
            this.rangoInicioDataGridViewTextBoxColumn.DataPropertyName = "RangoInicio";
            this.rangoInicioDataGridViewTextBoxColumn.HeaderText = "Rango Inicio";
            this.rangoInicioDataGridViewTextBoxColumn.Name = "rangoInicioDataGridViewTextBoxColumn";
            this.rangoInicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.rangoInicioDataGridViewTextBoxColumn.Width = 102;
            // 
            // rangoFinalDataGridViewTextBoxColumn
            // 
            this.rangoFinalDataGridViewTextBoxColumn.DataPropertyName = "RangoFinal";
            this.rangoFinalDataGridViewTextBoxColumn.HeaderText = "Rango Final";
            this.rangoFinalDataGridViewTextBoxColumn.Name = "rangoFinalDataGridViewTextBoxColumn";
            this.rangoFinalDataGridViewTextBoxColumn.ReadOnly = true;
            this.rangoFinalDataGridViewTextBoxColumn.Width = 98;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioDataGridViewTextBoxColumn.Width = 69;
            // 
            // tiposIdDataGridViewTextBoxColumn
            // 
            this.tiposIdDataGridViewTextBoxColumn.DataPropertyName = "TiposId";
            this.tiposIdDataGridViewTextBoxColumn.HeaderText = "TiposId";
            this.tiposIdDataGridViewTextBoxColumn.Name = "tiposIdDataGridViewTextBoxColumn";
            this.tiposIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.tiposIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // listarDetallePreciosBindingSource
            // 
            this.listarDetallePreciosBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarDetallePrecios);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.tableLayoutPanel4);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(642, 488);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.DgvEscalasProducto, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.toolListadoProducto, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.toolEscalas, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.056586F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.00145F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.94196F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(642, 488);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // toolListadoProducto
            // 
            this.toolListadoProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolListadoProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolListadoProducto.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolListadoProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnVolver,
            this.toolStripSeparator4,
            this.toolStripLabel1});
            this.toolListadoProducto.Location = new System.Drawing.Point(0, 0);
            this.toolListadoProducto.Name = "toolListadoProducto";
            this.toolListadoProducto.Size = new System.Drawing.Size(642, 27);
            this.toolListadoProducto.TabIndex = 4;
            this.toolListadoProducto.Text = "ToolStrip";
            // 
            // BtnVolver
            // 
            this.BtnVolver.Image = global::Sistema.Properties.Resources.volver;
            this.BtnVolver.ImageTransparentColor = System.Drawing.Color.Black;
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(24, 24);
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Image = global::Sistema.Properties.Resources.MoneyEditor_16x;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(153, 24);
            this.toolStripLabel1.Text = "Detalle de Precios";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.groupGeneral);
            this.panel1.Controls.Add(this.groupPrecios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 177);
            this.panel1.TabIndex = 50;
            // 
            // ModuloPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 488);
            this.Controls.Add(this.kryptonPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModuloPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Red Owl Software";
            this.Load += new System.EventHandler(this.ModuloPrecios_Load);
            this.groupPrecios.ResumeLayout(false);
            this.groupPrecios.PerformLayout();
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();
            this.toolEscalas.ResumeLayout(false);
            this.toolEscalas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEscalasProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listarDetallePreciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.toolListadoProducto.ResumeLayout(false);
            this.toolListadoProducto.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupGeneral;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtCodigoBarras;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtDescripcion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.GroupBox groupPrecios;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtprecioventa;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel15;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtpreciorevendedor;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtpreciogobierno;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtpreciocuentaclave;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtpreciomayorista;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView DgvEscalasProducto;
        private System.Windows.Forms.ToolStrip toolEscalas;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripTextBox TxtBuscador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPrecioIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiposDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn escalaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rangoInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rangoFinalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiposIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listarDetallePreciosBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ToolStrip toolListadoProducto;
        private System.Windows.Forms.ToolStripButton BtnVolver;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panel1;
    }
}