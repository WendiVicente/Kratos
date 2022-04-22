using sharedDatabase.Models.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Proveedores
{
    public class Rubro
    {
        public Rubro()
        {
            Proveedores = new List<Proveedor>();

        }
        public int Id { get; set; }
        public string Descripcion {get;set;}
        public bool IsActive { get; set; }
        
        public ICollection<Proveedor> Proveedores { get; set; }
    }
}
