using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using Sistema.Forms.Extras;
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
    public partial class AgregarColor : BaseContext
    {
      //  private Producto _producto = null;
        private  List<ColoresProducto> _coloresProductos = null;
        private  List<ColoresProducto> _coloreslistalocal = null;
        private List<ColoresProducto> _listaTemp = null;
        public string colorDetalle;
        private NuevoProducto _nuevoProducto = null;
        private int stockTosave;

        public AgregarColor(NuevoProducto nuevoProducto,List<ColoresProducto> lista)
        {
            //_producto = producto;
            _nuevoProducto = nuevoProducto;
             _coloreslistalocal = new List<ColoresProducto>();
            _coloresProductos = lista;
            _listaTemp = lista;
            stockTosave = _nuevoProducto.stockToValidar;
            InitializeComponent();
        }

        private void AgregarColor_Load(object sender, EventArgs e)
        {
           
            
            CargarComboColores();
            OcultarSubCombo();
            cargarListaColoresSaves();
            limpiarDGV();
        }

        private void limpiarDGV()
        {
            if (_coloresProductos.Count == 0)
            {
                dgvColoresadd.DataSource = null;
            }
            else
            {
                _coloreslistalocal = _coloresProductos;
                CargaDgv(_coloreslistalocal);
                ValidarCantidadColores(_coloreslistalocal);
            }
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidadColores.Text) || txtCantidadColores.Text == "0")
            {
                KryptonMessageBox.Show("¡Debe ingresar una cantidad valida!");
                return;
            }
            if (rbcolorespersonal.Checked) { colorDetalle = txtColor.Text; }
            var nuevoDetalle = Colores();

            if (comprobarColor(nuevoDetalle))
            {
                KryptonMessageBox.Show("¡Color ya ingresado!");
                return;
            }
            else
            {
                if (stockTosave >= nuevoDetalle.cantidad)
                {
                    stockTosave -= nuevoDetalle.cantidad;
                    // _coloresProductos.Add(nuevoDetalle);
                    _coloreslistalocal.Add(nuevoDetalle);
                    CargaDgv(_coloreslistalocal);
                    Limpiartxt();
                }
                else
                {
                    KryptonMessageBox.Show("¡Cantidad mayor al Stock Ingresado !");
                    return;
                }
            
            }
           


        }

        public ColoresProducto Colores()
        {
            var listacolores = new ColoresProducto()
            {
                ColorDescripcion = colorDetalle,
                cantidad = int.Parse(txtCantidadColores.Text)
            };
              

        return listacolores;
        }
        private void CargaDgv(List<ColoresProducto> listacoloresAc)
        {
            BindingSource source = new BindingSource();
            source.DataSource = listacoloresAc;
            dgvColoresadd.DataSource = typeof(List<>);
            dgvColoresadd.DataSource = source;
            dgvColoresadd.AutoResizeColumns();

        }
        private void cargarListaColoresSaves()
        {/*
            if (_coloresProductos != null)
            {
                CargaDgv();
            }
            */
        }

        private void Limpiartxt()
        {
            txtCantidadColores.Text = "0";
          // ColorDetalle = "";
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
            else
            {
                // paleta.ShowDialog();
            }

            
        }

        private void rbcolorespersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcolorespersonal.Checked)
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
        private void OcultarSubCombo()
        {
            lbColor.Visible = false;
            txtColor.Visible = false;
            cbcoloresba.Visible = false;

        }

        private void cbcoloresba_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorDetalle = cbcoloresba.SelectedItem.ToString();
        }

        private void btnAgregarlista_Click(object sender, EventArgs e)
        {
            if (dgvColoresadd.RowCount <= 0) { KryptonMessageBox.Show("No hay ninguna color añadido"); return; }
            if (stockTosave > 0)
            {
                KryptonMessageBox.Show("Debe de utilizar todo el Stock en los diferentes Colores\n le faltan: "
                                        + stockTosave.ToString() + " para finalizar"); return;
            }

            _nuevoProducto._listacolores = _coloreslistalocal;
            _nuevoProducto.stockproducto.ReadOnly = true;
            Close();
        }
      

      
        public bool comprobarColor(ColoresProducto colortoAdd)
        {
            foreach (DataGridViewRow row in dgvColoresadd.Rows)
            {
                if (row.Cells[0].Value.ToString() == colortoAdd.ColorDescripcion)
                {
                    return true;
                }
            }

            return false;
        }

        private void AgregarColor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _coloreslistalocal = _nuevoProducto._listacolores;
            _coloresProductos = _nuevoProducto._listacolores;
            _listaTemp = _nuevoProducto._listacolores;
            if (listadgvtemp != null)
            {
                listadgvtemp.ForEach(item => _nuevoProducto._listacolores.Add(item));

            }
           // Close();
        }

        private List<ColoresProducto> listadgvtemp = new List<ColoresProducto>();
        private void dgvColoresadd_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
          //  KryptonMessageBox.Show("Este color se eliminara permanentemente");
            var filaeliminada = dgvColoresadd.CurrentRow;
            var filaActualEliminada = (ColoresProducto)dgvColoresadd.CurrentRow.DataBoundItem;
            listadgvtemp.Add(filaActualEliminada);
            stockTosave += (int)filaeliminada.Cells[1].Value;
        }

        private void ValidarCantidadColores(List<ColoresProducto> lista)
        {
            if (lista != null)
            {
                var totalcolores = 0;
                foreach (var item in lista)
                {
                    totalcolores += item.cantidad;
                }
                stockTosave -= totalcolores;
            }
        }

        
    }
}
