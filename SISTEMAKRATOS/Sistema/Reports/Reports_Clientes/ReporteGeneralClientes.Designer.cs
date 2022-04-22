namespace Sistema.Reports.Reports_Clientes
{
    partial class ReporteGeneralClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteGeneralClientes));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btngenerar = new System.Windows.Forms.ToolStripButton();
            this.checkfechas = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpfechainicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpfechafinal = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbcategoria = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbtipos = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.rbAscent = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbDescen = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtenvios = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.rbwhatsap = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbemail = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbActivos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbTodos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbInactivos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkvarios = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbsucursales = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.rvClientes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.ListarProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbtipos)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListarProductosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btngenerar,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btngenerar
            // 
            this.btngenerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(96, 22);
            this.btngenerar.Text = "Generar Reporte";
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // checkfechas
            // 
            this.checkfechas.Location = new System.Drawing.Point(6, 91);
            this.checkfechas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkfechas.Name = "checkfechas";
            this.checkfechas.Size = new System.Drawing.Size(114, 20);
            this.checkfechas.TabIndex = 5;
            this.checkfechas.Values.Text = "Todas las Fechas";
            this.checkfechas.CheckedChanged += new System.EventHandler(this.checkfechas_CheckedChanged);
            // 
            // dtpfechainicio
            // 
            this.dtpfechainicio.Location = new System.Drawing.Point(95, 25);
            this.dtpfechainicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpfechainicio.Name = "dtpfechainicio";
            this.dtpfechainicio.Size = new System.Drawing.Size(192, 21);
            this.dtpfechainicio.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(4, 58);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Fecha Fin";
            // 
            // dtpfechafinal
            // 
            this.dtpfechafinal.Location = new System.Drawing.Point(95, 58);
            this.dtpfechafinal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpfechafinal.Name = "dtpfechafinal";
            this.dtpfechafinal.Size = new System.Drawing.Size(192, 21);
            this.dtpfechafinal.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(4, 25);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Fecha Inicio";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkfechas);
            this.groupBox1.Controls.Add(this.dtpfechainicio);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.dtpfechafinal);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Location = new System.Drawing.Point(148, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(339, 124);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de Creación";
            // 
            // cbcategoria
            // 
            this.cbcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcategoria.DropDownWidth = 226;
            this.cbcategoria.Location = new System.Drawing.Point(91, 58);
            this.cbcategoria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbcategoria.Name = "cbcategoria";
            this.cbcategoria.Size = new System.Drawing.Size(191, 21);
            this.cbcategoria.TabIndex = 1;
            // 
            // cbtipos
            // 
            this.cbtipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtipos.DropDownWidth = 226;
            this.cbtipos.Location = new System.Drawing.Point(91, 25);
            this.cbtipos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbtipos.Name = "cbtipos";
            this.cbtipos.Size = new System.Drawing.Size(159, 21);
            this.cbtipos.TabIndex = 0;
            // 
            // rbAscent
            // 
            this.rbAscent.Location = new System.Drawing.Point(18, 17);
            this.rbAscent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbAscent.Name = "rbAscent";
            this.rbAscent.Size = new System.Drawing.Size(86, 20);
            this.rbAscent.TabIndex = 1;
            this.rbAscent.Values.Text = "Ascendente";
            // 
            // rbDescen
            // 
            this.rbDescen.Location = new System.Drawing.Point(21, 41);
            this.rbDescen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbDescen.Name = "rbDescen";
            this.rbDescen.Size = new System.Drawing.Size(93, 20);
            this.rbDescen.TabIndex = 0;
            this.rbDescen.Values.Text = "Descendente";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.rbAscent);
            this.groupBox3.Controls.Add(this.rbDescen);
            this.groupBox3.Location = new System.Drawing.Point(834, 28);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(147, 124);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordenar por nombre";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.groupBox5);
            this.kryptonPanel2.Controls.Add(this.groupBox4);
            this.kryptonPanel2.Controls.Add(this.groupBox3);
            this.kryptonPanel2.Controls.Add(this.groupBox2);
            this.kryptonPanel2.Controls.Add(this.groupBox1);
            this.kryptonPanel2.Controls.Add(this.toolStrip1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1028, 154);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.txtenvios);
            this.groupBox5.Controls.Add(this.rbwhatsap);
            this.groupBox5.Controls.Add(this.rbemail);
            this.groupBox5.Location = new System.Drawing.Point(985, 28);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(107, 124);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Envios";
            // 
            // txtenvios
            // 
            this.txtenvios.Location = new System.Drawing.Point(11, 76);
            this.txtenvios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtenvios.Name = "txtenvios";
            this.txtenvios.Size = new System.Drawing.Size(92, 23);
            this.txtenvios.TabIndex = 2;
            // 
            // rbwhatsap
            // 
            this.rbwhatsap.Location = new System.Drawing.Point(11, 48);
            this.rbwhatsap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbwhatsap.Name = "rbwhatsap";
            this.rbwhatsap.Size = new System.Drawing.Size(78, 20);
            this.rbwhatsap.TabIndex = 1;
            this.rbwhatsap.Values.Text = "Whatsapp";
            // 
            // rbemail
            // 
            this.rbemail.Location = new System.Drawing.Point(11, 24);
            this.rbemail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbemail.Name = "rbemail";
            this.rbemail.Size = new System.Drawing.Size(52, 20);
            this.rbemail.TabIndex = 0;
            this.rbemail.Values.Text = "Email";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.rbActivos);
            this.groupBox4.Controls.Add(this.rbTodos);
            this.groupBox4.Controls.Add(this.rbInactivos);
            this.groupBox4.Location = new System.Drawing.Point(9, 28);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(136, 124);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Clientes";
            // 
            // rbActivos
            // 
            this.rbActivos.Location = new System.Drawing.Point(4, 17);
            this.rbActivos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(89, 20);
            this.rbActivos.TabIndex = 9;
            this.rbActivos.Values.Text = "Solo Activos";
            // 
            // rbTodos
            // 
            this.rbTodos.Location = new System.Drawing.Point(4, 78);
            this.rbTodos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(56, 20);
            this.rbTodos.TabIndex = 8;
            this.rbTodos.Values.Text = "Todos";
            // 
            // rbInactivos
            // 
            this.rbInactivos.Location = new System.Drawing.Point(4, 48);
            this.rbInactivos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbInactivos.Name = "rbInactivos";
            this.rbInactivos.Size = new System.Drawing.Size(98, 20);
            this.rbInactivos.TabIndex = 6;
            this.rbInactivos.Values.Text = "Solo Inactivos";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.checkvarios);
            this.groupBox2.Controls.Add(this.kryptonLabel5);
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Controls.Add(this.kryptonLabel3);
            this.groupBox2.Controls.Add(this.cbsucursales);
            this.groupBox2.Controls.Add(this.cbcategoria);
            this.groupBox2.Controls.Add(this.cbtipos);
            this.groupBox2.Location = new System.Drawing.Point(492, 28);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(338, 124);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro de Clientes";
            // 
            // checkvarios
            // 
            this.checkvarios.Location = new System.Drawing.Point(254, 26);
            this.checkvarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkvarios.Name = "checkvarios";
            this.checkvarios.Size = new System.Drawing.Size(89, 20);
            this.checkvarios.TabIndex = 7;
            this.checkvarios.Values.Text = "Elegir varios";
            this.checkvarios.CheckedChanged += new System.EventHandler(this.checkvarios_CheckedChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(4, 25);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(34, 20);
            this.kryptonLabel5.TabIndex = 5;
            this.kryptonLabel5.Values.Text = "Tipo";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(4, 58);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel4.TabIndex = 4;
            this.kryptonLabel4.Values.Text = "Categoria";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(4, 92);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Sucursal";
            // 
            // cbsucursales
            // 
            this.cbsucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsucursales.DropDownWidth = 226;
            this.cbsucursales.Location = new System.Drawing.Point(91, 91);
            this.cbsucursales.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbsucursales.Name = "cbsucursales";
            this.cbsucursales.Size = new System.Drawing.Size(191, 21);
            this.cbsucursales.TabIndex = 2;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.rvClientes);
            this.kryptonPanel3.Location = new System.Drawing.Point(2, 154);
            this.kryptonPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(1086, 391);
            this.kryptonPanel3.TabIndex = 1;
            // 
            // rvClientes
            // 
            this.rvClientes.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Clientes.ReporteGeneralClientes.rdlc";
            this.rvClientes.Location = new System.Drawing.Point(0, 0);
            this.rvClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rvClientes.Name = "rvClientes";
            this.rvClientes.ServerReport.BearerToken = null;
            this.rvClientes.Size = new System.Drawing.Size(1084, 391);
            this.rvClientes.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonPanel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1028, 552);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // ListarProductosBindingSource
            // 
            this.ListarProductosBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarProductos);
            // 
            // ReporteGeneralClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 552);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReporteGeneralClientes";
            this.Text = "ReporteGeneralClientes";
            this.Load += new System.EventHandler(this.ReporteGeneralClientes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbtipos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListarProductosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btngenerar;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkfechas;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechainicio;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechafinal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbcategoria;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbtipos;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbAscent;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbDescen;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private Microsoft.Reporting.WinForms.ReportViewer rvClientes;
        private System.Windows.Forms.BindingSource ListarProductosBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbsucursales;
        private System.Windows.Forms.GroupBox groupBox5;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbwhatsap;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbemail;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtenvios;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbActivos;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbTodos;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbInactivos;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkvarios;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}