using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDatosParentesco
    {
        public clsParentesco obtenerParentesco(int id)
        {
            clsConexion clsConexion = new clsConexion();

            string sql = "select * from PARENTEZCO where IDPARENTEZCO=" + id;
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            clsConexion.abrirConexion();

            SqlDataReader lector = comando.ExecuteReader();

            clsParentesco objParentesco = new clsParentesco();

            while (lector.Read())
            {
                objParentesco.Codigo = lector.GetInt32(0);
                objParentesco.NombreParentesco = lector.GetString(1);
            }

            clsConexion.cerrarConexion();
            return objParentesco;
        }

        public bool ingresarParentesco(clsParentesco objParentesco)
        {
          
            try
            {
                clsConexion.abrirConexion();

                string cadena = "insert into PARENTEZCO (NOMBREPARENTEZCO) values ('" + objParentesco.NombreParentesco + "')";
            
                SqlCommand comando = new SqlCommand(cadena, clsConexion.Conexion);

                comando.ExecuteNonQuery();                              

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally                                                     
            {
                clsConexion.cerrarConexion();
            }
        }

        public bool eliminarParentesco(int id)
        {
            clsParentesco objParentesco = new clsParentesco();

            objParentesco.Codigo = id;

            try
            {
                clsConexion.abrirConexion();

                string query = "delete from PARENTEZCO where IDPARENTEZCO=" + objParentesco.Codigo;

                SqlCommand comando = new SqlCommand(query, clsConexion.Conexion);

                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                clsConexion.cerrarConexion();
            }
        }

        public bool actualizarParentesco(clsParentesco objParentesco)
        {
            clsConexion clsConexion = new clsConexion();
            try
            {
                string sql = "update PARENTEZCO set " +
                    "NOMBREPARENTEZCO='" + objParentesco.NombreParentesco + "' where IDPARENTEZCO=" + objParentesco.Codigo;
                SqlCommand comando = new SqlCommand(sql, clsConexion.Conexion);

                clsConexion.abrirConexion();

                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                clsConexion.cerrarConexion();
            }
        }
    }
}
