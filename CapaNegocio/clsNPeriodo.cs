using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsNPeriodo
    {
        private int iDPeriodo;
        private string nOMBREPERIODO;
        private DateTime fECHAINICIOPERIODO;
        private DateTime fECHAFINPERIODO;
        private bool aCTIVO;
        private int idTipoPeriodo;

        public int IDPeriodo
        {
            get
            {
                return iDPeriodo;
            }

            set
            {
                iDPeriodo = value;
            }
        }

        public int IDTIPOPERIODO
        {
            get
            {
                return idTipoPeriodo;
            }

            set
            {
                idTipoPeriodo = value;
            }
        }

        public string NOMBREPERIODO
        {
            get
            {
                return nOMBREPERIODO;
            }

            set
            {
                nOMBREPERIODO = value;
            }
        }

        public DateTime FECHAINICIOPERIODO
        {
            get
            {
                return fECHAINICIOPERIODO;
            }

            set
            {
                fECHAINICIOPERIODO = value;
            }
        }

        public DateTime FECHAFINPERIODO
        {
            get
            {
                return fECHAFINPERIODO;
            }

            set
            {
                fECHAFINPERIODO = value;
            }
        }

        public bool ACTIVO
        {
            get
            {
                return aCTIVO;
            }

            set
            {
                aCTIVO = value;
            }
        }

        public clsNPeriodo()
        {

        }
    }
}
