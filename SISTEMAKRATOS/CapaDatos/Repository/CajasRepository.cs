using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using sharedDatabase.Models.Caja;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class CajasRepository
    {

        private Context _context = null;

        public CajasRepository(Context context)
        {
            _context = context;
        }

        //guardar caja
        public void Add(Caja caja, bool saveChanges = true)
        {
            _context.Cajas.Add(caja);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        // guardar detalle de caja
        public void AddDetalleCaja(DetalleCaja model, bool guardarpordefecto = true)
        {
            _context.DetalleCajas.Add(model);

            if (guardarpordefecto)
            {
                _context.SaveChanges();
            }
        }

        //

        // listar cajas
        public IList<Caja> GetListcajacerradas()
        {
            return _context.Cajas
                .Where(a => a.EstadoCaja == false)
                .OrderByDescending(a => a.FechaApertura)
                .ToList();
        }
        // listar detalle de cajas

    
        public IList<ListarCajaDetalles> GetDetalleCaja(int cajaid)
        {
            return _context.DetalleCajas
                .Include(x => x.Caja)
                 .Include(y => y.Compra)
                .Include(z => z.Factura)
                .Where(r => r.CajaId == cajaid)
                .Select(x => new ListarCajaDetalles
                {
                    Id = x.Id,
                    CompraId = x.CompraId,
                    FacturaId = x.FacturaId,
                    Descripcion = x.Descripcion,
                    TarjetaDebito = x.TarjetaDebito,
                    CajaId = x.CajaId,
                    Efectivo = x.Efectivo,
                    TarjetaCredito = x.TarjetaCredito,
                    Cheques = x.Cheques,
                    Egreso = x.Egreso,
                    Transferencias = x.Transferencia
                    // TotalEgresos= x.Compra.DetalleCompras.Sum(y => y.PrecioTotal),
                    // TotalIngresos =x.Factura.DetalleFacturas.Sum(z => z.PrecioTotal+ x.Efectivo)

                }).ToList();
                
        }

        // buscar detalle caja
        public DetalleCaja GetDetalleCajaEditar(int idCaja,Guid guidcompra ,bool includeRelatedEntities = true)
        {
            var cajaDetalle = _context.DetalleCajas.AsQueryable();

            if (includeRelatedEntities)
            {
                cajaDetalle = cajaDetalle.Include(a => a.Caja);

            }

            return cajaDetalle.Where(a => a.CajaId == idCaja && a.CompraId ==guidcompra && a.Caja.EstadoCaja == true).SingleOrDefault();
        }

        //buscar caja
        public Caja Get(int id, bool includeRelatedEntities = true)
        {
            var caja = _context.Cajas.AsQueryable();

            if (includeRelatedEntities)
            {
                caja = caja.Include(a => a.DetalleCajas);

            }

            return caja.Where(a => a.Id == id).SingleOrDefault();
        }

        public Caja GetCajaAperturada(int idsucursal ,bool includeRelatedEntities = true)
        {
            var caja = _context.Cajas.AsQueryable();

            if (includeRelatedEntities)
            {
               
                caja = caja.Include(a => a.DetalleCajas);
            }

            return caja.Where(a => a.EstadoCaja == true && a.SucursalId == idsucursal).SingleOrDefault();
        }

        // obtener lista personaliza de caja
        public IList<ListarCaja> GetCajas(int sucursalId, int estado)
        {
            var cajas = _context.Cajas.AsQueryable();
            if (sucursalId != 0)
            {
                cajas = cajas.Where(a => a.SucursalId == sucursalId);
            }
            if (estado != 0)
            {
                if(estado == 1) cajas = cajas.Where(a => a.EstadoCaja == false );
                if (estado == 2) cajas = cajas.Where(a => a.EstadoCaja == true);
            }

            return cajas
                .Include(x => x.Sucursal)
                .Select(x => new ListarCaja
                {
                    Id_Transaccion = x.Id,
                    EstadoCaja = x.EstadoCaja == true ? "Abierta" : "Cerrada",
                    FechaApertura = x.FechaApertura,
                    FechaCierre = x.FechaCierre,
                    MontoApertura = x.MontoApertura,
                    Sucursal = x.Sucursal.NombreSucursal
                    // Total =x.DetalleCajas.Sum(a => a.)
                }
                //   == true ? "Comprado" : "Petición",

                ).ToList();


        }






        public void Update(Caja caja, bool saveChanges = true)
        {
            _context.Entry(caja).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        //update detalle de caja para compras
        public void UpdateDetalleCaja(DetalleCaja detallecaja, bool saveChanges = true)
        {
            _context.Entry(detallecaja).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

    }
}
