using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;

namespace CapaDatos.Repository
{
    public class FacturasRepository
    {
        private Context _context = null;
        public FacturasRepository(Context context)
        {
            _context = context;
        }


        public void Add(DetalleFactura detalleFactura, bool saveChanges = true)
        {
            _context.DetalleFacturas.Add(detalleFactura);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }


        // listar ventas 

        public IList<ListarVentas> GetListVentasHoy(int sucursalId)
        {

            var ventas = _context.Facturas.AsQueryable();

            if (sucursalId != 0)
            {
                ventas = ventas.Where(a => a.User.SucursalId == sucursalId);
            }

            var today = DateTime.Now.Date;

            return ventas
               .Include(a => a.DetalleFacturas).OrderByDescending(a => a.FechaVenta)
               .Include(a => a.Cliente)
               // .Where(b => b.FechaVenta.Year == today.Year && b.FechaVenta.Month == today.Month && b.FechaVenta.Day == today.Day)
               .Select(x => new ListarVentas
               {
                   Total = x.DetalleFacturas.Where(b => b.PrecioTotal != 0).Sum(b => b.PrecioTotal),
                   Id = x.Id,
                   FechaVenta = x.FechaVenta,
                   NoFactura = x.NoFactura,
                   Serie = x.Serie,
                   Nombre = x.Nombre,
                   Direccion = x.Direccion,
                   NIT = x.NIT,
                   TipoPago = x.TipoPago,
                   Usuario = x.User.Name
               })
               .ToList();
        }





        public IList<Factura> SearchBy(string text)
        {
            return _context.Facturas.Where(a => a.Nombre.Contains(text) || a.NoFactura.Contains(text)).ToList();
        }


        public List<ListaDetalleProductosVenta> GetListDetailleVenta(Guid id)
        {


            return _context.DetalleFacturas
                    .Include(x => x.Producto)
                    .Where(a => a.FacturaId == id)
                    .Select(x => new ListaDetalleProductosVenta
                    {

                        Descripcion = x.Producto.Descripcion,
                        Cantidad = x.Cantidad,
                        Precio = x.Precio,
                        Ahorro = x.Descuento,
                        Subtotal = x.SubTotal,
                        Total = x.PrecioTotal,

                    })
                    .ToList();
        }

        public Factura Get(Guid id)
        {
            return _context.Facturas
                .Include(x => x.Cliente)
                .Where(a => a.Id == id).SingleOrDefault();
        }



        public IList<ListarVentas> GetFacturasPorFecha(DateTime inicio, DateTime final, int sucursalId)
        {
            var ventas = _context.Facturas.AsQueryable();

            if (sucursalId != 0)
            {
                ventas = ventas.Where(a => a.User.SucursalId == sucursalId);
            }

            return ventas
               .Include(a => a.DetalleFacturas).OrderByDescending(a => a.FechaVenta)
               .Where(a => a.FechaVenta >= inicio && a.FechaVenta <= final)
               .Select(x => new ListarVentas
               {
                   Total = x.DetalleFacturas.Sum(b => b.PrecioTotal),
                   Id = x.Id,
                   FechaVenta = x.FechaVenta,
                   NoFactura = x.NoFactura,
                   Serie = x.Serie,
                   Nombre = x.Nombre,
                   Direccion = x.Direccion,
                   NIT = x.NIT,
                   TipoPago = x.TipoPago,
                   Usuario = x.User.Name
               })
               .ToList();
        }



        public IList<ListarDetalleFacturas> GetDetallebyFactura(Guid idfact)
        {
            var ventas = _context.DetalleFacturas.AsQueryable();



            return ventas
               .Include(a => a.Producto)
                .Include(a => a.Combo)
                 .Include(a => a.DetalleColor)
                  .Include(a => a.DetalleTalla)
               .Where(a => a.FacturaId == idfact)
               .Select(x => new ListarDetalleFacturas
               {
                   Id = x.Id,
                   Descripcion = x.ProductoId == null ? x.Combo.Descripcion : x.Producto.Descripcion,
                   Cantidad = x.Cantidad,
                   Precio = x.Precio,
                   PrecioTotal = x.PrecioTotal,

                   ProductoId = x.ProductoId == null ? 0 : (int)x.ProductoId,
                   FacturaId = x.FacturaId,
                   Descuento = x.Descuento,
                   SubTotal = x.SubTotal,
                   ComboId = x.ComboId == null ? Guid.Empty : (Guid)x.ComboId,
                   DetalleColorId = x.DetalleColorId == null ? 0 : (int)x.DetalleColorId,
                   DetalleTallaId = x.DetalleTallaId == null ? 0 : (int)x.DetalleTallaId,
                   TallayColorId = x.DetalleColorTallaId == null ? 0 : (int)x.DetalleColorTallaId

               })
               .ToList();
        }

        public IList<DetalleFactura> getdetallelista(Guid id, int idcategoria)//int idcategoria, bool allcategoria,Guid id)
        {
            var listatosend = _context.DetalleFacturas.Include(x => x.Producto).Include(x => x.Producto.Categoria).Include(x => x.Factura).AsQueryable();

            if (idcategoria != 0)
            {
                listatosend= listatosend.Where(x => x.Producto.Categoria.Id == idcategoria);
            }
            return listatosend.Where(x => x.FacturaId == id).ToList();

        }
        public IList<ListarVentas> GetFacturastoReporte(DateTime inicio, DateTime final, bool todasfechas)//int idcategoria, bool allcategoria,Guid id)
        {
            //var listafacturas = _context.Facturas.Include(x => x.Cliente).Include(y => y.DetalleFacturas).Include(z => z.User);
            //if (!todasfechas)
            //{
            //    listafacturas = listafacturas.Where(a => a.FechaVenta >= inicio && a.FechaVenta <= final);
            //}

            //return (IList<Factura>)listafacturas;

            var ventas = _context.Facturas.AsQueryable();

            if (!todasfechas)
            {
                ventas = ventas.Where(a => a.FechaVenta >= inicio && a.FechaVenta <= final);
            }
            return ventas
               .Include(a => a.DetalleFacturas).OrderByDescending(a => a.FechaVenta)
               // .Where(a => a.FechaVenta >= inicio && a.FechaVenta <= final)
               .Select(x => new ListarVentas
               {
                   Total = x.DetalleFacturas.Sum(b => b.PrecioTotal),
                   Id = x.Id,
                   FechaVenta = x.FechaVenta,
                   NoFactura = x.NoFactura,
                   Serie = x.Serie,
                   Nombre = x.Nombre,
                   Direccion = x.Direccion,
                   NIT = x.NIT,
                   TipoPago = x.TipoPago,
                   Usuario = x.User.Name
               })
               .ToList();

        }
        public string GetLastFact()
        {
            var listado = _context.Facturas.ToList();
            if (listado.Count() > 0)
            {
                listado = listado.Where(x => x.NoFactura.Contains("FC-")).ToList();
                listado = listado.OrderByDescending(x => x.NoFactura).ToList();
                if (listado.Count() > 0)
                {
                    string no = (string)listado.FirstOrDefault().NoFactura;
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
