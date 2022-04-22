using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.Prestamos;
using CapaDatos.Models.Prestamos;
using CapaDatos.Repository.PrestamosRepository;
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

namespace Sistema.Forms.modulo_Prestamos
{
    public partial class CobroCreditos : BaseContext
    {
        public ListarPrestamos prestamoActual = null;
        public Prestamos _prestamoAc = null;
        public Cliente clienteActual = null;
        public CuotasCreditoRepository _cuotasCreditoRepository = null;
        public RegistroPagoRepository _registroPagoRepository = null;
        public PrestamoRepository _prestamoRepository = null;
        public List<RegistroPagoCuota> _listaRegistrosPago = new List<RegistroPagoCuota>();
        private Layout layout = null;
        public CobroCreditos(Layout formspadre)
        {
            InitializeComponent();
            _cuotasCreditoRepository = new CuotasCreditoRepository(_context);
            _registroPagoRepository = new RegistroPagoRepository(_context);
            _prestamoRepository = new PrestamoRepository(_context);
            layout = formspadre;
            Crearcorrelativo();
        }
        private void CobroCreditos_Load(object sender, EventArgs e)
        {
            txtmora.Text = "0";
            LimpiarDatos(false);
        }

        private void Crearcorrelativo()
        {
            //string tipo = "CP-";
            //string nodocumento;
            //do
            //{
            //    nodocumento = GenerarNumeroAleatorio.GenerateRandom(tipo);
            //}

            //while (ExisteNoCotizacion(nodocumento));
            txtnopago.Text = Guid.NewGuid().ToString();


        }
        //private bool ExisteNoCotizacion(string cadena)
        //{
        //    Prestamos prestamo = null  ;
        //    if (prestamo == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        public void CargarPrestamo()
        {
            if (prestamoActual != null)
            {
              
                txtnombrecliente.Text = prestamoActual.Nombrescliente.ToString();
                txtnoprestamo.Text = prestamoActual.NoDocumento;
                _prestamoAc = _prestamoRepository.GetPrestamo(prestamoActual.Id);

            }
            if (clienteActual != null)
            {
                txtdpicliente.Text = clienteActual.DPI;
            }
        }

        private void btnprestamoelegir_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ElegirPrestamo"] == null)
            {
                ElegirPrestamo elegirPrestamo = new ElegirPrestamo(this);
                //elegirCliente.MdiParent = this;
                elegirPrestamo.Show();
            }
            else
            {
                Application.OpenForms["ElegirPrestamo"].Activate();
            }
        }

        private IList<ListarCuotas> _listarCuotas = null;
        private void btnLoadSaldos_Click(object sender, EventArgs e)
        {
            if (prestamoActual == null) return;
            CargarDGV();

            //DeudaTotal();

        }
        public void CargarDGV(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cuotasCreditoRepository = null;
                _cuotasCreditoRepository = new CuotasCreditoRepository(_context);
            }

