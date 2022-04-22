using CapaDatos.ListasPersonalizadas.PropiedadesLista;
using CapaDatos.Models.Personal;
using CapaDatos.Repository.PersonalRepository;
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
    public partial class ConfiguracionPersonal : BaseContext
    {
        PropiedadesRepository _propiedadesRepository = null;
        int estadoDepto = 0;
        int estadoHorario = 0;
        int estadoContrato = 0;
        int estadoPuesto = 0;

        public ConfiguracionPersonal()
        {
            _propiedadesRepository = new PropiedadesRepository(_context);
            InitializeComponent();
        }

        private void ConfiguracionPersonal_Load(object sender, EventArgs e)
        {
            RefrescarDataGridDeptos();
            RefrescarDataGridHorarios();
            RefrescarDataGridPuestos();
            RefrescarDataGridTipocontratos();
            cargarDeptosCombo();
           
        }
        public void RefrescarDataGridDeptos(bool LoadNewContext = true)
        {
            var listarDepto = _propiedadesRepository.GetListDepartamentos();
            BindingSource source = new BindingSource();
            source.DataSource = listarDepto;
            dgvListaDepto.DataSource = typeof(List<>);
            dgvListaDepto.DataSource = source;
        }
        public void RefrescarDataGridHorarios(bool LoadNewContext = true)
        {
            var listarhorarios = _propiedadesRepository.GetListHorarios();
            BindingSource source = new BindingSource();
            source.DataSource = listarhorarios;
            dgvlistaHorario.DataSource = typeof(List<>);
            dgvlistaHorario.DataSource = source;
        }
        public void RefrescarDataGridPuestos(bool LoadNewContext = true)
        {
            var listarPuestos = _propiedadesRepository.GetListPuestos();
            BindingSource source = new BindingSource();
            source.DataSource = listarPuestos;
            dgvlistarPuestos.DataSource = typeof(List<>);
            dgvlistarPuestos.DataSource = source;
        }
        public void RefrescarDataGridTipocontratos(bool LoadNewContext = true)
        {
            var listarTiposContratos = _propiedadesRepository.GetListContratos();
            BindingSource source = new BindingSource();
            source.DataSource = listarTiposContratos;
            dgvListarContrato.DataSource = typeof(List<>);
            dgvListarContrato.DataSource = source;
        }

        private void cargarDeptosCombo()
        {
            var Deptos = _propiedadesRepository.GetListDepartamentos();

            comboDepartamentos.DataSource = Deptos;
            comboDepartamentos.DisplayMember = "Area";
            comboDepartamentos.ValueMember = "Id";
            comboDepartamentos.Text = "Seleccione una área"; // esto no jalo? no me jalo
            //comboDepartamentos.SelectedIndex = 0;
            comboDepartamentos.Invalidate();

        }

        // nuevo y actualizacion de Departamentos
        private Departamento GetDepartamentoEdit(Departamento depto)
        {
            depto.Area = txtDescripDepto.Text;
            depto.IsActive = checkestadoDepto.Checked;
            return depto;
        }
        private Departamento GetDeptoNuevo()
        {
            return new Departamento()
            {
                Area = txtDescripDepto.Text,
                IsActive = checkestadoDepto.Checked
            };
        }
        //fin 
        // nuevo y actualizacion de Horario
        private Horario GetHorarioEdit(Horario horario)
        {
            horario.Periodo = txtDescripcionHorario.Text;
            horario.IsActive = checkEstadoHorario.Checked;
            return horario;
        }
        private Horario GetHorarioNuevo()
        {
            return new Horario()
            {
                Periodo = txtDescripcionHorario.Text,
                IsActive = checkEstadoHorario.Checked
            };
        }
        //fin 
        // nuevo y actualizacion de Horario
        private Puesto GetPuestoEdit(Puesto puesto)
        {
            puesto.Descripcion = txtDescripcionPuesto.Text;
            puesto.IsActive = checkEstadoPuesto.Checked;
            puesto.DepartamentoId = int.Parse(comboDepartamentos.SelectedValue.ToString());
            return puesto;
        }
        private Puesto GetPuestoNuevo()
        {
            return new Puesto()
            {
                DepartamentoId = int.Parse(comboDepartamentos.SelectedValue.ToString()),
                Descripcion = txtDescripcionPuesto.Text,
                IsActive = checkEstadoPuesto.Checked
                
            };
        }
        //fin 
        // nuevo y actualizacion de Horario
        private TipoContrato GetTipoContratoEdit(TipoContrato contrato)
        {
            contrato.Descripcion = txtDescripcionContrato.Text;
            contrato.IsActive = checkEstadoContrato.Checked;
            return contrato;
        }
        private TipoContrato GetTipoContratoNuevo()
        {
            return new TipoContrato()
            {
                Descripcion = txtDescripcionContrato.Text,
                IsActive = checkEstadoContrato.Checked
            };
        }
        //fin 

        //guardar Departamentos
        private void guardarDepto()
        {
            if (estadoDepto == 0)
            {
                var modeloDepto = GetDeptoNuevo();
                if (String.IsNullOrEmpty(txtDescripDepto.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Departamento"); return; }
                if (!ModelState.IsValid(modeloDepto)) { return; }

                _propiedadesRepository.AddDepartamento(modeloDepto);

                RefrescarDataGridDeptos(true);
            }
        }
        // guardar horario
        private void guardarHorario()
        {
            if (estadoHorario == 0)
            {
                var modeloHorario = GetHorarioNuevo();
                if (String.IsNullOrEmpty(txtDescripcionHorario.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Horario"); return; }
                if (!ModelState.IsValid(modeloHorario)) { return; }

                _propiedadesRepository.AddHorario(modeloHorario);

                RefrescarDataGridHorarios(true);
            }
        }
        // guardar Puestos
        private void guardarPuestos()
        {
            if (estadoPuesto == 0)
            {
                var modeloPuesto = GetPuestoNuevo();
                if (String.IsNullOrEmpty(txtDescripcionPuesto.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un puesto"); return; }
                if (!ModelState.IsValid(modeloPuesto)) { return; }

                _propiedadesRepository.AddPuesto(modeloPuesto);

                RefrescarDataGridPuestos(true);
            }
        }
        private void guardarContrato()
        {
            if (estadoContrato == 0)
            {
                var modeloContrato = GetTipoContratoNuevo();
                if (String.IsNullOrEmpty(txtDescripcionPuesto.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Texto"); return; }
                if (!ModelState.IsValid(modeloContrato)) { return; }
                _propiedadesRepository.AddContrato(modeloContrato);
                RefrescarDataGridTipocontratos(true);
            }
        }

        private void btnGuardarDepto_Click(object sender, EventArgs e)
        {
            guardarDepto();
            LimpiarTxtDepto();
        }

        private void btnGuardarHorario_Click(object sender, EventArgs e)
        {
            guardarHorario();
            LimpiarTxtHorario();
        }

        private void btnguardarPuesto_Click(object sender, EventArgs e)
        {
            guardarPuestos();
            LimpiarTxtPuesto();

        }

        private void btnGuardarContrato_Click(object sender, EventArgs e)
        {
            guardarContrato();
            LimpiarTxtContrato();
        }

        private void btnActualizardepto_Click(object sender, EventArgs e)
        {
            if (dgvListaDepto.CurrentRow == null)
            {
                return;
            }

            if (estadoDepto == 1)
            {
                var row = (ListarDepartamentos)dgvListaDepto.CurrentRow.DataBoundItem;
                var Getdepto = _propiedadesRepository.GetDepartamento(row.Id);

                var modeloEditar = GetDepartamentoEdit(Getdepto);
                if (String.IsNullOrEmpty(txtDescripDepto.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un departmento"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }
                _propiedadesRepository.UpdateDepartamento(modeloEditar);
                RefrescarDataGridDeptos(true);
                LimpiarTxtDepto();
            }
        }

        private void btnUpdateHorario_Click(object sender, EventArgs e)
        {
            if (dgvlistaHorario.CurrentRow == null)
            {
                return;
            }

            if (estadoHorario == 1)
            {
                var row = (ListarHorarios)dgvlistaHorario.CurrentRow.DataBoundItem;
                var GetHorario = _propiedadesRepository.GetHorario(row.Id);

                var modeloEditar = GetHorarioEdit(GetHorario);
                if (String.IsNullOrEmpty(txtDescripcionHorario.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Horario"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }
                _propiedadesRepository.UpdateHorario(modeloEditar);
                RefrescarDataGridDeptos(true);
                LimpiarTxtHorario();
            }

        }

        private void btnUpdatePuesto_Click(object sender, EventArgs e)
        {
            if (dgvlistarPuestos.CurrentRow == null)
            {
                return;
            }

            if (estadoPuesto == 1)
            {
                var row = (ListarPuestos)dgvlistarPuestos.CurrentRow.DataBoundItem;
                var GetObjeto = _propiedadesRepository.GetPuesto(row.Id);

                var modeloEditar = GetPuestoEdit(GetObjeto);
                if (String.IsNullOrEmpty(txtDescripcionPuesto.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Puesto"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }
                _propiedadesRepository.UpdatePuesto(modeloEditar);
                RefrescarDataGridPuestos(true);
                LimpiarTxtPuesto();
            }
        }

        private void btnUpdateContrato_Click(object sender, EventArgs e)
        {
            if (dgvListarContrato.CurrentRow == null)
            {
                return;
            }

            if (estadoContrato == 1)
            {
                var row = (ListarContratos)dgvListarContrato.CurrentRow.DataBoundItem;
                var GetObjeto = _propiedadesRepository.GetContrato(row.Id);

                var modeloEditar = GetTipoContratoEdit(GetObjeto);
                if (String.IsNullOrEmpty(txtDescripcionContrato.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Tipo de Contrato"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }
                _propiedadesRepository.UpdateContrato(modeloEditar);
                RefrescarDataGridTipocontratos(true);
                LimpiarTxtContrato();
            }
        }

        private void LimpiarTxtDepto()
        {
            txtCodDepto.Text = "";
            txtDescripDepto.Text = "";
            checkestadoDepto.Checked = false;
        }
        private void LimpiarTxtHorario()
        {
            txtCodigoHorario.Text = "";
            txtDescripcionHorario.Text = "";
            checkEstadoHorario.Checked = false;
        }
        private void LimpiarTxtPuesto()
        {
            txtcodigoPuesto.Text = "";
            txtDescripcionPuesto.Text = "";
            checkEstadoPuesto.Checked = false;
        }
        private void LimpiarTxtContrato()
        {
            txtCodigoContrato.Text = "";
            txtDescripcionContrato.Text = "";
            checkEstadoContrato.Checked = false;
        }



        private void limpiarDepto_Click(object sender, EventArgs e)
        {
            LimpiarTxtDepto();
            estadoDepto = 0;
        }

        private void limpiarHorario_Click(object sender, EventArgs e)
        {
            LimpiarTxtHorario();
            estadoHorario = 0;
        }

        private void limpiarPuesto_Click(object sender, EventArgs e)
        {
            LimpiarTxtPuesto();
            estadoPuesto = 0;
        }

        private void limpiarContrato_Click(object sender, EventArgs e)
        {
            LimpiarTxtContrato();
            estadoContrato = 0;
        }

        private void dgvListaDepto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBoxDepto(dgvListaDepto.CurrentRow.Index);
            limpiarDepto.Visible = true;
            estadoDepto = 1;
        }

        private void dgvlistaHorario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBoxHorario(dgvlistaHorario.CurrentRow.Index);
            limpiarHorario.Visible = true;
            estadoHorario = 1;

        }

        private void dgvlistarPuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBoxPuesto(dgvlistarPuestos.CurrentRow.Index);
            limpiarPuesto.Visible = true;
            estadoPuesto = 1;
        }

        private void dgvListarContrato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBoxContrato(dgvListarContrato.CurrentRow.Index);
            limpiarContrato.Visible = true;
            estadoContrato = 1;
        }

        public void LlenarTextBoxDepto(int IndiceDGV)
        {
            txtCodDepto.Text = dgvListaDepto.Rows[IndiceDGV].Cells[0].Value.ToString();
            txtDescripDepto.Text = dgvListaDepto.Rows[IndiceDGV].Cells[1].Value.ToString(); //tipo de cliente

            if (dgvListaDepto.Rows[IndiceDGV].Cells[2].Value.ToString() == "Activa")
            {
                checkestadoDepto.Checked = false;

            }
            else
            {
                checkestadoDepto.Checked = true;
            }
        }
        public void LlenarTextBoxHorario(int IndiceDGV)
        {
            txtCodigoHorario.Text = dgvlistaHorario.Rows[IndiceDGV].Cells[0].Value.ToString();
            txtDescripcionHorario.Text = dgvlistaHorario.Rows[IndiceDGV].Cells[1].Value.ToString(); //tipo de cliente

            if (dgvlistaHorario.Rows[IndiceDGV].Cells[2].Value.ToString() == "Activa")
            {
                checkEstadoHorario.Checked = false;

            }
            else
            {
                checkEstadoHorario.Checked = true;
            }
        }
        public void LlenarTextBoxPuesto(int IndiceDGV)
        {
            txtcodigoPuesto.Text = dgvlistarPuestos.Rows[IndiceDGV].Cells[0].Value.ToString();
            txtDescripcionPuesto.Text = dgvlistarPuestos.Rows[IndiceDGV].Cells[1].Value.ToString(); //tipo de cliente

            if (dgvlistarPuestos.Rows[IndiceDGV].Cells[2].Value.ToString() == "Activa")
            {
                checkEstadoPuesto.Checked = false;

            }
            else
            {
                checkEstadoPuesto.Checked = true;
            }
        }
        public void LlenarTextBoxContrato(int IndiceDGV)
        {
            txtCodigoContrato.Text = dgvListarContrato.Rows[IndiceDGV].Cells[0].Value.ToString();
            txtDescripcionContrato.Text = dgvListarContrato.Rows[IndiceDGV].Cells[1].Value.ToString(); //tipo de cliente

            if (dgvListarContrato.Rows[IndiceDGV].Cells[2].Value.ToString() == "Activa")
            {
                checkEstadoContrato.Checked = false;

            }
            else
            {
                checkEstadoContrato.Checked = true;
            }
        }


    }
}
