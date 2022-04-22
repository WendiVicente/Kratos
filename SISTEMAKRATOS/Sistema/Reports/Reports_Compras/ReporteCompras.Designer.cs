namespace Sistema.Reports.Reports_Compras
{
    partial class ReporteCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCompras));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lbHistorial = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dgvDetalleprecios = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbbydetalle = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbEncabezado = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonDateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonDateTimePicker2 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dgvcompras = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkfechas = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpfechainicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpfechafinal = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btngenerarReporte = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleprecios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcompras)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lbHistorial);
            this.kryptonPanel1.Controls.Add(this.dgvDetalleprecios);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Controls.Add(this.toolStrip2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1370, 681);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // lbHistorial
            // 
            this.lbHistorial.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lbHistorial.Location = new System.Drawing.Point(986, 121);
            this.lbHistorial.Name = "lbHistorial";
            this.lbHistorial.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleOrange;
            this.lbHistorial.Size = new System.Drawing.Size(204, 20);
            this.lbHistorial.TabIndex = 10;
            this.lbHistorial.Values.ImageTransparentColor = System.Drawing.Color.White;
            this.lbHistorial.Values.Text = "Hilstorial de Precios del Producto";
            this.lbHistorial.Visible = false;
            // 
            // dgvDetalleprecios
            // 
            this.dgvDetalleprecios.AllowUserToAddRows = false;
            this.dgvDetalleprecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleprecios.Location = new System.Drawing.Point(965, 160);
            this.dgvDetalleprecios.Name = "dgvDetalleprecios";
            this.dgvDetalleprecios.Size = new System.Drawing.Size(538, 507);
            this.dgvDetalleprecios.TabIndex = 7;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.groupBox2);
            this.kryptonPanel2.Controls.Add(this.dgvcompras);
            this.kryptonPanel2.Controls.Add(this.groupBox1);
            this.kryptonPanel2.Location = new System.Drawing.Point(3, 28);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(959, 641);
            this.kryptonPanel2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.rbbydetalle);
            this.groupBox2.Controls.Add(this.rbEncabezado);
            this.groupBox2.Controls.Add(this.kryptonDateTimePicker1);
            this.groupBox2.Controls.Add(this.kryptonLabel3);
            this.groupBox2.Controls.Add(this.kryptonDateTimePicker2);
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(339, 124);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccion";
            // 
            // rbbydetalle
            // 
            this.rbbydetalle.Location = new System.Drawing.Point(145, 99);
            this.rbbydetalle.Name = "rbbydetalle";
            this.rbbydetalle.Size = new System.Drawing.Size(100, 20);
            this.rbbydetalle.TabIndex = 6;
            this.rbbydetalle.Values.Text = "Por productos";
            this.rbbydetalle.CheckedChanged += new System.EventHandler(this.rbbydetalle_CheckedChanged);
            // 
            // rbEncabezado
            // 
            this.rbEncabezado.Location = new System.Drawing.Point(6, 99);
            this.rbEncabezado.Name = "rbEncabezado";
            this.rbEncabezado.Size = new System.Drawing.Size(86, 20);
            this.rbEncabezado.TabIndex = 5;
            this.rbEncabezado.Values.Text = "Por compra";
            this.rbEncabezado.CheckedChanged += new System.EventHandler(this.rbEncabezado_CheckedChanged);
            // 
            // kryptonDateTimePicker1
            // 
            this.kryptonDateTimePicker1.Location = new System.Drawing.Point(95, 25);
            this.kryptonDateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
            this.kryptonDateTimePicker1.Size = new System.Drawing.Size(192, 21);
            this.kryptonDateTimePicker1.TabIndex = 1;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(4, 58);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Fecha Fin";
            // 
            // kryptonDateTimePicker2
            // 
            this.kryptonDateTimePicker2.Location = new System.Drawing.Point(95, 58);
            this.kryptonDateTimePicker2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonDateTimePicker2.Name = "kryptonDateTimePicker2";
            this.kryptonDateTimePicker2.Size = new System.Drawing.Size(192, 21);
            this.kryptonDateTimePicker2.TabIndex = 2;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(4, 25);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Fecha Inicio";
            // 
            // dgvcompras
            // 
            this.dgvcompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcompras.Location = new System.Drawing.Point(3, 131);
            this.dgvcompras.Name = "dgvcompras";
            this.dgvcompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcompras.Size = new System.Drawing.Size(953, 507);
            this.dgvcompras.TabIndex = 6;
            this.dgvcompras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcompras_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkfechas);
            this.groupBox1.Controls.Add(this.dtpfechainicio);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.dtpfechafinal);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Location = new System.Drawing.Point(345, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(339, 124);
            this.groupBox1.TabIndex = 5;
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
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btngenerarReporte});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1370, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btngenerarReporte
            // 
            this.btngenerarReporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btngenerarReporte.Image = ((System.Drawing.Image)(resources.GetObject("btngenerarReporte.Image")));
            this.btngenerarReporte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngenerarReporte.Name = "btngenerarReporte";
            this.btngenerarReporte.Size = new System.Drawing.Size(96, 22);
            this.btngenerarReporte.Text = "Generar Reporte";
            this.btngenerarReporte.Visible = false;
            // 
            // ReporteCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 681);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ReporteCompras";
            this.Text = "ReporteCompras";
            this.Load += new System.EventHandler(this.ReporteCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleprecios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcompras)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkfechas;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechainicio;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechafinal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbbydetalle;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbEncabezado;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvcompras;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btngenerarReporte;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDetalleprecios;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbHistorial;
    }
}