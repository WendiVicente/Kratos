using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos.Repository
{
    public class ProductosRepository
    {
        private Context _context = null;

        public ProductosRepository(Context context)
        {
            _context = context;
        }

        public IList<ListarProductos> GetList(int idSucursal)
        {

            return _context.Productos
              .Include(r => r.Categoria)
              .Where(a => a.Deleted == false && a.SucursalId == idSucursal)
              .OrderBy(a => a.Id).ThenByDescending(a => a.Id)
              .Select(x => new ListarProductos
              {
                  Id = x.Id,
                  Categoria = x.Categoria.Nombre,
                  Sucursal = x.Sucursal.NombreSucursal,
                  Descripcion = x.Descripcion,
                  CodigoReferencia = x.CodigoBarras,
                  Ubicacion = x.Ubicacion,
                  PrecioVenta = x.PrecioVenta,
                  PeriodoMovimiento=x.PeriodoMovimiento,
                  DescuentoEspecial=x.DescuentoEspecial,
                  PrecioCuentaClave=x.PrecioCuentaClave,
                  PrecioEntidadGubernamental=x.PrecioEntidadGubernamental,
                  PrecioMayorista=x.PrecioMayorista,
                  PrecioRevendedor=x.PrecioRevendedor,
                  FechaIngreso=x.FechaIngreso,
                  FechaModificacion=x.FechaModificacion,
                  //reInventarioBajo=x.stockMinimo,
                  Escalas = x.TieneEscalas,
                  Coste = x.Coste,
                  Stock = x.Stock,
                  StockControl = x.StockControl == true ? "Sí" : "No",
                  Notas = x.Notas,
                  PermitirVenta = x.PermitirVenta == true ? "Sí" : "No",
                  PermitirCompra = x.PermitirCompra == true ? "Sí" : "No",
                  IncluyeColor = x.TieneColor == false ? "No" : "Si",
                  Talla = x.TieneTalla == false ? "No" : "Si",
                  Deleted = x.Deleted,
                  Imagen = x.Imagen,

              })
              .OrderBy(a => a.Descripcion)
              .ToList();


        }
        // listar productos que utilizan colores

        public IList<ListarProductos> GetListProductosColores(int idSucursal, bool isColor=true)
        {

            return _context.Productos
              .Include(r => r.Categoria)
              .Include (z=> z.DetalleColors)
              .Where(a => a.Deleted == false && a.SucursalId == idSucursal && a.TieneColor==isColor)
              .OrderBy(a => a.Id)
              .Select(x => new ListarProductos
              {
                  Id = x.Id,
                  Categoria = x.Categoria.Nombre,
                  Descripcion = x.Descripcion,
                  CodigoReferencia = x.CodigoBarras,
                  Ubicacion = x.Ubicacion,
                  PrecioVenta = x.PrecioVenta,
                  Coste = x.Coste,
                  Stock = x.Stock,
                  StockControl = x.StockControl == true ? "Sí" : "No",
                  Notas = x.Notas,
                  PermitirVenta = x.PermitirVenta == true ? "Sí" : "No",
                  PermitirCompra = x.PermitirCompra == true ? "Sí" : "No",
                  IncluyeColor =x.TieneColor == true? "Sí":"No",
                  Talla = x.TieneTalla == true ? "Sí" : "No",
                  Escalas = x.TieneEscalas,
                  Deleted = x.Deleted
              })
              .OrderBy(a => a.Descripcion)
              .ToList();


        }
        //var listadeProductos = _productosRepository.GetListReportes(idsucursal, allFechas, fechaInicio,
       // fechaFinal.AddDays(1), prodActivo, prodInactivo, todosEstados, idCategoria, includeAltas, includeBajas, includeTodas, orderByUltimoMov, orderByExistencia);
        public IList<ListarProductos> GetListReportes(int idSucursal, bool todasfechas,DateTime fechainicio,DateTime fechafinal,
            bool activoProd,bool inactivoProd, bool allState, int categoria, bool orderByLastMov, bool orderByExiste)
        {
            var productolist = _context.Productos.AsQueryable();

            if(idSucursal != 0)
            {
                productolist = productolist.Where(a => a.SucursalId == idSucursal);
            }
            if (categoria != 0)
            {
                productolist = productolist.Where(a => a.CategoriaId == categoria);
            }
            if(todasfechas ==false)
            {
                productolist = productolist.Where(a => a.FechaIngreso > fechainicio && a.FechaIngreso <= fechafinal);
            }

            if (orderByExiste == true)
            {
                productolist = productolist.OrderBy(a => a.Stock);
            }
            if (orderByLastMov == true)
            {
                productolist = productolist.OrderBy(a => a.PeriodoMovimiento);
            }

            if (allState == false)
            {
                if (activoProd == true)
                {
                    productolist = productolist.Where(a => a.Deleted == false);
                }
                if (inactivoProd == true)
                {
                    productolist = productolist.Where(a => a.Deleted == true);
                }

            }


            return productolist
               .Include(r => r.Categoria)
               .Include(r => r.Sucursal)
              //.Where(a => a.Deleted == false)
              .Select(x => new ListarProductos
              {
                  Id = x.Id,
                  Categoria = x.Categoria.Nombre,
                  Sucursal = x.Sucursal.NombreSucursal,
                  Descripcion = x.Descripcion,
                  CodigoReferencia = x.CodigoBarras,
                  Ubicacion = x.Ubicacion,
                  PrecioVenta = x.PrecioVenta,
                  Coste = x.Coste,
                  Stock = x.Stock,
                  StockControl = x.StockControl == true ? "Sí" : "No",
                  Notas = x.Notas,
                  PermitirVenta = x.PermitirVenta == true ? "Sí" : "No",
                  PermitirCompra = x.PermitirCompra == true ? "Sí" : "No",
                  IncluyeColor = x.TieneColor == true ? "Sí" : "No",
                  Deleted = x.Deleted,
                  Estado = x.Deleted == true ? "Inactivo" : "Activo",
                  PrecioCuentaClave = x.PrecioCuentaClave,
                  PrecioEntidadGubernamental = x.PrecioEntidadGubernamental,
                  PrecioMayorista = x.PrecioMayorista,
                  PrecioRevendedor = x.PrecioRevendedor,
                  FechaIngreso = x.FechaIngreso,
                  DescuentoEspecial = x.DescuentoEspecial,
                  Impuesto = x.Impuesto,
                  PeriodoMovimiento = x.PeriodoMovimiento,
                  InventarioBajo= x.stockMinimo == x.Stock? "Sí":"No",
                  Talla = x.TieneTalla == true ? "Sí" : "No",
                  FechaModificacion = x.FechaModificacion,


              }).ToList();


        }


        public IList<ListarProductos> GetListByCategoria(int categoriaid, int idSucursal)
        {

            return _context.Productos
              .Include(r => r.Categoria)
              .Where(a => a.Deleted == false && a.SucursalId == idSucursal && a.CategoriaId == categoriaid)
              .OrderBy(a => a.Id).ThenByDescending(a => a.Id)
              .Select(x => new ListarProductos
              {
                  Id = x.Id,
                  Categoria = x.Categoria.Nombre,
                  Sucursal = x.Sucursal.NombreSucursal,
                  Descripcion = x.Descripcion,
                  CodigoReferencia = x.CodigoBarras,
                  Ubicacion = x.Ubicacion,
                  PrecioVenta = x.PrecioVenta,
                  PeriodoMovimiento = x.PeriodoMovimiento,
                  DescuentoEspecial = x.DescuentoEspecial,
                  PrecioCuentaClave = x.PrecioCuentaClave,
                  PrecioEntidadGubernamental = x.PrecioEntidadGubernamental,
                  PrecioMayorista = x.PrecioMayorista,
                  PrecioRevendedor = x.PrecioRevendedor,
                  FechaIngreso = x.FechaIngreso,
                  FechaModificacion = x.FechaModificacion,
                  //reInventarioBajo=x.stockMinimo,

                  Coste = x.Coste,
                  Stock = x.Stock,
                  StockControl = x.StockControl == true ? "Sí" : "No",
                  Notas = x.Notas,
                  PermitirVenta = x.PermitirVenta == true ? "Sí" : "No",
                  PermitirCompra = x.PermitirCompra == true ? "Sí" : "No",
                  IncluyeColor = x.TieneColor == false ? "No" : "Si",
                  Talla = x.TieneTalla == false ? "No" : "Si",
                  Deleted = x.Deleted,
                  Imagen = x.Imagen,

              })
              .OrderBy(a => a.Descripcion)
              .ToList();


        }



        public IList<Categoria> GetCategoriasList()
        {
            return _context.Categorias.OrderBy(h => h.Nombre).ToList();
        }


        //sirve para capturar el producto segun Id en el argumeto
        public Producto Get(int id, bool includerelatedentities = true)
        {
            var productos = _context.Productos.AsQueryable();

            if (includerelatedentities)
            {
                productos = productos
                    .Include(s => s.Categoria);
            }

            return productos.Where(s => s.Id == id)
                .SingleOrDefault();
        }

        public Producto GetProductByBarCode(string barcode,int sucursalid)
        {
            return _context.Productos.Where(a => a.CodigoBarras == barcode && a.Deleted == false && a.SucursalId ==sucursalid).SingleOrDefault();
        }


        //public Producto GetCodigoBarras(string codigo, bool includeRelatedEntities = true)
        //{
        //    var productos = _context.Productos.AsQueryable();

        //    if (includeRelatedEntities)
        //    {
        //        productos = productos
        //            .Include(s => s.Categoria);
        //    }

        //    return productos.Where(s => s.CodigoBarras == codigo && s.IsActive == false)
        //        .SingleOrDefault();
        //}

        public List<Producto> GetAllProductos()
        {
            return _context.Productos.ToList();
        }

        public decimal GetUtilidadProducto(int id, decimal precio)
        {
            decimal utilidad = 0.00m;
            var prod  = _context.Productos.Where(x => x.Id == id);
            if (prod != null)
            {
                Producto producto = prod.FirstOrDefault();
                utilidad = producto.Utilidad;
            }

            return utilidad;
        }

        public void Add(Producto producto, bool saveChanges = true)
        {
            _context.Productos.Add(producto);

            if (saveChanges)
            {
                _context.SaveChanges();

            }

        }


        public void Update(Producto producto, bool saveChanges = true)
        {
            _context.Entry(producto).State = EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
                
            }

        }

     

    }
}
