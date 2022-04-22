namespace Sistema.Forms.modulo_Bancos
{
    partial class EnviarACaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnviarACaja));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvlistaCuenta = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.txtobservaciones = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtEstado = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.txtmontoCaja = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txttiposmovi = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtbuscarCuenta = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvlistaCaja = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtbuscarCaja = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbfecha = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtnotrasacccion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistaCuenta)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistaCaja)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(962, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::Sistema.Properties.Resources.SaveStatusBar1_16x;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(73, 24);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(962, 429);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.81208F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.18792F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 401F));
            this.tableLayoutPanel1.Controls.Add(this.dgvlistaCuenta, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 294);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvlistaCuenta
            // 
            this.dgvlistaCuenta.AllowUserToAddRows = false;
            this.dgvlistaCuenta.AllowUserToDeleteRows = false;
            this.dgvlistaCuenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvlistaCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlistaCuenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvlistaCuenta.Location = new System.Drawing.Point(2, 63);
            this.dgvlistaCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.dgvlistaCuenta.Name = "dgvlistaCuenta";
            this.dgvlistaCuenta.RowHeadersWidth = 51;
            this.dgvlistaCuenta.RowTemplate.Height = 24;
            this.dgvlistaCuenta.Size = new System.Drawing.Size(286, 228);
            this.dgvlistaCuenta.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.9901F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel12, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel11, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(292, 63);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.46154F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.53846F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(262, 229);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.69388F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.30612F));
            this.tableLayoutPanel12.Controls.Add(this.txtobservaciones, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.kryptonLabel9, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(2, 72);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(257, 67);
            this.tableLayoutPanel12.TabIndex = 2;
            // 
            // txtobservaciones
            // 
            this.txtobservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtobservaciones.Location = new System.Drawing.Point(91, 2);
            this.txtobservaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtobservaciones.Name = "txtobservaciones";
            this.txtobservaciones.Size = new System.Drawing.Size(164, 63);
            this.txtobservaciones.TabIndex = 0;
            this.txtobservaciones.Text = "";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel9.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel9.TabIndex = 1;
            this.kryptonLabel9.Values.Text = "Observaciones:";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.86006F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.13994F));
            this.tableLayoutPanel10.Controls.Add(this.kryptonLabel7, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.txtEstado, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(257, 37);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel7.TabIndex = 0;
            this.kryptonLabel7.Values.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstado.Location = new System.Drawing.Point(94, 2);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(161, 23);
            this.txtEstado.TabIndex = 1;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.86006F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.13994F));
            this.tableLayoutPanel11.Controls.Add(this.txtmontoCaja, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.kryptonLabel8, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(2, 43);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(257, 25);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // txtmontoCaja
            // 
            this.txtmontoCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtmontoCaja.Location = new System.Drawing.Point(94, 2);
            this.txtmontoCaja.Margin = new System.Windows.Forms.Padding(2);
            this.txtmontoCaja.Name = "txtmontoCaja";
            this.txtmontoCaja.Size = new System.Drawing.Size(161, 23);
            this.txtmontoCaja.TabIndex = 0;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel8.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel8.TabIndex = 1;
            this.kryptonLabel8.Values.Text = "Monto:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.11079F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.88921F));
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txttiposmovi, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 143);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(257, 29);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(37, 20);
            this.kryptonLabel5.TabIndex = 0;
            this.kryptonLabel5.Values.Text = "Tipo:";
            // 
            // txttiposmovi
            // 
            this.txttiposmovi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txttiposmovi.Location = new System.Drawing.Point(89, 2);
            this.txttiposmovi.Margin = new System.Windows.Forms.Padding(2);
            this.txttiposmovi.Name = "txttiposmovi";
            this.txttiposmovi.ReadOnly = true;
            this.txttiposmovi.Size = new System.Drawing.Size(166, 23);
            this.txttiposmovi.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.18026F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.81974F));
            this.tableLayoutPanel5.Controls.Add(this.kryptonLabel3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtbuscarCuenta, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 32);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(286, 27);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel3.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(70, 23);
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.Values.Text = "Buscar cuenta";
            // 
            // txtbuscarCuenta
            // 
            this.txtbuscarCuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbuscarCuenta.Location = new System.Drawing.Point(76, 2);
            this.txtbuscarCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtbuscarCuenta.Name = "txtbuscarCuenta";
            this.txtbuscarCuenta.Size = new System.Drawing.Size(208, 23);
            this.txtbuscarCuenta.TabIndex = 1;
            this.txtbuscarCuenta.TextChanged += new System.EventHandler(this.txtbuscarCuenta_TextChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.dgvlistaCaja, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(562, 63);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 229F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(398, 229);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // dgvlistaCaja
            // 
            this.dgvlistaCaja.AllowUserToAddRows = false;
            this.dgvlistaCaja.AllowUserToDeleteRows = false;
            this.dgvlistaCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlistaCaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvlistaCaja.Location = new System.Drawing.Point(2, 2);
            this.dgvlistaCaja.Margin = new System.Windows.Forms.Padding(2);
            this.dgvlistaCaja.Name = "dgvlistaCaja";
            this.dgvlistaCaja.RowHeadersWidth = 51;
            this.dgvlistaCaja.RowTemplate.Height = 24;
            this.dgvlistaCaja.Size = new System.Drawing.Size(394, 223);
            this.dgvlistaCaja.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.97201F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.02799F));
            this.tableLayoutPanel7.Controls.Add(this.kryptonLabel2, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.txtbuscarCaja, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(562, 32);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(398, 27);
            this.tableLayoutPanel7.TabIndex = 4;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(71, 20);
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Values.Text = "Buscar caja";
            // 
            // txtbuscarCaja
            // 
            this.txtbuscarCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbuscarCaja.Location = new System.Drawing.Point(109, 2);
            this.txtbuscarCaja.Margin = new System.Windows.Forms.Padding(2);
            this.txtbuscarCaja.Name = "txtbuscarCaja";
            this.txtbuscarCaja.Size = new System.Drawing.Size(287, 23);
            this.txtbuscarCaja.TabIndex = 1;
            this.txtbuscarCaja.TextChanged += new System.EventHandler(this.txtbuscarCaja_TextChanged);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.89641F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.10358F));
            this.tableLayoutPanel8.Controls.Add(this.kryptonLabel4, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.lbfecha, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(286, 26);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel4.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(70, 22);
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "Fecha:";
            // 
            // lbfecha
            // 
            this.lbfecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbfecha.Location = new System.Drawing.Point(76, 2);
            this.lbfecha.Margin = new System.Windows.Forms.Padding(2);
            this.lbfecha.Name = "lbfecha";
            this.lbfecha.Size = new System.Drawing.Size(208, 22);
            this.lbfecha.TabIndex = 1;
            this.lbfecha.Values.Text = "DD/MM/YY-YY";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.67622F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.32378F));
            this.tableLayoutPanel9.Controls.Add(this.kryptonLabel6, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.txtnotrasacccion, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(292, 32);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(262, 27);
            this.tableLayoutPanel9.TabIndex = 6;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(92, 20);
            this.kryptonLabel6.TabIndex = 0;
            this.kryptonLabel6.Values.Text = "No. Transacción";
            // 
            // txtnotrasacccion
            // 
            this.txtnotrasacccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtnotrasacccion.Location = new System.Drawing.Point(98, 2);
            this.txtnotrasacccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtnotrasacccion.Name = "txtnotrasacccion";
            this.txtnotrasacccion.ReadOnly = true;
            this.txtnotrasacccion.Size = new System.Drawing.Size(162, 23);
            this.txtnotrasacccion.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.64179F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.35821F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel4.Controls.Add(this.kryptonLabel1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(292, 2);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(262, 26);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(89, 2);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(95, 20);
            this.kryptonLabel1.TabIndex = 7;
            this.kryptonLabel1.Values.Text = "ENVIAR A CAJA";
            // 
            // EnviarACaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 456);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EnviarACaja";
            this.Text = "EnviarACaja";
            this.Load += new System.EventHandler(this.EnviarACaja_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistaCuenta)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistaCaja)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvlistaCuenta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtobservaciones;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEstado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtmontoCaja;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscarCuenta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvlistaCaja;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscarCaja;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbfecha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnotrasacccion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttiposmovi;
    }
}