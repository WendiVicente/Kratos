using CapaDatos.Models.Productos;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class AgregarColorTalla : BaseContext
    {
        private List<DetalleColorTalla> _detalleColorTallas = null;
        private NuevoProducto _nuevoProducto = null;
        private string tallaDetalle;
        public string colorDetalle;
        private int stockTosave;
        public AgregarColorTalla(NuevoProducto nuevoProducto, List<DetalleColorTalla> lista)
        {
            _nuevoProducto = nuevoProducto;
            _detalleColorTallas = lista;
            stockTosave = _nuevoProducto.stockToValidar;
            InitializeComponent();
        }

        private void AgregarColorTalla_Load(object sender, EventArgs e)
        {
            CargarTallasCombo();
            CargarComboColores();
            OcultarSubCombo();
            OcultarCombocolor();
            CargaDgv();
        }
        public void CargarTallasCombo()
        {

            List<String> tallaslitacombo = new List<string>();
            tallaslitacombo.Add(" Extra Extra Grande (XXL)");
            tallaslitacombo.Add(" Extra Grande (XL)");
            tallaslitacombo.Add(" Grande (L)");
            tallaslitacombo.Add(" Mediana (M)");
            tallaslitacombo.Add(" Pequeño (S)");
            tallaslitacombo.Add(" Extra Pequeño (XS)");
            comboTallas.DataSource = tallaslitacombo;

        }
        public void CargarComboColores()
        {
            List<String> coloreslista = new List<string>();
            coloreslista.Add("Blanco");
            coloreslista.Add("Negro");
            coloreslista.Add("Azul");
            coloreslista.Add("Amarillo");
            coloreslista.Add("verde");
            coloreslista.Add("Rojo");
            cbcoloresba.DataSource = coloreslista;
        }
        private void OcultarCombocolor()
        {
            lbcolor.Visible = false;
            txtcolor.Visible = false;
            cbcoloresba.Visible = false;

        }
        private void OcultarSubCombo()
        {
            lbmedida.Visible = false;
            txtmedida.Visible = false;
            comboTallas.Visible = false;

        }
        public DetalleColorTalla TallasAndColor()
        {
            var listaTallas = new DetalleColorTalla()
            {
                Talla = tallaDetalle,
                Color= colorDetalle,
                Stock = int.Parse(txtcantidad.Text)
            };
            return listaTallas;
        }
        private void btnAgregarlista_Click(object sender, EventArgs e)
        {
            if (dgvcolorestallas.RowCount <= 0) { KryptonMessageBox.Show("No hay ninguna color ni talla añadido"); return; }

            if (stockTosave > 0)
            {
                KryptonMessageBox.Show("Debe de utilizar todo el Stock en las diferentes tallas y colores\n le faltan: "
                                        + stockTosave.ToString() + " para finalizar"); return;
            }

            _nuevoProducto._listaColorTallas = _detalleColorTallas;
            //_nuevoProducto._listaColorTallas = _detalleColorTallas;
            _nuevoProducto.stockproducto.ReadOnly = true;
            Close();
        }
        private void CargaDgv()
        {
            BindingSource source = new BindingSource();
            source.DataSource = _detalleColorTallas;
            dgvcolorestallas.DataSource = typeof(List<>);
            dgvcolorestallas.DataSource = source;
            dgvcolorestallas.AutoResizeColumns();
            //dgvcolorestallas.Columns[0].Visible = false;
            //dgvcolorestallas.Columns[1].Visible = false;
            //dgvcolorestallas.Columns[5].Visible = false;

        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcantidad.Text) || txtcantidad.Text == "0")
            {
                KryptonMessageBox.Show("¡Debe ingresar una cantidad valida!");
                return;
            }


            if (rbtallapersonaliz.Checked)
            {
                //if (string.IsNullOrEmpty(tallaDetalle)) { KryptonMessageBox.Show("¡Debe ingresar una talla valida!"); return; }
                tallaDetalle = txtmedida.Text;
            }
            if (rbcolorespersonal.Checked) { colorDetalle = txtcolor.Text; }

            var nuevoDetalle = TallasAndColor();
            if (comprobarTalla(nuevoDetalle))
            {
                KryptonMessageBox.Show("¡Talla y Color ya ingresado!");
                return;
            }
            else
            {
                if (stockTosave >= nuevoDetalle.Stock)
                {
                    stockTosave -= nuevoDetalle.Stock;
                    _detalleColorTallas.Add(nuevoDetalle);
                    CargaDgv();
                    Limpiartxt();
                }
                else
                {
                    KryptonMessageBox.Show("¡Cantidad mayor al Stock Ingresado !");
                    return;
                }



            }
        }
        private void Limpiartxt()
        {
            txtcantidad.Text = "0";
            //tallaDetalle = "";
            txtcolor.Text = "";
            txtmedida.Text = "";
        }
        public bool comprobarTalla(DetalleColorTalla ColorTallatoAdd)
        {
            foreach (DataGridViewRow row in dgvcolorestallas.Rows)
            {
                if (row.Cells[3].Value.ToString() == ColorTallatoAdd.Color && row.Cells[4].Value.ToString() == ColorTallatoAdd.Talla)
                {
                    return true;
                }
            }

            return false;
        }
        private void rbcomboTallas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcomboTallas.Checked)
            {

                lbmedida.Visible = false;
                txtmedida.Visible = false;
                tallaDetalle = comboTallas.Text;
                comboTallas.Visible = true;
            }

        }

        private void rbtallapersonaliz_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtallapersonaliz.Checked)
            {
                lbmedida.Visible = true;
                txtmedida.Visible = true;
                tallaDetalle = txtmedida.Text;
                comboTallas.Visible = false;
            }
            else
            {
                lbmedida.Visible = false;
                txtmedida.Visible = false;

            }

        }

        private void rbcolorespersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcolorespersonal.Checked)
            {
                lbcolor.Visible = true;
                txtcolor.Visible = true;
                colorDetalle = txtcolor.Text;
            }
            else
            {
                lbcolor.Visible = false;
                txtcolor.Visible = false;

            }

        }

        private void rbcolorespaleta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcolorespaleta.Checked)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string colorName;
                    if (dialog.Color.IsKnownColor)
                        colorName = dialog.Color.ToKnownColor().ToString();
                    else if (dialog.Color.IsNamedColor)
                        colorName = dialog.Color.Name;
                    else
                        colorName = dialog.Color.ToString();
                    //   MessageBox.Show(colorName);
                    colorDetalle = colorName;
                }


            }
        }

        private void rblistacolores_CheckedChanged(object sender, EventArgs e)
        {
            if (rblistacolores.Checked)
            {
                cbcoloresba.Visible = true;
                colorDetalle = cbcoloresba.SelectedItem.ToString();
            }
            else
            {
                cbcoloresba.Visible = false;
            }
        }

        private void comboTallas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tallaDetalle = comboTallas.SelectedItem.ToString();
        }

        private void cbcoloresba_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorDetalle = cbcoloresba.SelectedItem.ToString();
        }

        private void AgregarColorTalla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvcolorestallas.RowCount <= 0)
            {
                _nuevoProducto.rdcolorytalla.Checked = false;
            }
        }

        private void dgvcolorestallas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var filaeliminada = dgvcolorestallas.CurrentRow;
            stockTosave += (int)filaeliminada.Cells[2].Value;
        }
    }
}
