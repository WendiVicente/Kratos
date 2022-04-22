using CapaDatos.Models.Recursos_Humanos;
using CapaDatos.Models.Sucursales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Personal
{
  public  class Personal
    {

        public Personal()
        {
            HorasExtras = new List<HorasExtras>();
            EntradaSalidas = new List<EntradaSalida>();
            HorarioAsignados = new List<HorarioAsignado>();
            Retrasos = new List<Retraso>();
            PaseEmpleados = new List<PaseEmpleado>();
            EmpleadoAusencias = new List<EmpleadoAusencia>();

          }
        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefonos1 { get; set; }
        public string Telefonos2 { get; set; }
        public string Telefonos3 { get; set; }
        public int Edad { get; set; }
        public string Dpi { get; set; }
        public string Nit { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool IsActive { get; set; }
        public int HorarioId { get; set; }
        public int ContratoId { get; set; }
        public int SucursalId { get; set; }
        public int PuestoId { get; set; }
        
       
       
        public TipoContrato Contrato { get; set; }
        public Horario Horario { get; set; }
        public Puesto Puesto { get; set; }

        public Sucursal Sucursal { get; set; }

        //horarios
         public ICollection<HorasExtras> HorasExtras { get; set; }
        public ICollection<EntradaSalida> EntradaSalidas { get; set; }
        public ICollection<HorarioAsignado> HorarioAsignados { get; set; }
        public ICollection<Retraso> Retrasos { get; set; }
        public ICollection<PaseEmpleado> PaseEmpleados { get; set; }
        public ICollection<EmpleadoAusencia> EmpleadoAusencias { get; set; }


    }
}
