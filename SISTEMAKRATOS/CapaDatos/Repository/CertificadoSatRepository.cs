using CapaDatos.Data;
using CapaDatos.Models.DocumentoSAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class CertificadoSatRepository
    {
        public Context _context = null;
        public CertificadoSatRepository(Context context)
        {
            _context = context;
        }

        public void add(DocumentoCertificadoSAT certificado)
        {
            _context.DocumentoCertificadoSATs.Add(certificado);
            _context.SaveChanges();
        }
        
        public void addAnulacion(AnulacionCertificado certiAnulada)
        {
            _context.AnulacionCertificados.Add(certiAnulada);
            _context.SaveChanges();
        }
        public DocumentoCertificadoSAT Get(string numeroDoc)
        {

            return _context.DocumentoCertificadoSATs.Where(x => x.Autorizacion == numeroDoc).FirstOrDefault();
        }
       
        public List<AnulacionCertificado> GetListaAnulaciones()
        {
            return _context.AnulacionCertificados.ToList();
        }

        public List<DocumentoCertificadoSAT> GetlistaDoCertificadoSAT()
        {
            return _context.DocumentoCertificadoSATs.ToList();
        }

    }
}
