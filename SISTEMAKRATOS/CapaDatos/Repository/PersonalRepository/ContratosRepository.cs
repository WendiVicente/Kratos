using CapaDatos.Data;
using CapaDatos.Models.Personal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.PersonalRepository
{
   public class ContratosRepository
    {

        private Context _context = null;

        public ContratosRepository(Context context)
        {
            _context = context;
        }

       public void Add(TipoContrato contrato, bool saveChanges = true)
        {
            _context.TipoContratos.Add(contrato);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<TipoContrato> GetContratos()
        {
            return _context.TipoContratos
                //.Where(a => a.IsActive == false)
                .OrderBy(a => a.Descripcion)
                .ToList();
        }


        public void Update(TipoContrato contrato, bool saveChanges = true)
        {
            _context.Entry(contrato).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
    }
}
