using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Productos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class ColoresRepository
    {
        private Context _context = null;

        public ColoresRepository(Context context)
        {
            _context = context;
        }

        public void Add(DetalleColor detalleColor, bool saveChanges = true)
        {
            _context.detalleColors.Add(detalleColor);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void Update(DetalleColor detalleColor, bool saveChanges = true)
        {
            _context.Entry(detalleColor).State = EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public List<DetalleColor> GetAllColors()
        {
            return _context.detalleColors.ToList();
        }

        public DetalleColor GetColor(int codigoproducto)
        {
            return _context.detalleColors
                .Include(r => r.Producto)
                .Where(r => r.ProductoId == codigoproducto)
                .OrderBy(h => h.Color)
                .FirstOrDefault();
        }

        public DetalleColor GetDetalleColor(int id)
        {
            return _context.detalleColors
                .Include(r => r.Producto)
                .Where(r => r.Id == id)
                .OrderBy(h => h.Color)
                .FirstOrDefault();
        }

        public void DeleteDetalleColor(DetalleColor detalleColor)
        {
            _context.Entry(detalleColor).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<DetalleColor> GetProductoListaColor(int codigoproducto)
        {
            return _context.detalleColors
                 .Include(r => r.Producto)
                 .Where(r => r.ProductoId == codigoproducto)
                 .OrderBy(h => h.Color)
                 .ToList();
        }

        public List<ListarDetalle> GetListaDetalle(int codigoproducto)
        {
            return _context.detalleColors
                .Include(r => r.Producto)
                .Where(r => r.ProductoId == codigoproducto)
                .OrderBy(h => h.Color)
                .Select(x => new ListarDetalle
                {
                    ProductoId = x.ProductoId,
                    DetalleId = x.Id,
                    Detalle = x.Color,
                    Cantidad = x.Stock
                }).ToList();
        }
    }
}
