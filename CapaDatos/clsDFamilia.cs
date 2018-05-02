using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
namespace CapaDatos
{
    public class clsDFamilia
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();
        public List<FAMILIA> consultaFamilia()
        {
            try
            {
                return bd.FAMILIA.ToList().OrderBy(a => a.NOMBREFAMILIA).ToList();

            }
            catch (Exception ex)
            {
                return new List<FAMILIA>();
            }
        }

        public object consultaPersonasAsistentes(int idreunion)
        {
            
            try
            {
                int tipo = (from reu in bd.REUNION
                            where reu.IDREUNION == idreunion
                            select new
                            {
                                reu.IDTIPOASISTENTES
                            }).FirstOrDefault().IDTIPOASISTENTES;
                if (tipo == 1) {
                    var Rep = from m in bd.MATRICULA
                              join p in bd.PERIODO_PERSONA_FAMILIA on m.IDPERSONA equals p.IDPERSONA
                              join r in bd.REUNION on
                              new { linea = m.IDLINEADEACCION, orientador = m.IDORIENTADOR, proceso = m.IDPROCESO, periodo = m.IDPERIODO }
                              equals
                              new { linea = r.IDLINEADEACCION, orientador = r.IDORIENTADOR, proceso = r.IDPROCESO, periodo = r.IDPERIODO }
                              join per in bd.PERSONA on p.IDREPRESENTANTE equals per.IDPERSONA
                              where r.IDREUNION == idreunion
                              select new
                              {

                                  APELLIDOPERSONA = per.PRIMERAPELLIDOPERSONA,
                                  NOMBREPERSONA = per.PRIMERNOMBREPERSONA,
                                  CEDULAPERSONA = per.CEDULAPERSONA,
                                  IDPERSONA = per.IDPERSONA

                              };
                    return Rep.OrderBy(per => per.APELLIDOPERSONA).ToList();
                }

                else if (tipo == 2)
                {
                    var Rep = from m in bd.MATRICULA
                              join r in bd.REUNION on
                              new { linea = m.IDLINEADEACCION, orientador = m.IDORIENTADOR, proceso = m.IDPROCESO, periodo = m.IDPERIODO }
                              equals
                              new { linea = r.IDLINEADEACCION, orientador = r.IDORIENTADOR, proceso = r.IDPROCESO, periodo = r.IDPERIODO }
                              join p in bd.PERSONA on m.IDPERSONA equals p.IDPERSONA
                              where r.IDREUNION == idreunion
                              select new
                              {

                                  APELLIDOPERSONA = p.PRIMERAPELLIDOPERSONA,
                                  NOMBREPERSONA = p.PRIMERNOMBREPERSONA,
                                  CEDULAPERSONA = p.CEDULAPERSONA,
                                  IDPERSONA = m.IDPERSONA

                              };
                    return Rep.OrderBy(per => per.APELLIDOPERSONA).ToList();
                }
                else
                {
                    var Rep = from m in bd.MATRICULA
                              join r in bd.REUNION on
                              new { linea = m.IDLINEADEACCION, orientador = m.IDORIENTADOR, proceso = m.IDPROCESO, periodo = m.IDPERIODO }
                              equals
                              new { linea = r.IDLINEADEACCION, orientador = r.IDORIENTADOR, proceso = r.IDPROCESO, periodo = r.IDPERIODO }
                              join per in bd.PERSONA on m.IDPERSONA equals per.IDPERSONA
                              where r.IDREUNION == idreunion
                              select new
                              {

                                  APELLIDOPERSONA = per.PRIMERAPELLIDOPERSONA,
                                  NOMBREPERSONA = per.PRIMERNOMBREPERSONA,
                                  CEDULAPERSONA = per.CEDULAPERSONA,
                                  IDPERSONA = per.IDPERSONA

                              };
                        var Rep2 = from m in bd.MATRICULA
                                  join p in bd.PERIODO_PERSONA_FAMILIA on m.IDPERSONA equals p.IDPERSONA
                                  join r in bd.REUNION on
                                  new { linea = m.IDLINEADEACCION, orientador = m.IDORIENTADOR, proceso = m.IDPROCESO, periodo = m.IDPERIODO }
                                  equals
                                  new { linea = r.IDLINEADEACCION, orientador = r.IDORIENTADOR, proceso = r.IDPROCESO, periodo = r.IDPERIODO }
                                  join per in bd.PERSONA on p.IDREPRESENTANTE equals per.IDPERSONA
                                  where r.IDREUNION == idreunion
                                  select new
                                  {

                                      APELLIDOPERSONA = per.PRIMERAPELLIDOPERSONA,
                                      NOMBREPERSONA = per.PRIMERNOMBREPERSONA,
                                      CEDULAPERSONA = per.CEDULAPERSONA,
                                      IDPERSONA = per.IDPERSONA

                                  };
                    var Asistentes = Rep.Concat(Rep2);
                    return Asistentes.Distinct().OrderBy(per => per.APELLIDOPERSONA).ToList();
                }

            }
            catch
            {
                return new List<FAMILIA>();
            }

        }
        public object consultaPersonasAsistentesDiarios(int idlinea, int idProceso, int idOrientador, int idPeriodo)
        {

