using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Descuento : BaseContext
    {
        private readonly MDIParent1 _mDIParent1;
        private List<String> _productoobtenido;
        private DataGridViewCellCollection _dataGridView;
       // private readonly ProductosRepository _productosRepository = null;
        int descuentocol = 2;
        int cantidadCol = 4;
        int subtotalCol = 5;
        int totalcol = 6;
        int descuentoscol = 8;

        public Descuento(List<String> productoSeleccionado, DataGridViewCellCollection dataGridView,MDIParent1 mDIParent1)
        {

            _dataGridView = dataGridView;

            _productoobtenido = productoSeleccionado;
            _mDIParent1 = mDIParent1;
            InitializeComponent();
        }


        private void CargarTextBox()
        {


            lbproducto.Text = _productoobtenido[1];
            txtpreciounit.Text = _productoobtenido[3];
            txtcantidad.Text = _productoobtenido[4];
            txtahorro.Text = _productoobtenido[2];
            txtdescuento.Text = _productoobtenido[descuentoscol];
            int cantidadOperar = int.Parse(txtcantidad.Text.ToString());
            decimal preciounidad = decimal.Parse(txtpreciounit.Text.ToString());
            decimal operacionSubtotal = cantidadOperar * preciounidad;
            txtsubtotal.Text = operacionSubtotal.ToString();
            txttotal.Text = _productoobtenido[totalcol];

        }

        private void Descuento_Load(object sender, EventArgs e)
        {
            CargarTextBox();
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            operacionCantidad();
        }
        private void txtdescuento_TextChanged(object sender, EventArgs e)
        {
            DescuentoOperacion();
        }
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            EnviarCambios();
        }

        public void operacionCantidad()
        {
            if (string.IsNullOrEmpty(txtcantidad.Text))
            {

                txtsubtotal.Text = "0.00";
                txttotal.Text = "0.00";
                return;
            }
            if (txtcantidad.Text == "0") { return; }


            var subtotalOp = ((decimal.Parse(txtpreciounit.Text.ToString())) * (int.Parse(txtcantidad.Text.ToString())));

            txtsubtotal.Text = subtotalOp.ToString();
            txttotal.Text = subtotalOp.ToString();

            if (string.IsNullOrEmpty(txtdescuento.Text)) { txtahorro.Text = "0.0"; return; }

            txttotal.Text = CalcularDescuento(subtotalOp).ToString("0.00");

        }

        private decimal CalcularDescuento(decimal monto)
        {
            var subtotalOperar = monto;
            decimal residuo;
            decimal ahorroOperado;
            var descuent = decimal.Parse(txtdescuento.Text.ToString());
            residuo = descuent / 100; //0.2 
            ahorroOperado = subtotalOperar * residuo;
            var totaldescuento = subtotalOperar - ahorroOperado;
            txtahorro.Text = ahorroOperado.ToString("0.00");
            return totaldescuento;

        }


        private void DescuentoOperacion()
        {
            decimal reciduo;
            decimal ahorroOperado;
            double mostraAhorro;

            if (string.IsNullOrEmpty(txtdescuento.Text) || string.IsNullOrEmpty(txtcantidad.Text))
            {
                txtahorro.Text = "0.00";
                txttotal.Text = txtsubtotal.Text;

            }
            else
            {

                decimal montoPrecioUnit = decimal.Parse(txtpreciounit.Text.ToString());
                decimal Cantidad = int.Parse(txtcantidad.Text.ToString());
                decimal descuent = decimal.Parse(txtdescuento.Text.ToString());

                reciduo = descuent / 100; //0.2
                decimal subtotalOp = montoPrecioUnit * Cantidad;
                ahorroOperado = subtotalOp * reciduo;

                decimal totaldescuento = subtotalOp - ahorroOperado;
                var totalAmostrar = float.Parse(totaldescuento.ToString());
                mostraAhorro = double.Parse(ahorroOperado.ToString());
                txtahorro.Text = mostraAhorro.ToString("0.00");
                txttotal.Text = totalAmostrar.ToString("0.00");
            }

        }


        private decimal EnviarvaloresForm(decimal montoaEnviar, decimal montoenlabel, decimal valorencolumnaDg, int elegirLabel)
        {

            if (montoaEnviar == valorencolumnaDg)
            {

                this.Close();
            }
            else if (montoaEnviar < valorencolumnaDg)
            {
                var restaenvio = valorencolumnaDg - montoaEnviar;

                if (elegirLabel == 1) { _mDIParent1.LabelTotal.Text = (montoenlabel - restaenvio).ToString(); }
                if (elegirLabel == 2) { _mDIParent1.lsubtotal.Text = (montoenlabel - restaenvio).ToString(); }
                if (elegirLabel == 3) { _mDIParent1.ldescuento.Text = (montoenlabel - restaenvio).ToString(); }
            }
            else if (montoaEnviar > valorencolumnaDg)
            {
                var diferenciaEn = (montoaEnviar - valorencolumnaDg);

                if (elegirLabel == 1) { _mDIParent1.LabelTotal.Text = (montoenlabel + diferenciaEn).ToString(); }
                if (elegirLabel == 2) { _mDIParent1.lsubtotal.Text = (montoenlabel + diferenciaEn).ToString(); }
                if (elegirLabel == 3) { _mDIParent1.ldescuento.Text = (montoenlabel + diferenciaEn).ToString(); }

            }
            return 1;

        }


        private void EnviarCambios()
        {



            if (string.IsNullOrEmpty(txtcantidad.Text))
            { MessageBox.Show("Debe ingresar una cantidad valida"); return; }
            if (string.IsNullOrEmpty(txtdescuento.Text))
            { MessageBox.Show("Debe ingresar un descuento valido"); return; }

            decimal totalenviar = Convert.ToDecimal(txttotal.Text);
            decimal subtotalEnviar = Convert.ToDecimal(txtsubtotal.Text);
            decimal cantidadEnviar = Convert.ToDecimal(txtcantidad.Text);
            decimal ahorroEnviar = Convert.ToDecimal(txtahorro.Text);
            int descuentosEnviar = Convert.ToInt32(txtdescuento.Text);

            if (cantidadEnviar <= 0) { MessageBox.Show("La cantidad a comprar debe ser  mayor de 0 "); return; }

            // var cantidadTotal = cantidadEnviar + (int.Parse(_productoobtenido[cantidadCol].ToString())); //sigo pensando, dale yo me puse a leer unos papeles
            // terminemos por hoy este POS, bien le damos. manana pasamos a compras, espero que si porque hay que programar usuarios aqui en POS
            // codigo ya tenemos
            
            var productoCapturado = _mDIParent1.AccesoProductoRepository().Get(int.Parse(_productoobtenido[7]));
            if (cantidadEnviar <= productoCapturado.Stock)
            {
                _dataGridView[descuentocol].Value = ahorroEnviar;
                _dataGridView[cantidadCol].Value = cantidadEnviar;
                _dataGridView[totalcol].Value = totalenviar;
                _dataGridView[subtotalCol].Value = subtotalEnviar;
                _dataGridView[descuentoscol].Value = descuentosEnviar;

                //EnviarTotal();
                EnviarvaloresForm(totalenviar, (decimal.Parse(_mDIParent1.LabelTotal.Text)), (Convert.ToDecimal(_productoobtenido[totalcol])), 1);
                //Enviarsubtotal();
                EnviarvaloresForm(subtotalEnviar, (decimal.Parse(_mDIParent1.lsubtotal.Text)), (Convert.ToDecimal(_productoobtenido[subtotalCol])), 2);

                //Enviar Descuento;
                EnviarvaloresForm(ahorroEnviar, (decimal.Parse(_mDIParent1.ldescuento.Text)), (Convert.ToDecimal(_productoobtenido[descuentocol])), 3);
                Close();
            }
            else
            {
                KryptonMessageBox.Show("La Cantidad ingresada es mayor a la existencia actual.", "ERROR", MessageBoxButtons.OK);


            }





        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtdescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }

    
}
