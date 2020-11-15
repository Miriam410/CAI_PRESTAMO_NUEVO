using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Negocio.ValidacionHelper
{
    public static class Validacion
    {
        /*validación generica de monto y plazo, para no tener 
        que escribir el mismo código 
        */
        public  static bool Validar(string monto, string plazo)
        {
            bool Flag = true;
            string msg = "";

            msg += ValidarNumero(monto, "Monto");
            msg += ValidarNumero(plazo, "Plazo");

            if(!string.IsNullOrEmpty(msg))
            {
                msg = "Error de dato";
                Flag = false;
            }
            return Flag;
        }

        //validación de número que se utiliza 2 veces
        public static string ValidarNumero(string numero, string campo)
        {
            string msg;
            if (!double.TryParse(numero, out double Num))
            {
                msg = "El campo" + campo + "debe ser numerico";
            }
            else if (Num < 0)
            {
                msg = "El campo" + campo + "debe ser un numero positivo";
            }
            else 
            {
                msg = "";
            }
            return msg;
        }
    }
}
