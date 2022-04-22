
namespace Sistema.Forms.modulo_producto
{
    partial class Plantilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plantilla));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolListadoProducto = new System.Windows.Forms.ToolStrip();
            this.BtnVolver = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.PageListado = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.PageGestion = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolListadoProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PageListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageGestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.toolListadoProducto, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonNavigator1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.060606F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.93939F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolListadoProducto
            // 
            this.toolListadoProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolListadoProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolListadoProducto.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolListadoProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnVolver,
            this.toolStripSeparator4,
            this.toolStripLabel1});
            this.toolListadoProducto.Location = new System.Drawing.Point(0, 0);
            this.toolListadoProducto.Name = "toolListadoProducto";
            this.toolListadoProducto.Size = new System.Drawing.Size(884, 34);
            this.toolListadoProducto.TabIndex = 4;
            this.toolListadoProducto.Text = "ToolStrip";
            // 
            // BtnVolver
            // 
            this.BtnVolver.Image = global::Sistema.Properties.Resources.volver;
            this.BtnVolver.ImageTransparentColor = System.Drawing.Color.Black;
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(24, 31);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 31);
            this.toolStripLabel1.Text = "Header";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(3, 37);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.PageListado,
            this.PageGestion});
            this.kryptonNavigator1.SelectedIndex = 1;
            this.kryptonNavigator1.Size = new System.Drawing.Size(878, 521);
            this.kryptonNavigator1.TabIndex = 5;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // PageListado
            // 
            this.PageListado.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.PageListado.Flags = 65534;
            this.PageListado.LastVisibleSet = true;
            this.PageListado.MinimumSize = new System.Drawing.Size(50, 50);
            this.PageListado.Name = "PageListado";
            this.PageListado.Size = new System.Drawing.Size(876, 494);
            this.PageListado.Text = "Listado";
            this.PageListado.ToolTipTitle = "Page ToolTip";
            this.PageListado.UniqueName = "9EC726F42E4A40A1D38EC449F14E2428";
            this.PageListado.Click += new System.EventHandler(this.PageListado_Click);
            // 
            // PageGestion
            // 
            this.PageGestion.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.PageGestion.Flags = 65534;
            this.PageGestion.LastVisibleSet = true;
            this.PageGestion.MinimumSize = new System.Drawing.Size(50, 50);
            this.PageGestion.Name = "PageGestion";
            this.PageGestion.Size = new System.Drawing.Size(876, 494);
            this.PageGestion.Text = "Gestion";
            this.PageGestion.ToolTipTitle = "Page ToolTip";
            this.PageGestion.UniqueName = "79065C536851448A72AB50B5B65392ED";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Location = new System.Drawing.Point(3, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(884, 561);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // Plantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Plantilla";
            this.Text = "Plantilla";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolListadoProducto.ResumeLayout(false);
            this.toolListadoProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PageListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageGestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ToolStrip toolListadoProducto;
        private System.Windows.Forms.ToolStripButton BtnVolver;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage PageListado;
        private ComponentFactory.Krypton.Navigator.KryptonPage PageGestion;
    }
}