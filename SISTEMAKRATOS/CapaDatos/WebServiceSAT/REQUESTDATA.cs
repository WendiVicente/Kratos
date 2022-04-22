using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi
{
   public class REQUESTDATA
    {
       
        
            public int Respuesta { get; set; }
            public string Codigo { get; set; }
            public string Procesador { get; set; }
            public object Mensaje { get; set; }
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
        
    }
}
