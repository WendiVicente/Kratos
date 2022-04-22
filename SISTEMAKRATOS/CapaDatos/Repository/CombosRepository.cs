using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Productos.Combos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
   
    public class CombosRepository
    {
        private Context _context = null;
        public CombosRepository(Context context)
        {
            _context = context;
        }

        // guardar combo encabezado
        public void Add(Combo combo, bool saveChanges = true)
        {
            _context.Combos.Add(combo);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        //guardar detalle de combo
        public void AddDetalle(DetalleCombo detalleCombo, bool saveChanges = true)
        {
            _context.DetalleCombos.Add(detalleCombo);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        // delete detalle de combos

        public void DeleteDetalles(Guid idcombo)
        {
            var detalle =_context.DetalleCombos.Where(b => b.ComboId == idcombo).ToList();
            foreach (var item in detalle)
            {
                _context.DetalleCombos.Remove(item);
                _context.SaveChanges();
            }
            
        }

        //borrar un producto de un detalle
        public void DeleteProductoDetalle(DetalleCombo detalleCombo)
        {
            _context.Entry(detalleCombo).State = EntityState.Deleted;
            _context.SaveChanges();

        }

        public DetalleCombo Getdetalle(int id, bool includerelatedentities = true)
        {

            var detallecombo = _context.DetalleCombos.AsQueryable();

            if (includerelatedentities)
            {
                detallecombo = detallecombo
                    .Include(s => s.Producto);
            }

            return detallecombo.Where(s => s.Id == id)
                .SingleOrDefault();
        }

        // obtener combo 
        
        public Combo Get(Guid id, bool includerelatedentities = true)
        {
            var combos = _context.Combos.AsQueryable();

            if (includerelatedentities)
            {
               combos = combos
                   .Include(s => s.DetalleCombos);
            }

            return combos.Where(s => s.Id == id)
                .SingleOrDefault();
        }

        
        public void Update(Combo combo, bool savechages = true)
        {
            _context.Entry(combo).State = EntityState.Modified;
            if (savechages)
            {
                _context.SaveChanges();
            }
        }

        //update detallecombos
        public void UpdateDetalleCombo(DetalleCombo detalle, bool savechages = true)
        {
            _context.Entry(detalle).State = EntityState.Modified;
            if (savechages)
            {
                _context.SaveChanges();
            }
        }


        public IList<ListarCombos> GetListarCombos(int idsucursal)
        {
            return _context.Combos
            .Include(r => r.DetalleCombos)
                .Where(a => a.isActive == false && a.SucursalId == idsucursal)
                .Select(x => new ListarCombos
                {
              
                    CodigoBarras=x.CodigoBarras,
                    Descripcion= x.Descripcion,
                    FechaInicio= x.FechaInicio,
                    IdCombo= x.Id,
                    PrecioCompra=x.PrecioCompra,
                    PrecioCuentaClave= x.PrecioCuentaClave,
                    PrecioEntidadGubernamental= x.PrecioEntidadGubernamental,
                    PrecioMayorista= x.PrecioMayorista,
                    PrecioRevendedor=x.PrecioRevendedor,
                    Precioventa= x.Precioventa,
                    Stock= x.Stock,
                    SucursalId= x.Sucursal.NombreSucursal,
                   Imagen=x.Imagen,
                    

                }
                ).ToList();

            
        }

        //lista detalles segun idcombo 
        public List<ComboDetalleLista> GetListDetalleCombo(Guid id)
        {


            return _context.DetalleCombos
                    .Include(x => x.Producto)
                    .Where(a => a.ComboId == id)
                    .Select(x => new ComboDetalleLista
                    {
                        Id = x.Id,
                        Referencia = x.Referencia,
                        ProductoId = x.Producto == null ? 0 : (int)x.Producto.Id,
                        Descripcion = x.Descripcion,
                        Cantidad = x.Cantidad,
                        ComboId = x.ComboId,
                        TallayColorId = x.DetalleColorTallaId == null ? 0 : (int)x.DetalleColorTallaId,
                        ColorId = x.DetalleColorId == null ? 0 : (int)x.DetalleColorId,
                        TallaId = x.DetalleTallaId == null ? 0 : (int)x.DetalleTallaId,
                        Talla = x.DetalleColorTallaId == null ? x.DetalleTallaId == null ? "" : x.DetalleTala.Talla : x.DetalleColorTalla.Talla,
                        Color = x.DetalleColorTallaId == null ? x.DetalleColorId == null ? "" : x.DetalleColor.Color : x.DetalleColorTalla.Color
                    })
                    .ToList();
        }

        public IList<ListaCombosReporte> ListaReporte(int idsucursal=0)
        {
            var combos = _context.Combos.AsQueryable();

            if (idsucursal != 0)
            {
                combos = combos.Where(a => a.SucursalId == idsucursal);
            }


            return combos
            .Include(r => r.DetalleCombos)
               .Where(a => a.isActive == false)
                .Select(x => new ListaCombosReporte
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    FechaInicio = x.FechaInicio,
                   
                    PrecioCompra = x.PrecioCompra,
                    PrecioCuentaClave = x.PrecioCuentaClave,
                    PrecioEntidadGubernamental = x.PrecioEntidadGubernamental,
                    PrecioMayorista = x.PrecioMayorista,
                    PrecioRevendedor = x.PrecioRevendedor,
                    Precioventa = x.Precioventa,
                    Stock = x.Stock,
                    SucursalId = x.Sucursal.NombreSucursal,
                    
                    //Descripciondetalle= x.DetalleCombos.Where(x=> x.ComboId= x.Combo.IdCombo)

                


                }
                ).ToList();


        }
        public IList<ComboDetalleLista> ListaDetalleCombos()//int idsucursal)
        {
            return _context.DetalleCombos
            .Include(r => r.Combo)
             
                .Select(x => new ComboDetalleLista
                {
                   Id= x.Id,
                   ComboId=x.ComboId,
                   Cantidad=x.Cantidad,
                   Descripcion= x.Descripcion,
                   Referencia=x.Referencia,
                  
                   



                }
                ).ToList();


        }



    }





}
