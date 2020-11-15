using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Configuration;

namespace NLayer_Entidades
{
    //para serealizar o deserializar
    [DataContract] 
    public class Prestamo
    {
        private TipoPrestamo _tipoPrestamo;
        private int _plazo;
        private double _monto;
        private string _usuario = ConfigurationManager.AppSettings["Registro"];
        private int _id;

        /*aplica DataMember a las variables por propiedades 
        que se va a utilizar para serializar o deserializar
        */

        [DataMember] 
        public TipoPrestamo TipoPrestamo
        {
            get { return this._tipoPrestamo; }
            set { this._tipoPrestamo = value; }
        }
        [DataMember]
        public int Plazo
        {
            get { return this._plazo; }
            set { this._plazo = value; }
        }
        [DataMember]
        public double Monto
        {
            get { return this._monto; }
            set { this._monto = value; }
        }
        [DataMember]
        public string Usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }
        }
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public Prestamo(TipoPrestamo tipoPrestamo, int plazo, double monto)
        {
            this._tipoPrestamo = tipoPrestamo;
            this._plazo = plazo;
            this._monto = monto;
        }
        public Prestamo()
        { 
        }
        public double CuotaCapital()
        {
            return _monto / _plazo;
        }

        public double CuotaInteres()
        {
            return (CuotaCapital() * ((_tipoPrestamo.Tna) * 100 / 12));
        }
        public double CuotaTotal()
        {
            return CuotaCapital() + CuotaInteres();
        }

    }
}
