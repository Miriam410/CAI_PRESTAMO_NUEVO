using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer_Datos;
using NLayer_Entidades;

namespace NLayer_Negocio
{
    public class PrestamoServicio
    {
        private PrestamoMapper mapper;

        public PrestamoServicio()
        {
            mapper = new PrestamoMapper();
        }

        public List<Prestamo> TraerTodos()
        {
            List<Prestamo> result = mapper.TraerTodos();
            return result;
        }

        public int Insertar(Prestamo prestamo)
        {
            List<Prestamo> listaPrestamo = mapper.TraerTodos();
            TransactionResult resultado = mapper.Insert(prestamo);
            if (resultado.IsOk)
            {
                return resultado.Id;
            }
            else
            {
                throw new Exception("Error en la petición al servicio");
            }
        }
    }
}
