using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class clsDPosibleRespuesta
    {
        //Metodo de creacion de nueva posible respuesta
        public bool D_ingresarPosibleRespuesta(clsNPosibleRespuesta nuevaPosibleRespuesta)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    POSIBLERESPUESTA posiblerespuesta = new POSIBLERESPUESTA();
                    posiblerespuesta.TEXTOPOSIBLERESPUESTA = nuevaPosibleRespuesta.TEXTOPOSIBLERESPUESTA;
                    posiblerespuesta.PUNTAJEPOSIBLERESPUESTA = nuevaPosibleRespuesta.PUNTAJEPOSIBLERESPUESTA;
                    posiblerespuesta.ESTADOPOSIBLERESPUESTA = nuevaPosibleRespuesta.ESTADOPOSIBLERESPUESTA;

                    db.POSIBLERESPUESTA.InsertOnSubmit(posiblerespuesta);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de posibles respuestas
        public List<POSIBLERESPUESTA> D_consultarPosiblesRespuestas()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.POSIBLERESPUESTA.ToList().OrderBy(a => a.TEXTOPOSIBLERESPUESTA).ToList();
            }
        }

        //Metodo de eliminacion de posibles respuestas
        public bool D_eliminarPosibleRespuesta(POSIBLERESPUESTA eliminarPosibleRespuesta)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    POSIBLERESPUESTA posiblerespuesta = (from pr in db.POSIBLERESPUESTA where pr.IDPOSIBLERESPUESTA == eliminarPosibleRespuesta.IDPOSIBLERESPUESTA select pr).First();
                    db.POSIBLERESPUESTA.DeleteOnSubmit(posiblerespuesta);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de edicion de los posibles respuestas
        public bool D_editarPosibleRespuesta(POSIBLERESPUESTA editarPosibleRespuesta)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    POSIBLERESPUESTA posiblerespuesta = db.POSIBLERESPUESTA.Single(u => u.IDPOSIBLERESPUESTA == editarPosibleRespuesta.IDPOSIBLERESPUESTA);
                    posiblerespuesta.TEXTOPOSIBLERESPUESTA = editarPosibleRespuesta.TEXTOPOSIBLERESPUESTA;
                    posiblerespuesta.PUNTAJEPOSIBLERESPUESTA = editarPosibleRespuesta.PUNTAJEPOSIBLERESPUESTA;
                    posiblerespuesta.ESTADOPOSIBLERESPUESTA = editarPosibleRespuesta.ESTADOPOSIBLERESPUESTA;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        
        //Metodo de consulta de posibles respuestas activas ordenado
        public List<POSIBLERESPUESTA> D_consultarPosiblesRespuestasActivas()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.POSIBLERESPUESTA.Where(u => u.ESTADOPOSIBLERESPUESTA == true).OrderBy(x => x.TEXTOPOSIBLERESPUESTA).ToList();
            }
        }

        //Metodo de consulta de Preguntas con sus respectivas respuestas
        public object D_consultaPreguntasconPosiblesRespuestasConPuntaje(int idPregunta)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var listaPreguntasRespuestas = from pr in db.PREGUNTASCONPOSIBLESRESPUESTAS
                                               where pr.IDPREGUNTA==idPregunta
                            select new
                            {
                                IDPREGUNTA = pr.IDPREGUNTA,
                                IDRESPUESTA = pr.IDPOSIBLERESPUESTA,
                                Pregunta = pr.PREGUNTA.NOMBREPREGUNTA,
                                Respuesta = pr.POSIBLERESPUESTA.TEXTOPOSIBLERESPUESTA + " Puntaje: " + pr.POSIBLERESPUESTA.PUNTAJEPOSIBLERESPUESTA
                            };
                return listaPreguntasRespuestas.ToList().ToList();
            }                
        }

        //Metodo de consulta de respuestas con su respectivo puntaje en una sola linea
        public object D_consultarPosiblesRespuestasActivasPuntaje1Linea()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var listaRespuestas = from res in db.POSIBLERESPUESTA
                                               where res.ESTADOPOSIBLERESPUESTA == true
                                               select new
                                               {
                                                   IDPOSIBLERESPUESTA = res.IDPOSIBLERESPUESTA,
                                                   TEXTOPOSIBLERESPUESTAPUNTAJE = res.TEXTOPOSIBLERESPUESTA + " / Puntaje: " + res.PUNTAJEPOSIBLERESPUESTA
                                               };
                return listaRespuestas.ToList().OrderBy(x => x.TEXTOPOSIBLERESPUESTAPUNTAJE);
            }
        }

        //Crear nueva relacion pregunta respuesta
        public bool D_ingresarRelacionPreguntaRespuesta(int idPregunta, int idRespuesta)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    PREGUNTASCONPOSIBLESRESPUESTAS nuevarelacionPR = new PREGUNTASCONPOSIBLESRESPUESTAS();
                    nuevarelacionPR.IDPREGUNTA = idPregunta;
                    nuevarelacionPR.IDPOSIBLERESPUESTA = idRespuesta;

                    db.PREGUNTASCONPOSIBLESRESPUESTAS.InsertOnSubmit(nuevarelacionPR);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        //Eliminar relacion entre pregunta y posible respuesta
        public bool D_eliminarRelacionPreguntaRespuesta(int idPregunta, int idRespuesta)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    PREGUNTASCONPOSIBLESRESPUESTAS relacionpreguntarespuesta = (from pcpr in db.PREGUNTASCONPOSIBLESRESPUESTAS where pcpr.IDPREGUNTA == idPregunta && pcpr.IDPOSIBLERESPUESTA == idRespuesta select pcpr).First();
                    db.PREGUNTASCONPOSIBLESRESPUESTAS.DeleteOnSubmit(relacionpreguntarespuesta);
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
