namespace Sistema.Reports.Reports_Combos
{
    partial class ReporteCombos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCombos));
            this.ListarCombosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ComboDetalleListaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btngenerar = new System.Windows.Forms.ToolStripButton();
            this.checkfechas = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpfechainicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpfechafinal = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbsucursales = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.rbAscent = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbDescen = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rvcombos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.ListaCombosReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ListarProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ListarCombosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboDetalleListaBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaCombosReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListarProductosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ListarCombosBindingSource
            // 
            this.ListarCombosBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarCombos);
            // 
            // ComboDetalleListaBindingSource
            // 
            this.ComboDetalleListaBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ComboDetalleLista);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
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
            this.toolStrip1.Size = new System.Drawing.Size(1328, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btngenerar
            // 
            this.btngenerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(122, 24);
            this.btngenerar.Text = "Generar Reporte";
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // checkfechas
            // 
            this.checkfechas.Location = new System.Drawing.Point(8, 112);
            this.checkfechas.Name = "checkfechas";
            this.checkfechas.Size = new System.Drawing.Size(138, 24);
            this.checkfechas.TabIndex = 5;
            this.checkfechas.Values.Text = "Todas las Fechas";
            // 
            // dtpfechainicio
            // 
            this.dtpfechainicio.Location = new System.Drawing.Point(127, 31);
            this.dtpfechainicio.Name = "dtpfechainicio";
            this.dtpfechainicio.Size = new System.Drawing.Size(256, 25);
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
            this.dtpfechafinal.Size = new System.Drawing.Size(256, 25);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkfechas);
            this.groupBox1.Controls.Add(this.dtpfechainicio);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.dtpfechafinal);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 153);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de Compra";
            // 
            // cbsucursales
            // 
            this.cbsucursales.DropDownWidth = 226;
            this.cbsucursales.Location = new System.Drawing.Point(15, 31);
            this.cbsucursales.Name = "cbsucursales";
            this.cbsucursales.Size = new System.Drawing.Size(282, 25);
            this.cbsucursales.TabIndex = 0;
            this.cbsucursales.Text = "Sucursales";
            // 
            // rbAscent
            // 
            this.rbAscent.Location = new System.Drawing.Point(15, 72);
            this.rbAscent.Name = "rbAscent";
            this.rbAscent.Size = new System.Drawing.Size(103, 24);
            this.rbAscent.TabIndex = 1;
            this.rbAscent.Values.Text = "Ascendente";
            // 
            // rbDescen
            // 
            this.rbDescen.Location = new System.Drawing.Point(15, 42);
            this.rbDescen.Name = "rbDescen";
            this.rbDescen.Size = new System.Drawing.Size(112, 24);
            this.rbDescen.TabIndex = 0;
            this.rbDescen.Values.Text = "Descendente";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.rbAscent);
            this.groupBox3.Controls.Add(this.rbDescen);
            this.groupBox3.Location = new System.Drawing.Point(869, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(227, 153);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordenar por Stock";
            // 
            // rvcombos
            // 
            this.rvcombos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvcombos.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Combos.ReporteCombos.rdlc";
            this.rvcombos.Location = new System.Drawing.Point(0, 0);
            this.rvcombos.Name = "rvcombos";
            this.rvcombos.ServerReport.BearerToken = null;
            this.rvcombos.Size = new System.Drawing.Size(1322, 664);
            this.rvcombos.TabIndex = 0;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.rvcombos);
            this.kryptonPanel3.Location = new System.Drawing.Point(3, 6);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(1322, 664);
            this.kryptonPanel3.TabIndex = 1;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonPanel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 188);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1328, 523);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbsucursales);
            this.groupBox2.Location = new System.Drawing.Point(470, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 153);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.groupBox3);
            this.kryptonPanel2.Controls.Add(this.groupBox2);
            this.kryptonPanel2.Controls.Add(this.groupBox1);
            this.kryptonPanel2.Controls.Add(this.toolStrip1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1328, 188);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // ListaCombosReporteBindingSource
            // 
            this.ListaCombosReporteBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListaCombosReporte);
            // 
            // ListarProductosBindingSource
            // 
            this.ListarProductosBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarProductos);
            // 
            // ReporteCombos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 711);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteCombos";
            this.Text = "ReporteCombos";
            this.Load += new System.EventHandler(this.ReporteCombos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListarCombosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboDetalleListaBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaCombosReporteBindingSource)).EndInit();
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
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbsucursales;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbAscent;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbDescen;
        private System.Windows.Forms.GroupBox groupBox3;
        private Microsoft.Reporting.WinForms.ReportViewer rvcombos;
        private System.Windows.Forms.BindingSource ListarProductosBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.BindingSource ListaCombosReporteBindingSource;
        private System.Windows.Forms.BindingSource ListarCombosBindingSource;
        private System.Windows.Forms.BindingSource ComboDetalleListaBindingSource;
    }
}