using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Calculadora : BaseContext
    {
        decimal valor1, valor2;
        //variables
        double primero, segundo, resultado;
        string operacion;

        private const char SignoDecimal = '.'; // Carácter separador decimal
        private string _prevTextBoxValue; // Variable que almacena el valor anterior del Textbox

        public Calculadora()
        {
            InitializeComponent();
            txtcalculador.Focus();
        }

        private void concatenarNumeros(string numero)
        {
            var actual = txtcalculador.Text;
            string contenido = actual + numero;
            if (txtcalculador.Text != "")
                txtcalculador.Text = contenido;
            valor1 = Convert.ToDecimal(contenido);
        }
        private void concatenarNumeroSegundo(string numero)
        {
            var actual = txtcalculador.Text;
            string contenido = actual + numero;
            if (txtcalculador.Text != "")
                txtcalculador.Text = contenido;
            valor2 = Convert.ToDecimal(contenido);
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            //concatenarNumeros("1");
            IngresaNumero(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            IngresaNumero(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            IngresaNumero(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            IngresaNumero(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            IngresaNumero(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            IngresaNumero(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            IngresaNumero(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            IngresaNumero(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            IngresaNumero(9);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            IngresaNumero(0);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtcalculador.Text = "";
        }


        private void btnmenos_Click(object sender, EventArgs e)
        {

            operacion = "-";
            if (txtcalculador.Text != "")
                primero = double.Parse(txtcalculador.Text);
            txtcalculador.Clear();
        }

        private void btnmas_Click(object sender, EventArgs e)
        {
            operacion = "+";
            if (txtcalculador.Text != "")
                primero = double.Parse(txtcalculador.Text);
            txtcalculador.Clear();
        }

        private void btndivi_Click(object sender, EventArgs e)
        {
            operacion = "/";
            if (txtcalculador.Text != "")
                primero = double.Parse(txtcalculador.Text);
            txtcalculador.Clear();
        }

        private void Calculadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                    btn1.PerformClick();
                    break;
                case '2':
                    btn2.PerformClick();
                    break;
                case '3':
                    btn3.PerformClick();
                    break;
                case '4':
                    btn4.PerformClick();
                    break;
                case '5':
                    btn5.PerformClick();
                    break;
                case '6':
                    btn6.PerformClick();
                    break;
                case '7':
                    btn7.PerformClick();
                    break;
                case '8':
                    btn8.PerformClick();
                    break;
                case '9':
                    btn9.PerformClick();
                    break;
                case '0':
                    btn0.PerformClick();
                    break;
                case '+':
                    btnmas.PerformClick();
                    break;
                case '-':
                    btnmenos.PerformClick();
                    break;
                case '/':
                    btndivi.PerformClick();
                    break;
                case '*':
                    btnMulti.PerformClick();
                    break;
                case '=':
                    btnigual.PerformClick();
                    break;
                case (char)8:
                    Backspace();
                    break;
                case '.':
                    btnpunto.PerformClick();
                    break;
                case (char)13:
                    btnigual.PerformClick();
                    break;
            }

        }

        private void Backspace()
        {
            if (txtcalculador.Text != "")
            {
                string r = txtcalculador.Text;
                txtcalculador.Text = r.Remove(r.Length - 1, 1);
            }

        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            operacion = "*";
            if (txtcalculador.Text != "")
                primero = double.Parse(txtcalculador.Text);
            txtcalculador.Clear();
        }

        private void txtcalculador_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            // Comprueba si el valor del TextBox se ajusta a un valor válido
            if (Regex.IsMatch(textBox.Text, @"^(?:\d+\.?\d*)?$"))
            {
                // Si es válido se almacena el valor actual en la variable privada
                _prevTextBoxValue = textBox.Text;
            }
            else
            {
                // Si no es válido se recupera el valor de la variable privada con el valor anterior
                // Calcula el nº de caracteres después del cursor para dejar el cursor en la misma posición
                var charsAfterCursor = textBox.TextLength - textBox.SelectionStart - textBox.SelectionLength;
                // Recupera el valor anterior
                textBox.Text = _prevTextBoxValue;
                // Posiciona el cursor en la misma posición
                textBox.SelectionStart = Math.Max(0, textBox.TextLength - charsAfterCursor);
            }
        }

        private void txtcalculador_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            // Si el carácter pulsado no es un carácter válido se anula
            e.Handled = !char.IsDigit(e.KeyChar) // No es dígito
                        && !char.IsControl(e.KeyChar) // No es carácter de control (backspace)
                        && (e.KeyChar != SignoDecimal // No es signo decimal o es la 1ª posición o ya hay un signo decimal
                            || textBox.SelectionStart == 0
                            || textBox.Text.Contains(SignoDecimal));
        }

        private void Calculadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnC.PerformClick();
            }
        }

        private void btnpunto_Click(object sender, EventArgs e)
        {
            txtcalculador.Text = txtcalculador.Text + ".";
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            if (txtcalculador.Text != "")
                segundo = double.Parse(txtcalculador.Text);


            switch (operacion)
            {
                case "+":
                    resultado = primero + segundo;
                    txtcalculador.Text = resultado.ToString();
                    break;
                case "-":
                    resultado = primero - segundo;
                    txtcalculador.Text = resultado.ToString();
                    break;
                case "/":
                    resultado = primero / segundo;
                    txtcalculador.Text = resultado.ToString();
                    break;
                case "*":
                    resultado = primero * segundo;
                    txtcalculador.Text = resultado.ToString();
                    break;
            }
        }

        private void IngresaNumero(int num)
        {
            txtcalculador.Text = txtcalculador.Text + num;
            btnigual.Focus();
        }


    }
}
