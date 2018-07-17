using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsMenorEdad
    {
        private int idPersona;

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        private int idMenorEdad;

        public int IdMenorEdad
        {
            get { return idMenorEdad; }
            set { idMenorEdad = value; }
        }
        private int idRepresentante;

        public int IdRepresentante
        {
            get { return idRepresentante; }
            set { idRepresentante = value; }
        }
        private int idOrientador;

        public int IdOrientador
        {
            get { return idOrientador; }
            set { idOrientador = value; }
        }
        private string sad;

        public string Sad
        {
            get { return sad; }
            set { sad = value; }
        }
        private int anioIngreso;

        public int AnioIngreso
        {
            get { return anioIngreso; }
            set { anioIngreso = value; }
        }

        private int nombreEncargado;

        public int NombreEncargado
        {
            get { return nombreEncargado; }
            set { nombreEncargado = value; }
        }
        
        public clsMenorEdad()
        {

        }
    }
}
