using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CapaNegocio
{
    [Serializable]
    public class clsRepresentante
    {
        private int iDORIENTADOR;
        private int iDPERSONA;
        private string aNIOLECTIVO;
        private string rEFERENCIAREPRESENTANTE;
        private string rELACIONREPRESENTANTE;
        private string cODIGOSAD1;
        private string cODIGOSAD2;
        private string cODIGOSAD3;

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

        public string ANIOLECTIVO
        {
            get
            {
                return aNIOLECTIVO;
            }

            set
            {
                aNIOLECTIVO = value;
            }
        }

        public string REFERENCIAREPRESENTANTE
        {
            get
            {
                return rEFERENCIAREPRESENTANTE;
            }

            set
            {
                rEFERENCIAREPRESENTANTE = value;
            }
        }

        public string RELACIONREPRESENTANTE
        {
            get
            {
                return rELACIONREPRESENTANTE;
            }

            set
            {
                rELACIONREPRESENTANTE = value;
            }
        }

        public string CODIGOSAD1
        {
            get
            {
                return cODIGOSAD1;
            }

            set
            {
                cODIGOSAD1 = value;
            }
        }

        public string CODIGOSAD2
        {
            get
            {
                return cODIGOSAD2;
            }

            set
            {
                cODIGOSAD2 = value;
            }
        }

        public string CODIGOSAD3
        {
            get
            {
                return cODIGOSAD3;
            }

            set
            {
                cODIGOSAD3 = value;
            }
        }
        public clsRepresentante() { }
    }
}
