using CapaDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Validations
{
    public class ValidarExistenciaProducto
    {
        private Context _context = null;

        public ValidarExistenciaProducto(Context context) {

            _context = context;
        }

        public bool ValidarRegistro(string codigo, int idsucursal)
        {
            return _context.Productos
                .Where(a => a.Deleted == false)
                .Where(a => a.SucursalId == idsucursal)
                .Any(a => a.CodigoBarras == codigo);
        }
    }


}


    
