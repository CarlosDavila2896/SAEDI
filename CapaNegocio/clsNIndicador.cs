using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class clsNIndicador
    {
        private int idIndicador;

        public int IDINDICADOR
        {
            get { return idIndicador; }
            set { idIndicador = value; }
        }
        private string nombreIndicador;

        public string NOMBREINDICADOR
        {
            get { return nombreIndicador; }
            set { nombreIndicador = value; }
        }

        private bool estadoIndicador;

        public bool ESTADOINDICADOR
        {
            get { return estadoIndicador; }
            set { estadoIndicador = value; }
        }
    }
}
