using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CapaNegocio;
using System.Data.SqlClient;

using System.Data.Sql;





namespace CapaDatos
{
    public class clsDatosRespuestaIndicador
    {
       
            private string cadena2;

            public clsDatosRespuestaIndicador()
            {

                cadena2 = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;


            }

            public List<clsRespuestaIndicador> listarRespuestaIndicador()
            {
                SqlConnection conexion = new SqlConnection(cadena2);
                SqlCommand comando = new SqlCommand("select * from RESPUESTA_INDICADOR", conexion);

                List<clsRespuestaIndicador> lista = new List<clsRespuestaIndicador>();

                conexion.Open();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    clsRespuestaIndicador respuesta = new clsRespuestaIndicador();
                     try
            {
                    respuesta.Codigo = lector.GetInt32(0);
                    respuesta.IdPregunta = lector.GetInt32(1);
                    respuesta.IdIndicador = lector.GetInt32(2);
                    respuesta.IdPersona = lector.GetInt32(3);
                   
                    respuesta.ObservacionCertificado = lector.GetString(5);
                    respuesta.FechaRespuesta = lector.GetDateTime(6);


                    lista.Add(respuesta);
            }
                     catch (Exception ex)
                     {
                         string msg = ex.InnerException.ToString();
                     }

                }

                conexion.Close();

                return lista;

            }


            public bool grabarDatosRespuestaIndicador(clsRespuestaIndicador claseRespuestaIndicador)
            {
                SqlConnection conexion = new SqlConnection(cadena2);
                try 
	            {	        
		        
                SqlCommand comando = new SqlCommand("insert RESPUESTA_INDICADOR(IDPREGUNTA,IDINDICADOR,PUNTAJE,OBSERVACIONCERTIFICADOMEDICO) values(@IDPREGUNTA,@IDINDICADOR,@PUNTAJE,@OBSERVACIONCERTIFICADOMEDICO) ", conexion);

             //   comando.Parameters.Add("@IDPREGUNTA", //SqlDbType.Int).Value = claseRespuestaIndicador.IdPregunta;
               // comando.Parameters.Add("@IDINDICADOR", //SqlDbType.Int).Value = claseRespuestaIndicador.IdIndicador;
                //comando.Parameters.Add("@PUNTAJE", //SqlDbType.Decimal).Value = claseRespuestaIndicador.Puntaje;
                //comando.Parameters.Add("@OBSERVACIONCERTIFICADOMEDICO", //SqlDbType.VarChar).Value = claseRespuestaIndicador.ObservacionCertificado;
               


//                conexion.Open();

                comando.ExecuteNonQuery();
                    return true;
	}
	catch (Exception)
	{
		return false;
	}
                finally{
                    conexion.Close();
                }
                }



        public bool ingresarDatosRespuestaIndicador(clsRespuestaIndicador claseRespuestaIndicador)
        {
            SqlConnection conexion = new SqlConnection(cadena2);
            try
            {

                SqlCommand comando = new SqlCommand("insert RESPUESTA_INDICADOR(IDPREGUNTA,IDINDICADOR,IDRESPUESTA,IDPERSONA,FECHARESPUESTAINDICADOR) values(@IDPREGUNTA,@IDINDICADOR,@IDRESPUESTA,@IDPERSONA,FECHARESPUESTAINDICADOR) ", conexion);

  //              comando.Parameters.Add("@IDPREGUNTA", SqlDbType.Int).Value = claseRespuestaIndicador.IdPregunta;
    ///            comando.Parameters.Add("@IDINDICADOR", SqlDbType.Int).Value = claseRespuestaIndicador.IdIndicador;
       //         comando.Parameters.Add("@IDRESPUESTA", SqlDbType.Int).Value = claseRespuestaIndicador.IdRespuesta;
         //       comando.Parameters.Add("@IDPERSONA", SqlDbType.Int).Value = claseRespuestaIndicador.IdPersona;
           //     comando.Parameters.Add("@FECHARESPUESTAINDICADOR", SqlDbType.VarChar).Value = claseRespuestaIndicador.FechaRespuesta;



                conexion.Open();

                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
        

        public bool ingresarDatosTextologros(clsRespuestaIndicador claseRespuestaIndicador)
        {
            try
            {

                string sql = "insert into RESPUESTA_INDICADOR(IDPREGUNTA,IDINDICADOR,IDRESPUESTA,IDPERSONA,FECHARESPUESTAINDICADOR) values " +
                    " ('" + claseRespuestaIndicador.IdPregunta + "', " + claseRespuestaIndicador.IdIndicador + ", '" + claseRespuestaIndicador.IdRespuesta + "'," + claseRespuestaIndicador.IdPersona + "', " +
                    claseRespuestaIndicador.FechaRespuesta.ToString("yyyy-MM-dd") + ")";
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



        public List<clsRespuestaIndicador> consultaDatosLOGROSCuestionario(int IDINDICADOR, int IDPERSONA)
        {
            try
            {
                string sql = "SELECT RESPUESTA_INDICADOR.IDPREGUNTA, PREGUNTA.NOMBRE, RESPUESTA_INDICADOR.IDINDICADOR, RESPUESTA_INDICADOR.IDRESPUESTA, RESPUESTA_INDICADOR.IDPERSONA, RESPUESTA_INDICADOR.FECHASOLUCION FROM RESPUESTA_INDICADOR INNER JOIN INDICADOR ON RESPUESTA_INDICADOR.IDINDICADOR = INDICADOR.IDINDICADOR INNER JOIN PREGUNTA ON RESPUESTA_INDICADOR.IDPREGUNTA = PREGUNTA.IDPREGUNTA INNER JOIN PERSONA ON RESPUESTA_INDICADOR.IDPERSONA = PERSONA.IDPERSONA WHERE (RESPUESTA_INDICADOR.IDPERSONA = " + IDPERSONA + ") AND (RESPUESTA_INDICADOR.IDINDICADOR = " + IDINDICADOR + ")";

                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                
                List<clsRespuestaIndicador> lista = new List<clsRespuestaIndicador>();

                clsConexion.abrirConexion();

                // el lectorProductos consigue todo el contenido dentro de la tabla Producto

                SqlDataReader lector = comando.ExecuteReader();
                //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto


                while (lector.Read())
                {
                    clsRespuestaIndicador respuesta = new clsRespuestaIndicador();
                 
                        bool fecha = false;
                        respuesta.Codigo = lector.GetInt32(0);
                        respuesta.IdPregunta = lector.GetInt32(1);
                        respuesta.IdIndicador = lector.GetInt32(2);
                    respuesta.IdRespuesta = lector.GetInt32(3);
                        respuesta.IdPersona = lector.GetInt32(4);
                        respuesta.FechaRespuesta = lector.GetDateTime(6);


                     
                    if (lista.Count == 0)
                    {
                            lista.Add(respuesta);
                        
                    }
                    else
                    {
                        for (int i = 0; i < lista.Count; i++)
                        {

                            if (lista[i].IdPregunta == respuesta.IdPregunta)
                            {

                                fecha = true;

                            }


                        }
                        if (fecha == false) // condicion para evitarrepetir las fechas dentro del DDL
                        {
                            lista.Add(respuesta);
                        }
                    }

                    //listaOrientador.Add(objOrientador);
                }
                clsConexion.cerrarConexion();
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }




    }

}
