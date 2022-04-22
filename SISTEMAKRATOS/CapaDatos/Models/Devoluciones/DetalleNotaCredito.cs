using CapaDatos.Models.CuentaCobrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Devoluciones
{
    public class DetalleNotaCredito
    {
        public int Id { get; set; }//0
        public Guid NotaCreditoId { get; set; }//1
        public string Descripcion { get; set; }//2
        public int Cantidad { get; set; }//3
        public decimal Precio { get; set; }//4
        public decimal Descuento { get; set; }//5
        public decimal SubTotal { get; set; }//6
        public decimal PrecioTotal { get; set; }//7
        public int? ProductoId { get; set; }//8
        public Guid? ComboId { get; set; }//9
        public int? DetalleColorId { get; set; }//10
        public int? DetalleTallaId { get; set; }//11
        public int? TallayColorId { get; set; }//12
        
        public NotaCredito NotaCredito { get; set; }//13
       
    }
}
