using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarPersonal
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefonos1 { get; set; }
        public string Telefonos2 { get; set; }
        public string Telefonos3 { get; set; }
        public int Edad { get; set; }
        public string Dpi { get; set; }
        public string Nit { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }

        public string Contrato { get; set; }
        public decimal Salario { get; set; }
        public string Sucursal { get; set; }

        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; }
        public bool Desactivar { get; set; }
        public bool Acciones { get; set; }
    }
}
