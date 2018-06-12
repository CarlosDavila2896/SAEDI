using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    [Serializable]
    public class clsNPosibleRespuesta
    {
        private int IdPosibleRespuesta;

        public int IDPOSIBLERESPUESTA
        {
            get { return IdPosibleRespuesta; }
            set { IdPosibleRespuesta = value; }
        }
        
        private string TextoPosibleRespuesta;

        public string TEXTOPOSIBLERESPUESTA
        {
            get { return TextoPosibleRespuesta; }
            set { TextoPosibleRespuesta = value; }
        }
        private int puntajePosibleRespuesta;

        public int PUNTAJEPOSIBLERESPUESTA
        {
            get { return puntajePosibleRespuesta; }
            set { puntajePosibleRespuesta = value; }
        }

        private bool estadoPosibleRespuesta;

        public bool ESTADOPOSIBLERESPUESTA
        {
            get { return estadoPosibleRespuesta; }
            set { estadoPosibleRespuesta = value; }
        }
        public clsNPosibleRespuesta()
        {

        }
    }
}
