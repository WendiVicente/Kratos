namespace Sistema.Forms.modulo_Bancos
{
    partial class VerTransacciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerTransacciones));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bntES = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnacciones = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnoperaciones = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btncuantatocaja = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevaTransac = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvlistaTransacc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkTodas = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistaTransacc)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.bntES,
            this.toolStripSeparator3,
            this.toolStripSeparator5,
            this.toolStripButton5,
            this.toolStripSeparator4,
            this.btnoperaciones,
            this.toolStripSeparator6,
            this.btncuantatocaja,
            this.toolStripSeparator7,
            this.btnNuevaTransac,
            this.toolStripSeparator8,
            this.btnacciones});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1109, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bntES
            // 
            this.bntES.Image = global::Sistema.Properties.Resources.MoneyEditor_16x;
            this.bntES.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntES.Name = "bntES";
            this.bntES.Size = new System.Drawing.Size(154, 24);
            this.bntES.Text = "Ingresos y Egresos";
            this.bntES.Click += new System.EventHandler(this.bntES_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnacciones
            // 
            this.btnacciones.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
            this.btnacciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnacciones.Name = "btnacciones";
            this.btnacciones.Size = new System.Drawing.Size(102, 24);
            this.btnacciones.Text = "Validación";
            this.btnacciones.Click += new System.EventHandler(this.btnacciones_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = global::Sistema.Properties.Resources.HistoryTable_16x;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(110, 24);
            this.toolStripButton5.Text = "Ver Cuentas";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btnoperaciones
            // 
            this.btnoperaciones.Image = global::Sistema.Properties.Resources.MoneyEditor_16x;
            this.btnoperaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnoperaciones.Name = "btnoperaciones";
            this.btnoperaciones.Size = new System.Drawing.Size(141, 24);
            this.btnoperaciones.Text = "Cuenta a Cuenta";
            this.btnoperaciones.Click += new System.EventHandler(this.btnoperaciones_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // btncuantatocaja
            // 
            this.btncuantatocaja.Image = global::Sistema.Properties.Resources.MoneyEditor_16x;
            this.btncuantatocaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncuantatocaja.Name = "btncuantatocaja";
            this.btncuantatocaja.Size = new System.Drawing.Size(124, 24);
            this.btncuantatocaja.Text = "Cuenta a Caja";
            this.btncuantatocaja.Click += new System.EventHandler(this.btncuantatocaja_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // btnNuevaTransac
            // 
            this.btnNuevaTransac.Image = global::Sistema.Properties.Resources.OrderDown_16x;
            this.btnNuevaTransac.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevaTransac.Name = "btnNuevaTransac";
            this.btnNuevaTransac.Size = new System.Drawing.Size(124, 24);
            this.btnNuevaTransac.Text = "Caja a Cuenta";
            this.btnNuevaTransac.Click += new System.EventHandler(this.btnNuevaTransac_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1109, 461);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvlistaTransacc, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.72482F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.27518F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1109, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvlistaTransacc
            // 
            this.dgvlistaTransacc.AllowUserToAddRows = false;
            this.dgvlistaTransacc.AllowUserToDeleteRows = false;
            this.dgvlistaTransacc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvlistaTransacc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlistaTransacc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlistaTransacc.Location = new System.Drawing.Point(3, 109);
            this.dgvlistaTransacc.Name = "dgvlistaTransacc";
            this.dgvlistaTransacc.ReadOnly = true;
            this.dgvlistaTransacc.RowHeadersWidth = 51;
            this.dgvlistaTransacc.RowTemplate.Height = 24;
            this.dgvlistaTransacc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlistaTransacc.Size = new System.Drawing.Size(1103, 349);
            this.dgvlistaTransacc.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.29102F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.708975F));
            this.tableLayoutPanel2.Controls.Add(this.checkTodas, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 69);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1103, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // checkTodas
            // 
            this.checkTodas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkTodas.Location = new System.Drawing.Point(1031, 3);
            this.checkTodas.Name = "checkTodas";
            this.checkTodas.Size = new System.Drawing.Size(69, 28);
            this.checkTodas.TabIndex = 0;
            this.checkTodas.Values.Text = "Todos";
            this.checkTodas.CheckedChanged += new System.EventHandler(this.checkTodas_CheckedChanged);
            // 
            // VerTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 488);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerTransacciones";
            this.Text = "Transacciones";
            this.Load += new System.EventHandler(this.Transacciones_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistaTransacc)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevaTransac;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvlistaTransacc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkTodas;
        private System.Windows.Forms.ToolStripButton bntES;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnacciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnoperaciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btncuantatocaja;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}