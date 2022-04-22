using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarPReserva
    {
        public Guid Id { get; set; }//0
        public string Descripcion { get; set; }//1
        public string Color { get; set; }//2
        public string Talla { get; set; }//3
        public int Cantidad { get; set; }//4
        public decimal Precio { get; set; }//5
        public decimal Total { get; set; }//6
        public string NoCuenta { get; set; }//7
        public Guid CuentaCBId { get; set; }//8
        public int? ProductoId { get; set; }//9
        public Guid? ComboId { get; set; }//10
        public int? DetalleColorId { get; set; }//11
        public int? DetalleTallaId { get; set; }//12
        public int? DetalleColorTallaId { get; set; }//n13
        public string Estado { get; set; }//14
        public bool Acciones { get; set; }//15

    }
}
