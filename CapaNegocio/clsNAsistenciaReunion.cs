using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsNAsistenciaReunion
    {
        private int idPersona;
        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        private int idReunion;
        public int IdReunion
        {
            get { return idReunion; }
            set { idReunion = value; }
        }

        private int idAsistencia;
        public int IdAsistencia
        {
            get { return idAsistencia; }
            set { idAsistencia = value; }
        }

        private int idTipoAsistencia;
        public int IdTipoAsistencia
        {
            get { return idTipoAsistencia; }
            set { idTipoAsistencia = value; }
        }

        public clsNAsistenciaReunion()
        {

        }
    }
}
