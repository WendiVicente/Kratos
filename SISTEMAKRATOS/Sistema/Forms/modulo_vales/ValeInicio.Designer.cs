namespace Sistema.Forms.modulo_vales
{
    partial class ValeInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValeInicio));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnguardar = new System.Windows.Forms.ToolStripButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAunPersonal = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtcantidad = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtmontoindividual = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.checkClientes = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.combotipos = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbcorrelVale = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMonto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbfecha = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtdescrip = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAunPersonal)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combotipos)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnguardar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(522, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnguardar
            // 
            this.btnguardar.Image = global::Sistema.Properties.Resources.SaveStatusBar1_16x;
            this.btnguardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(73, 24);
            this.btnguardar.Text = "Guardar";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(522, 519);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.dgvAunPersonal, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 207);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 397);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgvAunPersonal
            // 
            this.dgvAunPersonal.AllowUserToAddRows = false;
            this.dgvAunPersonal.AllowUserToDeleteRows = false;
            this.dgvAunPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAunPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAunPersonal.Location = new System.Drawing.Point(2, 2);
            this.dgvAunPersonal.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAunPersonal.Name = "dgvAunPersonal";
            this.dgvAunPersonal.RowHeadersWidth = 51;
            this.dgvAunPersonal.RowTemplate.Height = 24;
            this.dgvAunPersonal.Size = new System.Drawing.Size(483, 377);
            this.dgvAunPersonal.TabIndex = 2;
            this.dgvAunPersonal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAunPersonal_CellContentClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel8, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(522, 207);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.72603F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.27397F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel8.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.txtcantidad, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.kryptonLabel6, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.txtmontoindividual, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.checkClientes, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(2, 131);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(518, 59);
            this.tableLayoutPanel8.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Cantidad";
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(116, 2);
            this.txtcantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(169, 23);
            this.txtcantidad.TabIndex = 1;
            this.txtcantidad.TextChanged += new System.EventHandler(this.txtcantidad_TextChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(2, 33);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(104, 20);
            this.kryptonLabel6.TabIndex = 2;
            this.kryptonLabel6.Values.Text = "Monto Individual";
            // 
            // txtmontoindividual
            // 
            this.txtmontoindividual.Location = new System.Drawing.Point(116, 33);
            this.txtmontoindividual.Margin = new System.Windows.Forms.Padding(2);
            this.txtmontoindividual.Name = "txtmontoindividual";
            this.txtmontoindividual.Size = new System.Drawing.Size(169, 23);
            this.txtmontoindividual.TabIndex = 3;
            // 
            // checkClientes
            // 
            this.checkClientes.Location = new System.Drawing.Point(289, 33);
            this.checkClientes.Margin = new System.Windows.Forms.Padding(2);
            this.checkClientes.Name = "checkClientes";
            this.checkClientes.Size = new System.Drawing.Size(130, 20);
            this.checkClientes.TabIndex = 4;
            this.checkClientes.Values.Text = "Seleccionar clientes";
            this.checkClientes.CheckedChanged += new System.EventHandler(this.checkClientes_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.39519F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.60481F));
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.combotipos, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(289, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(227, 27);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel7.TabIndex = 0;
            this.kryptonLabel7.Values.Text = "Tipo Vale";
            // 
            // combotipos
            // 
            this.combotipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combotipos.DropDownWidth = 229;
            this.combotipos.Location = new System.Drawing.Point(82, 2);
            this.combotipos.Margin = new System.Windows.Forms.Padding(2);
            this.combotipos.Name = "combotipos";
            this.combotipos.Size = new System.Drawing.Size(143, 21);
            this.combotipos.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.46066F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.53934F));
            this.tableLayoutPanel4.Controls.Add(this.kryptonLabel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbcorrelVale, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(518, 29);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel2.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(112, 25);
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Values.Text = "No. Vale";
            // 
            // lbcorrelVale
            // 
            this.lbcorrelVale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbcorrelVale.Location = new System.Drawing.Point(119, 3);
            this.lbcorrelVale.Name = "lbcorrelVale";
            this.lbcorrelVale.Size = new System.Drawing.Size(396, 23);
            this.lbcorrelVale.TabIndex = 1;
            this.lbcorrelVale.Values.Text = "";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.49284F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.50716F));
            this.tableLayoutPanel7.Controls.Add(this.kryptonLabel5, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.txtMonto, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(2, 99);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(518, 28);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel5.TabIndex = 1;
            this.kryptonLabel5.Values.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMonto.Location = new System.Drawing.Point(118, 2);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(2);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(398, 23);
            this.txtMonto.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.54335F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.45665F));
            this.tableLayoutPanel6.Controls.Add(this.kryptonLabel4, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbfecha, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(2, 35);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(518, 28);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel4.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(112, 24);
            this.kryptonLabel4.TabIndex = 1;
            this.kryptonLabel4.Values.Text = "Fecha:";
            // 
            // lbfecha
            // 
            this.lbfecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbfecha.Location = new System.Drawing.Point(118, 2);
            this.lbfecha.Margin = new System.Windows.Forms.Padding(2);
            this.lbfecha.Name = "lbfecha";
            this.lbfecha.Size = new System.Drawing.Size(398, 24);
            this.lbfecha.TabIndex = 2;
            this.lbfecha.Values.Text = "DD/MM/YY-YY";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.46377F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.53623F));
            this.tableLayoutPanel5.Controls.Add(this.kryptonLabel3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtdescrip, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 67);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(518, 28);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(77, 20);
            this.kryptonLabel3.TabIndex = 1;
            this.kryptonLabel3.Values.Text = "Descripción:";
            // 
            // txtdescrip
            // 
            this.txtdescrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtdescrip.Location = new System.Drawing.Point(118, 2);
            this.txtdescrip.Margin = new System.Windows.Forms.Padding(2);
            this.txtdescrip.Name = "txtdescrip";
            this.txtdescrip.Size = new System.Drawing.Size(398, 23);
            this.txtdescrip.TabIndex = 2;
            // 
            // ValeInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 546);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ValeInicio";
            this.Text = "ValeInicio";
            this.Load += new System.EventHandler(this.ValeInicio_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAunPersonal)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combotipos)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMonto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbfecha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtdescrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvAunPersonal;
        private System.Windows.Forms.ToolStripButton btnguardar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcantidad;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtmontoindividual;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkClientes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox combotipos;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbcorrelVale;
    }
}