using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.Devoluciones;
using CapaDatos.Models.Devoluciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.DevolucionesRepository
{
    public class NotaDebitoRepository
    {
        private Context _context = null;
        public NotaDebitoRepository(Context context)
        {
            _context = context;
        }
        public void Add(NotaDebito nota, bool saveChanges = true)
        {
            _context.NotaDebitos.Add(nota);

            if (saveChanges)
            {
                _context.SaveChanges();
            }

        }

        public void Update(NotaDebito nota, bool saveChanges = true)
        {
            _context.Entry(nota).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public IList<ListarNotasDebito> GetlistaNotasDebito()
        {
            var listanotasdebito = _context.NotaDebitos.AsQueryable();
            return listanotasdebito
              .Include(x => x.Factura)
              .OrderBy(x => x.FechaTransaccion)
              .Select(x => new ListarNotasDebito
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
        public NotaDebito GetNDbyNodocumento(string nodoc)
        {
            return _context.NotaDebitos.FirstOrDefault(x => x.NoDocumento == nodoc);
        }
        public NotaDebito Get(Guid nodoc)
        {
            return _context.NotaDebitos.FirstOrDefault(x => x.Id == nodoc);
        }

       

    }
}
