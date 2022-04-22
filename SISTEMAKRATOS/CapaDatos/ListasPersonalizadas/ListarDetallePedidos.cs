using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarDetallePedidos
    {
      
        public Guid Id { get; set; } //0
        public Guid PedidoId { get; set; } //1
        public int ProductoId { get; set; } //2
        public Guid ComboId { get; set; }//3
        public string Color { get; set; } //4
        public string Talla { get; set; }//5
        public string Descripcion { get; set; } //6
        public decimal Precio { get; set; } //7
        public int Cantidad { get; set; } //8
        public decimal Total { get; set; } //9
        public int DetalleColorId { get; set; } //10
        public int DetalleTallaId { get; set; } //11
        public int TallayColorId { get; set; } //12
    }
}
