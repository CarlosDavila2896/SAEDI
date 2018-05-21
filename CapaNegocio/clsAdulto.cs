using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsAdulto
    {
        private int idPersona;
        private bool estudiaAdulto;

        public bool EstudiaAdulto
        {
            get { return estudiaAdulto; }
            set { estudiaAdulto = value; }
        }
        private string dondeEstudiaAdulto;

        public string DondeEstudiaAdulto
        {
            get { return dondeEstudiaAdulto; }
            set { dondeEstudiaAdulto = value; }
        }

        private string nivelEducacion;

        public string NivelEducacion
        {
            get { return nivelEducacion; }
            set { nivelEducacion = value; }
        }

        public int IdPersona
        {
            get
            {
                return idPersona;
            }

            set
            {
                idPersona = value;
            }
        }

        public clsAdulto()
        {

        }
    }
}
