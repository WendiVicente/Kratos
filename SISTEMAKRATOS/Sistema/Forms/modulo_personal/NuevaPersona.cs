using CapaDatos.Models.Personal;
using CapaDatos.Repository;
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
    public partial class NuevaPersona : BaseContext
    {
        private PersonalRepository _personalRepository = null;
        private SucursalesRepository _sucursalRepository = null;
        private ContratosRepository _contratosRepository = null;
        private PropiedadesRepository _propiedadesRepository = null;
        public NuevaPersona()
        {
            _personalRepository = new PersonalRepository(_context);
            _sucursalRepository = new SucursalesRepository(_context);
            _contratosRepository = new ContratosRepository(_context);
            _propiedadesRepository = new PropiedadesRepository(_context);
            InitializeComponent();
        }

      

        private void NuevaPersona_Load(object sender, EventArgs e)
        {
            CargarSucursales();
                CargarTipocontrato();
            CargarHorario();
            CargarPuesto();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarProveedor();

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
                PuestoId= int.Parse(comboPuestos.SelectedValue.ToString()),
                Nit = txtnit.Text,
                FechaIngreso = dtpingreso.Value,
                EstadoCivil= txtestadocivil.Text,
                Dpi= txtdpi.Text,
                Edad= int.Parse(txtedad.Text),
                Salario= decimal.Parse(txtsalario.Text),
                



            };

        }
        private void GuardarProveedor()
        {
            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtdpi.Text) ||
                 string.IsNullOrEmpty(txttel1.Text))
            { KryptonMessageBox.Show("Campos Vacios, Todos son Obligatorios "); return; }

            var modeloProveedor = GetNewPersonal();
            if (!ModelState.IsValid(modeloProveedor)) { return; }
            _personalRepository.Add(modeloProveedor);

            KryptonMessageBox.Show("Personal Guardado!");


        }


        private void CargarSucursales()
        {
            var sucursal = _sucursalRepository.GetList();
            comboSucursal.DataSource = sucursal;
            comboSucursal.DisplayMember = "NombreSucursal";
            comboSucursal.ValueMember = "Id";
            comboSucursal.SelectedIndex = 0;
            comboSucursal.Invalidate();
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
        private void CargarPuesto()
        {
            var puestos = _propiedadesRepository.GetListPuestos();
            comboPuestos.DataSource = puestos;
            comboPuestos.DisplayMember = "Descripcion";
            comboPuestos.ValueMember = "Id";
            comboPuestos.Invalidate();



        }

    }
}
