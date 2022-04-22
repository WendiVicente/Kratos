using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using sharedDatabase.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class TomoEdicionRepository
    {
        private Context _context = null;

        public TomoEdicionRepository(Context context)
        {
            _context = context;
        }

        public void Add(DetalleTomoEdicion detalle, bool saveChanges = true)
        {
            _context.DetalleTomoEdicions.Add(detalle);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<DetalleTomoEdicion> GetListTomos(string codigo)
        {
            return _context.DetalleTomoEdicions
                .Where(x => x.Codigo == codigo && x.Tomo != null)
                .ToList();
        }

        public IList<DetalleTomoEdicion> GetListEdiciones(string codigo)
        {
            return _context.DetalleTomoEdicions
                .Where(x => x.Codigo == codigo && x.Edicion != null)
                .ToList();
        }

        public IList<DetalleTomoEdicion> GetListTomosEdiciones(string codigo)
        {
            return _context.DetalleTomoEdicions
                .Where(x => x.Codigo == codigo)
                .ToList();
        }

        public DetalleTomoEdicion GetDetalleTE(int id)
        {
            return _context.DetalleTomoEdicions
              .Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(DetalleTomoEdicion detalle, bool saveChanges = true)
        {
            _context.Entry(detalle).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void DeleteDetalleTE(DetalleTomoEdicion detalleTE)
        {
            _context.Entry(detalleTE).State = EntityState.Deleted;
            //  _context.detalleColors.Sql.r
            _context.SaveChanges();

        }

    }
}
