namespace Sistema.Forms.modulo_producto
{
    partial class AgregarColorTalla
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
            this.btnAgregarlista = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbcolorespaleta = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbcolorespersonal = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rblistacolores = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.cbcoloresba = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lbcolor = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtcolor = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.rbtallapersonaliz = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.txtmedida = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lbmedida = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.rbcomboTallas = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.txtcantidad = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.comboTallas = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.dgvcolorestallas = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnagregar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Colorpaleta = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcoloresba)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboTallas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcolorestallas)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarlista,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(795, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAgregarlista
            // 
            this.btnAgregarlista.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
            this.btnAgregarlista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarlista.Name = "btnAgregarlista";
            this.btnAgregarlista.Size = new System.Drawing.Size(86, 24);
            this.btnAgregarlista.Text = "Guardar";
            this.btnAgregarlista.Click += new System.EventHandler(this.btnAgregarlista_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(795, 641);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvcolorestallas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.0288F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.9712F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(795, 567);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 228);
            this.panel1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbcolorespaleta);
            this.groupBox2.Controls.Add(this.rbcolorespersonal);
            this.groupBox2.Controls.Add(this.rblistacolores);
            this.groupBox2.Controls.Add(this.cbcoloresba);
            this.groupBox2.Controls.Add(this.lbcolor);
            this.groupBox2.Controls.Add(this.txtcolor);
            this.groupBox2.Location = new System.Drawing.Point(385, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 222);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colores";
            // 
            // rbcolorespaleta
            // 
            this.rbcolorespaleta.Location = new System.Drawing.Point(16, 65);
            this.rbcolorespaleta.Name = "rbcolorespaleta";
            this.rbcolorespaleta.Size = new System.Drawing.Size(112, 24);
            this.rbcolorespaleta.TabIndex = 36;
            this.rbcolorespaleta.Values.Text = "Desde Paleta";
            this.rbcolorespaleta.CheckedChanged += new System.EventHandler(this.rbcolorespaleta_CheckedChanged);
            // 
            // rbcolorespersonal
            // 
            this.rbcolorespersonal.Location = new System.Drawing.Point(16, 107);
            this.rbcolorespersonal.Name = "rbcolorespersonal";
            this.rbcolorespersonal.Size = new System.Drawing.Size(118, 24);
            this.rbcolorespersonal.TabIndex = 35;
            this.rbcolorespersonal.Values.Text = "Personalizado";
            this.rbcolorespersonal.CheckedChanged += new System.EventHandler(this.rbcolorespersonal_CheckedChanged);
            // 
            // rblistacolores
            // 
            this.rblistacolores.Location = new System.Drawing.Point(16, 27);
            this.rblistacolores.Name = "rblistacolores";
            this.rblistacolores.Size = new System.Drawing.Size(141, 24);
            this.rblistacolores.TabIndex = 34;
            this.rblistacolores.Values.Text = "Elegir desde Lista";
            this.rblistacolores.CheckedChanged += new System.EventHandler(this.rblistacolores_CheckedChanged);
            // 
            // cbcoloresba
            // 
            this.cbcoloresba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcoloresba.DropDownWidth = 139;
            this.cbcoloresba.Location = new System.Drawing.Point(183, 27);
            this.cbcoloresba.Name = "cbcoloresba";
            this.cbcoloresba.Size = new System.Drawing.Size(171, 25);
            this.cbcoloresba.TabIndex = 33;
            this.cbcoloresba.SelectedIndexChanged += new System.EventHandler(this.cbcoloresba_SelectedIndexChanged);
            // 
            // lbcolor
            // 
            this.lbcolor.Location = new System.Drawing.Point(167, 104);
            this.lbcolor.Margin = new System.Windows.Forms.Padding(4);
            this.lbcolor.Name = "lbcolor";
            this.lbcolor.Size = new System.Drawing.Size(48, 24);
            this.lbcolor.TabIndex = 32;
            this.lbcolor.Values.Text = "Color";
            // 
            // txtcolor
            // 
            this.txtcolor.Location = new System.Drawing.Point(223, 104);
            this.txtcolor.Margin = new System.Windows.Forms.Padding(4);
            this.txtcolor.Name = "txtcolor";
            this.txtcolor.Size = new System.Drawing.Size(131, 27);
            this.txtcolor.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.rbtallapersonaliz);
            this.groupBox1.Controls.Add(this.txtmedida);
            this.groupBox1.Controls.Add(this.lbmedida);
            this.groupBox1.Controls.Add(this.rbcomboTallas);
            this.groupBox1.Controls.Add(this.txtcantidad);
            this.groupBox1.Controls.Add(this.comboTallas);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 222);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Talla";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(25, 176);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(73, 24);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Cantidad";
            // 
            // rbtallapersonaliz
            // 
            this.rbtallapersonaliz.Location = new System.Drawing.Point(18, 101);
            this.rbtallapersonaliz.Name = "rbtallapersonaliz";
            this.rbtallapersonaliz.Size = new System.Drawing.Size(118, 24);
            this.rbtallapersonaliz.TabIndex = 27;
            this.rbtallapersonaliz.Values.Text = "Personalizado";
            this.rbtallapersonaliz.CheckedChanged += new System.EventHandler(this.rbtallapersonaliz_CheckedChanged);
            // 
            // txtmedida
            // 
            this.txtmedida.Location = new System.Drawing.Point(225, 98);
            this.txtmedida.Margin = new System.Windows.Forms.Padding(4);
            this.txtmedida.Name = "txtmedida";
            this.txtmedida.Size = new System.Drawing.Size(131, 27);
            this.txtmedida.TabIndex = 18;
            // 
            // lbmedida
            // 
            this.lbmedida.Location = new System.Drawing.Point(154, 98);
            this.lbmedida.Margin = new System.Windows.Forms.Padding(4);
            this.lbmedida.Name = "lbmedida";
            this.lbmedida.Size = new System.Drawing.Size(63, 24);
            this.lbmedida.TabIndex = 24;
            this.lbmedida.Values.Text = "Medida";
            // 
            // rbcomboTallas
            // 
            this.rbcomboTallas.Location = new System.Drawing.Point(18, 21);
            this.rbcomboTallas.Name = "rbcomboTallas";
            this.rbcomboTallas.Size = new System.Drawing.Size(141, 24);
            this.rbcomboTallas.TabIndex = 26;
            this.rbcomboTallas.Values.Text = "Elegir desde Lista";
            this.rbcomboTallas.CheckedChanged += new System.EventHandler(this.rbcomboTallas_CheckedChanged);
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(143, 173);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(213, 27);
            this.txtcantidad.TabIndex = 2;
            this.txtcantidad.Text = "0";
            // 
            // comboTallas
            // 
            this.comboTallas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTallas.DropDownWidth = 139;
            this.comboTallas.Location = new System.Drawing.Point(185, 21);
            this.comboTallas.Name = "comboTallas";
            this.comboTallas.Size = new System.Drawing.Size(171, 25);
            this.comboTallas.TabIndex = 25;
            this.comboTallas.SelectedIndexChanged += new System.EventHandler(this.comboTallas_SelectedIndexChanged);
            // 
            // dgvcolorestallas
            // 
            this.dgvcolorestallas.AllowUserToAddRows = false;
            this.dgvcolorestallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcolorestallas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvcolorestallas.Location = new System.Drawing.Point(3, 237);
            this.dgvcolorestallas.Name = "dgvcolorestallas";
            this.dgvcolorestallas.ReadOnly = true;
            this.dgvcolorestallas.RowHeadersWidth = 51;
            this.dgvcolorestallas.RowTemplate.Height = 24;
            this.dgvcolorestallas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcolorestallas.Size = new System.Drawing.Size(789, 219);
            this.dgvcolorestallas.TabIndex = 7;
            this.dgvcolorestallas.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvcolorestallas_UserDeletingRow);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.03423F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.96577F));
            this.tableLayoutPanel2.Controls.Add(this.btnagregar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 462);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(789, 102);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(248, 3);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(173, 43);
            this.btnagregar.TabIndex = 6;
            this.btnagregar.Values.Text = "Agregar";
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // AgregarColorTalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 668);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AgregarColorTalla";
            this.Text = "AgregarColorTalla";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgregarColorTalla_FormClosing);
            this.Load += new System.EventHandler(this.AgregarColorTalla_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcoloresba)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboTallas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcolorestallas)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAgregarlista;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtallapersonaliz;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbcomboTallas;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboTallas;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcantidad;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbmedida;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtmedida;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvcolorestallas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnagregar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbcolorespaleta;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbcolorespersonal;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rblistacolores;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbcoloresba;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbcolor;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcolor;
        private System.Windows.Forms.ColorDialog Colorpaleta;
    }
}