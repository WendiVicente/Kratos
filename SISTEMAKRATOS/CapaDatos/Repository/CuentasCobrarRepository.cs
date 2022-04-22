using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.Creditos;
using CapaDatos.Models.CuentaCobrar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class CuentasCobrarRepository
    {
        private Context _context = null;

        public CuentasCobrarRepository(Context context)
        {
            _context = context;
        }
        public void Add(CuentaCB cuenta, bool saveChanges = true)
        {
            _context.CuentaCBs.Add(cuenta);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
       
        public void AddNotaPago(NotaPago nota, bool saveChanges = true)
        {
            _context.NotaPagos.Add(nota);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void AddTalonarios(Talonario talonario, bool saveChanges = true)
        {
            _context.Talonarios.Add(talonario);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void Update(CuentaCB Cuenta, bool saveChanges = true)
        {
            _context.Entry(Cuenta).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
      
        public void UpdateNotaPago(NotaPago nota, bool saveChanges = true)
        {
            _context.Entry(nota).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void UpdateTalonario(Talonario talonario, bool saveChanges = true)
        {
            _context.Entry(talonario).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public CuentaCB Get(Guid id, bool includeRelatedEntities = true) // true es por defecto
        {
            var cuenta = _context.CuentaCBs.AsQueryable();

            if (includeRelatedEntities)
            {
                // pendiente, aqui incluir las relacioens cuando hagamos reportes
            }

            return cuenta.Where(a => a.Id == id).SingleOrDefault();
        }

        public IList<ListarCuentasCBs> GetCuentaCBslista()
        {
            var listadecuentas = _context.CuentaCBs.AsQueryable();
            return listadecuentas
              .Include(x => x.Cliente)
               
              .OrderBy(x => x.FechaCreacion)
              .Select(x => new ListarCuentasCBs
              {
                  Id = x.Id,
                  NoCuenta = x.NoCuenta,
                  FechaCreacion = x.FechaCreacion,
                  SaldoActual = x.SaldoActual,
                  Cliente = x.Cliente.Nombres,
                  Apellido=x.Cliente.Apellidos,
                  Sucursal=x.Sucursal.NombreSucursal,
                  Estado=x.IsActive==false? "Activa":"Inactiva",
                 
              }
              ).ToList();
        }

        public List<Movimiento> GetlistaMovimientos()
        {
            return _context.Movimientos.Where(x => x.IsActive == false).ToList();
        }
        public CuentaCB GetCcbyCliente(int clienteid)
        {
            return _context.CuentaCBs.Where(x => x.ClienteId == clienteid).FirstOrDefault();
        }
        public CuentaCB GetCcbyNocuenta(string nocuenta)
        {
            return _context.CuentaCBs.Where(x => x.NoCuenta == nocuenta).FirstOrDefault();
        }
        public NotaPago GetNotapago(string nocuenta)
        {
            return _context.NotaPagos.Where(x => x.NoDocumento == nocuenta).FirstOrDefault();
        }

        public IList<ListarNotasPago> Getlistadepagoscreditos(Guid idcuentaCB)
        {
            var listanotaspago = _context.NotaPagos.AsQueryable();
            if (idcuentaCB != null)
            {
                listanotaspago = listanotaspago.Where(x => x.CuentaCBId == idcuentaCB);
            }
            return listanotaspago
                .Include(x => x.CuentaCB)
                .OrderBy(x => x.FechaTransaccion)
                .Select(x => new ListarNotasPago
                {
                    Id = x.Id,
                    FechaTransaccion = x.FechaTransaccion,
                    NoDocumento = x.NoDocumento,
                    Descripcion = x.Descripcion,
                    Movimiento = x.Movimiento.tipoMovimiento,
                    Monto = x.Monto,
                    Responsable = x.User.Name,
                    MovimientoId = x.MovimientoId,
                    UserId = x.User.Name,
                    //FacturaId=x.Factur
                    CuentaCBId = x.CuentaCBId,
                    NoCuenta = x.CuentaCB.NoCuenta,
                }
                ).ToList();
        }

        public List<Talonario> GetTalonariosByCuentacb(Guid cuentacb)
        {
            return _context.Talonarios.Where(x => x.CuentaCBId == cuentacb).ToList();
        }
        public IList<ListarTalonarios> GetlistByCuentacb(Guid cuentid, int inicio, int final)
        {
            var lista = _context.Talonarios.AsQueryable();
            if (cuentid != null)
            {
                lista = lista.Where(x => x.CuentaCBId == cuentid);
            }
            if (inicio != 0 && final != 0)
            {
                lista = lista.Where(x => x.Correlativo >= inicio && x.Correlativo <= final);
            }
            return
               lista
               .Include(x=>x.CuentaCB)
               .Include(x=>x.CuentaCB.Cliente)
               
               .Select(x => new ListarTalonarios
               {
                   Id=x.Id,
                   Correlativo=x.Correlativo,
                   Nombre=x.Nombre,
                   Apellido=x.Apellido,
                   FechaCambio=x.FechaCambio,
                   FechaCreacion=x.FechaCreacion,
                   Estado=x.Estado==false?"Disponible":"Cobrado",
                   NoCuenta=x.CuentaCB.NoCuenta,
                   ClienteApellido=x.CuentaCB.Cliente.Apellidos,
                   ClienteNombre=x.CuentaCB.Cliente.Nombres
               }).ToList();
        }
        
    }
}
