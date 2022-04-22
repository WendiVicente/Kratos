using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.CuentaCobrar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class ProductosReservaRepository
    {
        private Context _context = null;

        public ProductosReservaRepository(Context context)
        {
            _context = context;
        }
        public void Add(ProductosReserva preserva, bool saveChanges = true)
        {
            _context.ProductosReservas.Add(preserva);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void Update(ProductosReserva preserva, bool saveChanges = true)
        {
            _context.Entry(preserva).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public ProductosReserva Get(Guid id)
        {
            return _context.ProductosReservas.Where(x => x.Id == id && x.IsActive == false).FirstOrDefault();
        }
        public IList<ListarPReserva> GetListaPReservas(Guid cuentaid, bool estadop)
        {
            var listaProductos = _context.ProductosReservas.AsQueryable();
            if (estadop)
            {
                listaProductos = listaProductos.Where(x => x.IsActive == true);
            }
            else
            {
                listaProductos = listaProductos.Where(x => x.IsActive == false);
            }
            return
                listaProductos
                .Include(x => x.Producto)
                .Where(x => x.CuentaCBId == cuentaid)
                .Select(x => new ListarPReserva
                {
                    Id = x.Id,
                    Descripcion = x.ProductoId == null ? x.Combo.Descripcion : x.Producto.Descripcion,
                    Cantidad=x.Cantidad,
                    Precio=x.Precio,
                    Total=x.Total,
                    NoCuenta=x.CuentaCB.NoCuenta,
                    CuentaCBId=x.CuentaCBId,
                    ProductoId=x.ProductoId==null? 0:x.ProductoId,
                    ComboId=x.ComboId==null? null: x.ComboId,
                    DetalleColorId=x.DetalleColorId,
                    DetalleColorTallaId=x.DetalleColorTallaId,
                    DetalleTallaId=x.DetalleTallaId,
                    Estado=x.IsActive==false? "No pagado":"Pagado",
                    



                }).ToList();
        }

    }
}
