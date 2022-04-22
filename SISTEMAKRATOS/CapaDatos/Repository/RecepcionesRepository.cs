using CapaDatos.Data;
using CapaDatos.Models.Recepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CapaDatos.ListasPersonalizadas;

namespace CapaDatos.Repository
{
   public  class RecepcionesRepository
    {
        private Context _context = null;
        public RecepcionesRepository(Context context)
        {
            _context = context;
        }

        public void AddDetallesRecep(DetalleRecepcion detalleRecepcion, bool saveChanges = true)
        {
            _context.DetalleRecepciones.Add(detalleRecepcion);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void AddRecepcion(Recepcion recepcion, bool saveChanges = true)
        {
            _context.recepcions.Add(recepcion);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void Update(Recepcion recepcion, bool saveChanges = true)
        {
            _context.Entry(recepcion).State = EntityState.Modified;
           if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public EstadoRecepcion ObtenerEstadoId(string estadobuscar, bool relaciones = true)
        {
            var estado = _context.EstadoRecepciones.AsQueryable();
            if (relaciones)
            {
                estado = estado.Include(s => s.recepciones);
            }
            return estado.Where(s => s.Estado == estadobuscar).SingleOrDefault();

        }

        public Recepcion Get(Guid idcompra, bool relaciones = true)
        {
            var recepcion = _context.recepcions.AsQueryable();
            if (relaciones)
            {
                recepcion = recepcion.Include(s => s.detalleRecepciones);
            }
            return recepcion.Where(s => s.CompraId == idcompra).SingleOrDefault();

        }

        // traer todas las recepciones 
        public IList<ListarRecepciones> GetListRecepciones(int sucursalId, int estadoRecepcion)
        {

            var recepciones = _context.recepcions.AsQueryable();
            if (sucursalId != 0)
            {
                recepciones = recepciones.Where(a => a.SucursalId == sucursalId);
                
            }
            if (estadoRecepcion != 0)
            {
                recepciones = recepciones.Where(a => a.EstadoRecepcionId == estadoRecepcion);

            }

            return recepciones
               .Include(a => a.Compra.DetalleCompras ).OrderByDescending(a => a.Compra.FechaRecepcion)
              
              // .Where(a => a.EstadoRecepcionId == estadoRecepcion)
               .Select(x => new ListarRecepciones
               {

                   Solicitud = x.Compra.NoComprobante,
                   Id = x.Id,
                   Sucursal = x.Compra.Sucursal.NombreSucursal,
                   SolicitudCompra = x.CompraId,
                   EstadoRecepcion=x.EstadoRecepcion.Estado,
                   proveedor =x.Compra.Proveedor.Nombre,
                   FechaPrevista =x.Compra.FechaLimite,
                 

               }

               )
               .ToList();
        }

        public IList<EstadoRecepcion> SearchByState()
        {
            return _context.EstadoRecepciones.ToList();
        }


    }
}
