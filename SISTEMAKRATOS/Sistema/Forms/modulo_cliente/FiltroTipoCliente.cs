using CapaDatos.Models.Clientes;
using CapaDatos.Repository;
using Sistema.Reports.Reports_Clientes;
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
    public partial class FiltroTipoCliente : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        private readonly ListarClientesDgv _listarClientes = null;
        public FiltroTipoCliente(ListarClientesDgv listaform)
        {
            _clientesRepository = new ClientesRepository(_context);
            _listarClientes = listaform;
            InitializeComponent();
        }

        private void FiltroTipoCliente_Load(object sender, EventArgs e)
        {

            var tipos = _clientesRepository.GetTipos();

            // agregar nuevo item a la lista
            tipos.Add(new Tipos { Id = 0, TipoCliente = "Todas" });
            var s = tipos.OrderBy(a => a.Id).ToList();
            // mostrar datos en dgv
            listsucursales.DataSource = s;
            listsucursales.DisplayMember = "Area";
            listsucursales.ValueMember = "Id";
            listsucursales.Text = "Seleccione una área"; 
            listsucursales.SelectedIndex = 0;
            listsucursales.Invalidate();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            var valorCombobox = listsucursales.SelectedValue.ToString();
            var textoseleccionado = listsucursales.Text.ToString();

            ReporteTiposClientes reporte = new ReporteTiposClientes(int.Parse(valorCombobox)) ;
            reporte.Show();
        }

        private void bntfiltro_Click(object sender, EventArgs e)
        {
            _listarClientes.lbtipocliente.Text = listsucursales.Text;
            var valorCombobox = listsucursales.SelectedValue.ToString();
            _listarClientes.filtroid = Convert.ToInt32(valorCombobox);
            _listarClientes.RefrescarDataGridClientes(true);

        }

        private void listsucursales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
