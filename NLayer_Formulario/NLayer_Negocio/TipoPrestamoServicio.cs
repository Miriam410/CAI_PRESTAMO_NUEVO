using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer_Datos;
using NLayer_Entidades;

namespace NLayer_Negocio
{
    public class TipoPrestamoServicio
    {
        private TipoPrestamoMapper mapper;

        public TipoPrestamoServicio()
        {
            mapper = new TipoPrestamoMapper();
        }

        public List<TipoPrestamo> TraerTodos()
        {
            List<TipoPrestamo> result = mapper.TraerTodos();
            return result;
        }

        public int Insertar(TipoPrestamo tipoPrestamo)
        {
            List<TipoPrestamo> ListaTipoPrestamo = mapper.TraerTodos();
            TransactionResult resultado = mapper.Insert(tipoPrestamo);
            if (resultado.IsOk)
            {
                return resultado.Id;
            }
            else 
            {
                throw new Exception("Hubo un error en la petición");
            }
        }
    }
}
