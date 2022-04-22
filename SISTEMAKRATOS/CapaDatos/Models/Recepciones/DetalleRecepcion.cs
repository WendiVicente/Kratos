using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recepciones
{
   public class DetalleRecepcion
    {
        public DetalleRecepcion()
        {

        }


        public int Id { get; set; }
        public int RecepcionId { get; set; }

        public Recepcion recepcion { get; set; }


    }
}
