using CapaDatos.Data;
using CapaDatos.Models.Productos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.PreciosRepository
{
    public class PreciosDetallePepsRepository
    {
        private Context _context = null;

        public PreciosDetallePepsRepository(Context context)
        {
            _context = context;
        }

        public void Add(PreciosDetallePeps preciosprps, bool saveChanges = true)
        {
            _context.PreciosDetallePeps.Add(preciosprps);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void Update(PreciosDetallePeps precio, bool saveChanges = true)
        {
            _context.Entry(precio).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public PreciosDetallePeps Get(int idproducto, bool includeRelatedEntities = true)
        {
            var precio = _context.PreciosDetallePeps.AsQueryable();

            if (includeRelatedEntities)
            {
              //  precio = precio.Include(a => a.DetallePrecios);

            }

            return precio.Where(a => a.ProductoId == idproducto).SingleOrDefault();
        }
        public PreciosDetallePeps GetPreciosPeps(int idproducto)
        {
            var precio = _context.PreciosDetallePeps.AsQueryable();
            return precio.Where(a => a.ProductoId == idproducto)
                .Where(x => x.Cantidad > 0)
                .OrderByDescending(y => y.FechaIngreso).First();
                         

        }

        public List<PreciosDetallePeps> GetListaPreciosPeps(int idproducto)
        {
            var precio = _context.PreciosDetallePeps.AsQueryable();
            return precio.Where(a => a.ProductoId == idproducto)
                .Where(x => x.Cantidad > 0)
                .OrderByDescending(y => y.FechaIngreso).ToList();


        }

    }
}
