
namespace POS.Forms
{
    partial class Cobro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cobro));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.tblDetalleEntidad = new System.Windows.Forms.TableLayoutPanel();
            this.lbEntidad = new System.Windows.Forms.Label();
            this.lbNumero = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.grupmontos = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel15 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel14 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel13 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txttrasnferMonto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtdebitoMonto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtcreditoMonto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtchequeMonto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtefectivoMonto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cbTipoPago = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.pbCancelar = new System.Windows.Forms.PictureBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtEntidad = new System.Windows.Forms.TextBox();
            this.pbAceptarCobro = new System.Windows.Forms.PictureBox();
            this.checkStorageFact = new System.Windows.Forms.CheckBox();
            this.pbImpresora = new System.Windows.Forms.PictureBox();
            this.checkRecibo = new System.Windows.Forms.CheckBox();
            this.checkFEL = new System.Windows.Forms.CheckBox();
            this.txtTotalCobrado = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtCantidadVuelto = new System.Windows.Forms.TextBox();
            this.txtCantidadTotal = new System.Windows.Forms.TextBox();
            this.txtCantidadValor = new System.Windows.Forms.TextBox();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtTotalCobrar = new System.Windows.Forms.TextBox();
            this.txtboxFormadpago = new System.Windows.Forms.TextBox();
            this.checkDividirPago = new System.Windows.Forms.CheckBox();
            this.dgvDatosFacturacion = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tblDetalleEntidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupmontos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupmontos.Panel)).BeginInit();
            this.grupmontos.Panel.SuspendLayout();
            this.grupmontos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAceptarCobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImpresora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosFacturacion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.dtpFecha);
            this.panel2.Controls.Add(this.tblDetalleEntidad);
            this.panel2.Controls.Add(this.grupmontos);
            this.panel2.Controls.Add(this.cbTipoPago);
            this.panel2.Controls.Add(this.pbCancelar);
            this.panel2.Controls.Add(this.txtNumero);
            this.panel2.Controls.Add(this.txtEntidad);
            this.panel2.Controls.Add(this.pbAceptarCobro);
            this.panel2.Controls.Add(this.checkStorageFact);
            this.panel2.Controls.Add(this.pbImpresora);
            this.panel2.Controls.Add(this.checkRecibo);
            this.panel2.Controls.Add(this.checkFEL);
            this.panel2.Controls.Add(this.txtTotalCobrado);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.txtCantidadVuelto);
            this.panel2.Controls.Add(this.txtCantidadTotal);
            this.panel2.Controls.Add(this.txtCantidadValor);
            this.panel2.Controls.Add(this.txtVuelto);
            this.panel2.Controls.Add(this.txtEfectivo);
            this.panel2.Controls.Add(this.txtValor);
            this.panel2.Controls.Add(this.txtTotalCobrar);
            this.panel2.Controls.Add(this.txtboxFormadpago);
            this.panel2.Controls.Add(this.checkDividirPago);
            this.panel2.Controls.Add(this.dgvDatosFacturacion);
            this.panel2.Controls.Add(this.txt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 455);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(752, 33);
            this.panel4.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(301, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "DETALLE COBRO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(150, 153);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.dtpFecha.Size = new System.Drawing.Size(134, 21);
            this.dtpFecha.TabIndex = 62;
            // 
            // tblDetalleEntidad
            // 
            this.tblDetalleEntidad.ColumnCount = 1;
            this.tblDetalleEntidad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDetalleEntidad.Controls.Add(this.lbEntidad, 0, 0);
            this.tblDetalleEntidad.Controls.Add(this.lbNumero, 0, 1);
            this.tblDetalleEntidad.Controls.Add(this.lbFecha, 0, 2);
            this.tblDetalleEntidad.Location = new System.Drawing.Point(25, 105);
            this.tblDetalleEntidad.Name = "tblDetalleEntidad";
            this.tblDetalleEntidad.RowCount = 3;
            this.tblDetalleEntidad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblDetalleEntidad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblDetalleEntidad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tblDetalleEntidad.Size = new System.Drawing.Size(124, 70);
            this.tblDetalleEntidad.TabIndex = 61;
            this.tblDetalleEntidad.Visible = false;
            // 
            // lbEntidad
            // 
            this.lbEntidad.AutoSize = true;
            this.lbEntidad.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lbEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbEntidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEntidad.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEntidad.Location = new System.Drawing.Point(3, 0);
            this.lbEntidad.Name = "lbEntidad";
            this.lbEntidad.Size = new System.Drawing.Size(118, 23);
            this.lbEntidad.TabIndex = 0;
            this.lbEntidad.Text = "ENTIDAD:";
            this.lbEntidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.BackColor = System.Drawing.Color.RoyalBlue;
            this.lbNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNumero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNumero.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumero.Location = new System.Drawing.Point(3, 23);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(118, 23);
            this.lbNumero.TabIndex = 1;
            this.lbNumero.Text = "NÚMERO CHEQUE:";
            this.lbNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.BackColor = System.Drawing.Color.Lavender;
            this.lbFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.Location = new System.Drawing.Point(3, 46);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(118, 24);
            this.lbFecha.TabIndex = 2;
            this.lbFecha.Text = "FECHA COBRO:";
            this.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grupmontos
            // 
            this.grupmontos.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonLowProfile;
            this.grupmontos.Location = new System.Drawing.Point(25, 264);
            this.grupmontos.Name = "grupmontos";
            this.grupmontos.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            // 
            // grupmontos.Panel
            // 
            this.grupmontos.Panel.Controls.Add(this.kryptonLabel16);
            this.grupmontos.Panel.Controls.Add(this.kryptonLabel15);
            this.grupmontos.Panel.Controls.Add(this.kryptonLabel14);
            this.grupmontos.Panel.Controls.Add(this.kryptonLabel13);
            this.grupmontos.Panel.Controls.Add(this.kryptonLabel12);
            this.grupmontos.Panel.Controls.Add(this.txttrasnferMonto);
            this.grupmontos.Panel.Controls.Add(this.txtdebitoMonto);
            this.grupmontos.Panel.Controls.Add(this.txtcreditoMonto);
            this.grupmontos.Panel.Controls.Add(this.txtchequeMonto);
            this.grupmontos.Panel.Controls.Add(this.txtefectivoMonto);
            this.grupmontos.Size = new System.Drawing.Size(725, 98);
            this.grupmontos.TabIndex = 60;
            this.grupmontos.Values.Heading = "Montos";
            this.grupmontos.Visible = false;
            // 
            // kryptonLabel16
            // 
            this.kryptonLabel16.Location = new System.Drawing.Point(254, 42);
            this.kryptonLabel16.Name = "kryptonLabel16";
            this.kryptonLabel16.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel16.TabIndex = 42;
            this.kryptonLabel16.Values.Text = "Transferencia";
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(487, 10);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel15.TabIndex = 41;
            this.kryptonLabel15.Values.Text = "Tarjeta Debito";
            // 
            // kryptonLabel14
            // 
            this.kryptonLabel14.Location = new System.Drawing.Point(487, 42);
            this.kryptonLabel14.Name = "kryptonLabel14";
            this.kryptonLabel14.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel14.TabIndex = 40;
            this.kryptonLabel14.Values.Text = "Tarjeta Credito";
            // 
            // kryptonLabel13
            // 
            this.kryptonLabel13.Location = new System.Drawing.Point(254, 10);
            this.kryptonLabel13.Name = "kryptonLabel13";
            this.kryptonLabel13.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel13.TabIndex = 39;
            this.kryptonLabel13.Values.Text = "Cheque";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(4, 10);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel12.TabIndex = 38;
            this.kryptonLabel12.Values.Text = "Efectivo";
            // 
            // txttrasnferMonto
            // 
            this.txttrasnferMonto.Location = new System.Drawing.Point(363, 39);
            this.txttrasnferMonto.Name = "txttrasnferMonto";
            this.txttrasnferMonto.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txttrasnferMonto.Size = new System.Drawing.Size(118, 23);
            this.txttrasnferMonto.TabIndex = 37;
            this.txttrasnferMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttrasnferMonto.TextChanged += new System.EventHandler(this.txttrasnferMonto_TextChanged);
            this.txttrasnferMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttrasnferMonto_KeyPress);
            // 
            // txtdebitoMonto
            // 
            this.txtdebitoMonto.Location = new System.Drawing.Point(597, 10);
            this.txtdebitoMonto.Name = "txtdebitoMonto";
            this.txtdebitoMonto.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtdebitoMonto.Size = new System.Drawing.Size(118, 23);
            this.txtdebitoMonto.TabIndex = 36;
            this.txtdebitoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtdebitoMonto.TextChanged += new System.EventHandler(this.txtdebitoMonto_TextChanged);
            this.txtdebitoMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdebitoMonto_KeyPress);
            // 
            // txtcreditoMonto
            // 
            this.txtcreditoMonto.Location = new System.Drawing.Point(597, 39);
            this.txtcreditoMonto.Name = "txtcreditoMonto";
            this.txtcreditoMonto.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtcreditoMonto.Size = new System.Drawing.Size(118, 23);
            this.txtcreditoMonto.TabIndex = 35;
            this.txtcreditoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtcreditoMonto.TextChanged += new System.EventHandler(this.txtcreditoMonto_TextChanged);
            this.txtcreditoMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcreditoMonto_KeyPress);
            // 
            // txtchequeMonto
            // 
            this.txtchequeMonto.Location = new System.Drawing.Point(363, 10);
            this.txtchequeMonto.Name = "txtchequeMonto";
            this.txtchequeMonto.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtchequeMonto.Size = new System.Drawing.Size(118, 23);
            this.txtchequeMonto.TabIndex = 34;
            this.txtchequeMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtchequeMonto.TextChanged += new System.EventHandler(this.txtchequeMonto_TextChanged);
            this.txtchequeMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtchequeMonto_KeyPress);
            // 
            // txtefectivoMonto
            // 
            this.txtefectivoMonto.Location = new System.Drawing.Point(113, 10);
            this.txtefectivoMonto.Name = "txtefectivoMonto";
            this.txtefectivoMonto.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtefectivoMonto.Size = new System.Drawing.Size(118, 23);
            this.txtefectivoMonto.TabIndex = 33;
            this.txtefectivoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtefectivoMonto.TextChanged += new System.EventHandler(this.txtefectivoMonto_TextChanged);
            this.txtefectivoMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtefectivoMonto_KeyPress);
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.DropDownWidth = 121;
            this.cbTipoPago.Location = new System.Drawing.Point(150, 40);
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.cbTipoPago.Size = new System.Drawing.Size(134, 21);
            this.cbTipoPago.TabIndex = 53;
            this.cbTipoPago.SelectedIndexChanged += new System.EventHandler(this.cbTipoPago_SelectedIndexChanged);
            // 
            // pbCancelar
            // 
            this.pbCancelar.Image = global::POS.Properties.Resources.CANCELAR;
            this.pbCancelar.Location = new System.Drawing.Point(156, 414);
            this.pbCancelar.Name = "pbCancelar";
            this.pbCancelar.Size = new System.Drawing.Size(38, 34);
            this.pbCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCancelar.TabIndex = 52;
            this.pbCancelar.TabStop = false;
            this.pbCancelar.Click += new System.EventHandler(this.pbCancelar_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.White;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.ForeColor = System.Drawing.Color.Black;
            this.txtNumero.Location = new System.Drawing.Point(150, 129);
            this.txtNumero.Multiline = true;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(134, 23);
            this.txtNumero.TabIndex = 57;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEntidad
            // 
            this.txtEntidad.BackColor = System.Drawing.Color.White;
            this.txtEntidad.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntidad.ForeColor = System.Drawing.Color.Black;
            this.txtEntidad.Location = new System.Drawing.Point(150, 105);
            this.txtEntidad.Multiline = true;
            this.txtEntidad.Name = "txtEntidad";
            this.txtEntidad.Size = new System.Drawing.Size(134, 23);
            this.txtEntidad.TabIndex = 58;
            this.txtEntidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pbAceptarCobro
            // 
            this.pbAceptarCobro.Image = global::POS.Properties.Resources.LISTO;
            this.pbAceptarCobro.Location = new System.Drawing.Point(91, 414);
            this.pbAceptarCobro.Name = "pbAceptarCobro";
            this.pbAceptarCobro.Size = new System.Drawing.Size(38, 34);
            this.pbAceptarCobro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAceptarCobro.TabIndex = 51;
            this.pbAceptarCobro.TabStop = false;
            this.pbAceptarCobro.Click += new System.EventHandler(this.pbAceptarCobro_Click);
            // 
            // checkStorageFact
            // 
            this.checkStorageFact.AutoSize = true;
            this.checkStorageFact.BackColor = System.Drawing.Color.White;
            this.checkStorageFact.Location = new System.Drawing.Point(210, 375);
            this.checkStorageFact.Name = "checkStorageFact";
            this.checkStorageFact.Size = new System.Drawing.Size(103, 17);
            this.checkStorageFact.TabIndex = 49;
            this.checkStorageFact.Text = "Guardar Factura";
            this.checkStorageFact.UseVisualStyleBackColor = false;
            this.checkStorageFact.CheckedChanged += new System.EventHandler(this.checkStorageFact_CheckedChanged);
            // 
            // pbImpresora
            // 
            this.pbImpresora.Image = global::POS.Properties.Resources.Imprecion;
            this.pbImpresora.Location = new System.Drawing.Point(161, 368);
            this.pbImpresora.Name = "pbImpresora";
            this.pbImpresora.Size = new System.Drawing.Size(30, 28);
            this.pbImpresora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImpresora.TabIndex = 48;
            this.pbImpresora.TabStop = false;
            // 
            // checkRecibo
            // 
            this.checkRecibo.AutoSize = true;
            this.checkRecibo.BackColor = System.Drawing.Color.White;
            this.checkRecibo.Location = new System.Drawing.Point(140, 376);
            this.checkRecibo.Name = "checkRecibo";
            this.checkRecibo.Size = new System.Drawing.Size(15, 14);
            this.checkRecibo.TabIndex = 47;
            this.checkRecibo.UseVisualStyleBackColor = false;
            this.checkRecibo.CheckedChanged += new System.EventHandler(this.checkRecibo_CheckedChanged);
            // 
            // checkFEL
            // 
            this.checkFEL.AutoSize = true;
            this.checkFEL.BackColor = System.Drawing.Color.White;
            this.checkFEL.Location = new System.Drawing.Point(28, 368);
            this.checkFEL.Name = "checkFEL";
            this.checkFEL.Size = new System.Drawing.Size(106, 30);
            this.checkFEL.TabIndex = 46;
            this.checkFEL.Text = "Generar Factura \r\nFEL";
            this.checkFEL.UseVisualStyleBackColor = false;
            this.checkFEL.CheckedChanged += new System.EventHandler(this.checkFEL_CheckedChanged);
            // 
            // txtTotalCobrado
            // 
            this.txtTotalCobrado.BackColor = System.Drawing.Color.White;
            this.txtTotalCobrado.Enabled = false;
            this.txtTotalCobrado.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCobrado.ForeColor = System.Drawing.Color.Black;
            this.txtTotalCobrado.Location = new System.Drawing.Point(585, 376);
            this.txtTotalCobrado.Multiline = true;
            this.txtTotalCobrado.Name = "txtTotalCobrado";
            this.txtTotalCobrado.Size = new System.Drawing.Size(167, 24);
            this.txtTotalCobrado.TabIndex = 45;
            this.txtTotalCobrado.Text = "0.00";
            this.txtTotalCobrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(462, 376);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(123, 24);
            this.textBox2.TabIndex = 44;
            this.textBox2.Text = "TOTAL A COBRADO:";
            // 
            // txtCantidadVuelto
            // 
            this.txtCantidadVuelto.BackColor = System.Drawing.Color.White;
            this.txtCantidadVuelto.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadVuelto.ForeColor = System.Drawing.Color.Black;
            this.txtCantidadVuelto.Location = new System.Drawing.Point(143, 236);
            this.txtCantidadVuelto.Multiline = true;
            this.txtCantidadVuelto.Name = "txtCantidadVuelto";
            this.txtCantidadVuelto.Size = new System.Drawing.Size(141, 24);
            this.txtCantidadVuelto.TabIndex = 42;
            this.txtCantidadVuelto.Text = "0.00";
            this.txtCantidadVuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCantidadTotal
            // 
            this.txtCantidadTotal.BackColor = System.Drawing.Color.White;
            this.txtCantidadTotal.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadTotal.ForeColor = System.Drawing.Color.Black;
            this.txtCantidadTotal.Location = new System.Drawing.Point(143, 212);
            this.txtCantidadTotal.Multiline = true;
            this.txtCantidadTotal.Name = "txtCantidadTotal";
            this.txtCantidadTotal.Size = new System.Drawing.Size(141, 24);
            this.txtCantidadTotal.TabIndex = 41;
            this.txtCantidadTotal.Text = "0.00";
            this.txtCantidadTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidadTotal.TextChanged += new System.EventHandler(this.txtCantidadTotal_TextChanged);
            this.txtCantidadTotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidadEfectivo_KeyDown);
            this.txtCantidadTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadEfectivo_KeyPress);
            // 
            // txtCantidadValor
            // 
            this.txtCantidadValor.BackColor = System.Drawing.Color.White;
            this.txtCantidadValor.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadValor.ForeColor = System.Drawing.Color.Black;
            this.txtCantidadValor.Location = new System.Drawing.Point(143, 189);
            this.txtCantidadValor.Multiline = true;
            this.txtCantidadValor.Name = "txtCantidadValor";
            this.txtCantidadValor.Size = new System.Drawing.Size(141, 24);
            this.txtCantidadValor.TabIndex = 40;
            this.txtCantidadValor.Text = "0.00";
            this.txtCantidadValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVuelto
            // 
            this.txtVuelto.BackColor = System.Drawing.Color.Lavender;
            this.txtVuelto.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVuelto.ForeColor = System.Drawing.Color.Black;
            this.txtVuelto.Location = new System.Drawing.Point(25, 236);
            this.txtVuelto.Multiline = true;
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.Size = new System.Drawing.Size(119, 24);
            this.txtVuelto.TabIndex = 39;
            this.txtVuelto.Text = "VUELTO:     Q";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.RoyalBlue;
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.ForeColor = System.Drawing.Color.Black;
            this.txtEfectivo.Location = new System.Drawing.Point(25, 212);
            this.txtEfectivo.Multiline = true;
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(119, 24);
            this.txtEfectivo.TabIndex = 38;
            this.txtEfectivo.Text = "EFECTIVO:  Q";
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txtValor.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.ForeColor = System.Drawing.Color.Black;
            this.txtValor.Location = new System.Drawing.Point(25, 189);
            this.txtValor.Multiline = true;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(119, 24);
            this.txtValor.TabIndex = 37;
            this.txtValor.Text = "VALOR:       Q";
            // 
            // txtTotalCobrar
            // 
            this.txtTotalCobrar.BackColor = System.Drawing.Color.White;
            this.txtTotalCobrar.Enabled = false;
            this.txtTotalCobrar.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCobrar.ForeColor = System.Drawing.Color.Black;
            this.txtTotalCobrar.Location = new System.Drawing.Point(435, 40);
            this.txtTotalCobrar.Multiline = true;
            this.txtTotalCobrar.Name = "txtTotalCobrar";
            this.txtTotalCobrar.Size = new System.Drawing.Size(124, 24);
            this.txtTotalCobrar.TabIndex = 36;
            this.txtTotalCobrar.Text = "0.00";
            this.txtTotalCobrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtboxFormadpago
            // 
            this.txtboxFormadpago.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txtboxFormadpago.Enabled = false;
            this.txtboxFormadpago.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxFormadpago.ForeColor = System.Drawing.Color.Black;
            this.txtboxFormadpago.Location = new System.Drawing.Point(25, 39);
            this.txtboxFormadpago.Multiline = true;
            this.txtboxFormadpago.Name = "txtboxFormadpago";
            this.txtboxFormadpago.Size = new System.Drawing.Size(124, 24);
            this.txtboxFormadpago.TabIndex = 35;
            this.txtboxFormadpago.Text = "FORMA DE PAGO:";
            // 
            // checkDividirPago
            // 
            this.checkDividirPago.AutoSize = true;
            this.checkDividirPago.BackColor = System.Drawing.Color.White;
            this.checkDividirPago.Location = new System.Drawing.Point(28, 72);
            this.checkDividirPago.Name = "checkDividirPago";
            this.checkDividirPago.Size = new System.Drawing.Size(96, 17);
            this.checkDividirPago.TabIndex = 34;
            this.checkDividirPago.Text = "Dividir el pago:";
            this.checkDividirPago.UseVisualStyleBackColor = false;
            this.checkDividirPago.CheckedChanged += new System.EventHandler(this.checkBoxDPago_CheckedChanged);
            // 
            // dgvDatosFacturacion
            // 
            this.dgvDatosFacturacion.AllowUserToAddRows = false;
            this.dgvDatosFacturacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDatosFacturacion.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvDatosFacturacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDatosFacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosFacturacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5});
            this.dgvDatosFacturacion.Location = new System.Drawing.Point(317, 103);
            this.dgvDatosFacturacion.Name = "dgvDatosFacturacion";
            this.dgvDatosFacturacion.ReadOnly = true;
            this.dgvDatosFacturacion.Size = new System.Drawing.Size(433, 156);
            this.dgvDatosFacturacion.TabIndex = 33;
            this.dgvDatosFacturacion.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDatosFacturacion_UserDeletingRow);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "FORMA DE PAGO";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 84;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "DOCTO";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "VALOR";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 68;
            // 
            // txt
            // 
            this.txt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt.Enabled = false;
            this.txt.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.ForeColor = System.Drawing.Color.Black;
            this.txt.Location = new System.Drawing.Point(317, 40);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(119, 24);
            this.txt.TabIndex = 31;
            this.txt.Text = "TOTAL A COBRAR:";
            // 
            // Cobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 455);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cobro";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Red Owl Software";
            this.Load += new System.EventHandler(this.Cobro_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tblDetalleEntidad.ResumeLayout(false);
            this.tblDetalleEntidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupmontos.Panel)).EndInit();
            this.grupmontos.Panel.ResumeLayout(false);
            this.grupmontos.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupmontos)).EndInit();
            this.grupmontos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAceptarCobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImpresora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosFacturacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbCancelar;
        private System.Windows.Forms.PictureBox pbAceptarCobro;
        private System.Windows.Forms.CheckBox checkStorageFact;
        private System.Windows.Forms.PictureBox pbImpresora;
        private System.Windows.Forms.CheckBox checkRecibo;
        private System.Windows.Forms.CheckBox checkFEL;
        private System.Windows.Forms.TextBox txtTotalCobrado;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtCantidadVuelto;
        private System.Windows.Forms.TextBox txtCantidadTotal;
        private System.Windows.Forms.TextBox txtCantidadValor;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtTotalCobrar;
        private System.Windows.Forms.TextBox txtboxFormadpago;
        private System.Windows.Forms.CheckBox checkDividirPago;
        private System.Windows.Forms.DataGridView dgvDatosFacturacion;
        private System.Windows.Forms.TextBox txt;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbTipoPago;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grupmontos;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel16;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel15;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel14;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel13;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttrasnferMonto;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtdebitoMonto;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtcreditoMonto;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtchequeMonto;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtefectivoMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TableLayoutPanel tblDetalleEntidad;
        private System.Windows.Forms.Label lbEntidad;
        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtEntidad;
    }
}