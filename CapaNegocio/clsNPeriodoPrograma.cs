using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsNPeriodoPrograma
    {
        private int iDPERIODOPROGRAMA;
        private int iDPERIODO;
        private int iDPROGRAMA;
        private int iDORIENTADOR;

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

        public int IDPERIODO
        {
            get
            {
                return iDPERIODO;
            }

            set
            {
                iDPERIODO = value;
            }
        }

        public int IDPROGRAMA
        {
            get
            {
                return iDPROGRAMA;
            }

            set
            {
                iDPROGRAMA = value;
            }
        }

        public int IDORIENTADOR
        {
            get
            {
                return iDORIENTADOR;
            }

            set
            {
                iDORIENTADOR = value;
            }
        }
        public clsNPeriodoPrograma() { }
    }
}
