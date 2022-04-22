using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Productos.Combos
{
   public  class DetalleCombo
    {
        public int Id { get; set; }

        public Guid ComboId { get; set; }
      
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }

        public int? DetalleColorId { get; set; }
        public int? DetalleTallaId { get; set; }
        public int? DetalleColorTallaId { get; set; }
        public Combo Combo { get; set; }
        public Producto Producto { get; set; }
        public DetalleColor DetalleColor { get; set; }
        public DetalleTalla DetalleTala { get; set; }
        public DetalleColorTalla DetalleColorTalla { get; set; }

    }
}
