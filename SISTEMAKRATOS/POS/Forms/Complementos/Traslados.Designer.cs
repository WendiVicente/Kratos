
namespace POS.Forms
{
    partial class Traslados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Traslados));
            this.pnlTraslados1 = new System.Windows.Forms.Panel();
            this.tblTraslados = new System.Windows.Forms.TableLayoutPanel();
            this.dvgTraslados = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.traslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTraslado2 = new System.Windows.Forms.Panel();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cbSucursal = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCodigoAlterno = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbCódigo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTraslado3 = new System.Windows.Forms.Panel();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlTraslados1.SuspendLayout();
            this.tblTraslados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTraslados)).BeginInit();
            this.pnlTraslado2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSucursal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTraslado3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTraslados1
            // 
            this.pnlTraslados1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlTraslados1.Controls.Add(this.tblTraslados);
            this.pnlTraslados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTraslados1.Location = new System.Drawing.Point(0, 0);
            this.pnlTraslados1.Name = "pnlTraslados1";
            this.pnlTraslados1.Size = new System.Drawing.Size(652, 439);
            this.pnlTraslados1.TabIndex = 0;
            // 
            // tblTraslados
            // 
            this.tblTraslados.BackColor = System.Drawing.Color.Transparent;
            this.tblTraslados.ColumnCount = 1;
            this.tblTraslados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTraslados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTraslados.Controls.Add(this.dvgTraslados, 0, 1);
            this.tblTraslados.Controls.Add(this.pnlTraslado2, 0, 0);
            this.tblTraslados.Controls.Add(this.pnlTraslado3, 0, 2);
            this.tblTraslados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTraslados.Location = new System.Drawing.Point(0, 0);
            this.tblTraslados.Name = "tblTraslados";
            this.tblTraslados.RowCount = 3;
            this.tblTraslados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.67033F));
            this.tblTraslados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.32967F));
            this.tblTraslados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tblTraslados.Size = new System.Drawing.Size(652, 439);
            this.tblTraslados.TabIndex = 0;
            // 
            // dvgTraslados
            // 
            this.dvgTraslados.AllowUserToAddRows = false;
            this.dvgTraslados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgTraslados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgTraslados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sucursal,
            this.existencias,
            this.traslado});
            this.dvgTraslados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgTraslados.Location = new System.Drawing.Point(3, 111);
            this.dvgTraslados.Name = "dvgTraslados";
            this.dvgTraslados.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.dvgTraslados.Size = new System.Drawing.Size(646, 250);
            this.dvgTraslados.TabIndex = 0;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            // 
            // existencias
            // 
            this.existencias.HeaderText = "Cantidad Existente";
            this.existencias.Name = "existencias";
            // 
            // traslado
            // 
            this.traslado.HeaderText = "Traslado";
            this.traslado.Name = "traslado";
            // 
            // pnlTraslado2
            // 
            this.pnlTraslado2.BackColor = System.Drawing.Color.White;
            this.pnlTraslado2.Controls.Add(this.kryptonTextBox1);
            this.pnlTraslado2.Controls.Add(this.cbSucursal);
            this.pnlTraslado2.Controls.Add(this.label4);
            this.pnlTraslado2.Controls.Add(this.pictureBox1);
            this.pnlTraslado2.Controls.Add(this.label3);
            this.pnlTraslado2.Controls.Add(this.lbCodigoAlterno);
            this.pnlTraslado2.Controls.Add(this.lbCódigo);
            this.pnlTraslado2.Controls.Add(this.label2);
            this.pnlTraslado2.Controls.Add(this.label1);
            this.pnlTraslado2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTraslado2.Location = new System.Drawing.Point(3, 3);
            this.pnlTraslado2.Name = "pnlTraslado2";
            this.pnlTraslado2.Size = new System.Drawing.Size(646, 102);
            this.pnlTraslado2.TabIndex = 1;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(427, 27);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonTextBox1.Size = new System.Drawing.Size(121, 23);
            this.kryptonTextBox1.TabIndex = 9;
            this.kryptonTextBox1.Text = "0";
            // 
            // cbSucursal
            // 
            this.cbSucursal.DropDownWidth = 121;
            this.cbSucursal.Location = new System.Drawing.Point(427, 56);
            this.cbSucursal.Name = "cbSucursal";
            this.cbSucursal.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.cbSucursal.Size = new System.Drawing.Size(121, 21);
            this.cbSucursal.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sucursal:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(563, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad:";
            // 
            // lbCodigoAlterno
            // 
            this.lbCodigoAlterno.Location = new System.Drawing.Point(163, 52);
            this.lbCodigoAlterno.Name = "lbCodigoAlterno";
            this.lbCodigoAlterno.Size = new System.Drawing.Size(95, 20);
            this.lbCodigoAlterno.TabIndex = 3;
            this.lbCodigoAlterno.Values.Text = "XXX-XX COLOR";
            // 
            // lbCódigo
            // 
            this.lbCódigo.Location = new System.Drawing.Point(96, 30);
            this.lbCódigo.Name = "lbCódigo";
            this.lbCódigo.Size = new System.Drawing.Size(52, 20);
            this.lbCódigo.TabIndex = 2;
            this.lbCódigo.Values.Text = "XX-XXX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "CÓDIGO ALTERNO: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CÓDIGO:";
            // 
            // pnlTraslado3
            // 
            this.pnlTraslado3.Controls.Add(this.kryptonButton1);
            this.pnlTraslado3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTraslado3.Location = new System.Drawing.Point(3, 367);
            this.pnlTraslado3.Name = "pnlTraslado3";
            this.pnlTraslado3.Size = new System.Drawing.Size(646, 69);
            this.pnlTraslado3.TabIndex = 2;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(534, 9);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonButton1.Size = new System.Drawing.Size(103, 49);
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Values.Text = " SOLICITAR\r\nTRASLADO";
            // 
            // Traslados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 439);
            this.Controls.Add(this.pnlTraslados1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Traslados";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRASLADOS";
            this.Load += new System.EventHandler(this.Traslados_Load);
            this.pnlTraslados1.ResumeLayout(false);
            this.tblTraslados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgTraslados)).EndInit();
            this.pnlTraslado2.ResumeLayout(false);
            this.pnlTraslado2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSucursal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTraslado3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTraslados1;
        private System.Windows.Forms.TableLayoutPanel tblTraslados;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dvgTraslados;
        private System.Windows.Forms.Panel pnlTraslado2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbCodigoAlterno;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbCódigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTraslado3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbSucursal;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn existencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn traslado;
    }
}