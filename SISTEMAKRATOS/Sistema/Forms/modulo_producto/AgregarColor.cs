using CapaDatos.Models.Productos;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class AgregarColor : BaseContext
    {
        private readonly List<DetalleColor> _listaTemporal = new List<DetalleColor>();
        private readonly List<DetalleColor> listadgvtemp = new List<DetalleColor>();
        private List<DetalleColor> _coloreslistalocal = null;
        private ModuloProducto ModProducto = null;
        public string colorDetalle;        
        private int stockTosave;

        public AgregarColor(ModuloProducto Producto, List<DetalleColor> lista)
        {
            ModProducto = Producto;
            _coloreslistalocal = lista;            
            stockTosave = ModProducto.stockToValidar;
            InitializeComponent();
        }

        private void AgregarColor_Load(object sender, EventArgs e)
        {
            CargarComboColores();
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

        private void OcultarSubCombo()
        {
            lbColor.Visible = false;
            txtColor.Visible = false;
            CbListaColores.Visible = false;
        }

        private void LimpiarDGV()
        {
            if (_coloreslistalocal.Count == 0)
            {
                DgvColoresadd.DataSource = null;
            }
            else
            {
                CargaDgv(_coloreslistalocal);
                ValidarCantidadColores(_coloreslistalocal);
            }
        }

        private void CargaDgv(List<DetalleColor> listacoloresAc)
        {
            BindingSource source = new BindingSource
            {
                DataSource = listacoloresAc
            };
            DgvColoresadd.DataSource = typeof(List<>);
            DgvColoresadd.DataSource = source;
            DgvColoresadd.AutoResizeColumns();
            DgvColoresadd.ClearSelection();
        }

        private void ValidarCantidadColores(List<DetalleColor> lista)
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
                txtColor.Visible = true;
                colorDetalle = txtColor.Text;
            }
            else
            {
                lbColor.Visible = false;
                txtColor.Visible = false;
            }
        }

        private void TxtCantidadColores_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DgvColoresadd_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var filaeliminada = DgvColoresadd.CurrentRow;
            var filaActualEliminada = (DetalleColor)DgvColoresadd.CurrentRow.DataBoundItem;
            listadgvtemp.Add(filaActualEliminada);
            stockTosave += (int)filaeliminada.Cells[2].Value;
        }

        private void BtnAgregarlista_Click(object sender, EventArgs e)
        {
            if (DgvColoresadd.RowCount <= 0) { KryptonMessageBox.Show("No hay ninguna color añadido"); return; }
            if (stockTosave > 0)
            {
                KryptonMessageBox.Show("Debe de utilizar todo el Stock en los diferentes Colores\n le faltan: "
                                        + stockTosave.ToString() + " para finalizar"); return;
            }

            DevolverList();
            ModProducto._listacoloresProd = _listaTemporal;
            ModProducto._listacoloresDel = listadgvtemp;
            ModProducto.DetalleProd = 1;
            ModProducto.TxtStockProducto.ReadOnly = true;
            ModProducto.Producto.TieneColor = true;
            Close();
        }

        private void DevolverList()
        {
            foreach (DataGridViewRow dc in DgvColoresadd.Rows)
            {
                DetalleColor color = (DetalleColor)dc.DataBoundItem;
                _listaTemporal.Add(color);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtCantidadColores.Text) || TxtCantidadColores.Text == "0")
            {
                KryptonMessageBox.Show("¡Debe ingresar una cantidad valida!");
                return;
            }
            if (RbColorPersonal.Checked)
                colorDetalle = txtColor.Text;

            var nuevoDetalle = Colores();
            if (ComprobarColor(nuevoDetalle))
            {
                KryptonMessageBox.Show("¡Color ya ingresado!");
                return;
            }
            else
            {
                if (stockTosave >= nuevoDetalle.Stock)
                {

                    if (listadgvtemp.Count > 0)
                    {
                        var det = listadgvtemp.Where(x => x.Color == nuevoDetalle.Color);
                        if (det.Count() > 0)
                        {
                            det.ElementAt(0).Stock = nuevoDetalle.Stock;
                            stockTosave -= nuevoDetalle.Stock;
                            _coloreslistalocal.Add(det.ElementAt(0));
                            listadgvtemp.Remove(det.ElementAt(0));
                            CargaDgv(_coloreslistalocal);
                        }
                        else
                        {
                            stockTosave -= nuevoDetalle.Stock;
                            _coloreslistalocal.Add(nuevoDetalle);
                            CargaDgv(_coloreslistalocal);
                        }
                    }
                    else
                    {
                        stockTosave -= nuevoDetalle.Stock;
                        _coloreslistalocal.Add(nuevoDetalle);
                        CargaDgv(_coloreslistalocal);
                    }
                    TxtCantidadColores.Text = "";
                }
                else
                {
                    KryptonMessageBox.Show("¡Cantidad mayor al Stock Ingresado !");
                    return;
                }
            }
        }

        public DetalleColor Colores()
        {
            DetalleColor listacolores;
            Producto producto = ModProducto.Producto;
            if (producto.Id > 0)
            {
                listacolores = new DetalleColor()
                {
                    Color = colorDetalle,
                    ProductoId = producto.Id,
                    PrecioMayorista = producto.PrecioMayorista,
                    PrecioEntidadGubernamental = producto.PrecioEntidadGubernamental,
                    PrecioCuentaClave = producto.PrecioCuentaClave,
                    PrecioRevendedor = producto.PrecioRevendedor,
                    Stock = int.Parse(TxtCantidadColores.Text)
                };
            }
            else
            {
                listacolores = new DetalleColor
                {
                    Color = colorDetalle,
                    Stock = int.Parse(TxtCantidadColores.Text)
                };
            }          
            return listacolores;
        }     

        public bool ComprobarColor(DetalleColor colortoAdd)
        {
            foreach (DataGridViewRow row in DgvColoresadd.Rows)
            {
                if (row.Cells[0].Value.ToString() == colortoAdd.Color)
                {
                    return true;
                }
            }
            return false;
        }

        private void AgregarColor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModProducto._listacoloresProd.Count == 0)
                ModProducto.RbColor.Checked = false;
        }
    }
}
