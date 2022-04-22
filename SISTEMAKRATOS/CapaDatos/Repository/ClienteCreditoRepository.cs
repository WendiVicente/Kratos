using CapaDatos.Data;
using CapaDatos.Models.Clientes;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos.Repository
{
    public class ClienteCreditoRepository
    {
        private Context _context = null;

        public ClienteCreditoRepository(Context context)
        {
            _context = context;
        }

        public void Add(ClienteCredito clientec, bool saveChanges = true)
        {
            _context.ClienteCreditos.Add(clientec);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }


        public void Update(ClienteCredito clientec, bool saveChanges = true)
        {
            _context.Entry(clientec).State = EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();

            }
        }


        public IList<ClienteCredito> GetAll()
        {
            return _context.ClienteCreditos.ToList();
        }

        public ClienteCredito Get(int id)
        {
            return _context.ClienteCreditos
                 .Include(r => r.Id == id)
                .FirstOrDefault();
        }


        public void Delete(ClienteCredito clientec)
        {
            _context.Entry(clientec).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<ClienteCredito> GetByCuenta(Guid CuentaCBId)
        {
            var clientes = _context.ClienteCreditos.ToList();
            if (clientes.Count() > 0)
            {
                clientes = clientes.Where(x => x.CuentaCBId == CuentaCBId).ToList();
                if (clientes.Count() > 0)
                    return clientes;
                else
                    return new List<ClienteCredito>();
            }
            else
            {
                return new List<ClienteCredito>();
            }
        }

        public ClienteCredito GetByDocumento(Guid DocumentoId)
        {
            var clientes = _context.ClienteCreditos.ToList();
            ClienteCredito cliente = null;
            if (clientes.Count() > 0)
            {
                clientes = clientes.Where(x => x.DocumentoId == DocumentoId).ToList();
                if (clientes.Count() > 0)
                    cliente = clientes.FirstOrDefault();
            }
            return cliente;
        }
    }
}
