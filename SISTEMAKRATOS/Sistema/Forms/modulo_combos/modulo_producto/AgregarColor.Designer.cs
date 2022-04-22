namespace Sistema.Forms.modulo_producto
{
    partial class AgregarColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarColor));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel4 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnagregar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvColoresadd = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbcolorespaleta = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbcolorespersonal = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.rblistacolores = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.cbcoloresba = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtCantidadColores = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lbColor = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtColor = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonPanel5 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAgregarlista = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Colorpaleta = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).BeginInit();
            this.kryptonPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColoresadd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcoloresba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel5)).BeginInit();
            this.kryptonPanel5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonPanel4);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel3);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(274, 497);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonPanel4
            // 
            this.kryptonPanel4.Controls.Add(this.btnagregar);
            this.kryptonPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel4.Location = new System.Drawing.Point(0, 458);
            this.kryptonPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel4.Name = "kryptonPanel4";
            this.kryptonPanel4.Size = new System.Drawing.Size(274, 39);
            this.kryptonPanel4.TabIndex = 8;
            // 
            // btnagregar
            // 
            this.btnagregar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnagregar.Location = new System.Drawing.Point(75, 2);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(130, 35);
            this.btnagregar.TabIndex = 5;
            this.btnagregar.Values.Text = "Agregar";
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.dgvColoresadd);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 242);
            this.kryptonPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(274, 255);
            this.kryptonPanel3.TabIndex = 7;
            // 
            // dgvColoresadd
            // 
            this.dgvColoresadd.AllowUserToAddRows = false;
            this.dgvColoresadd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColoresadd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColoresadd.Location = new System.Drawing.Point(0, 0);
            this.dgvColoresadd.Margin = new System.Windows.Forms.Padding(2);
            this.dgvColoresadd.Name = "dgvColoresadd";
            this.dgvColoresadd.ReadOnly = true;
            this.dgvColoresadd.RowHeadersWidth = 51;
            this.dgvColoresadd.RowTemplate.Height = 24;
            this.dgvColoresadd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColoresadd.Size = new System.Drawing.Size(274, 255);
            this.dgvColoresadd.TabIndex = 0;
            this.dgvColoresadd.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvColoresadd_UserDeletingRow);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.panel1);
            this.kryptonPanel2.Controls.Add(this.kryptonPanel5);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(274, 242);
            this.kryptonPanel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.rbcolorespaleta);
            this.panel1.Controls.Add(this.rbcolorespersonal);
            this.panel1.Controls.Add(this.kryptonLabel2);
            this.panel1.Controls.Add(this.rblistacolores);
            this.panel1.Controls.Add(this.cbcoloresba);
            this.panel1.Controls.Add(this.txtCantidadColores);
            this.panel1.Controls.Add(this.lbColor);
            this.panel1.Controls.Add(this.txtColor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 214);
            this.panel1.TabIndex = 5;
            // 
            // rbcolorespaleta
            // 
            this.rbcolorespaleta.Location = new System.Drawing.Point(10, 60);
            this.rbcolorespaleta.Margin = new System.Windows.Forms.Padding(2);
            this.rbcolorespaleta.Name = "rbcolorespaleta";
            this.rbcolorespaleta.Size = new System.Drawing.Size(93, 20);
            this.rbcolorespaleta.TabIndex = 28;
            this.rbcolorespaleta.Values.Text = "Desde Paleta";
            this.rbcolorespaleta.CheckedChanged += new System.EventHandler(this.rbcolorespaleta_CheckedChanged);
            // 
            // rbcolorespersonal
            // 
            this.rbcolorespersonal.Location = new System.Drawing.Point(10, 94);
            this.rbcolorespersonal.Margin = new System.Windows.Forms.Padding(2);
            this.rbcolorespersonal.Name = "rbcolorespersonal";
            this.rbcolorespersonal.Size = new System.Drawing.Size(98, 20);
            this.rbcolorespersonal.TabIndex = 27;
            this.rbcolorespersonal.Values.Text = "Personalizado";
            this.rbcolorespersonal.CheckedChanged += new System.EventHandler(this.rbcolorespersonal_CheckedChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(16, 155);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Cantidad";
            // 
            // rblistacolores
            // 
            this.rblistacolores.Location = new System.Drawing.Point(10, 29);
            this.rblistacolores.Margin = new System.Windows.Forms.Padding(2);
            this.rblistacolores.Name = "rblistacolores";
            this.rblistacolores.Size = new System.Drawing.Size(117, 20);
            this.rblistacolores.TabIndex = 26;
            this.rblistacolores.Values.Text = "Elegir desde Lista";
            this.rblistacolores.CheckedChanged += new System.EventHandler(this.rblistacolores_CheckedChanged);
            // 
            // cbcoloresba
            // 
            this.cbcoloresba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcoloresba.DropDownWidth = 139;
            this.cbcoloresba.Location = new System.Drawing.Point(136, 29);
            this.cbcoloresba.Margin = new System.Windows.Forms.Padding(2);
            this.cbcoloresba.Name = "cbcoloresba";
            this.cbcoloresba.Size = new System.Drawing.Size(128, 21);
            this.cbcoloresba.TabIndex = 25;
            this.cbcoloresba.SelectedIndexChanged += new System.EventHandler(this.cbcoloresba_SelectedIndexChanged);
            // 
            // txtCantidadColores
            // 
            this.txtCantidadColores.Location = new System.Drawing.Point(104, 153);
            this.txtCantidadColores.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidadColores.Name = "txtCantidadColores";
            this.txtCantidadColores.Size = new System.Drawing.Size(160, 23);
            this.txtCantidadColores.TabIndex = 2;
            this.txtCantidadColores.Text = "0";
            // 
            // lbColor
            // 
            this.lbColor.Location = new System.Drawing.Point(124, 92);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(40, 20);
            this.lbColor.TabIndex = 24;
            this.lbColor.Values.Text = "Color";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(166, 92);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(98, 23);
            this.txtColor.TabIndex = 18;
            // 
            // kryptonPanel5
            // 
            this.kryptonPanel5.Controls.Add(this.toolStrip1);
            this.kryptonPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel5.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel5.Name = "kryptonPanel5";
            this.kryptonPanel5.Size = new System.Drawing.Size(274, 28);
            this.kryptonPanel5.TabIndex = 4;
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
            this.toolStrip1.Size = new System.Drawing.Size(274, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAgregarlista
            // 
            this.btnAgregarlista.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
            this.btnAgregarlista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarlista.Name = "btnAgregarlista";
            this.btnAgregarlista.Size = new System.Drawing.Size(73, 24);
            this.btnAgregarlista.Text = "Guardar";
            this.btnAgregarlista.Click += new System.EventHandler(this.btnAgregarlista_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // AgregarColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnagregar;
            this.ClientSize = new System.Drawing.Size(274, 497);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar Color";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgregarColor_FormClosing);
            this.Load += new System.EventHandler(this.AgregarColor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).EndInit();
            this.kryptonPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColoresadd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcoloresba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel5)).EndInit();
            this.kryptonPanel5.ResumeLayout(false);
            this.kryptonPanel5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnagregar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCantidadColores;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvColoresadd;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAgregarlista;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbcolorespaleta;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbcolorespersonal;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rblistacolores;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbcoloresba;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbColor;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtColor;
        private System.Windows.Forms.ColorDialog Colorpaleta;
    }
}