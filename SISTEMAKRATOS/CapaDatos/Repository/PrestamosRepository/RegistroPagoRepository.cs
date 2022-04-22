using CapaDatos.Data;
using CapaDatos.Models.Prestamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ListasPersonalizadas.Prestamos;

namespace CapaDatos.Repository.PrestamosRepository
{
  public   class RegistroPagoRepository
    {
        private Context _context = null;
        public RegistroPagoRepository(Context context)
        {
            _context = context;
        }


        public bool Add(RegistroPagoCuota pagocuota)
        {
            _context.RegistroPagoCuotas.Add(pagocuota);
            _context.SaveChanges();
            return true;
        }

        public bool Update(RegistroPagoCuota pagocuota)
        {

            try
            {
                _context.Entry(pagocuota).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public RegistroPagoCuota GetRegistroPago(Guid pagocuota)
        {
            return _context.RegistroPagoCuotas.FirstOrDefault(x => x.Id == pagocuota);
        }
        public RegistroPagoCuota Getpagobycodigo(string pagocuota)
        {
            return _context.RegistroPagoCuotas.FirstOrDefault(x => x.Nopago == pagocuota);
        }

        public List<RegistroPagoCuota> getlistaRegistrobydocumento(string nodocumento)
        {
            return
                _context.RegistroPagoCuotas
                .Include(x => x.CuotasCredito)
                .Include(x => x.Prestamos)
                .Where(x => x.Nopago == nodocumento).ToList();
        }

        public IList<ListarRegistroPagos> GetlistaPagosToReport(Guid prestamoid)
        {
            return
               _context.RegistroPagoCuotas
               .Include(x => x.CuotasCredito)
               .Include(x => x.Prestamos)
               .Where(x => x.PrestamosId == prestamoid)
               .Select(x => new ListarRegistroPagos()
               {
                   Id = x.Id,
                   FechaPago = x.FechaPago,
                   Importe = x.Importe,
                   Mora = x.Mora,
                   NoCuotaPagada = x.CuotasCredito.NoCuota,
                   Nopago = x.Nopago,
                   PrestamosId = x.PrestamosId== null ? Guid.Empty : (Guid)x.PrestamosId,



               }).OrderBy(x => x.NoCuotaPagada).ToList();
        }

    }
}
