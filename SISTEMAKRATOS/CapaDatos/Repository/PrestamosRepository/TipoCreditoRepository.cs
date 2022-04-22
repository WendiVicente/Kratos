using CapaDatos.Data;
using CapaDatos.Models.Prestamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.PrestamosRepository
{
    public class TipoCreditoRepository
    {
        private Context _context = null;
        public TipoCreditoRepository(Context context)
        {
            _context = context;
        }

       public TipoCredito GetTipoCredito(string tipo)
        {
            return _context.TipoCreditos.FirstOrDefault(x => x.Tipo == tipo);
        }

        public List<TipoCredito> GetListaTipoCreditos()
        {
            return _context.TipoCreditos.ToList();
        }


      


    }
}
