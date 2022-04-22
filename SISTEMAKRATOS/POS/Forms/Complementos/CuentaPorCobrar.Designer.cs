
namespace POS.Forms.Complementos
{
    partial class CuentaPorCobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuentaPorCobrar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.txttelefono = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtnit = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtdpi = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtapellidos = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtnombres = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbCliente = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCrearCuenta = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtBuscador = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dgvCuentasPorCobrar = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasPorCobrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.tableLayoutPanel11);
            this.panel1.Controls.Add(this.cbCliente);
            this.panel1.Controls.Add(this.kryptonLabel2);
            this.panel1.Controls.Add(this.btnCrearCuenta);
            this.panel1.Controls.Add(this.txtBuscador);
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Controls.Add(this.dgvCuentasPorCobrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 379);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 4;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.2828F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.7172F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tableLayoutPanel11.Controls.Add(this.txttelefono, 3, 1);
            this.tableLayoutPanel11.Controls.Add(this.txtnit, 3, 0);
            this.tableLayoutPanel11.Controls.Add(this.txtdpi, 1, 2);
            this.tableLayoutPanel11.Controls.Add(this.txtapellidos, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.kryptonLabel6, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.kryptonLabel7, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.kryptonLabel8, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.kryptonLabel9, 2, 0);
            this.tableLayoutPanel11.Controls.Add(this.kryptonLabel10, 2, 1);
            this.tableLayoutPanel11.Controls.Add(this.txtnombres, 1, 0);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(12, 40);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 3;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(686, 75);
            this.tableLayoutPanel11.TabIndex = 6;
            // 
            // txttelefono
            // 
            this.txttelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txttelefono.Location = new System.Drawing.Point(429, 27);
            this.txttelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(255, 21);
            this.txttelefono.TabIndex = 9;
            this.txttelefono.Values.Text = "";
            // 
            // txtnit
            // 
            this.txtnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtnit.Location = new System.Drawing.Point(429, 2);
            this.txtnit.Margin = new System.Windows.Forms.Padding(2);
            this.txtnit.Name = "txtnit";
            this.txtnit.Size = new System.Drawing.Size(255, 21);
            this.txtnit.TabIndex = 8;
            this.txtnit.Values.Text = "";
            // 
            // txtdpi
            // 
            this.txtdpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtdpi.Location = new System.Drawing.Point(75, 52);
            this.txtdpi.Margin = new System.Windows.Forms.Padding(2);
            this.txtdpi.Name = "txtdpi";
            this.txtdpi.Size = new System.Drawing.Size(267, 21);
            this.txtdpi.TabIndex = 7;
            this.txtdpi.Values.Text = "";
            // 
            // txtapellidos
            // 
            this.txtapellidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtapellidos.Location = new System.Drawing.Point(75, 27);
            this.txtapellidos.Margin = new System.Windows.Forms.Padding(2);
            this.txtapellidos.Name = "txtapellidos";
            this.txtapellidos.Size = new System.Drawing.Size(267, 21);
            this.txtapellidos.TabIndex = 6;
            this.txtapellidos.Values.Text = "";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel6.Location = new System.Drawing.Point(2, 2);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel6.Size = new System.Drawing.Size(69, 21);
            this.kryptonLabel6.TabIndex = 0;
            this.kryptonLabel6.Values.Text = "Nombres";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel7.Location = new System.Drawing.Point(2, 27);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel7.Size = new System.Drawing.Size(69, 21);
            this.kryptonLabel7.TabIndex = 1;
            this.kryptonLabel7.Values.Text = "Apellidos";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel8.Location = new System.Drawing.Point(2, 52);
            this.kryptonLabel8.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel8.Size = new System.Drawing.Size(69, 21);
            this.kryptonLabel8.TabIndex = 2;
            this.kryptonLabel8.Values.Text = "DPI";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel9.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel9.Location = new System.Drawing.Point(346, 2);
            this.kryptonLabel9.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel9.Size = new System.Drawing.Size(79, 21);
            this.kryptonLabel9.TabIndex = 3;
            this.kryptonLabel9.Values.Text = "Nit";
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel10.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel10.Location = new System.Drawing.Point(346, 27);
            this.kryptonLabel10.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel10.Size = new System.Drawing.Size(79, 21);
            this.kryptonLabel10.TabIndex = 4;
            this.kryptonLabel10.Values.Text = "Telefono";
            // 
            // txtnombres
            // 
            this.txtnombres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtnombres.Location = new System.Drawing.Point(75, 2);
            this.txtnombres.Margin = new System.Windows.Forms.Padding(2);
            this.txtnombres.Name = "txtnombres";
            this.txtnombres.Size = new System.Drawing.Size(267, 21);
            this.txtnombres.TabIndex = 5;
            this.txtnombres.Values.Text = "";
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownWidth = 175;
            this.cbCliente.Location = new System.Drawing.Point(68, 7);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.cbCliente.Size = new System.Drawing.Size(259, 21);
            this.cbCliente.TabIndex = 5;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(14, 7);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel2.Size = new System.Drawing.Size(51, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Cliente";
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.Location = new System.Drawing.Point(333, 7);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnCrearCuenta.Size = new System.Drawing.Size(110, 25);
            this.btnCrearCuenta.TabIndex = 3;
            this.btnCrearCuenta.Values.Text = "Crear Cuenta";
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(66, 121);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtBuscador.Size = new System.Drawing.Size(378, 23);
            this.txtBuscador.TabIndex = 2;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 124);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel1.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Buscar";
            // 
            // dgvCuentasPorCobrar
            // 
            this.dgvCuentasPorCobrar.AllowUserToAddRows = false;
            this.dgvCuentasPorCobrar.AllowUserToDeleteRows = false;
            this.dgvCuentasPorCobrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentasPorCobrar.Location = new System.Drawing.Point(12, 150);
            this.dgvCuentasPorCobrar.MultiSelect = false;
            this.dgvCuentasPorCobrar.Name = "dgvCuentasPorCobrar";
            this.dgvCuentasPorCobrar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.dgvCuentasPorCobrar.ReadOnly = true;
            this.dgvCuentasPorCobrar.Size = new System.Drawing.Size(686, 218);
            this.dgvCuentasPorCobrar.TabIndex = 0;
            this.dgvCuentasPorCobrar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentasPorCobrar_CellDoubleClick);
            // 
            // CuentaPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 379);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CuentaPorCobrar";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Text = "Cuentas por cobrar";
            this.Load += new System.EventHandler(this.CuentaPorCobrar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasPorCobrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvCuentasPorCobrar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCrearCuenta;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBuscador;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCliente;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txttelefono;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtnit;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtdpi;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtapellidos;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtnombres;
    }
}