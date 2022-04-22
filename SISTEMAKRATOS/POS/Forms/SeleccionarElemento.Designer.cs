
namespace POS.Forms
{
    partial class SeleccionarElemento
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
            this.txtCantidad = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbStock = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbTallaColor = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAceptar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbTallas = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbColores = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbStockMinimo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbStockGeneral = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTallaColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTallas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbColores)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.txtCantidad);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Controls.Add(this.cbTallaColor);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.btnCancelar);
            this.kryptonPanel1.Controls.Add(this.btnAceptar);
            this.kryptonPanel1.Controls.Add(this.cbTallas);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.cbColores);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonPanel1.Size = new System.Drawing.Size(502, 292);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(31, 193);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtCantidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidad.Size = new System.Drawing.Size(169, 23);
            this.txtCantidad.TabIndex = 10;
            this.txtCantidad.Text = "0";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.AllowDrop = true;
            this.kryptonLabel5.Location = new System.Drawing.Point(31, 166);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel5.Size = new System.Drawing.Size(62, 20);
            this.kryptonLabel5.TabIndex = 9;
            this.kryptonLabel5.Values.Text = "Cantidad:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.09129F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.90871F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbStockMinimo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbStock, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbStockGeneral, 1, 1);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(237, 113);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33267F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.32867F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33867F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(241, 103);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel4.Size = new System.Drawing.Size(134, 30);
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "Stock Disponible:";
            // 
            // lbStock
            // 
            this.lbStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStock.Location = new System.Drawing.Point(143, 3);
            this.lbStock.Name = "lbStock";
            this.lbStock.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.lbStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbStock.Size = new System.Drawing.Size(95, 30);
            this.lbStock.TabIndex = 1;
            this.lbStock.Values.Text = "0";
            // 
            // cbTallaColor
            // 
            this.cbTallaColor.DropDownWidth = 169;
            this.cbTallaColor.Location = new System.Drawing.Point(237, 50);
            this.cbTallaColor.Name = "cbTallaColor";
            this.cbTallaColor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.cbTallaColor.Size = new System.Drawing.Size(241, 21);
            this.cbTallaColor.TabIndex = 7;
            this.cbTallaColor.SelectedIndexChanged += new System.EventHandler(this.cbTallaColor_SelectedIndexChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.AllowDrop = true;
            this.kryptonLabel3.Location = new System.Drawing.Point(237, 24);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel3.Size = new System.Drawing.Size(141, 20);
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Seleccionar color y talla:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(388, 245);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Values.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(262, 245);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnAceptar.Size = new System.Drawing.Size(90, 25);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Values.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbTallas
            // 
            this.cbTallas.DropDownWidth = 169;
            this.cbTallas.Location = new System.Drawing.Point(31, 116);
            this.cbTallas.Name = "cbTallas";
            this.cbTallas.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.cbTallas.Size = new System.Drawing.Size(169, 21);
            this.cbTallas.TabIndex = 3;
            this.cbTallas.SelectedIndexChanged += new System.EventHandler(this.cbTallas_SelectedIndexChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.AllowDrop = true;
            this.kryptonLabel2.Location = new System.Drawing.Point(31, 90);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel2.Size = new System.Drawing.Size(103, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Seleccionar Talla:";
            // 
            // cbColores
            // 
            this.cbColores.DropDownWidth = 169;
            this.cbColores.Location = new System.Drawing.Point(31, 50);
            this.cbColores.Name = "cbColores";
            this.cbColores.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.cbColores.Size = new System.Drawing.Size(169, 21);
            this.cbColores.TabIndex = 1;
            this.cbColores.SelectedIndexChanged += new System.EventHandler(this.cbColores_SelectedIndexChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AllowDrop = true;
            this.kryptonLabel1.Location = new System.Drawing.Point(31, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel1.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Seleccionar color:";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel6.Location = new System.Drawing.Point(3, 69);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel6.Size = new System.Drawing.Size(134, 31);
            this.kryptonLabel6.TabIndex = 2;
            this.kryptonLabel6.Values.Text = "Stock Minimo:";
            // 
            // lbStockMinimo
            // 
            this.lbStockMinimo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStockMinimo.Location = new System.Drawing.Point(143, 69);
            this.lbStockMinimo.Name = "lbStockMinimo";
            this.lbStockMinimo.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.lbStockMinimo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbStockMinimo.Size = new System.Drawing.Size(95, 31);
            this.lbStockMinimo.TabIndex = 3;
            this.lbStockMinimo.Values.Text = "0";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel7.Location = new System.Drawing.Point(3, 39);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel7.Size = new System.Drawing.Size(134, 24);
            this.kryptonLabel7.TabIndex = 4;
            this.kryptonLabel7.Values.Text = "Stock General:";
            // 
            // lbStockGeneral
            // 
            this.lbStockGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStockGeneral.Location = new System.Drawing.Point(143, 39);
            this.lbStockGeneral.Name = "lbStockGeneral";
            this.lbStockGeneral.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.lbStockGeneral.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbStockGeneral.Size = new System.Drawing.Size(95, 24);
            this.lbStockGeneral.TabIndex = 5;
            this.lbStockGeneral.Values.Text = "0";
            // 
            // SeleccionarElemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(502, 292);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionarElemento";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Color / Talla";
            this.Load += new System.EventHandler(this.SeleccionarColor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTallaColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTallas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbColores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAceptar;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbTallas;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbColores;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbTallaColor;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbStock;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCantidad;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbStockMinimo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbStockGeneral;
    }
}