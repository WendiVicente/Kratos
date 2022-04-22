namespace Sistema.Forms.modulo_Caja
{
    partial class VerCajas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerCajas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDetalle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnfiltroestado = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbestado = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscarSucursal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.lbMostrarSucursal = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.totalventashoyselect = new System.Windows.Forms.ToolStripLabel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvcajas = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcajas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 26);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.btnDetalle,
            this.toolStripSeparator7,
            this.btnRefrescar,
            this.toolStripSeparator8,
            this.btnfiltroestado,
            this.toolStripSeparator1,
            this.lbestado,
            this.toolStripSeparator2,
            this.btnBuscarSucursal,
            this.toolStripSeparator9,
            this.lbMostrarSucursal,
            this.toolStripSeparator10,
            this.totalventashoyselect});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1040, 27);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "ToolStrip";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalle.Image")));
            this.btnDetalle.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(67, 24);
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::Sistema.Properties.Resources.Refresh_16x;
            this.btnRefrescar.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(79, 24);
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // btnfiltroestado
            // 
            this.btnfiltroestado.Image = global::Sistema.Properties.Resources.Filter_16x;
            this.btnfiltroestado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnfiltroestado.Name = "btnfiltroestado";
            this.btnfiltroestado.Size = new System.Drawing.Size(66, 24);
            this.btnfiltroestado.Text = "Estado";
            this.btnfiltroestado.Click += new System.EventHandler(this.btnfiltroestado_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // lbestado
            // 
            this.lbestado.Name = "lbestado";
            this.lbestado.Size = new System.Drawing.Size(51, 24);
            this.lbestado.Text = "Sin filtro";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnBuscarSucursal
            // 
            this.btnBuscarSucursal.Image = global::Sistema.Properties.Resources.Business_16x;
            this.btnBuscarSucursal.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnBuscarSucursal.Name = "btnBuscarSucursal";
            this.btnBuscarSucursal.Size = new System.Drawing.Size(138, 24);
            this.btnBuscarSucursal.Text = "Seleccionar Sucursal";
            this.btnBuscarSucursal.Click += new System.EventHandler(this.btnBuscarSucursal_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // lbMostrarSucursal
            // 
            this.lbMostrarSucursal.Name = "lbMostrarSucursal";
            this.lbMostrarSucursal.Size = new System.Drawing.Size(37, 24);
            this.lbMostrarSucursal.Text = "Todas";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 27);
            // 
            // totalventashoyselect
            // 
            this.totalventashoyselect.Name = "totalventashoyselect";
            this.totalventashoyselect.Size = new System.Drawing.Size(0, 24);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.dgvcajas);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 26);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1040, 430);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // dgvcajas
            // 
            this.dgvcajas.AllowUserToAddRows = false;
            this.dgvcajas.AllowUserToDeleteRows = false;
            this.dgvcajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcajas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvcajas.Location = new System.Drawing.Point(0, 0);
            this.dgvcajas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvcajas.Name = "dgvcajas";
            this.dgvcajas.ReadOnly = true;
            this.dgvcajas.RowHeadersWidth = 51;
            this.dgvcajas.RowTemplate.Height = 24;
            this.dgvcajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcajas.Size = new System.Drawing.Size(1040, 430);
            this.dgvcajas.TabIndex = 0;
            // 
            // VerCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 456);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "VerCajas";
            this.Text = "VerCajas";
            this.Load += new System.EventHandler(this.VerCajas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcajas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvcajas;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnDetalle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnBuscarSucursal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.ToolStripLabel lbMostrarSucursal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripLabel totalventashoyselect;
        private System.Windows.Forms.ToolStripButton btnfiltroestado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripLabel lbestado;
    }
}