namespace Sistema.Forms.modulo_producto
{
    partial class CategoriaProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriaProducto));
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel6 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvCategorias = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel5 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lbcatelimpiar = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.checkestadocate = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtcategoria = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardarCate = new System.Windows.Forms.ToolStripButton();
            this.btnActualizarCate = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel6)).BeginInit();
            this.kryptonPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel5)).BeginInit();
            this.kryptonPanel5.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // kryptonPanel6
            // 
            this.kryptonPanel6.Controls.Add(this.dgvCategorias);
            this.kryptonPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel6.Location = new System.Drawing.Point(0, 142);
            this.kryptonPanel6.Name = "kryptonPanel6";
            this.kryptonPanel6.Size = new System.Drawing.Size(800, 308);
            this.kryptonPanel6.TabIndex = 8;
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.AllowUserToDeleteRows = false;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategorias.Location = new System.Drawing.Point(0, 0);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.RowHeadersWidth = 51;
            this.dgvCategorias.RowTemplate.Height = 24;
            this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorias.Size = new System.Drawing.Size(800, 308);
            this.dgvCategorias.TabIndex = 0;
            this.dgvCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellClick);
            // 
            // kryptonPanel5
            // 
            this.kryptonPanel5.Controls.Add(this.lbcatelimpiar);
            this.kryptonPanel5.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel5.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel5.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel5.Controls.Add(this.checkestadocate);
            this.kryptonPanel5.Controls.Add(this.txtcategoria);
            this.kryptonPanel5.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel5.Controls.Add(this.toolStrip2);
            this.kryptonPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel5.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel5.Name = "kryptonPanel5";
            this.kryptonPanel5.Size = new System.Drawing.Size(800, 142);
            this.kryptonPanel5.TabIndex = 6;
            // 
            // lbcatelimpiar
            // 
            this.lbcatelimpiar.Location = new System.Drawing.Point(428, 35);
            this.lbcatelimpiar.Name = "lbcatelimpiar";
            this.lbcatelimpiar.Size = new System.Drawing.Size(121, 24);
            this.lbcatelimpiar.TabIndex = 13;
            this.lbcatelimpiar.Values.Image = global::Sistema.Properties.Resources.CleanData_16x;
            this.lbcatelimpiar.Values.Text = "Limpiar datos";
            this.lbcatelimpiar.Click += new System.EventHandler(this.lbcatelimpiar_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(142, 35);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(6, 2);
            this.kryptonLabel3.TabIndex = 12;
            this.kryptonLabel3.Values.Text = "";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(62, 35);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(64, 24);
            this.kryptonLabel4.TabIndex = 11;
            this.kryptonLabel4.Values.Text = "Codigo:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(54, 110);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(72, 24);
            this.kryptonLabel5.TabIndex = 10;
            this.kryptonLabel5.Values.Text = "Inactivar:";
            // 
            // checkestadocate
            // 
            this.checkestadocate.Location = new System.Drawing.Point(148, 115);
            this.checkestadocate.Name = "checkestadocate";
            this.checkestadocate.Size = new System.Drawing.Size(19, 13);
            this.checkestadocate.TabIndex = 9;
            this.checkestadocate.Values.Text = "";
            this.checkestadocate.CheckedChanged += new System.EventHandler(this.checkestadocate_CheckedChanged);
            // 
            // txtcategoria
            // 
            this.txtcategoria.Location = new System.Drawing.Point(142, 65);
            this.txtcategoria.Name = "txtcategoria";
            this.txtcategoria.Size = new System.Drawing.Size(159, 27);
            this.txtcategoria.TabIndex = 8;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(12, 68);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(129, 24);
            this.kryptonLabel6.TabIndex = 7;
            this.kryptonLabel6.Values.Text = "Nueva Categoria:";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardarCate,
            this.toolStripSeparator3,
            this.btnActualizarCate,
            this.toolStripSeparator4});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(800, 27);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnGuardarCate
            // 
            this.btnGuardarCate.Image = global::Sistema.Properties.Resources.Add_8x_16x;
            this.btnGuardarCate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardarCate.Name = "btnGuardarCate";
            this.btnGuardarCate.Size = new System.Drawing.Size(133, 24);
            this.btnGuardarCate.Text = "Nuevo Guardar";
            this.btnGuardarCate.Click += new System.EventHandler(this.btnGuardarCate_Click);
            // 
            // btnActualizarCate
            // 
            this.btnActualizarCate.Image = global::Sistema.Properties.Resources.EditDocument_16x;
            this.btnActualizarCate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizarCate.Name = "btnActualizarCate";
            this.btnActualizarCate.Size = new System.Drawing.Size(99, 24);
            this.btnActualizarCate.Text = "Actualizar";
            this.btnActualizarCate.Click += new System.EventHandler(this.btnActualizarCate_Click);
            // 
            // CategoriaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel6);
            this.Controls.Add(this.kryptonPanel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CategoriaProducto";
            this.Text = "CategoriaProducto";
            this.Load += new System.EventHandler(this.CategoriaProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel6)).EndInit();
            this.kryptonPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel5)).EndInit();
            this.kryptonPanel5.ResumeLayout(false);
            this.kryptonPanel5.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel6;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvCategorias;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbcatelimpiar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkestadocate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcategoria;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnGuardarCate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnActualizarCate;
    }
}