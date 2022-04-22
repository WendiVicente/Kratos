using CapaDatos.Data;
using CapaDatos.Models.Pedidos;
using CapaDatos.Models.Productos;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaDatos.Repository
{
    public class DetalleProductoRepository 
    {
        private Context _context = null;

        public DetalleProductoRepository(Context context)
        {
            _context = context;
        }

        public void Add(DetalleProducto detalle, bool saveChanges = true)
        {
            _context.DetalleProductos.Add(detalle);

            if (saveChanges)
            {
                _context.SaveChanges();

            }
        }

        public void Update(DetalleProducto detalle, bool saveChanges = true)
        {
            _context.Entry(detalle).State = EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();

            }
        }


        public IList<DetalleProducto> GetAllDetalleProducto()
        {
            return _context.DetalleProductos.ToList();
        }

        public DetalleProducto GetDetalleProducto(int id)
        {
            return _context.DetalleProductos
                 .Include(r => r.Id == id)
                .FirstOrDefault();
        }


        public void DeleteDetalleProducto(DetalleProducto detalle)
        {
            _context.Entry(detalle).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IList<DetalleProducto> GetList()
        {
            return _context.DetalleProductos
                .OrderBy(a => a.noDocumento)
                .ToList();
        }

        public List<DetalleProducto> GetListNoDocumento(string noDocumento)
        {
            var detalles = _context.DetalleProductos.ToList();
            if (detalles.Count() > 0)
            {
                detalles = detalles.Where(x => x.noDocumento == noDocumento).ToList();
                return detalles;
            }
            else
            {
                return new List<DetalleProducto>();
            }
        }

        public List<DetalleProducto> GetDetallesTmp(DateTime inicio, DateTime final)
        {
            DateTime FechaInicio = inicio.Date + new TimeSpan(0, 0, 0);
            DateTime FechaFin = final.Date + new TimeSpan(23, 59, 59);
            var detalles = _context.DetalleProductos.ToList();
            if (detalles.Count() > 0)
            {
                detalles = detalles.Where(x => x.noDocumento.Contains("TMP")).ToList();

                if (detalles.Count() > 0)
                {
                    detalles = detalles.Where(x => x.FechaDocumento >= FechaInicio && x.FechaDocumento <= FechaFin).ToList();
                }
                return detalles;
            }
            else
            {
                return new List<DetalleProducto>();
            }
        }

        public List<DetalleProducto> GetDetallesTmp()
        {
            var detalles = _context.DetalleProductos.ToList();
            if (detalles.Count() > 0)
            {
                detalles = detalles.Where(x => x.noDocumento.Contains("TMP")).ToList();
                return detalles;
            }
            else
            {
                return new List<DetalleProducto>();
            }
        }

    }
}
