using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CapaNegocio;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
   public class clsDIndicador
    {

        static clsNIndicador tramsformar(INDICADOR newIndicador)
        {
            clsNIndicador indicador = new clsNIndicador();
            indicador.IDINDICADOR = newIndicador.IDINDICADOR;
            indicador.NOMBREINDICADOR = newIndicador.NOMBREINDICADOR;
            indicador.ESTADOINDICADOR = newIndicador.ESTADO;
            return indicador;
        }
        //Metodo de creacion de nuevo indicador
        public bool D_ingresarIndicador(clsNIndicador nuevoIndicador)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    INDICADOR indicador = new INDICADOR();
                    indicador.NOMBREINDICADOR = nuevoIndicador.NOMBREINDICADOR;
                    indicador.ESTADO = nuevoIndicador.ESTADOINDICADOR;

                    db.INDICADOR.InsertOnSubmit(indicador);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de Indicadores
        public List<INDICADOR> D_consultarIndicadores()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.INDICADOR.ToList().OrderBy(a => a.NOMBREINDICADOR).ToList();
            }
        }

        //Metodo de eliminacion de Indicadores
        public bool D_eliminarIndicador(INDICADOR eliminarIndicador)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    INDICADOR indicador = (from i in db.INDICADOR where i.IDINDICADOR == eliminarIndicador.IDINDICADOR select i).First();
                    db.INDICADOR.DeleteOnSubmit(indicador);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de edicion de los indicadores
        public bool D_editarIndicador(INDICADOR editarIndicador)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    INDICADOR indicador = db.INDICADOR.Single(u => u.IDINDICADOR == editarIndicador.IDINDICADOR);
                    indicador.NOMBREINDICADOR = editarIndicador.NOMBREINDICADOR;
                    indicador.ESTADO = editarIndicador.ESTADO;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de Indicadores Activos alfabeticamente
        public List<INDICADOR> D_consultarIndicadoresActivosOrdenados()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.INDICADOR.Where(x => x.ESTADO == true).OrderBy(x => x.NOMBREINDICADOR).ToList();
            }
        }


    }
}