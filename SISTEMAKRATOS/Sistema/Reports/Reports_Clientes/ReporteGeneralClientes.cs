using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Clientes;
using CapaDatos.Repository;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Reports.Reports_Clientes
{
    public partial class ReporteGeneralClientes : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        private TiposClienteRepository _tiposClienteRepository = null;
        private string estadocliente;
        public List<Tipos> TiposSeleccionadosLista = null;
        private DateTime fechaInicio => Convert.ToDateTime(dtpfechainicio.Value.ToLongDateString());
        private DateTime fechaFinal => Convert.ToDateTime(dtpfechafinal.Value.ToLongDateString());

        //  DateTime fechaInicio, fechaFinal;
        public ReporteGeneralClientes()
        {
            _clientesRepository = new ClientesRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            _tiposClienteRepository = new TiposClienteRepository(_context);


            InitializeComponent();
        }

        private void ReporteGeneralClientes_Load(object sender, EventArgs e)
        {
            CargarTiposClientes();
            CargarSucursales();
            CargarCategoriaClientes();
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            CargarTabla();
            cargarTextbox();
           
            this.rvClientes.RefreshReport();

        }



        private void CargarTabla()
        {
            var tiposId = int.Parse(cbtipos.SelectedValue.ToString()); //
            
            var orderByAscen = rbAscent.Checked;
            var orderByDescen = rbDescen.Checked;
            var allFechas = checkfechas.Checked;
            // checkbox de usuariios inactivos o activos
            var clienteActivo = rbActivos.Checked;
            var clienteInactivo = rbInactivos.Checked;
            var todos = rbTodos.Checked;
            var idsucursal =int.Parse(cbsucursales.SelectedValue.ToString());
            var idCategoria = int.Parse(cbcategoria.SelectedValue.ToString());

            CargarEstados();

            if (checkvarios.Checked== true)
            {
                tiposId = 0;

            }

            var listadeclientes = _clientesRepository.GetlistaReporte(idsucursal, tiposId, allFechas, fechaInicio,
                fechaFinal.AddDays(1), orderByDescen, orderByAscen, clienteActivo, clienteInactivo, todos, idCategoria);//,TiposSeleccionadosLista);

            IList<ListarClientes> ListaFiltrada = null;
            

            if (TiposSeleccionadosLista != null && checkvarios.Checked == true)
            {
                string busqueda;
                
                foreach (var tiposItem in TiposSeleccionadosLista)
                     {

                          busqueda= tiposItem.TipoCliente.ToString();
                            var  listaCustomers = listadeclientes.Where(a => a.Tipo_Cliente == busqueda).ToList();
                                 
                   
                     if(ListaFiltrada== null)
                    {
                        ListaFiltrada = listaCustomers;
                    }
                    else
                    {
                        ListaFiltrada = ListaFiltrada.Concat(listaCustomers).ToList();
                     
                    }

                     }
                    


                 


                rvClientes.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Clientes.ReporteGeneralClientes.rdlc";
                var rds1 = new ReportDataSource("listageneralclientes", ListaFiltrada);
                rvClientes.LocalReport.DataSources.Clear();
                rvClientes.LocalReport.DataSources.Add(rds1);
            }
            else
            {
                rvClientes.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Clientes.ReporteGeneralClientes.rdlc";
                var rds1 = new ReportDataSource("listageneralclientes", listadeclientes);
                rvClientes.LocalReport.DataSources.Clear();
                rvClientes.LocalReport.DataSources.Add(rds1);
            }
             

           
        }
        private void CargarEstados()
        {
            if (rbTodos.Checked == true) { estadocliente = "Todos"; };
            if (rbInactivos.Checked == true) { estadocliente = "Inactivos"; };
            if (rbActivos.Checked == true) { estadocliente = "Activos"; };
        }

        private void CargarTiposClientes()
        {
            var tipos = _clientesRepository.GetTipos();

            // agregar nuevo item a la lista
            tipos.Add(new Tipos { Id = 0, TipoCliente = "Todas" });
            var s = tipos.OrderBy(a => a.Id).OrderBy(x=>x.TipoCliente).ToList();
           
            cbtipos.DataSource = s;
            cbtipos.DisplayMember = "TipoCliente";
            cbtipos.ValueMember = "Id";
            cbtipos.Text = "Seleccione una Tipo";
            cbtipos.SelectedIndex = 0;
            cbtipos.Invalidate();
           
        }
        private void CargarCategoriaClientes()
        {
            var categoria = _tiposClienteRepository.GetCategoria();

            // agregar nuevo item a la lista
            categoria.Add(new ListaDeCategoriaCliente { Id = 0, Categoria = "Todas" });
            var s = categoria.OrderBy(a => a.Id).ToList();
            // mostrar datos en dgv
            cbcategoria.DataSource = s;
            cbcategoria.DisplayMember = "Categoria";
            cbcategoria.ValueMember = "Id";
            cbcategoria.Text = "Seleccione una Categoria"; //
            cbcategoria.SelectedIndex = 0;
            cbcategoria.Invalidate();
        }
        private void CargarSucursales()
        {
            var sucursal = _sucursalesRepository.GetList();

            // agregar nuevo item a la lista
            sucursal.Add(new ListarSucursales { Id = 0, NombreSucursal = "Todas" });
            var s = sucursal.OrderBy(a => a.Id).ToList();

            // mostrar datos en dgv
            cbsucursales.DataSource = s;
            cbsucursales.DisplayMember = "NombreSucursal";
            cbsucursales.ValueMember = "Id";
            //cbsucursales.Text = "Seleccione una Sucursal"; // 
            cbsucursales.SelectedIndex = 0;
            cbsucursales.Invalidate();
        }
        private void checkfechas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkfechas.Checked == false)
            {
                dtpfechainicio.Enabled = true;
                dtpfechafinal.Enabled = true;
            }
            else
            {
                dtpfechainicio.Enabled = false;
                dtpfechafinal.Enabled = false;
            }

        }

        public void cargarTextbox()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("tipocliente",cbtipos.Text),
                new ReportParameter("categoria",cbcategoria.Text),
                 new ReportParameter("fechainicio",fechaInicio.ToString()),
                  new ReportParameter("fechafinal",fechaFinal.ToString()),
                   new ReportParameter("sucursal",cbsucursales.Text),
                    new ReportParameter("estadocliente",estadocliente),

            };
            rvClientes.LocalReport.SetParameters(reportParameters);

        }

        private void lbSelectedVarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbSelectedVarios_Click(object sender, EventArgs e)
        {
           
        }

        private void checkvarios_CheckedChanged(object sender, EventArgs e)
        {
            if (checkvarios.Checked == true)
            {
                if (Application.OpenForms["ElegirMasTipos"] == null)
                {


                    ElegirMasTipos elegirMasTipos = new ElegirMasTipos(this);
                    elegirMasTipos.Show();


                }

                else { Application.OpenForms["ElegirMasTipos"].Activate(); }

            }
            else
            {
                TiposSeleccionadosLista = null;
            }
        }
    }
}
