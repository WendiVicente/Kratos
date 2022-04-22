using CapaDatos.Repository;
using CapaDatos.Repository.PrestamosRepository;
using CapaDatos.Models;
using CapaDatos.Models.Prestamos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sharedDatabase.Models;
using CapaDatos.ListasPersonalizadas;
using ComponentFactory.Krypton.Toolkit;
using CapaDatos.Validation;
using Sistema.Validations;

namespace Sistema.Forms.modulo_Prestamos
{
    public partial class RegistroDesembolso : BaseContext
    {
        private readonly TipoCreditoRepository _tipoCreditoRepository = null;
        private readonly MetodoAmortizacionRepository _amortizacionrepository = null;
        private readonly PrestamoRepository _prestamoRepository = null;
        private readonly CuotasCreditoRepository _cuotasCreditoRepository = null;
        private readonly ClientesRepository _clienteRepository = null;
        public ListarClientes clienteActual = null;
        public RegistroDesembolso()
        {
            InitializeComponent();
            _tipoCreditoRepository = new TipoCreditoRepository(_context);
            _amortizacionrepository = new MetodoAmortizacionRepository(_context);
            _prestamoRepository = new PrestamoRepository(_context);
            _cuotasCreditoRepository = new CuotasCreditoRepository(_context);
            _clienteRepository = new ClientesRepository(_context);
        }

     
        private void RegistroDesembolso_Load(object sender, EventArgs e)
        {
            Cargaramortizacion();
            CargarTiposCredito();
            Crearcorrelativo();
            limpiarData(false);
        }
        private void Crearcorrelativo()
        {
            string tipo = "PC-";
            string nodocumento;
            do
            {
                nodocumento = GenerarNumeroAleatorio.GenerateRandom(tipo);
            }

            while (ExisteNoCotizacion(nodocumento));
            txtnocredito.Text = nodocumento;


        }
        private bool ExisteNoCotizacion(string cadena)
        {
            var prestamo = _prestamoRepository.Getprestamobycodigo(cadena);
            if (prestamo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Cargaramortizacion()
        {
            var amortizacionlista = _amortizacionrepository.GetListaMetodos();
            combometodoamort.DataSource = amortizacionlista;
            combometodoamort.ValueMember = "Id";
            combometodoamort.DisplayMember = "Metodo";
            combometodoamort.SelectedIndex = 0;
        }
        private void CargarTiposCredito()
        {
            var periodoCredito = _tipoCreditoRepository.GetListaTipoCreditos();
            comboperiodopago.DataSource = periodoCredito;
            comboperiodopago.ValueMember = "Id";
            comboperiodopago.DisplayMember = "Tipo";
            comboperiodopago.SelectedIndex = 0;
        }

        int idcliente = 0;
        public void CargarClientetxts()
        {
            if (clienteActual != null)
            {
                txtcodcliente.Text = clienteActual.CodigoCliente;
                idcliente = clienteActual.Codigo;
                txtnombrecliente.Text = clienteActual.Nombres + " " + clienteActual.Apellidos;

            }
        }
      
        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ElegirCliente"] == null)
            {
                ElegirCliente elegirCliente = new ElegirCliente(this);
                //elegirCliente.MdiParent = this;
                elegirCliente.Show();
            }
            else
            {
                Application.OpenForms["ElegirCliente"].Activate();
            }
        }

        private CuotasCredito GetNewCuotas()
        {
            return new CuotasCredito()
            {

            };
        }
        private Prestamos GetnewPrestamo()
        {
            return new Prestamos()
            {
                Id = Guid.NewGuid(),
                NoDocumento = txtnocredito.Text,
                Monto = decimal.Parse(txtmontosolicitado.Text),
                TasaInteres = int.Parse(txttasainteres.Text),
                ImporteFinanciado = decimal.Parse(txtimporteFinal.Text),
                NoCuotas = int.Parse(txtnocuotas.Text),
                MontoCuotas = decimal.Parse(txtvalorxcuota.Text),
                DeudaActual = decimal.Parse(txtimporteFinal.Text),
                Estado = "En Deuda",
                TipoCreditoId = int.Parse(comboperiodopago.SelectedValue.ToString()),
                FechaSolicitud = DateTime.Now,
                Observaciones = txtobservacion.Text,
                AmortizacionId = int.Parse(combometodoamort.SelectedValue.ToString()),
                UsuarioId = UsuarioLogeadoSistemas.User.Id,
                ClienteId = idcliente,


            };
        }


        private double interesCalc(decimal interes, decimal montoSolicitado,int nocuotas)
        {


            var interesmas = 1 + interes;
            var valor = double.Parse(interesmas.ToString());
            double potencia = 0- nocuotas ;
            double calculo = Math.Pow(valor, potencia) ;
            
           
            var valorbycuota = ((Convert.ToDouble(montoSolicitado) * Convert.ToDouble(interes)) / 1 - (calculo));
            

            return valorbycuota;
        }

        private List<CuotasCredito> GetlistaCuotas()
        {
            var lista = new List<CuotasCredito>();
            var today = DateTime.Today;
            var mes = DateTime.Today;
            var tasainteresfija = (decimal.Parse(txttasainteres.Text) / 100);
            var montosolicitado = decimal.Parse( txtmontosolicitado.Text);
            var saldoInsoluto = montosolicitado;
            var calculointeres = tasainteresfija * saldoInsoluto;

            for (int i = 1; i <= int.Parse(txtnocuotas.Text); i++)
            {
                var nuevaCuota = GetNewCuotas();
                nuevaCuota.NoCuota = i;
                nuevaCuota.Estado = "Pendiente";
                if (combometodoamort.Text == "Frances")
                {
                    nuevaCuota.Interes = calculointeres;
                    nuevaCuota.Amortizacion = (decimal.Parse(txtvalorxcuota.Text)) - calculointeres;
                    saldoInsoluto -=  nuevaCuota.Amortizacion;
                }
                nuevaCuota.MontoSolicitado = decimal.Parse(txtmontosolicitado.Text);
                nuevaCuota.MontoCuotas = decimal.Parse(txtvalorxcuota.Text);
               
                if (comboperiodopago.Text == "Diario")
                {
                    
                    nuevaCuota.Fecha = DateTime.Today.AddDays(i);
                    nuevaCuota.Vence= DateTime.Today.AddDays(i+1);
                    lista.Add(nuevaCuota);
                }
                if (comboperiodopago.Text == "Semanal")
                {
                    nuevaCuota.Fecha = today;
                    today = today.AddDays(7);
                    nuevaCuota.Vence = today;
                    lista.Add(nuevaCuota);
                }
                if (comboperiodopago.Text == "Quincenal")
                {
                    nuevaCuota.Fecha = today;
                    today = today.AddDays(15);
                    nuevaCuota.Vence = today;
                    lista.Add(nuevaCuota);
                }
                if (comboperiodopago.Text == "Mensual")
                {
                    nuevaCuota.Fecha = mes ;
                    mes = mes.AddMonths(1);
                    nuevaCuota.Vence = mes;
                    lista.Add(nuevaCuota);
                }
                if (comboperiodopago.Text == "Trimestral")
                {
                    nuevaCuota.Fecha = mes;
                    mes = mes.AddMonths(3);
                    nuevaCuota.Vence = mes;
                    lista.Add(nuevaCuota);
                }
                if (comboperiodopago.Text == "Semestral")
                {
                    nuevaCuota.Fecha = mes;
                    mes = mes.AddMonths(6);
                    nuevaCuota.Vence = mes;
                    lista.Add(nuevaCuota);
                }
                if (comboperiodopago.Text == "Anual")
                {
                    nuevaCuota.Fecha = mes;
                    mes = mes.AddYears(1);
                    nuevaCuota.Vence = mes;
                    lista.Add(nuevaCuota);
                }

            }

            return lista;

        }


        private List<CuotasCredito> _listageneralcuotas = new List<CuotasCredito>();
        private void CargarComboCuotas()
        {
            if(string.IsNullOrEmpty(txtnocuotas.Text)|| string.IsNullOrEmpty(txtimporteFinal.Text)) { KryptonMessageBox.Show("Debe ingresar Un monto y numero de cuotas para continuar."); return; }
            _listageneralcuotas = GetlistaCuotas();
            BindingSource source = new BindingSource();
            source.DataSource = _listageneralcuotas;
            dgvCuotas.DataSource = typeof(List<>);
            dgvCuotas.DataSource = source;
            dgvCuotas.AutoResizeColumns();
           


        }










       
        private void Calcularmonto()
        {

            var interes = (decimal.Parse(txttasainteres.Text) / 100);
            var montosolicitado = decimal.Parse(txtmontosolicitado.Text);
           // var cuotasno = int.Parse(txtnocuotas.Text);
            //if (combometodoamort.Text == "Frances")
            //{
            //    txtvalorxcuota.Text = interesCalc(interes, montosolicitado, cuotasno).ToString("0.00");
            //}

            txtimporteFinal.Text = ((montosolicitado*interes)+montosolicitado).ToString() ;

        }

      
        private void txttasainteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtmontosolicitado_KeyPress(object sender, KeyPressEventArgs e)
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

     
        private void txtnocuotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       

        private void txtmontosolicitado_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttasainteres.Text)|| txttasainteres.Text=="0") { return; }
            if (string.IsNullOrEmpty(txtmontosolicitado.Text) || txtmontosolicitado.Text=="0") { return; }

