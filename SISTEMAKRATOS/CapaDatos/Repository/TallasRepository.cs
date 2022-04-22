using CapaDatos.Data;
using CapaDatos.Models.Productos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class TallasRepository
    {
        private Context _context = null;

        public TallasRepository(Context context)
        {
            _context = context;
        }

        public void Add(DetalleTalla detalle, bool saveChanges = true)
        {
            _context.DetalleTallas.Add(detalle);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void Update(DetalleTalla Detalle, bool saveChanges = true)
        {
            _context.Entry(Detalle).State = EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public List<DetalleTalla> GetAllTallas()
        {
            return _context.DetalleTallas.ToList();
        }

        public List<DetalleTalla> GetTallaListaProducto(int codigoproducto)
        {
            return _context.DetalleTallas
                .Include(r => r.Producto)
                .Where(r => r.ProductoId == codigoproducto)
                .OrderBy(h => h.Talla)
                .ToList();
        }

        public DetalleTalla GetDetalleTalla(int id)
        {
            return _context.DetalleTallas
                .Include(r => r.Producto)
                .Where(r => r.Id == id)
                .OrderBy(h => h.Talla)
                .FirstOrDefault();
        }

        public void DeleteDetalleTalla(DetalleTalla detalleTallas)
        {
            _context.Entry(detalleTallas).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<ListasPersonalizadas.ListarDetalle> GetListaDetalle(int codigoproducto)
        {
            return _context.DetalleTallas
                .Include(r => r.Producto)
                .Where(r => r.ProductoId == codigoproducto)
                .OrderBy(h => h.Talla)
                .Select(x => new ListasPersonalizadas.ListarDetalle
                {
                    ProductoId = x.ProductoId,
                    DetalleId = x.Id,
                    Detalle = x.Talla,
                    Cantidad = x.Stock
                }).ToList();
        }

    }
}
