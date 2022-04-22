namespace Sistema.Reports.Reports_Productos
{
    partial class ReporteUtilidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteUtilidad));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnreporteGeneral = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.reporteUtil = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAscent = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbDescen = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbcategoria = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbsucursales = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkfechas = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpfechainicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpfechafinal = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnreporteGeneral,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1101, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnreporteGeneral
            // 
            this.btnreporteGeneral.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnreporteGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnreporteGeneral.Image")));
            this.btnreporteGeneral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnreporteGeneral.Name = "btnreporteGeneral";
            this.btnreporteGeneral.Size = new System.Drawing.Size(95, 22);
            this.btnreporteGeneral.Text = "Reporte General";
            this.btnreporteGeneral.Click += new System.EventHandler(this.btnreporteGeneral_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.reporteUtil);
            this.kryptonPanel1.Controls.Add(this.groupBox3);
            this.kryptonPanel1.Controls.Add(this.groupBox2);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1101, 647);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // reporteUtil
            // 
            this.reporteUtil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reporteUtil.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Productos.ReporteUTIL.rdlc";
            this.reporteUtil.Location = new System.Drawing.Point(4, 162);
            this.reporteUtil.Name = "reporteUtil";
            this.reporteUtil.ServerReport.BearerToken = null;
            this.reporteUtil.Size = new System.Drawing.Size(1084, 473);
            this.reporteUtil.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.rbAscent);
            this.groupBox3.Controls.Add(this.rbDescen);
            this.groupBox3.Location = new System.Drawing.Point(861, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(227, 153);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordenar por Stock";
            // 
            // rbAscent
            // 
            this.rbAscent.Location = new System.Drawing.Point(15, 72);
            this.rbAscent.Name = "rbAscent";
            this.rbAscent.Size = new System.Drawing.Size(86, 20);
            this.rbAscent.TabIndex = 1;
            this.rbAscent.Values.Text = "Ascendente";
            // 
            // rbDescen
            // 
            this.rbDescen.Location = new System.Drawing.Point(15, 42);
            this.rbDescen.Name = "rbDescen";
            this.rbDescen.Size = new System.Drawing.Size(93, 20);
            this.rbDescen.TabIndex = 0;
            this.rbDescen.Values.Text = "Descendente";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbcategoria);
            this.groupBox2.Controls.Add(this.cbsucursales);
            this.groupBox2.Location = new System.Drawing.Point(462, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 153);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // cbcategoria
            // 
            this.cbcategoria.DropDownWidth = 226;
            this.cbcategoria.Location = new System.Drawing.Point(15, 71);
            this.cbcategoria.Name = "cbcategoria";
            this.cbcategoria.Size = new System.Drawing.Size(282, 21);
            this.cbcategoria.TabIndex = 1;
            this.cbcategoria.Text = "Categoria";
            // 
            // cbsucursales
            // 
            this.cbsucursales.DropDownWidth = 226;
            this.cbsucursales.Location = new System.Drawing.Point(15, 31);
            this.cbsucursales.Name = "cbsucursales";
            this.cbsucursales.Size = new System.Drawing.Size(282, 21);
            this.cbsucursales.TabIndex = 0;
            this.cbsucursales.Text = "Sucursales";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkfechas);
            this.groupBox1.Controls.Add(this.dtpfechainicio);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.dtpfechafinal);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 153);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fechas";
            // 
            // checkfechas
            // 
            this.checkfechas.Location = new System.Drawing.Point(8, 112);
            this.checkfechas.Name = "checkfechas";
            this.checkfechas.Size = new System.Drawing.Size(114, 20);
            this.checkfechas.TabIndex = 5;
            this.checkfechas.Values.Text = "Todas las Fechas";
            this.checkfechas.CheckedChanged += new System.EventHandler(this.checkfechas_CheckedChanged);
            // 
            // dtpfechainicio
            // 
            this.dtpfechainicio.Location = new System.Drawing.Point(127, 31);
            this.dtpfechainicio.Name = "dtpfechainicio";
            this.dtpfechainicio.Size = new System.Drawing.Size(256, 21);
            this.dtpfechainicio.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 71);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Fecha Fin";
            // 
            // dtpfechafinal
            // 
            this.dtpfechafinal.Location = new System.Drawing.Point(127, 71);
            this.dtpfechafinal.Name = "dtpfechafinal";
            this.dtpfechafinal.Size = new System.Drawing.Size(256, 21);
            this.dtpfechafinal.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 31);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Fecha Inicio";
            // 
            // ReporteUtilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 672);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteUtilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReporteUtilidad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteUtilidad_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbcategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnreporteGeneral;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbAscent;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbDescen;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbcategoria;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbsucursales;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkfechas;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechainicio;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechafinal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Microsoft.Reporting.WinForms.ReportViewer reporteUtil;
    }
}