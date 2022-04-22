using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.Prestamos;
using CapaDatos.Models.Prestamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.PrestamosRepository
{
    public class CuotasCreditoRepository
    {
        private Context _context = null;
        public CuotasCreditoRepository(Context context)
        {
            _context = context;
        }


        public void Add(CuotasCredito credito)
        {
            _context.CuotasCreditos.Add(credito);
            _context.SaveChanges();
        }
        public IList<ListarCuotas> GetListaCuotas(Guid prestamoid)
        {
            return _context.CuotasCreditos
                 .Select(x => new ListarCuotas
                 {
                     Id=x.Id,
                     Estado=x.Estado,
                     NoCuota=x.NoCuota,
                     Fecha=x.Fecha,
                     MontoSolicitado=x.MontoSolicitado,
                     Amortizacion=x.Amortizacion,
                     Interes=x.Interes,
                     MontoCuotas=x.MontoCuotas,
                     ITF=x.ITF,
                     Vence=x.Vence,
                     Mora=x.Mora,
                     InteresesProyectados=x.InteresesProyectados,
                     PrestamosID=x.PrestamosID,



                 }).Where(x=> x.PrestamosID==prestamoid).OrderBy(x=>x.NoCuota).ToList();

        }
        
       public bool Update(CuotasCredito cuota)
        {
            _context.Entry(cuota).State = System.Data.Entity.EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

    }
}
