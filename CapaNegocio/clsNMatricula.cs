using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsNMatricula
    {
        private int iDMATRICULA;
        public int IDMATRICULA
        {
            get
            {
                return iDMATRICULA;
            }

            set
            {
                iDMATRICULA = value;
            }
        }

        //Nuevos atributos
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

        private int iDPERSONA;

        public int IDPERSONA
        {
            get
            {
                return iDPERSONA;
            }

            set
            {
                iDPERSONA = value;
            }
        }

        //Antiguos campos
        private int iDPERIODOPROGRAMA;
               

        public int IDPERIODOPROGRAMA
        {
            get
            {
                return iDPERIODOPROGRAMA;
            }

            set
            {
                iDPERIODOPROGRAMA = value;
            }
        }

        public clsNMatricula() { }

        
    }
}
