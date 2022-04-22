namespace Sistema.Forms.modulo_recepcion
{
    partial class BuscarPorSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarPorSucursales));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.listsucursales = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.btnBuscar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listsucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.listsucursales);
            this.kryptonPanel1.Controls.Add(this.kryptonHeader1);
            this.kryptonPanel1.Controls.Add(this.btnBuscar);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(623, 219);
            this.kryptonPanel1.TabIndex = 3;
            this.kryptonPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel1_Paint);
            // 
            // listsucursales
            // 
            this.listsucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listsucursales.DropDownWidth = 218;
            this.listsucursales.Location = new System.Drawing.Point(259, 86);
            this.listsucursales.Margin = new System.Windows.Forms.Padding(4);
            this.listsucursales.Name = "listsucursales";
            this.listsucursales.Size = new System.Drawing.Size(291, 25);
            this.listsucursales.TabIndex = 3;
            this.listsucursales.SelectedIndexChanged += new System.EventHandler(this.listsucursales_SelectedIndexChanged);
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(623, 37);
            this.kryptonHeader1.TabIndex = 2;
            this.kryptonHeader1.Values.Heading = "Seleccionar Sucursal";
            this.kryptonHeader1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonHeader1_Paint);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(108, 81);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(144, 31);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Values.Text = "Aplicar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // BuscarPorSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 219);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BuscarPorSucursales";
            this.Text = "BuscarPorSucursales";
            this.Load += new System.EventHandler(this.BuscarPorSucursales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listsucursales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox listsucursales;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBuscar;
    }
}