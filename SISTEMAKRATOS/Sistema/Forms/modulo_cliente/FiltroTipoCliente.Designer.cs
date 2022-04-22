namespace Sistema.Forms.modulo_cliente
{
    partial class FiltroTipoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltroTipoCliente));
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bntfiltro = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReporte = new System.Windows.Forms.ToolStripButton();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.listsucursales = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listsucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonPanel1);
            this.kryptonPanel2.Controls.Add(this.kryptonPanel3);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(600, 162);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.toolStrip1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(600, 22);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bntfiltro,
            this.toolStripSeparator1,
            this.btnReporte});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(600, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bntfiltro
            // 
            this.bntfiltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntfiltro.Name = "bntfiltro";
            this.bntfiltro.Size = new System.Drawing.Size(41, 22);
            this.bntfiltro.Text = "Filtrar";
            this.bntfiltro.Click += new System.EventHandler(this.bntfiltro_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReporte
            // 
            this.btnReporte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(96, 22);
            this.btnReporte.Text = "Generar Reporte";
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel3.Controls.Add(this.listsucursales);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(600, 162);
            this.kryptonPanel3.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(91, 70);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(95, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Tipo de Cliente:";
            // 
            // listsucursales
            // 
            this.listsucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listsucursales.DropDownWidth = 218;
            this.listsucursales.Location = new System.Drawing.Point(194, 70);
            this.listsucursales.Name = "listsucursales";
            this.listsucursales.Size = new System.Drawing.Size(218, 21);
            this.listsucursales.TabIndex = 3;
            this.listsucursales.SelectedIndexChanged += new System.EventHandler(this.listsucursales_SelectedIndexChanged);
            // 
            // FiltroTipoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 162);
            this.Controls.Add(this.kryptonPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FiltroTipoCliente";
            this.Text = "FiltroTipoCliente";
            this.Load += new System.EventHandler(this.FiltroTipoCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.kryptonPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listsucursales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox listsucursales;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bntfiltro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReporte;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}