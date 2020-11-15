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

            msg += ValidarDouble(monto, "Monto");
            msg += ValidarInt(plazo, "Plazo");

            if(!string.IsNullOrEmpty(msg))
            {
                msg = "Error de dato";
                Flag = false;
            }
            return Flag;
        }

        //validación de número de double e int
        public static string ValidarDouble(string numero, string campo)
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
        public static string ValidarInt(string numero, string campo)
        {
            string msg;
            if (!int.TryParse(numero, out int Numint))
            {
                msg = "El campo" + campo + "debe ser numerico";
            }
            else if (Numint < 0)
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
