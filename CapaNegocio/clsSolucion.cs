using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsSolucion
    {

        private int idRespuesta;

        public int IdRespuesta
        {
            get { return idRespuesta; }
            set { idRespuesta = value; }
        }

        private string respuestaTexto;

        public string RespuestaTexto
        {
            get { return respuestaTexto; }
            set { respuestaTexto = value; }
        }

        private int idPregunta;

        public int IdPregunta
        {
            get { return idPregunta; }
            set { idPregunta = value; }
        }

        private DateTime fechaSolucion;

        public DateTime FechaSolucion
        {
            get { return fechaSolucion; }
            set { fechaSolucion = value; }
        }
        private string ObjetivoIndicador;

        public string ObjetivoIndicador1
        {
            get { return ObjetivoIndicador; }
            set { ObjetivoIndicador = value; }
        }
        private int idIndicador;

        public int IdIndicador
        {
            get { return idIndicador; }
            set { idIndicador = value; }
        }
        private int idRepresentante;

        public int IdRepresentante
        {
            get { return idRepresentante; }
            set { idRepresentante = value; }
        }
        private string nombrePregunta;

        public string NombrePregunta
        {
            get { return nombrePregunta; }
            set { nombrePregunta = value; }
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

        private int idPersona;
    }
        
}
