using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.CuentaCobrar
{
   public class Talonario
    {
        public Guid Id { get; set; }
        public int Correlativo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaCambio { get; set; }
        public bool Estado { get; set; }
        public Guid CuentaCBId { get; set; }
        public CuentaCB CuentaCB { get; set; }
      
       
    }
}
