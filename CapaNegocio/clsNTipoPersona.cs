using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsNTipoPersona
    {
        private int idTipoPersona;

        public int IDTIPOPERSONA
        {
            get { return idTipoPersona; }
            set { idTipoPersona = value; }
        }

        private string nombreTipoPersona;

        public string NOMBRETIPOPERSONA
        {
            get { return nombreTipoPersona; }
            set { nombreTipoPersona = value; }
        }

        private int edadMinima;

        public int EDADMINIMA
        {
            get { return edadMinima; }
            set { edadMinima = value; }
        }

        private int edadMaxima;

        public int EDADMAXIMA
        {
            get { return edadMaxima; }
            set { edadMaxima = value; }
        }
        public clsNTipoPersona() { }
    }
}
