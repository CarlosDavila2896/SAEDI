using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
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
        private double peso;

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        private double talla;

        public double Talla
        {
            get { return talla; }
            set { talla = value; }
        }
        private string discapacidad;

        public string Discapacidad
        {
            get { return discapacidad; }
            set { discapacidad = value; }
        }
        private bool vacunas;

        public bool Vacunas
        {
            get { return vacunas; }
            set { vacunas = value; }
        }
        private int alimentacion;

        public int Alimentacion
        {
            get { return alimentacion; }
            set { alimentacion = value; }
        }
        private int nombreEncargado;

        public int NombreEncargado
        {
            get { return nombreEncargado; }
            set { nombreEncargado = value; }
        }
        private string sacramento;

        public string Sacramento
        {
            get { return sacramento; }
            set { sacramento = value; }
        }
    }
}
