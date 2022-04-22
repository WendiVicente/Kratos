using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Bancos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos.Repository
{
   public class CuentasRepository
    {
        private Context _context = null;

        public CuentasRepository(Context context)
        {
            _context = context;
        }

        public void Add(CuentaBanco cuenta, bool saveChanges = true)
        {
            _context.CuentaBancos.Add(cuenta);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void Update(CuentaBanco cuenta, bool saveChanges = true)
        {
            _context.Entry(cuenta).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public CuentaBanco Get(Guid id)
        {
            return _context.CuentaBancos.Where(x => x.Id == id).FirstOrDefault();

        }
        public CuentaBanco GetNoCuenta(string nocuenta)
        {
            return _context.CuentaBancos.Where(x => x.NumeroCuenta == nocuenta).FirstOrDefault();

        }

        public IList<ListarCuentas> GetListarCuentas()
        {
            return _context.CuentaBancos
                //.Include(r => r.Sucursal)
               //s.Where(a => a.IsActive == false)
                .Select(x => new ListarCuentas
                {
                    Id = x.Id,
                    TipoCuenta = x.TipoCuenta,
                    Diaria = x.Diaria,
                    Semanal = x.Semanal,
                    Mensual = x.Semanal,
                    Anual = x.Anual,
                    BancaId = x.Banca.Entidad,
                    Empresa = x.Empresa,
                    Moneda = x.Moneda.ToString(),
                    MontoInicial = x.MontoInicial,
                    NombreCuenta = x.NombreCuenta,
                    NumeroCuenta = x.NumeroCuenta,
                    Estado = x.IsActive == true ? "Inactivo":"Activo"




                }
                ).ToList();

        }


    }
}
