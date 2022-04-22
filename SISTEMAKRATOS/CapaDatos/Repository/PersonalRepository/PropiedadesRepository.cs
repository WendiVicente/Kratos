using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.PropiedadesLista;
using CapaDatos.Models.Bancos;
using CapaDatos.Models.Personal;
using CapaDatos.Models.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.PersonalRepository
{
    public class PropiedadesRepository
    {
        private Context _context = null;

        public PropiedadesRepository(Context context)
        {
            _context = context;

        }

        public void AddDepartamento(Departamento depto, bool saveChanges = true)
        {
            _context.Departamentos.Add(depto);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public IList<ListarDepartamentos> GetListDepartamentos()
        {

            return _context.Departamentos
               .Select(x => new ListarDepartamentos
               {
                   Id = x.Id,
                   Area = x.Area,
                   Estado = x.IsActive == true ? "Inactiva" : "Activa",



               }).ToList();
        }

        public Departamento GetDepartamento(int id, bool includerelated = true)
        {
            var Depto = _context.Departamentos.AsQueryable();
            if (includerelated)
            {
            }
            return Depto.Where(a => a.Id == id).SingleOrDefault();

        }
        public void UpdateDepartamento(Departamento depto, bool saveChanges = true)
        {
            _context.Entry(depto).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }



        public void AddHorario(Horario horario, bool saveChanges = true)
        {
            _context.Horarios.Add(horario);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public IList<ListarHorarios> GetListHorarios()
        {
            return _context.Horarios
            .Select(x => new ListarHorarios
            {
                Id = x.Id,
                Periodo = x.Periodo,
                Estado = x.IsActive == true ? "Inactiva" : "Activa",



            }).ToList();
        }

        public Horario GetHorario(int id, bool includerelated = true)
        {
            var Horario = _context.Horarios.AsQueryable();
            if (includerelated)
            {
            }
            return Horario.Where(a => a.Id == id).SingleOrDefault();

        }
        public void UpdateHorario(Horario horario, bool saveChanges = true)
        {
            _context.Entry(horario).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }




        public void AddPuesto(Puesto puesto, bool saveChanges = true)
        {
            _context.Puestos.Add(puesto);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public IList<ListarPuestos> GetListPuestos()
        {
            return _context.Puestos
                .Select(x => new ListarPuestos
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Departamento = x.Departamento.Area,
                    Estado = x.IsActive == true ? "Inactiva" : "Activa",

                }).ToList();
        }

        public Puesto GetPuesto(int id, bool includerelated = true)
        {
            var puesto = _context.Puestos.AsQueryable();
            if (includerelated)
            {
            }
            return puesto.Where(a => a.Id == id).SingleOrDefault();

        }
        public void UpdatePuesto(Puesto puesto, bool saveChanges = true)
        {
            _context.Entry(puesto).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        //contrato 
        public void AddContrato(TipoContrato contrato, bool saveChanges = true)
        {
            _context.TipoContratos.Add(contrato);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public IList<ListarContratos> GetListContratos()
        {
            return _context.TipoContratos
                .Select(x => new ListarContratos
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Estado = x.IsActive == true ? "Inactiva" : "Activa",

                }).ToList();
        }

        public TipoContrato GetContrato(int id, bool includerelated = true)
        {
            var TiposContrato = _context.TipoContratos.AsQueryable();
            if (includerelated)
            {
            }
            return TiposContrato.Where(a => a.Id == id).SingleOrDefault();

        }
        public void UpdateContrato(TipoContrato contrato, bool saveChanges = true)
        {
            _context.Entry(contrato).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        // fin 

        public void AddFrecuencia(Frecuencia frecuencia, bool saveChanges = true)
        {
            _context.Frecuencias.Add(frecuencia);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public IList<ListarFrecuenciaP> GetListFrecuencias()
        {
            return _context.Frecuencias
               .Select(x => new ListarFrecuenciaP
               {
                   Id = x.Id,
                   Periodo = x.Periodo,
                   Estado = x.IsActive == true ? "Inactiva" : "Activa",



               }).ToList();

        }
        public Frecuencia GetFrecuencia(int id, bool includerelated = true)
        {
            var frecuencia = _context.Frecuencias.AsQueryable();
            if (includerelated)
            {
            }
            return frecuencia.Where(a => a.Id == id).SingleOrDefault();

        }
        public void UpdateFrecuencia(Frecuencia frecuencia, bool saveChanges = true)
        {
            _context.Entry(frecuencia).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }


        public void AddRubro(Rubro rubro, bool saveChanges = true)
        {
            _context.Rubros.Add(rubro);

            if (saveChanges)
            {
                _context.SaveChanges();
            }


        }
        public IList<ListarRubros> GetListRubros()
        {
           
            return _context.Rubros
             .Select(x => new ListarRubros
             {
                 Id = x.Id,
                 Descripcion = x.Descripcion,
                 Estado = x.IsActive == true ? "Inactiva" : "Activa",



             }).ToList();
        }
        public Rubro GetRubro(int id, bool includerelated = true)
        {
            var rubro = _context.Rubros.AsQueryable();
            if (includerelated)
            {
            }
            return rubro.Where(a => a.Id == id).SingleOrDefault();

        }

        public void UpdateRubro(Rubro rubro, bool saveChanges = true)
        {
            _context.Entry(rubro).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void AddTipoProveedor(TipoProveedor tipoprove, bool saveChanges = true)
        {
            _context.TipoProveedors.Add(tipoprove);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<TipoProveedorListar> GetListTipoProveedores()
        {
            
            return _context.TipoProveedors
            .Select(x => new TipoProveedorListar
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Estado = x.IsActive == true ? "Inactiva" : "Activa",



            }).ToList();


        }

        public TipoProveedor GetTipoProveedor(int id, bool includerelated = true)
        {
            var tipo = _context.TipoProveedors.AsQueryable();
            if (includerelated)
            {
            }
            return tipo.Where(a => a.Id == id).SingleOrDefault();

        }

        public void UpdateTipoProveedor(TipoProveedor tipo, bool saveChanges = true)
        {
            _context.Entry(tipo).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<Banca> GetListBancos()
        {
            return _context.Banco
                .Where(a => a.IsActive == false)
                .OrderBy(a => a.Entidad)
                .ToList();
        }






    }






}
