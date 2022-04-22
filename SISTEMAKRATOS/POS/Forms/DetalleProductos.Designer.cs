
namespace POS.Forms
{
    partial class DetalleProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleProductos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.BtnAceptar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbProd = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.BtnEliminarLista = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.DgvListaDetalles = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.lbDetalle = new System.Windows.Forms.Label();
            this.CbDetalles = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.BtnAgregarLista = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbStock = new System.Windows.Forms.Label();
            this.TxtCantidad = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel1.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.pnlDetalle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 343);
            this.panel1.TabIndex = 0;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.BtnAceptar);
            this.pnlDetalle.Controls.Add(this.lbProd);
            this.pnlDetalle.Controls.Add(this.lbTotal);
            this.pnlDetalle.Controls.Add(this.BtnEliminarLista);
            this.pnlDetalle.Controls.Add(this.DgvListaDetalles);
            this.pnlDetalle.Controls.Add(this.lbDetalle);
            this.pnlDetalle.Controls.Add(this.CbDetalles);
            this.pnlDetalle.Controls.Add(this.BtnAgregarLista);
            this.pnlDetalle.Controls.Add(this.lbStock);
            this.pnlDetalle.Controls.Add(this.TxtCantidad);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(549, 343);
            this.pnlDetalle.TabIndex = 39;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Enabled = false;
            this.BtnAceptar.Location = new System.Drawing.Point(456, 300);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.BtnAceptar.Size = new System.Drawing.Size(87, 33);
            this.BtnAceptar.TabIndex = 96;
            this.BtnAceptar.Values.Text = "Aceptar";
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // lbProd
            // 
            this.lbProd.AutoSize = true;
            this.lbProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProd.Location = new System.Drawing.Point(8, 27);
            this.lbProd.Name = "lbProd";
            this.lbProd.Size = new System.Drawing.Size(100, 15);
            this.lbProd.TabIndex = 95;
            this.lbProd.Text = "Nombe Producto";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(303, 305);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(40, 15);
            this.lbTotal.TabIndex = 94;
            this.lbTotal.Text = "Total: ";
            // 
            // BtnEliminarLista
            // 
            this.BtnEliminarLista.Location = new System.Drawing.Point(505, 46);
            this.BtnEliminarLista.Name = "BtnEliminarLista";
            this.BtnEliminarLista.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.BtnEliminarLista.Size = new System.Drawing.Size(35, 23);
            this.BtnEliminarLista.TabIndex = 93;
            this.BtnEliminarLista.Values.Image = global::POS.Properties.Resources.DeleteAllRows_16x;
            this.BtnEliminarLista.Values.Text = "";
            this.BtnEliminarLista.Click += new System.EventHandler(this.BtnEliminarLista_Click);
            // 
            // DgvListaDetalles
            // 
            this.DgvListaDetalles.AllowUserToAddRows = false;
            this.DgvListaDetalles.AllowUserToResizeRows = false;
            this.DgvListaDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvListaDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaDetalles.Location = new System.Drawing.Point(7, 74);
            this.DgvListaDetalles.Margin = new System.Windows.Forms.Padding(2);
            this.DgvListaDetalles.MultiSelect = false;
            this.DgvListaDetalles.Name = "DgvListaDetalles";
            this.DgvListaDetalles.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.DgvListaDetalles.RowHeadersWidth = 51;
            this.DgvListaDetalles.RowTemplate.Height = 24;
            this.DgvListaDetalles.Size = new System.Drawing.Size(536, 218);
            this.DgvListaDetalles.TabIndex = 92;
            // 
            // lbDetalle
            // 
            this.lbDetalle.AutoSize = true;
            this.lbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetalle.Location = new System.Drawing.Point(8, 8);
            this.lbDetalle.Name = "lbDetalle";
            this.lbDetalle.Size = new System.Drawing.Size(51, 16);
            this.lbDetalle.TabIndex = 30;
            this.lbDetalle.Text = "Detalle";
            // 
            // CbDetalles
            // 
            this.CbDetalles.DropDownHeight = 175;
            this.CbDetalles.DropDownWidth = 175;
            this.CbDetalles.Location = new System.Drawing.Point(7, 48);
            this.CbDetalles.Name = "CbDetalles";
            this.CbDetalles.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.CbDetalles.Size = new System.Drawing.Size(175, 21);
            this.CbDetalles.TabIndex = 27;
            this.CbDetalles.SelectedIndexChanged += new System.EventHandler(this.CbDetalles_SelectedIndexChanged);
            // 
            // BtnAgregarLista
            // 
            this.BtnAgregarLista.Location = new System.Drawing.Point(464, 46);
            this.BtnAgregarLista.Name = "BtnAgregarLista";
            this.BtnAgregarLista.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.BtnAgregarLista.Size = new System.Drawing.Size(37, 23);
            this.BtnAgregarLista.TabIndex = 26;
            this.BtnAgregarLista.Values.Image = global::POS.Properties.Resources.Add_8x_16x;
            this.BtnAgregarLista.Values.Text = "";
            this.BtnAgregarLista.Click += new System.EventHandler(this.BtnAgregarLista_Click);
            // 
            // lbStock
            // 
            this.lbStock.AutoSize = true;
            this.lbStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStock.Location = new System.Drawing.Point(188, 50);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(82, 15);
            this.lbStock.TabIndex = 28;
            this.lbStock.Text = "Existencias: 0";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(316, 46);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.TxtCantidad.Size = new System.Drawing.Size(142, 23);
            this.TxtCantidad.TabIndex = 29;
            this.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // DetalleProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 343);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetalleProductos";
            this.Text = "Detalle Producto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetalleProductos_FormClosing);
            this.Load += new System.EventHandler(this.DetalleProductos_Load);
            this.panel1.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDetalle;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAceptar;
        private System.Windows.Forms.Label lbProd;
        private System.Windows.Forms.Label lbTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnEliminarLista;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView DgvListaDetalles;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox CbDetalles;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAgregarLista;
        private System.Windows.Forms.Label lbStock;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtCantidad;
        private System.Windows.Forms.Label lbDetalle;
    }
}