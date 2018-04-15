using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Transactions;

namespace CapaDatos
{
    public class clsDRepresentante
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();

        public List<REPRESENTANTE> consultarRepresentante(clsPersona persona)
        {
            try
            {
                List<PERIODO_PERSONA_FAMILIA> actual = bd.PERIODO_PERSONA_FAMILIA.Where(ppf => ppf.IDPERSONA == persona.Codigo && ppf.PERIODO.ESTADOPERIODO == true).ToList();
                List<REPRESENTANTE> representantes = new List<REPRESENTANTE>();
                foreach(PERIODO_PERSONA_FAMILIA familia in actual)
                {
                    representantes.Add(bd.REPRESENTANTE.Where(rep => rep.IDPERSONA == bd.PERIODO_PERSONA_FAMILIA.Where(ppf => ppf.IDFAMILIA == familia.IDFAMILIA && ppf.IDPERIODO == familia.IDPERIODO && ppf.REPRESENTANTE == true).First().IDPERSONA).First());
                }

                return representantes;
            }
            catch (Exception ex)
            {
                return new List<REPRESENTANTE> ();
            }
        }

        public object consultaRepresentanteLinq(int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {

                var pr = from p in db.REPRESENTANTE
                         where p.IDORIENTADOR == idOrientador
                         select new
                         {
                             ID = p.IDREPRESENTANTE,
                             Nombre = p.PERSONA.PRIMERNOMBREPERSONA
                         };
                return pr.ToList();
            }
        }

        public object consultarRepresentantesPresentes(int idreunion)
        {
            //try
            //{
            //    var repre = from a in bd.ASISTENCIA
            //                where a.IDREUNION == idreunion
            //                select new
            //                {
            //                    Nombre = a.REPRESENTANTE.PERSONA.PRIMERNOMBREPERSONA + " " + a.REPRESENTANTE.PERSONA.SEGUNDONOMBREPERSONA + " " + a.REPRESENTANTE.PERSONA.PRIMERAPELLIDOPERSONA + " " + a.REPRESENTANTE.PERSONA.SEGUNDOAPELLIDOPERSONA,
            //                    IdRepresentante = a.IDREPRESENTANTE

            //                 };


            //    return repre.ToList();
            //}
            //catch (Exception ex)
            //{
            //    return new List<REPRESENTANTE>();
            //}
            return new object();
        }
    }
}
