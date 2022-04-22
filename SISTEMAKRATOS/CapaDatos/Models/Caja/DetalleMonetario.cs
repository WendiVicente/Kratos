using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sharedDatabase.Models.Caja
{
    public class DetalleMonetario
    {
        public int Id { get; set; }
        public decimal? Moneda { get; set; } 
        public int? Cantidad { get; set; }
        public int CajaId { get; set; }
        public Caja Caja { get; set; }
        //public decimal tipo { get; set; }

    }
}
