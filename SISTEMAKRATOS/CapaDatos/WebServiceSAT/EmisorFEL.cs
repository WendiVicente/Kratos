using CapaDatos.Data;
using CapaDatos.Models.DocumentoSAT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.WebServiceSAT
{
    
    public class EmisorFEL 
    {
        
        public EmisorFEL()
        {            
            //emi = new Context().Emisors.ToList().Where(x => x.nitemisor == "44653948").ElementAt(0);
            //PRODUCCION
            emi = new Context().Emisors.ToList().Where(x => x.nitemisor == "44653948").ElementAt(0);
        }

        public EmisorFEL(int entorno)
        {
            if (entorno == 1)
            {
                emi = new Context().Emisors.ToList().Where(x => x.nitemisor == "44653948").ElementAt(0);
            }
            else if (entorno == 2)
            {
                emi = new Context().Emisors.ToList().Where(x => x.nitemisor == "44653948").ElementAt(0);
            }
        }

        public Emisor emi { get; }
    }
}
