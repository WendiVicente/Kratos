namespace Sistema.Forms.modulo_Sucursales
{
    partial class ListaSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaSucursales));
            this.dglistasucursales = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.BuscarSucursal = new System.Windows.Forms.ToolStripButton();
            this.btnBorrar = new System.Windows.Forms.ToolStripButton();
            this.btnDetalle = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dglistasucursales)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dglistasucursales
            // 
            this.dglistasucursales.AllowUserToAddRows = false;
            this.dglistasucursales.AllowUserToDeleteRows = false;
            this.dglistasucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglistasucursales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglistasucursales.Location = new System.Drawing.Point(0, 27);
            this.dglistasucursales.Margin = new System.Windows.Forms.Padding(4);
            this.dglistasucursales.Name = "dglistasucursales";
            this.dglistasucursales.ReadOnly = true;
            this.dglistasucursales.RowHeadersWidth = 51;
            this.dglistasucursales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglistasucursales.Size = new System.Drawing.Size(800, 423);
            this.dglistasucursales.TabIndex = 6;
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BuscarSucursal,
            this.btnBorrar,
            this.btnDetalle,
            this.btnActualizar,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 27);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "ToolStrip";
            // 
            // BuscarSucursal
            // 
            this.BuscarSucursal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BuscarSucursal.Image = ((System.Drawing.Image)(resources.GetObject("BuscarSucursal.Image")));
            this.BuscarSucursal.ImageTransparentColor = System.Drawing.Color.Black;
            this.BuscarSucursal.Name = "BuscarSucursal";
            this.BuscarSucursal.Size = new System.Drawing.Size(29, 24);
            this.BuscarSucursal.Text = "Buscar";
            this.BuscarSucursal.Click += new System.EventHandler(this.BuscarSucursal_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBorrar.Image = global::Sistema.Properties.Resources._0405_20_delete;
            this.btnBorrar.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(29, 24);
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalle.Image")));
            this.btnDetalle.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(29, 24);
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizar.Image = global::Sistema.Properties.Resources.Refresh_16x;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(29, 24);
            this.btnActualizar.Text = "Refrescar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // ListaSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dglistasucursales);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListaSucursales";
            this.Text = "ListaSucursales";
            this.Load += new System.EventHandler(this.ListaSucursales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dglistasucursales)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dglistasucursales;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton BuscarSucursal;
        private System.Windows.Forms.ToolStripButton btnBorrar;
        private System.Windows.Forms.ToolStripButton btnDetalle;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}