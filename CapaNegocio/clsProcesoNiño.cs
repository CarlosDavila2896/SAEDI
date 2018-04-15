using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class clsProcesoNiño
    {
        private int IDProceso;

        public int IDProceso1
        {
            get { return IDProceso; }
            set { IDProceso = value; }
        }
        private int IDOrientador;

        public int IDOrientador1
        {
            get { return IDOrientador; }
            set { IDOrientador = value; }
        }
        private string nombreProceso;

        public string NombreProceso
        {
            get { return nombreProceso; }
            set { nombreProceso = value; }
        }

        private int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private int idProcesoDuplicado;

        public int IdProcesoDuplicado
        {
            get { return idProcesoDuplicado; }
            set { idProcesoDuplicado = value; }
        }
    }
}
