using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Validations
{
    public class GenerarNumeroAleatorio
    {

        public static string GenerateRandom(string tipo)
        {
            Random randomGenerate = new System.Random();
            string nocuenta = tipo;
            var cadena = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            var resulto = String.Concat(nocuenta, cadena);
            return resulto;//Substring(resulto.Length - 11, 11);

        }

    }

   
}
