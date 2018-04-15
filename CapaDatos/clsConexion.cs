using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class clsConexion
    {
        public static string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public static SqlConnection conexion = new SqlConnection(cadena);

        public static SqlConnection Conexion
        {
            get { return conexion; }
            set { conexion = value; }
        }

        // ABRIR CONEXIÓN

        public static void abrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }

        // CERRAR CONEXIÓN

        public static void cerrarConexion()
        {

            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }
    }
}
