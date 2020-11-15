using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Entidades
{
    public class Operador
    {
        private List<Prestamo> _prestamo;
        private double _comision;

        public Operador (double comision)
        {
            _prestamo = new List < Prestamo >() ;
        }
        
        public double Comision()
        {
            double interes = 0;
            foreach (Prestamo p in _prestamo)
            {
                interes += p.CuotaInteres();
            }
            return interes*0.15;
        }


    }
}
