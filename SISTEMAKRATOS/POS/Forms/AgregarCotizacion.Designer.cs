namespace POS.Forms
{
    partial class AgregarCotizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarCotizacion));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btncobrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtbuscarcotiza = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnAgregarVenta = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgvCotizaciones = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btncobrar,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(756, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btncobrar
            // 
            this.btncobrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncobrar.Name = "btncobrar";
            this.btncobrar.Size = new System.Drawing.Size(47, 22);
            this.btncobrar.Text = "Detalle";
            this.btncobrar.Click += new System.EventHandler(this.btncobrar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonPanel1.Size = new System.Drawing.Size(756, 442);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.8F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvCotizaciones, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.636364F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.36364F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 442);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 508F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtbuscarcotiza, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAgregarVenta, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(752, 28);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(114, 24);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Buscar";
            // 
            // txtbuscarcotiza
            // 
            this.txtbuscarcotiza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbuscarcotiza.Location = new System.Drawing.Point(120, 2);
            this.txtbuscarcotiza.Margin = new System.Windows.Forms.Padding(2);
            this.txtbuscarcotiza.Name = "txtbuscarcotiza";
            this.txtbuscarcotiza.Size = new System.Drawing.Size(504, 23);
            this.txtbuscarcotiza.TabIndex = 1;
            this.txtbuscarcotiza.TextChanged += new System.EventHandler(this.txtbuscarcotiza_TextChanged);
            // 
            // btnAgregarVenta
            // 
            this.btnAgregarVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarVenta.Location = new System.Drawing.Point(628, 2);
            this.btnAgregarVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarVenta.Name = "btnAgregarVenta";
            this.btnAgregarVenta.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnAgregarVenta.Size = new System.Drawing.Size(122, 24);
            this.btnAgregarVenta.TabIndex = 2;
            this.btnAgregarVenta.Values.Text = "Agregar a venta";
            this.btnAgregarVenta.Click += new System.EventHandler(this.btnAgregarVenta_Click);
            // 
            // dgvCotizaciones
            // 
            this.dgvCotizaciones.AllowUserToAddRows = false;
            this.dgvCotizaciones.AllowUserToDeleteRows = false;
            this.dgvCotizaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCotizaciones.Location = new System.Drawing.Point(2, 35);
            this.dgvCotizaciones.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCotizaciones.Name = "dgvCotizaciones";
            this.dgvCotizaciones.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.dgvCotizaciones.ReadOnly = true;
            this.dgvCotizaciones.RowHeadersWidth = 51;
            this.dgvCotizaciones.RowTemplate.Height = 24;
            this.dgvCotizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCotizaciones.Size = new System.Drawing.Size(752, 405);
            this.dgvCotizaciones.TabIndex = 1;
            this.dgvCotizaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCotizaciones_CellClick);
            // 
            // AgregarCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 467);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AgregarCotizacion";
            this.Text = "AgregarCotizacion";
            this.Load += new System.EventHandler(this.AgregarCotizacion_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btncobrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscarcotiza;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvCotizaciones;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregarVenta;
    }
}