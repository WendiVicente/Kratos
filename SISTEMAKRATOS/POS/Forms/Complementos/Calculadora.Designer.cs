
namespace POS.Forms
{
    partial class Calculadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculadora));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btndivi = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnmenos = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnmas = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnMulti = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnpunto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnC = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn0 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn9 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn8 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn7 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn6 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn5 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnigual = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtcalculador = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btndivi, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnmenos, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnmas, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnMulti, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnpunto, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnC, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn0, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn9, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn5, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn3, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnigual, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // btndivi
            // 
            this.btndivi.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            resources.ApplyResources(this.btndivi, "btndivi");
            this.btndivi.Name = "btndivi";
            this.btndivi.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btndivi.Values.Text = resources.GetString("btndivi.Values.Text");
            this.btndivi.Click += new System.EventHandler(this.btndivi_Click);
            // 
            // btnmenos
            // 
            this.btnmenos.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            resources.ApplyResources(this.btnmenos, "btnmenos");
            this.btnmenos.Name = "btnmenos";
            this.btnmenos.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnmenos.Values.Text = resources.GetString("btnmenos.Values.Text");
            this.btnmenos.Click += new System.EventHandler(this.btnmenos_Click);
            // 
            // btnmas
            // 
            this.btnmas.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            resources.ApplyResources(this.btnmas, "btnmas");
            this.btnmas.Name = "btnmas";
            this.btnmas.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnmas.Values.Text = resources.GetString("btnmas.Values.Text");
            this.btnmas.Click += new System.EventHandler(this.btnmas_Click);
            // 
            // btnMulti
            // 
            this.btnMulti.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            resources.ApplyResources(this.btnMulti, "btnMulti");
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnMulti.Values.Text = resources.GetString("btnMulti.Values.Text");
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            // 
            // btnpunto
            // 
            this.btnpunto.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            resources.ApplyResources(this.btnpunto, "btnpunto");
            this.btnpunto.Name = "btnpunto";
            this.btnpunto.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnpunto.Values.Text = resources.GetString("btnpunto.Values.Text");
            this.btnpunto.Click += new System.EventHandler(this.btnpunto_Click);
            // 
            // btnC
            // 
            this.btnC.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            resources.ApplyResources(this.btnC, "btnC");
            this.btnC.Name = "btnC";
            this.btnC.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnC.Values.Text = resources.GetString("btnC.Values.Text");
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btn0
            // 
            resources.ApplyResources(this.btn0, "btn0");
            this.btn0.Name = "btn0";
            this.btn0.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn0.TabStop = false;
            this.btn0.UseMnemonic = false;
            this.btn0.Values.Text = resources.GetString("btn0.Values.Text");
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btn9
            // 
            resources.ApplyResources(this.btn9, "btn9");
            this.btn9.Name = "btn9";
            this.btn9.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn9.Values.Text = resources.GetString("btn9.Values.Text");
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btn8
            // 
            resources.ApplyResources(this.btn8, "btn8");
            this.btn8.Name = "btn8";
            this.btn8.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn8.Values.Text = resources.GetString("btn8.Values.Text");
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn7
            // 
            resources.ApplyResources(this.btn7, "btn7");
            this.btn7.Name = "btn7";
            this.btn7.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn7.Values.Text = resources.GetString("btn7.Values.Text");
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn6
            // 
            resources.ApplyResources(this.btn6, "btn6");
            this.btn6.Name = "btn6";
            this.btn6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn6.Values.Text = resources.GetString("btn6.Values.Text");
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn5
            // 
            resources.ApplyResources(this.btn5, "btn5");
            this.btn5.Name = "btn5";
            this.btn5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn5.Values.Text = resources.GetString("btn5.Values.Text");
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn4
            // 
            resources.ApplyResources(this.btn4, "btn4");
            this.btn4.Name = "btn4";
            this.btn4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn4.Values.Text = resources.GetString("btn4.Values.Text");
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn3
            // 
            resources.ApplyResources(this.btn3, "btn3");
            this.btn3.Name = "btn3";
            this.btn3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn3.Values.Text = resources.GetString("btn3.Values.Text");
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            resources.ApplyResources(this.btn2, "btn2");
            this.btn2.Name = "btn2";
            this.btn2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn2.Values.Text = resources.GetString("btn2.Values.Text");
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            resources.ApplyResources(this.btn1, "btn1");
            this.btn1.Name = "btn1";
            this.btn1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn1.Values.Text = resources.GetString("btn1.Values.Text");
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btnigual
            // 
            this.btnigual.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            resources.ApplyResources(this.btnigual, "btnigual");
            this.btnigual.Name = "btnigual";
            this.btnigual.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnigual.Values.Text = resources.GetString("btnigual.Values.Text");
            this.btnigual.Click += new System.EventHandler(this.btnigual_Click);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.txtcalculador, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // txtcalculador
            // 
            resources.ApplyResources(this.txtcalculador, "txtcalculador");
            this.txtcalculador.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtcalculador.Name = "txtcalculador";
            this.txtcalculador.TextChanged += new System.EventHandler(this.txtcalculador_TextChanged);
            this.txtcalculador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcalculador_KeyPress);
            // 
            // Calculadora
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calculadora";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Calculadora_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Calculadora_KeyPress);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn6;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn7;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn8;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn9;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn0;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnC;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnpunto;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnMulti;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnmas;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnmenos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btndivi;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnigual;
        private System.Windows.Forms.TextBox txtcalculador;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}