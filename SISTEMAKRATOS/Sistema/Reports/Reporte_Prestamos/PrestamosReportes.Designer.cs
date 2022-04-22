namespace Sistema.Reports.Reporte_Prestamos
{
    partial class PrestamosReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrestamosReportes));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.rvPrestamosGenerales = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioendeuda = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbTodos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radioFiniquito = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btngenerarreporte = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.rbAscent = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbDescen = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboclientes = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.comboamortizacion = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbtipos = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkfechas = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpfechainicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpfechafinal = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboclientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboamortizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbtipos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1091, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.rvPrestamosGenerales);
            this.kryptonPanel1.Controls.Add(this.groupBox4);
            this.kryptonPanel1.Controls.Add(this.groupBox3);
            this.kryptonPanel1.Controls.Add(this.groupBox2);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1091, 647);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // rvPrestamosGenerales
            // 
            this.rvPrestamosGenerales.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Prestamos.PrestamosReporte.rdlc";
            this.rvPrestamosGenerales.Location = new System.Drawing.Point(1, 140);
            this.rvPrestamosGenerales.Name = "rvPrestamosGenerales";
            this.rvPrestamosGenerales.ServerReport.BearerToken = null;
            this.rvPrestamosGenerales.Size = new System.Drawing.Size(1083, 504);
            this.rvPrestamosGenerales.TabIndex = 14;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.radioendeuda);
            this.groupBox4.Controls.Add(this.rbTodos);
            this.groupBox4.Controls.Add(this.radioFiniquito);
            this.groupBox4.Location = new System.Drawing.Point(5, 11);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(135, 124);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Estado";
            // 
            // radioendeuda
            // 
            this.radioendeuda.Location = new System.Drawing.Point(4, 17);
            this.radioendeuda.Margin = new System.Windows.Forms.Padding(2);
            this.radioendeuda.Name = "radioendeuda";
            this.radioendeuda.Size = new System.Drawing.Size(73, 20);
            this.radioendeuda.TabIndex = 9;
            this.radioendeuda.Values.Text = "En deuda";
            // 
            // rbTodos
            // 
            this.rbTodos.Location = new System.Drawing.Point(4, 78);
            this.rbTodos.Margin = new System.Windows.Forms.Padding(2);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(56, 20);
            this.rbTodos.TabIndex = 8;
            this.rbTodos.Values.Text = "Todos";
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // radioFiniquito
            // 
            this.radioFiniquito.Location = new System.Drawing.Point(4, 48);
            this.radioFiniquito.Margin = new System.Windows.Forms.Padding(2);
            this.radioFiniquito.Name = "radioFiniquito";
            this.radioFiniquito.Size = new System.Drawing.Size(84, 20);
            this.radioFiniquito.TabIndex = 6;
            this.radioFiniquito.Values.Text = "Finiquitado";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btngenerarreporte);
            this.groupBox3.Controls.Add(this.rbAscent);
            this.groupBox3.Controls.Add(this.rbDescen);
            this.groupBox3.Location = new System.Drawing.Point(826, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(258, 124);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Monto otorgado";
            // 
            // btngenerarreporte
            // 
            this.btngenerarreporte.Location = new System.Drawing.Point(142, 81);
            this.btngenerarreporte.Name = "btngenerarreporte";
            this.btngenerarreporte.Size = new System.Drawing.Size(111, 31);
            this.btngenerarreporte.TabIndex = 2;
            this.btngenerarreporte.Values.Text = "Generar Reporte";
            this.btngenerarreporte.Click += new System.EventHandler(this.btngenerarreporte_Click);
            // 
            // rbAscent
            // 
            this.rbAscent.Location = new System.Drawing.Point(18, 17);
            this.rbAscent.Margin = new System.Windows.Forms.Padding(2);
            this.rbAscent.Name = "rbAscent";
            this.rbAscent.Size = new System.Drawing.Size(86, 20);
            this.rbAscent.TabIndex = 1;
            this.rbAscent.Values.Text = "Ascendente";
            // 
            // rbDescen
            // 
            this.rbDescen.Location = new System.Drawing.Point(21, 41);
            this.rbDescen.Margin = new System.Windows.Forms.Padding(2);
            this.rbDescen.Name = "rbDescen";
            this.rbDescen.Size = new System.Drawing.Size(93, 20);
            this.rbDescen.TabIndex = 0;
            this.rbDescen.Values.Text = "Descendente";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.kryptonLabel5);
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Controls.Add(this.kryptonLabel3);
            this.groupBox2.Controls.Add(this.comboclientes);
            this.groupBox2.Controls.Add(this.comboamortizacion);
            this.groupBox2.Controls.Add(this.cbtipos);
            this.groupBox2.Location = new System.Drawing.Point(484, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(338, 124);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro de Clientes";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(4, 25);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(34, 20);
            this.kryptonLabel5.TabIndex = 5;
            this.kryptonLabel5.Values.Text = "Tipo";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(4, 58);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel4.TabIndex = 4;
            this.kryptonLabel4.Values.Text = "Amortizacion";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(4, 92);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Cliente";
            // 
            // comboclientes
            // 
            this.comboclientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboclientes.DropDownWidth = 226;
            this.comboclientes.Location = new System.Drawing.Point(91, 91);
            this.comboclientes.Margin = new System.Windows.Forms.Padding(2);
            this.comboclientes.Name = "comboclientes";
            this.comboclientes.Size = new System.Drawing.Size(191, 21);
            this.comboclientes.TabIndex = 2;
            // 
            // comboamortizacion
            // 
            this.comboamortizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboamortizacion.DropDownWidth = 226;
            this.comboamortizacion.Location = new System.Drawing.Point(91, 58);
            this.comboamortizacion.Margin = new System.Windows.Forms.Padding(2);
            this.comboamortizacion.Name = "comboamortizacion";
            this.comboamortizacion.Size = new System.Drawing.Size(191, 21);
            this.comboamortizacion.TabIndex = 1;
            // 
            // cbtipos
            // 
            this.cbtipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtipos.DropDownWidth = 226;
            this.cbtipos.Location = new System.Drawing.Point(91, 25);
            this.cbtipos.Margin = new System.Windows.Forms.Padding(2);
            this.cbtipos.Name = "cbtipos";
            this.cbtipos.Size = new System.Drawing.Size(191, 21);
            this.cbtipos.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkfechas);
            this.groupBox1.Controls.Add(this.dtpfechainicio);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.dtpfechafinal);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Location = new System.Drawing.Point(140, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(339, 124);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de Creación";
            // 
            // checkfechas
            // 
            this.checkfechas.Location = new System.Drawing.Point(6, 91);
            this.checkfechas.Margin = new System.Windows.Forms.Padding(2);
            this.checkfechas.Name = "checkfechas";
            this.checkfechas.Size = new System.Drawing.Size(114, 20);
            this.checkfechas.TabIndex = 5;
            this.checkfechas.Values.Text = "Todas las Fechas";
            this.checkfechas.CheckedChanged += new System.EventHandler(this.checkfechas_CheckedChanged);
            // 
            // dtpfechainicio
            // 
            this.dtpfechainicio.Location = new System.Drawing.Point(95, 25);
            this.dtpfechainicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpfechainicio.Name = "dtpfechainicio";
            this.dtpfechainicio.Size = new System.Drawing.Size(192, 21);
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
            this.dtpfechafinal.Location = new System.Drawing.Point(95, 58);
            this.dtpfechafinal.Margin = new System.Windows.Forms.Padding(2);
            this.dtpfechafinal.Name = "dtpfechafinal";
            this.dtpfechafinal.Size = new System.Drawing.Size(192, 21);
            this.dtpfechafinal.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(4, 25);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Fecha Inicio";
            // 
            // PrestamosReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 672);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrestamosReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PretamosReportes";
            this.Load += new System.EventHandler(this.PrestamosReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboclientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboamortizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbtipos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioendeuda;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbTodos;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioFiniquito;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboclientes;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboamortizacion;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbtipos;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkfechas;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechainicio;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechafinal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Microsoft.Reporting.WinForms.ReportViewer rvPrestamosGenerales;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbAscent;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbDescen;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btngenerarreporte;
    }
}