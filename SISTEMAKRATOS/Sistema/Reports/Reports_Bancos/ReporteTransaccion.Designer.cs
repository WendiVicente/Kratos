namespace Sistema.Reports.Reports_Bancos
{
    partial class ReporteTransaccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteTransaccion));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtenvios = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.rbwhatsap = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbemail = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbsucursales = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.comboEstadosT = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.comboTiposmovi = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkfechas = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpfechainicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpfechafinal = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btngenerar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.rvtransac = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboEstadosT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTiposmovi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1408, 674);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.groupBox5);
            this.kryptonPanel2.Controls.Add(this.groupBox2);
            this.kryptonPanel2.Controls.Add(this.groupBox1);
            this.kryptonPanel2.Controls.Add(this.toolStrip1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1408, 190);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.txtenvios);
            this.groupBox5.Controls.Add(this.rbwhatsap);
            this.groupBox5.Controls.Add(this.rbemail);
            this.groupBox5.Location = new System.Drawing.Point(1110, 30);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(286, 153);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Envios";
            // 
            // txtenvios
            // 
            this.txtenvios.Location = new System.Drawing.Point(15, 93);
            this.txtenvios.Name = "txtenvios";
            this.txtenvios.Size = new System.Drawing.Size(122, 27);
            this.txtenvios.TabIndex = 2;
            // 
            // rbwhatsap
            // 
            this.rbwhatsap.Location = new System.Drawing.Point(15, 59);
            this.rbwhatsap.Name = "rbwhatsap";
            this.rbwhatsap.Size = new System.Drawing.Size(92, 24);
            this.rbwhatsap.TabIndex = 1;
            this.rbwhatsap.Values.Text = "Whatsapp";
            // 
            // rbemail
            // 
            this.rbemail.Location = new System.Drawing.Point(15, 29);
            this.rbemail.Name = "rbemail";
            this.rbemail.Size = new System.Drawing.Size(60, 24);
            this.rbemail.TabIndex = 0;
            this.rbemail.Values.Text = "Email";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.kryptonLabel5);
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Controls.Add(this.kryptonLabel3);
            this.groupBox2.Controls.Add(this.cbsucursales);
            this.groupBox2.Controls.Add(this.comboEstadosT);
            this.groupBox2.Controls.Add(this.comboTiposmovi);
            this.groupBox2.Location = new System.Drawing.Point(619, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 153);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro de Clientes";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(6, 31);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(128, 24);
            this.kryptonLabel5.TabIndex = 5;
            this.kryptonLabel5.Values.Text = "Tipo Movimiento";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(6, 71);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(64, 24);
            this.kryptonLabel4.TabIndex = 4;
            this.kryptonLabel4.Values.Text = "Estados";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(6, 113);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(68, 24);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Sucursal";
            // 
            // cbsucursales
            // 
            this.cbsucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsucursales.DropDownWidth = 226;
            this.cbsucursales.Location = new System.Drawing.Point(140, 112);
            this.cbsucursales.Name = "cbsucursales";
            this.cbsucursales.Size = new System.Drawing.Size(255, 25);
            this.cbsucursales.TabIndex = 2;
            // 
            // comboEstadosT
            // 
            this.comboEstadosT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstadosT.DropDownWidth = 226;
            this.comboEstadosT.Location = new System.Drawing.Point(140, 70);
            this.comboEstadosT.Name = "comboEstadosT";
            this.comboEstadosT.Size = new System.Drawing.Size(255, 25);
            this.comboEstadosT.TabIndex = 1;
            // 
            // comboTiposmovi
            // 
            this.comboTiposmovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTiposmovi.DropDownWidth = 226;
            this.comboTiposmovi.Location = new System.Drawing.Point(140, 30);
            this.comboTiposmovi.Name = "comboTiposmovi";
            this.comboTiposmovi.Size = new System.Drawing.Size(255, 25);
            this.comboTiposmovi.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkfechas);
            this.groupBox1.Controls.Add(this.dtpfechainicio);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.dtpfechafinal);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 153);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de Creación";
            // 
            // checkfechas
            // 
            this.checkfechas.Location = new System.Drawing.Point(8, 112);
            this.checkfechas.Name = "checkfechas";
            this.checkfechas.Size = new System.Drawing.Size(138, 24);
            this.checkfechas.TabIndex = 5;
            this.checkfechas.Values.Text = "Todas las Fechas";
            this.checkfechas.CheckedChanged += new System.EventHandler(this.checkfechas_CheckedChanged_1);
            // 
            // dtpfechainicio
            // 
            this.dtpfechainicio.Location = new System.Drawing.Point(127, 31);
            this.dtpfechainicio.Name = "dtpfechainicio";
            this.dtpfechainicio.Size = new System.Drawing.Size(256, 25);
            this.dtpfechainicio.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 71);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(75, 24);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Fecha Fin";
            // 
            // dtpfechafinal
            // 
            this.dtpfechafinal.Location = new System.Drawing.Point(127, 71);
            this.dtpfechafinal.Name = "dtpfechafinal";
            this.dtpfechafinal.Size = new System.Drawing.Size(256, 25);
            this.dtpfechafinal.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 31);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(92, 24);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Fecha Inicio";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btngenerar,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1408, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btngenerar
            // 
            this.btngenerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(122, 24);
            this.btngenerar.Text = "Generar Reporte";
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.rvtransac);
            this.kryptonPanel3.Location = new System.Drawing.Point(3, 189);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(1448, 481);
            this.kryptonPanel3.TabIndex = 1;
            // 
            // rvtransac
            // 
            this.rvtransac.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Bancos.ReporteTransaccion.rdlc";
            this.rvtransac.Location = new System.Drawing.Point(0, 0);
            this.rvtransac.Name = "rvtransac";
            this.rvtransac.ServerReport.BearerToken = null;
            this.rvtransac.Size = new System.Drawing.Size(1393, 481);
            this.rvtransac.TabIndex = 0;
            // 
            // ReporteTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 674);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteTransaccion";
            this.Text = "ReporteTransaccion";
            this.Load += new System.EventHandler(this.ReporteTransaccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbsucursales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboEstadosT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTiposmovi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private Microsoft.Reporting.WinForms.ReportViewer rvtransac;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.GroupBox groupBox5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtenvios;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbwhatsap;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbemail;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbsucursales;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboEstadosT;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboTiposmovi;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkfechas;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechainicio;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpfechafinal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btngenerar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}