using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class clsDatosSolucion
    {
        // INGRESAR SOLUCIÓN RADIOBUTTON
        static clsSolucion transformar(SOLUCIONCUESTIONARIO newSolucion)
        {
            clsSolucion solucion = new clsSolucion();
            solucion.IdProceso = newSolucion.IDPROCESO;
            solucion.IdObjetivo = newSolucion.IDOBJETIVO;
            solucion.IdIndicador = newSolucion.IDINDICADOR;
            solucion.IdPregunta = newSolucion.IDPREGUNTA;
            solucion.IdPersona = newSolucion.IDPERSONA;
            solucion.IdPeriodo = newSolucion.IDPERIODO;
            solucion.FechaSolucion = newSolucion.FECHASOLUCIONCUESTIONARIO;
            solucion.RespuestaTexto = newSolucion.TEXTOSOLUCIONCUESTIONARIO;

            return solucion; 
        }
        public bool ingresarSolucionOpciones(clsSolucion solucion)
        {
            try
            {
                string sql = "insert into SOLUCIONESCUESTIONARIOS (IDRESPUESTA, IDPREGUNTA, FECHASOLUCION,IDINDICADOR) values " +
                    " (" + solucion.IdRespuesta + ", " + solucion.IdPregunta + ", '" +
                    solucion.FechaSolucion.ToString("yyyy-MM-dd") + "'," + solucion.IdIndicador + ")";
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
        public bool ingresarSolucionOpcionesReunion(clsSolucion solucion)
        {
            try
            {
                string sql = "insert into SOLUCIONESCUESTIONARIOS (IDRESPUESTA, IDPREGUNTA, FECHASOLUCION,IDREPRESENTANTE,IDINDICADOR,IDPERSONA) values " +
                    " (" + solucion.IdRespuesta + ", " + solucion.IdPregunta + ", '" +
                    solucion.FechaSolucion.ToString("yyyy-MM-dd") + "'," +solucion.IdRepresentante+", "+ solucion.IdIndicador +", "+ solucion.IdPersona +  ")";
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

        // INGRESAR SOLUCIÓN TEXTBOX


        public bool ingresarDatosRespuestaLogros(clsRespuestaIndicador claseRespuestaIndicador)
        {
            try
            {
                string sql = "insert into RESPUESTA_INDICADOR(IDPREGUNTA,IDINDICADOR,IDRESPUESTA,IDPERSONA,FECHARESPUESTAINDICADOR) values " +
                             " (" + claseRespuestaIndicador.IdPregunta + ", " + claseRespuestaIndicador.IdIndicador + ", " + claseRespuestaIndicador.IdRespuesta + " , " +
                             claseRespuestaIndicador.IdPersona + ", '" +   claseRespuestaIndicador.FechaRespuesta.ToString("yyyy-MM-dd") + "')";
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

        public bool editarRespuestaLogros(clsRespuestaIndicador claseRespuestaIndicador)
        {
            try
            {
                SqlCommand comando = new SqlCommand("update RESPUESTA_INDICADOR set IDRESPUESTA='" + claseRespuestaIndicador.IdRespuesta +
                    "',RESPUESTATEXTOS='" + claseRespuestaIndicador.Respuestatexto + "' where IDRPEGUNTA = "
                    +  claseRespuestaIndicador.IdPregunta + " 'AND IDINDICADOR="+ claseRespuestaIndicador.IdIndicador+ " 'AND IDPERSONA="+ claseRespuestaIndicador.IdPersona + " 'AND IDRESPUESTAINDICADOR=" + claseRespuestaIndicador.Codigo , clsConexion.Conexion);

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


        public bool ingresarSolucionestextoLogros(clsRespuestaIndicador claseRespuestaIndicador)
        {
            try
            {
                string sql = "insert into RESPUESTA_INDICADOR(IDPREGUNTA,IDINDICADOR,IDPERSONA,FECHARESPUESTAINDICADOR,RESPUESTATEXTOS) values " +
                             " (" + claseRespuestaIndicador.IdPregunta + ", " + claseRespuestaIndicador.IdIndicador + ", " +
                             claseRespuestaIndicador.IdPersona + ", '" + claseRespuestaIndicador.FechaRespuesta.ToString("yyyy-MM-dd")+ "', '" + claseRespuestaIndicador.Respuestatexto +"')";
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



        public bool ingresarSolucionTexto(clsSolucion solucion)
        {
            try
            {
               

                string sql = "insert into SOLUCIONESCUESTIONARIOS (RESPUESTATEXTO, IDPREGUNTA, FECHASOLUCION, IDINDICADOR) values " +
                    " ('" + solucion.RespuestaTexto + "', " + solucion.IdPregunta + ", '" +
                    solucion.FechaSolucion.ToString("yyyy-MM-dd") + "',"+solucion.IdIndicador+")";
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

        public bool ingresarSolucionTextoReunion(clsSolucion solucion)
        {
            try
            {
                string sql = "insert into SOLUCIONESCUESTIONARIOS (RESPUESTATEXTO, IDPREGUNTA, FECHASOLUCION, IDREPRESENTANTE, IDINDICADOR, IDPERSONA) values " +
                    " ('" + solucion.RespuestaTexto + "', " + solucion.IdPregunta + ", '" +
                    solucion.FechaSolucion.ToString("yyyy-MM-dd") + "'," + solucion.IdRepresentante + ", " + solucion.IdIndicador + ", " + solucion.IdPersona + ")";
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

        public bool ingresarSolucionTextologros(clsSolucion solucion)
        {
            try
            {
                string sql = "insert into SOLUCIONESCUESTIONARIOS (RESPUESTATEXTO, IDPREGUNTA, FECHASOLUCION, IDREPRESENTANTE, IDINDICADOR) values " +
                    " ('" + solucion.RespuestaTexto + "', " + solucion.IdPregunta + ", '" +
                    solucion.FechaSolucion.ToString() + "'," + solucion.IdRepresentante + ", " + solucion.IdIndicador + ")";
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

        public List<clsSolucion> consultaDatosObjetivoIndicador(int IDPROCESO)
        {
            try
            {
                string sql = "SELECT  i.IDINDICADOR, (o.NOMBREOBJETIVO + ' - ' + i.NOMBREINDICADOR) AS 'Objetivo - Indicador' FROM [PROCESO_OBJETIVO] AS p, OBJETIVO AS o, OBJETIVO_INDICADOR AS s, INDICADOR AS i,PROCESO AS pro WHERE ((p.[ESTADOPROCESOBJETIVO] = " + 1 + ") AND (p.[IDPROCESO] = pro.[IDPROCESODUPLICADO]) AND (p.OBJETIVOID = o.OBJETIVOID) AND (pro.[IDPROCESODUPLICADO] = " + IDPROCESO + ")AND (o.OBJETIVOID = s.OBJETIVOID) AND (i.IDINDICADOR = s.IDINDICADOR))";

                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                List<clsSolucion> listaOrientador = new List<clsSolucion>();

                clsConexion.abrirConexion();

                // el lectorProductos consigue todo el contenido dentro de la tabla Producto
                SqlDataReader lectorJovenes = comando.ExecuteReader();
                //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
                while (lectorJovenes.Read())
                {
                    clsSolucion objOrientador = new clsSolucion();
                    // cada indice significa el lugar dentro de la tabla Producto
                    // Es importante conocer la estructura de la tabla, sino genera error

                    //
                    bool fecha = false;
                    objOrientador.IdIndicador = lectorJovenes.GetInt32(0);
                    objOrientador.ObjetivoIndicador1 = lectorJovenes.GetString(1);
                    if (listaOrientador.Count == 0)
                    {
                        listaOrientador.Add(objOrientador);
                    }
                    else
                    {
                        for (int i = 0; i < listaOrientador.Count; i++)
                        {

                            if (listaOrientador[i].ObjetivoIndicador1 == objOrientador.ObjetivoIndicador1)
                            {

                                fecha = true;

                            }


                        }
                        if (fecha == false) // condicion para evitarrepetir las fechas dentro del DDL
                        {
                            listaOrientador.Add(objOrientador);
                        }
                    }

                    //listaOrientador.Add(objOrientador);
                }
                clsConexion.cerrarConexion();
                return listaOrientador;
            }
            catch (Exception)
            {
                return null;
            }
         }
        public List<clsSolucion> consultaDatosSolucionCuestionario(int IDINDICADOR, int IDREPRESENTANTE)
        {
            try
            {
                string sql = "SELECT SOLUCIONESCUESTIONARIOS.IDPREGUNTA, PREGUNTA.NOMBRE, SOLUCIONESCUESTIONARIOS.RESPUESTATEXTO, SOLUCIONESCUESTIONARIOS.IDRESPUESTA, SOLUCIONESCUESTIONARIOS.FECHASOLUCION FROM SOLUCIONESCUESTIONARIOS INNER JOIN INDICADOR ON SOLUCIONESCUESTIONARIOS.IDINDICADOR = INDICADOR.IDINDICADOR INNER JOIN PREGUNTA ON SOLUCIONESCUESTIONARIOS.IDPREGUNTA = PREGUNTA.IDPREGUNTA INNER JOIN REPRESENTANTE ON SOLUCIONESCUESTIONARIOS.IDREPRESENTANTE = REPRESENTANTE.IDREPRESENTANTE WHERE (SOLUCIONESCUESTIONARIOS.IDREPRESENTANTE = "+IDREPRESENTANTE+") AND (SOLUCIONESCUESTIONARIOS.IDINDICADOR = "+IDINDICADOR+")";

                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                List<clsSolucion> listaOrientador = new List<clsSolucion>();

                clsConexion.abrirConexion();

                // el lectorProductos consigue todo el contenido dentro de la tabla Producto
                SqlDataReader lectorJovenes = comando.ExecuteReader();
                //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
                while (lectorJovenes.Read())
                {
                    clsSolucion objOrientador = new clsSolucion();
                    // cada indice significa el lugar dentro de la tabla Producto
                    // Es importante conocer la estructura de la tabla, sino genera error

                    //
                    bool fecha = false;
                    objOrientador.IdPregunta = lectorJovenes.GetInt32(0);
                    objOrientador.NombrePregunta = lectorJovenes.GetString(1);
                    objOrientador.RespuestaTexto = lectorJovenes.GetString(2);
                    objOrientador.IdRespuesta = lectorJovenes.GetInt32(3);
                    objOrientador.FechaSolucion = lectorJovenes.GetDateTime(4);
                    
                    if (listaOrientador.Count == 0)
                    {
                        listaOrientador.Add(objOrientador);
                    }
                    else
                    {
                        for (int i = 0; i < listaOrientador.Count; i++)
                        {

                            if (listaOrientador[i].IdPregunta == objOrientador.IdPregunta)
                            {

                                fecha = true;

                            }


                        }
                        if (fecha == false) // condicion para evitarrepetir las fechas dentro del DDL
                        {
                            listaOrientador.Add(objOrientador);
                        }
                    }

                    //listaOrientador.Add(objOrientador);
                }
                clsConexion.cerrarConexion();
                return listaOrientador;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
