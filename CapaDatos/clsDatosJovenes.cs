using System;
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
            joven.idMenor = newJoven.IDMENOREDAD;
            joven.idPersona = newJoven.IDPERSONA;
            return joven;
        }

    }
}
