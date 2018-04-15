using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Transactions;
namespace CapaDatos
{
    public class clsDPeriodo
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();
        public bool ingresarPeriodo(clsNPeriodo objPeriodo)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    PERIODO p = new PERIODO();
                    p.NOMBREPERIODO = objPeriodo.NOMBREPERIODO.ToUpper();
                    p.IDTIPOPERIODO = 1;
                    p.FECHAINICIOPERIODO = DateTime.Now.Date;
                    p.FECHAFINPERIODO = null;
                    p.ESTADOPERIODO = true;
                    bd.PERIODO.InsertOnSubmit(p);
                    bd.SubmitChanges();
                    trans.Complete();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public bool cerrarPeriodo(clsNPeriodo objPeriodo)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    PERIODO p = bd.PERIODO.Where(per=> per.IDPERIODO == objPeriodo.IDPeriodo).First();
                    p.FECHAFINPERIODO = DateTime.Now;
                    p.ESTADOPERIODO = false;
                    bd.SubmitChanges();
                    trans.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool ingresarPeriodoConFechas(clsNPeriodo objPeriodo)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    PERIODO p = new PERIODO();
                    p.NOMBREPERIODO = objPeriodo.NOMBREPERIODO.ToUpper();
                    p.IDTIPOPERIODO = 1;
                    p.FECHAINICIOPERIODO = objPeriodo.FECHAINICIOPERIODO;
                    p.FECHAFINPERIODO = objPeriodo.FECHAFINPERIODO;
                    p.ESTADOPERIODO = objPeriodo.ACTIVO; 
                    bd.PERIODO.InsertOnSubmit(p);
                    bd.SubmitChanges();
                    trans.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<PERIODO> consultarPeriodoActivo()
        {
            try
            {
                return bd.PERIODO.Where(p=>p.ESTADOPERIODO==true).ToList();

            }
            catch(Exception ex)
            {
                return new List<PERIODO>();
            }
        }

        public List<PERIODO> consultaAniosLectivosCrudos()
        {
            try
            {
                return bd.PERIODO.Where(p => p.IDTIPOPERIODO==1).ToList();

            }
            catch (Exception ex)
            {
                return new List<PERIODO>();
            }
        }

        public object consultarAniosLectivos()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var periodos = (from per in db.PERIODO
                               where per.IDTIPOPERIODO == 1
                               select new
                               {
                                   NOMBRE = per.NOMBREPERIODO,
                                   FECHAINICIO = per.FECHAINICIOPERIODO.ToShortDateString(),
                                   FECHAFIN = per.FECHAFINPERIODO.GetValueOrDefault().ToShortDateString(),
                                   ESTADO = per.ESTADOPERIODO
                               }).ToList();

                return periodos;
            }
        }



        public bool ingresarPeriodo2(clsNPeriodo objPeriodo)
        {
            throw new NotImplementedException();
        }

        //Maetodo de consulta de periodos asociados
        public object D_consutarPeriodosActivosAsociados(int idLineaAccion, int idProceso, int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var periodos = from per in db.PERIODO
                                   join r in db.ORIENTADORACARGODEPROCESOENPERIODO on per.IDPERIODO equals r.IDPERIODO
                                   where r.IDLINEADEACCION == idLineaAccion && r.IDPROCESO == idProceso && r.IDORIENTADOR == idOrientador
                                   select new
                                   {
                                       IDPERIODO = per.IDPERIODO,
                                       NOMBREPERIODO = per.NOMBREPERIODO
                                   };


                return periodos.ToList();
            }
        }

        //Consulta anios lectivos
        public List<PERIODO> D_consultaPeriodosAniosLectivos()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.PERIODO.Where(p => p.IDTIPOPERIODO == 1 && p.ESTADOPERIODO == true).ToList();
            }
        }
    }
}
