namespace Sistema.Forms.modulo_Bancos
{
    partial class IngresosEgresos
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvlistaDecuenta = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
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
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboTipoTransac = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtbuscarcuentaorigen = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtnotrasacccion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbfecha = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistaDecuenta)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboTipoTransac)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(632, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
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
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(632, 358);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.58065F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.41935F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel1.Controls.Add(this.dgvlistaDecuenta, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel14, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 294);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvlistaDecuenta
            // 
            this.dgvlistaDecuenta.AllowUserToAddRows = false;
            this.dgvlistaDecuenta.AllowUserToDeleteRows = false;
            this.dgvlistaDecuenta.ColumnHeadersHeight = 29;
            this.dgvlistaDecuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvlistaDecuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlistaDecuenta.Location = new System.Drawing.Point(2, 63);
            this.dgvlistaDecuenta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvlistaDecuenta.Name = "dgvlistaDecuenta";
            this.dgvlistaDecuenta.ReadOnly = true;
            this.dgvlistaDecuenta.RowHeadersWidth = 51;
            this.dgvlistaDecuenta.RowTemplate.Height = 24;
            this.dgvlistaDecuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlistaDecuenta.Size = new System.Drawing.Size(217, 229);
            this.dgvlistaDecuenta.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.9901F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel12, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel11, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel13, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(223, 63);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.42268F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.57732F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 229);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.201F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.799F));
            this.tableLayoutPanel12.Controls.Add(this.txtobservaciones, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.kryptonLabel9, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(2, 64);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(221, 72);
            this.tableLayoutPanel12.TabIndex = 2;
            // 
            // txtobservaciones
            // 
            this.txtobservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtobservaciones.Location = new System.Drawing.Point(90, 2);
            this.txtobservaciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtobservaciones.Name = "txtobservaciones";
            this.txtobservaciones.Size = new System.Drawing.Size(129, 68);
            this.txtobservaciones.TabIndex = 0;
            this.txtobservaciones.Text = "";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabel9.TabIndex = 1;
            this.kryptonLabel9.Values.Text = "Observaciones;";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.201F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.799F));
            this.tableLayoutPanel10.Controls.Add(this.kryptonLabel7, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.txtEstado, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(221, 25);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel7.TabIndex = 0;
            this.kryptonLabel7.Values.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstado.Location = new System.Drawing.Point(90, 2);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(129, 23);
            this.txtEstado.TabIndex = 1;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.201F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.799F));
            this.tableLayoutPanel11.Controls.Add(this.txtmontoCaja, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.kryptonLabel8, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(2, 31);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(221, 29);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // txtmontoCaja
            // 
            this.txtmontoCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtmontoCaja.Location = new System.Drawing.Point(90, 2);
            this.txtmontoCaja.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtmontoCaja.Name = "txtmontoCaja";
            this.txtmontoCaja.Size = new System.Drawing.Size(129, 23);
            this.txtmontoCaja.TabIndex = 0;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel8.TabIndex = 1;
            this.kryptonLabel8.Values.Text = "Monto:";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 2;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.19718F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.80282F));
            this.tableLayoutPanel13.Controls.Add(this.kryptonLabel5, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.comboTipoTransac, 1, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(2, 140);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(221, 32);
            this.tableLayoutPanel13.TabIndex = 3;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(37, 20);
            this.kryptonLabel5.TabIndex = 0;
            this.kryptonLabel5.Values.Text = "Tipo:";
            // 
            // comboTipoTransac
            // 
            this.comboTipoTransac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboTipoTransac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoTransac.DropDownWidth = 201;
            this.comboTipoTransac.Location = new System.Drawing.Point(93, 2);
            this.comboTipoTransac.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboTipoTransac.Name = "comboTipoTransac";
            this.comboTipoTransac.Size = new System.Drawing.Size(126, 21);
            this.comboTipoTransac.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.13669F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.86331F));
            this.tableLayoutPanel5.Controls.Add(this.txtbuscarcuentaorigen, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 32);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(217, 27);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // txtbuscarcuentaorigen
            // 
            this.txtbuscarcuentaorigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbuscarcuentaorigen.Location = new System.Drawing.Point(65, 2);
            this.txtbuscarcuentaorigen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtbuscarcuentaorigen.Name = "txtbuscarcuentaorigen";
            this.txtbuscarcuentaorigen.Size = new System.Drawing.Size(150, 23);
            this.txtbuscarcuentaorigen.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Buscar";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.66667F));
            this.tableLayoutPanel9.Controls.Add(this.kryptonLabel6, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.txtnotrasacccion, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(223, 32);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(240, 27);
            this.tableLayoutPanel9.TabIndex = 6;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(97, 20);
            this.kryptonLabel6.TabIndex = 0;
            this.kryptonLabel6.Values.Text = "No. Transacción";
            // 
            // txtnotrasacccion
            // 
            this.txtnotrasacccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtnotrasacccion.Location = new System.Drawing.Point(105, 2);
            this.txtnotrasacccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtnotrasacccion.Name = "txtnotrasacccion";
            this.txtnotrasacccion.ReadOnly = true;
            this.txtnotrasacccion.Size = new System.Drawing.Size(133, 23);
            this.txtnotrasacccion.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.5F));
            this.tableLayoutPanel8.Controls.Add(this.kryptonLabel4, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.lbfecha, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(223, 2);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(240, 26);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel4.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(98, 22);
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "Fecha:";
            // 
            // lbfecha
            // 
            this.lbfecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbfecha.Location = new System.Drawing.Point(104, 2);
            this.lbfecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbfecha.Name = "lbfecha";
            this.lbfecha.Size = new System.Drawing.Size(134, 22);
            this.lbfecha.TabIndex = 1;
            this.lbfecha.Values.Text = "DD/MM/YY-YY";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.71943F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.28057F));
            this.tableLayoutPanel14.Controls.Add(this.kryptonLabel2, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(217, 26);
            this.tableLayoutPanel14.TabIndex = 7;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel2.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(106, 22);
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Values.Text = "Cuenta Origen";
            // 
            // IngresosEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 385);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "IngresosEgresos";
            this.Text = "IngresosEgresos";
            this.Load += new System.EventHandler(this.IngresosEgresos_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistaDecuenta)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboTipoTransac)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvlistaDecuenta;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboTipoTransac;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscarcuentaorigen;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnotrasacccion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbfecha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}