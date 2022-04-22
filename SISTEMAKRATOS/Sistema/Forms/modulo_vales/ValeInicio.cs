using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Vales;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using Sistema.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_vales
{
    public partial class ValeInicio : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        private ValesRepository _valesRepository = null;
        private TipoPrecioRepository _tipoPrecioRepository = null;
        public int filtroid = 0;
        private IList<ListarClientes> listaClientestodos => _clientesRepository.GetList(filtroid);
        private List<Cliente> _listaclientes = null;
        private Guid idvale;
        public ValeInicio()
        {
            _clientesRepository = new ClientesRepository(_context);
            _valesRepository = new ValesRepository(_context);
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            _listaclientes = new List<Cliente>();
            InitializeComponent();
            Crearcorrelativo();
        }

        private void ValeInicio_Load(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToString();
            idvale = Guid.NewGuid();
            txtMonto.Text = "0.00";
            txtcantidad.Text = "1";
            CargarTipos();
         
        }
        private void Crearcorrelativo()
        {
            string tipo = "VL-";
            string numeroVale;
            do
            {
                numeroVale = GenerarNumeroAleatorio.GenerateRandom(tipo);
            }

            while (ExisteNoCotizacion(numeroVale));
            lbcorrelVale.Text = numeroVale;


        }
        private bool ExisteNoCotizacion(string cadena)
        {
            var cotiz = _valesRepository.GetvaleByCorrel(cadena);
            if (cotiz == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RefrescarDataGridClientes(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _clientesRepository = null;
                _clientesRepository = new ClientesRepository(_context);
            }

            BindingSource source = new BindingSource();
            // var clientes = _clientesRepository.GetList(filtroid);
            source.DataSource = listaClientestodos;
            dgvAunPersonal.DataSource = typeof(List<>);
            dgvAunPersonal.DataSource = source;
            dgvAunPersonal.AutoResizeColumns();
            for (int i = 0; i < 17; i++)
            {
                dgvAunPersonal.Columns[i].Visible = false;
            }
            dgvAunPersonal.Columns[1].Visible = true;
            dgvAunPersonal.Columns[2].Visible = true;
            dgvAunPersonal.Columns[3].Visible = true;
            dgvAunPersonal.Columns[4].Visible = true;
            dgvAunPersonal.Columns[15].Visible = true;

        }
        private void CargarTipos()
        {
            var tipos = _clientesRepository.GetTipos();

            combotipos.DataSource = tipos;
            combotipos.DisplayMember = "TipoCliente";
            combotipos.ValueMember = "Id";
            combotipos.SelectedIndex = 0;
            combotipos.Invalidate();
        }
        public Vale GetNewVale()
        {
            return new Vale()
            {
                Id = idvale,
                NoVale = lbcorrelVale.Text.Trim(),
                SucursalId = UsuarioLogeadoSistemas.User.SucursalId,
                FechaRecepcion = DateTime.Now,
                Monto = decimal.Parse(txtMonto.Text),
                Descripcion = txtdescrip.Text,
                UserId = UsuarioLogeadoSistemas.User.Id,
                TiposId = int.Parse(combotipos.SelectedValue.ToString()),
            };
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            SeleccionAcciones(_listaclientes);
            
                GuardarVales();
                      
            
        }
        private void GuardarVales()
        {
           
            if (string.IsNullOrEmpty(txtdescrip.Text)) { KryptonMessageBox.Show("debe ingresar una descripción para el vale"); return; }
            if (string.IsNullOrEmpty(txtcantidad.Text) || txtcantidad.Text == "0") { KryptonMessageBox.Show("campo cantidad inválido "); return; }
            if (string.IsNullOrEmpty(txtMonto.Text) || txtMonto.Text=="0.00") { KryptonMessageBox.Show("campo monto inválido "); return; }

            var encabezadoVale = GetNewVale();
            ///var detalleVales = GetDatosDetalleVales();
           //var detalleRebaja = GetDatosDetalleRebajas();
            if (!ModelState.IsValid(encabezadoVale)) { return; }
         
            _valesRepository.Add(encabezadoVale);

            if (checkClientes.Checked == true)
            {
                if (_listaclientes.Count == 0) { return; }
                GuardarAsignacionValeListaClientes();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtcantidad.Text) || txtcantidad.Text != "0")
                {
                    _listaclientes.Clear();
                    GuardarvaleIndividual();
                }
               

            }
          

            KryptonMessageBox.Show("Registro Guardado correctamente! ");
            // limpiardatos();
            Close();

        }

        private void GuardarAsignacionValeListaClientes()
        {
            var totalitems = _listaclientes.Count;
            foreach (var cliente in _listaclientes)
            {
                var asignacion = GetAsignacionNuevo();
                if (!ModelState.IsValid(asignacion)) { return; }
                asignacion.ClienteId = cliente.Id;
                var operacion = (decimal.Parse(txtMonto.Text) / totalitems).ToString("0.00");
                asignacion.Monto = decimal.Parse(operacion);
                asignacion.Reciduo= decimal.Parse(operacion);
                _valesRepository.AddAsignacionVale(asignacion);

            }
        }
        private void GuardarvaleIndividual()
        {
            var totalitems = int.Parse(txtcantidad.Text);
            for (int i = 1; i <= totalitems; i++)
            {
                var asignacion = GetAsignacionNuevo();
                if (!ModelState.IsValid(asignacion)) { return; }
                asignacion.NoVale = i;
                asignacion.Monto = decimal.Parse(txtmontoindividual.Text);
                asignacion.Reciduo = decimal.Parse(txtmontoindividual.Text);
                _valesRepository.AddAsignacionVale(asignacion);
            }
            
        }


        private AsignacionVale GetAsignacionNuevo()
        {
            return new AsignacionVale()
            {

                Id = Guid.NewGuid(),
                ValeId = idvale,
                Estado = "Asignado",
                FechaAsignacion= DateTime.Now,
                FechaCambio= DateTime.Now,



            };
        }
        private void SeleccionAcciones(List<Cliente> clienteslista)
        {


            if (dgvAunPersonal.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            foreach (DataGridViewRow Rows in dgvAunPersonal.Rows)
            {
                var filasTotales = int.Parse(dgvAunPersonal.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[15].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var Id = int.Parse(Rows.Cells[0].Value.ToString());
                    var clienteobtenido = _clientesRepository.Get(Id);

                    clienteslista.Add(clienteobtenido);
                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Cliente, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }


        }

        private void checkClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkClientes.Checked == true)
            {
                RefrescarDataGridClientes();
            }
            else
            {
                dgvAunPersonal.DataSource = null;
            }
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
           
            if(!string.IsNullOrEmpty(txtMonto.Text)|| txtMonto.Text != "0")
            {
                var monto = decimal.Parse(txtMonto.Text);
                if(!string.IsNullOrEmpty(txtcantidad.Text))
                {
                    try
                    {
                        var cantidad = int.Parse(txtcantidad.Text);
                        txtmontoindividual.Text = (monto / cantidad).ToString();
                    }
                    catch(DivideByZeroException)
                    {
                        KryptonMessageBox.Show("No es posible dividir (0)");
                    }
                    
                }
                else { return; }
            }
            else { return; }
        }

        private void dgvAunPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var fila = dgvAunPersonal.CurrentCell;
            if (fila.ColumnIndex == 15)
            {
                var row = dgvAunPersonal.CurrentRow;
                if (row.Cells[15].Value != null)
                {
                    bool seleccion = Convert.ToBoolean(row.Cells[15].Value);
                    if (seleccion)
                    {
                        row.Cells[15].Value = false;
                    }
                    else 
                    {
                        row.Cells[15].Value = true;
                    }
                }                
            }
        }
    }
}
