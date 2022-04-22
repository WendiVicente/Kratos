using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Repository.SolicitudestoFacturar;
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
using POS.Validations;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;

namespace POS.Forms
{
    public partial class VentaAcumulada : BaseContext
    {
        private readonly PrincipalV2 _formPadre = null;
        public List<ListarDetalleFacturas> listaDetalleFacturas = null;
        private SolicitudesRepository _solicitudesRepository = null;
        private ProductosRepository _productosRepository = null;
        private List<SolicitudDetalle> _listaDetalleSolicitud = null;
        public VentaAcumulada(PrincipalV2 formPadre, List<ListarDetalleFacturas> detalleFacturalista)
        {
            _formPadre = formPadre;
            listaDetalleFacturas = detalleFacturalista;
            _solicitudesRepository = new SolicitudesRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            InitializeComponent();
        }

        private void VentaAcumulada_Load(object sender, EventArgs e)
        {
            _listaDetalleSolicitud = new List<SolicitudDetalle>();
        }

        private SolicitudToFacturar newSolicitud()
        {
            string nombreClienteinsert =txtnombrecliente.Text;
            var nuevaSolicitud = new SolicitudToFacturar()
            {
                Id = Guid.NewGuid(),
                UserId = UsuarioLogeadoPOS.User.Id,
                FechaVenta = DateTime.Now,
                NombreCliente = nombreClienteinsert,
                Vendedor = UsuarioLogeadoPOS.User.Name,

            };
            return nuevaSolicitud;
        }

        private SolicitudDetalle modelSolicitudDetalle( ListarDetalleFacturas item)//,SolicitudToFacturar solicitudEncabezado)
        {

            var solicitudTo = new SolicitudDetalle()
            {
                //SolicitudToFacturarId=solicitudEncabezado.Id,
                Cantidad = item.Cantidad,
                Precio = item.Precio,
                Descuento = item.Descuento,
                SubTotal = (item.Cantidad * item.Precio),
                PrecioTotal = (item.Cantidad * item.Precio) - item.Descuento,
            };

            if (item.ProductoId != 0)
            {
                solicitudTo.ProductoId = item.ProductoId;
            }
            else solicitudTo.ProductoId = null;

            if (item.DetalleColorId != 0)
            {
                solicitudTo.DetalleColorId = item.DetalleColorId;
            }
            else solicitudTo.DetalleColorId = null;

            if (item.DetalleTallaId != 0)
            {
                solicitudTo.DetalleTallaId = item.DetalleTallaId;
            }
            else solicitudTo.DetalleTallaId = null;
            if (item.TallayColorId != 0)
            {
                solicitudTo.DetalleColorTallaId = item.TallayColorId;
            }
            else solicitudTo.DetalleColorTallaId = null;
            if (item.ProductoId == 0)
            {
                solicitudTo.ComboId = item.ComboId;
            }
            else solicitudTo.ComboId = null;

            return solicitudTo;


        }


        private bool GuardarDetalleSolicitud()
        {

            var detallefactura = listaDetalleFacturas;
            var encabezaSolictud = newSolicitud();
            try
            {


               
                foreach (var item in detallefactura)
                {

                    _listaDetalleSolicitud.Add(modelSolicitudDetalle(item));
                   
                }
                if (_listaDetalleSolicitud.Count != 0)
                {
                    _solicitudesRepository.Add(encabezaSolictud);
                    foreach (var detalleindividual in _listaDetalleSolicitud)
                    {
                        detalleindividual.SolicitudToFacturarId = encabezaSolictud.Id;
                        _solicitudesRepository.AddDetalleSolicitud(detalleindividual);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message);
                return false;
            }

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtnombrecliente.Text))
            {
                if (GuardarDetalleSolicitud())
                {
                    KryptonMessageBox.Show("Registro Guardado Correctamente");
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show("Error en el registro, valide los datos ingresados");
                }

            }
            else
            {
                KryptonMessageBox.Show("Es necesario Ingresar el nombre del cliente");
            }
            
        }

       

    }
}
