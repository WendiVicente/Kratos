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

namespace POS.Forms
{
    public partial class IngresoToken : BaseContext
    {
        int _tokenValidar = 0;
        bool _cobrar = false;
        PuntoDeVenta _pos = null;
        bool _limpiar = true;
        public IngresoToken(int token, PuntoDeVenta pos,  bool cobrar)
        {
            _tokenValidar = token;
            _pos = pos;
            _cobrar = cobrar;
            InitializeComponent();
        }

        private void pbAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtToken.Text) || txtToken.Text == "0" || !Int32.TryParse(txtToken.Text, out var numberStyles))
            {
                MessageBox.Show("¡Token ingresado inválido!");
                return;
            }
            else
            {
                int tm = Convert.ToInt32(txtToken.Text);
                if (tm == _tokenValidar)
                {
                    
                    MessageBox.Show("¡Validación de Token exitosa!");
                    _pos.validacionToken = true;
                    _limpiar = false;
                    Hide();
                    if (_cobrar)
                    {
                        if (_pos.ValidarCuentaxCobrar())                        
                        {
                            _pos.GuardarVenta(true);
                            //_pos.CargarDatos();
                            //_pos.LimpiarGridListado();
                        }                                              
                    }
                    _pos.validacionToken = true;
                    Close();
                }
                else 
                {
                    MessageBox.Show("¡Token ingresado inválido!");
                    _pos.validacionToken = false;
                    _limpiar = true;
                    return;
                }
            }
        }

        private void pbCancelar_Click(object sender, EventArgs e)
        {
            _pos.validacionToken = false;
            _pos.Actualizar();
            _pos.CargarDatos();
            _pos.LimpiarGridListado();
            _limpiar = false; 
            Close();
        }

        private void IngresoToken_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_limpiar)
            {
                _pos.validacionToken = false;
                _pos.Actualizar();
                _pos.CargarDatos();
                _pos.LimpiarGridListado();
            }
        }
    }
}
