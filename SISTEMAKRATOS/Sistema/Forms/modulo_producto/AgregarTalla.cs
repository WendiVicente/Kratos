using CapaDatos.Models.Productos;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class AgregarTalla : BaseContext
    {
        private readonly List<DetalleTalla> _listaTemporal = new List<DetalleTalla>();
        private List<DetalleTalla> listadgvtemp = new List<DetalleTalla>();
        private List<DetalleTalla> _tallaslistalocal = null;
        private ModuloProducto ModProducto = null;
        public string tallaDetalle;
        private int stockTosave;


        public AgregarTalla(ModuloProducto Producto, List<DetalleTalla> lista)
        {
            ModProducto = Producto;
            _tallaslistalocal = lista;
            stockTosave = ModProducto.stockToValidar;
            InitializeComponent();
        }

        private void AgregarTalla_Load(object sender, EventArgs e)
        {
            CargarTallasCombo();
            OcultarSubCombo();
            LimpiarDGV();           
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
            LbTalla.Visible = false;
            TxtTalla.Visible = false;
            CbListaTallas.Visible = false;
        }

        private void LimpiarDGV()
        {
            if (_tallaslistalocal.Count == 0)
            {
                DgvTallas.DataSource = null;
            }
            else
            {
                CargaDgv(_tallaslistalocal);
                ValidarCantidadTallas(_tallaslistalocal);
            }
        }

        private void CargaDgv(List<DetalleTalla> lista)
        {
            BindingSource source = new BindingSource
            {
                DataSource = lista
            };
            DgvTallas.DataSource = typeof(List<>);
            DgvTallas.DataSource = source;
            DgvTallas.AutoResizeColumns();
            DgvTallas.ClearSelection();
        }

        private void ValidarCantidadTallas(List<DetalleTalla> lista)
        {
            if (lista != null)
            {
                var totaltallas = 0;
                foreach (var item in lista)
                {
                    totaltallas += item.Stock;
                }
                stockTosave -= totaltallas;
            }
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

        private void TxtCantidadTallas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DgvTallas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var filaeliminada = DgvTallas.CurrentRow;
            var filaActualEliminada = (DetalleTalla)DgvTallas.CurrentRow.DataBoundItem;
            listadgvtemp.Add(filaActualEliminada);
            stockTosave += (int)filaeliminada.Cells[2].Value;
        }

        public DetalleTalla Tallas()
        {
            var listaTallas = new DetalleTalla()
            {
                Talla = tallaDetalle,
                Stock = int.Parse(TxtCantidadTallas.Text)
            };
            return listaTallas;
        }        

        private void BtnAgregarlista_Click(object sender, EventArgs e)
        {
            if (DgvTallas.RowCount <= 0) { KryptonMessageBox.Show("No hay ninguna Talla añadida"); return; }

            if (stockTosave > 0)
            {
                KryptonMessageBox.Show("Debe de utilizar todo el Stock en las diferentes tallas\n le faltan: "
                                        + stockTosave.ToString() + " para finalizar"); return;
            }
            DevolverList();
            ModProducto._listaTallasProd = _listaTemporal;
            ModProducto._listaTallasDel = listadgvtemp;
            ModProducto.TxtStockProducto.ReadOnly = true;
            ModProducto.DetalleProd = 2;
            ModProducto.Producto.TieneTalla = true;
            Close();
        }

        private void DevolverList()
        {
            foreach (DataGridViewRow dt in DgvTallas.Rows)
            {
                DetalleTalla detalle = (DetalleTalla)dt.DataBoundItem;
                _listaTemporal.Add(detalle);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtCantidadTallas.Text) || TxtCantidadTallas.Text == "0")
            {
                KryptonMessageBox.Show("¡Debe ingresar una cantidad valida!");
                return;
            }

            if (RbTallaPersonal.Checked)
                tallaDetalle = TxtTalla.Text;

            var nuevoDetalle = Tallas();
            if (ComprobarTalla(nuevoDetalle))
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
                        var det = listadgvtemp.Where(x => x.Talla == nuevoDetalle.Talla);
                        if (det.Count() > 0)
                        {
                            det.ElementAt(0).Stock = nuevoDetalle.Stock;
                            stockTosave -= nuevoDetalle.Stock;
                            _tallaslistalocal.Add(det.ElementAt(0));
                            listadgvtemp.Remove(det.ElementAt(0));
                            CargaDgv(_tallaslistalocal);
                        }
                        else
                        {
                            stockTosave -= nuevoDetalle.Stock;
                            _tallaslistalocal.Add(nuevoDetalle);
                            CargaDgv(_tallaslistalocal);
                        }
                    }
                    else
                    {
                        stockTosave -= nuevoDetalle.Stock;
                        _tallaslistalocal.Add(nuevoDetalle);
                        CargaDgv(_tallaslistalocal);
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

        public bool ComprobarTalla(DetalleTalla tallatoAdd)
        {
            foreach (DataGridViewRow row in DgvTallas.Rows)
            {
                if (row.Cells[3].Value.ToString() == tallatoAdd.Talla)
                {
                    return true;
                }
            }
            return false;
        }

        private void Limpiartxt()
        {
            TxtCantidadTallas.Text = "0";
            TxtTalla.Text = "";
        }

        private void AgregarTalla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModProducto._listaTallasProd.Count == 0)
                ModProducto.RbTalla.Checked = false;
        }
    }
}
