using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class clsCrear
    {
        private int id_Indicador;

        public int Id_Indicador
        {
            get { return id_Indicador; }
            set { id_Indicador = value; }
        }

        private string nombreIndicador;

        public string NombreIndicador
        {
            get { return nombreIndicador; }
            set { nombreIndicador = value; }
        }

        private int iD_Objetivo;

        public int ID_Objetivo
        {
            get { return iD_Objetivo; }
            set { iD_Objetivo = value; }
        }

        private string nombreObjetivo;

        public string NombreObjetivo
        {
            get { return nombreObjetivo; }
            set { nombreObjetivo = value; }
        }

        private int visitaDomiciliar;

        public int VisitaDomiciliar
        {
            get { return visitaDomiciliar; }
            set { visitaDomiciliar = value; }
        }

        private int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private int iD_Pregunta;

        public int ID_Pregunta
        {
            get { return iD_Pregunta; }
            set { iD_Pregunta = value; }
        }

        private string nombrePregunta;

        public string NombrePregunta
        {
            get { return nombrePregunta; }
            set { nombrePregunta = value; }
        }
    }
}
