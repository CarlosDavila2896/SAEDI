using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsOrientador
    {
        private int IDOrientador;

        public int IDOrientador1
        {
            get { return IDOrientador; }
            set { IDOrientador = value; }
        }
        private string nombreOrientador;

        public string NombreOrientador
        {
            get { return nombreOrientador; }
            set { nombreOrientador = value; }
        }

        public string apellidoOrientador { get; set; }
        public char generoOrientador { get; set; }
        public bool estadoOrientador { get; set; }
        public string username { get; set; }
        public string pass { get; set; }

        public clsOrientador()
        {
        }
    }
}
