using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Precios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos.Repository.PreciosRepository
{
    public class TipoPrecioRepository
    {
        private Context _context = null;

        public TipoPrecioRepository(Context context)
        {
            _context = context;
        }

        public void AddDescuento(DescuentoPromos descuentos, bool saveChanges = true)
        {
            _context.DescuentoPromos.Add(descuentos);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }



        public void Add(TipoPrecio precio, bool saveChanges = true)
        {
            _context.TipoPrecios.Add(precio);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        // guardar detalle de precios
        public void AddDetallePrecio(DetallePrecio model, bool guardarpordefecto = true)
        {
            _context.DetallePrecios.Add(model);

            if (guardarpordefecto)
            {
                _context.SaveChanges();
            }
        }

        public void Update(TipoPrecio precio, bool saveChanges = true)
        {
            _context.Entry(precio).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        //update detalle de caja para compras
        public void UpdateDetallePrecio(DetallePrecio detalle, bool saveChanges = true)
        {
            _context.Entry(detalle).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

         //listas de todos los registros 

        public IList<ListarTipoPrecios> GetTipoPreciosAll()
        {
            return _context.TipoPrecios
                .Include(y=> y.Producto)
                .Include(x=> x.DetallePrecios)
                .Select(x => new ListarTipoPrecios
                {
                   Id=x.Id,
                 // Descripcion= x.Tipos.TipoCliente,
                   ProductoId= x.ProductoId,
                   
                }).ToList();
        }

        public IList<ListarDetallePrecios> GetDetallePreciosAll()
        {
            return _context.DetallePrecios
                .Select(x => new ListarDetallePrecios
                {
                    Id=x.Id,
                    TipoPrecioId= x.TipoPrecioId,
                    RangoInicio= x.RangoInicio,
                    RangoFinal=x.RangoFinal,
                    Precio= x.Precio

                }).ToList();
        }

       
        public IList<DescuentoPromos> GetDescuentopromosAll()
        {
            return _context.DescuentoPromos.OrderByDescending(x=> x.Descuento).
                ToList();
              /*  .Select(x => new ListarDetallePrecios
                {
                    Id = x.Id,
                    TipoPrecioId = x.TipoPrecioId,
                    RangoInicio = x.RangoInicio,
                    RangoFinal = x.RangoFinal,
                    Precio = x.Precio

                }).ToList();*/
        }





        // Buscar un solo registro

        public TipoPrecio Get(int idproducto, bool includeRelatedEntities = true)
        {
            var precio = _context.TipoPrecios.AsQueryable();

            if (includeRelatedEntities)
            {
                precio = precio.Include(a => a.DetallePrecios);

            }

            return precio.Where(a => a.ProductoId == idproducto).SingleOrDefault();
        }


        public List<DetallePrecio> GetDetallePrecio(Guid id,int tipoprecio)
        {
            var Detalle = _context.DetallePrecios.AsQueryable();
            if (id != null)
            {
                Detalle = Detalle.Where(x => x.TipoPrecioId == id);
            }
            if (tipoprecio != 0)
            {
                Detalle = Detalle.Where(x => x.TiposId == tipoprecio);
            }
          
          

            return Detalle.ToList();
        }

        public List<DetallePrecio> GetDetallePrecios(Guid id)
        {
            var Detalle = _context.DetallePrecios.AsQueryable();
            Detalle = Detalle.Where(x => x.TipoPrecioId == id);
            return Detalle.ToList();
        }



        public List<ListarDetallePrecios> GetDetallePrecioListar(Guid id, int tipoprecio)
        {
            var Detalle = _context.DetallePrecios.AsQueryable();
            if (id != null)
            {
                Detalle = Detalle.Where(x => x.TipoPrecioId == id);
            }
            if (tipoprecio != 0)
            {
                Detalle = Detalle.Where(x => x.TiposId == tipoprecio);
            }

            return Detalle
                
              .Select(x => new ListarDetallePrecios
              {
                  Id = x.Id,
                  TipoPrecioId = x.TipoPrecioId,
                  Tipos = x.Tipos.TipoCliente,
                  Escala = x.Escala,
                  RangoInicio = x.RangoInicio,
                  RangoFinal = x.RangoFinal,
                  TiposId = x.TiposId,
                  Precio = x.Precio


              }).OrderBy(x=> x.Tipos).ThenBy(x=>x.RangoInicio).ToList();
        }

        public void DeleteDetallePrecio(TipoPrecio DetallePrecio)
        {
            _context.Entry(DetallePrecio).State = EntityState.Deleted;
            //  _context.detalleColors.Sql.r
            _context.SaveChanges();
        }

        public void DeleteDetallePreciop(DetallePrecio Detalle)
        {
            _context.Entry(Detalle).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public DetallePrecio GetDetalle(Guid id)
        {
            return _context.DetallePrecios
                  .Where(r => r.Id == id)
                .FirstOrDefault();
        }
    }
}
