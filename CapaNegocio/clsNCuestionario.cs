
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsNCuestionario
    {
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

        private string observacioCuestionario;

        public string OBSERVACIONCUESTIONARIO
        {
            get { return observacioCuestionario; }
            set { observacioCuestionario = value; }
        }

        private bool estadoCuestionario;

        public bool ESTADOCUESTIONARIO
        {
            get { return estadoCuestionario; }
            set { estadoCuestionario = value; }
        }
    }
}
