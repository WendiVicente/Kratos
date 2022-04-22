using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.Creditos
{
    public class ListarTalonarios
    {
        public Guid Id { get; set; }
        public int Correlativo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaCambio { get; set; }
        public string Estado { get; set; }
        public string NoCuenta { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
       // public string Responsable { get; set; }
       
    }
}
