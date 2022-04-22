using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Transacciones
{
   public class TipoMovimiento
    {
        public TipoMovimiento()
        {
            Transacciones = new List<Transaccion>();
        }
        public int Id { get; set; }
        public string Movimiento { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Transaccion> Transacciones { get; set; }
    }
}
