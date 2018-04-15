using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDatosOrientador
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();
        public object consultarOrientador()
        {
            try
            {
                var consulta = from o in bd.ORIENTADOR
                               select new
                               {
                                   ID_ORIENTADOR = o.IDORIENTADOR,
                                   NOMBRE = o.NOMBREORIENTADOR + " " + o.APELLIDOORIENTADOR
                               };
                return consulta.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Maetodo de consulta de orientadores asociados
        public object D_consutarOrientadoresActivosAsociados(int idLineaAccion, int idProceso)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var orientadores = from or in db.ORIENTADOR
                               join r in db.ORIENTADORACARGODEPROCESOENPERIODO on or.IDORIENTADOR equals r.IDORIENTADOR
                               where r.IDLINEADEACCION == idLineaAccion && r.IDPROCESO == idProceso
                               select new
                               {
                                   IDORIENTADOR = or.IDORIENTADOR,
                                   NOMBREORIENTADOR = or.NOMBREORIENTADOR + " " + or.APELLIDOORIENTADOR
                               };


                return orientadores.ToList();
            }
        }
    }
}
