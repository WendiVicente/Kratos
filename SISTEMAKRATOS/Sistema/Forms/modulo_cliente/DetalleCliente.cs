using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_cliente
{
    public partial class DetalleCliente : BaseContext
    {
        private readonly Cliente _cliente = null;
        private readonly ClientesRepository _clientesRepository = null;
        private readonly ListarClientesDgv _listarClientesForm = null;

        public DetalleCliente(Cliente cliente, ListarClientesDgv listaClientesForm)
        {
            _cliente = cliente;
            _clientesRepository = new ClientesRepository(_context);
            _listarClientesForm = listaClientesForm;

            InitializeComponent();
        }

        private void DetalleCliente_Load(object sender, EventArgs e)
        {
            CargarModelo();
            CargarTipos();
        }

        private void CargarModelo()
        {
            nombretxt.Text = _cliente.Nombres;
            apellidostxt.Text = _cliente.Apellidos;
            telefonotxt.Text = _cliente.Telefonos;
            nittxt.Text = _cliente.Nit;
            direcciontxt.Text = _cliente.Direccion;
            aliastxt.Text = _cliente.Alias;
            cbtipoCliente.SelectedValue = _cliente.TiposId;
            txtcodigocliente.Text = _cliente.CodigoCliente;
            checkcredito.Checked = _cliente.PermitirCredito;
        }

        private Cliente GetViewModel(Cliente cliente)
        {
            cliente.Nombres = nombretxt.Text;
            cliente.CodigoCliente = txtcodigocliente.Text;
            cliente.Apellidos = apellidostxt.Text;
            cliente.Telefonos = telefonotxt.Text;
            cliente.Nit = nittxt.Text;
            cliente.Direccion = direcciontxt.Text;
            cliente.Alias = aliastxt.Text;
            cliente.TiposId = int.Parse(cbtipoCliente.SelectedValue.ToString());
            cliente.PermitirCredito = checkcredito.Checked;

            return cliente;
        }

        public void CargarTipos()
        {
            cbtipoCliente.DataSource = _clientesRepository.GetTipos();
            cbtipoCliente.DisplayMember = "TipoCliente";
            cbtipoCliente.ValueMember = "Id";
            cbtipoCliente.Invalidate();
            cbtipoCliente.SelectedValue = _cliente.TiposId;
        }



        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            var cliente = _clientesRepository.Get(_cliente.Id);

            var GetCliente = GetViewModel(cliente);

            if(ModelState.IsValid(GetCliente))
            {
                try
                {
                    _clientesRepository.Update(GetCliente);
                    _listarClientesForm.RefrescarDataGridClientes(true);
                    Close();
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
            else
            {
                KryptonMessageBox.Show("Hay campos obligatorios sin llenar", "ERROR", MessageBoxButtons.OK);

            }
        }
    }
}
