namespace Sistema.Forms.modulo_personal
{
    partial class VerPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerPersonal));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnreporte = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEstado = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btntraslado = new System.Windows.Forms.ToolStripButton();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPersonal = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtbuscar = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbsucursales = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkfechas = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpfechainicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpfechafinal = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbActivos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbTodos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbInactivos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnVista = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.toolStrip1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(747, 27);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnreporte,
            this.toolStripSeparator2,
            this.btnEstado,
            this.toolStripSeparator3,
            this.btntraslado});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnreporte
            // 
            this.btnreporte.Image = global::Sistema.Properties.Resources.UserTask_16x;
            this.btnreporte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnreporte.Name = "btnreporte";
            this.btnreporte.Size = new System.Drawing.Size(116, 24);
            this.btnreporte.Text = "Generar Reporte";
            this.btnreporte.Click += new System.EventHandler(this.btnreporte_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnEstado
            // 
            this.btnEstado.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
            this.btnEstado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(114, 24);
            this.btnEstado.Text = "Cambiar Estado";
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btntraslado
            // 
            this.btntraslado.Image = global::Sistema.Properties.Resources.Business_16x;
            this.btntraslado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btntraslado.Name = "btntraslado";
            this.btntraslado.Size = new System.Drawing.Size(125, 24);
            this.btntraslado.Text = "Trasladar Personal";
            this.btntraslado.Click += new System.EventHandler(this.btntraslado_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel2.Controls.Add(this.tableLayoutPanel3);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(747, 421);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPersonal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbuscar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 121);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(747, 300);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.AllowUserToDeleteRows = false;
            this.dgvPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonal.Location = new System.Drawing.Point(2, 34);
            this.dgvPersonal.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.RowHeadersWidth = 51;
            this.dgvPersonal.RowTemplate.Height = 24;
            this.dgvPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonal.Size = new System.Drawing.Size(743, 264);
            this.dgvPersonal.TabIndex = 0;
            // 
            // txtbuscar
            // 
            this.txtbuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbuscar.Location = new System.Drawing.Point(2, 2);
            this.txtbuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(743, 23);
            this.txtbuscar.TabIndex = 1;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.19231F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.80769F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnVista, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.60465F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(747, 121);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.kryptonLabel5);
            this.groupBox2.Controls.Add(this.cbsucursales);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(401, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(243, 117);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros de Productos";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(4, 35);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel5.TabIndex = 3;
            this.kryptonLabel5.Values.Text = "Sucursal";
            // 
            // cbsucursales
            // 
            this.cbsucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsucursales.DropDownWidth = 226;
            this.cbsucursales.Location = new System.Drawing.Point(91, 31);
            this.cbsucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbsucursales.Name = "cbsucursales";
            this.cbsucursales.Size = new System.Drawing.Size(121, 21);
            this.cbsucursales.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkfechas);
            this.groupBox1.Controls.Add(this.dtpfechainicio);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.dtpfechafinal);
            this.groupBox1.Controls.Add(this.kryptonLabel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(122, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(275, 117);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de Creación";
            // 
            // checkfechas
            // 
            this.checkfechas.Location = new System.Drawing.Point(4, 82);
            this.checkfechas.Margin = new System.Windows.Forms.Padding(2);
            this.checkfechas.Name = "checkfechas";
            this.checkfechas.Size = new System.Drawing.Size(114, 20);
            this.checkfechas.TabIndex = 5;
            this.checkfechas.Values.Text = "Todas las Fechas";
            this.checkfechas.CheckedChanged += new System.EventHandler(this.checkfechas_CheckedChanged);
            // 
            // dtpfechainicio
            // 
            this.dtpfechainicio.CalendarTodayDate = new System.DateTime(2020, 12, 21, 0, 0, 0, 0);
            this.dtpfechainicio.Location = new System.Drawing.Point(95, 25);
            this.dtpfechainicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpfechainicio.Name = "dtpfechainicio";
            this.dtpfechainicio.Size = new System.Drawing.Size(178, 21);
            this.dtpfechainicio.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(4, 58);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Fecha Fin";
            // 
            // dtpfechafinal
            // 
            this.dtpfechafinal.CalendarTodayDate = new System.DateTime(2020, 12, 21, 0, 0, 0, 0);
            this.dtpfechafinal.Location = new System.Drawing.Point(95, 58);
            this.dtpfechafinal.Margin = new System.Windows.Forms.Padding(2);
            this.dtpfechafinal.Name = "dtpfechafinal";
            this.dtpfechafinal.Size = new System.Drawing.Size(178, 21);
            this.dtpfechafinal.TabIndex = 2;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(4, 25);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Fecha Inicio";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.rbActivos);
            this.groupBox4.Controls.Add(this.rbTodos);
            this.groupBox4.Controls.Add(this.rbInactivos);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(2, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(116, 117);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Estado";
            // 
            // rbActivos
            // 
            this.rbActivos.Location = new System.Drawing.Point(4, 17);
            this.rbActivos.Margin = new System.Windows.Forms.Padding(2);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(89, 20);
            this.rbActivos.TabIndex = 9;
            this.rbActivos.Values.Text = "Solo Activos";
            // 
            // rbTodos
            // 
            this.rbTodos.Location = new System.Drawing.Point(4, 78);
            this.rbTodos.Margin = new System.Windows.Forms.Padding(2);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(56, 20);
            this.rbTodos.TabIndex = 8;
            this.rbTodos.Values.Text = "Todos";
            // 
            // rbInactivos
            // 
            this.rbInactivos.Location = new System.Drawing.Point(4, 48);
            this.rbInactivos.Margin = new System.Windows.Forms.Padding(2);
            this.rbInactivos.Name = "rbInactivos";
            this.rbInactivos.Size = new System.Drawing.Size(98, 20);
            this.rbInactivos.TabIndex = 6;
            this.rbInactivos.Values.Text = "Solo Inactivos";
            // 
            // btnVista
            // 
            this.btnVista.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVista.Location = new System.Drawing.Point(648, 2);
            this.btnVista.Margin = new System.Windows.Forms.Padding(2);
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(78, 37);
            this.btnVista.TabIndex = 11;
            this.btnVista.Values.Text = "Vista Previa";
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click_1);
            // 
            // VerPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 448);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VerPersonal";
            this.Text = "VerPersonal";
            this.Load += new System.EventHandler(this.VerPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnreporte;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ToolStripButton btnEstado;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvPersonal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbsucursales;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkfechas;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechainicio;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechafinal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbActivos;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbTodos;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbInactivos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnVista;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btntraslado;
    }
}