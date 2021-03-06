﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    [Serializable]
    public class clsAsistencia
    {
        private int codigoJoven;


        private int codigoAsistencia;
        public int CodigoAsistencia
        {
            get { return codigoAsistencia; }
            set { codigoAsistencia = value; }
        }
        private int idLineaDeAccion;
        public int IdLineaDeAccion
        {
            get { return idLineaDeAccion; }
            set { idLineaDeAccion = value; }
        }
        private int idPeriodo;
        public int IdPeriodo
        {
            get { return idPeriodo; }
            set { idPeriodo = value; }
        }
        private int idPersona;
        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        private int idProcesos;
        public int IdProcesos
        {
            get { return idProcesos; }
            set { idProcesos = value; }
        }
        private int tipoAsistencia;
        public int TipoAsistencia
        {
            get { return tipoAsistencia; }
            set { tipoAsistencia = value; }
        }

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
