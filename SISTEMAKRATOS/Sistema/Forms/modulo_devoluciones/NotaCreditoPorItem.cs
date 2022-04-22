using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Devoluciones;
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
    public partial class NotaCreditoPorItem : BaseContext
    {
        private ListarVentas _venta = null;
        private NotaCreditoRepository _notaCreditoRepository = null;
        private NotaCreditoVista _notaCreditoVista = null;
        private FacturasRepository facturasRepository = null;
        private List<DetalleNotaCredito> _listaItemsNotacredito = null;
        private Factura _facturaActual = null;
        public NotaCreditoPorItem(ListarVentas venta,List<DetalleNotaCredito> _listaItems, NotaCreditoVista _vista)
        {
            InitializeComponent();
            _venta = venta;
            facturasRepository = new FacturasRepository(_context);
            _notaCreditoRepository = new NotaCreditoRepository(_context);
            _listaItemsNotacredito = _listaItems;
            _notaCreditoVista = _vista;
        }

        private void NotaCreditoPorItem_Load(object sender, EventArgs e)
        {
            _facturaActual = facturasRepository.Get(_venta.Id);
            Crearcorrelativo();
            cargarTxt();
            CargarDetalleNC();
        }
        private void Crearcorrelativo()
        {
            string tipo = "NCI-";
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
                Monto = _listaItemsNotacredito.Sum(x=>x.PrecioTotal),
                MontoDisponible= _listaItemsNotacredito.Sum(x => x.PrecioTotal),
                FechaTransaccion = DateTime.Now,
                NombreVendedor = UsuarioLogeadoSistemas.User.Name,
                FacturaId = _facturaActual.Id,
                NcbyItem = true,


            };
        }
        private void CargarDetalleNC()
        {
            //var historial = _cuentasCRepository.Getlistadepagoscreditos(idCCB);
            BindingSource source = new BindingSource();
            source.DataSource = _listaItemsNotacredito;
            dgvdetallenotacredito.DataSource = typeof(List<>);
            dgvdetallenotacredito.DataSource = source;
            dgvdetallenotacredito.AutoResizeColumns();
            //dgvdetallenotacredito.Columns[0].Visible = false;
            var suma = _listaItemsNotacredito.Sum(x => x.PrecioTotal);
            txttotal.Text = "Q." + suma.ToString();

        }
        private bool guardarNotaCredito()
        {
            try
            {
                var notacreditomodel = GetnewmodelNota();
                if (ModelState.IsValid(notacreditomodel))
                {

                    _notaCreditoRepository.AddNotaCredito(notacreditomodel);
                    GuardarDetalleNotaCredito(notacreditomodel.Id);
                    return true;
                }

            }
            catch (Exception ex) { KryptonMessageBox.Show(ex.Message); return false; }

            return false;

        }

        private void GuardarDetalleNotaCredito(Guid idNotacredito)
        {
            foreach (var item in _listaItemsNotacredito)
            {
                item.NotaCreditoId = idNotacredito;
                _notaCreditoRepository.AddDetalleNotaCredito(item);
            }
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
