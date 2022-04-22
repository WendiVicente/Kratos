using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarVales
    {
        public Guid Id { get; set; }
        public string NoVale { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaRecepcion { get; set; }

        public decimal Monto { get; set; }
        public string Sucursal { get; set; }
        public string Usuario { get; set; }
        public int TipoPrecio { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
    }
}
