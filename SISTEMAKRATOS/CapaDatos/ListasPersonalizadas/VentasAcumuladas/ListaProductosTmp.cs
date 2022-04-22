using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.VentasAcumuladas
{
    public class ListaProductosTmp
    {

        public int Id { get; set; }//0
        public string Color { get; set; }//1
        public string Talla { get; set; }//2
        public string Descripcion { get; set; }//3

        public int Cantidad { get; set; }//4
        public decimal Precio { get; set; }//5
        public decimal Descuento { get; set; }//6
        public decimal SubTotal { get; set; }//7
        public decimal PrecioTotal { get; set; }//8
        

        public int ProductoId { get; set; }//10
        //public Guid FacturaId { get; set; }//11
        public Guid ComboId { get; set; }//12
        public int DetalleColorId { get; set; }//13
        public int DetalleTallaId { get; set; }//14
        public int TallayColorId { get; set; }//15
       // public int TipoPrecioId { get; set; }//16
        public bool Acciones { get; set; }//14
        public bool IsActive { get; set; }
        /*
          public int Id { get; set; }//0
        public string Color { get; set; }//1
        public string Talla { get; set; }//2
        public string Descripcion { get; set; }//3

        public int Cantidad { get; set; }//4
        public decimal Precio { get; set; }//5
        public decimal Descuento { get; set; }//6
        public decimal SubTotal { get; set; }//7
        public decimal PrecioTotal { get; set; }//8
        public decimal Utilidad { get; set; }//9

        public int ProductoId { get; set; }//10
        public Guid FacturaId { get; set; }//11
        public Guid ComboId { get; set; }//12
        public int DetalleColorId { get; set; }//13
        public int DetalleTallaId { get; set; }//14
        public int TallayColorId { get; set; }//15
        public int TipoPrecioId { get; set; }//16
        public bool Acciones { get; set; } 
         
         */
    }
}
