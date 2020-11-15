using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer_Entidades;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;

namespace NLayer_Datos
{
    public class PrestamoMapper
    {
        private string _endpointPath = "/prestamo";
        private string _endpointPath1 = "/prestamo/{registro}";

        public List<Prestamo> TraerTodos()
        {
            string json = WebHelper.Get(this._endpointPath1);
            List<Prestamo> resultado = MapList(json);
            return resultado;
        }

        public TransactionResult Insert(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);
            string result = WebHelper.Post(this._endpointPath,obj);
            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }
        public  List<Prestamo> MapList(string json)
        {
            List<Prestamo> lst = JsonConvert.DeserializeObject<List<Prestamo>>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(Prestamo prestamo)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Plazo",prestamo.Plazo.ToString()); //double
            n.Add("Monto",prestamo.Monto.ToString()); //double
            n.Add("CuotaTotal",prestamo.CuotaTotal().ToString()); //double
            return n;
        }

       
        private TransactionResult MapResultado(string json)
        {
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }
    }
}
