using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class clsDAlimentacion2
    {
        public object D_consultarOcupacion()
        {
            using(MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.OCUPACION.ToList();
            }
        }
    }
}
