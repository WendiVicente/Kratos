using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Vales
{
    public class DetalleRebajas
    {
        public Guid Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal precio { get; set; }
        public Guid AsignacionValeId { get; set; }





       public AsignacionVale AsignacionVale { get; set; }
        public Producto Producto { get; set; }



    }
}
