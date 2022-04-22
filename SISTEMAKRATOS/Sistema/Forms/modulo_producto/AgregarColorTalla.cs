using CapaDatos.Models.Productos;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class AgregarColorTalla : BaseContext
    {
        private readonly List<DetalleColorTalla> _listaTemporal = new List<DetalleColorTalla>();
        private readonly List<DetalleColorTalla> listadgvtemp = new List<DetalleColorTalla>();
        private List<DetalleColorTalla> _colorestallalocal = null;
        private ModuloProducto ModProducto = null;
        public string colorDetalle;
        public string tallaDetalle;
        private int stockTosave;

        public AgregarColorTalla(ModuloProducto Producto, List<DetalleColorTalla> lista)
        {
            ModProducto = Producto;
            _colorestallalocal = lista;
            stockTosave = ModProducto.stockToValidar;
            InitializeComponent();
        }

        private void AgregarColorTalla_Load(object sender, EventArgs e)
        {
            CargarComboColores();
            CargarTallasCombo();
            OcultarSubCombo();
            LimpiarDGV();
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
            CbListaColores.DataSource = coloreslista;
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
            CbListaTallas.DataSource = tallaslitacombo;
        }

        private void OcultarSubCombo()
        {
            lbColor.Visible = false;
            TxtColor.Visible = false;
            CbListaColores.Visible = false;
            LbTalla.Visible = false;
            TxtTalla.Visible = false;
            CbListaTallas.Visible = false;
        }

        private void LimpiarDGV()
        {
            if (_colorestallalocal.Count == 0)
            {
                DgvColorTalla.DataSource = null;
            }
            else
            {
                CargaDgv(_colorestallalocal);
                ValidarCantidadColores(_colorestallalocal);
            }
        }

        private void CargaDgv(List<DetalleColorTalla> lista)
        {
            BindingSource source = new BindingSource
            {
                DataSource = lista
            };
            DgvColorTalla.DataSource = typeof(List<>);
            DgvColorTalla.DataSource = source;
            DgvColorTalla.AutoResizeColumns();
            DgvColorTalla.ClearSelection();
        }

        private void ValidarCantidadColores(List<DetalleColorTalla> lista)
        {
            if (lista != null)
            {
                var totalcolores = 0;
                foreach (var item in lista)
                {
                    totalcolores += item.Stock;
                }
                stockTosave -= totalcolores;
            }
        }


        private void RbListaColores_CheckedChanged(object sender, EventArgs e)
        {
            if (RbListaColores.Checked)
            {
                CbListaColores.Visible = true;
                colorDetalle = CbListaColores.SelectedItem.ToString();
            }
            else
            {
                CbListaColores.Visible = false;
            }
        }

        private void CbListaColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorDetalle = CbListaColores.SelectedItem.ToString();
        }

        private void RbColoresPaleta_CheckedChanged(object sender, EventArgs e)
        {
            if (RbColoresPaleta.Checked)
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
                    colorDetalle = colorName;
                    BtnPaleta.BackColor = dialog.Color;
                    BtnPaleta.Visible = true;
                }
            }
            else
            {
                BtnPaleta.Visible = false;
            }
        }

        private void RbColoresPersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (RbColorPersonal.Checked)
            {
                lbColor.Visible = true;
                TxtColor.Visible = true;
                colorDetalle = TxtColor.Text;
            }
            else
            {
                lbColor.Visible = false;
                TxtColor.Visible = false;
            }
        }

        private void TxtTalla_TextChanged(object sender, EventArgs e)
        {
            tallaDetalle = TxtTalla.Text;
        }

        private void RbListaTallas_CheckedChanged(object sender, EventArgs e)
        {
            if (RbListaTallas.Checked)
            {
                CbListaTallas.Visible = true;
                tallaDetalle = CbListaTallas.SelectedItem.ToString();
            }
            else
            {
                CbListaTallas.Visible = false;
            }
        }

        private void CbListaTallas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tallaDetalle = CbListaTallas.SelectedItem.ToString();
        }

        private void RbTallaPersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (RbTallaPersonal.Checked)
            {
                LbTalla.Visible = true;
                TxtTalla.Visible = true;
                tallaDetalle = TxtTalla.Text;
            }
            else
            {
                LbTalla.Visible = false;
                TxtTalla.Visible = false;
            }
        }

        private void TxtColor_TextChanged(object sender, EventArgs e)
        {
            colorDetalle = TxtColor.Text;
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnAgregarlista_Click(object sender, EventArgs e)
        {
            if (DgvColorTalla.RowCount <= 0) { KryptonMessageBox.Show("No hay ninguna color añadido"); return; }
            if (stockTosave > 0)
            {
                KryptonMessageBox.Show("Debe de utilizar todo el Stock en los diferentes Colores y tallas\n le faltan: "
                                        + stockTosave.ToString() + " para finalizar"); return;
            }

            DevolverList();
            ModProducto._listaColorTallas = _listaTemporal;
            ModProducto._listaColorTallasDel = listadgvtemp;
            ModProducto.DetalleProd = 3;
            ModProducto.TxtStockProducto.ReadOnly = true;
            ModProducto.Producto.TieneColor = true;
            ModProducto.Producto.TieneTalla = true;
            Close();
        }

        private void DevolverList()
        {
            foreach (DataGridViewRow dc in DgvColorTalla.Rows)
            {
                DetalleColorTalla colortalla = (DetalleColorTalla)dc.DataBoundItem;
                _listaTemporal.Add(colortalla);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (colorDetalle == "" || tallaDetalle == "")
            {
                KryptonMessageBox.Show("¡El campo talla y/o color estan vacios!"); return;
            }

            if (string.IsNullOrEmpty(TxtCantidad.Text) || TxtCantidad.Text == "0")
            {
                KryptonMessageBox.Show("¡Debe ingresar una cantidad valida!");
                return;
            }

            var nuevoDetalle = TallasAndColor();
            if (ComprobarTallaColor(nuevoDetalle))
            {
                KryptonMessageBox.Show("¡Talla ya ingresado!");
                return;
            }
            else
            {
                if (stockTosave >= nuevoDetalle.Stock)
                {
                    if (listadgvtemp.Count > 0)
                    {
                        var det = listadgvtemp.Where(x => x.Talla == nuevoDetalle.Talla &&
                                                          x.Color == nuevoDetalle.Color);

                        if (det.Count() > 0)
                        {
                            det.ElementAt(0).Stock = nuevoDetalle.Stock;
                            stockTosave -= nuevoDetalle.Stock;
                            _colorestallalocal.Add(det.ElementAt(0));
                            listadgvtemp.Remove(det.ElementAt(0));
                            CargaDgv(_colorestallalocal);
                        }
                        else
                        {
                            stockTosave -= nuevoDetalle.Stock;
                            _colorestallalocal.Add(nuevoDetalle);
                            CargaDgv(_colorestallalocal);
                        }
                    }
                    else
                    {
                        stockTosave -= nuevoDetalle.Stock;
                        _colorestallalocal.Add(nuevoDetalle);
                        CargaDgv(_colorestallalocal);
                    }
                    Limpiartxt();
                }
                else
                {
                    KryptonMessageBox.Show("¡Cantidad mayor al Stock Ingresado !");
                    return;
                }
            }
        }

        public DetalleColorTalla TallasAndColor()
        {
            var listaColorTalla = new DetalleColorTalla()
            {
                Talla = tallaDetalle,
                Color = colorDetalle,
                Stock = int.Parse(TxtCantidad.Text)
            };
            return listaColorTalla;
        }

        public bool ComprobarTallaColor(DetalleColorTalla ColorTallatoAdd)
        {
            foreach (DataGridViewRow row in DgvColorTalla.Rows)
            {
                if (row.Cells[3].Value.ToString() == ColorTallatoAdd.Color && row.Cells[4].Value.ToString() == ColorTallatoAdd.Talla)
                {
                    return true;
                }
            }

            return false;
        }

        private void Limpiartxt()
        {
            TxtCantidad.Text = "0";
            TxtColor.Text = "";
            TxtTalla.Text = "";
        }

        private void AgregarColorTalla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModProducto._listaColorTallas.Count == 0)
                ModProducto.RbColorTalla.Checked = false;
        }
    }
}
