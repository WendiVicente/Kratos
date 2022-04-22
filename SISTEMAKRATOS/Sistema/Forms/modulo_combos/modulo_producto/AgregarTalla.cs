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
    public partial class AgregarTalla : BaseContext
    {
        private List<DetalleTalla> _detalleTallas = null;
        private List<DetalleTalla> _tallaslistalocal = null;
        private NuevoProducto _nuevoProducto = null;
        private List<DetalleTalla> listadgvtemp = new List<DetalleTalla>();
        private string tallaDetalle;
        private int stockTosave;
        public AgregarTalla(NuevoProducto nuevoProducto, List<DetalleTalla> lista)
        {
            _nuevoProducto = nuevoProducto;
            _tallaslistalocal = new List<DetalleTalla>();
            _detalleTallas = lista;
            stockTosave = _nuevoProducto.stockToValidar;
            InitializeComponent();
        }


        private void AgregarTalla_Load(object sender, EventArgs e)
        {
            CargarTallasCombo();
            OcultarSubCombo();
            limpiarDGV();
           
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
        private void OcultarSubCombo()
        {
            lbColor.Visible = false;
            txtColor.Visible = false;
            comboTallas.Visible = false;

        }

        public DetalleTalla Tallas()
        {
            var listaTallas = new DetalleTalla()
            {
                Talla = tallaDetalle,
                Stock = int.Parse(txtCantidadColores.Text)
            };


            return listaTallas;
        }

        bool enabledDeleteperman=false;
        private void btnAgregarlista_Click(object sender, EventArgs e)
        {
            
            if (dgvtallaslist.RowCount <= 0) { KryptonMessageBox.Show("No hay ninguna Talla añadida"); return; }

            if (stockTosave > 0) { KryptonMessageBox.Show("Debe de utilizar todo el Stock en las diferentes tallas\n le faltan: "
                                                           + stockTosave.ToString() +" para finalizar"); return; }

            _nuevoProducto._listaTallas = _tallaslistalocal;
            _nuevoProducto.stockproducto.ReadOnly = true;
            enabledDeleteperman = true;
            Close();

        }
        private void CargaDgv(List<DetalleTalla> lista)
        {
            BindingSource source = new BindingSource();
            source.DataSource = lista;
            dgvtallaslist.DataSource = typeof(List<>);
            dgvtallaslist.DataSource = source;
            dgvtallaslist.AutoResizeColumns();
            dgvtallaslist.Columns[0].Visible = false;
            dgvtallaslist.Columns[1].Visible = false;
            dgvtallaslist.Columns[4].Visible = false;

        }

        private void Limpiartxt()
        {
            txtCantidadColores.Text = "0";
            //tallaDetalle = "";
            txtColor.Text = "";
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidadColores.Text) || txtCantidadColores.Text == "0")
            {
                KryptonMessageBox.Show("¡Debe ingresar una cantidad valida!");
                return;
            }
          

            if (rbtallapersonaliz.Checked) {
               
                tallaDetalle = txtColor.Text; 
            }

            var nuevoDetalle = Tallas();
            if (comprobarTalla(nuevoDetalle))
            {
                KryptonMessageBox.Show("¡Talla ya ingresado!");
                return;
            }
            else
            {
                if (stockTosave >= nuevoDetalle.Stock)
                {
                    stockTosave -= nuevoDetalle.Stock;
                    _tallaslistalocal.Add(nuevoDetalle);
                    CargaDgv(_tallaslistalocal);
                    Limpiartxt();
                }
                else 
                {
                    KryptonMessageBox.Show("¡Cantidad mayor al Stock Ingresado !");
                    return;
                }
               
               
               
            }
        }
        public bool comprobarTalla(DetalleTalla tallatoAdd)
        {
            foreach (DataGridViewRow row in dgvtallaslist.Rows)
            {
                if (row.Cells[3].Value.ToString() == tallatoAdd.Talla)
                {
                    return true;
                }
            }

            return false;
        }

        private void rblistacolores_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcomboTallas.Checked)
            {

                lbColor.Visible = false;
                txtColor.Visible = false;
                tallaDetalle = comboTallas.Text;
                comboTallas.Visible = true;
            }
            else
            {
              

            }

        }

        private void rbcolorespersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtallapersonaliz.Checked)
            {
                lbColor.Visible = true;
                txtColor.Visible = true;
                tallaDetalle = txtColor.Text;
                comboTallas.Visible = false;
            }
            else
            {
                lbColor.Visible = false;
                txtColor.Visible = false;

            }
        }

        private void comboTallas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tallaDetalle = comboTallas.SelectedItem.ToString();
        }

        private void AgregarTalla_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tallaslistalocal = _nuevoProducto._listaTallas;
            _detalleTallas = _nuevoProducto._listaTallas;
           // _listaTemp = _nuevoProducto._listacolores;
            if (listadgvtemp != null && enabledDeleteperman==false)
            {
                listadgvtemp.ForEach(item => _nuevoProducto._listaTallas.Add(item));

            }
            //if (dgvtallaslist.RowCount <= 0)
            //{
            //    _nuevoProducto.checktalla.Checked = false;
            //}
        }
      
        private void limpiarDGV()
        {
            if (_detalleTallas.Count == 0)
            {
                dgvtallaslist.DataSource = null;
            }
            else
            {
                _tallaslistalocal = _detalleTallas;
                CargaDgv(_tallaslistalocal);
                ValidarCantidadTallas(_tallaslistalocal);
            }
        }

       
        private void dgvtallaslist_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var filaeliminada = dgvtallaslist.CurrentRow;
            var filaActualEliminada = (DetalleTalla)dgvtallaslist.CurrentRow.DataBoundItem;
            listadgvtemp.Add(filaActualEliminada);
            //var pp = (int)filaeliminada.Cells[2].Value;
            stockTosave += (int)filaeliminada.Cells[2].Value;
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
