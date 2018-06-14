using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDLineaAccion
    {
        static clsNLineaAccion transformar(LINEADEACCION newLinea)
        {
            clsNLineaAccion linea = new clsNLineaAccion();
            linea.IDLINEA = newLinea.IDLINEADEACCION;
            linea.NOMBRELINEAACCION = newLinea.NOMBRELINEADEACCION;
            linea.DESCRIPCIONLINEAACCION = newLinea.DESCRIPCIONLINEADEACCION;
            linea.IDTIPOPERSONA = newLinea.IDTIPOPERSONA;
            return linea;
        }

        //Metodo de creacion de linea de accion
        public bool D_ingresarLineadeAccion(clsNLineaAccion nuevaLineaDeAccion)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    LINEADEACCION lineadeaccion = new LINEADEACCION();
                    lineadeaccion.NOMBRELINEADEACCION = nuevaLineaDeAccion.NOMBRELINEAACCION;
                    lineadeaccion.DESCRIPCIONLINEADEACCION = nuevaLineaDeAccion.DESCRIPCIONLINEAACCION;
                    lineadeaccion.IDTIPOPERSONA = nuevaLineaDeAccion.IDTIPOPERSONA;

                    db.LINEADEACCION.InsertOnSubmit(lineadeaccion);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de lineas de accion
        public List<LINEADEACCION> D_consultarLineasDeAccion()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.LINEADEACCION.ToList();
            }
        }

        //Metodo de eliminacion de linea de accion
        public bool D_eliminarLineaDeAccion(LINEADEACCION eliminarLineaDeAccion)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    LINEADEACCION lineadeaccion = (from la in db.LINEADEACCION where la.IDLINEADEACCION == eliminarLineaDeAccion.IDLINEADEACCION select la).First();
                    db.LINEADEACCION.DeleteOnSubmit(lineadeaccion);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de edicion de las lineas de accion
        public bool D_editarLineasDeAccion(LINEADEACCION editarLineaDeAccion)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    LINEADEACCION lineadeaccion = db.LINEADEACCION.Single(u => u.IDLINEADEACCION == editarLineaDeAccion.IDLINEADEACCION);
                    lineadeaccion.NOMBRELINEADEACCION = editarLineaDeAccion.NOMBRELINEADEACCION;
                    lineadeaccion.DESCRIPCIONLINEADEACCION = editarLineaDeAccion.DESCRIPCIONLINEADEACCION;
                    lineadeaccion.IDTIPOPERSONA = editarLineaDeAccion.IDTIPOPERSONA;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de lineas de accion activas ordenadas
        public List<LINEADEACCION> D_consultarLineasDeAccionActivasOrdenadas()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.LINEADEACCION.OrderBy(x => x.NOMBRELINEADEACCION).ToList();
            }
        }

        //Maetodo de consulta de linea de accion asociada
        public object D_consutarLineasDeAccionAsociadas()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var lineasdeaccion = from la in db.LINEADEACCION
                                     join r in db.ORIENTADORACARGODEPROCESOENPERIODO on la.IDLINEADEACCION equals r.IDLINEADEACCION                                     
                                     select new
                                     {
                                         IDLINEAACCION = la.IDLINEADEACCION,
                                         NOMBRELINEAACCION = la.NOMBRELINEADEACCION
                                     };


                return lineasdeaccion.Distinct().ToList().OrderBy(a => a.NOMBRELINEAACCION).ToList();
            }
        }

        public object D_consutarLineasDeAccionAsociadasConOrientador(int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var lineasdeaccion = from la in db.LINEADEACCION
                                     join r in db.ORIENTADORACARGODEPROCESOENPERIODO on la.IDLINEADEACCION equals r.IDLINEADEACCION
                                     where r.IDORIENTADOR == idOrientador
                                     select new
                                     {
                                         IDLINEAACCION = la.IDLINEADEACCION,
                                         NOMBRELINEAACCION = la.NOMBRELINEADEACCION
                                     };


                return lineasdeaccion.Distinct().ToList().OrderBy(a => a.NOMBRELINEAACCION).ToList();
            }
        }

    }
}
