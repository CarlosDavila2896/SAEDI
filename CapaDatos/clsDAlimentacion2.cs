using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDAlimentacion2
    {
        static clsNOcupacion transformar(OCUPACION newOcupacxion)
        {
            clsNOcupacion ocupacion = new clsNOcupacion();
            ocupacion.idAlimentacion2 = newOcupacxion.IDALIMENTACION2;
            ocupacion.EstadoTipoPregunta = int.Parse(newOcupacxion.ESTADOTIPOPREGUNTA.ToString());
            ocupacion.FechaTipoPregunta = DateTime.Parse(newOcupacxion.ESTADOTIPOPREGUNTA.ToString());
            ocupacion.Nombre = newOcupacxion.NOMBRE;
            return ocupacion;
        }

        public object D_consultarOcupacion()
        {
            using(MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.OCUPACION.ToList();
            }
        }
    }
}
