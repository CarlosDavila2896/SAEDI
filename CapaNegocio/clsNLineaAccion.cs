using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsNLineaAccion
    {
        private int idLineaAccion;

        public int IDLINEA
        {
            get { return idLineaAccion; }
            set { idLineaAccion = value; }
        }

        private string nombreLineaAccion;

        public string NOMBRELINEAACCION
        {
            get { return nombreLineaAccion; }
            set { nombreLineaAccion = value; }
        }

        private string descripcionLineaAccion;

        public string DESCRIPCIONLINEAACCION
        {
            get { return descripcionLineaAccion; }
            set { descripcionLineaAccion = value; }
        }

        private int idTipoPersona;

        public int IDTIPOPERSONA
        {
            get { return idTipoPersona; }
            set { idTipoPersona = value; }
        }

        public clsNLineaAccion() { }
    }
}
