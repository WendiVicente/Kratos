using CapaDatos.Models.CuentaCobrar;
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

namespace POS.Forms.Complementos
{
    public partial class NuevoCliente : BaseContext
    {
        private readonly ClientesRepository _clientesRepository = null;
        private readonly CuentasCobrarRepository _cuentasCobrarRepository = null;
        public NuevoCliente()
        {
            _clientesRepository = new ClientesRepository(_context);
            _cuentasCobrarRepository = new CuentasCobrarRepository(_context);
            InitializeComponent();
            cargarcodigocliente();


        }

        private void cargarcodigocliente()
        {
            string tipocl = "CL-";
            string codigocliente;
            do
            {
                codigocliente = GenerateRandom(tipocl);
            }

            while (ExisteCliente(codigocliente));

            txtcodigocliente.Text = codigocliente;
        }



        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            var model = GetViewModel();
            
            if(ModelState.IsValid(model))
            {
                try
                {
                    var idclienteactual= _clientesRepository.Add(model);
                    if (checkcredito.Checked == true)
                    {
                        CrearCuentabyCobrar(idclienteactual);
                    }
                    else
                    {
                        KryptonMessageBox.Show("Registro guardado correctamente!");
                    }
                   
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

        public Cliente GetViewModel()
        {
            return new Cliente()
            {
                Nombres = kryptonTextBox1.Text,
                CodigoCliente= txtcodigocliente.Text,
                Apellidos = kryptonTextBox2.Text,
                Telefonos = kryptonTextBox3.Text,
                Nit = kryptonTextBox4.Text,
                Direccion = kryptonTextBox5.Text,
                Alias = kryptonTextBox6.Text,
                TiposId = int.Parse(cbtipoCliente.SelectedValue.ToString()),
                FechaCreacion = DateTime.Now,
                PermitirCredito=checkcredito.Checked,
                DPI= txtdpi.Text,
                SucursalId= UsuarioLogeadoPOS.User.SucursalId                
            };
        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {
            CargarTipos();
        }

        public void CargarTipos()
        {
            cbtipoCliente.DataSource = _clientesRepository.GetTipos();
            cbtipoCliente.DisplayMember = "TipoCliente";
            cbtipoCliente.ValueMember = "Id";
            cbtipoCliente.Invalidate();
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

        private void CrearCuentabyCobrar(int idcliente)
        {
            string tipocuenta = "CC-";
            string numerocuenta;
            do
            {
                numerocuenta = GenerateRandom(tipocuenta);
            }

            while (ExisteCuenta(numerocuenta));

            var cuentatosend = cuentaNueva();
            cuentatosend.NoCuenta = numerocuenta;
            cuentatosend.ClienteId = idcliente;
            _cuentasCobrarRepository.Add(cuentatosend);

            KryptonMessageBox.Show("Registro Guardado Correctamente");
            Close();

        }
        public string GenerateRandom(string tipo)
        {
            Random randomGenerate = new System.Random();
            string nocuenta = tipo;
            var cadena = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            var resulto = String.Concat(nocuenta, cadena);
            return resulto;//Substring(resulto.Length - 11, 11);
           
           
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
        private bool ExisteCliente(string cadena)
        {
            var cliente = _clientesRepository.GetByCodigoNew(cadena);
            if (cliente == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
