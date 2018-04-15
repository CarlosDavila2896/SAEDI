using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace CapaNegocio
{
    public class clsasignarfamilia
    {
        //------ddlFamilia----
        private string parentezco;

        public string Parentezco
        {
            get { return parentezco; }
            set { parentezco = value; }
        }

        private int codigoParentezco;

        
        private int codigoFamilia;

        public int CodigoFamilia
        {
            get { return codigoFamilia; }
            set { codigoFamilia = value; }
        }
        private string nombreFamilia;

        public string NombreFamilia
        {
            get { return nombreFamilia; }
            set { nombreFamilia = value; }
        }
        //---------ListPersonaSin----


        private int persona;

        public int Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        private string primerNombre;

        public string PrimerNombre
        {
            get { return primerNombre; }
            set { primerNombre = value; }
        }
        private string segundoNombre;

        public string SegundoNombre
        {
            get { return segundoNombre; }
            set { segundoNombre = value; }
        }
        private string primerApellido;

        public string PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }
        private string segundoApellido;

        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }
        private bool familia;

        public bool Familia
        {
            get { return familia; }
            set { familia = value; }
        }

        //-----------------------so
        private int codigoPersona;

        public int CodigoPersona
        {
            get { return codigoPersona; }
            set { codigoPersona = value; }
        }

        public int CodigoParentezco
        {
            get
            {
                return codigoParentezco;
            }

            set
            {
                codigoParentezco = value;
            }
        }
    }
    



}
