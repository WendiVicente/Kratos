using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarClientes
    {
        public int Codigo { get; set; }
        public string CodigoCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefonos { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
        public string Alias { get; set; }
        public string Tipo_Cliente { get; set; }
       
        public DateTime FechaCreacion { get; set; }
        public bool Desactivado { get; set; }
        public string EstadoActual { get; set; }
        public string Sucursal { get; set; }
        public string Categoria { get; set; }
        public string Credito { get; set; }
        public bool  Acciones { get; set; }
        public DateTime FechaUltimaCompra { get; set; }
        public string DPI { get; set; }
    }
}
