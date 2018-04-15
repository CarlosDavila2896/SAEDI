using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
   public class clsNPregunta
    {
        private int idPregunta;

        public int IDPREGUNTA
        {
            get { return idPregunta; }
            set { idPregunta = value; }
        }
        
        private int idTipoPregunta;

        public int IDTIPOPREGUNTA
        {
            get { return idTipoPregunta; }
            set { idTipoPregunta = value; }
        }

        private string nombrePregunta;

        public string NOMBREPREGUNTA
        {
            get { return nombrePregunta; }
            set { nombrePregunta = value; }
        }

        private bool estadoPregunta;

        public bool ESTADOPREGUNTA
        {
            get { return estadoPregunta; }
            set { estadoPregunta = value; }
        }

    }
}
