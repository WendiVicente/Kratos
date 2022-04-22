using sharedDatabase.Models.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recepciones
{
    public class Recepcion
    {
        public Recepcion()
        {
            detalleRecepciones = new List<DetalleRecepcion>();
        }
        public int Id { get; set; }
        public int SucursalId { get; set; }
        public Guid CompraId { get; set; }
        public int EstadoRecepcionId { get; set; }
        public EstadoRecepcion EstadoRecepcion { get; set; }
        public Compra Compra { get; set; }
        
        public ICollection<DetalleRecepcion> detalleRecepciones { get; set; }
    }
}
