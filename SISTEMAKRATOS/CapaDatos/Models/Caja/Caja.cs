//using CapaDatos.Models.Caja;
using CapaDatos.Models.Sucursales;
using CapaDatos.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models.Caja
{
    public class Caja
    {
        public Caja()
        {
            DetalleCajas = new List<DetalleCaja>();
            DetalleMonetarios = new List<DetalleMonetario>();
        }


        public int Id { get; set; }
        public DateTime FechaApertura { get; set; }

        public DateTime? FechaCierre { get; set; } // ? significa que no es obligatorio, aceptara campos null

       // public string Responsable { get; set; }

        public decimal MontoApertura { get; set; }

        public bool EstadoCaja { get; set; } // abierta o cerrada
       // public string  UsuarioId { get; set; }
        public int  SucursalId { get; set; }

        public Sucursal Sucursal{ get; set; }


        public ICollection<DetalleCaja> DetalleCajas { get; set; }
        public ICollection<DetalleMonetario> DetalleMonetarios { get; set; }
    }
}