            try
            {
                var Rep = from m in bd.MATRICULA
                          join p in bd.PERSONA on m.IDPERSONA equals p.IDPERSONA
                          
                          where m.IDLINEADEACCION == idlinea && m.IDPROCESO == idProceso && m.IDORIENTADOR == idOrientador && m.IDPERIODO==idPeriodo
                          select new
                          {

                              APELLIDOPERSONA = p.PRIMERAPELLIDOPERSONA,
                              NOMBREPERSONA = p.PRIMERNOMBREPERSONA,
                              CEDULAPERSONA = p.CEDULAPERSONA,
                              IDPERSONA = m.IDPERSONA

                          };
                return Rep.OrderBy(per => per.APELLIDOPERSONA).ToList();


            }
            catch
            {
                return new List<FAMILIA>();
            }

        }

        public bool modificarFamilia(clsNFamilia familiaModificada)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    FAMILIA familia = db.FAMILIA.Single(f => f.IDFAMILIA == familiaModificada.IDFAMILIA);
                    familia.NOMBREFAMILIA = familiaModificada.NOMBREFAMILIA;
                    familia.DIRECCIONFAMILIA = familiaModificada.DIRECCIONFAMILIA;
                    familia.OBSERVACIONFAMILIA = familiaModificada.OBSERVACIONFAMILIA;
                    familia.MIEMBROSFAMILIA = familiaModificada.MIEMBROSFAMILIA;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public clsNFamilia consultaInfoFamilia(int idFamilia)
        {
            try
            {
                clsNFamilia familiaConsultada = new clsNFamilia();

                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    FAMILIA familia = db.FAMILIA.Where(f => f.IDFAMILIA == idFamilia).First();
                    familiaConsultada.IDFAMILIA = familia.IDFAMILIA;
                    familiaConsultada.NOMBREFAMILIA = familia.NOMBREFAMILIA;
                    familiaConsultada.OBSERVACIONFAMILIA = familia.OBSERVACIONFAMILIA;
                    familiaConsultada.MIEMBROSFAMILIA = familia.MIEMBROSFAMILIA.Value;
                }
                return familiaConsultada;
            }
            catch
            {
                return new clsNFamilia();
            }
        }

        public object consultaInfoFamilia()
        {
            var listaFamilias = from f in bd.FAMILIA
                                select new
                                {
                                    Nombre = f.NOMBREFAMILIA,
                                    Ingreso = f.ANIOINGRESOFAMILIA.Value.Date.ToString(),
                                    Direccion = f.DIRECCIONFAMILIA,
                                    Miembros = f.MIEMBROSFAMILIA.Value + " miembros",
                                    Observacion = f.OBSERVACIONFAMILIA
                                };
            return listaFamilias.OrderBy(f => f.Nombre).ThenBy(f => f.Ingreso).ToList();            
            
        }

        public string consultaRepresentante(int idFamilia)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                string idRepresentante = (from f in db.PERIODO_PERSONA_FAMILIA
                                          where f.IDFAMILIA == idFamilia && f.PERIODO.ESTADOPERIODO == true && f.REPRESENTANTE == true
                                          select f.IDPERSONA.ToString()).FirstOrDefault();

                return idRepresentante;
                                         
            }
        }
        public object consultaRepresentantes3(int id, DateTime a,TimeSpan t1)
        {
            //try
            //{

            //    var Rep = from r in bd.REUNIONES
            //              join m in bd.MATRICULA on r.IDPERIODOPROGRAMA equals m.IDPERIODOPROGRAMA
            //              where r.IDORIENTADOR == id && r.Hora == t1 && r.Fecha_Reunion == a
            //              select new
            //              {
            //                  IDREPRESENTANTE = m.REPRESENTANTE.IDREPRESENTANTE ,
            //                  NOMBREREPRESENTANTE = m.REPRESENTANTE.PERSONA.PRIMERNOMBREPERSONA,
            //                  CEDULAREPRESENTANTE = m.REPRESENTANTE.PERSONA.CEDULAPERSONA,
            //                  IDREUNION = r.ID_Reunion

            //              };
            //    return Rep.ToList();
            //}
            //catch
            //{
            //    return new List<FAMILIA>();
            //}
            return new object();
        }
    }
}
