using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDRelacionPR_LA_ORI
    {
        //Metodo de agregar nueva relacion entre linea de accion, proceso, orientador y periodo
        public bool D_ingresarRelacionLA_PR_OR_PER(clsNRelacionPR_LA_ORI nuevaRelacion)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    ORIENTADORACARGODEPROCESOENPERIODO relacion = new ORIENTADORACARGODEPROCESOENPERIODO();
                    relacion.IDLINEADEACCION = nuevaRelacion.IDLINEADEACCION;
                    relacion.IDORIENTADOR = nuevaRelacion.IDORIENTADOR;
                    relacion.IDPROCESO = nuevaRelacion.IDPROCESO;
                    relacion.IDPERIODO = nuevaRelacion.IDPERIODO;
                    relacion.OBSERVACION = nuevaRelacion.OBSERVACIONRELACION;

                    db.ORIENTADORACARGODEPROCESOENPERIODO.InsertOnSubmit(relacion);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de relaciones linea de accion, proceso, orientador y periodo filtradas por parametros
        public List<ORIENTADORACARGODEPROCESOENPERIODO> D_consultarRelacionLA_PR_OR_PERFiltrada(int idLineaAccion, int idProceso, int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                if (idLineaAccion == 0)
                {
                    return db.ORIENTADORACARGODEPROCESOENPERIODO.ToList();
                }
                else if (idLineaAccion > 0 && idProceso == 0)
                {
                    return db.ORIENTADORACARGODEPROCESOENPERIODO.Where(x => x.IDLINEADEACCION == idLineaAccion).ToList();
                }
                else if (idLineaAccion > 0 && idProceso > 0 && idOrientador == 0)
                {
                    return db.ORIENTADORACARGODEPROCESOENPERIODO.Where(x => x.IDLINEADEACCION == idLineaAccion && x.IDPROCESO == idProceso).ToList();
                }
                else if (idLineaAccion > 0 && idProceso > 0 && idOrientador > 0)
                {
                    return db.ORIENTADORACARGODEPROCESOENPERIODO.Where(x => x.IDLINEADEACCION == idLineaAccion && x.IDPROCESO == idProceso && x.IDORIENTADOR == idOrientador).ToList();
                }
                else
                {
                    return new List<ORIENTADORACARGODEPROCESOENPERIODO>();
                }
            }
        }

        //Metodo de eliminacion de relaciones linea de accion, proceso, orientador y periodo
        public bool D_eliminarRelacionLA_PR_OR_PER(ORIENTADORACARGODEPROCESOENPERIODO eliminarRelacion)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    ORIENTADORACARGODEPROCESOENPERIODO relacion = (from r in db.ORIENTADORACARGODEPROCESOENPERIODO where r.IDLINEADEACCION == eliminarRelacion.IDLINEADEACCION && r.IDPROCESO == eliminarRelacion.IDPROCESO && r.IDORIENTADOR == eliminarRelacion.IDORIENTADOR && r.IDPERIODO == eliminarRelacion.IDPERIODO select r).First();
                    db.ORIENTADORACARGODEPROCESOENPERIODO.DeleteOnSubmit(relacion);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de edicion de relaciones linea de accion, proceso, orientador y periodo
        public bool D_editarRelacionLA_PR_OR_PER(ORIENTADORACARGODEPROCESOENPERIODO editarRelacion)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    ORIENTADORACARGODEPROCESOENPERIODO relacion = db.ORIENTADORACARGODEPROCESOENPERIODO.Single(u => u.IDLINEADEACCION == editarRelacion.IDLINEADEACCION && u.IDPROCESO == editarRelacion.IDPROCESO && u.IDORIENTADOR == editarRelacion.IDORIENTADOR && u.IDPERIODO == editarRelacion.IDPERIODO);
                    relacion.IDLINEADEACCION = editarRelacion.IDLINEADEACCION;
                    relacion.IDORIENTADOR = editarRelacion.IDORIENTADOR;
                    relacion.IDPROCESO = editarRelacion.IDPROCESO;
                    relacion.IDPERIODO = editarRelacion.IDPERIODO;
                    relacion.OBSERVACION = editarRelacion.OBSERVACION;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
