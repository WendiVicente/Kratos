namespace Sistema.Reports.Reports_Productos
{
    partial class ReporteProducto
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteProducto));
            this.ListarProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.rvproductos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btngenerar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.ListarProductosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListarProductosBindingSource
            // 
            this.ListarProductosBindingSource.DataSource = typeof(CapaDatos.ListasPersonalizadas.ListarProductos);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonPanel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1315, 682);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.rvproductos);
            this.kryptonPanel3.Location = new System.Drawing.Point(3, 189);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(1312, 481);
            this.kryptonPanel3.TabIndex = 1;
            // 
            // rvproductos
            // 
            this.rvproductos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "listaproductos";
            reportDataSource1.Value = this.ListarProductosBindingSource;
            this.rvproductos.LocalReport.DataSources.Add(reportDataSource1);
            this.rvproductos.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Productos.ReporteProducto.rdlc";
            this.rvproductos.Location = new System.Drawing.Point(0, 0);
            this.rvproductos.Name = "rvproductos";
            this.rvproductos.ServerReport.BearerToken = null;
            this.rvproductos.Size = new System.Drawing.Size(1312, 481);
            this.rvproductos.TabIndex = 0;
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
            this.kryptonPanel2.Size = new System.Drawing.Size(1315, 190);
            this.kryptonPanel2.TabIndex = 1;
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbcategoria);
            this.groupBox2.Controls.Add(this.cbsucursales);
            this.groupBox2.Location = new System.Drawing.Point(470, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 153);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // cbcategoria
            // 
            this.cbcategoria.DropDownWidth = 226;
            this.cbcategoria.Location = new System.Drawing.Point(15, 71);
            this.cbcategoria.Name = "cbcategoria";
            this.cbcategoria.Size = new System.Drawing.Size(282, 25);
            this.cbcategoria.TabIndex = 1;
            this.cbcategoria.Text = "Categoria";
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
            // checkfechas
            // 
            this.checkfechas.Location = new System.Drawing.Point(8, 112);
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
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btngenerar,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1315, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btngenerar
            // 
            this.btngenerar.Image = global::Sistema.Properties.Resources.HistoryTable_16x;
            this.btngenerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(142, 24);
            this.btngenerar.Text = "Generar Reporte";
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // ReporteProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 682);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteProducto";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.ReporteProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListarProductosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbcategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private System.Windows.Forms.ToolStripButton btngenerar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Microsoft.Reporting.WinForms.ReportViewer rvproductos;
        private System.Windows.Forms.BindingSource ListarProductosBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
    }
}