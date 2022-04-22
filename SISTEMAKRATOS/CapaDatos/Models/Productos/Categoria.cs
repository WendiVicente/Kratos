using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Productos = new List<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Inactivo { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
