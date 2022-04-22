using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarUsuarios
    {
        public string Id { get; set; }
        public int SucursalId { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Sucursal { get; set; }
        public string Privilegios { get; set; }
        public int Token { get; set; }
        public bool Estado { get; set; }
    }
}
