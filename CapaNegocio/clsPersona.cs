using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class clsPersona
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
       

        private int idRepresentate;

        public int IdRepresentate
        {
            get { return idRepresentate; }
            set { idRepresentate = value; }
        }
        private int idParentezco;

        public int IdParentezco
        {
            get { return idParentezco; }
            set { idParentezco = value; }
        }
        private int idAlimentacion;

        public int IdAlimentacion
        {
            get { return idAlimentacion; }
            set { idAlimentacion = value; }
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
        private bool genero;

        public bool Genero
        {
            get { return genero; }
            set { genero = value; }
        }
        private DateTime nacimiento;

        public DateTime Nacimiento
        {
            get { return nacimiento; }
            set { nacimiento = value; }
        }
        private string cedula;

        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        private string lugarNacimiento;

        public string LugarNacimiento
        {
            get { return lugarNacimiento; }
            set { lugarNacimiento = value; }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private bool viveFamilia;

        public bool ViveFamilia
        {
            get { return viveFamilia; }
            set { viveFamilia = value; }
        }
        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        private DateTime ingreso;

        public DateTime Ingreso
        {
            get { return ingreso; }
            set { ingreso = value; }
        }
        private bool cabeza;

        public bool Cabeza
        {
            get { return cabeza; }
            set { cabeza = value; }
        }

        private List<string> numeros;

        public List<string> Numeros
        {
            get { return numeros; }
            set { numeros = value; }
        }

    }
}
