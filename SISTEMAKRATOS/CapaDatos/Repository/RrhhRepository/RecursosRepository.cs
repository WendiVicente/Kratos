using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.RecursosHLista;
using CapaDatos.Models.Recursos_Humanos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.RrhhRepository
{
    public class RecursosRepository
    {
        private Context _context = null;

        public RecursosRepository(Context context)
        {
            _context = context;
        }

        public void AddRetraso(Retraso retraso, bool saveChanges = true)
        {
            _context.Retrasos.Add(retraso);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<ListarllegadasTarde> GetlistRetrasos()
        {
            var retrasoslista = _context.Retrasos.AsQueryable();

            return retrasoslista
                .Include(x=> x.Personal)
               
                .Select(x => new ListarllegadasTarde
                {
                    Id=x.Id,
                    Nombre=x.Personal.Nombres,
                    Apellido=x.Personal.Apellidos,
                    DPI= x.Personal.Dpi,
                    Departamento= x.Personal.Puesto.Departamento.Area,
                    Puesto= x.Personal.Puesto.Descripcion,
                    Fecha= x.Fecha,
                    Minutos=x.Minutos,
                    Observacion=x.Observacion,
                    TipoRetraso=x.TipoRetraso.Retraso


                }).ToList();
           
        }

        public Retraso GetRetraso(int id, bool includerelated = true)
        {
            var retrasos = _context.Retrasos.AsQueryable();
            if (includerelated)
            {
            }
            return retrasos.Where(a => a.Id == id).SingleOrDefault();

        }





       /// <summary>
       /// 
       /// </summary>
       /// <param name="retraso"></param>
       /// <param name="saveChanges"></param>
        public void AddTipoRetraso(TipoRetraso retraso, bool saveChanges = true)
        {
            _context.TipoRetrasos.Add(retraso);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<TipoRetraso> GetlistTiposRetrasos()
        {
            return _context.TipoRetrasos
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }



        public TipoRetraso GetTipoRetraso(int id, bool includerelated = true)
        {
            var retrasos = _context.TipoRetrasos.AsQueryable();
            if (includerelated)
            {
            }
            return retrasos.Where(a => a.Id == id).SingleOrDefault();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ausencia"></param>
        /// <param name="saveChanges"></param>
        public void AddAusencia(Ausencia ausencia, bool saveChanges = true)
        {
            _context.Ausencias.Add(ausencia);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<Ausencia> GetlistAusencia()
        {
            return _context.Ausencias
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }

        public IList<ListarAusencias> GetlistAusenciaRe() {
           
            var ausencias = _context.EmpleadoAusencias.AsQueryable();

            return ausencias
                .Include(x => x.Personal)
                .Select(x => new ListarAusencias
                {
                    Id = x.Id,
                    Nombre = x.Personal.Nombres,
                    Apellido = x.Personal.Apellidos,
                    DPI = x.Personal.Dpi,
                    Departamento = x.Personal.Puesto.Departamento.Area,
                    Puesto = x.Personal.Puesto.Descripcion,
                    FechaInicio= x.FechaInicio,
                    FechaFinal= x.FechaFinal,
                    Motivo= x.Motivo,


                }).ToList();

        }





        public Ausencia GetAusencia(int id, bool includerelated = true)
        {
            var ausencias = _context.Ausencias.AsQueryable();
            if (includerelated)
            {
            }
            return ausencias.Where(a => a.Id == id).SingleOrDefault();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empleadoAusencia"></param>
        /// <param name="saveChanges"></param>
        public void AddEmAusencia(EmpleadoAusencia empleadoAusencia, bool saveChanges = true)
        {
            _context.EmpleadoAusencias.Add(empleadoAusencia);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<EmpleadoAusencia> GetlistEmAusencia()
        {
            return _context.EmpleadoAusencias
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }

        public EmpleadoAusencia GetEmpleadoAusencia(int id, bool includerelated = true)
        {
            var empleadoAusencia = _context.EmpleadoAusencias.AsQueryable();
            if (includerelated)
            {
            }
            return empleadoAusencia.Where(a => a.Id == id).SingleOrDefault();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="horarioAsignado"></param>
        /// <param name="saveChanges"></param>
        public void AddHorarioAsignado(HorarioAsignado horarioAsignado, bool saveChanges = true)
        {
            _context.HorarioAsignados.Add(horarioAsignado);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<HorarioAsignado> GetlistHorarioAsinados()
        {
            return _context.HorarioAsignados
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }

        public HorarioAsignado GetHorarioAsignado(int id, bool includerelated = true)
        {
            var horarios = _context.HorarioAsignados.AsQueryable();
            if (includerelated)
            {
            }
            return horarios.Where(a => a.Id == id).SingleOrDefault();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoES"></param>
        /// <param name="saveChanges"></param>
        public void AddTipoES(TipoES tipoES, bool saveChanges = true)
        {
            _context.TipoEs.Add(tipoES);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<TipoES> GetlistTipoESs()
        {
            return _context.TipoEs
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }

        public TipoES GetTipoES(int id, bool includerelated = true)
        {
            var tipoEs = _context.TipoEs.AsQueryable();
            if (includerelated)
            {
            }
            return tipoEs.Where(a => a.Id == id).SingleOrDefault();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entradaSalida"></param>
        /// <param name="saveChanges"></param>
        public void AddEntradaSalida(EntradaSalida entradaSalida, bool saveChanges = true)
        {
            _context.EntradaSalidas.Add(entradaSalida);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<EntradaSalida> GetlistEntradaSalidas()
        {
            return _context.EntradaSalidas
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }

        public EntradaSalida GetEntradaSalida(int id, bool includerelated = true)
        {
            var entradaSalida = _context.EntradaSalidas.AsQueryable();
            if (includerelated)
            {
            }
            return entradaSalida.Where(a => a.Id == id).SingleOrDefault();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="motivoPase"></param>
        /// <param name="saveChanges"></param>
        public void AddMotivoPase(MotivoPase motivoPase, bool saveChanges = true)
        {
            _context.MotivoPases.Add(motivoPase);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<MotivoPase> GetlistMotivoPase()
        {
            return _context.MotivoPases
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }

        public MotivoPase GetMotivoPase(int id, bool includerelated = true)
        {
            var motivoPases = _context.MotivoPases.AsQueryable();
            if (includerelated)
            {
            }
            return motivoPases.Where(a => a.Id == id).SingleOrDefault();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paseEmpleado"></param>
        /// <param name="saveChanges"></param>
        public void AddPaseEmpleado(PaseEmpleado paseEmpleado, bool saveChanges = true)
        {
            _context.PaseEmpleados.Add(paseEmpleado);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<PaseEmpleado> GetlistPaseEmpleado()
        {
            return _context.PaseEmpleados
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }

        public PaseEmpleado GetPaseEmpleado(int id, bool includerelated = true)
        {
            var paseEmpleados = _context.PaseEmpleados.AsQueryable();
            if (includerelated)
            {
            }
            return paseEmpleados.Where(a => a.Id == id).SingleOrDefault();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="horasExtras"></param>
        /// <param name="saveChanges"></param>
        public void AddHorasExtras(HorasExtras horasExtras, bool saveChanges = true)
        {
            _context.HorasExtras.Add(horasExtras);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<HorasExtras> GetlistHorasExtras()
        {
            return _context.HorasExtras
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }
        public IList<ListarHorasExtra> GetlistHorasExtrase()
        {

            var ausencias = _context.HorasExtras.AsQueryable();

            return ausencias
                .Include(x => x.Personal)
                .Select(x => new ListarHorasExtra
                {
                    Id = x.Id,
                    Nombre = x.Personal.Nombres,
                    Apellido = x.Personal.Apellidos,
                    DPI = x.Personal.Dpi,
                    Departamento = x.Personal.Puesto.Departamento.Area,
                    Puesto = x.Personal.Puesto.Descripcion,
                    Descripcion = x.Descripcion,
                    DiaCompleto = x.DiaCompleto == true ? "Sí":"No",
                    Fecha= x.Fecha,
                    HorarioFinal= x.HorarioFinal,
                    HoraInicio= x.HoraInicio

                }).ToList();

        }


        public HorasExtras GetHorasExtra(int id, bool includerelated = true)
        {
            var horasExtras = _context.HorasExtras.AsQueryable();
            if (includerelated)
            {
            }
            return horasExtras.Where(a => a.Id == id).SingleOrDefault();

        }

        //
        public void AddHorarioE(HorarioE horarioE, bool saveChanges = true)
        {
            _context.HorarioEs.Add(horarioE);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<HorarioE> GetlistHorarioE()
        {
            return _context.HorarioEs
                // .Where(a => a.IsActive == false)
                //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }

        public HorarioE GetHorarioE(Guid id, bool includerelated = true)
        {
            var horario = _context.HorarioEs.AsQueryable();
            if (includerelated)
            {
            }
            return horario.Where(a => a.IdHorario == id).SingleOrDefault();

        }

    }
}
