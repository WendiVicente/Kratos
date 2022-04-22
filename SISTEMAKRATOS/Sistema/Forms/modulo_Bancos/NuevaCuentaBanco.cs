using CapaDatos.Models.Bancos;
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

namespace Sistema.Forms.modulo_Bancos
{
    public partial class NuevaCuentaBanco : BaseContext
    {
        CuentasRepository _cuentasRepository = null;
        PropiedadesRepository _propiedadesRepository = null;
        public NuevaCuentaBanco()
        {
            _cuentasRepository = new CuentasRepository(_context);
            _propiedadesRepository = new PropiedadesRepository(_context);
            InitializeComponent();
        }

        private void NuevaCuentaBanco_Load(object sender, EventArgs e)
        {
            CargarBancos();
            CargarTipocambio();

        }
        private void CargarBancos()
        {
            var bancos = _propiedadesRepository.GetListBancos();
            comboBanco.DataSource = bancos;
            comboBanco.DisplayMember = "Entidad";
            comboBanco.ValueMember = "Id";
            comboBanco.SelectedIndex = 0;
            comboBanco.Invalidate();

        }

        private void CargarTipocambio()
        {
            string[] tipos = {
                "Dolares", "Quetzales", "Euros"
            };

            var listatipos = new List<string>(tipos);

            foreach (var item in listatipos)
            {
                ComboMoneda.Items.Add(item);

            }
            ComboMoneda.SelectedIndex = 0;

        }


        private CuentaBanco GetCuentaNueva()
        {
            return new CuentaBanco()
            {
                Id = Guid.NewGuid(),
                NombreCuenta= txtnombrecuenta.Text,
                NumeroCuenta= txtnumerocuenta.Text,
                TipoCuenta= txttipocuenta.Text,
                Diaria= checkdiaria.Checked,
                Semanal= checksemanal.Checked,
                Mensual= checkmensual.Checked,
                Anual= checkanual.Checked,
                BancaId= int.Parse(comboBanco.SelectedValue.ToString()),
                Empresa= txtempresa.Text,
                MontoInicial= decimal.Parse(txtmontoinicial.Text),
               // Moneda= ComboMoneda.Text,
                



            };

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            var cuentatosave = GetCuentaNueva();

            if (!ModelState.IsValid(cuentatosave)) { return; }

           if (ValidarCuenta())
            {
                KryptonMessageBox.Show("El número de cuenta ya está almacenado \n debe ingresar uno nuevo!");
            }
            else
            {
                _cuentasRepository.Add(cuentatosave);
                KryptonMessageBox.Show("Registro Guardado con éxito!");
            }


            

        }
        private bool ValidarCuenta()
        {
            var cuentaobtenida = _cuentasRepository.GetNoCuenta(txtnumerocuenta.Text);
            if (cuentaobtenida != null)
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        private void checktodas_CheckedChanged(object sender, EventArgs e)
        {
            if (checktodas.Checked == true)
            {
                MarcarCheckes();
            }
            else
            {
                DesMarcarcheckes();
            }
        }

        private void MarcarCheckes()
        {
            checkdiaria.Checked = true;
            checksemanal.Checked = true;
            checkmensual.Checked = true;
            checkanual.Checked = true;

        }
        private void DesMarcarcheckes()
        {
            checkdiaria.Checked = false;
            checksemanal.Checked = false;
            checkmensual.Checked = false;
            checkanual.Checked = false;

        }

    }
}
