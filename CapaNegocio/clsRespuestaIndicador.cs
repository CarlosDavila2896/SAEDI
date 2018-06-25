using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    [Serializable]
    public class clsRespuestaIndicador
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private int idPregunta;

        public int IdPregunta
        {
            get { return idPregunta; }
            set { idPregunta = value; }
        }

        private int idIndicador;

        public int IdIndicador
        {
            get { return idIndicador; }
            set { idIndicador = value; }
        }
        private int idRespuesta;

        public int IdRespuesta
        {
            get { return idRespuesta; }
            set { idRespuesta = value; }
        }
        private int idPersona;

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        private decimal puntaje;

        public decimal Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }
        private string observacionCertificado;

        public string ObservacionCertificado
        {
            get { return observacionCertificado; }
            set { observacionCertificado = value; }
        }
        private DateTime fechaRespuesta;

        public DateTime FechaRespuesta
        {
            get { return fechaRespuesta; }
            set { fechaRespuesta = value; }
        }

        private string respuestatexto;

        public string Respuestatexto
        {
            get
            {
                return respuestatexto;
            }

            set
            {
                respuestatexto = value;
            }
        }

        

    }
}
