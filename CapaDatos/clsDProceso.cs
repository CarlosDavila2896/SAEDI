using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDProceso
    {
        static clsProcesoNiño transformar(PROCESO newProceso)
        {
            clsProcesoNiño proceso = new clsProcesoNiño();
            proceso.IDProceso1 = newProceso.IDPROCESO;
            proceso.NombreProceso = newProceso.NOMBREPROCESO;
            proceso.Estado = int.Parse(newProceso.ESTADOPROCESO.ToString());
            return proceso;
        }
        //Metodo de creacion de nuevo proceso
        public bool D_ingresarProceso(clsNProceso nuevoProceso)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    PROCESO proceso = new PROCESO();
                    proceso.NOMBREPROCESO = nuevoProceso.NOMBREPROCESO;
                    proceso.ESTADOPROCESO = nuevoProceso.ESTADO;
                    proceso.IDTIPOPROCESO = nuevoProceso.IDTIPOPROCESO;

                    db.PROCESO.InsertOnSubmit(proceso);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public object D_consultarProcesoPorOrientador(int idOrientador)
        {
            try
            {
                using (MERSembrarDataContext bd = new MERSembrarDataContext())
                {
                    return (from proceso in bd.PROCESO
                            join r in bd.ORIENTADORACARGODEPROCESOENPERIODO on proceso.IDPROCESO equals r.IDPROCESO
                            where r.IDORIENTADOR == idOrientador
                            select new
                            {
                                Nombre = proceso.NOMBREPROCESO,
                                IdProceso = proceso.IDPROCESO
                            }).ToList().OrderBy(a => a.Nombre).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                return new object();
            }
        }

        //Metodo de consulta de procesos
        public List<PROCESO> D_consultarProcesos()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.PROCESO.ToList();
            }
        }

        //Metodo de eliminacion de procesos
        public bool D_eliminarProceso(PROCESO eliminarProceso)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    PROCESO proceso = (from p in db.PROCESO where p.IDPROCESO == eliminarProceso.IDPROCESO select p).First();
                    db.PROCESO.DeleteOnSubmit(proceso);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de edicion de los procesos
        public bool D_editarProceso(PROCESO editarProceso)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    PROCESO proceso = db.PROCESO.Single(u => u.IDPROCESO == editarProceso.IDPROCESO);
                    proceso.NOMBREPROCESO = editarProceso.NOMBREPROCESO;
                    proceso.ESTADOPROCESO = editarProceso.ESTADOPROCESO;
                    proceso.IDTIPOPROCESO = editarProceso.IDTIPOPROCESO;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de procesos activos en orden alfabetico
        public List<PROCESO> D_consultarProcesosActivosOrdenados()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.PROCESO.Where(x => x.ESTADOPROCESO).OrderBy(x => x.NOMBREPROCESO).ToList();
            }
        }

        //Metodo de consulta de procesos activos en orden alfabetico
        public List<PROCESO> D_consultarProcesosActivosOrdenadosPorTipo(int idtipo)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.PROCESO.Where(x => x.ESTADOPROCESO && x.IDTIPOPROCESO==idtipo).OrderBy(x => x.NOMBREPROCESO).ToList();
            }
        }



        public object D_consultarProceso()
        {
            try
            {
                using (MERSembrarDataContext bd = new MERSembrarDataContext())
                {
                    return (from proceso in bd.PROCESO
                            select new
                            {
                                Nombre = proceso.NOMBREPROCESO,
                                IdProceso = proceso.IDPROCESO
                            }).ToList().OrderBy(a => a.Nombre).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                return new object();
            }
        }
        //Maetodo de consulta de procesos asociados
        public object D_consutarProcesosActivosAsociados(int idLineaAccion)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var procesos = from pr in db.PROCESO
                                     join r in db.ORIENTADORACARGODEPROCESOENPERIODO on pr.IDPROCESO equals r.IDPROCESO
                                     where r.IDLINEADEACCION == idLineaAccion && pr.ESTADOPROCESO == true
                                     select new
                                     {
                                         IDPROCESO = pr.IDPROCESO,
                                         NOMBREPROCESO = pr.NOMBREPROCESO
                                     };


                return procesos.Distinct().ToList().OrderBy(a=>a.NOMBREPROCESO).ToList();
            }
        }

        public object D_consutarProcesosActivosAsociadosConOrientador(int idLineaAccion, int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var procesos = from pr in db.PROCESO
                               join r in db.ORIENTADORACARGODEPROCESOENPERIODO on pr.IDPROCESO equals r.IDPROCESO
                               where r.IDLINEADEACCION == idLineaAccion && pr.ESTADOPROCESO == true && r.IDORIENTADOR == idOrientador
                               select new
                               {
                                   IDPROCESO = pr.IDPROCESO,
                                   NOMBREPROCESO = pr.NOMBREPROCESO
                               };


                return procesos.Distinct().ToList().OrderBy(a => a.NOMBREPROCESO).ToList();
            }
        }




    }
}
