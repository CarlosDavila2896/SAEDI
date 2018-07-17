using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Transactions;

namespace CapaDatos
{
    public class clsDSolucionCuestionario
    {
        static clsNSolucionCuestionario transformar(SOLUCIONCUESTIONARIO newSolucion)
        {
            clsNSolucionCuestionario solucion = new clsNSolucionCuestionario();
            solucion.FECHAMODIFICACIONCUESTIONARIO = DateTime.Parse(newSolucion.FECHAMODIFICACIONCUESTIONARIO.ToString());
            solucion.FECHASOLUCIONCUESTIONARIO = newSolucion.FECHASOLUCIONCUESTIONARIO;
            solucion.IDINDICADOR = newSolucion.IDINDICADOR;
            solucion.IDOBJETIVO = newSolucion.IDOBJETIVO;
            solucion.IDPERIODO = newSolucion.IDPERIODO;
            solucion.IDPERSONA = newSolucion.IDPERSONA;
            solucion.IDPREGUNTA = newSolucion.IDPREGUNTA;
            solucion.IDPROCESO = newSolucion.IDPROCESO;
            solucion.IDSOLUCION = newSolucion.IDSOLUCIONCUESTIONARIO;
            solucion.TEXTOSOLUCIONCUESTIONARIO = newSolucion.TEXTOSOLUCIONCUESTIONARIO;
            return solucion;
        }
        public bool D_guardarRespuestaCuestionario(List<clsNSolucionCuestionario> listaSoluciones)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    foreach (clsNSolucionCuestionario nuevaSolucion in listaSoluciones)
                    {
                        SOLUCIONCUESTIONARIO solucioncuestionario = new SOLUCIONCUESTIONARIO();
                        solucioncuestionario.IDPROCESO = nuevaSolucion.IDPROCESO;
                        solucioncuestionario.IDOBJETIVO = nuevaSolucion.IDOBJETIVO;
                        solucioncuestionario.IDINDICADOR = nuevaSolucion.IDINDICADOR;
                        solucioncuestionario.IDPREGUNTA = nuevaSolucion.IDPREGUNTA;
                        solucioncuestionario.IDPERSONA = nuevaSolucion.IDPERSONA;
                        solucioncuestionario.IDPERIODO = nuevaSolucion.IDPERIODO;
                        solucioncuestionario.FECHASOLUCIONCUESTIONARIO = nuevaSolucion.FECHASOLUCIONCUESTIONARIO.Date;
                        solucioncuestionario.TEXTOSOLUCIONCUESTIONARIO = nuevaSolucion.TEXTOSOLUCIONCUESTIONARIO;
                        solucioncuestionario.IDUSUARIOINGRESA = nuevaSolucion.USUARIOINGRESA;
                        if (nuevaSolucion.USUARIOMODIFICA != 0)
                        {
                            solucioncuestionario.IDUSUARIOMODIFICA = nuevaSolucion.USUARIOMODIFICA;
                        }                        

                        db.SOLUCIONCUESTIONARIO.InsertOnSubmit(solucioncuestionario);
                        db.SubmitChanges();
                    }                    

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool D_modificarRespuestaCuestionario(List<clsNSolucionCuestionario> listaSoluciones)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    foreach (clsNSolucionCuestionario nuevaSolucion in listaSoluciones)
                    {
                        SOLUCIONCUESTIONARIO solucioncuestionario = db.SOLUCIONCUESTIONARIO.Where(s => s.IDSOLUCIONCUESTIONARIO == nuevaSolucion.IDSOLUCION).First();
                        solucioncuestionario.FECHAMODIFICACIONCUESTIONARIO = nuevaSolucion.FECHAMODIFICACIONCUESTIONARIO;
                        solucioncuestionario.TEXTOSOLUCIONCUESTIONARIO = nuevaSolucion.TEXTOSOLUCIONCUESTIONARIO;
                        if (nuevaSolucion.USUARIOMODIFICA != 0)
                        {
                            solucioncuestionario.IDUSUARIOMODIFICA = nuevaSolucion.USUARIOMODIFICA;
                        }
                        db.SubmitChanges();
                    }
                    

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<clsNSolucionCuestionario> D_obtenerlistaRespuestas(int idPersona, int idProceso, int idPeriodo)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    DateTime FechaMax = new DateTime();

                    FechaMax = (from fecha in db.SOLUCIONCUESTIONARIO
                              where fecha.IDPERSONA == idPersona && fecha.IDPROCESO == idProceso && fecha.IDPERIODO ==idPeriodo
                              select fecha.FECHASOLUCIONCUESTIONARIO).Max();

                    List<clsNSolucionCuestionario> listaRespuestas = (from res in db.SOLUCIONCUESTIONARIO
                                           where res.FECHASOLUCIONCUESTIONARIO == FechaMax && res.IDPERSONA == idPersona && res.IDPERIODO == idPeriodo && res.IDPROCESO == idProceso
                                           select res).Select(s => new clsNSolucionCuestionario()
                                           {
                                               IDSOLUCION = s.IDSOLUCIONCUESTIONARIO,
                                               IDPROCESO = s.IDPROCESO,
                                               IDPERIODO = s.IDPERIODO,
                                               IDINDICADOR = s.IDINDICADOR,
                                               IDOBJETIVO = s.IDOBJETIVO,
                                               IDPERSONA = s.IDPERSONA,
                                               IDPREGUNTA = s.IDPREGUNTA,
                                               FECHASOLUCIONCUESTIONARIO = s.FECHASOLUCIONCUESTIONARIO,
                                               TEXTOSOLUCIONCUESTIONARIO = s.TEXTOSOLUCIONCUESTIONARIO,
                                               FECHAMODIFICACIONCUESTIONARIO = s.FECHAMODIFICACIONCUESTIONARIO.Value,
                                               USUARIOINGRESA = s.IDUSUARIOINGRESA.Value,
                                               USUARIOMODIFICA = s.IDUSUARIOMODIFICA.Value
                                           }).ToList();

                    return listaRespuestas;
                    
                }
            }
            catch
            {
                return new List<clsNSolucionCuestionario>();
            }
        }

        public bool D_eliminarRespuestaCuestionario(List<clsNSolucionCuestionario> respuestas)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    using (MERSembrarDataContext db = new MERSembrarDataContext())
                    {
                        foreach(clsNSolucionCuestionario respuesta in respuestas)
                        {
                            SOLUCIONCUESTIONARIO eliminarRespuesta = db.SOLUCIONCUESTIONARIO.Where(s => s.IDSOLUCIONCUESTIONARIO == respuesta.IDSOLUCION).First();
                            db.SOLUCIONCUESTIONARIO.DeleteOnSubmit(eliminarRespuesta);
                            db.SubmitChanges();
                        }
                    }
                    trans.Complete();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool D_eliminarRespuestaMultiplesCuestionario(List<clsNSolucionCuestionario> respuestas)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    using (MERSembrarDataContext db = new MERSembrarDataContext())
                    {
                        foreach (clsNSolucionCuestionario respuesta in respuestas)
                        {
                            List<SOLUCIONCUESTIONARIO> eliminarRespuestas = db.SOLUCIONCUESTIONARIO.Where(s => s.IDSOLUCIONCUESTIONARIO == respuesta.IDSOLUCION && s.CUESTIONARIO.PREGUNTA.IDTIPOPREGUNTA==4).ToList();
                            db.SOLUCIONCUESTIONARIO.DeleteAllOnSubmit(eliminarRespuestas);
                            db.SubmitChanges();
                        }
                    }
                    trans.Complete();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
