using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Clientes
{
    public class CategoriaCliente
    {
        public CategoriaCliente()
        {
            Clientes = new List<Cliente>();
        }
        public int Id { get; set; }

        public string Categoria { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
