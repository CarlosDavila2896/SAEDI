﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Data.SqlClient;
using System.Transactions;

namespace CapaDatos
{
    public class clsDMatriculas
    {

        static clsNMatricula transformar(MATRICULA newMatricula)
        {
            clsNMatricula matricula = new clsNMatricula();
            matricula.IDMATRICULA = newMatricula.IDMATRICULA;
            matricula.IDLINEADEACCION = newMatricula.IDLINEADEACCION;
            matricula.IDORIENTADOR = newMatricula.IDORIENTADOR;
            matricula.IDPROCESO = newMatricula.IDPROCESO;
            matricula.IDPERIODO = newMatricula.IDPERIODO;
            matricula.IDPERSONA = newMatricula.IDPERSONA;
            return matricula;
        }

        //Ingreso de matriculas
        public bool ingresarMatricula(clsNMatricula nuevaMatricula)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    MATRICULA matricula = new MATRICULA();
                    matricula.IDLINEADEACCION = nuevaMatricula.IDLINEADEACCION;
                    matricula.IDORIENTADOR = nuevaMatricula.IDORIENTADOR;
                    matricula.IDPROCESO = nuevaMatricula.IDPROCESO;
                    matricula.IDPERIODO = nuevaMatricula.IDPERIODO;
                    matricula.IDPERSONA = nuevaMatricula.IDPERSONA;
                    if (db.MATRICULA.Any(m => m.IDPERSONA.Equals(matricula.IDPERSONA) && m.IDPERIODO.Equals(matricula.IDPERIODO) && m.IDPROCESO.Equals(matricula.IDPROCESO)))
                    {
                        return false;
                    }
                    db.MATRICULA.InsertOnSubmit(matricula);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public object consultarMatricula()
        {
            //try
            //{
            //    var individuos = from m in bd.MATRICULA
            //                     select new
            //                     {
            //                         PROGRAMA = m.PERIODO_PROGRAMA.PROGRAMA.NOMBREPROGRAMA + " " + m.PERIODO_PROGRAMA.PERIODO.NOMBREPERIODO,
            //                         ORIENTADOR = m.PERIODO_PROGRAMA.ORIENTADOR.NOMBREORIENTADOR,
            //                         NOMBRECOMPLETO = m.PERSONA.PRIMERNOMBREPERSONA + " " + m.PERSONA.SEGUNDONOMBREPERSONA + " " + m.PERSONA.PRIMERAPELLIDOPERSONA + " " + m.PERSONA.SEGUNDOAPELLIDOPERSONA,
            //                         REPRESENTANTE = m.REPRESENTANTE.PERSONA.PRIMERNOMBREPERSONA + " " + m.REPRESENTANTE.PERSONA.SEGUNDONOMBREPERSONA + " " + m.REPRESENTANTE.PERSONA.PRIMERAPELLIDOPERSONA + " " + m.REPRESENTANTE.PERSONA.SEGUNDOAPELLIDOPERSONA

            //                     };


            //    return individuos.ToList();
            //}
            //catch (Exception ex)
            //{
            //    return new List<MATRICULA>();
            //}
            return new object();
        }

        //Consulta de ninios asociados a una linea de accion especifica
        public object D_consultarMatriculasFiltradas(int idLineaAccion, int idProceso, int idOrientador, int idPeriodo)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {

                var individuos = from m in db.MATRICULA
                                 where m.IDLINEADEACCION == idLineaAccion && m.IDPROCESO == idProceso && m.IDORIENTADOR == idOrientador && idPeriodo == m.IDPERIODO
                                 select new
                                 {
                                     IDMATRICULA = m.IDMATRICULA,
                                     LineaAccion = m.ORIENTADORACARGODEPROCESOENPERIODO.LINEADEACCION.NOMBRELINEADEACCION,
                                     Proceso = m.ORIENTADORACARGODEPROCESOENPERIODO.PROCESO.NOMBREPROCESO,
                                     Orientador = m.ORIENTADORACARGODEPROCESOENPERIODO.ORIENTADOR.NOMBREORIENTADOR + " " + m.ORIENTADORACARGODEPROCESOENPERIODO.ORIENTADOR.APELLIDOORIENTADOR,
                                     Individuo = m.PERSONA.PRIMERNOMBREPERSONA + " " + m.PERSONA.SEGUNDONOMBREPERSONA + " " + m.PERSONA.PRIMERAPELLIDOPERSONA + " " + m.PERSONA.SEGUNDOAPELLIDOPERSONA,
                                     Periodo = m.ORIENTADORACARGODEPROCESOENPERIODO.PERIODO.NOMBREPERIODO
                                 };


                return individuos.ToList();

            }
        }

        //Sacar del ninio de la linea de accion


        public List<MATRICULA> consultarMiembrosMatricula(clsNMatricula matricula)
        {
            //try
            //{
            //    return bd.MATRICULA.Where(m => m.IDPERIODOPROGRAMA == matricula.IDPERIODOPROGRAMA && m.PERIODO.ACTIVO == true).ToList();
            //}
            //catch (Exception ex)
            //{
            //    return new List<MATRICULA>();
            //}
            return new List<MATRICULA>();
        }



        public void eliminarMatricula(int idMatricula)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    MATRICULA matricula = (from ma in db.MATRICULA where ma.IDMATRICULA == idMatricula select ma).First();
                    db.MATRICULA.DeleteOnSubmit(matricula);
                    db.SubmitChanges();
                }
            }
            catch
            {

            }
        }

        //public object consultarNiniosMatricula(int idPeriodoPrograma)
        //{
        //    try
        //    {

        //        var alum = from m in bd.MATRICULA
        //                   join me in bd.MENOREDAD on m.IDPERSONA equals me.IDPERSONA
        //                   join per in bd.PERSONA on m.IDPERSONA equals per.IDPERSONA
        //                   where m.IDPERIODOPROGRAMA == idPeriodoPrograma
        //                   select new
        //                   {
        //                       CODIGOSAD = me.CODIGOSADMENOREDAD,
        //                       NOMBRERESCOMPLETOS = per.PRIMERNOMBREPERSONA + " " + per.SEGUNDONOMBREPERSONA + " " + per.PRIMERAPELLIDOPERSONA + " " + per.SEGUNDOAPELLIDOPERSONA
        //                   };
        //        return alum.ToList();
        //    }
        //    catch
        //    {
        //        return new List<PROGRAMA>();
        //    }

        //}
    }
}
