namespace Sistema.Forms.modulo_Prestamos
{
    partial class RegistroDesembolso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroDesembolso));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnguardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnimprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtnombrecliente = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtcodcliente = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtnocredito = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtbuscarcliente = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnbuscarcliente = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtobservacion = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.txtvalorxcuota = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtnocuotas = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtimporteFinal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtmontosolicitado = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txttasainteres = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btngenerarcuotas = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.comboperiodopago = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.combometodoamort = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCuotas = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboperiodopago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combometodoamort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnguardar,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.btnimprimir,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1193, 27);
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
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Sistema.Properties.Resources._0405_20_delete;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(77, 24);
            this.toolStripButton2.Text = "Cancelar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnimprimir
            // 
            this.btnimprimir.Image = global::Sistema.Properties.Resources.Print_16x;
            this.btnimprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(77, 24);
            this.btnimprimir.Text = "Imprimir";
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1193, 527);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvCuotas, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.35593F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.64407F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1193, 527);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonLabel11);
            this.groupBox1.Controls.Add(this.txtnombrecliente);
            this.groupBox1.Controls.Add(this.txtcodcliente);
            this.groupBox1.Controls.Add(this.txtnocredito);
            this.groupBox1.Controls.Add(this.txtbuscarcliente);
            this.groupBox1.Controls.Add(this.btnbuscarcliente);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1187, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solicitud de Prestamo";
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Location = new System.Drawing.Point(16, 70);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel11.TabIndex = 7;
            this.kryptonLabel11.Values.Text = "Nombre";
            // 
            // txtnombrecliente
            // 
            this.txtnombrecliente.Location = new System.Drawing.Point(100, 70);
            this.txtnombrecliente.Name = "txtnombrecliente";
            this.txtnombrecliente.Size = new System.Drawing.Size(291, 23);
            this.txtnombrecliente.TabIndex = 6;
            // 
            // txtcodcliente
            // 
            this.txtcodcliente.Location = new System.Drawing.Point(100, 44);
            this.txtcodcliente.Name = "txtcodcliente";
            this.txtcodcliente.Size = new System.Drawing.Size(154, 23);
            this.txtcodcliente.TabIndex = 5;
            // 
            // txtnocredito
            // 
            this.txtnocredito.Location = new System.Drawing.Point(100, 18);
            this.txtnocredito.Name = "txtnocredito";
            this.txtnocredito.Size = new System.Drawing.Size(154, 23);
            this.txtnocredito.TabIndex = 4;
            // 
            // txtbuscarcliente
            // 
            this.txtbuscarcliente.Location = new System.Drawing.Point(437, 70);
            this.txtbuscarcliente.Name = "txtbuscarcliente";
            this.txtbuscarcliente.Size = new System.Drawing.Size(240, 23);
            this.txtbuscarcliente.TabIndex = 3;
            // 
            // btnbuscarcliente
            // 
            this.btnbuscarcliente.Location = new System.Drawing.Point(766, 18);
            this.btnbuscarcliente.Name = "btnbuscarcliente";
            this.btnbuscarcliente.Size = new System.Drawing.Size(125, 24);
            this.btnbuscarcliente.TabIndex = 2;
            this.btnbuscarcliente.Values.Text = "Elegir Cliente";
            this.btnbuscarcliente.Click += new System.EventHandler(this.btnbuscarcliente_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(16, 44);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Cod.Cliente";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(16, 18);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "No. Credito";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 463F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 125);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1187, 167);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kryptonLabel12);
            this.groupBox2.Controls.Add(this.txtobservacion);
            this.groupBox2.Controls.Add(this.txtvalorxcuota);
            this.groupBox2.Controls.Add(this.kryptonLabel10);
            this.groupBox2.Controls.Add(this.txtnocuotas);
            this.groupBox2.Controls.Add(this.kryptonLabel7);
            this.groupBox2.Controls.Add(this.txtimporteFinal);
            this.groupBox2.Controls.Add(this.kryptonLabel5);
            this.groupBox2.Controls.Add(this.kryptonLabel6);
            this.groupBox2.Controls.Add(this.txtmontosolicitado);
            this.groupBox2.Controls.Add(this.txttasainteres);
            this.groupBox2.Controls.Add(this.kryptonLabel3);
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Generales";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(6, 103);
            this.kryptonLabel12.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel12.TabIndex = 15;
            this.kryptonLabel12.Values.Text = "Observaciones";
            // 
            // txtobservacion
            // 
            this.txtobservacion.Location = new System.Drawing.Point(96, 106);
            this.txtobservacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtobservacion.Name = "txtobservacion";
            this.txtobservacion.Size = new System.Drawing.Size(215, 41);
            this.txtobservacion.TabIndex = 14;
            this.txtobservacion.Text = "";
            // 
            // txtvalorxcuota
            // 
            this.txtvalorxcuota.Location = new System.Drawing.Point(357, 73);
            this.txtvalorxcuota.Name = "txtvalorxcuota";
            this.txtvalorxcuota.ReadOnly = true;
            this.txtvalorxcuota.Size = new System.Drawing.Size(65, 23);
            this.txtvalorxcuota.TabIndex = 13;
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(250, 76);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(100, 20);
            this.kryptonLabel10.TabIndex = 12;
            this.kryptonLabel10.Values.Text = "Valor  por Cuota";
            // 
            // txtnocuotas
            // 
            this.txtnocuotas.Location = new System.Drawing.Point(509, 15);
            this.txtnocuotas.Name = "txtnocuotas";
            this.txtnocuotas.Size = new System.Drawing.Size(65, 23);
            this.txtnocuotas.TabIndex = 11;
            this.txtnocuotas.TextChanged += new System.EventHandler(this.txtnocuotas_TextChanged);
            this.txtnocuotas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnocuotas_KeyPress);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(171, 19);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(21, 20);
            this.kryptonLabel7.TabIndex = 10;
            this.kryptonLabel7.Values.Text = "%";
            // 
            // txtimporteFinal
            // 
            this.txtimporteFinal.Location = new System.Drawing.Point(97, 74);
            this.txtimporteFinal.Name = "txtimporteFinal";
            this.txtimporteFinal.ReadOnly = true;
            this.txtimporteFinal.Size = new System.Drawing.Size(130, 23);
            this.txtimporteFinal.TabIndex = 8;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(434, 18);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(71, 20);
            this.kryptonLabel5.TabIndex = 7;
            this.kryptonLabel5.Values.Text = "No. Cuotas";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(8, 74);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel6.TabIndex = 6;
            this.kryptonLabel6.Values.Text = "Importe Final";
            // 
            // txtmontosolicitado
            // 
            this.txtmontosolicitado.Location = new System.Drawing.Point(323, 15);
            this.txtmontosolicitado.Name = "txtmontosolicitado";
            this.txtmontosolicitado.Size = new System.Drawing.Size(100, 23);
            this.txtmontosolicitado.TabIndex = 5;
            this.txtmontosolicitado.TextChanged += new System.EventHandler(this.txtmontosolicitado_TextChanged);
            this.txtmontosolicitado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmontosolicitado_KeyPress);
            // 
            // txttasainteres
            // 
            this.txttasainteres.Location = new System.Drawing.Point(100, 19);
            this.txttasainteres.Name = "txttasainteres";
            this.txttasainteres.Size = new System.Drawing.Size(65, 23);
            this.txttasainteres.TabIndex = 4;
            this.txttasainteres.TextChanged += new System.EventHandler(this.txttasainteres_TextChanged_1);
            this.txttasainteres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttasainteres_KeyPress);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(213, 19);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(104, 20);
            this.kryptonLabel3.TabIndex = 1;
            this.kryptonLabel3.Values.Text = "Monto Solicitado";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(16, 18);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(93, 20);
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "Taza de Interés";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btngenerarcuotas);
            this.groupBox3.Controls.Add(this.comboperiodopago);
            this.groupBox3.Controls.Add(this.kryptonLabel9);
            this.groupBox3.Controls.Add(this.combometodoamort);
            this.groupBox3.Controls.Add(this.kryptonLabel8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(727, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(457, 161);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Metodo de pago";
            // 
            // btngenerarcuotas
            // 
            this.btngenerarcuotas.Location = new System.Drawing.Point(163, 105);
            this.btngenerarcuotas.Name = "btngenerarcuotas";
            this.btngenerarcuotas.Size = new System.Drawing.Size(200, 27);
            this.btngenerarcuotas.TabIndex = 4;
            this.btngenerarcuotas.Values.Text = "Generar cuotas";
            this.btngenerarcuotas.Click += new System.EventHandler(this.btngenerarcuotas_Click);
            // 
            // comboperiodopago
            // 
            this.comboperiodopago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboperiodopago.DropDownWidth = 169;
            this.comboperiodopago.Location = new System.Drawing.Point(163, 69);
            this.comboperiodopago.Name = "comboperiodopago";
            this.comboperiodopago.Size = new System.Drawing.Size(169, 21);
            this.comboperiodopago.TabIndex = 3;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(22, 70);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel9.TabIndex = 2;
            this.kryptonLabel9.Values.Text = "Tipo de pago";
            // 
            // combometodoamort
            // 
            this.combometodoamort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combometodoamort.DropDownWidth = 171;
            this.combometodoamort.Location = new System.Drawing.Point(161, 29);
            this.combometodoamort.Name = "combometodoamort";
            this.combometodoamort.Size = new System.Drawing.Size(171, 21);
            this.combometodoamort.TabIndex = 1;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(22, 29);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel8.TabIndex = 0;
            this.kryptonLabel8.Values.Text = "Metodo";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.89816F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.10184F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 457);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1187, 38);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.AllowUserToAddRows = false;
            this.dgvCuotas.AllowUserToDeleteRows = false;
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuotas.Location = new System.Drawing.Point(3, 298);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.ReadOnly = true;
            this.dgvCuotas.Size = new System.Drawing.Size(1187, 153);
            this.dgvCuotas.TabIndex = 4;
            // 
            // RegistroDesembolso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 554);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroDesembolso";
            this.Text = "RegistroDesembolso";
            this.Load += new System.EventHandler(this.RegistroDesembolso_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboperiodopago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combometodoamort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnguardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnimprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscarcliente;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnbuscarcliente;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtimporteFinal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtmontosolicitado;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttasainteres;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcodcliente;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnocredito;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtvalorxcuota;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnocuotas;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboperiodopago;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox combometodoamort;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btngenerarcuotas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvCuotas;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtnombrecliente;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtobservacion;
    }
}