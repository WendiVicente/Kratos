using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Productos.Promocion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class PromocionRepository
    {
        private Context _context= null;
        public PromocionRepository(Context context)
        {
            _context = context;

        }

        public void AddPromocion(Promocion promocion, bool saveChanges = true)
        {
            _context.Promociones.Add(promocion);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void AddDetallePromocion(DetallePromocion detallepromocion, bool saveChanges = true)
        {
            _context.DetallePromociones.Add(detallepromocion);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void Update(Promocion promocion, bool savechages = true)
        {
            _context.Entry(promocion).State = EntityState.Modified;
            if (savechages)
            {
                _context.SaveChanges();
            }
        }
        public Promocion Get(Guid idpromocion)
        {
            return _context.Promociones.Where(x => x.Id == idpromocion).FirstOrDefault();
        }
        public void DeleteDetalles(Guid idpromo)
        {
            var detalle = _context.DetallePromociones.Where(b => b.PromocionId == idpromo).ToList();
            foreach (var item in detalle)
            {
                _context.DetallePromociones.Remove(item);
                _context.SaveChanges();
            }
          
        }

        public List<ListarDetallePromocion> GetlistDetallePromocion(Guid idpromocion)
        {
            var listadetalle = _context.DetallePromociones.AsQueryable();

            if (idpromocion != null)
            {
                listadetalle = listadetalle.Where(x => x.PromocionId == idpromocion);
            }

            return
                listadetalle
                .Include(x=> x.DescuentoPromos)
                .Include(x=> x.Producto)
                .Include(x => x.Promocion)
             .Include(x => x.Combo)
                .Select(x => new ListarDetallePromocion
                {
                    Id = x.Id,
                    Descuento = x.DescuentoPromos.Descuento,
                    Referencia=x.Producto.CodigoBarras,
                    Descripcion = x.Producto.Descripcion,
                    Promocion = x.Promocion.Descripcion,
                    //ComboId=x.ComboId,
                    NombreCombo =x.Combo.Descripcion,

                }).ToList();
        }

        public IList<ListarPromocion> GetlistPromocion()
        {
            var listaPromos = _context.Promociones.AsQueryable();

            return
                listaPromos
                
                .Include(x => x.Sucursal)
               .Where(x=> x.IsActive==false)
                .Select(x => new ListarPromocion
                {
                    Id = x.Id,
                    FechaInicio = x.FechaInicio,
                    FechaFin = x.FechaFin,
                    Descripcion = x.Descripcion,
                    HoraInicio = x.HoraInicio,
                    HoraFin = x.HoraFin,
                    Sucursal= x.Sucursal.NombreSucursal,
                    Estado=x.IsActive==true? "Inactivo":"Activo",

                }).ToList();
        }


    }
}