            Calcularmonto();


        }

        private void txttasainteres_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttasainteres.Text)) { return; }
            if (string.IsNullOrEmpty(txtmontosolicitado.Text)) { return; }

            Calcularmonto();
        }

       
      

        private void txtnocuotas_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnocuotas.Text)|| txtnocuotas.Text=="0") { return; }
            else
            {
                var importefinal = decimal.Parse(txtimporteFinal.Text);
                var valorByCuota = (importefinal / (int.Parse(txtnocuotas.Text)));
                txtvalorxcuota.Text = valorByCuota.ToString("0.00");
            }

        }

        private void btngenerarcuotas_Click(object sender, EventArgs e)
        {
            CargarComboCuotas();
        }

        private void limpiarData(bool cleanll)
        {
            if (cleanll)
            {
                dgvCuotas.DataSource = null;
                _listageneralcuotas.Clear();
            }

            txtnombrecliente.Text = "";
            txtcodcliente.Text = "";
            txtimporteFinal.Text = "0.00";
            txtmontosolicitado.Text = "0.00";
            txttasainteres.Text = "0";
            txtobservacion.Text = "";
            txtnocuotas.Text = "0";
            txtvalorxcuota.Text = "0.00";


        }


        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (dgvCuotas.RowCount == 0) { KryptonMessageBox.Show("debera generar cuotas a pagar"); return; }

            Guid guidprestamo;
            try
            {
                var prestamo = GetnewPrestamo();
                guidprestamo = prestamo.Id;

                if (_prestamoRepository.Add(prestamo))
                {

                    foreach (var cuotasCredito in _listageneralcuotas)
                    {
                        cuotasCredito.PrestamosID = guidprestamo;
                        _cuotasCreditoRepository.Add(cuotasCredito);
                    }
                    KryptonMessageBox.Show("Registro Guardado correctamente!");
                    limpiarData(true);
                    Crearcorrelativo();
                }

            }catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
            
            

        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SolicitudPDF"] == null)
            {
                //var listacuotas = GetlistaCuotas();
                if (_listageneralcuotas.Count == 0) return;
                var tipoperiodo = comboperiodopago.Text;
                SolicitudPDF solicitudPDF = new SolicitudPDF(GetnewPrestamo(), _listageneralcuotas, clienteActual, tipoperiodo);
                //elegirCliente.MdiParent = this;
                solicitudPDF.Show();
            }
            else
            {
                Application.OpenForms["SolicitudPDF"].Activate();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            limpiarData(true);
        }
    }
}
