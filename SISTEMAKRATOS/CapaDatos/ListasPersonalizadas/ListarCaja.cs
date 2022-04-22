using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarCaja
    {
        public int Id_Transaccion { get; set; }
        public DateTime FechaApertura { get; set; }

        public DateTime? FechaCierre { get; set; } // ? significa que no es obligatorio, aceptara campos null

        public decimal MontoApertura { get; set; }

        public string EstadoCaja { get; set; } // abierta o cerrada
       // public decimal Total { get; set; }
      //  public string Usuario { get; set; }
        public string  Sucursal { get; set; }

    }
}
