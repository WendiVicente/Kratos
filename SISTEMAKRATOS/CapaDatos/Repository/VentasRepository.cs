using CapaDatos.Data;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos.Repository
{
    public class VentasRepository
    {
        private Context _context = null;

        public VentasRepository(Context context)
        {
            _context = context;
        }

        public IList<Factura> GetFacturasList()
        {
            return _context.Facturas
                .Include(c => c.Cliente)
                .OrderByDescending(r => r.FechaVenta)
                .ToList();
        }

        public void Add(Factura model, bool saveChanges = true)
        {
            _context.Facturas.Add(model);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public Factura GetbyNoCorrelativo(string nocrrelativo)
        {
            return _context.Facturas.FirstOrDefault(x => x.NoFactura == nocrrelativo);
        }

    }
}
