using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;
using CapaDatos.Models.ProductosToFacturar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class ProductosTempRepository
    {
        private Context _context = null;

        public ProductosTempRepository(Context context)
        {
            _context = context;
        }
        public void Add(TemporalProductos TemporalProductos, bool saveChanges = true)
        {
            _context.TemporalProductos.Add(TemporalProductos);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public List<ListaProductosTmp> GetTemporalProductosLista()
        {
            var ventas = _context.TemporalProductos.AsQueryable();



            return ventas
               .Include(a => a.Producto)
                .Include(a => a.Combo)
                 .Include(a => a.DetalleColor)
                  .Include(a => a.DetalleTalla)
               //.Where(a => a.FacturaId == idfact)
               .Select(x => new ListaProductosTmp
               {
                   Id = x.Id,
                   Descripcion = x.ProductoId == 0 ? x.Combo.Descripcion : x.Producto.Descripcion,
                   Cantidad = x.Cantidad,
                   Precio = x.Precio,
                   PrecioTotal = x.PrecioTotal,
                   
                   ProductoId = x.ProductoId == 0 ? 0 : (int)x.ProductoId,
                  
                   Descuento = x.Descuento,
                   SubTotal = x.SubTotal,
                   ComboId = x.ComboId == null ? Guid.Empty : (Guid)x.ComboId,
                   DetalleColorId = x.DetalleColorId == null ? 0 : (int)x.DetalleColorId,
                   DetalleTallaId = x.DetalleTallaId == null ? 0 : (int)x.DetalleTallaId,
                   TallayColorId = x.DetalleColorTallaId == null ? 0 : (int)x.DetalleColorTallaId,
                   Color=x.DetalleColorId==null? x.DetalleColorTalla.Color:x.DetalleColor.Color,
                   Talla=x.DetalleTallaId==null? x.DetalleColorTalla.Talla:x.DetalleTalla.Talla,
                   IsActive=x.IsActive==false? false:x.IsActive,
                   
               })
               .ToList();
        }

        public void Update(TemporalProductos ventatmp, bool saveChanges = true)
        {
            _context.Entry(ventatmp).State = EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();

            }

        }


        public TemporalProductos GetTemporal(int id)
        {
            return _context.TemporalProductos
              .Where(a => a.Id == id).FirstOrDefault();
        }

    }
}
