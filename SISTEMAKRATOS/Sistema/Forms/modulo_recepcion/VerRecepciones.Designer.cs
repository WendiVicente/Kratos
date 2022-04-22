namespace Sistema.Forms.modulo_recepcion
{
    partial class VerRecepciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerRecepciones));
            this.dgvListaRecepciones = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnDetalleP = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnestado = new System.Windows.Forms.ToolStripButton();
            this.lbfiltro = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnsucursal = new System.Windows.Forms.ToolStripButton();
            this.lbsucursal = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaRecepciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListaRecepciones
            // 
            this.dgvListaRecepciones.AllowUserToAddRows = false;
            this.dgvListaRecepciones.AllowUserToDeleteRows = false;
            this.dgvListaRecepciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaRecepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaRecepciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaRecepciones.Location = new System.Drawing.Point(0, 27);
            this.dgvListaRecepciones.Name = "dgvListaRecepciones";
            this.dgvListaRecepciones.ReadOnly = true;
            this.dgvListaRecepciones.RowHeadersWidth = 51;
            this.dgvListaRecepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaRecepciones.Size = new System.Drawing.Size(884, 537);
            this.dgvListaRecepciones.TabIndex = 4;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.dgvListaRecepciones);
            this.kryptonPanel1.Controls.Add(this.toolStrip);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(884, 564);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDetalleP,
            this.btnActualizar,
            this.toolStripSeparator1,
            this.btnestado,
            this.lbfiltro,
            this.toolStripSeparator2,
            this.btnsucursal,
            this.lbsucursal});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(884, 27);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "ToolStrip";
            // 
            // btnDetalleP
            // 
            this.btnDetalleP.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleP.Image")));
            this.btnDetalleP.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnDetalleP.Name = "btnDetalleP";
            this.btnDetalleP.Size = new System.Drawing.Size(67, 24);
            this.btnDetalleP.Text = "Detalle";
            this.btnDetalleP.Click += new System.EventHandler(this.btnDetalleP_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::Sistema.Properties.Resources.Refresh_16x;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(79, 24);
            this.btnActualizar.Text = "Refrescar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnestado
            // 
            this.btnestado.Image = global::Sistema.Properties.Resources.Filter_16x;
            this.btnestado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnestado.Name = "btnestado";
            this.btnestado.Size = new System.Drawing.Size(71, 24);
            this.btnestado.Text = "Estados";
            this.btnestado.Click += new System.EventHandler(this.btnestado_Click);
            // 
            // lbfiltro
            // 
            this.lbfiltro.Name = "lbfiltro";
            this.lbfiltro.Size = new System.Drawing.Size(37, 24);
            this.lbfiltro.Text = "Todas";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnsucursal
            // 
            this.btnsucursal.Image = global::Sistema.Properties.Resources.Business_16x;
            this.btnsucursal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsucursal.Name = "btnsucursal";
            this.btnsucursal.Size = new System.Drawing.Size(86, 24);
            this.btnsucursal.Text = "Sucursales";
            this.btnsucursal.Click += new System.EventHandler(this.btnsucursal_Click);
            // 
            // lbsucursal
            // 
            this.lbsucursal.Name = "lbsucursal";
            this.lbsucursal.Size = new System.Drawing.Size(54, 24);
            this.lbsucursal.Text = ":Sucursal";
            // 
            // VerRecepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 564);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerRecepciones";
            this.Text = "VerRecepciones";
            this.Load += new System.EventHandler(this.VerRecepciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaRecepciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvListaRecepciones;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnDetalleP;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnestado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnsucursal;
        public System.Windows.Forms.ToolStripLabel lbfiltro;
        public System.Windows.Forms.ToolStripLabel lbsucursal;
    }
}