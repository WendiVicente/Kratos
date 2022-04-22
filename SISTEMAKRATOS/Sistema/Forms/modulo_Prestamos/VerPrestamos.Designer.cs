namespace Sistema.Forms.modulo_Prestamos
{
    partial class VerPrestamos
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCuotas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnverPagos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReportePrestamos = new System.Windows.Forms.ToolStripButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnbuscar = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dgvprestamos = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCuotas,
            this.toolStripSeparator1,
            this.btnverPagos,
            this.toolStripSeparator2,
            this.btnReportePrestamos});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCuotas
            // 
            this.btnCuotas.Image = global::Sistema.Properties.Resources.Print_16x;
            this.btnCuotas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCuotas.Name = "btnCuotas";
            this.btnCuotas.Size = new System.Drawing.Size(113, 22);
            this.btnCuotas.Text = "Imprimir Cuotas";
            this.btnCuotas.Click += new System.EventHandler(this.btnCuotas_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnverPagos
            // 
            this.btnverPagos.Image = global::Sistema.Properties.Resources.Print_16x;
            this.btnverPagos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnverPagos.Name = "btnverPagos";
            this.btnverPagos.Size = new System.Drawing.Size(108, 22);
            this.btnverPagos.Text = "Imprimir Pagos";
            this.btnverPagos.Click += new System.EventHandler(this.btnverPagos_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReportePrestamos
            // 
            this.btnReportePrestamos.Image = global::Sistema.Properties.Resources.HistoryTable_16x;
            this.btnReportePrestamos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportePrestamos.Name = "btnReportePrestamos";
            this.btnReportePrestamos.Size = new System.Drawing.Size(126, 22);
            this.btnReportePrestamos.Text = "Reporte Prestamos";
            this.btnReportePrestamos.Click += new System.EventHandler(this.btnReportePrestamos_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 425);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvprestamos, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.35294F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.64706F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 425);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.556675F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.44332F));
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnbuscar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 37);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 14);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Buscar";
            // 
            // btnbuscar
            // 
            this.btnbuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbuscar.Location = new System.Drawing.Point(62, 11);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(729, 23);
            this.btnbuscar.TabIndex = 1;
            this.btnbuscar.TextChanged += new System.EventHandler(this.btnbuscar_TextChanged);
            // 
            // dgvprestamos
            // 
            this.dgvprestamos.AllowUserToAddRows = false;
            this.dgvprestamos.AllowUserToDeleteRows = false;
            this.dgvprestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvprestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvprestamos.Location = new System.Drawing.Point(3, 46);
            this.dgvprestamos.Name = "dgvprestamos";
            this.dgvprestamos.ReadOnly = true;
            this.dgvprestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvprestamos.Size = new System.Drawing.Size(794, 376);
            this.dgvprestamos.TabIndex = 1;
            // 
            // VerPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "VerPrestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VerPrestamos";
            this.Load += new System.EventHandler(this.VerPrestamos_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprestamos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCuotas;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox btnbuscar;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvprestamos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnverPagos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnReportePrestamos;
    }
}