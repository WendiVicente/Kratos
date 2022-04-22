using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.Devoluciones;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Devoluciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.DevolucionesRepository
{
    public class NotaCreditoRepository
    {
        private Context _context = null;
        public NotaCreditoRepository(Context context)
        {
            _context = context;
        }
        public void AddNotaCredito(NotaCredito nota, bool saveChanges = true)
        {
            _context.NotaCreditos.Add(nota);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void AddDetalleNotaCredito(DetalleNotaCredito detalle, bool saveChanges = true)
        {
            _context.DetalleNotaCreditos.Add(detalle);
            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void UpdateNotaCredito(NotaCredito nota, bool saveChanges = true)
        {
            _context.Entry(nota).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void UpdateDetalle(DetalleNotaCredito detalle, bool saveChanges = true)
        {
            _context.Entry(detalle).State = System.Data.Entity.EntityState.Modified;
            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<ListarNotasCredito> GetlistaNotasCreditos()
        {
            var listanotasCredito = _context.NotaCreditos.AsQueryable();
            return listanotasCredito
              .Include(x => x.Factura)
              .OrderBy(x => x.FechaTransaccion)
              .Select(x => new ListarNotasCredito
              {
                  Id = x.Id,
                  NoDocumento = x.NoDocumento,
                  Disponible = x.MontoDisponible,
                  Descripcion = x.Descripcion,
                  Monto = x.Monto,
                  FechaTransaccion = x.FechaTransaccion,
                  FechaAceptacion = x.FechaAceptacion,
                  NombreVendedor = x.NombreVendedor,
                  FacturaId = x.FacturaId,
                  NoFactura = x.Factura.NoFactura,
                  Estado = x.Estado == false ? "En Espera" : "Aceptada",

              }
              ).ToList();
        }
        public NotaCredito GetNCbyNodocumento(string nodoc)
        {
            return _context.NotaCreditos.FirstOrDefault(x => x.NoDocumento == nodoc);
        }
        public NotaCredito Get(Guid nodoc)
        {
            return _context.NotaCreditos.FirstOrDefault(x => x.Id == nodoc);
        }

        public List<DetalleNotaCredito> GetDetalleByNotaCredito(Guid idnotacredito)
        {
            return _context.DetalleNotaCreditos.Where(x => x.NotaCreditoId == idnotacredito).ToList();
        }



    }
}
