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
    public class clsActualizarDatos
    {
        public List<clsCrear> leerIndicadores()
        {
            clsConexion clsConexion = new clsConexion();


            string cadena = "Select IDINDICADOR, NOMBREINDICADOR from INDICADOR WHERE ESTADO=" + 1;
            SqlCommand comando = new SqlCommand(cadena, clsConexion.conexion);

            List<clsCrear> listaIndicadores = new List<clsCrear>();

            try
            {
                clsConexion.abrirConexion();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    clsCrear indicador = new clsCrear();

                    indicador.Id_Indicador = lector.GetInt32(0);
                    indicador.NombreIndicador = lector.GetString(1).ToString();
                    listaIndicadores.Add(indicador);
                    
                }
                
                return listaIndicadores;
            }
            catch (Exception)
            {
                return listaIndicadores;
            }
            finally
            {
                clsConexion.cerrarConexion();
            }
        }

        public bool ActualizarIndicadores(clsCrear indicador)
        {
            clsConexion clsConexion = new clsConexion();

            try
            {
                clsConexion.abrirConexion();
                string sql = "update INDICADOR set NOMBREINDICADOR='" + indicador.NombreIndicador +
                    "' where IDINDICADOR=" + indicador.Id_Indicador;

                SqlCommand comando = new SqlCommand(sql, clsConexion.Conexion);
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



        public clsCrear obtenerDatosObjetivos(int id)
        {
            clsConexion clsConexion = new clsConexion();

            string cadena = "Select * from OBJETIVO WHERE OBJETIVOID=" + id;

            SqlCommand comando = new SqlCommand(cadena, clsConexion.Conexion);
            clsConexion.abrirConexion();       

            SqlDataReader lector = comando.ExecuteReader();
            clsCrear objetivo = new clsCrear();

            while (lector.Read())
            {
               objetivo.ID_Objetivo = lector.GetInt32(0);
               objetivo.NombreObjetivo = lector.GetString(2);
            }
            clsConexion.cerrarConexion();
            return objetivo;          
        }

        public clsCrear obtenerDatosIndicador(int p)
        {
            clsConexion clsConexion = new clsConexion();

            string sql = "select * from INDICADOR where IDINDICADOR=" + p;
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            clsConexion.abrirConexion();

            SqlDataReader lector = comando.ExecuteReader();

            clsCrear indicador = new clsCrear();

            while (lector.Read())
            {
                indicador.Id_Indicador = lector.GetInt32(0);
                indicador.NombreIndicador = lector.GetString(1);
            }

            clsConexion.cerrarConexion();
            return indicador;
        }

        public bool editarIndicador(clsCrear indicador)
        {
            clsConexion clsConexion = new clsConexion();
            try
            {
                string sql = "update INDICADOR set " +
                    "NOMBREINDICADOR='" + indicador.NombreIndicador + "' where IDINDICADOR=" + indicador.Id_Indicador;
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

        public bool editarObjetivo(clsCrear objetivo)
        {
            clsConexion clsConexion = new clsConexion();
            try
            {
                string sql = "update OBJETIVO set " +
                    "NOMBREOBJETIVO='" + objetivo.NombreObjetivo + "' where OBJETIVOID=" + objetivo.ID_Objetivo;
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

        public bool editarRelacion(clsCrear relacion, clsCrear datos)
        {
            clsConexion clsConexion = new clsConexion();
            try
            {
                string sql = "UPDATE OBJETIVO_INDICADOR" +
                    " set OBJETIVOID=" + datos.ID_Objetivo + ", IDINDICADOR=" + datos.Id_Indicador +
                    "where OBJETIVOID=" + relacion.ID_Objetivo + " AND IDINDICADOR=" + relacion.Id_Indicador;
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

        public clsCrear obtenerDatosPregunta(int p)
        {
            clsConexion clsConexion = new clsConexion();

            string sql = "select * from PREGUNTA where IDPREGUNTA=" + p;
            SqlCommand comando = new SqlCommand(sql, clsConexion.Conexion);

            clsConexion.abrirConexion();

            SqlDataReader lector = comando.ExecuteReader();

            clsCrear pregunta = new clsCrear();

            while (lector.Read())
            {
                pregunta.ID_Pregunta= lector.GetInt32(0);
                pregunta.NombrePregunta = lector.GetString(3);
            }

            clsConexion.cerrarConexion();
            return pregunta;
        }

        public bool editarRelacionIndicadorPregunta(clsCrear relacion, clsCrear datos)
        {
            clsConexion clsConexion = new clsConexion();
            try
            {
                string sql = "UPDATE PREGUNTA" +
                    " set IDINDICADOR=" + datos.Id_Indicador +
                    "where IDPREGUNTA=" + relacion.ID_Pregunta + " AND IDINDICADOR=" + relacion.Id_Indicador;
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
