﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class clsDatosJovenes
    {

        static clsJoven transformar(JOVEN newJoven)
        {
            clsJoven joven = new clsJoven();
            joven.Cedula = newJoven.IDJOVEN;
            joven.IdMenor = newJoven.IDMENOREDAD;
            joven.IdPersona = newJoven.IDPERSONA;
            return joven;
        }
        static clsMenorEdad transformarMenor(MENOREDAD newMenor)
        {
            clsMenorEdad menor = new clsMenorEdad();
            menor.Alimentacion = newMenor.ALIMENTACIONMENOREDAD;
            menor.AnioIngreso = newMenor.ANIOINGRESOMENOREDAD;
            menor.Discapacidad = newMenor.DISCAPACIDADESMENOREDAD;
            menor.IdMenorEdad = newMenor.IDMENOREDAD;
            menor.IdPersona = newMenor.IDPERSONA;
            menor.NombreEncargado = newMenor.NOMBREENCARGADOMENOREDAD;
            menor.Sacramento = newMenor.SACRAMENTOMENOREDAD;
            menor.Sad = newMenor.CODIGOSADMENOREDAD;
            menor.Vacunas = newMenor.VACUNASMENOREDAD;
            menor.IdRepresentante = int.Parse(newMenor.IDREPRESENTANTE.ToString());
            return menor;
        }

    }
}
