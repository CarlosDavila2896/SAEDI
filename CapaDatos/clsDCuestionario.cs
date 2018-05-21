using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDCuestionario
    {
        //Metodo de agregar nueva pregunta de cuestionario
        public bool D_ingresarCuestionario(clsNCuestionario nuevoCuestionario)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    CUESTIONARIO cuestionario = new CUESTIONARIO();
                    cuestionario.IDPROCESO = nuevoCuestionario.IDPROCESO;
                    cuestionario.IDOBJETIVO = nuevoCuestionario.IDOBJETIVO;
                    cuestionario.IDINDICADOR = nuevoCuestionario.IDINDICADOR;
                    cuestionario.IDPREGUNTA = nuevoCuestionario.IDPREGUNTA;
                    cuestionario.OBSERVACIONESCUESTIONARIO = nuevoCuestionario.OBSERVACIONCUESTIONARIO;
                    cuestionario.ESTADOPREGUNTACUESTIONARIO = nuevoCuestionario.ESTADOCUESTIONARIO;

                    db.CUESTIONARIO.InsertOnSubmit(cuestionario);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de cuestionario filtrado por parametros
        public List<CUESTIONARIO> D_consultarCuestionarioFiltrado(int idProceso, int idObjetivo, int idIndicador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                if(idProceso == 0)
                {
                    return db.CUESTIONARIO.ToList().OrderBy(a => a.IDOBJETIVO).ThenBy(a => a.IDINDICADOR).ToList();
                }
                else if (idProceso>0 && idObjetivo == 0)
                {
                    return db.CUESTIONARIO.Where(x => x.IDPROCESO == idProceso).OrderBy(a => a.IDOBJETIVO).ThenBy(a => a.IDINDICADOR).ToList();
                }
                else if (idProceso > 0 && idObjetivo > 0 && idIndicador==0)
                {
                    return db.CUESTIONARIO.Where(x => x.IDPROCESO == idProceso && x.IDOBJETIVO == idObjetivo).OrderBy(a => a.IDOBJETIVO).ThenBy(a => a.IDINDICADOR).ToList();
                }                
                else
                {
                    return new List<CUESTIONARIO>();
                }
            }
        }

        


        //Metodo de eliminacion de cuestionario
        public bool D_eliminarCuestionario(CUESTIONARIO eliminarCuestionario)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    CUESTIONARIO cuestionario = (from c in db.CUESTIONARIO where c.IDPROCESO == eliminarCuestionario.IDPROCESO && c.IDOBJETIVO == eliminarCuestionario.IDOBJETIVO && c.IDINDICADOR == eliminarCuestionario.IDINDICADOR && c.IDPREGUNTA == eliminarCuestionario.IDPREGUNTA select c).First();
                    db.CUESTIONARIO.DeleteOnSubmit(cuestionario);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de edicion de los cuestionarios
        public bool D_editarCuestionario(CUESTIONARIO editarCuestionario)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    CUESTIONARIO cuestionario = db.CUESTIONARIO.Single(u => u.IDPROCESO == editarCuestionario.IDPROCESO && u.IDOBJETIVO == editarCuestionario.IDOBJETIVO && u.IDINDICADOR == editarCuestionario.IDINDICADOR && u.IDPREGUNTA == editarCuestionario.IDPREGUNTA);
                    cuestionario.OBSERVACIONESCUESTIONARIO = editarCuestionario.OBSERVACIONESCUESTIONARIO;
                    cuestionario.ESTADOPREGUNTACUESTIONARIO = editarCuestionario.ESTADOPREGUNTACUESTIONARIO;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Consulta de lista de objetivos
        public List<OBJETIVO> D_consultaObjectivosCuestionarioAResolver(int idProceso)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                db.ObjectTrackingEnabled = false;
                return db.CUESTIONARIO.Where(p => p.IDPROCESO == idProceso).Select(o => o.OBJETIVO).Distinct().ToList();
            }
        }

        //Consulta de lista de indicadores
        public List<INDICADOR> D_consultaIndicadoresCuestionarioAResolver(int idProceso, int idObjetivo)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.CUESTIONARIO.Where(p => p.IDPROCESO == idProceso && p.IDOBJETIVO==idObjetivo).Select(o => o.INDICADOR).Distinct().ToList();
            }
        }
        public List<INDICADOR> D_consultaIndicadoresCuestionarioAResolver(int idProceso, List<int> idObjetivos)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                db.ObjectTrackingEnabled = false;
                return db.CUESTIONARIO.Where(p => p.IDPROCESO == idProceso && idObjetivos.Contains(p.IDOBJETIVO)).Select(o => o.INDICADOR).Distinct().ToList();
            }
        }


        //Consulta de lista de preguntas
        public List<PREGUNTA> D_consultaPreguntasCuestionarioAResolver(int idProceso, int idObjetivo, int idIndicador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.CUESTIONARIO.Where(p => p.IDPROCESO == idProceso && p.IDOBJETIVO == idObjetivo && p.IDINDICADOR==idIndicador).Select(o => o.PREGUNTA).ToList();
            }
        }

        public List<PREGUNTA> D_consultaPreguntasCuestionarioAResolver(int idProceso, List<int> idObjetivos, List<int> idIndicadores)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                db.ObjectTrackingEnabled = false;
                return db.CUESTIONARIO.Where(p => p.IDPROCESO == idProceso && idObjetivos.Contains(p.IDOBJETIVO) && idIndicadores.Contains(p.IDINDICADOR)).Select(o => o.PREGUNTA).ToList();
            }
        }

        public List<PREGUNTASCONPOSIBLESRESPUESTAS> D_consultaPreguntasRespuestasCuestionarioAResolver(List<int> idPreguntas)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                db.ObjectTrackingEnabled = false;
                return db.PREGUNTASCONPOSIBLESRESPUESTAS.Where(p => idPreguntas.Contains(p.IDPREGUNTA)).ToList();
            }
        }

        //Consulta de lista de Respuestas si aplica
        public List<POSIBLERESPUESTA> D_consultaRespuestasCuestionarioAResolver(int idPregunta)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.PREGUNTASCONPOSIBLESRESPUESTAS.Where(p => p.IDPREGUNTA == idPregunta).Select(o => o.POSIBLERESPUESTA).ToList();
            }
        }

        public List<POSIBLERESPUESTA> D_consultaRespuestasCuestionarioAResolver(List<int> idPreguntas)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                db.ObjectTrackingEnabled = false;
                return db.PREGUNTASCONPOSIBLESRESPUESTAS.Where(p => idPreguntas.Contains(p.IDPREGUNTA)).Select(o => o.POSIBLERESPUESTA).ToList();
            }
        }


        //Consulta de preguntas de un proceso para presentar el cuestionario
        public object D_consultaPreguntasCuestionarioAResolver(int idProceso)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var listaPreguntas = from cues in db.CUESTIONARIO
                                               where cues.IDPROCESO == idProceso && cues.PREGUNTA.ESTADOPREGUNTA == true && cues.OBJETIVO.ESTADOOBJETIVO == true && cues .INDICADOR.ESTADO == true
                                               select new
                                               {
                                                   IDOBJETIVO = cues.IDOBJETIVO,
                                                   NOMBREOBJETIVO = cues.OBJETIVO.NOMBREOBJETIVO,
                                                   IDINDICADOR = cues.IDINDICADOR,
                                                   NOMBREINDICADOR = cues.INDICADOR.NOMBREINDICADOR,
                                                   IDPREGUNTA = cues.IDPREGUNTA,
                                                   TIPODEPREGUNTA = cues.PREGUNTA.IDTIPOPREGUNTA,
                                                   TEXTOPREGUNTA = cues.PREGUNTA.NOMBREPREGUNTA,
                                               };
                return listaPreguntas.OrderBy(o => o.IDOBJETIVO).ThenBy(i => i.IDINDICADOR).ThenBy(p => p.IDPREGUNTA).ToList();
            }
        }
        

        
    }
}
