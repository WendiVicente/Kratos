namespace Sistema.Reports.Reports_Productos
{
    partial class ReporteProductosGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteProductosGeneral));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLista = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtbuscar = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkfechas = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpfechainicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpfechafinal = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbActivos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbTodos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbInactivos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbBajas = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbAmbasExiste = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbAltas = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbporExistencia = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.cbMovimiento = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnVistaPrevia = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbsucursales = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbcategoria = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbcategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.toolStrip1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1545, 30);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1545, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(122, 24);
            this.toolStripButton1.Text = "Generar Reporte";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dgvLista, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 162);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1545, 492);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(3, 3);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersWidth = 51;
            this.dgvLista.RowTemplate.Height = 24;
            this.dgvLista.Size = new System.Drawing.Size(1539, 486);
            this.dgvLista.TabIndex = 1;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.tableLayoutPanel3);
            this.kryptonPanel3.Controls.Add(this.tableLayoutPanel2);
            this.kryptonPanel3.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 30);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(1545, 654);
            this.kryptonPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.048543F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.95145F));
            this.tableLayoutPanel2.Controls.Add(this.txtbuscar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 132);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1545, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtbuscar
            // 
            this.txtbuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbuscar.Location = new System.Drawing.Point(80, 3);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(1462, 27);
            this.txtbuscar.TabIndex = 1;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(56, 24);
            this.kryptonLabel6.TabIndex = 0;
            this.kryptonLabel6.Values.Text = "Buscar";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.97495F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.02505F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 297F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnVistaPrevia, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1545, 132);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkfechas);
            this.groupBox1.Controls.Add(this.dtpfechainicio);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.dtpfechafinal);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(149, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 126);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de Creación";
            // 
            // checkfechas
            // 
            this.checkfechas.Location = new System.Drawing.Point(6, 101);
            this.checkfechas.Name = "checkfechas";
            this.checkfechas.Size = new System.Drawing.Size(138, 24);
            this.checkfechas.TabIndex = 5;
            this.checkfechas.Values.Text = "Todas las Fechas";
            this.checkfechas.CheckedChanged += new System.EventHandler(this.checkfechas_CheckedChanged);
            // 
            // dtpfechainicio
            // 
            this.dtpfechainicio.Location = new System.Drawing.Point(127, 31);
            this.dtpfechainicio.Name = "dtpfechainicio";
            this.dtpfechainicio.Size = new System.Drawing.Size(238, 25);
            this.dtpfechainicio.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 71);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(75, 24);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Fecha Fin";
            // 
            // dtpfechafinal
            // 
            this.dtpfechafinal.Location = new System.Drawing.Point(127, 71);
            this.dtpfechafinal.Name = "dtpfechafinal";
            this.dtpfechafinal.Size = new System.Drawing.Size(238, 25);
            this.dtpfechafinal.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 31);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(92, 24);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Fecha Inicio";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.rbActivos);
            this.groupBox4.Controls.Add(this.rbTodos);
            this.groupBox4.Controls.Add(this.rbInactivos);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 126);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Productos";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // rbActivos
            // 
            this.rbActivos.Location = new System.Drawing.Point(6, 21);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(107, 24);
            this.rbActivos.TabIndex = 9;
            this.rbActivos.Values.Text = "Solo Activos";
            // 
            // rbTodos
            // 
            this.rbTodos.Location = new System.Drawing.Point(6, 96);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(65, 24);
            this.rbTodos.TabIndex = 8;
            this.rbTodos.Values.Text = "Todos";
            // 
            // rbInactivos
            // 
            this.rbInactivos.Location = new System.Drawing.Point(6, 59);
            this.rbInactivos.Name = "rbInactivos";
            this.rbInactivos.Size = new System.Drawing.Size(118, 24);
            this.rbInactivos.TabIndex = 6;
            this.rbInactivos.Values.Text = "Solo Inactivos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbBajas);
            this.groupBox3.Controls.Add(this.rbAmbasExiste);
            this.groupBox3.Controls.Add(this.rbAltas);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(843, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(138, 126);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Incluir Existencias";
            // 
            // rbBajas
            // 
            this.rbBajas.Location = new System.Drawing.Point(10, 32);
            this.rbBajas.Name = "rbBajas";
            this.rbBajas.Size = new System.Drawing.Size(58, 24);
            this.rbBajas.TabIndex = 12;
            this.rbBajas.Values.Text = "Bajas";
            // 
            // rbAmbasExiste
            // 
            this.rbAmbasExiste.Location = new System.Drawing.Point(10, 96);
            this.rbAmbasExiste.Name = "rbAmbasExiste";
            this.rbAmbasExiste.Size = new System.Drawing.Size(65, 24);
            this.rbAmbasExiste.TabIndex = 11;
            this.rbAmbasExiste.Values.Text = "Todos";
            // 
            // rbAltas
            // 
            this.rbAltas.Location = new System.Drawing.Point(10, 70);
            this.rbAltas.Name = "rbAltas";
            this.rbAltas.Size = new System.Drawing.Size(57, 24);
            this.rbAltas.TabIndex = 10;
            this.rbAltas.Values.Text = "Altas";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbporExistencia);
            this.groupBox5.Controls.Add(this.cbMovimiento);
            this.groupBox5.Location = new System.Drawing.Point(987, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(162, 126);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ordenar";
            // 
            // cbporExistencia
            // 
            this.cbporExistencia.Location = new System.Drawing.Point(7, 64);
            this.cbporExistencia.Name = "cbporExistencia";
            this.cbporExistencia.Size = new System.Drawing.Size(118, 24);
            this.cbporExistencia.TabIndex = 1;
            this.cbporExistencia.Values.Text = "Por Existencia";
            // 
            // cbMovimiento
            // 
            this.cbMovimiento.Location = new System.Drawing.Point(6, 31);
            this.cbMovimiento.Name = "cbMovimiento";
            this.cbMovimiento.Size = new System.Drawing.Size(149, 24);
            this.cbMovimiento.TabIndex = 0;
            this.cbMovimiento.Values.Text = "Movimiento Lento";
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.Location = new System.Drawing.Point(1269, 3);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(97, 51);
            this.btnVistaPrevia.TabIndex = 12;
            this.btnVistaPrevia.Values.Text = "Vista Previa";
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Controls.Add(this.kryptonLabel3);
            this.groupBox2.Controls.Add(this.cbsucursales);
            this.groupBox2.Controls.Add(this.cbcategoria);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(546, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 126);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros de Productos";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(6, 32);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(77, 24);
            this.kryptonLabel4.TabIndex = 4;
            this.kryptonLabel4.Values.Text = "Categoria";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(6, 67);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(68, 24);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Sucursal";
            // 
            // cbsucursales
            // 
            this.cbsucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsucursales.DropDownWidth = 226;
            this.cbsucursales.Location = new System.Drawing.Point(121, 62);
            this.cbsucursales.Name = "cbsucursales";
            this.cbsucursales.Size = new System.Drawing.Size(161, 25);
            this.cbsucursales.TabIndex = 2;
            // 
            // cbcategoria
            // 
            this.cbcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcategoria.DropDownWidth = 226;
            this.cbcategoria.Location = new System.Drawing.Point(121, 25);
            this.cbcategoria.Name = "cbcategoria";
            this.cbcategoria.Size = new System.Drawing.Size(161, 25);
            this.cbcategoria.TabIndex = 1;
            // 
            // ReporteProductosGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 684);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteProductosGeneral";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteProductosGeneral";
            this.Load += new System.EventHandler(this.ReporteProductosGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbcategoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbActivos;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbTodos;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbInactivos;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkfechas;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechainicio;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechafinal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbsucursales;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbcategoria;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvLista;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscar;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbBajas;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbAmbasExiste;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbAltas;
        private System.Windows.Forms.GroupBox groupBox5;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbporExistencia;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbMovimiento;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnVistaPrevia;
    }
}