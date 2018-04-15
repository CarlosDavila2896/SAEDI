using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class clsDTipoAsistente
    {
        public object D_consultarTipoAsistentes()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var tipo = from la in db.TIPOASISTENTES
                                     select new
                                     {
                                         IDTIPO = la.IDTIPOASISTENTES,
                                         NOMBRE = la.NOMBRETIPOASISTENTES
                                     };


                return tipo.Distinct().ToList();
            }
        }
    }
}
