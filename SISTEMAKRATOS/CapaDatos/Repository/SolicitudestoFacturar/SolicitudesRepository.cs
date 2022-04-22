using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;
using CapaDatos.Models.ProductosToFacturar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.SolicitudestoFacturar
{
    public class SolicitudesRepository
    {

        Context _context = null;

        public SolicitudesRepository(Context context)
        {
            _context = context;
        }

        public void Add(SolicitudToFacturar solicitudToFacturar)
        {
             _context.SolicitudToFacturar.Add(solicitudToFacturar);
            _context.SaveChanges();
            
        }

        public void AddDetalleSolicitud(SolicitudDetalle solicitudDetalle)
        {
            _context.solicitudDetalles.Add(solicitudDetalle);
            _context.SaveChanges();
        }
        public void Update(SolicitudToFacturar solicitud)
        {
            _context.Entry(solicitud).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void UpdateDetalle(SolicitudDetalle solicitud)
        {
            _context.Entry(solicitud).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public SolicitudToFacturar Get(Guid id)
        {
            var solicitud = _context.SolicitudToFacturar.Where(x => x.Id == id).FirstOrDefault();

            return solicitud;
        }

        public List<ListarAcumuladasEncabezado> GetSolicitudesxUser(string roluser,string iduser )
        {
            var listaSolicitudes = _context.SolicitudToFacturar.AsQueryable();
            if (roluser != "Administrador") //|| roluser != "Solo Caja")
            {
                listaSolicitudes = listaSolicitudes.Where(x => x.UserId == iduser);
            }
            return listaSolicitudes.Where(x=>x.Estado==false)
                .Select(x => new ListarAcumuladasEncabezado
                {
                    Id=x.Id,
                    UserId=x.UserId,
                    NoSolicitud=x.NoSolicitud,
                    NombreCliente=x.NombreCliente,
                    Estado=x.Estado==false? "Pendiente":"Facturado",
                    Vendedor=x.Vendedor,
                    FechaVenta=x.FechaVenta



                }).ToList();
                
                
                
        }

        public List<SolicitudDetalle> GetDetallebySolicitud(Guid idSolicitud)
        {
            return _context.solicitudDetalles.Where(x => x.SolicitudToFacturarId == idSolicitud).ToList();
        }

        public List<ListaVentasAcumuladas> GetListaVentasAcumuladasbyUser(Guid idSolicitud)
        {
            var listaDetalles = _context.solicitudDetalles.AsQueryable();

            return listaDetalles.Include(a => a.Producto).Include(b => b.SolicitudToFacturar)
                .Select(x => new ListaVentasAcumuladas
                {
                    Id = x.Id,
                    Descripcion = x.ProductoId == null ?  x.Combo.Descripcion : x.Producto.Descripcion ,
                    Descuento = x.Descuento,
                    Cantidad = x.Cantidad,
                    Precio = x.Precio,
                    PrecioTotal = x.PrecioTotal,
                    SolicitudId = x.SolicitudToFacturarId,
                    SubTotal = x.SubTotal,
                    Color = x.DetalleColorId == null ?   x.DetalleColorTalla.Color : x.DetalleColor.Color,
                    Talla = x.DetalleTallaId == null ?   x.DetalleColorTalla.Talla :   x.DetalleTalla.Talla,
                    ComboId = x.ComboId == null ? Guid.Empty : (Guid)x.ComboId,
                    DetalleColorId=x.DetalleColorId==null? 0:(int)x.DetalleColorId,
                    DetalleTallaId=x.DetalleTallaId==null? 0: (int)x.DetalleTallaId,
                    TallayColorId=x.DetalleColorTallaId==null? 0:(int)x.DetalleColorTallaId,
                    ProductoId=x.ProductoId==null? 0:(int)x.ProductoId,
                    


                }).Where(x => x.SolicitudId == idSolicitud).ToList();
        }

        public List<ListarAcumuladasEncabezado> GetSolicitudes(int sucursal)
        {
            var listaSolicitudes = _context.SolicitudToFacturar.ToList();
            if (listaSolicitudes.Count() > 0)
            {
                listaSolicitudes = listaSolicitudes.Where(x => x.SucursalId == sucursal).ToList();
            }
            return listaSolicitudes.Where(x => x.Estado == false)
                .Select(x => new ListarAcumuladasEncabezado
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    NoSolicitud = x.NoSolicitud,
                    NitCliente = x.NitCliente,
                    NombreCliente = x.NombreCliente,
                    Estado = x.Estado == false ? "Pendiente" : "Facturado",
                    Vendedor = x.Vendedor,
                    FechaVenta = x.FechaVenta,
                    ClienteId = x.ClienteId,
                    Temporales = x.Temporales == null ? false : true
                }).ToList();
        }

        public List<ListarAcumuladasEncabezado> GetAllSolicitudes(int sucursal)
        {
            var listaSolicitudes = _context.SolicitudToFacturar.ToList();
            if (listaSolicitudes.Count() > 0)
            {
                listaSolicitudes = listaSolicitudes.Where(x => x.SucursalId == sucursal).ToList();
            }
            return listaSolicitudes
                .Select(x => new ListarAcumuladasEncabezado
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    NoSolicitud = x.NoSolicitud,
                    NitCliente = x.NitCliente,
                    NombreCliente = x.NombreCliente,
                    Estado = x.Estado == false ? "Pendiente" : "Facturado",
                    Vendedor = x.Vendedor,
                    FechaVenta = x.FechaVenta,
                    ClienteId = x.ClienteId,
                    Temporales = x.Temporales == null ? false : true
                }).ToList();
        }

        public string GetLastSolicitud(string tipo, int sucursal)
        {
            var listadosolicitud = _context.SolicitudToFacturar.ToList();
            if (listadosolicitud.Count() >= 1)
            {
                string noSolicitud = "";
                listadosolicitud = listadosolicitud.Where(x => x.NoSolicitud.Contains(tipo)).OrderByDescending(x => x.NoSolicitud).ToList();
                //listadosolicitud = listadosolicitud.Where(x => x.SucursalId == sucursal).ToList();
                if (listadosolicitud.Count >= 1)
                    noSolicitud = listadosolicitud.FirstOrDefault().NoSolicitud;
                else
                    noSolicitud = "";
                return noSolicitud;
            }
            else
            {
                return "";
            }
        }

        public void DeleteDetalleSolicitud(SolicitudDetalle solicitudDetalle)
        {
            _context.Entry(solicitudDetalle).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        public SolicitudDetalle GetDetalleSolicitud(int idSolicitud)
        {
            return _context.solicitudDetalles.Where(x => x.Id == idSolicitud).ToList().FirstOrDefault();
        }

        public SolicitudToFacturar GetSolicitudByNo(string NoDocumento)
        {
            return _context.SolicitudToFacturar.Where(x => x.NoSolicitud == NoDocumento).ToList().FirstOrDefault();
        }
    }
}
