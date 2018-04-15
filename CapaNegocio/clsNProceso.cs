using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsNProceso
    {
        private int idProceso;

        public int IDPROCESO
        {
            get { return idProceso; }
            set { idProceso = value; }
        }

        private string nombreProceso;

        public string NOMBREPROCESO
        {
            get { return nombreProceso; }
            set { nombreProceso = value; }
        }

        private bool estadoProceso;

        public bool ESTADO
        {
            get { return estadoProceso; }
            set { estadoProceso = value; }
        }
    }
}
