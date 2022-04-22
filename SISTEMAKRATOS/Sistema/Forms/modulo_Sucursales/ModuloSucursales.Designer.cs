
namespace Sistema.Forms.modulo_Sucursales
{
    partial class ModuloSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuloSucursales));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolListadoProducto = new System.Windows.Forms.ToolStrip();
            this.BtnVolver = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.PageListado = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buscarprod = new System.Windows.Forms.ToolStripButton();
            this.TxtBuscador = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnBorrar = new System.Windows.Forms.ToolStripButton();
            this.DgvListSucursales = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreSucursalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEncargadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listarSucursalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PageGestion = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtsucursal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtencargado = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtdireccion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txttelefono = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnguardar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolListadoProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PageListado)).BeginInit();
            this.PageListado.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListSucursales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listarSucursalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageGestion)).BeginInit();
            this.PageGestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(734, 441);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.toolListadoProducto, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonNavigator1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.482993F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.51701F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 441);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.toolListadoProducto.Size = new System.Drawing.Size(734, 32);
            this.toolListadoProducto.TabIndex = 4;
            this.toolListadoProducto.Text = "ToolStrip";
            // 
            // BtnVolver
            // 
            this.BtnVolver.Image = global::Sistema.Properties.Resources.volver;
            this.BtnVolver.ImageTransparentColor = System.Drawing.Color.Black;
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(24, 29);
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Image = global::Sistema.Properties.Resources.sucursal64;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(104, 29);
            this.toolStripLabel1.Text = "Sucursales";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(3, 35);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.PageListado,
            this.PageGestion});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(728, 403);
            this.kryptonNavigator1.TabIndex = 5;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // PageListado
            // 
            this.PageListado.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.PageListado.Controls.Add(this.tableLayoutPanel2);
            this.PageListado.Flags = 65534;
            this.PageListado.LastVisibleSet = true;
            this.PageListado.MinimumSize = new System.Drawing.Size(50, 50);
            this.PageListado.Name = "PageListado";
            this.PageListado.Size = new System.Drawing.Size(726, 376);
            this.PageListado.Text = "Listado";
            this.PageListado.ToolTipTitle = "Page ToolTip";
            this.PageListado.UniqueName = "9EC726F42E4A40A1D38EC449F14E2428";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DgvListSucursales, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(726, 376);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarprod,
            this.TxtBuscador,
            this.toolStripSeparator1,
            this.BtnNuevo,
            this.toolStripSeparator3,
            this.BtnEditar,
            this.toolStripSeparator2,
            this.BtnActualizar,
            this.toolStripSeparator5,
            this.BtnBorrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(726, 30);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "ToolStrip";
            // 
            // buscarprod
            // 
            this.buscarprod.Image = ((System.Drawing.Image)(resources.GetObject("buscarprod.Image")));
            this.buscarprod.ImageTransparentColor = System.Drawing.Color.Black;
            this.buscarprod.Name = "buscarprod";
            this.buscarprod.Size = new System.Drawing.Size(24, 27);
            // 
            // TxtBuscador
            // 
            this.TxtBuscador.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtBuscador.Name = "TxtBuscador";
            this.TxtBuscador.Size = new System.Drawing.Size(250, 30);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Sistema.Properties.Resources.Add_8x_16x;
            this.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(65, 27);
            this.BtnNuevo.Text = "Nueva";
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditar.Image")));
            this.BtnEditar.ImageTransparentColor = System.Drawing.Color.Black;
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(61, 27);
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Image = global::Sistema.Properties.Resources.Refresh_16x;
            this.BtnActualizar.ImageTransparentColor = System.Drawing.Color.Black;
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(79, 27);
            this.BtnActualizar.Text = "Refrescar";
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 30);
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.Image = global::Sistema.Properties.Resources._0405_20_delete;
            this.BtnBorrar.ImageTransparentColor = System.Drawing.Color.Black;
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(74, 27);
            this.BtnBorrar.Text = "Eliminar";
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // DgvListSucursales
            // 
            this.DgvListSucursales.AllowUserToAddRows = false;
            this.DgvListSucursales.AllowUserToDeleteRows = false;
            this.DgvListSucursales.AutoGenerateColumns = false;
            this.DgvListSucursales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvListSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListSucursales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nombreSucursalDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.nombreEncargadoDataGridViewTextBoxColumn});
            this.DgvListSucursales.DataSource = this.listarSucursalesBindingSource;
            this.DgvListSucursales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvListSucursales.Location = new System.Drawing.Point(3, 33);
            this.DgvListSucursales.Name = "DgvListSucursales";
            this.DgvListSucursales.ReadOnly = true;
            this.DgvListSucursales.Size = new System.Drawing.Size(720, 340);
            this.DgvListSucursales.TabIndex = 5;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreSucursalDataGridViewTextBoxColumn
            // 
            this.nombreSucursalDataGridViewTextBoxColumn.DataPropertyName = "NombreSucursal";
            this.nombreSucursalDataGridViewTextBoxColumn.HeaderText = "Nombre Sucursal";
            this.nombreSucursalDataGridViewTextBoxColumn.Name = "nombreSucursalDataGridViewTextBoxColumn";
            this.nombreSucursalDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreSucursalDataGridViewTextBoxColumn.Width = 117;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.direccionDataGridViewTextBoxColumn.Width = 86;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.telefonoDataGridViewTextBoxColumn.Width = 81;
            // 
            // nombreEncargadoDataGridViewTextBoxColumn
            // 
            this.nombreEncargadoDataGridViewTextBoxColumn.DataPropertyName = "NombreEncargado";
            this.nombreEncargadoDataGridViewTextBoxColumn.HeaderText = "Nombre Encargado";
            this.nombreEncargadoDataGridViewTextBoxColumn.Name = "nombreEncargadoDataGridViewTextBoxColumn";
            this.nombreEncargadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreEncargadoDataGridViewTextBoxColumn.Width = 128;
            // 
            // listarSucursalesBindingSource
            // 
            this.listarSucursalesBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarSucursales);
            // 
            // PageGestion
            // 
            this.PageGestion.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.PageGestion.Controls.Add(this.kryptonHeaderGroup1);
            this.PageGestion.Flags = 65534;
            this.PageGestion.LastVisibleSet = true;
            this.PageGestion.MinimumSize = new System.Drawing.Size(50, 50);
            this.PageGestion.Name = "PageGestion";
            this.PageGestion.Size = new System.Drawing.Size(726, 376);
            this.PageGestion.Text = "Gestion";
            this.PageGestion.ToolTipTitle = "Page ToolTip";
            this.PageGestion.UniqueName = "79065C536851448A72AB50B5B65392ED";
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanel2);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(726, 376);
            this.kryptonHeaderGroup1.TabIndex = 2;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Nueva Sucursal";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = global::Sistema.Properties.Resources.Business_16x;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Modulo para gestion de sucursales";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.tableLayoutPanel3);
            this.kryptonPanel2.Controls.Add(this.btnguardar);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(724, 323);
            this.kryptonPanel2.TabIndex = 23;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.67712F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.32288F));
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtsucursal, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtencargado, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel9, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel5, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtdireccion, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txttelefono, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.kryptonButton1, 1, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(7, 26);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(385, 277);
            this.tableLayoutPanel3.TabIndex = 23;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(104, 20);
            this.kryptonLabel4.TabIndex = 11;
            this.kryptonLabel4.Values.Text = "Nombre Sucursal";
            // 
            // txtsucursal
            // 
            this.txtsucursal.Location = new System.Drawing.Point(144, 3);
            this.txtsucursal.Name = "txtsucursal";
            this.txtsucursal.Size = new System.Drawing.Size(216, 23);
            this.txtsucursal.TabIndex = 1;
            // 
            // txtencargado
            // 
            this.txtencargado.Location = new System.Drawing.Point(144, 168);
            this.txtencargado.Name = "txtencargado";
            this.txtencargado.Size = new System.Drawing.Size(216, 23);
            this.txtencargado.TabIndex = 4;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(3, 58);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(58, 20);
            this.kryptonLabel7.TabIndex = 17;
            this.kryptonLabel7.Values.Text = "Telefono";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(3, 168);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(68, 20);
            this.kryptonLabel9.TabIndex = 22;
            this.kryptonLabel9.Values.Text = "Encargado";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(3, 113);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(62, 20);
            this.kryptonLabel5.TabIndex = 13;
            this.kryptonLabel5.Values.Text = "Direccion";
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(144, 113);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(216, 23);
            this.txtdireccion.TabIndex = 2;
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(144, 58);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(216, 23);
            this.txttelefono.TabIndex = 3;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(144, 223);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(123, 32);
            this.kryptonButton1.TabIndex = 23;
            this.kryptonButton1.Values.Image = global::Sistema.Properties.Resources.SaveStatusBar1_16x;
            this.kryptonButton1.Values.Text = "Guardar";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(238, 327);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(108, 25);
            this.btnguardar.TabIndex = 5;
            this.btnguardar.Values.Text = "Guardar";
            // 
            // ModuloSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 441);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModuloSucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Red Owl Software";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModuloSucursales_FormClosing);
            this.Load += new System.EventHandler(this.ModuloSucursales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolListadoProducto.ResumeLayout(false);
            this.toolListadoProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PageListado)).EndInit();
            this.PageListado.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListSucursales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listarSucursalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageGestion)).EndInit();
            this.PageGestion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolListadoProducto;
        private System.Windows.Forms.ToolStripButton BtnVolver;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage PageListado;
        private ComponentFactory.Krypton.Navigator.KryptonPage PageGestion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buscarprod;
        private System.Windows.Forms.ToolStripTextBox TxtBuscador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BtnBorrar;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView DgvListSucursales;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreSucursalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEncargadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listarSucursalesBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnguardar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtencargado;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttelefono;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtsucursal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtdireccion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}