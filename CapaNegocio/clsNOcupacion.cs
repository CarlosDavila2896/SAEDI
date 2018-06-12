using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsNOcupacion
    {
        private int idAlimentacion2;

        public int IdAlimentacion2
        {
            get { return idAlimentacion2; }
            set { idAlimentacion2 = value; }
        }
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private int estadoTipoPregunta;

        public int EstadoTipoPregunta
        {
            get { return estadoTipoPregunta; }
            set { estadoTipoPregunta = value; }
        }

        private DateTime fechaTipoPregunta;

        public DateTime FechaTipoPregunta
        {
            get { return fechaTipoPregunta; }
            set { fechaTipoPregunta = value; }
        }

        public clsNOcupacion()
        {

        } 

    }
}
