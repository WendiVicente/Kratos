using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Vales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class ValesRepository
    {
        private Context _context = null;
        public ValesRepository(Context context)
        {

            _context = context;
        }

        public void Add(Vale vale, bool saveChanges = true)
        {
            _context.Vales.Add(vale);
            if (saveChanges)
            {
                _context.SaveChanges();
            }

        }

        public void AddDetalle(DetalleVale detalle, bool saveChange = true)
        {
            _context.DetalleVales.Add(detalle);
            if (saveChange)
            {
                _context.SaveChanges();
            }
        }
        public void AddDetalleRebaja(DetalleRebajas detalle, bool saveChange = true)
        {
            _context.DetalleRebajas.Add(detalle);
            if (saveChange)
            {
                _context.SaveChanges();
            }
        }
        public void AddAsignacionVale(AsignacionVale asignacion, bool saveChange = true)
        {
            _context.AsignacionVales.Add(asignacion);
            if (saveChange)
            {
                _context.SaveChanges();
            }
        }



        public void Update(Vale vale, bool saveChanges = true)
        {
            _context.Entry(vale).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void UpdateAsignacion(AsignacionVale Asing, bool saveChanges = true)
        {
            _context.Entry(Asing).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public Vale GetVale(Guid id)
        {
            return _context.Vales.Where(x => x.Id == id).FirstOrDefault();
        }
        public IList<ListarVales> GetListaVales()
        {
            var listavales = _context.Vales.AsQueryable();
            if (listavales.Count() > 0)
            {
                listavales = listavales.Where(x => x.IsActive == false);
            }
            return listavales
                .Select(x => new ListarVales
                {
                    Id = x.Id,
                    NoVale = x.NoVale,
                    Descripcion = x.Descripcion,
                    TipoPrecio = x.TiposId,
                    FechaRecepcion = x.FechaRecepcion,
                    Monto = x.Monto,
                    Sucursal = x.Sucursal.NombreSucursal,
                    Usuario = x.User.Name,
                    Tipo = x.Tipos.TipoCliente,
                }).ToList();
        }
        public IList<ListarDetalleVales> GetListaDetalleVales()
        {
            var listavales = _context.DetalleVales.AsQueryable();

            return listavales
                .Select(x => new ListarDetalleVales
                {
                    Id = x.Id,
                    ProductoId = x.Producto.Id,
                    Descripcion = x.Producto.Descripcion,
                    Cantidad=x.Cantidad,
                   // ValesId = x.Vale.Id
                }).ToList();
        }
        public List<ListarDetalleVales> GetListDetalleVale(Guid id)
        {
            // return _context.DetallePedidos.Where(x => x.PedidoId == id).ToList();


            return _context.DetalleVales

                    .Select(x => new ListarDetalleVales
                    {

                        Id = x.Id,
                        ValesId = x.AsignacionValeId,
                        ProductoId = x.ProductoId == null ? 0 : (int)x.ProductoId,
                        ComboId = x.ComboId == null ? Guid.Empty : (Guid)x.ComboId,
                        Color = x.DetalleColor.Color,
                        Talla = x.DetalleTalla.Talla,
                        Descripcion = x.ProductoId == null ? x.Combo.Descripcion : x.Producto.Descripcion,
                        Cantidad = x.Cantidad,
                        Precio = x.precio,
                        Total = x.Cantidad * x.precio,
                        DetalleColorId = x.DetalleColorId == null ? 0 : (int)x.DetalleColorId,
                        DetalleTallaId = x.DetalleTallaId == null ? 0 : (int)x.DetalleTallaId,
                        TallayColorId = x.DetalleColorTallaId == null ? 0 : (int)x.DetalleColorTallaId,

                    })
                    .ToList();
        }
        public IList<ListarDetalleRebajas> GetListaDetalleRebajas()
        {
            var listavales = _context.DetalleRebajas.AsQueryable();

            return listavales
                .Select(x => new ListarDetalleRebajas
                {
                    Id = x.Id,
                    ProductoId = x.Producto.Id,
                    Descripcion = x.Producto.Descripcion,
                    Cantidad = x.Cantidad,
                  // ValesId = x.Vale.Id
                }).ToList();
        }

        public IList<AsignacionVale> GetAsignacionVale(Guid id)
        {
            return _context.AsignacionVales.Where(x => x.ValeId == id).ToList();
                  
        }

        public AsignacionVale GetAsinacionPorCliente(int idcliente,Guid idvale)
        {
            return _context.AsignacionVales.Where(x => x.ClienteId == idcliente && x.ValeId==idvale).FirstOrDefault();
        }
        public AsignacionVale GetAsinacionPorNumero(int idnovale, Guid idvale)
        {
            return _context.AsignacionVales.Where(x => x.NoVale == idnovale && x.ValeId == idvale).FirstOrDefault();
        }

        public Vale  GetvaleByCorrel(string correlativo)
        {
            return _context.Vales.Where(x => x.NoVale == correlativo).FirstOrDefault();
        }

        public IList<ListarVales> GetListaVales(int sucursal)
        {
            var listavales = _context.Vales.AsQueryable();
            if (sucursal > 0 && listavales.Count() > 0)
            {
                listavales = listavales.Where(x => x.SucursalId == sucursal);
            }
            return listavales
                .Where(x => x.IsActive == false)
                .Select(x => new ListarVales
                {
                    Id = x.Id,
                    NoVale = x.NoVale,
                    Descripcion = x.Descripcion,
                    TipoPrecio = x.TiposId,
                    FechaRecepcion = x.FechaRecepcion,
                    Monto = x.Monto,
                    Sucursal = x.Sucursal.NombreSucursal,
                    Usuario = x.User.Name,
                    Tipo = x.Tipos.TipoCliente,
                    //Estado = x.IsActive,
                }).ToList();
        }

        public IList<DetalleVale> GetListadoDetalleVales(Guid Id)
        {
            var listavales = _context.DetalleVales.AsQueryable().ToList();
            if (listavales.Count > 0)
            {
                listavales = listavales.Where(x => x.AsignacionValeId == Id).ToList();
            }

            return listavales;
        }
        public string GetLastVale(int sucursal)
        {
            var listado = _context.Vales.ToList();
            if (listado.Count() > 0)
            {
                listado = listado.Where(x => x.SucursalId == sucursal).ToList();
                listado = listado.OrderByDescending(x => x.NoVale).ToList();
              
                if (listado.Count() > 0)
                {
                    string no = (string)listado.FirstOrDefault().NoVale;
                   
                    return no;
              
                }
                else
                {
                    return "";
                }

            }
            else
            {
                return "";
            }

        }
      
    }
}
