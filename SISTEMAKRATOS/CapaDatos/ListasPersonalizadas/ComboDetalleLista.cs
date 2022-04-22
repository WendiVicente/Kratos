using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ComboDetalleLista
    {


        public int Id { get; set; }
        public Guid ComboId { get; set; }
        public int ProductoId { get; set; }
        public string Referencia { get; set; }

        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
        public int TallaId { get; set; }
        public string Talla { get; set; }
        public int TallayColorId { get; set; }



    }
}
