using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDTipoAsistente
    {
        static clsNTipoAsistentes transformar(TIPOASISTENTES newAsistentes)
        {
            clsNTipoAsistentes asistente = new clsNTipoAsistentes();
            asistente.IdTipoAsistentes = newAsistentes.IDTIPOASISTENTES;
            asistente.NombreTipoAsistentes = newAsistentes.NOMBRETIPOASISTENTES;
            return asistente;
        }
        public object D_consultarTipoAsistentes()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var tipo = from la in db.TIPOASISTENTES
                                     select new
                                     {
                                         IDTIPO = la.IDTIPOASISTENTES,
                                         NOMBRE = la.NOMBRETIPOASISTENTES
                                     };


                return tipo.Distinct().ToList();
            }
        }
    }
}
