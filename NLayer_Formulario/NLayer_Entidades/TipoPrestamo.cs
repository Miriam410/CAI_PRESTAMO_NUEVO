using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NLayer_Entidades
{
    [DataContract]
    public class TipoPrestamo
    {
        
        private string _linea;
        private double _tna;
        [DataMember]
        public string Linea
        {
            get { return _linea; }
            set { _linea = value; }
        }
        [DataMember]
        public double Tna
        {
            get{ return _tna; }
            set { _tna = value; }
        }
    }
}
