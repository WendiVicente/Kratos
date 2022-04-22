using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Devoluciones;
using CapaDatos.Repository;
using CapaDatos.Repository.DevolucionesRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using POS.Validations;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_debitos
{
    public partial class NotaDebitoFactura : BaseContext
    {
        private ListarVentas _venta = null;
        private FacturasRepository _facturasRepository = null;
        private Factura _facturaActual = null;
        private NotaDebitoRepository _notaDebitoRepository = null;
        private NotaDebitoVista _notaDebitoVista = null;
        decimal totaltoaumentar;
        public NotaDebitoFactura(ListarVentas venta, NotaDebitoVista _vista)
        {
            _venta = venta;
            _facturasRepository = new FacturasRepository(_context);
            _notaDebitoRepository = new NotaDebitoRepository(_context);
            _notaDebitoVista = _vista;
            InitializeComponent();
        }
        private void NotaDebitoFactura_Load(object sender, EventArgs e)
        {
            _facturaActual = _facturasRepository.Get(_venta.Id);
            Crearcorrelativo();
            cargarTxt();
            operacionInicial();
        }
        private void Crearcorrelativo()
        {
            string tipo = "ND-";
            string nodocumento;
            do
            {
                nodocumento = GenerarNumeroAleatorios.GenerateRandom(tipo);
            }

            while (ExisteNoCotizacion(nodocumento));
            txtnodoc.Text = nodocumento;


        }
        private bool ExisteNoCotizacion(string cadena)
        {
            var prestamo = _notaDebitoRepository.GetNDbyNodocumento(cadena);
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
        private NotaDebito GetnewmodelNota()
        {
            return new NotaDebito()
            {
                Id = Guid.NewGuid(),
                NoDocumento = txtnodoc.Text,
                Descripcion = txtdescripcion.Text,
                Monto = totaltoaumentar,
                MontoDisponible = totaltoaumentar,
                FechaTransaccion = DateTime.Now,
                NombreVendedor = UsuarioLogeadoSistemas.User.Name,
                FacturaId = _facturaActual.Id,


            };
        }
        private void operacionInicial()
        {
            if (string.IsNullOrEmpty(txttotalfactura.Text)) { return; }
            txttotal.Text = txttotalfactura.Text;
            txtdesc.Text = "0";
        }
        private bool guardarNotaDebito()
        {
            try
            {
                var notaDeBitomodel = GetnewmodelNota();
                if (ModelState.IsValid(notaDeBitomodel))
                {
                    _notaDebitoRepository.Add(notaDeBitomodel);
                    return true;
                }

            }
            catch (Exception ex) { KryptonMessageBox.Show(ex.Message); return false; }

            return false;

        }

        private void txtdesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
       
        private void txtdesc_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtdesc.Text) || txtdesc.Text == "." || txtdesc.Text == "0") { txttotal.Text = "Q.0.00"; return; }
            var aumento = (decimal.Parse(txtdesc.Text) / 100);
            var montotodescontar = decimal.Parse(txttotalfactura.Text);
            totaltoaumentar = ((montotodescontar * aumento));
            txttotal.Text = "Q." + totaltoaumentar.ToString();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (guardarNotaDebito())
            {
                KryptonMessageBox.Show("Registro guardado correctamente!");
                _notaDebitoVista.CargarListaVentas();
                Close();
            }
            else { KryptonMessageBox.Show("Error al Guardar, intentelo nuevamente"); }
        }

       
    }
}
