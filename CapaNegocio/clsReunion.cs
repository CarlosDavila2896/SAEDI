using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsReunion
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idorientador;
        private int idIndicador;

        public int IdIndicador
        {
            get { return idIndicador; }
            set { idIndicador = value; }
        }
        public int Idorientador
        {
            get { return idorientador; }
            set { idorientador = value; }
        }

        private int idrepresentante;

        public int Idrepresentante
        {
            get { return idrepresentante; }
            set { idrepresentante = value; }
        }
        public int idPeriodoPrograma
        {
            get { return minuto; }
            set { minuto = value; }
        }

        private String tema;

        public String Tema
        {
            get { return tema; }
            set { tema = value; }
        }

        private string habilitado;

        public string Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        private String fecha;

        public String Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string hora;

        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        private int minuto;

        public int Minuto
        {
            get { return minuto; }
            set { minuto = value; }
        }
        private String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
       
    }
}
