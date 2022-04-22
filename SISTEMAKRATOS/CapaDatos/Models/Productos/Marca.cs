using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models
{
    public class Marca
    {
        public Marca()
        {
            Productos = new List<Producto>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }

    }
}
