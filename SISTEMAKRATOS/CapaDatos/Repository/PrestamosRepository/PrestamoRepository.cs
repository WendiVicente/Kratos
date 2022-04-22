using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.Prestamos;
using CapaDatos.Models.Prestamos;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.PrestamosRepository
{
   public  class PrestamoRepository
    {
        private Context _context = null;
        public PrestamoRepository(Context context)
        {
            _context = context;
        }


        public bool Add(Prestamos prestamo)
        {
            _context.Prestamos.Add(prestamo);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Prestamos prestamos)
        {
           
            try
            {
                _context.Entry(prestamos).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Prestamos GetPrestamo(Guid prestamo)
        {
           return _context
                
                .Prestamos
                .Include(x => x.TipoCredito)
                .Include(x => x.MetodoAmortizacion)
                .Include(x => x.RegistroPagoCuotas)
                .Include(x=> x.Cliente)
                .FirstOrDefault(x => x.Id == prestamo);
        }
        public Prestamos Getprestamobycodigo( string prestamo)
        {
           return _context.Prestamos.FirstOrDefault(x => x.NoDocumento == prestamo);
        }


        public IList<ListarPrestamos> GetListarPrestamos()
        {
            return _context.Prestamos
                .Include(x=> x.TipoCredito)
                .Include(x=> x.MetodoAmortizacion)
                .Include(x=> x.RegistroPagoCuotas)
                .Include(x=>x.Cliente)
                .Select(x => new ListarPrestamos
                {
                    Id = x.Id,
                    Amortizacion=x.MetodoAmortizacion.Metodo,
                    AmortizacionId=x.AmortizacionId,
                    DeudaActual=x.DeudaActual,
                    NoDocumento= x.NoDocumento,
                    ClienteId=x.ClienteId,
                    Nombrescliente= x.Cliente.Nombres+" "+x.Cliente.Apellidos,
                    Empleado= x.User.Name,
                    Estado=x.Estado,
                    FechaSolicitud=x.FechaSolicitud,
                    ImporteFinanciado=x.ImporteFinanciado,
                    TasaInteres=x.TasaInteres,
                    TipoCreditoId=x.TipoCreditoId,
                    Tipocredito=x.TipoCredito.Tipo,
                    Monto=x.Monto,
                    MontoCuotas=x.MontoCuotas,
                    NoCuotas=x.NoCuotas,
                    Observaciones=x.Observaciones,
                    
                }).ToList();
        }
        public IList<ListarPrestamos> GetlistaReporte(int idcliente,int idtipocredito,int idamoritz,bool allfechas,DateTime fechainicio,DateTime fechafin,
            bool descendente,bool ascendente,bool endeuda,bool enfiniquito, bool todas)
        {
            var listaPrestamos = _context.Prestamos.AsQueryable();

            if (idcliente != 0)
            {
                listaPrestamos = listaPrestamos.Where(x => x.ClienteId == idcliente);
            }
            if (idtipocredito != 0)
            {
                listaPrestamos = listaPrestamos.Where(x => x.TipoCreditoId == idtipocredito);
            }
            if (idamoritz != 0)
            {
                listaPrestamos = listaPrestamos.Where(x => x.AmortizacionId == idamoritz);
            }
            if (allfechas == false)
            {
                listaPrestamos = listaPrestamos.Where(a => a.FechaSolicitud > fechainicio && a.FechaSolicitud <= fechafin);
            }
            if (descendente == true)
            {
                listaPrestamos = listaPrestamos.OrderByDescending(a => a.ImporteFinanciado).ThenBy(a => a.FechaSolicitud);
            }
            if (ascendente == true)
            {
                listaPrestamos = listaPrestamos.OrderBy(a => a.ImporteFinanciado).ThenBy(a => a.FechaSolicitud);
            }

            if (todas == false)
            {
                if (endeuda == true)
                {
                    listaPrestamos = listaPrestamos.Where(a => a.Estado == "En Deuda");
                }
                if (enfiniquito == true)
                {
                    listaPrestamos = listaPrestamos.Where(a => a.Estado == "Finiquitado");
                }

            }
            return listaPrestamos
                .Include(x => x.TipoCredito)
                .Include(x => x.MetodoAmortizacion)
                .Include(x => x.RegistroPagoCuotas)
                .Include(x => x.Cliente)
                .Select(x => new ListarPrestamos
                {
                    Id = x.Id,
                    Amortizacion = x.MetodoAmortizacion.Metodo,
                    AmortizacionId = x.AmortizacionId,
                    DeudaActual = x.DeudaActual,
                    NoDocumento = x.NoDocumento,
                    ClienteId = x.ClienteId,
                    Nombrescliente = x.Cliente.Nombres + " " + x.Cliente.Apellidos,
                    Empleado = x.User.Name,
                    Estado = x.Estado,
                    FechaSolicitud = x.FechaSolicitud,
                    ImporteFinanciado = x.ImporteFinanciado,
                    TasaInteres = x.TasaInteres,
                    TipoCreditoId = x.TipoCreditoId,
                    Tipocredito = x.TipoCredito.Tipo,
                    Monto = x.Monto,
                    MontoCuotas = x.MontoCuotas,
                    NoCuotas = x.NoCuotas,
                    Observaciones = x.Observaciones,

                }).ToList();
        }
    }
}
