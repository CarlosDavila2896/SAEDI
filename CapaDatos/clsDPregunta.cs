using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using CapaNegocio;
using System.Configuration;

namespace CapaDatos
{
    public class clsDPregunta
    {
        //CONSULTA DE TIPOS DE PREGUNTAS
        public List<TIPOPREGUNTA> consultaTipoPreguntas()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.TIPOPREGUNTA.ToList();
            }
        }


        //Metodo de creacion de nueva pregunta
        public bool D_ingresarPregunta(clsNPregunta nuevaPregunta)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    PREGUNTA pregunta = new PREGUNTA();
                    pregunta.NOMBREPREGUNTA = nuevaPregunta.NOMBREPREGUNTA;
                    pregunta.IDTIPOPREGUNTA = nuevaPregunta.IDTIPOPREGUNTA;
                    pregunta.ESTADOPREGUNTA = nuevaPregunta.ESTADOPREGUNTA;

                    db.PREGUNTA.InsertOnSubmit(pregunta);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de Preguntas
        public List<PREGUNTA> D_consultarPreguntas()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.PREGUNTA.ToList().OrderBy(a => a.NOMBREPREGUNTA).ToList();
            }
        }

        //Metodo de consulta de Preguntas
        public List<PREGUNTA> D_consultarPreguntas(string filtro)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                if (filtro==null || filtro.Trim()=="")
                {
                    return db.PREGUNTA.ToList().OrderBy(a => a.NOMBREPREGUNTA).ToList();
                }
                return db.PREGUNTA.Where(p => p.NOMBREPREGUNTA.Contains(filtro) || p.TIPOPREGUNTA.NOMBRETIPOPREGUNTA.Contains(filtro)).ToList().OrderBy(a => a.NOMBREPREGUNTA).ToList();
            }
        }

        //Metodo de eliminacion de Preguntas
        public bool D_eliminarPregunta(PREGUNTA eliminarPregunta)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    PREGUNTA pregunta = (from p in db.PREGUNTA where p.IDPREGUNTA == eliminarPregunta.IDPREGUNTA select p).First();
                    db.PREGUNTA.DeleteOnSubmit(pregunta);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de edicion de los preguntas
        public bool D_editarPreguntas(PREGUNTA editarPregunta)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    PREGUNTA pregunta = db.PREGUNTA.Single(u => u.IDPREGUNTA == editarPregunta.IDPREGUNTA);
                    pregunta.NOMBREPREGUNTA = editarPregunta.NOMBREPREGUNTA;
                    pregunta.IDTIPOPREGUNTA = editarPregunta.IDTIPOPREGUNTA;
                    pregunta.ESTADOPREGUNTA = editarPregunta.ESTADOPREGUNTA;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de preguntas cerradas activas ordenado
        public List<PREGUNTA> D_consultarPreguntasCerradasActivasOrdenadas()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.PREGUNTA.Where(u => u.ESTADOPREGUNTA == true && u.TIPOPREGUNTA.NOMBRETIPOPREGUNTA == "Cerrada").OrderBy(x => x.NOMBREPREGUNTA).ToList();
            }
        }

        //Metodo de consulta de preguntas activas ordenado
        public List<PREGUNTA> D_consultarPreguntasActivasOrdenadas()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.PREGUNTA.Where(u => u.ESTADOPREGUNTA == true).OrderBy(x => x.NOMBREPREGUNTA).ToList();
            }
        }

    }
}

