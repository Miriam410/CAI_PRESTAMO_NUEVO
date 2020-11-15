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
    public class TipoPrestamoMapper
    {
        private string _endpointPath = "/prestamotipo";

        public List<TipoPrestamo> TraerTodos()
        {
            string json = WebHelper.Get(this._endpointPath);
            List<TipoPrestamo> resultado = MapList(json);
            return resultado;
        }

        public TransactionResult Insert(TipoPrestamo tipoPrestamo)
        {
            NameValueCollection obj = ReverseMap(tipoPrestamo);
            string result = WebHelper.Post(this._endpointPath, obj);
            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }
        public List<TipoPrestamo> MapList(string json)
        {
            List<TipoPrestamo> lst= JsonConvert.DeserializeObject<List<TipoPrestamo>>(json);
            return lst;
        }
       
        private NameValueCollection ReverseMap(TipoPrestamo tipoPrestamo)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Linea", tipoPrestamo.Linea);
            n.Add("Tna",tipoPrestamo.Tna.ToString()); //double
            return n;
        }

        public TransactionResult MapResultado(string json)
        {
            TransactionResult lst= JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }
    }
}
