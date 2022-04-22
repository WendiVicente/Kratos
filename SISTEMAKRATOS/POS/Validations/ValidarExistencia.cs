using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Validations
{
   public class ValidarExistencia
    {
        private Context _context = null;
        private CotizacionRepository _cotizacionRepository = null;
        private PedidoRepository _pedidoRepository = null;
        private ValesRepository _valesRepository = null;
        private ProductosRepository _productosRepository = null;
        private CombosRepository _combosRepository = null;
        private ColoresRepository _coloresRepository = null;
        private TallasRepository _tallasRepository = null;
        private TallasyColoresRepository _tallasyColoresRepository = null;

        /*
        //listas detalles
        public List<ListarDetalleCotiz> _listadetallesCotiz = new List<ListarDetalleCotiz>();
        public List<ListarDetallePedidos> _listadetallesPedidos = new List<ListarDetallePedidos>();
        public IList<ListarCombos> _listaCombos = new List<ListarCombos>();
        public IList<ListarProductos> _listaProductos = null;
        public List<ListarDetalleFacturas> _listaDetalleFacturas = new List<ListarDetalleFacturas>();
        public ValidarExistencia()
        {
            _cotizacionRepository = new CotizacionRepository(_context);
            _pedidoRepository = new PedidoRepository(_context);
            _valesRepository = new ValesRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
        }*/
        public  bool ValidarEx(ListarDetalleFacturas detallefactura, bool save = false)
        {
            Producto producto = new Producto();
            if (detallefactura.ProductoId != 0)
            {
                producto = _productosRepository.Get(detallefactura.ProductoId);
                if (producto.StockControl == true)
                {
                    if (producto.TieneColor == false && producto.TieneTalla == false)
                    {
                        if (producto.Stock > producto.stockMinimo)
                        {
                            var stock = producto.Stock - producto.stockMinimo;


                            if (stock >= detallefactura.Cantidad)
                            {
                                if (save)
                                {
                                    producto.Stock -= detallefactura.Cantidad;
                                    _productosRepository.Update(producto);
                                    return true;
                                }

                                return true;
                            }
                            else { return false; }

                        }
                        else { return false; }
                    }//descuento en tabla DetalleColors
                    else if (producto.TieneColor == true && producto.TieneTalla == false)
                    {
                        var listaobtenidaDetalleColor = _coloresRepository.GetProductoListaColor(producto.Id);
                        var detalleColorToLess = listaobtenidaDetalleColor.Where(x => x.Id == detallefactura.DetalleColorId).FirstOrDefault();

                        if (detalleColorToLess.Stock > producto.stockMinimo)
                        {
                            var stock = detalleColorToLess.Stock - producto.stockMinimo;

                            if (stock >= detallefactura.Cantidad)
                            {

                                if (save)
                                {
                                    detalleColorToLess.Stock -= detallefactura.Cantidad;
                                    _coloresRepository.Update(detalleColorToLess);
                                    producto.Stock -= detallefactura.Cantidad;
                                    _productosRepository.Update(producto);
                                    return true;
                                }

                                return true;
                            }
                            else
                            {
                                return false;
                            }


                        }
                        else { return false; }

                    }//Resta en tabla DetalleTalla stock 
                    else if (producto.TieneColor == false && producto.TieneTalla == true)
                    {
                        var listTallabyProducto = _tallasRepository.GetTallaListaProducto(producto.Id);
                        var detalleTallaToLess = listTallabyProducto.Where(x => x.Id == detallefactura.DetalleTallaId).FirstOrDefault();

                        if (detalleTallaToLess.Stock > producto.stockMinimo)
                        {
                            var stock = detalleTallaToLess.Stock - producto.stockMinimo;

                            if (stock >= detallefactura.Cantidad)
                            {

                                if (save)
                                {
                                    detalleTallaToLess.Stock -= detallefactura.Cantidad;
                                    _tallasRepository.Update(detalleTallaToLess);
                                    producto.Stock -= detallefactura.Cantidad;
                                    _productosRepository.Update(producto);
                                    return true;
                                }

                                return true;

                            }
                            else { return false; }
                        }
                        else
                        { return false; }


                    }
                    else if (producto.TieneColor == true && producto.TieneTalla == true)
                    {
                        var tallasyColores = _tallasyColoresRepository.GetTallaColorListaProducto(producto.Id);
                        var colorytallatoLess = tallasyColores.Where(x => x.Id == detallefactura.TallayColorId).FirstOrDefault();

                        if (colorytallatoLess.Stock > producto.stockMinimo)
                        {
                            var stock = colorytallatoLess.Stock - producto.stockMinimo;

                            if (stock >= detallefactura.Cantidad)
                            {

                                if (save)
                                {
                                    colorytallatoLess.Stock -= detallefactura.Cantidad;
                                    _tallasyColoresRepository.Update(colorytallatoLess);
                                    producto.Stock -= detallefactura.Cantidad;
                                    _productosRepository.Update(producto);
                                    return true;
                                }
                                return true;
                            }
                            else { return false; }
                        }
                        else
                        { return false; }


                    }

                }



            }
            else
            {
                var comboToLess = _combosRepository.Get(detallefactura.ComboId);
                if (comboToLess.Stock >= detallefactura.Cantidad)
                {

                    if (save)
                    {
                        comboToLess.Stock -= detallefactura.Cantidad;
                        _combosRepository.Update(comboToLess);
                        return true;
                    }
                    return true;
                }
                else
                {
                    return false;
                }


            }

            return false;






        }





    }
}
