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
   public class TallasyColoresRepository
   {
        private Context _context = null;

        public TallasyColoresRepository(Context context)
        {
            _context = context;
        }

        public void Add(DetalleColorTalla detalle, bool saveChanges = true)
        {
            _context.DetalleColorTallas.Add(detalle);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }


        public void Update(DetalleColorTalla Detalle, bool saveChanges = true)
        {
            _context.Entry(Detalle).State = EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public List<DetalleColorTalla> GetAllColoresTallas()
        {
            return _context.DetalleColorTallas.ToList();
        }

        public DetalleColorTalla GetColorTalla(int id)
        {
            return _context.DetalleColorTallas
                .Include(r => r.Producto)
                .Where(r => r.Id == id)
                .FirstOrDefault();
        }

        public List<DetalleColorTalla> GetTallaColorListaProducto(int codigoproducto)
        {
            return _context.DetalleColorTallas
                .Include(r => r.Producto)
                .Where(r => r.ProductoId == codigoproducto)
                .OrderBy(h => h.Talla).ThenBy(h=> h.Color)
                .ToList();
        }

        public void DeleteDetalleTallaColor(DetalleColorTalla detalleTallas)
        {
            _context.Entry(detalleTallas).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IList<ListarDetalleColorTallas> GetListaDetalleColorTallas(int codigoproducto)
        {
            var listacolortallas = _context.DetalleColorTallas.AsQueryable();
            return listacolortallas
                  .Where(a => a.ProductoId == codigoproducto)
                  .Select(x => new ListarDetalleColorTallas
                  {
                      Id = x.Id,
                      ProductoId=x.ProductoId,
                      Stock=x.Stock,
                      Color = x.Color,
                      Talla = x.Talla,
                  })
                  .ToList();
        }

        public List<ListarDetalle> GetListaDetalle(int codigoproducto)
        {
            return _context.DetalleColorTallas
                .Include(r => r.Producto)
                .Where(r => r.ProductoId == codigoproducto)
                .OrderBy(h => h.Color).ThenBy(h => h.Talla)
                .Select(x => new ListarDetalle
                {
                    ProductoId = x.ProductoId,
                    DetalleId = x.Id,
                    Detalle = x.Color + " - " + x.Talla,
                    Cantidad = x.Stock
                }).ToList();
        }
   }
}
