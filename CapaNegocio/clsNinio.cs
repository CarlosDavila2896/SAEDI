using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsNinio
    {
        private int idPersona;

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        private int idMenorEdad;

        public int IdMenorEdad
        {
            get { return idMenorEdad; }
            set { idMenorEdad = value; }
        }
        private int idNinio;

        public int IdNinio
        {
            get { return idNinio; }
            set { idNinio = value; }
        }
    }
}
