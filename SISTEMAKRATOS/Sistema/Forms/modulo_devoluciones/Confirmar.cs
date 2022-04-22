using CapaDatos.ListasPersonalizadas.Devoluciones;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Devoluciones;
using CapaDatos.Repository;
using CapaDatos.Repository.DevolucionesRepository;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using sharedDatabase.Models.Caja;
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
    public partial class Confirmar : BaseContext
    {
        private NotaCreditoVista _notacreditoforms = null;
        private NotaCredito _notaCredito = null;
        private readonly CajasRepository _cajasRepository = null;
        private readonly NotaCreditoRepository _notaCreditoRepository = null;
        private int sucursalId = UsuarioLogeadoSistemas.User.SucursalId;
        private ProductosRepository _productosRepository = null;
        private readonly TallasyColoresRepository _tallasyColoresRepository = null;
        private readonly CombosRepository _combosRepository = null;
        private readonly ColoresRepository _coloresRepository = null;
        private readonly TallasRepository _tallasRepository = null;
        private Caja cajaObtenida = null;
        public Confirmar(NotaCreditoVista creditovista, NotaCredito listacredito)
        {
            _notacreditoforms = creditovista;
            _notaCredito = listacredito;
            _cajasRepository = new CajasRepository(_context);
            _notaCreditoRepository = new NotaCreditoRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            InitializeComponent();
        }

        private void Confirmar_Load(object sender, EventArgs e)
        {
            rbpagocaja.Checked = true;
            cargarDatosGenerales();
            CargarCaja();
        }

        private void CargarCaja()
        {
            cajaObtenida = _cajasRepository.GetCajaAperturada(sucursalId);
            if (cajaObtenida != null)
            {
                txtcajaActiva.Text = cajaObtenida.Id.ToString();
            }
            

          }

        private void cargarDatosGenerales()
        {
           
            lbtotalfactura.Text = "Q." + _notaCredito.Monto.ToString();
            txtmontosalida.Text = "Q." + _notaCredito.MontoDisponible.ToString();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private NotaCredito updateNotacredito(NotaCredito notacredito)
        {
            notacredito.Estado = true;
            notacredito.MontoDisponible = 0;
            notacredito.FechaAceptacion = DateTime.Now;
            return notacredito;
        }
        private DetalleCaja getdetalleCaja()
        {
            return new DetalleCaja()
            {
                Descripcion = "Devolución Nota de Crédito",
                Egreso = _notaCredito.Monto

            };
        }

       
        private bool validarCajaActiva()
        {
            try
            {
                if (cajaObtenida == null)
                {
                    KryptonMessageBox.Show("No hay ninguna caja aperturada en esta sucursal");
                    return false;
                }
                else
                {
                    // cajaObtenida = _cajasRepository.GetCajaAperturada(sucursalId);
                    var detalleCaja = getdetalleCaja();
                    detalleCaja.CajaId = cajaObtenida.Id;
                    _cajasRepository.AddDetalleCaja(detalleCaja);
                    return true;
                }
               
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
                return false;
            }

        }
        private void Guardar()
        {
            if (rbpagocaja.Checked == true)
            {
                if (validarCajaActiva())
                {
                    var notaCredito = updateNotacredito(_notaCredito);
                    try
                    {
                        CargarlistaDetalle();
                        _notaCreditoRepository.UpdateNotaCredito(notaCredito);
                       
                        KryptonMessageBox.Show("Registro Guarda Correctamente");
                        _notacreditoforms.CargarListaVentas();
                        Close();
                    }
                    catch (Exception ex)
                    {

                        KryptonMessageBox.Show(ex.Message);
                    }
                }


            }
            else
            {
                CargarlistaDetalle();
                Close();
            }
            
        }
        private void CargarlistaDetalle()
        {
            if (_notaCredito.NcbyItem == true)
            {
                var listanotacredito = _notaCreditoRepository.GetDetalleByNotaCredito(_notaCredito.Id);
                foreach (var item in listanotacredito)
                {
                    RollbackProductos(item, true);
                }
            }
        }

        public bool RollbackProductos(DetalleNotaCredito detalleNC, bool save = false)
        {
            Producto producto = new Producto();
            if (detalleNC.ProductoId != 0)
            {
                producto = _productosRepository.Get((int)detalleNC.ProductoId);
                if (producto.StockControl == true)
                {
                    if (producto.TieneColor == false && producto.TieneTalla == false)
                    {
                        if (save)
                        {
                            producto.Stock += detalleNC.Cantidad;
                            _productosRepository.Update(producto);
                            return true;
                        }



                    }//descuento en tabla DetalleColors
                    else if (producto.TieneColor == true && producto.TieneTalla == false)
                    {
                        var listaobtenidaDetalleColor = _coloresRepository.GetProductoListaColor(producto.Id);
                        var detalleColorToLess = listaobtenidaDetalleColor.Where(x => x.Id == detalleNC.DetalleColorId).FirstOrDefault();

                        if (save)
                        {
                            detalleColorToLess.Stock += detalleNC.Cantidad;
                            _coloresRepository.Update(detalleColorToLess);
                            producto.Stock += detalleNC.Cantidad;
                            _productosRepository.Update(producto);
                            return true;
                        }

                    }//Resta en tabla DetalleTalla stock 
                    else if (producto.TieneColor == false && producto.TieneTalla == true)
                    {
                        var listTallabyProducto = _tallasRepository.GetTallaListaProducto(producto.Id);
                        var detalleTallaToLess = listTallabyProducto.Where(x => x.Id == detalleNC.DetalleTallaId).FirstOrDefault();

                        if (save)
                        {
                            detalleTallaToLess.Stock += detalleNC.Cantidad;
                            _tallasRepository.Update(detalleTallaToLess);
                            producto.Stock += detalleNC.Cantidad;
                            _productosRepository.Update(producto);
                            return true;
                        }
                    }
                    else if (producto.TieneColor == true && producto.TieneTalla == true)
                    {
                        var tallasyColores = _tallasyColoresRepository.GetTallaColorListaProducto(producto.Id);
                        var colorytallatoLess = tallasyColores.Where(x => x.Id == detalleNC.TallayColorId).FirstOrDefault();

                        if (save)
                        {
                            colorytallatoLess.Stock += detalleNC.Cantidad;
                            _tallasyColoresRepository.Update(colorytallatoLess);
                            producto.Stock += detalleNC.Cantidad;
                            _productosRepository.Update(producto);
                            return true;
                        }

                    }

                }



            }
            else
            {
                var comboToLess = _combosRepository.Get((Guid)detalleNC.ComboId);

                if (save)
                {
                    comboToLess.Stock += detalleNC.Cantidad;
                    _combosRepository.Update(comboToLess);
                    return true;
                }

            }

            return false;

        }

    }
}
