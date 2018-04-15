using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsNSolucionCuestionario
    {
        private long idSolucion;

        public long IDSOLUCION
        {
            get { return idSolucion; }
            set { idSolucion = value; }
        }

        private int idProceso;

        public int IDPROCESO
        {
            get { return idProceso; }
            set { idProceso = value; }
        }

        private int idObjetivo;

        public int IDOBJETIVO
        {
            get { return idObjetivo; }
            set { idObjetivo = value; }
        }

        private int idIndicador;

        public int IDINDICADOR
        {
            get { return idIndicador; }
            set { idIndicador = value; }
        }

        private int idPregunta;

        public int IDPREGUNTA
        {
            get { return idPregunta; }
            set { idPregunta = value; }
        }

        private int idPersona;

        public int IDPERSONA
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        private int idPeriodo;

        public int IDPERIODO
        {
            get { return idPeriodo; }
            set { idPeriodo = value; }
        }

        private DateTime fechaSolucionCuestionario;

        public DateTime FECHASOLUCIONCUESTIONARIO
        {
            get { return fechaSolucionCuestionario; }
            set { fechaSolucionCuestionario = value; }
        }

        private DateTime fechaModificacionCuestionario;

        public DateTime FECHAMODIFICACIONCUESTIONARIO
        {
            get { return fechaModificacionCuestionario; }
            set { fechaModificacionCuestionario = value; }
        }

        private string textoSolucionCuestionario;

        public string TEXTOSOLUCIONCUESTIONARIO
        {
            get { return textoSolucionCuestionario; }
            set { textoSolucionCuestionario = value; }
        }
        

    }
}
