using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Repository;
using CapaDatos.WebServiceSAT;
using ComponentFactory.Krypton.Toolkit;
using Newtonsoft.Json;
using sharedDatabase.Models;
using System;
using System.Windows.Forms;
using WebApi;

namespace POS.Forms
{
    public partial class DatosCliente : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        private CuentasCobrarRepository _cuentasCobrarRepository = null;
        public Cliente _cliente = null;
        public PuntoDeVenta _pos = null;
        private TokenSAT TokenObtenidoSat = null;
        private RESPONSE clientesx = null;
        private int _tipocliente;
        private bool conectado;
        public DatosCliente(Cliente cliente, int tipoCliente, PuntoDeVenta punto, TokenSAT tokenSat, bool conec)
        {
            TokenObtenidoSat = tokenSat;
            conectado = conec;
            _clientesRepository = new ClientesRepository(_context);
            _cuentasCobrarRepository = new CuentasCobrarRepository(_context);
            _cliente = cliente;
            _tipocliente = tipoCliente;
            _pos = punto;
            InitializeComponent();
        }       

        private void DatosCliente_Load(object sender, EventArgs e)
        {
            
            clientesx = new RESPONSE();
            if (_cliente != null)
            {
                if (_cliente.Nit != null)
                    txtNit.Text = _cliente.Nit.ToString();
                if (_cliente.Nombres != null)
                    txtNombre.Text = _cliente.Nombres.ToString();
                if (_cliente.Direccion != null)
                    txtDireccion.Text = _cliente.Direccion.ToString();
            }
        }

        private void pbAceptar_Click(object sender, EventArgs e)
        {
            if (txtNit.Text.Length == 0)
            {
                errorNit.SetError(txtNit, "Ingrese un nombre o CF");
                return;
            }
            if (txtNombre.Text.Length == 0)
            {
                errorNombre.SetError(txtNombre, "Ingrese un nombre o CF");
                return;
            }            
            GuardarCliente();
            Close();
        }

        private void pbCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BuscarCienteBD()
        {
            var cliente = _clientesRepository.GetClienteByNit(txtNit.Text.Trim());
            if (cliente != null)
            {
                txtNombre.Text = cliente.Apellidos + "," + cliente.Nombres;
                txtDireccion.Text = cliente.Direccion;
            }
            else
            {
                MessageBox.Show("¡Falló la búsqueda, no posee conexión a Internet\n o no se obtuvo el cliente!", "Notificación");
            }
        }
        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try
                {
                    if (conectado)
                    {
                        if (TokenObtenidoSat.Token != null)
                        {
                            var clienteobtenidoSAT = ValidaClienteSat.GetClientbyNit(TokenObtenidoSat.Token, txtNit.Text.Trim());
                            Root clienteSAT = JsonConvert.DeserializeObject<Root>(clienteobtenidoSAT);
                            foreach (var item in clienteSAT.RESPONSE)
                            {
                                txtNit.Text = item.NIT;
                                txtNombre.Text = item.NOMBRE;
                                var direcc = item.DEPARTAMENTO + ", " + item.MUNICIPIO + ", " + item.PAIS;
                                txtDireccion.Text = direcc;

                                clientesx = new RESPONSE
                                {
                                    NOMBRE = item.NOMBRE,
                                    NIT = item.NIT,
                                    DEPARTAMENTO = item.DEPARTAMENTO,
                                    Direccion = item.Direccion,
                                    MUNICIPIO = item.MUNICIPIO,
                                    PAIS = item.PAIS,
                                };
                            }
                        }
                        else
                        {
                            BuscarCienteBD();
                        }
                    }
                    else
                    {
                        BuscarCienteBD();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error en obtener datos del cliente.\n" + ex.Message, "ERROR");
                }
            }
        
               
        }

        private void GuardarCliente() 
        {
            try
            {
                var cliente = _clientesRepository.GetClienteByNit(txtNit.Text.Trim());
                if (cliente == null)
                {
                    if (txtNombre.Text.Contains(","))
                    {
                        string[] nombreCompleto = txtNombre.Text.Split(',');
                        int tam = nombreCompleto.Length - 1;
                        _cliente = new Cliente
                        {
                            Nombres = nombreCompleto[tam - 1] + " " + nombreCompleto[tam],
                            CodigoCliente = GenerateRandom(),
                            Apellidos = nombreCompleto[0] + " " + nombreCompleto[1],
                            Telefonos = "",
                            Nit = txtNit.Text,
                            Direccion = txtDireccion.Text,
                            Alias = nombreCompleto[tam],
                            TiposId = _tipocliente,
                            CategoriaId = 1,
                            SucursalId = UsuarioLogeadoPOS.User.SucursalId,
                            IsActive = false,
                            FechaCreacion = DateTime.Now,
                            PermitirCredito = true,
                            DPI = ""
                        };
                    }
                    else
                    {
                        _cliente = new Cliente
                        {
                            Nombres = txtNombre.Text,
                            CodigoCliente = "CL-" + GenerateRandom(),
                            Apellidos = txtNombre.Text,
                            Telefonos = "",
                            Nit = txtNit.Text,
                            Direccion = txtDireccion.Text,
                            TiposId = _tipocliente,
                            CategoriaId = 1,
                            SucursalId = UsuarioLogeadoPOS.User.SucursalId,
                            IsActive = false,
                            FechaCreacion = DateTime.Now,
                            PermitirCredito = true,
                            DPI = ""
                        };
                    }                    
                    _clientesRepository.Add(_cliente);
                    _cliente = _clientesRepository.GetClienteByNit(txtNit.Text.Trim());
                    CrearCuentabyCobrar(_cliente.Id);                    
                    _pos._cliente = _cliente;
                }
                else
                {
                    _cliente = cliente;
                    _pos._cliente = _cliente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡No se ha podido guardar la información del cliente! \n"+ex.Message, "Notificación");
            }
             
        }

        public string GenerateRandom()
        {
            Random randomGenerate = new System.Random();
            var cadena = System.Convert.ToString(randomGenerate.Next(0000001, 9999999));
            return cadena;
        }        

        private void CrearCuentabyCobrar(int idcliente)
        {
            string tipocuenta = "CC-";
            string numerocuenta;
            do
            {
                numerocuenta = GenerateRandom();
            }

            while (ExisteCuenta(numerocuenta));

            var cuentatosend = cuentaNueva();
            cuentatosend.NoCuenta = tipocuenta+numerocuenta;
            cuentatosend.ClienteId = idcliente;
            _cuentasCobrarRepository.Add(cuentatosend);
        }

        private bool ExisteCuenta(string cadena)
        {
            var cuenta = _cuentasCobrarRepository.GetCcbyNocuenta(cadena);
            if (cuenta == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private CuentaCB cuentaNueva()
        {
            return new CuentaCB()
            {
                Id = Guid.NewGuid(),
                FechaCreacion = DateTime.Now,
                SaldoActual = 0,
                SucursalId = UsuarioLogeadoPOS.User.SucursalId,
            };
        }
    }
}
