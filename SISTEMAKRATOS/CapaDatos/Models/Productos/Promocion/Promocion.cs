using CapaDatos.Models.Sucursales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Productos.Promocion
{
    public class Promocion
    {
        public Promocion()
        {
            DetallePromocions = new List<DetallePromocion>();
        }
        public Guid Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Descripcion { get; set; }
        public int?  SucursalId { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        
        public bool IsActive { get; set; }
        public Sucursal Sucursal { get; set; }
        public ICollection<DetallePromocion> DetallePromocions { get; set; }
    }
}
