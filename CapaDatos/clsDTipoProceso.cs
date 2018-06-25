using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class clsDTipoProceso
    {
        public List<TIPOPROCESO> obtenerTiposProceso()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.TIPOPROCESO.ToList();
            }
        }
    }
}
