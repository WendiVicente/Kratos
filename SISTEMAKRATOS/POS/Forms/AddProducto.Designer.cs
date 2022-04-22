namespace POS.Forms
{
    partial class AddProducto
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnBuscarP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtbuscarP = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgListaProductos = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonHeaderGroup1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanel3);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanel2);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(800, 450);
            this.kryptonHeaderGroup1.TabIndex = 0;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.toolStrip);
            this.kryptonPanel3.Controls.Add(this.txtbuscarP);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(798, 58);
            this.kryptonPanel3.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBuscarP,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(798, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "ToolStrip";
            // 
            // btnBuscarP
            // 
            this.btnBuscarP.Image = global::POS.Properties.Resources.Add_8x_16x;
            this.btnBuscarP.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnBuscarP.Name = "btnBuscarP";
            this.btnBuscarP.Size = new System.Drawing.Size(69, 22);
            this.btnBuscarP.Text = "Agregar";
            this.btnBuscarP.Click += new System.EventHandler(this.btnBuscarP_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // txtbuscarP
            // 
            this.txtbuscarP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtbuscarP.Location = new System.Drawing.Point(0, 27);
            this.txtbuscarP.Name = "txtbuscarP";
            this.txtbuscarP.Size = new System.Drawing.Size(798, 31);
            this.txtbuscarP.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscarP.TabIndex = 0;
            this.txtbuscarP.TextChanged += new System.EventHandler(this.txtbuscarP_TextChanged);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.dgListaProductos);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 58);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(798, 339);
            this.kryptonPanel2.TabIndex = 0;
            this.kryptonPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel2_Paint);
            // 
            // dgListaProductos
            // 
            this.dgListaProductos.AllowUserToAddRows = false;
            this.dgListaProductos.AllowUserToDeleteRows = false;
            this.dgListaProductos.AllowUserToResizeColumns = false;
            this.dgListaProductos.AllowUserToResizeRows = false;
            this.dgListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListaProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListaProductos.Location = new System.Drawing.Point(0, 0);
            this.dgListaProductos.Name = "dgListaProductos";
            this.dgListaProductos.ReadOnly = true;
            this.dgListaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListaProductos.Size = new System.Drawing.Size(798, 339);
            this.dgListaProductos.TabIndex = 0;
            // 
            // AddProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "AddProducto";
            this.Text = "AddProducto";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.kryptonPanel3.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgListaProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbuscarP;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnBuscarP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgListaProductos;
    }
}