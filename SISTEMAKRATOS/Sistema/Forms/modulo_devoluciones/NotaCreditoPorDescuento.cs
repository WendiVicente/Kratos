using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Repository;
using CapaDatos.Repository.DevolucionesRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using Sistema.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_devoluciones
{
    public partial class NotaCreditoPorDescuento : BaseContext
    {
        private ListarVentas _venta = null;
        private FacturasRepository facturasRepository = null;
        private Factura _facturaActual = null;
        private NotaCreditoRepository _notaCreditoRepository = null;
        private NotaCreditoVista _notaCreditoVista = null;
        public NotaCreditoPorDescuento(ListarVentas venta, NotaCreditoVista _vista)
        {
           
            _venta = venta;
            facturasRepository = new FacturasRepository(_context);
            _notaCreditoRepository = new NotaCreditoRepository(_context);
            _notaCreditoVista = _vista;
            InitializeComponent();
        }

        private void NotaCreditoPorDescuento_Load(object sender, EventArgs e)
        {
            _facturaActual = facturasRepository.Get(_venta.Id);
            Crearcorrelativo();
            cargarTxt();
            operacionInicial();
        }
        private void Crearcorrelativo()
        {
            string tipo = "NC-";
            string nodocumento;
            do
            {
                nodocumento = GenerarNumeroAleatorio.GenerateRandom(tipo);
            }

            while (ExisteNoCotizacion(nodocumento));
            txtnodoc.Text = nodocumento;


        }
        private bool ExisteNoCotizacion(string cadena)
        {
            var prestamo = _notaCreditoRepository.GetNCbyNodocumento(cadena);
            if (prestamo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void cargarTxt()
        {
            txtnofactura.Text = _venta.NoFactura;
            txttotalfactura.Text = _venta.Total.ToString();
            if (_facturaActual.Cliente != null)
            {
                txtcliente.Text = _facturaActual.Cliente.Nombres + " " + _facturaActual.Cliente.Apellidos;
            }
            else
            {
                txtcliente.Text = _venta.Nombre;
            }
            
        }


        private NotaCredito GetnewmodelNota()
        {
            return new NotaCredito()
            {
                Id = Guid.NewGuid(),
                NoDocumento = txtnodoc.Text,
                Descripcion = txtdescripcion.Text,
                Monto = totaltodescontar,
                MontoDisponible= totaltodescontar,
                FechaTransaccion = DateTime.Now,
                NombreVendedor = UsuarioLogeadoSistemas.User.Name,
                FacturaId = _facturaActual.Id,


            };
        }

        private void txtdesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        decimal totaltodescontar;
        private void txtdesc_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtdesc.Text) || txtdesc.Text == "." || txtdesc.Text == "0") { txttotal.Text = "Q.0.00"; return; }
            var descuento = (decimal.Parse(txtdesc.Text) / 100);
            var montotodescontar = decimal.Parse(txttotalfactura.Text);
            totaltodescontar = ((montotodescontar * descuento));
            txttotal.Text = "Q."+ totaltodescontar.ToString();
            
        }

        private void operacionInicial()
        {
            if (string.IsNullOrEmpty(txttotalfactura.Text)) { return; }
            txttotal.Text = txttotalfactura.Text;
            txtdesc.Text = "0";
        }


        private bool guardarNotaCredito()
        {
            try
            {
                var notacreditomodel = GetnewmodelNota();
                if (ModelState.IsValid(notacreditomodel))
                {
                    _notaCreditoRepository.AddNotaCredito(notacreditomodel);
                    return true;
                }

            }
            catch (Exception ex){ KryptonMessageBox.Show(ex.Message); return false; }

            return false;

        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (guardarNotaCredito())
            {
                KryptonMessageBox.Show("Registro guardado correctamente!");
                _notaCreditoVista.CargarListaVentas();
                Close();
            }
            else { KryptonMessageBox.Show("Error al Guardar, intentelo nuevamente"); }
        }
    }
}
