namespace Sistema.Forms.modulo_Sucursales
{
    partial class BuscarSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarSucursal));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.buscar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buscarc = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonHeader1);
            this.kryptonPanel1.Controls.Add(this.buscar);
            this.kryptonPanel1.Controls.Add(this.buscarc);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(529, 168);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(529, 37);
            this.kryptonHeader1.TabIndex = 2;
            this.kryptonHeader1.Values.Description = "Descripción";
            this.kryptonHeader1.Values.Heading = "Búsqueda de Sucursales";
            this.kryptonHeader1.Values.Image = global::Sistema.Properties.Resources.Search_16x;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(104, 59);
            this.buscar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(107, 35);
            this.buscar.TabIndex = 1;
            this.buscar.Values.Image = global::Sistema.Properties.Resources.Search_16x;
            this.buscar.Values.Text = "Buscar";
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // buscarc
            // 
            this.buscarc.Location = new System.Drawing.Point(215, 59);
            this.buscarc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buscarc.Name = "buscarc";
            this.buscarc.Size = new System.Drawing.Size(218, 27);
            this.buscarc.TabIndex = 0;
            // 
            // BuscarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 168);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BuscarSucursal";
            this.Text = "BuscarSucursal";
            this.Load += new System.EventHandler(this.BuscarSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buscar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox buscarc;
    }
}