using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using sharedDatabase.Models.Caja;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CapaDatos.Repository
{
    public class DetallePagoRepository
    {
        private Context _context = null;

        public DetallePagoRepository(Context context)
        {
            _context = context;
        }

        //guardar caja
        public void Add(DetallePago detalle, bool saveChanges = true)
        {
            _context.DetallePago.Add(detalle);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public List<ListasPersonalizadas.ListaDetallePago> GetDetallePagos(int CajaId, string Tipo)
        {
            var listapago = _context.DetallePago.ToList();
            List<ListaDetallePago> listapagos = new List<ListaDetallePago>();
            if (listapago.Count() > 0)
            {
                listapagos = listapago
                     .Select(x => new ListaDetallePago() { 
                        Id = x.Id,
                        FacturaId = x.FacturaId,
                        CajaId = x.CajaId,
                        Documento = x.Documento,
                        TipoPago = x.Pago,
                        Entidad = x.Entidad,
                        Numero = x.Numero,
                        Monto = x.Monto,
                        Fecha = x.Fecha
                    })
                    .Where(x => x.CajaId == CajaId && x.TipoPago == Tipo).ToList();
            }
            else
            {
                listapagos = new List<ListaDetallePago>();
            }
            return listapagos;
        }


        public DetallePago Get(int id)
        {
            var detallePagos = _context.DetallePago.AsQueryable();

            return detallePagos.Where(a => a.Id == id).SingleOrDefault();
        }


        public void Update(DetallePago detalle, bool saveChanges = true)
        {
            _context.Entry(detalle).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void Delete(DetallePago detalle, bool saveChanges = true)
        {
            _context.Entry(detalle).State = System.Data.Entity.EntityState.Deleted;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
    }
}
