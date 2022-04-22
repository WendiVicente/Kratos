using CapaDatos.Models.Personal;
using CapaDatos.Models.Recursos_Humanos;
using CapaDatos.Repository.PersonalRepository;
using CapaDatos.Repository.RrhhRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_RRHH
{
    public partial class RecursosHumanos : BaseContext
    {
        private RecursosRepository _recursosRepository = null;
        private PersonalRepository _personalRepository = null;
        private List<Personal> listatoSend = null;
        private List<Personal> listaPersonalRetrasos = null;
        private List<Personal> listaPersonalPermisos = null;
        private List<Personal> listaPersonalAusencias = null;
        private List<Personal> listaPersonalHorasExtras = null;
        private List<Personal> listaPersonalcontrolES = null;
        private List<string> listaHoras = null;
        private List<string> listaMinutos = null;

        public RecursosHumanos()
        {
            _recursosRepository = new RecursosRepository(_context);
            _personalRepository = new PersonalRepository(_context);
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void RecursosHumanos_Load(object sender, EventArgs e)
        {
            CargarHora();
            CargarDgvHPersonal();
            CargarDgvHhorarios();
            CargarMinutos();
            CargarRetrasosTipos();
            CargarDgvPermisosPersonal();
            CargarDgvAtrasosPersonal();
            CargarComboMotivoPase();
            CargarDgvAusencias();
            CargarDgvControlEnSAl();
            CargarDgvHorasExtras();
            CargarComboEntradaSalida();
            CargarComboAusencia();

        }

       
        private HorarioAsignado GetHorarioAsigNuevo()
        {
            return new HorarioAsignado()
            {
                FechaAsignacion = dtpHfecha.Value,
                CausaHorario= txtHdescripcion.Text,
               
            };
        }
        private HorarioE GetHorarioENuevo()
        {
            return new HorarioE()
            {
              //  IdHorario= Guid.NewGuid(),
               HoraEntrada= comboHEntrada.Text,
               HoraSalida= ComboHsalida.Text,
               Lunes = checklunes.Checked,
                 Martes = checkmartes.Checked,
                Miercoles = checkmiercoles.Checked,
                Jueves = checkjueves.Checked,
                Viernes = checkviernes.Checked,
                Sabado = checksabado.Checked,
                Domingo = checkdomingo.Checked,
                Descripcion= txtHdescripcion.Text,

            };
        }
        private Retraso GetRetrasoNuevo()
        {
            return new Retraso()
            {
                TipoRetrasoId = int.Parse(comboatrasosTipo.SelectedValue.ToString()),
                Fecha = dtpatrasosFecha.Value,
                Minutos = comboatrasosMinutos.Text,
                Observacion= txtatrasosDescrip.Text,

            };
        }
        private PaseEmpleado GetPaseEmpleadoNuevo()
        {
            return new PaseEmpleado()
            {

                Fecha = dtpatrasosFecha.Value,
                HoraEntrada = comboperHoraEntrada.Text,
                HoraSalida= comboPerHoraSalida.Text,
                Descripcion= txtausDescrip.Text,
                MotivoPaseId= int.Parse(combopermotivo.SelectedValue.ToString())


            };
        }
        private EmpleadoAusencia GetEmpleadoAusenciaNuevo()
        {
            return new EmpleadoAusencia()
            {
                AusenciaId=int.Parse(comboAustipoaus.SelectedValue.ToString()),
                Motivo= txtausDescrip.Text,
                FechaFinal= dtpausFechafinal.Value,
                FechaInicio= dtpausfechaInicio.Value,
                
            };
        }
        private HorasExtras GetHorasExtrasNuevo()
        {
            return new HorasExtras()
            {
               Descripcion= txtxtrasdescrip.Text,
               Fecha= dtpxtrasfecha.Value,
               HoraInicio= comboxtrasinicio.Text,
               HorarioFinal= comboxtrasfinal.Text,
               DiaCompleto= checkxtrasTodoeldia.Checked,
               
            };
        }

        private EntradaSalida GetEntradaSalidaNuevo()
        {
            return new EntradaSalida()
            {
                
                Fecha = dtpESfecha.Value,
                Hora = comboEShoraentrada.Text,
                TipoESId= int.Parse(comboEStipo.SelectedValue.ToString()),
               

            };
        }
        private void guardarHorario()
        {
            
            foreach (var persona in listatoSend)
            {
                var modeloHorarioe = GetHorarioENuevo();
                var modeloHorarioAsig = GetHorarioAsigNuevo();
                if (!ModelState.IsValid(modeloHorarioe)) { return; }
                if (!ModelState.IsValid(modeloHorarioAsig)) { return; }
                modeloHorarioe.IdHorario = nuevo();
                modeloHorarioAsig.HorarioEId = modeloHorarioe.IdHorario;
                modeloHorarioAsig.PersonalId = persona.Id;
                _recursosRepository.AddHorarioE(modeloHorarioe);
                _recursosRepository.AddHorarioAsignado(modeloHorarioAsig);
                //modeloHorarioe.IdHorario = Guid.NewGuid();
            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
            CargarDgvHhorarios();
            limpiar();
           
        }
        // guardar retrasos
        private void guardarRetrasos()
        {

            foreach (var persona in listaPersonalRetrasos)
            {
                var modeloRetrasos = GetRetrasoNuevo();
                if (!ModelState.IsValid(modeloRetrasos)) { return; }
                modeloRetrasos.PersonalId = persona.Id;
                _recursosRepository.AddRetraso(modeloRetrasos);
                
            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
        }
        private void guardarPermisos()
        {

            foreach (var persona in listaPersonalPermisos)
            {
                var modeloPermisos = GetPaseEmpleadoNuevo();
                if (!ModelState.IsValid(modeloPermisos)) { return; }
                modeloPermisos.PersonalId = persona.Id;
                _recursosRepository.AddPaseEmpleado(modeloPermisos);

            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
        }

        //ausencia
        private void guardarAusencias()
        {

            foreach (var persona in listaPersonalAusencias)
            {
                var modeloAusencias = GetEmpleadoAusenciaNuevo();
                if (!ModelState.IsValid(modeloAusencias)) { return; }
                modeloAusencias.PersonalId = persona.Id;
                _recursosRepository.AddEmAusencia(modeloAusencias);

            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
        }

        //horas extras
        private void guardarHorasExtras()
        {

            foreach (var persona in listaPersonalHorasExtras)
            {
                var modeloHoras = GetHorasExtrasNuevo();
                if (!ModelState.IsValid(modeloHoras)) { return; }
                modeloHoras.PersonalId = persona.Id;
                _recursosRepository.AddHorasExtras(modeloHoras);

            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
        }
        private void guardarEntradaSalidas()
        {

            foreach (var persona in listaPersonalcontrolES)
            {
                var modeloESs = GetEntradaSalidaNuevo();
                if (!ModelState.IsValid(modeloESs)) { return; }
                modeloESs.PersonalId = persona.Id;
                _recursosRepository.AddEntradaSalida(modeloESs);

            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
        }





        private Guid nuevo()
        {
            Guid nuevoguid;
            return   nuevoguid = Guid.NewGuid();
        }

        private void limpiar()
        {

            txtHdescripcion.Text = "";
            checkboxFalse();
            checkHtodos.Checked = false;
        }

        private void SeleccionAcciones(DataGridView datatgrid,List<Personal> personallista)
        {
           
          
            if (datatgrid.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            foreach (DataGridViewRow Rows in datatgrid.Rows)
            {
                var filasTotales = int.Parse(datatgrid.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[17].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var Id = int.Parse(Rows.Cells[0].Value.ToString());
                    var PersonalObtenido = _personalRepository.Get(Id);

                    personallista.Add(PersonalObtenido);
                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Empleado, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }

          
        }



        private void CargarHora()
        {
            string[] Horas = {
                "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00",
                "08:00" ,"09:00","10:00","11:00","12:00",
                "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00",
                "20:00" ,"21:00","22:00","23:00","24:00",
            };
            listaHoras = new List<string>(Horas);
            foreach (var item in listaHoras)
            {
                comboHEntrada.Items.Add(item);
                ComboHsalida.Items.Add(item);
                comboperHoraEntrada.Items.Add(item);
                comboPerHoraSalida.Items.Add(item);
                comboxtrasfinal.Items.Add(item);
                comboxtrasinicio.Items.Add(item);
                comboEShoraentrada.Items.Add(item);
            }
            comboHEntrada.SelectedIndex = 0;
            ComboHsalida.SelectedIndex = 0;
            comboperHoraEntrada.SelectedIndex = 0;
            comboPerHoraSalida.SelectedIndex = 0;
            comboxtrasfinal.SelectedIndex = 0;
            comboxtrasinicio.SelectedIndex = 0;
            comboEShoraentrada.SelectedIndex = 0;

        }

        private void CargarMinutos()
        {
            string[] Minutos = {
                "05", "10", "15", "20", "25", "30", "35",
                "40" ,"45","50","55","60",
                "1:05", "1:10", "1:15", "1:20", "1:25", "1:30", "1:35",
                "1:40" ,"1:45","1:50","1:55","2:00",
            };

            listaMinutos = new List<string>(Minutos);

            foreach (var item in listaMinutos)
            {
                comboatrasosMinutos.Items.Add(item);
            
            }
            comboatrasosMinutos.SelectedIndex = 0;

        }
        private void CargarRetrasosTipos()
        {
            var sucursal = _recursosRepository.GetlistTiposRetrasos();
            comboatrasosTipo.DataSource = sucursal;
            comboatrasosTipo.DisplayMember = "Retraso";
            comboatrasosTipo.ValueMember = "Id";
            comboatrasosTipo.SelectedIndex = 0;
            comboatrasosTipo.Invalidate();
        }

        private void CargarComboMotivoPase()
        {
            var sucursal = _recursosRepository.GetlistMotivoPase();
            combopermotivo.DataSource = sucursal;
            combopermotivo.DisplayMember = "Motivo";
            combopermotivo.ValueMember = "Id";
            combopermotivo.SelectedIndex = 0;
            combopermotivo.Invalidate();
        }
        private void CargarComboEntradaSalida()
        {
            var tipos = _recursosRepository.GetlistTipoESs();
            comboEStipo.DataSource = tipos;
            comboEStipo.DisplayMember = "Tipo";
            comboEStipo.ValueMember = "Id";
            comboEStipo.SelectedIndex = 0;
            comboEStipo.Invalidate();
        }
        private void CargarComboAusencia()
        {
            var tipos = _recursosRepository.GetlistAusencia();
            comboAustipoaus.DataSource = tipos;
            comboAustipoaus.DisplayMember = "Descripcion";
            comboAustipoaus.ValueMember = "Id";
            comboAustipoaus.SelectedIndex = 0;
            comboAustipoaus.Invalidate();
        }

        public void CargarDgvHPersonal()
        {
            var listarpersonal = _personalRepository.GetListaPersonal(0,true,DateTime.Now,DateTime.Now,false,false,true);
            BindingSource source = new BindingSource();
            source.DataSource = listarpersonal;
            dgvHpersonal.DataSource = typeof(List<>);
            dgvHpersonal.DataSource = source;
            dgvHpersonal.AutoResizeColumns();
            dgvHpersonal.Columns[0].Visible = false;
            for (int i = 4; i < 17; i++)
            {
                dgvHpersonal.Columns[i].Visible = false;
            }
            dgvHpersonal.Columns[7].Visible = true;
        }

        //atrasos
       
        public void CargarDgvAtrasosPersonal()
        {
            var listarpersonal = _personalRepository.GetListaPersonal(0, true, DateTime.Now, DateTime.Now, false, false, true);
            BindingSource source = new BindingSource();
            source.DataSource = listarpersonal;
            dgvatrasosPersonal.DataSource = typeof(List<>);
            dgvatrasosPersonal.DataSource = source;
            dgvatrasosPersonal.AutoResizeColumns();
            dgvatrasosPersonal.Columns[0].Visible = false;
            for (int i = 4; i < 17; i++)
            {
                dgvatrasosPersonal.Columns[i].Visible = false;
            }
            dgvatrasosPersonal.Columns[7].Visible = true;
        }
        public void CargarDgvPermisosPersonal()
        {
            var listarpersonal = _personalRepository.GetListaPersonal(0, true, DateTime.Now, DateTime.Now, false, false, true);
            BindingSource source = new BindingSource();
            source.DataSource = listarpersonal;
            dgvPPersonal.DataSource = typeof(List<>);
            dgvPPersonal.DataSource = source;
            dgvPPersonal.AutoResizeColumns();
            dgvPPersonal.Columns[0].Visible = false;
            for (int i = 4; i < 17; i++)
            {
                dgvPPersonal.Columns[i].Visible = false;
            }
            dgvPPersonal.Columns[7].Visible = true;
        }
        public void CargarDgvAusencias()
        {
            var listarpersonal = _personalRepository.GetListaPersonal(0, true, DateTime.Now, DateTime.Now, false, false, true);
            BindingSource source = new BindingSource();
            source.DataSource = listarpersonal;
            dgvAunPersonal.DataSource = typeof(List<>);
            dgvAunPersonal.DataSource = source;
            dgvAunPersonal.AutoResizeColumns();
            dgvAunPersonal.Columns[0].Visible = false;
            for (int i = 4; i < 17; i++)
            {
                dgvAunPersonal.Columns[i].Visible = false;
            }
            dgvAunPersonal.Columns[7].Visible = true;
        }
        public void CargarDgvHorasExtras()
        {
            var listarpersonal = _personalRepository.GetListaPersonal(0, true, DateTime.Now, DateTime.Now, false, false, true);
            BindingSource source = new BindingSource();
            source.DataSource = listarpersonal;
            dgvxtraspersonal.DataSource = typeof(List<>);
            dgvxtraspersonal.DataSource = source;
            dgvxtraspersonal.AutoResizeColumns();
            dgvxtraspersonal.Columns[0].Visible = false;
            for (int i = 4; i < 17; i++)
            {
                dgvxtraspersonal.Columns[i].Visible = false;
            }
            dgvxtraspersonal.Columns[7].Visible = true;
        }
        
        public void CargarDgvControlEnSAl()
        {
            var listarpersonal = _personalRepository.GetListaPersonal(0, true, DateTime.Now, DateTime.Now, false, false, true);
            BindingSource source = new BindingSource();
            source.DataSource = listarpersonal;
            dgvEntradaSalida.DataSource = typeof(List<>);
            dgvEntradaSalida.DataSource = source;
            dgvEntradaSalida.AutoResizeColumns();
            dgvEntradaSalida.Columns[0].Visible = false;
            for (int i = 4; i < 17; i++)
            {
                dgvEntradaSalida.Columns[i].Visible = false;
            }
            dgvEntradaSalida.Columns[7].Visible = true;
        }


        public void CargarDgvHhorarios()
        {
            var horarioslista = _recursosRepository.GetlistHorarioAsinados();
                BindingSource source = new BindingSource();
            source.DataSource = horarioslista;
            dgvHhorarios.DataSource = typeof(List<>);
            dgvHhorarios.DataSource = source;
            dgvHhorarios.AutoResizeColumns();
            dgvHhorarios.Columns[5].Visible = false;
            dgvHhorarios.Columns[6].Visible = false;



        }

        private void checkHtodos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHtodos.Checked == true)
            {
                checkboxTrue();
            }
            else
            {
                checkboxFalse();
            }
        }

        private void checkboxTrue()
        {
            checklunes.Checked = true;
            checkmartes.Checked = true;
            checkmiercoles.Checked = true;
            checkjueves.Checked = true;
            checkviernes.Checked = true;
            checksabado.Checked = true;
            checkdomingo.Checked = true;
        }
        private void checkboxFalse()
        {
            checklunes.Checked = false;
            checkmartes.Checked = false;
            checkmiercoles.Checked = false;
            checkjueves.Checked = false;
            checkviernes.Checked = false;
            checksabado.Checked = false;
            checkdomingo.Checked = false;
        }



        private void btnHguardar_Click(object sender, EventArgs e)
        {
            listatoSend = new List<Personal>();
            SeleccionAcciones(dgvHpersonal, listatoSend);
            guardarHorario();
            listatoSend.Clear();
        }

        private void btnatrasosGuardar_Click(object sender, EventArgs e)
        {
            listaPersonalRetrasos = new List<Personal>();
            SeleccionAcciones(dgvatrasosPersonal, listaPersonalRetrasos);
            guardarRetrasos();
            listaPersonalRetrasos.Clear();
        }

        private void btnperGuardar_Click(object sender, EventArgs e)
        {
            listaPersonalPermisos = new List<Personal>();
            SeleccionAcciones(dgvPPersonal, listaPersonalPermisos);
            guardarPermisos();
            listaPersonalPermisos.Clear();
        }

        private void btnausenGuardar_Click(object sender, EventArgs e)
        {
            listaPersonalAusencias = new List<Personal>();
            SeleccionAcciones(dgvAunPersonal, listaPersonalAusencias);
            guardarAusencias();
            listaPersonalAusencias.Clear();
        }

        private void btnxtrasGuardar_Click(object sender, EventArgs e)
        {
            listaPersonalHorasExtras = new List<Personal>();
            SeleccionAcciones(dgvxtraspersonal, listaPersonalHorasExtras);
            guardarHorasExtras();
            listaPersonalHorasExtras.Clear();
        }

        private void btnESGuardar_Click(object sender, EventArgs e)
        {

            listaPersonalcontrolES = new List<Personal>();
            SeleccionAcciones(dgvEntradaSalida, listaPersonalcontrolES);
            guardarEntradaSalidas();
            listaPersonalcontrolES.Clear();


        }
    }
}
