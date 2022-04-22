namespace POS.Forms
{
    partial class VentasPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasPendientes));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregarVenta = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtbuscar = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.pbTrash = new System.Windows.Forms.PictureBox();
            this.dgVentasPendientes = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentasPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgVentasPendientes, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.882353F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.11765F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 425);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.6612F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.3388F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.Controls.Add(this.btnAgregarVenta, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtbuscar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbSelectAll, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.pbTrash, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(796, 37);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnAgregarVenta
            // 
            this.btnAgregarVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarVenta.Location = new System.Drawing.Point(529, 2);
            this.btnAgregarVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarVenta.Name = "btnAgregarVenta";
            this.btnAgregarVenta.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnAgregarVenta.Size = new System.Drawing.Size(106, 33);
            this.btnAgregarVenta.TabIndex = 3;
            this.btnAgregarVenta.Values.Text = "Facturar";
            this.btnAgregarVenta.Click += new System.EventHandler(this.btnAgregarVenta_Click);
            // 
            // txtbuscar
            // 
            this.txtbuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbuscar.Location = new System.Drawing.Point(74, 2);
            this.txtbuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(451, 23);
            this.txtbuscar.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(68, 33);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Buscar";
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(640, 3);
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.Size = new System.Drawing.Size(92, 17);
            this.chbSelectAll.TabIndex = 4;
            this.chbSelectAll.Text = "Select. Todos";
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // pbTrash
            // 
            this.pbTrash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbTrash.Image = ((System.Drawing.Image)(resources.GetObject("pbTrash.Image")));
            this.pbTrash.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbTrash.InitialImage")));
            this.pbTrash.Location = new System.Drawing.Point(745, 3);
            this.pbTrash.Name = "pbTrash";
            this.pbTrash.Size = new System.Drawing.Size(48, 31);
            this.pbTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTrash.TabIndex = 5;
            this.pbTrash.TabStop = false;
            this.pbTrash.Click += new System.EventHandler(this.pbTrash_Click);
            // 
            // dgVentasPendientes
            // 
            this.dgVentasPendientes.AllowUserToAddRows = false;
            this.dgVentasPendientes.AllowUserToDeleteRows = false;
            this.dgVentasPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVentasPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVentasPendientes.Location = new System.Drawing.Point(2, 43);
            this.dgVentasPendientes.Margin = new System.Windows.Forms.Padding(2);
            this.dgVentasPendientes.Name = "dgVentasPendientes";
            this.dgVentasPendientes.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.dgVentasPendientes.ReadOnly = true;
            this.dgVentasPendientes.RowHeadersWidth = 51;
            this.dgVentasPendientes.RowTemplate.Height = 24;
            this.dgVentasPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVentasPendientes.Size = new System.Drawing.Size(796, 380);
            this.dgVentasPendientes.TabIndex = 1;
            this.dgVentasPendientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVentasPendientes_CellClick);
            // 
            // VentasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "VentasPendientes";
            this.Text = "VentasPendientes";
            this.Load += new System.EventHandler(this.VentasPendientes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentasPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregarVenta;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgVentasPendientes;
        private System.Windows.Forms.CheckBox chbSelectAll;
        private System.Windows.Forms.PictureBox pbTrash;
    }
}