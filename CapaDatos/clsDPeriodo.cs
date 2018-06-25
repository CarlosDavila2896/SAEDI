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
        static clsNPeriodo transformar(PERIODO newPeriodo)
        {
            clsNPeriodo periodo = new clsNPeriodo();
            periodo.IDPeriodo = newPeriodo.IDPERIODO;
            periodo.IDTIPOPERIODO = int.Parse(newPeriodo.IDTIPOPERIODO.ToString());
            periodo.FECHAINICIOPERIODO = newPeriodo.FECHAINICIOPERIODO;
            periodo.FECHAFINPERIODO = DateTime.Parse(newPeriodo.FECHAFINPERIODO.ToString());
            periodo.ACTIVO = newPeriodo.ESTADOPERIODO;
            return periodo;
        }

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

        public object consultaPeriodosActualizar()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.PERIODO
                              where r.ESTADOPERIODO == true && r.IDTIPOPERIODO==1 
                              select new
                              {
                                  NOMBRE = r.NOMBREPERIODO,
                                  ID = r.IDPERIODO
                              };

                    return reu.Distinct().ToList().OrderBy(a => a.NOMBRE).ToList();

                }
                catch
                {
                    return new List<REUNION>();
                }
            }
        }


        public DateTime cargarFechaInicio(int id)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var reu = (from r in db.PERIODO

                           where r.IDPERIODO == id
                           select new
                           {
                               FECHA = r.FECHAINICIOPERIODO

                           }).FirstOrDefault().FECHA;
                return reu;
            }
        }


        public DateTime cargarFechaFin(int id)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var reu = (from r in db.PERIODO

                           where r.IDPERIODO == id
                           select new
                           {
                               FECHA = r.FECHAFINPERIODO

                           }).FirstOrDefault().FECHA;
                return reu.Value;
            }
        }

        public string cargarNombre(int id)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var reu = (from r in db.PERIODO

                           where r.IDPERIODO == id
                           select new
                           {
                               NOMBRE = r.NOMBREPERIODO

                           }).FirstOrDefault().NOMBRE;
                return reu.ToString();
            }
        }

        public bool actualizarPeriodo(int id, string nombre, DateTime fechainicio, DateTime fechafin)
        {
            using (MERSembrarDataContext bd = new MERSembrarDataContext())
            {
                try
                {
                    PERIODO reu = bd.PERIODO.First(r => r.IDPERIODO == id);
                    reu.FECHAFINPERIODO = fechainicio;
                    reu.FECHAINICIOPERIODO = fechafin;
                    reu.NOMBREPERIODO = nombre;
                    bd.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;

                }
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
