using CapaDatos.Data;
using CapaDatos.Models.Transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CapaDatos.ListasPersonalizadas;

namespace CapaDatos.Repository
{
   public  class TransaccionRepository
    {
        private Context _context = null;


        public TransaccionRepository(Context context)
        {
            _context = context;
        }
        public void Add(Transaccion transaccion, bool saveChanges = true)
        {
            _context.Transacciones.Add(transaccion);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void Update(Transaccion transaccion, bool saveChanges = true)
        {
            _context.Entry(transaccion).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<ListarTransacciones> GetListaTransacciones(int estadocancel=0, int estadodenegar=0)
        {
            var listaTransferencias = _context.Transacciones.AsQueryable();

            if (estadocancel != 0)
            {
                listaTransferencias = listaTransferencias.Where(x => x.EstadosTransacId == estadocancel);

            }

            if (estadodenegar != 0)
            {
                listaTransferencias = listaTransferencias.Where(x => x.EstadosTransacId == estadodenegar);

            }
            return listaTransferencias
                .Include(r => r.Sucursal)
                //.Include(r => r.CuentaBanco)
               // .Where(a => a.IsActive == false)
                .OrderByDescending(a => a.FechaSolicitud)
                .Select(x => new ListarTransacciones
                {
                    Id = x.Id,
                    CuentaOrigen= x.CuentaOrigenId.ToString(),
                    CuentaDestino= x.CuentaBanco.NumeroCuenta,
                    Estado= x.EstadosTransac.Estado,
                    FechaSolicitud= x.FechaSolicitud,
                    Monto= x.Monto,
                    Observaciones=x.Observaciones,
                    Sucursal=x.Sucursal.NombreSucursal,
                    Solicitante= x.Usuario.Name,
                    Responsable=x.Responsable,
                    CajaId= x.CajaId,
                    TipoMovimiento= x.TipoMovimiento.Movimiento,


                }
                ).ToList();

        }


        public IList<ListarTransacciones> GetlistaTransacReporte(int idsucursal, int tipomovi, bool todasfechas,
            DateTime fechainicio, DateTime fechafin,int estadoT)
        {
            var listaTransferencias = _context.Transacciones.AsQueryable();

            if (idsucursal != 0)
            {
                listaTransferencias = listaTransferencias.Where(x => x.SucursalId == idsucursal);

            }

            if (tipomovi != 0)
            {
                listaTransferencias = listaTransferencias.Where(x => x.TipoMovimientoId == tipomovi);

            }
            if (estadoT != 0)
            {
                listaTransferencias = listaTransferencias.Where(x => x.EstadosTransacId == estadoT);

            }
            if (todasfechas == false)
            {
                listaTransferencias = listaTransferencias.Where(a => a.FechaSolicitud > fechainicio && a.FechaSolicitud <= fechafin);
            }
            return listaTransferencias
                .Include(r => r.Sucursal)
                .OrderByDescending(a => a.FechaSolicitud)
                .Select(x => new ListarTransacciones
                {
                    Id = x.Id,
                    CuentaOrigen = x.CuentaOrigenId.ToString(),
                    CuentaDestino = x.CuentaBanco.NumeroCuenta,
                    Estado = x.EstadosTransac.Estado,
                    FechaSolicitud = x.FechaSolicitud,
                    Monto = x.Monto,
                    Observaciones = x.Observaciones,
                    Sucursal = x.Sucursal.NombreSucursal,
                    Solicitante = x.Usuario.Name,
                    Responsable = x.Responsable,
                    CajaId = x.CajaId,
                    TipoMovimiento = x.TipoMovimiento.Movimiento,


                }
                ).ToList();

        }


        public Transaccion Get(Guid id)
        {
            return _context.Transacciones.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<TipoMovimiento> GetlistMovimientos()
        {
            return _context.TipoMovimientos.Where(x=> x.IsActive==false).ToList();
        }

        public List<EstadosTransac> GetlistEstadosT()
        {
            return _context.EstadosTransacs.Where(x => x.IsActive == false).ToList();
        }

        public EstadosTransac GetEstadosTransac(string estado)
        {
            return _context.EstadosTransacs.Where(x => x.Estado == estado).FirstOrDefault();

        }

    }
}
