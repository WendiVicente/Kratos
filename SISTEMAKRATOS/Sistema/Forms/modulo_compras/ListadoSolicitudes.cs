using CapaDatos.ListasPersonalizadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Forms.modulo_compras
{
    public class ListadoSolicitudes
    {
        public static IList<ListarCompras> ListadeSolicitudes { get; set; }

        /// <summary>
        /// Buscar la solicitud 
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="includeRelatedEntities"></param>
        /// <returns></returns>
      

        public static ListarCompras Get(Guid id, bool includerelatedentities = true)
        {
           
            return ListadeSolicitudes.Where(s => s.Id == id)
                .SingleOrDefault();
        }

    }
}
