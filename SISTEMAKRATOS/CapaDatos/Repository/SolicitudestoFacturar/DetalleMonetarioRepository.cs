using CapaDatos.Data;
using sharedDatabase.Models.Caja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.SolicitudestoFacturar
{
   public  class DetalleMonetarioRepository
    {
        private Context _context = null;

        public DetalleMonetarioRepository(Context context)
        {
            _context = context;
        }

        //guardar caja
        public void Add(DetalleMonetario caja, bool saveChanges = true)
        {
            _context.DetalleMonetarios.Add(caja);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void Update(DetalleMonetario caja, bool saveChanges = true)
        {
            _context.Entry(caja).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }



    }
}
