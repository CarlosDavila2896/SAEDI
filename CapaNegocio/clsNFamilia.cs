using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsNFamilia
    {
        private int iDFAMILIA;
        private int iDTIPOFAMILIA;
        private string nOMBREFAMILIA;
        private string oBSERVACIONFAMILIA;
        private int miembrosFamilia;
        private DateTime aNIOINGRESOFAMILIA;
        private string dIRECCIONFAMILIA;
        public int IDFAMILIA
        {
            get
            {
                return iDFAMILIA;
            }

            set
            {
                iDFAMILIA = value;
            }
        }

        public int IDTIPOFAMILIA
        {
            get
            {
                return iDTIPOFAMILIA;
            }

            set
            {
                iDTIPOFAMILIA = value;
            }
        }

        public int MIEMBROSFAMILIA
        {
            get
            {
                return miembrosFamilia;
            }

            set
            {
                miembrosFamilia = value;
            }
        }

        public string NOMBREFAMILIA
        {
            get
            {
                return nOMBREFAMILIA;
            }

            set
            {
                nOMBREFAMILIA = value;
            }
        }

        public string OBSERVACIONFAMILIA
        {
            get
            {
                return oBSERVACIONFAMILIA;
            }

            set
            {
                oBSERVACIONFAMILIA = value;
            }
        }

        public DateTime ANIOINGRESOFAMILIA
        {
            get
            {
                return aNIOINGRESOFAMILIA;
            }

            set
            {
                aNIOINGRESOFAMILIA = value;
            }
        }

        public string DIRECCIONFAMILIA
        {
            get
            {
                return dIRECCIONFAMILIA;
            }

            set
            {
                dIRECCIONFAMILIA = value;
            }
        }
    }
}
