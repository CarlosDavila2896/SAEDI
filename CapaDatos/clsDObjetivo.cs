using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDObjetivo
    {
        static clsNObjetivo transformar(OBJETIVO newObjetivo)
        {
            clsNObjetivo objetivo = new clsNObjetivo();
            objetivo.IDOBJETIVO = newObjetivo.IDOBJETIVO;
            objetivo.NOMBREOBJETIVO = newObjetivo.NOMBREOBJETIVO;
            objetivo.ESTADOOBJETIVO = newObjetivo.ESTADOOBJETIVO;
            return objetivo;
        }
        //Metodo de creacion de nuevo objetivo
        public bool D_ingresarObjetivo(clsNObjetivo nuevoObjetivo)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    OBJETIVO objetivo = new OBJETIVO();
                    objetivo.NOMBREOBJETIVO = nuevoObjetivo.NOMBREOBJETIVO;
                    objetivo.ESTADOOBJETIVO = nuevoObjetivo.ESTADOOBJETIVO;

                    db.OBJETIVO.InsertOnSubmit(objetivo);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de Objetivos
        public List<OBJETIVO> D_consultarObjetivos()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.OBJETIVO.ToList();
            }
        }

        //Metodo de eliminacion de Objetivos
        public bool D_eliminarObjetivos(OBJETIVO eliminarObjetivo)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    OBJETIVO objetivo = (from o in db.OBJETIVO where o.IDOBJETIVO == eliminarObjetivo.IDOBJETIVO select o).First();
                    db.OBJETIVO.DeleteOnSubmit(objetivo);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de edicion de los objetivos
        public bool D_editarObjetivo(OBJETIVO editarObjetivo)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    OBJETIVO objetivo = db.OBJETIVO.Single(u => u.IDOBJETIVO == editarObjetivo.IDOBJETIVO);
                    objetivo.NOMBREOBJETIVO = editarObjetivo.NOMBREOBJETIVO;
                    objetivo.ESTADOOBJETIVO = editarObjetivo.ESTADOOBJETIVO;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de Objetivos activos ordenados
        public List<OBJETIVO> D_consultarObjetivosActivosOrdenados()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.OBJETIVO.Where(x => x.ESTADOOBJETIVO == true).OrderBy(x => x.NOMBREOBJETIVO).ToList();
            }
        }

    }
}
