using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsJoven
    {
        private int idMenor;
        public int IdMenor
        {
            get { return idMenor; }
            set { idMenor = value; }
        }
        private int idPersona;

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        private string nombreApellido;

        public string NombreApellido
        {
            get { return nombreApellido; }
            set { nombreApellido = value; }
        }


        private String cedula;

        public String Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        private int codigoJoven;

        public int CodigoJoven
        {
            get { return codigoJoven; }
            set { codigoJoven = value; }
        }
        private int codigoReunion;

        public int CodigoReunion
        {
            get { return codigoReunion; }
            set { codigoReunion = value; }
        }
        private int codigoIndicador;

        public int CodigoIndicador
        {
            get { return codigoIndicador; }
            set { codigoIndicador = value; }
        }
        private string tema;

        public string Tema
        {
            get { return tema; }
            set { tema = value; }
        }
    }
}
