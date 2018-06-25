using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsParentesco
    {
        private string nombreParentesco;
        private int codigo;

        public string NombreParentesco
        {
            get
            {
                return nombreParentesco;
            }

            set
            {
                nombreParentesco = value;
            }
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }
        public clsParentesco()
        {

        }
    }
}
