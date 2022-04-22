using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Prestamos
{
   public class TipoCredito
    {
        public TipoCredito()
        {
            Prestamos = new List<Prestamos>();

        }
        public int Id { get; set; }
        public string Tipo { get; set; }




        public ICollection<Prestamos> Prestamos { get; set; }
        
    }
}
