using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsNObjetivo
    {
        private int idObjetivo;

        public int IDOBJETIVO
        {
            get { return idObjetivo; }
            set { idObjetivo = value; }
        }

        private string nombreObjetivo;

        public string NOMBREOBJETIVO
        {
            get { return nombreObjetivo; }
            set { nombreObjetivo = value; }
        }

        private bool estadoObjetivo;

        public bool ESTADOOBJETIVO
        {
            get { return estadoObjetivo; }
            set { estadoObjetivo = value; }
        }
    }
}