            BindingSource source = new BindingSource();
            _listarCuotas = _cuotasCreditoRepository.GetListaCuotas(prestamoActual.Id);
            source.DataSource = _listarCuotas;
            dgvSaldos.DataSource = typeof(List<>);
            dgvSaldos.DataSource = source;
            dgvSaldos.AutoResizeColumns();
            DeudaTotal();
        }

        private void dgvSaldos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarfila(dgvSaldos, 0);
            sumarFilas(dgvSaldos, 0);
        }
        private void seleccionarfila(DataGridView data, int numberCol)
        {
            bool estadoActual = Convert.ToBoolean(data.CurrentRow.Cells[numberCol].Value);
            var fila = (ListarCuotas)data.CurrentRow.DataBoundItem;
            if (fila.Estado == "Pendiente" || fila.Estado=="En mora")
            {
                if (estadoActual)
                {
                    data.CurrentRow.Cells[numberCol].Value = false;
                }
                else
                {
                    data.CurrentRow.Cells[numberCol].Value = true;

                }
            }
            
        }

        private List<ListarCuotas> _listaCuotasSelected = null;
        int cuotasSelected = 0;
        private void sumarFilas(DataGridView data, int colacciones)
        {
            if (data.RowCount <= 0) { return; }
            int filasSeleccion = 0;
             cuotasSelected = 0;
            decimal total = 0;
            int contador = 0;
            _listaCuotasSelected = new List<ListarCuotas>();
            foreach (DataGridViewRow Rows in data.Rows)
            {
                var filasTotales = int.Parse(data.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[colacciones].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                   
                    total += decimal.Parse(Rows.Cells[8].Value.ToString());
                    txtimporteSelect.Text = total.ToString();
                    cuotasSelected += 1;
                    lbcuotasSelec.Text = cuotasSelected.ToString();
                    txtnuevosaldo.Text = "Q."+(totalparcial - total).ToString();
                    var filaSelected = (ListarCuotas)dgvSaldos.Rows[contador].DataBoundItem;
                    _listaCuotasSelected.Add(filaSelected);
                }
                contador += 1;
                if (filasSeleccion == filasTotales)
                {
                    lbcuotasSelec.Text = "0";
                    txtimporteSelect.Text = "0.00";
                    lbtotaltoPay.Text = "0.00";
                }
            }
        }

        private decimal totalparcial = 0;
        private void DeudaTotal()
        {
            totalparcial = _listarCuotas.Where(x => x.Estado == "Pendiente").Sum(x => x.MontoCuotas);
            txtDeudatotal.Text = "Q."+totalparcial.ToString();
        }
      

        public void LimpiarDatos(bool allclean)
        {
            //CobroCreditos nuevocredito = new CobroCreditos(layout);
            //nuevocredito.MdiParent = layout;
            //nuevocredito.Show();
            if (allclean)
            {
                if (_listarCuotas != null)
                {
                    _listarCuotas.Clear();

                }
               
                dgvSaldos.DataSource = null;
                txtDeudatotal.Text = "";
               
            }
            lbtotaltoPay.Text = "0.00";
            txtcambio.Text = "0.00";
            lbcuotasSelec.Text = "0";
            txtimporteSelect.Text = "";
            txtmontorecibido.Text = "0.00";
            txtmora.Text = "0";
            txtnuevosaldo.Text = "0.00";

        }
        private Prestamos UpdatePrestamoActual(Prestamos prestamo)
        {
            if (prestamo.DeudaActual > 0)
            {
                prestamo.DeudaActual -= decimal.Parse(txtimporteSelect.Text);
                if (prestamo.DeudaActual <= 0)
                {
                    prestamo.Estado = "Finiquitado";
                }
            }
          

            return prestamo;
        }


        private CuotasCredito Updatecuota(CuotasCredito credito)
        {

            credito.Estado = "Cobrado";
            if (!string.IsNullOrEmpty(txtmora.Text))
            {
                credito.Mora = decimal.Parse(txtmora.Text);
            }
            
            credito.Parcial = prestamoActual.MontoCuotas;
            return credito;
        }
        private RegistroPagoCuota GetnewModelRegistro()
        {
            return new RegistroPagoCuota()
            {
                Id = Guid.NewGuid(),
                Importe = decimal.Parse(txtimporteSelect.Text) / cuotasSelected,
                Mora = decimal.Parse(txtmora.Text),
                FechaPago = DateTime.Now,
                PrestamosId = _prestamoAc.Id,
                Nopago = txtnopago.Text,
            };
        }
        private List<CuotasCredito> ConvertirListartoCuotasCredito(List<ListarCuotas> listarCuotas)
        {
            List<CuotasCredito> lista = new List<CuotasCredito>();
            foreach (var item in listarCuotas)
            {
                var credito = new CuotasCredito()
                {
                    Id=item.Id,
                    NoCuota=item.NoCuota,
                    Fecha=item.Fecha,
                    MontoSolicitado=item.MontoSolicitado,
                    Amortizacion= item.Amortizacion,
                    Interes= item.Interes,
                    MontoCuotas=item.MontoCuotas,
                    ITF=item.ITF,
                    Vence=item.Vence,
                    PrestamosID=item.PrestamosID,
                    Mora=item.Mora,
                    InteresesProyectados= item.InteresesProyectados,
                    Estado=item.Estado,
                    

                };

                lista.Add(credito);


            }
            return lista;

        }


      
       private  bool GuardarCambios()
        {
            try
            {

                if (CargarMonto())
                {
                   
                    if (_prestamoRepository.Update(UpdatePrestamoActual(_prestamoAc)))
                    {
                        foreach (var item in ConvertirListartoCuotasCredito(_listaCuotasSelected))
                        {
                            var registropago = GetnewModelRegistro();
                            registropago.CuotasCreditoId = item.Id;

                            var cuotacreditoObtenida = Updatecuota(item);
                            _cuotasCreditoRepository.Update(cuotacreditoObtenida);
                            _registroPagoRepository.Add(registropago);
                            _listaRegistrosPago.Add(registropago);
                        }
                        CargarDGV();
                        LimpiarDatos(false);
                    }
                    else { return false; }

                    
                  
                }
               


            }
            catch(Exception ex) { KryptonMessageBox.Show(ex.Message); return false; }

            return true;
          
        }

      

        private bool CargarMonto()
        {
            
            if(string.IsNullOrEmpty(txtmontorecibido.Text)|| txtmontorecibido.Text == "0"|| txtmontorecibido.Text == "." || string.IsNullOrEmpty(txtimporteSelect.Text) || txtimporteSelect.Text=="0")
            {
                txtcambio.Text = "0.00";
                return false;
            }
            else
            {
                decimal montoRecibido = 0.00M;
                decimal importe = 0.00M;
                montoRecibido = decimal.Parse(txtmontorecibido.Text);
                importe = decimal.Parse(txtimporteSelect.Text);
                return true;
             /*   if(montoRecibido>= importe)
                {
                    return true;
                }
                else { return false; }*/
            }
  

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (_listaCuotasSelected.Count == 0) { KryptonMessageBox.Show("No ha elegido ninguna cuota"); return; }

            if (CargarMonto())
            {
                if (GuardarCambios())
                {
                    KryptonMessageBox.Show("Registro Guardado Correctamente!");
                    cargarRegistro();
                    Crearcorrelativo();
                }
                else { KryptonMessageBox.Show("Error al guardar registro!"); }
            }

        }
        private void cargarRegistro()
        {
            if (Application.OpenForms["ComprobantePago"] == null)
            {
                if (_prestamoAc == null) { return; }
                if (_listarCuotas.Count == 0) return;
                var codigoreferencia = txtnopago.Text.Trim();
                var listabdRegistro = _registroPagoRepository.getlistaRegistrobydocumento(codigoreferencia);
                ComprobantePago comprobantePago = new ComprobantePago(this, listabdRegistro, _prestamoAc,clienteActual);
                //elegirCliente.MdiParent = this;
                comprobantePago.Show();
                 _listaRegistrosPago.Clear();
            }
            else
            {
                Application.OpenForms["ReporteCuotasbyprestamo"].Activate();
            }


        }

        private void txtmontorecibido_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        private void txtmora_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CalculoMath()
        {

        }

        private void txtmontorecibido_TextChanged(object sender, EventArgs e)
        {
            
            if (!CargarMonto()) 
            { 
                return; 
            } 
            else
            {
                var importetotal = CalcularTotal(); ;
                var montoRecibido = decimal.Parse(txtmontorecibido.Text);
                var validarVuelto = montoRecibido - importetotal;
                txtcambio.Text = validarVuelto.ToString();
                if (validarVuelto < 0) txtcambio.BackColor=Color.Red;
                if (validarVuelto >= 0) txtcambio.BackColor = Color.White;
            }
         
        }

        private void txtmora_TextChanged(object sender, EventArgs e)
        {

            CalcularTotal();
        }

        private decimal CalcularTotal()
        {
            decimal totalpagar = 0.00M;
            if ( string.IsNullOrEmpty(txtimporteSelect.Text) || txtimporteSelect.Text == "0") 
            {

            } else
            {
                if (string.IsNullOrEmpty(txtmora.Text) || txtmora.Text == "0")
                {

                     totalpagar = decimal.Parse(txtimporteSelect.Text);
                    lbtotaltoPay.Text = "Q." + totalpagar.ToString("0.00");
                    
                }
                else
                {
                    totalpagar = ((decimal.Parse(txtmora.Text) / 100) * (decimal.Parse(txtimporteSelect.Text))) + (decimal.Parse(txtimporteSelect.Text));
                    lbtotaltoPay.Text = "Q." + totalpagar.ToString("0.00");

                }
               
               
            }
            
            return totalpagar;

        }

        private void txtimporteSelect_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReporteCuotasbyprestamo"] == null)
            {
                if(_prestamoAc== null) { return; }
                if (_listarCuotas.Count == 0) return;
                ReporteCuotasbyprestamo reporteCuotasbyprestamo = new ReporteCuotasbyprestamo(_prestamoAc,_listarCuotas,clienteActual);
                //elegirCliente.MdiParent = this;
                reporteCuotasbyprestamo.Show();
            }
            else
            {
                Application.OpenForms["ReporteCuotasbyprestamo"].Activate();
            }
        }
    }
}
