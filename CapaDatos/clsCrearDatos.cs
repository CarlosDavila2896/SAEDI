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
    public class clsCrearDatos
    {
        clsCrear indicador = new clsCrear();
        clsCrear objetivo = new clsCrear();

        public bool ingresarIndicador(CapaNegocio.clsCrear indicador)
        {
            try
            {
                clsConexion.abrirConexion();

                string cadena = "insert into INDICADOR (NOMBREINDICADOR, ESTADO) values ('" + indicador.NombreIndicador + "', " + indicador.Estado + ")";

                SqlCommand comando = new SqlCommand(cadena, clsConexion.Conexion);

                comando.ExecuteNonQuery();                              // Ejecutamos el comando

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally                                                     // Si no entra ni en try ni en catch
            {
                clsConexion.cerrarConexion();                                  // Siempre en finally se cierra la conexión con la base de datos
            }
        }



        public bool eliminarIndicador(int id)
        {
            indicador.Id_Indicador = id;
            try
            {
                clsConexion.abrirConexion();

                string query = "update INDICADOR" +
                    " set ESTADO=" + 0 +
                    " where IDINDICADOR=" + indicador.Id_Indicador;

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

        public bool ingresarObjetivo(clsCrear objetivo)
        {
            try
            {
                clsConexion.abrirConexion();

                string cadena = "insert into OBJETIVO (NOMBREOBJETIVO, ESTADOOBJETIVO) values ('" + objetivo.NombreObjetivo + "', " + objetivo.Estado + ")";

                SqlCommand comando = new SqlCommand(cadena, clsConexion.Conexion);

                comando.ExecuteNonQuery();                              // Ejecutamos el comando

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally                                                     // Si no entra ni en try ni en catch
            {
                clsConexion.cerrarConexion();                                  // Siempre en finally se cierra la conexión con la base de datos
            }
        }

        public bool eliminarObjetivo(int id)
        {
            objetivo.ID_Objetivo = id;
            try
            {
                clsConexion.abrirConexion();

                string query = "update OBJETIVO" +
                    " set ESTADOOBJETIVO=" + 0 +
                    " where OBJETIVOID=" + objetivo.ID_Objetivo;

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

        public bool ingresarRelacion(clsCrear relacion)
        {
            try
            {
                clsConexion.abrirConexion();

                string cadena = "insert into OBJETIVO_INDICADOR (OBJETIVOID, IDINDICADOR, ESTADO) values (" + relacion.ID_Objetivo + ", " + relacion.Id_Indicador + "," + relacion.Estado + ")";

                SqlCommand comando = new SqlCommand(cadena, clsConexion.Conexion);

                comando.ExecuteNonQuery();                              // Ejecutamos el comando

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally                                                     // Si no entra ni en try ni en catch
            {
                clsConexion.cerrarConexion();                                  // Siempre en finally se cierra la conexión con la base de datos
            }
        }

        public bool EliminarRelacion(int id)
        {
            objetivo.ID_Objetivo = id;
            try
            {
                clsConexion.abrirConexion();

                string query = "update OBJETIVO_INDICADOR" +
                    " set ESTADO=" + 0 +
                    " where OBJETIVOID=" + objetivo.ID_Objetivo;

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

        public bool ingresarRelacionPregunta(clsCrear relacion)
        {
            try
            {
                clsConexion.abrirConexion();

                string cadena = "update PREGUNTA" +
                    " set IDINDICADOR=" + relacion.Id_Indicador +
                    " where IDPREGUNTA=" + relacion.ID_Pregunta;

                SqlCommand comando = new SqlCommand(cadena, clsConexion.Conexion);

                comando.ExecuteNonQuery();                              // Ejecutamos el comando

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally                                                     // Si no entra ni en try ni en catch
            {
                clsConexion.cerrarConexion();                                  // Siempre en finally se cierra la conexión con la base de datos
            }
        }

        public bool eliminarRelacion(clsCrear relacion)
        {
            try
            {
                clsConexion.abrirConexion();

                string query = "update OBJETIVO_INDICADOR" +
                    " set ESTADO=" + 0 +
                    " where OBJETIVOID=" + relacion.ID_Objetivo + "AND IDINDICADOR=" + relacion.Id_Indicador;

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

        public bool eliminarRelacionIndicadorPregunta(clsCrear relacion)
        {
            try
            {
                clsConexion.abrirConexion();

                string query = "update PREGUNTA" +
                    " set IDINDICADOR=" + "Null" +
                    " where IDPREGUNTA=" + relacion.ID_Pregunta + "AND IDINDICADOR=" + relacion.Id_Indicador;

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
    }
}
