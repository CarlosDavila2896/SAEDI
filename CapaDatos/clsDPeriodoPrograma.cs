using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Transactions;

namespace CapaDatos
{
    public class clsDPeriodoPrograma
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();
        public bool ingresarPeriodoPrograma(clsNPeriodoPrograma objPeriodoPrograma)
        {
            //using (TransactionScope trans = new TransactionScope())
            //{
            //    try
            //    {
            //        PERIODO_PROGRAMA pp = new PERIODO_PROGRAMA();
            //        pp.IDPERIODO = objPeriodoPrograma.IDPERIODO;
            //        pp.IDORIENTADOR = objPeriodoPrograma.IDORIENTADOR;
            //        pp.IDPROGRAMA = objPeriodoPrograma.IDPROGRAMA;
            //        bd.PERIODO_PROGRAMA.InsertOnSubmit(pp);
            //        bd.SubmitChanges();
            //        trans.Complete();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        return false;
            //    }
            //}
            return true;

        }

        public object consultarPeriodoProgramaActivos(int periodo)
        {
            //try
            //{
            //    return bd.PERIODO_PROGRAMA.Where(pp=>pp.IDPERIODO == periodo && pp.PERIODO.ACTIVO==true).ToList();
            //}
            //catch (Exception ex)
            //{
            //    return new List<PERIODO_PROGRAMA>();
            //}
            return new object();
        }

        public object consultarPeriodoProgramaOrientador(int idOrientador)
        {
            //try
            //{
            //    var per = from PP in bd.PERIODO_PROGRAMA
            //              where PP.PERIODO.ACTIVO == true && PP.IDORIENTADOR == idOrientador
            //              select new
            //              {
            //                  IDPERIODOPROGRAMA = PP.IDPERIODOPROGRAMA,
            //                  PROGRAMA = PP.PROGRAMA.NOMBREPROGRAMA + " - " + PP.PERIODO.NOMBREPERIODO
            //              };
            //    return per.ToList();

            //}
            //catch (Exception ex)
            //{
            //    return new List<PERIODO_PROGRAMA>();
            //}
            return new object();
        }


        public object consultarPeriodoProgramaInfo()
        {
            //try
            //{
            //    var per = from PP in bd.PERIODO_PROGRAMA
            //              where PP.PERIODO.ACTIVO == true
            //              select new
            //              {
            //                  Nombre_Periodo = PP.PERIODO.NOMBREPERIODO,
            //                  Programa = PP.PROGRAMA.NOMBREPROGRAMA,
            //                  Orientador = PP.ORIENTADOR.NOMBREORIENTADOR
            //              };
            //    return per.ToList();

            //}
            //catch (Exception ex)
            //{
            //    return new List<PERIODO_PROGRAMA>();
            //}
            return new object();
        }

        public object consultarPeriodoProgramaActivos()
        {
            //try
            //{
            //    return bd.PERIODO_PROGRAMA.Where(pp =>pp.PERIODO.ACTIVO == true).ToList();
            //}
            //catch (Exception ex)
            //{
            //    return new List<PERIODO_PROGRAMA>();
            //}
            return new object();
        }

        public object D_consutarPeriodosActivosAsociados(int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var periodos = from per in db.PERIODO
                               join r in db.ORIENTADORACARGODEPROCESOENPERIODO on per.IDPERIODO equals r.IDPERIODO
                               where r.IDORIENTADOR == idOrientador && per.ESTADOPERIODO == true && per.IDTIPOPERIODO == 1
                               select new
                               {
                                   IDPERIODO = per.IDPERIODO,
                                   NOMBREPERIODO = per.NOMBREPERIODO
                               };


                return periodos.Distinct().ToList();
            }
        }
        public object D_consutarPeriodosActivosAsociadosCompleto(int idOrientador, int idProceso, int idLinea)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var periodos = from per in db.PERIODO
                               join r in db.ORIENTADORACARGODEPROCESOENPERIODO on per.IDPERIODO equals r.IDPERIODO
                               where r.IDORIENTADOR == idOrientador && per.ESTADOPERIODO == true && r.IDPROCESO==idProceso && r.IDLINEADEACCION==idLinea
                               select new
                               {
                                   IDPERIODO = per.IDPERIODO,
                                   NOMBREPERIODO = per.NOMBREPERIODO
                               };


                return periodos.Distinct().ToList();
            }
        }
    }
}
