using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDatosOcupacion
    {
        static clsNOcupacion transformar(OCUPACION newOcupacxion)
        {
            clsNOcupacion ocupacion = new clsNOcupacion();
            ocupacion.IdAlimentacion2 = newOcupacxion.IDALIMENTACION2;
            ocupacion.EstadoTipoPregunta = int.Parse(newOcupacxion.ESTADOTIPOPREGUNTA.ToString());
            ocupacion.FechaTipoPregunta = DateTime.Parse(newOcupacxion.FECHATIPOPREGUNTA.ToString());
            ocupacion.Nombre = newOcupacxion.NOMBRE;
            return ocupacion;
        }
        MERSembrarDataContext bd = new MERSembrarDataContext();
        public object consultarOcupacion()
        {
            try
            {
                var consulta = from o in bd.OCUPACION
                               select new
                               {
                                   ID_OCUPACION = o.IDALIMENTACION2,
                                   NOMBRE = o.NOMBRE
                               };
                return consulta.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
