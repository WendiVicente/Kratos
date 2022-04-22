using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class PedidoRepository
    {
        private Context _context = null;
        public PedidoRepository(Context context)
        {
            _context = context;
        }
        public void AddEncabezado(Pedido pedido, bool saveChanges = true)
        {
            _context.Pedidos.Add(pedido);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void AddDetalles(DetallePedidos detallePedidos, bool saveChanges = true)
        {
            _context.DetallePedidos.Add(detallePedidos);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void UpdatePedido(Pedido pddido, bool saveChanges = true)
        {
            _context.Entry(pddido).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public Pedido GetPedido(Guid idpedido)
        {
            return _context.Pedidos.Where(x => x.Id == idpedido).FirstOrDefault();
        }

        public IList<ListarPedidos> GetListGenerales(int sucursalId)
        {

            var pedidos = _context.Pedidos.AsQueryable();
            if (sucursalId != 0)
            {
                pedidos = pedidos.Where(a => a.SucursalId == sucursalId);
            }

            return pedidos
               .Include(a => a.DetallePedidos).OrderByDescending(a => a.FechaRecepcion)

               .Where(a => a.IsActive == false)
               .Select(x => new ListarPedidos
               {


                   Id = x.Id,
                   FechaRecepcion = x.FechaRecepcion,
                   Sucursal = x.Sucursal.NombreSucursal,
                   Estado = x.Estado == true ? "Comprado" : "Petición",
                   FechaLimite = x.FechaLimite,
                   NombreVendedor = x.NombreVendedor,
                   Cliente = x.Cliente.Nombres,
                   NoPedido=x.NoPedido,
                   
                   Total = x.DetallePedidos.Sum(b => b.PrecioTotal)
                   

               }

               )
               .ToList();
        }

        public List<ListarDetallePedidos> GetListDetallePedido(Guid id)
        {
           // return _context.DetallePedidos.Where(x => x.PedidoId == id).ToList();
            

            return _context.DetallePedidos
                    .Include(x => x.Producto)
                    .Where(a => a.PedidoId == id)
                    .Select(x => new ListarDetallePedidos
                    {

                        Id = x.Id,
                        PedidoId= x.PedidoId,
                        ProductoId = x.ProductoId == null ? 0 : (int)x.ProductoId,
                        ComboId = x.ComboId == null ? Guid.Empty : (Guid)x.ComboId,
                        Color = x.DetalleColor.Color,
                        Talla = x.DetalleTalla.Talla,
                        Descripcion = x.ProductoId == null ? x.Combo.Descripcion : x.Producto.Descripcion,
                        Cantidad = x.Cantidad,
                        Precio = x.Precio,
                        Total = x.PrecioTotal,
                        DetalleColorId = x.DetalleColorId == null ? 0 : (int)x.DetalleColorId,
                        DetalleTallaId = x.DetalleTallaId == null ? 0 : (int)x.DetalleTallaId,
                        TallayColorId = x.DetalleColorTallaId == null ? 0 : (int)x.DetalleColorTallaId,

                    })
                    .ToList();
        }

        public string GetLastPedidos(int sucursal)
        {
            var listado = _context.Pedidos.ToList();
            if (listado.Count() > 0)
            {
                listado = listado.Where(x => x.SucursalId == sucursal).ToList();
                listado = listado.OrderByDescending(x => x.NoPedido).ToList();
                if (listado.Count() > 0)
                {
                    string no = listado.FirstOrDefault().NoPedido;
                    return no;
                   
                }
                else
                {
                    return "";

                }

            }
            else
            {
                return "";
            }

        }

    }
}
