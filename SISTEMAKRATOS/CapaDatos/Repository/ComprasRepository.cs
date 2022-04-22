using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using sharedDatabase.Models.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos.Repository
{
    public class ComprasRepository
    {
        private Context _context = null;
        public ComprasRepository(Context context)
        {
            _context = context;
        }


        public void Add(DetalleCompra detalleCompras, bool saveChanges = true)
        {
            _context.DetalleCompras.Add(detalleCompras);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void AddEncabezado(Compra compra, bool saveChanges = true)
        {
            _context.Compras.Add(compra);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }


        public IList<ListarCompras> GetListGenerales(int sucursalId)
        {

            var compras = _context.Compras.AsQueryable();
            if (sucursalId != 0)
            {
                compras = compras.Where(a => a.SucursalId == sucursalId);
            }

            return compras
               .Include(a => a.DetalleCompras).OrderByDescending(a => a.FechaRecepcion)
               
               .Where(a=> a.IsActive ==false)
               .Select(x => new ListarCompras
               {
                 
                 
                   Id = x.Id,
                   FechaRecepcion = x.FechaRecepcion,
                   NoComprobante = x.NoComprobante,
                   Sucursal = x.Sucursal.NombreSucursal,
                   Estado = x.Estado == true? "Comprado" : "Petición",
                   FechaLimite = x.FechaLimite,
                   NombreVendedor = x.NombreVendedor,
                   Proveedor = x.Proveedor.Nombre,
                   Total = x.DetalleCompras.Sum(b =>b.PrecioTotal)
                  
               }
               
               )
               .ToList();
        }


        /*
        public  IList<CompraDetalleList> GetDetalleCompra(Guid idcompra, bool relaciones = true)
        {
            var detalleCompra = _context.DetalleCompras.AsQueryable();
            if (relaciones)
            {
               // detalleCompra = detalleCompra.Include(s => s.);
            }
            return detalleCompra
                .Select(x => new CompraDetalleList
                {
                    Id =x.Id,
                    Description = x.


                })
                .Where(s => s.Id == idcompra).ToList();
        }
        */
        public List<CompraDetalleList> GetListAllDetalle()
        {

            return _context.DetalleCompras
                    .Include(x => x.Producto)
                   
                    .Select(x => new CompraDetalleList
                    {
                        Id = x.Id,
                        productoId = x.ProductoId,
                        Referencia = x.Producto.CodigoBarras,
                        Descripcion = x.Producto.Descripcion,
                        Cantidad = x.Cantidad,
                        Precio = x.Precio,
                        BaseImponible = x.BaseImponible,
                        Impuesto = x.Impuesto,
                        Total = x.PrecioTotal,
                    })
                    .ToList();
        }

        public List<CompraDetalleList> GetListDetalleCompra(Guid id)
        {

            return _context.DetalleCompras
                    .Include(x => x.Producto)
                    .Where(a => a.CompraId == id)
                    .Select(x => new CompraDetalleList
                    {
                        Id =x.Id,
                        productoId= x.ProductoId,
                        Referencia=x.Producto.CodigoBarras,
                        Descripcion = x.Producto.Descripcion,
                        Cantidad = x.Cantidad,
                        Precio = x.Precio,
                        BaseImponible= x.BaseImponible,
                        Impuesto=x.Impuesto,
                        Total = x.PrecioTotal,
                    })
                    .ToList();
        }
        public DetalleCompra Getdetalle(int id, bool includerelatedentities = true)
        {

            var detallecompras = _context.DetalleCompras.AsQueryable();

            if (includerelatedentities)
            {
                detallecompras = detallecompras
                    .Include(s => s.Producto);
            }

            return detallecompras.Where(s => s.Id == id)
                .SingleOrDefault();
        }


        public Compra Get(Guid id, bool includerelatedentities = true)
        {
            var compras = _context.Compras.AsQueryable();

            if (includerelatedentities)
            {
                compras = compras
                    .Include(s => s.recepciones);
            }

            return compras.Where(s => s.Id == id)
                .SingleOrDefault();
        }

        public void Update(Compra compra, bool savechages = true )
        {
            _context.Entry(compra).State = EntityState.Modified;
            if (savechages)
            {
                _context.SaveChanges();
            }
        }

       
        public void UpdateDetalleCompra(DetalleCompra detalleCompra, bool savechages = true)
        {
            _context.Entry(detalleCompra).State = EntityState.Modified;
            if (savechages)
            {
                _context.SaveChanges();
            }

        }
        public void DeleteProductoDetalle(DetalleCompra detalleCompra)
        {
            _context.Entry(detalleCompra).State = EntityState.Deleted;
            _context.SaveChanges();

        }

    }
}
