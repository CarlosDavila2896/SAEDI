using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDatosOcupacion
    {
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
