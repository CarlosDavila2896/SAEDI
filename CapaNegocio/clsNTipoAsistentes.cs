using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsNTipoAsistentes
    {
        private int idTipoAsistentes;
        public int IdTipoAsistentes
        {
            get { return idTipoAsistentes; }
            set { idTipoAsistentes = value; }
        }

        private String nombreTipoAsistentes;
        public String NombreTipoAsistentes
        {
            get { return nombreTipoAsistentes; }
            set { nombreTipoAsistentes = value; }
        }

        public clsNTipoAsistentes() { }
    }
}
