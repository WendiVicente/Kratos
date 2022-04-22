using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Vales
{
   public  class AsignacionVale
    {
        public AsignacionVale()
        {
            DetalleVales = new List<DetalleVale>();
            DetalleRebajas = new List<DetalleRebajas>();
        }
        public Guid Id { get; set; }
        public Guid ValeId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Nit { get; set; }
        public int? ClienteId { get; set; }
        public decimal Monto { get; set; }
        public decimal Reciduo { get; set; }
        public string Estado { get; set; }
        public int NoVale { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaCambio { get; set; }



        public Vale Vale { get; set; }

        public Cliente Cliente { get; set; }
        public ICollection<DetalleVale> DetalleVales { get; set; }
        public ICollection<DetalleRebajas> DetalleRebajas { get; set; }
    }
}
