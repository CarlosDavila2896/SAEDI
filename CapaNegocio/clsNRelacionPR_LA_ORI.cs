using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsNRelacionPR_LA_ORI
    {
        private int idLineaAccion;

        public int IDLINEADEACCION
        {
            get { return idLineaAccion; }
            set { idLineaAccion = value; }
        }

        private int idOrientador;

        public int IDORIENTADOR
        {
            get { return idOrientador; }
            set { idOrientador = value; }
        }

        private int idProceso;

        public int IDPROCESO
        {
            get { return idProceso; }
            set { idProceso = value; }
        }

        private int idPeriodo;

        public int IDPERIODO
        {
            get { return idPeriodo; }
            set { idPeriodo = value; }
        }

        private string observacionRelacion;

        public string OBSERVACIONRELACION
        {
            get { return observacionRelacion; }
            set { observacionRelacion = value; }
        }
    }
}
