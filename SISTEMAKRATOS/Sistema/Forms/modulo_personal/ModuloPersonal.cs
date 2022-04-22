using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Personal;
using CapaDatos.Models.Recursos_Humanos;
using CapaDatos.Repository;
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

namespace Sistema.Forms.modulo_personal
{
    public partial class ModuloPersonal : BaseContext
    {
        private IList<ListarPersonal> _listaPersonal = null;
        private PersonalRepository _personalRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        private ContratosRepository _contratosRepository = null;
        private PropiedadesRepository _propiedadesRepository = null;
        public List<Personal> _personalTochange = null;
        private RecursosRepository _recursosRepository = null;
        private List<string> listaHoras = null;
        private List<string> listaMinutos = null;
        public ModuloPersonal()
        {
            _personalTochange = new List<Personal>();
            _listaPersonal = new List<ListarPersonal>();
            _personalRepository = new PersonalRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            _contratosRepository = new ContratosRepository(_context);
            _propiedadesRepository = new PropiedadesRepository(_context);
            _recursosRepository = new RecursosRepository(_context);
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal(this);
        }

        private void ModuloPersonal_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal(this, false);
        }
        public void CargarDGV()
        {
            _listaPersonal = _personalRepository.GetListaPersonal(0, true, DateTime.Now, DateTime.Now, false, false, true);
            BindingSource source = new BindingSource();
            source.DataSource = _listaPersonal;
            DgvListPersonal.DataSource = typeof(List<>);
            DgvListPersonal.DataSource = source;
        }
        private void ModuloPersonal_Load(object sender, EventArgs e)
        {
           
            CargarSucursales();
            CargarSucursalesTraslado();
            CargarTipocontrato();
            CargarDGV();
            CargarHorario();
            CargarPuesto();
            CargarComboMotivoPase();
            CargarRetrasosTipos();
            CargarComboAusencia();
            CargarMinutos();
            CargarHora();
           // CargarDgvHhorarios();
    


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
               
            }
            comboHEntrada.SelectedIndex = 0;
            ComboHsalida.SelectedIndex = 0;
           
        }
        private void CargarSucursalesTraslado()
        {
            var sucursal = _sucursalesRepository.GetList();
            CbSucursales.ComboBox.DataSource = sucursal;
            CbSucursales.ComboBox.DisplayMember = "NombreSucursal";
            CbSucursales.ComboBox.ValueMember = "Id";
            CbSucursales.SelectedIndex = 0;
            CbSucursales.Invalidate();
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
        private void CargarPuesto()
        {
            var puestos = _propiedadesRepository.GetListPuestos();
            comboPuestos.DataSource = puestos;
            comboPuestos.DisplayMember = "Descripcion";
            comboPuestos.ValueMember = "Id";
            comboPuestos.Invalidate();



        }
        private void CargarTipocontrato()
        {
            var contratos = _contratosRepository.GetContratos();
            comboContrato.DataSource = contratos;
            comboContrato.DisplayMember = "Descripcion";
            comboContrato.ValueMember = "Id";
            comboContrato.Invalidate();

        }
        private void CargarHorario()
        {
            var horario = _propiedadesRepository.GetListHorarios();
            comboHorario.DataSource = horario;
            comboHorario.DisplayMember = "Periodo";
            comboHorario.ValueMember = "Id";
            comboHorario.Invalidate();



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
        private void CargarComboAusencia()
        {
            var tipos = _recursosRepository.GetlistAusencia();
            comboAustipoaus.DataSource = tipos;
            comboAustipoaus.DisplayMember = "Descripcion";
            comboAustipoaus.ValueMember = "Id";
            comboAustipoaus.SelectedIndex = 0;
            comboAustipoaus.Invalidate();
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
        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarDGV();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (DgvListPersonal.CurrentRow != null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el Cliente ?", "Eliminar cliente",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                var cliente = (CapaDatos.ListasPersonalizadas.ListarPersonal)DgvListPersonal.CurrentRow.DataBoundItem;
                var GetCliente = _personalRepository.Get(cliente.Id);
                GetCliente.IsActive = true;
                _personalRepository.Update(GetCliente);
                CargarDGV();
            }
        }

      

        private void CargarSucursales()        
        {
            var sucursal = _sucursalesRepository.GetList();
            comboSucursal.DataSource = sucursal;
            comboSucursal.DisplayMember = "NombreSucursal";
            comboSucursal.ValueMember = "Id";
            comboSucursal.SelectedIndex = 0;
            comboSucursal.Invalidate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GuardarPersonal();
        }
        private void GuardarPersonal()
        {
            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtdpi.Text) ||
                 string.IsNullOrEmpty(txttel1.Text))
            { KryptonMessageBox.Show("Campos Vacios, Todos son Obligatorios "); return; }

            var modeloProveedor = GetNewPersonal();
            if (!ModelState.IsValid(modeloProveedor)) { return; }
            _personalRepository.Add(modeloProveedor);

            KryptonMessageBox.Show("Personal Guardado!");


        }
        private Personal GetNewPersonal()
        {

            return new Personal()
            {
                Nombres = txtnombre.Text,
                Apellidos = txtapellido.Text,
                Direccion = txtdireccion.Text,
                Telefonos1 = txttel2.Text,
                IsActive = checkEstado.Checked,
                Telefonos2 = txttel2.Text,
                Telefonos3 = txttel3.Text,
                SucursalId = int.Parse(comboSucursal.SelectedValue.ToString()),
                ContratoId = int.Parse(comboContrato.SelectedValue.ToString()),
                HorarioId = int.Parse(comboHorario.SelectedValue.ToString()),
                PuestoId = int.Parse(comboPuestos.SelectedValue.ToString()),
                Nit = txtnit.Text,
                FechaIngreso = dtpingreso.Value,
                EstadoCivil = txtestadocivil.Text,
                Dpi = txtdpi.Text,
                Edad = int.Parse(txtedad.Text),
                Salario = decimal.Parse(txtsalario.Text),




            };

        }
        private Personal GetViewModel(Personal persona)
        {

            return persona;
        }
        private void GuardarTraslado()
        {

            foreach (var item in _personalTochange)
            {
                var personaObtener = _personalRepository.Get(item.Id);
                var Getpersonal = GetViewModel(personaObtener);
                if (!ModelState.IsValid(Getpersonal)) { return; }

                Getpersonal.SucursalId = int.Parse(comboSucursal.SelectedValue.ToString());
                _personalRepository.Update(Getpersonal);
            }
        }
        private void BtnTrasladar_Click(object sender, EventArgs e)
        {
            GuardarTraslado();
            
        }
        public void limpiar()
        {
            txtnombre.Text = "";
                txtapellido.Text = "";
            txtdireccion.Text = "";
            txttel2.Text = "";
            checkEstado.Checked = false;
            txttel2.Text = "";
            txttel3.Text = "";
            txtnit.Text = "";
            txtestadocivil.Text = "";
            txtdpi.Text = "";
            txtedad.Text = "";
            txtsalario.Text = "";
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();

        }
        public void EsconderAsignar()
        {
            combopermotivo.Enabled=false;
            FechaInicio.Enabled=false;
            FechaFinal.Enabled=false;
            comboHtipo.Enabled=false;
            comboatrasosTipo.Enabled=false;
            comboAustipoaus.Enabled=false;
            comboatrasosMinutos.Enabled=false;
        }
        public void EsconderAtrasos()
        {
            combopermotivo.Enabled = false;
            FechaInicio.Enabled = false;
            FechaFinal.Enabled = false;
            comboHtipo.Enabled = false;
            comboAustipoaus.Enabled = false;
            comboHEntrada.Enabled = false;
            ComboHsalida.Enabled = false;
        }
        public void EsconderPermisos()
        {
            FechaInicio.Enabled = false;
            FechaFinal.Enabled = false;
            comboHtipo.Enabled = false;
            comboatrasosTipo.Enabled = false;
            comboAustipoaus.Enabled = false;
            comboatrasosMinutos.Enabled = false;
        }
        private void TipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoOperacion.SelectedItem=="Asignar Horario")
            {
                EsconderAsignar();
                CargarDgvHhorarios();
            }
            if (TipoOperacion.SelectedItem == "Atrasos")
            {
                EsconderAtrasos();
            }
            if(TipoOperacion.SelectedItem == "Permisos")
            {
                EsconderPermisos();
            }
        }
        private void SeleccionAcciones(DataGridView datatgrid, List<Personal> personallista)
        {


            if (datatgrid.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            foreach (DataGridViewRow Rows in datatgrid.Rows)
            {
                var filasTotales = int.Parse(datatgrid.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[0].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var Id = int.Parse(Rows.Cells[1].Value.ToString());
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
        private HorarioE GetHorarioENuevo()
        {
            return new HorarioE()
            {
                //  IdHorario= Guid.NewGuid(),
                HoraEntrada = comboHEntrada.Text,
                HoraSalida = ComboHsalida.Text,
                Lunes = checklunes.Checked,
                Martes = checkmartes.Checked,
                Miercoles = checkmiercoles.Checked,
                Jueves = checkjueves.Checked,
                Viernes = checkviernes.Checked,
                Sabado = checksabado.Checked,
                Domingo = checkdomingo.Checked,
                Descripcion = txtHdescripcion.Text,

            };
        }
        private HorarioAsignado GetHorarioAsigNuevo()
        {
            return new HorarioAsignado()
            {
                FechaAsignacion = dtpHfecha.Value,
                CausaHorario = txtHdescripcion.Text,

            };
        }
        private Guid nuevo()
        {
            Guid nuevoguid;
            return nuevoguid = Guid.NewGuid();
        }
        private void guardarHorario()
        {

            foreach (var persona in _personalTochange)
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
        public void CargarDgvHhorarios()
        {
            var horarioslista = _recursosRepository.GetlistHorarioAsinados();
            BindingSource source = new BindingSource();
            source.DataSource = horarioslista;
            dgvHhorarios.DataSource = typeof(List<>);
            dgvHhorarios.DataSource = source;
            dgvHhorarios.AutoResizeColumns();
          //  dgvHhorarios.Columns[5].Visible = false;
            //dgvHhorarios.Columns[6].Visible = false;



        }
        
        private void GuardarAsignarHorario()
        {
            _personalTochange = new List<Personal>();
            SeleccionAcciones(DgvListPersonal, _personalTochange);
            guardarHorario();
            _personalTochange.Clear();
        }
        private Retraso GetRetrasoNuevo()
        {
            return new Retraso()
            {
                TipoRetrasoId = int.Parse(comboatrasosTipo.SelectedValue.ToString()),
                Fecha = dtpHfecha.Value,
                Minutos = comboatrasosMinutos.Text,
                Observacion = txtHdescripcion.Text,

            };
        }
        private void guardarRetrasos()
        {

            foreach (var persona in _personalTochange)
            {
                var modeloRetrasos = GetRetrasoNuevo();
                if (!ModelState.IsValid(modeloRetrasos)) { return; }
                modeloRetrasos.PersonalId = persona.Id;
                _recursosRepository.AddRetraso(modeloRetrasos);

            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
        }
        private void GuardarAtraso()
        {
            _personalTochange = new List<Personal>();
            SeleccionAcciones(DgvListPersonal, _personalTochange);
            GuardarAtraso();
            _personalTochange.Clear();
        }
        private PaseEmpleado GetPaseEmpleadoNuevo()
        {
            return new PaseEmpleado()
            {

                Fecha = dtpHfecha.Value,
                HoraEntrada = comboHEntrada.Text,
                HoraSalida = ComboHsalida.Text,
                Descripcion = txtHdescripcion.Text,
                MotivoPaseId = int.Parse(combopermotivo.SelectedValue.ToString())


            };
        }
        private void guardarPermisos()
        {

            foreach (var persona in _personalTochange)
            {
                var modeloPermisos = GetPaseEmpleadoNuevo();
                if (!ModelState.IsValid(modeloPermisos)) { return; }
                modeloPermisos.PersonalId = persona.Id;
                _recursosRepository.AddPaseEmpleado(modeloPermisos);

            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
        }
        private HorasExtras GetHorasExtrasNuevo()
        {
            return new HorasExtras()
            {
                Descripcion = txtHdescripcion.Text,
                Fecha = dtpHfecha.Value,
                HoraInicio = comboHEntrada.Text,
                HorarioFinal = ComboHsalida.Text,
                DiaCompleto = kryptonCheckBox1.Checked,

            };
        }
        private void guardarHorasExtras()
        {

            foreach (var persona in _personalTochange)
            {
                var modeloHoras = GetHorasExtrasNuevo();
                if (!ModelState.IsValid(modeloHoras)) { return; }
                modeloHoras.PersonalId = persona.Id;
                _recursosRepository.AddHorasExtras(modeloHoras);

            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
        }
        private EntradaSalida GetEntradaSalidaNuevo()
        {
            return new EntradaSalida()
            {

                Fecha = dtpHfecha.Value,
                Hora = comboHEntrada.Text,
               // TipoESId = int.Parse(comboEStipo.SelectedValue.ToString()),


            };
        }
        private void guardarEntradaSalidas()
        {

            foreach (var persona in _personalTochange)
            {
                var modeloESs = GetEntradaSalidaNuevo();
                if (!ModelState.IsValid(modeloESs)) { return; }
                modeloESs.PersonalId = persona.Id;
                _recursosRepository.AddEntradaSalida(modeloESs);

            }
            KryptonMessageBox.Show("Registro Guardado con éxito");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(TipoOperacion.SelectedItem=="Asignar Horario")
            {
                GuardarAsignarHorario();
                CargarDgvHhorarios();
            }
            if (TipoOperacion.SelectedItem == "Atrasos")
            {
                GuardarAtraso();
            }
            if (TipoOperacion.SelectedItem == "Permisos")
            {
                _personalTochange = new List<Personal>();
                SeleccionAcciones(DgvListPersonal, _personalTochange);
                guardarPermisos();
                _personalTochange.Clear();
            }
            if(TipoOperacion.SelectedItem=="Horas Extras")
            {
                _personalTochange = new List<Personal>();
                SeleccionAcciones(DgvListPersonal, _personalTochange);
                guardarHorasExtras();
                _personalTochange.Clear();
            }if(TipoOperacion.SelectedItem=="Control Entrada y Salida")
            {
                _personalTochange = new List<Personal>();
                SeleccionAcciones(DgvListPersonal, _personalTochange);
                guardarEntradaSalidas();
                _personalTochange.Clear();
            }
        }

        private void BtnEntradaSalida_Click(object sender, EventArgs e)
        {

        }

        private void DgvListPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var fila = DgvListPersonal.CurrentCell;
            if (fila.ColumnIndex == 0)
            {
                var row = DgvListPersonal.CurrentRow;
                if (row.Cells[0].Value != null)
                {
                    bool seleccion = Convert.ToBoolean(row.Cells[0].Value);
                    if (seleccion)
                    {
                        row.Cells[0].Value = false;
                    }
                    else
                    {
                        row.Cells[0].Value = true;
                    }
                }
            }
        }
    }
}
