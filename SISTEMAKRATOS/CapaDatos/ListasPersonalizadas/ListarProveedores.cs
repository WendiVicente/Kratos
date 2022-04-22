using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
   public  class ListarProveedores
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }
        public string Correo { get; set; }

        public string Telefonos { get; set; }
        public string Telefonos2 { get; set; }
        public string Celular { get; set; }
        public string Celular2 { get; set; }
        public string Nit { get; set; }
        public string NoCuentaBancaria { get; set; }

        public DateTime Ingreso { get; set; }

        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public bool Desactivar { get; set; }
        public string SucursalId { get; set; }
        public string Banco { get; set; }
        public string Rubro { get; set; }
        public string Frecuencia { get; set; }
        public string TipoProveedor { get; set; }

    }
}
