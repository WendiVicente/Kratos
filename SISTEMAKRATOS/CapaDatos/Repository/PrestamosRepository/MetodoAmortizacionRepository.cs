using CapaDatos.Data;
using CapaDatos.Models.Prestamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.PrestamosRepository
{
   public  class MetodoAmortizacionRepository
    {
        private Context _context = null;
        public MetodoAmortizacionRepository(Context context)
        {
            _context = context;
        }

        public MetodoAmortizacion GetMetodo(int id)
        {
            return _context.MetodoAmortizaciones.FirstOrDefault(x => x.Id == id);
        }

        public List<MetodoAmortizacion> GetListaMetodos()
        {
            return _context.MetodoAmortizaciones.ToList();
        }
    }
}
