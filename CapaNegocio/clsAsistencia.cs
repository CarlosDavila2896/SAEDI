using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsAsistencia
    {
        private int codigoJoven;

        public int codigoAsistencia ;
        public int idLineaDeAccion;
        public int idPeriodo;
        public int idPersona;
        public int idProcesos;
        public int tipoAsistencia;

        public int CodigoJoven
        {
            get { return codigoJoven; }
            set { codigoJoven = value; }
        }
        private int codigoOrientador;

        public int CodigoOrientador
        {
            get { return codigoOrientador; }
            set { codigoOrientador = value; }
        }
        private DateTime fechaAsistencia;

        public DateTime FechaAsistencia
        {
            get { return fechaAsistencia; }
            set { fechaAsistencia = value; }
        }
        private string fechaAsistenciaString;

        public string FechaAsistenciaString
        {
            get { return fechaAsistenciaString; }
            set { fechaAsistenciaString = value; }
        }
        private int codigoReunion;

        public int CodigoReunion
        {
            get { return codigoReunion; }
            set { codigoReunion = value; }
        }
        private string tema;

        public string Tema
        {
            get { return tema; }
            set { tema = value; }
        }
        private string habilitado;

        public string Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        public clsAsistencia()
        {

        }
        
    }
}
