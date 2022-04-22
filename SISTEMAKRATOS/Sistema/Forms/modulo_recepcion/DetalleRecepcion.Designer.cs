namespace Sistema.Forms.modulo_recepcion
{
    partial class DetalleRecepcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleRecepcion));
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ListaProductSelect = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.lbtotal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtcomprobante = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbproveedor = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbcompraid = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbfechaestimada = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbfechasolicitud = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbEstado = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnValidar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaProductSelect)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.RoyalBlue;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(680, 7);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 2);
            this.label12.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label11.Location = new System.Drawing.Point(685, 10);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Total: Q.";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ListaProductSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 246);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 223);
            this.panel2.TabIndex = 4;
            // 
            // ListaProductSelect
            // 
            this.ListaProductSelect.AllowUserToAddRows = false;
            this.ListaProductSelect.AllowUserToDeleteRows = false;
            this.ListaProductSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaProductSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaProductSelect.Location = new System.Drawing.Point(0, 0);
            this.ListaProductSelect.Margin = new System.Windows.Forms.Padding(2);
            this.ListaProductSelect.Name = "ListaProductSelect";
            this.ListaProductSelect.ReadOnly = true;
            this.ListaProductSelect.RowHeadersWidth = 51;
            this.ListaProductSelect.RowTemplate.Height = 24;
            this.ListaProductSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaProductSelect.Size = new System.Drawing.Size(874, 223);
            this.ListaProductSelect.TabIndex = 0;
            // 
            // lbtotal
            // 
            this.lbtotal.AutoSize = true;
            this.lbtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotal.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbtotal.Location = new System.Drawing.Point(776, 10);
            this.lbtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbtotal.Name = "lbtotal";
            this.lbtotal.Size = new System.Drawing.Size(44, 20);
            this.lbtotal.TabIndex = 22;
            this.lbtotal.Text = "0.00";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbtotal);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 473);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(874, 78);
            this.panel3.TabIndex = 5;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 27);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(878, 553);
            this.kryptonPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.12297F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.22966F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.64738F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 553);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 233);
            this.panel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtcomprobante);
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Controls.Add(this.lbproveedor);
            this.groupBox2.Controls.Add(this.kryptonLabel5);
            this.groupBox2.Controls.Add(this.kryptonLabel6);
            this.groupBox2.Controls.Add(this.lbcompraid);
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(421, 226);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // txtcomprobante
            // 
            this.txtcomprobante.Location = new System.Drawing.Point(31, 89);
            this.txtcomprobante.Margin = new System.Windows.Forms.Padding(2);
            this.txtcomprobante.Name = "txtcomprobante";
            this.txtcomprobante.ReadOnly = true;
            this.txtcomprobante.Size = new System.Drawing.Size(286, 23);
            this.txtcomprobante.TabIndex = 37;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(31, 17);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(113, 20);
            this.kryptonLabel4.TabIndex = 34;
            this.kryptonLabel4.Values.Text = "Documento origen";
            // 
            // lbproveedor
            // 
            this.lbproveedor.Location = new System.Drawing.Point(31, 148);
            this.lbproveedor.Margin = new System.Windows.Forms.Padding(2);
            this.lbproveedor.Name = "lbproveedor";
            this.lbproveedor.ReadOnly = true;
            this.lbproveedor.Size = new System.Drawing.Size(286, 23);
            this.lbproveedor.TabIndex = 38;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(31, 70);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(109, 20);
            this.kryptonLabel5.TabIndex = 35;
            this.kryptonLabel5.Values.Text = "No. Comprobante";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(31, 124);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel6.TabIndex = 36;
            this.kryptonLabel6.Values.Text = "Proveedor";
            // 
            // lbcompraid
            // 
            this.lbcompraid.Location = new System.Drawing.Point(31, 41);
            this.lbcompraid.Margin = new System.Windows.Forms.Padding(2);
            this.lbcompraid.Name = "lbcompraid";
            this.lbcompraid.ReadOnly = true;
            this.lbcompraid.Size = new System.Drawing.Size(286, 23);
            this.lbcompraid.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.lbfechaestimada);
            this.groupBox1.Controls.Add(this.lbfechasolicitud);
            this.groupBox1.Controls.Add(this.lbEstado);
            this.groupBox1.Controls.Add(this.kryptonLabel3);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Location = new System.Drawing.Point(427, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(441, 226);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Recepcion";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(53, 72);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(95, 20);
            this.kryptonLabel2.TabIndex = 32;
            this.kryptonLabel2.Values.Text = "Fecha Estimada";
            // 
            // lbfechaestimada
            // 
            this.lbfechaestimada.AutoSize = false;
            this.lbfechaestimada.Location = new System.Drawing.Point(193, 68);
            this.lbfechaestimada.Margin = new System.Windows.Forms.Padding(2);
            this.lbfechaestimada.Name = "lbfechaestimada";
            this.lbfechaestimada.Size = new System.Drawing.Size(200, 24);
            this.lbfechaestimada.TabIndex = 26;
            this.lbfechaestimada.Values.Text = "DD/MM/YY-YY";
            // 
            // lbfechasolicitud
            // 
            this.lbfechasolicitud.AutoSize = false;
            this.lbfechasolicitud.Location = new System.Drawing.Point(193, 19);
            this.lbfechasolicitud.Margin = new System.Windows.Forms.Padding(2);
            this.lbfechasolicitud.Name = "lbfechasolicitud";
            this.lbfechasolicitud.Size = new System.Drawing.Size(200, 24);
            this.lbfechasolicitud.TabIndex = 27;
            this.lbfechasolicitud.Values.Text = "DD/MM/YY-YY";
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = false;
            this.lbEstado.Location = new System.Drawing.Point(193, 121);
            this.lbEstado.Margin = new System.Windows.Forms.Padding(2);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(200, 24);
            this.lbEstado.TabIndex = 30;
            this.lbEstado.Values.Text = "Estado";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(53, 17);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(109, 20);
            this.kryptonLabel3.TabIndex = 33;
            this.kryptonLabel3.Values.Text = "Fecha de Solicitud";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(53, 121);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel1.TabIndex = 31;
            this.kryptonLabel1.Values.Text = "Estado:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnValidar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(878, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnValidar
            // 
            this.btnValidar.Image = global::Sistema.Properties.Resources.Checkmark_green_12x_16x;
            this.btnValidar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(66, 24);
            this.btnValidar.Text = "Validar";
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99.08257F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9174312F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(872, 238);
            this.tableLayoutPanel2.TabIndex = 39;
            // 
            // DetalleRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 580);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetalleRecepcion";
            this.Text = "DetalleRecepcion";
            this.Load += new System.EventHandler(this.DetalleRecepcion_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListaProductSelect)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbtotal;
        private System.Windows.Forms.Panel panel3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnValidar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbEstado;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbfechasolicitud;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbfechaestimada;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView ListaProductSelect;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcomprobante;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox lbproveedor;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox lbcompraid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}