using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDatosAsistencia
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();

        static clsAsistencia transformarAsistencia(ASISTENCIA newAsistencia)
        {
            clsAsistencia asistencia = new clsAsistencia();
            asistencia.CodigoAsistencia = newAsistencia.IDASISTENCIA;
            asistencia.IdLineaDeAccion = newAsistencia.IDLINEADEACCION;
            asistencia.CodigoOrientador = newAsistencia.IDORIENTADOR;
            asistencia.IdPeriodo = newAsistencia.IDPERIODO;
            asistencia.IdPersona = newAsistencia.IDPERSONA;
            asistencia.IdProcesos = newAsistencia.IDPROCESO;
            asistencia.TipoAsistencia = newAsistencia.IDTIPOASISTENCIA;
            asistencia.FechaAsistencia = newAsistencia.FECHAASISTENCIA;
            return asistencia;
            
        }


        static clsNAsistenciaReunion transformarAsistenciaReunion(ASISTENCIAREUNION newAsistencia)
        {
            clsNAsistenciaReunion asistencia = new clsNAsistenciaReunion();
            asistencia.IdAsistencia = newAsistencia.IDASISTENCIAREUNION;
            asistencia.IdPersona = newAsistencia.IDPERSONA;
            asistencia.IdReunion = newAsistencia.IDPERSONA;
            asistencia.IdTipoAsistencia = newAsistencia.IDTIPOASISTENCIA;
            return asistencia;
        }

        public bool IngresoDatosAsistencia(int idreu, int tipo, int idper)
        {
            try
            {
                ASISTENCIAREUNION a1 = new ASISTENCIAREUNION { IDREUNION = idreu ,IDTIPOASISTENCIA = tipo, IDPERSONA= idper };
                bd.ASISTENCIAREUNION.InsertOnSubmit(a1);
                bd.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool IngresoDatosAsistenciaDiaria(int idlinea, int idori, int idpro, int idperiodo,  int idtipo, int idper, DateTime fecha)
        {
            try
            {
                ASISTENCIA a1 = new ASISTENCIA { IDLINEADEACCION=idlinea, IDORIENTADOR=idori, IDPROCESO=idpro, IDPERIODO=idperiodo, IDPERSONA=idper, IDTIPOASISTENCIA=idtipo,FECHAASISTENCIA=fecha};
                bd.ASISTENCIA.InsertOnSubmit(a1);
                bd.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public object D_consultarPersonas()
        {
            MERSembrarDataContext bd = new MERSembrarDataContext();
            try
            {
                var asi = (from r in bd.ASISTENCIAREUNION
                           join p in bd.PERSONA on r.IDPERSONA equals p.IDPERSONA
                           select new
                           {
                               Nombre = p.PRIMERNOMBREPERSONA+' '+ p.PRIMERAPELLIDOPERSONA,
                               IdPersona = p.IDPERSONA
                           }).Distinct().ToList();

                return asi;

            }
            catch
            {
                return "";
            }
        }

        public object D_consultarPersonasPorOrientador(int idOrientador, int tipo)
        {
            MERSembrarDataContext bd = new MERSembrarDataContext();
            try
            {
                if (tipo == 0)
                {
                    var asi = (from p in bd.PERSONA
                               join m in bd.MATRICULA on p.IDPERSONA equals m.IDPERSONA
                               join o in bd.ORIENTADOR on m.IDORIENTADOR equals o.IDORIENTADOR
                               where m.IDORIENTADOR == idOrientador
                               select new
                               {
                                   Nombre = p.PRIMERNOMBREPERSONA + ' ' + p.PRIMERAPELLIDOPERSONA,
                                   IdPersona = p.IDPERSONA
                               }).Distinct().ToList();
                    return asi;
                }
                else
                {
                    var asi2 = (from m in bd.MATRICULA
                                join p in bd.PERIODO_PERSONA_FAMILIA on m.IDPERSONA equals p.IDPERSONA
                                join per in bd.PERSONA on p.IDREPRESENTANTE equals per.IDPERSONA
                                join o in bd.ORIENTADOR on m.IDORIENTADOR equals o.IDORIENTADOR
                                where m.IDORIENTADOR == idOrientador
                                select new
                                {
                                    Nombre = per.PRIMERNOMBREPERSONA + ' ' + per.PRIMERAPELLIDOPERSONA,
                                    IdPersona = per.IDPERSONA
                                }).Distinct().ToList();

                    return asi2;
                }
            }
            catch
            {
                return "";
            }
        }

        public object D_consultarAsistenciaPorOrientador(int id)
        {
            MERSembrarDataContext bd = new MERSembrarDataContext();
            try
            {
                var asi = (from r in bd.ASISTENCIA
                           where r.IDORIENTADOR == id
                           select new
                           {
                               cadena = DateTime.Parse(r.FECHAASISTENCIA.ToString()).ToString("MM/dd/yyyy")
                           }).Distinct().ToList();

                return asi;

            }
            catch
            {
                return "";
            }
        }
        public bool ActualizarDatosAsistencia(int idreu, int idper, int tipo)
        {
            using (MERSembrarDataContext bd = new MERSembrarDataContext())
            {
                try
                {
                    ASISTENCIAREUNION asi = bd.ASISTENCIAREUNION.First(r => r.IDREUNION == idreu && r.IDPERSONA==idper);
                    asi.IDTIPOASISTENCIA = tipo;
                    bd.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;

                }
            }

        }
        public bool ActualizarDatosAsistenciaDiaria(int idlinea, int idori, int idpro, int idperiodo, int idtipo,int idper, DateTime fecha)
        {
            using (MERSembrarDataContext bd = new MERSembrarDataContext())
            {
                try
                {
                    ASISTENCIA asi = bd.ASISTENCIA.First(r => r.IDLINEADEACCION == idlinea && r.IDORIENTADOR==idori && r.IDPROCESO==idpro && r.IDPERIODO==idperiodo && r.IDPERSONA == idper && r.FECHAASISTENCIA==fecha);
                    asi.IDTIPOASISTENCIA = idtipo;
                    bd.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;

                }
            }

        }


        public int ingresarDatosAsistenciaRepresentante(clsAsistencia objJovenes)
        {


            int codigoJoven, codigoOrientador, codigoReunion;
            DateTime fechaAsistencia;

            try
            {
                codigoJoven = objJovenes.CodigoJoven;
                codigoReunion = objJovenes.CodigoReunion;
                codigoOrientador = objJovenes.CodigoOrientador;
                // cambiar solo es de prueba el fecha asistencia
                fechaAsistencia = objJovenes.FechaAsistencia;
                string sql = "INSERT INTO ASISTENCIA(IDRepresentante,IDORIENTADOR ,IdReunion, FECHAASISTENCIA) VALUES(" + codigoJoven + "," + codigoOrientador + "," + codigoReunion + ",'" + objJovenes.FechaAsistenciaString + "')";

                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);
                clsConexion.abrirConexion();
                //SqlParameter paramIdOri = new SqlParameter("@IDJOVEN", codigoJoven);
                //comando.Parameters.Add(paramIdOri);
                //SqlParameter paramIdJoven = new SqlParameter("@IDORIENTADOR", codigoOrientador);
                //comando.Parameters.Add(paramIdJoven);
                //SqlParameter paramFecha = new SqlParameter("@FECHAASISTENCIA", objJovenes.FechaAsistenciaString);
                //comando.Parameters.Add(paramFecha);
                comando.ExecuteNonQuery();
                clsConexion.cerrarConexion();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }



        }
        public List<clsAsistencia> consultaDatosFechasAsistencia(int IDORIENTADOR)
        {
            string sql = "SELECT ASISTENCIA.IDORIENTADOR, ASISTENCIA.FECHAASISTENCIA   FROM ASISTENCIA INNER JOIN ORIENTADOR ON ASISTENCIA.IDORIENTADOR = ORIENTADOR.IDORIENTADOR WHERE (ORIENTADOR.IDORIENTADOR = " + IDORIENTADOR + ")";
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsAsistencia> listaFechas = new List<clsAsistencia>();

            clsConexion.abrirConexion();

           
            SqlDataReader lectorJovenes = comando.ExecuteReader();
            
            while (lectorJovenes.Read())
            {
                clsAsistencia objAsistencia = new clsAsistencia();
                
                bool fecha = false;
                
                objAsistencia.FechaAsistenciaString = lectorJovenes.GetDateTime(1).ToString("yyyy/MM/dd");
                objAsistencia.CodigoOrientador = lectorJovenes.GetInt32(0);
                if (listaFechas.Count == 0)
                {
                    listaFechas.Add(objAsistencia);
                }
                else
                {
                    for (int i = 0; i < listaFechas.Count; i++)
                    {
                        if (listaFechas[i].FechaAsistenciaString == objAsistencia.FechaAsistenciaString)
                        {
                            fecha = true;

                        }

                    }
                    if (fecha == false) // condicion para evitarrepetir las fechas dentro del DDL
                    {
                        listaFechas.Add(objAsistencia);
                    }
                }


            }
            clsConexion.cerrarConexion();
            return listaFechas;
        }

        public bool consultarIngresoDiario(int idlinea, int idori, int idpro, int idper, DateTime fecha)
        {
            var Rep = from r in bd.ASISTENCIA
                      where r.IDLINEADEACCION == idlinea && r.IDORIENTADOR==idori && r.IDPROCESO== idpro && r.IDPERIODO==idper && r.FECHAASISTENCIA==fecha
                       select new
                       {
                           ID= r.IDASISTENCIA
                       };

            if(Rep.ToList().Count>0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public string consultaAsistencia(int id, int idReu)
        {
            MERSembrarDataContext bd = new MERSembrarDataContext();
            try
            {
                string asi = (from r in bd.ASISTENCIAREUNION
                              join t in bd.TIPOASISTENCIA on r.IDTIPOASISTENCIA equals t.IDTIPOASISTENCIA
                              where r.IDPERSONA == id
                              && r.IDREUNION == idReu
                              select new
                              {
                                  t.NOMBRETIPOASISTENCIA
                              }).FirstOrDefault().NOMBRETIPOASISTENCIA.ToString();

                return asi.ToString();

            }
            catch
            {
                return "";
            }
        }
        public string consultaAsistenciaDiaria(int idlinea, int idori, int idpro, int idperiodo, int idper, DateTime fecha)
        {
            MERSembrarDataContext bd = new MERSembrarDataContext();
            try
            {
                string asi = (from r in bd.ASISTENCIA
                              join t in bd.TIPOASISTENCIA on r.IDTIPOASISTENCIA equals t.IDTIPOASISTENCIA
                              where r.IDLINEADEACCION==idlinea && r.IDORIENTADOR==idori && r.IDPROCESO==idpro && r.IDPERIODO==idperiodo && r.IDPERSONA==idper && r.FECHAASISTENCIA ==fecha
                              select new
                              {
                                  t.NOMBRETIPOASISTENCIA
                              }).FirstOrDefault().NOMBRETIPOASISTENCIA.ToString();

                return asi.ToString();

            }
            catch
            {
                return "";
            }
        }
        public object consultaAsistentes(int id)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from a in db.ASISTENCIAREUNION
                              join p in db.PERSONA on a.IDPERSONA equals p.IDPERSONA
                              where a.IDREUNION==id
                              select new
                              {

                                  APELLIDOPERSONA = p.PRIMERAPELLIDOPERSONA,
                                  NOMBREPERSONA = p.PRIMERNOMBREPERSONA,
                                  CEDULAPERSONA = p.CEDULAPERSONA,
                                  IDPERSONA = p.IDPERSONA

                              };
                    return reu.Distinct().OrderBy(per => per.APELLIDOPERSONA).ToList();

                }
                catch (Exception)
                {
                    return new List<REUNION>();
                }
            }
        }

        public List<clsReunion> consultaDatosFechasReuniones(int IDORIENTADOR)
        {
            string sql = "SELECT REUNIONES.ID_REUNION, REUNIONES.FECHA_REUNION   FROM REUNIONES INNER JOIN ORIENTADOR ON REUNIONES.IDORIENTADOR = ORIENTADOR.IDORIENTADOR WHERE (ORIENTADOR.IDORIENTADOR = " + IDORIENTADOR + ")";
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsReunion> listaFechas = new List<clsReunion>();

            clsConexion.abrirConexion();


            SqlDataReader lectorJovenes = comando.ExecuteReader();

            while (lectorJovenes.Read())
            {
                clsReunion objAsistencia = new clsReunion();

                bool fecha = false;

                objAsistencia.Fecha = lectorJovenes.GetDateTime(1).ToString("yyyy/MM/dd");
                //objAsistencia. = lectorJovenes.GetInt32(0);
                if (listaFechas.Count == 0)
                {
                    listaFechas.Add(objAsistencia);
                }
                else
                {
                    for (int i = 0; i < listaFechas.Count; i++)
                    {
                        if (listaFechas[i].Fecha== objAsistencia.Fecha)
                        {
                            fecha = true;

                        }

                    }
                    if (fecha == false) // condicion para evitarrepetir las fechas dentro del DDL
                    {
                        listaFechas.Add(objAsistencia);
                    }
                }


            }
            clsConexion.cerrarConexion();
            return listaFechas;
        }
        public List<clsAsistencia> consultaDatosAsistencia(int IDORIENTADOR)
        {
            string sql = "SELECT Representante.IDRepresentante, PERSONA.PRIMERNOMBREPERSONA + ' ' + PERSONA.PRIMERAPELLIDOPERSONA AS Expr1,PERSONA.CEDULAPERSONA  FROM ASISTENCIA INNER JOIN ORIENTADOR ON ASISTENCIA.IDORIENTADOR = ORIENTADOR.IDORIENTADOR    WHERE (ORIENTADOR.IDORIENTADOR = " + IDORIENTADOR + ")";
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsAsistencia> listaFechas = new List<clsAsistencia>();

            clsConexion.abrirConexion();

            // el lectorProductos consigue todo el contenido dentro de la tabla Producto
            SqlDataReader lectorJovenes = comando.ExecuteReader();
            //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
            while (lectorJovenes.Read())
            {
                clsAsistencia objAsistencia = new clsAsistencia();
                // cada indice significa el lugar dentro de la tabla Producto
                // Es importante conocer la estructura de la tabla, sino genera error

                //
                objAsistencia.FechaAsistenciaString = lectorJovenes.GetDateTime(1).ToString();
                objAsistencia.CodigoOrientador = lectorJovenes.GetInt32(0);


                listaFechas.Add(objAsistencia);
            }
            clsConexion.cerrarConexion();
            return listaFechas;
        }
        public List<clsOrientador> consultaDatosOrientador(int IDPROCESODUPLICADO)
        {
            string sql = "SELECT ORIENTADOR.NOMBREORIENTADOR, ORIENTADOR.IDORIENTADOR FROM  PROCESO INNER JOIN ORIENTADOR ON PROCESO.IDORIENTADOR = ORIENTADOR.IDORIENTADOR WHERE (PROCESO.IDPROCESODUPLICADO = "+IDPROCESODUPLICADO+")";
           
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsOrientador> listaOrientador = new List<clsOrientador>();

            clsConexion.abrirConexion();

            // el lectorProductos consigue todo el contenido dentro de la tabla Producto
            SqlDataReader lectorJovenes = comando.ExecuteReader();
            //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
            while (lectorJovenes.Read())
            {
                clsOrientador objOrientador = new clsOrientador();
                // cada indice significa el lugar dentro de la tabla Producto
                // Es importante conocer la estructura de la tabla, sino genera error

                //
                objOrientador.IDOrientador1 = lectorJovenes.GetInt32(1);
                objOrientador.NombreOrientador= lectorJovenes.GetString(0);


                listaOrientador.Add(objOrientador);
            }
            lectorJovenes.Close();
            clsConexion.cerrarConexion();
            return listaOrientador;
        }
        public List<clsReunion> consultaDatosReunion(int IDORIENTADOR)
        {
            string sql = "SELECT REUNIONES.ID_Reunion, REUNIONES.Tema_Reunion FROM REUNIONES INNER JOIN ORIENTADOR ON REUNIONES.IDORIENTADOR = ORIENTADOR.IDORIENTADOR INNER JOIN ASISTENCIA ON REUNIONES.IDORIENTADOR = ASISTENCIA.IDORIENTADOR AND REUNIONES.ID_Reunion = ASISTENCIA.IDREUNION WHERE(ORIENTADOR.IDORIENTADOR = "+IDORIENTADOR+")";
            
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsReunion> listaOrientador = new List<clsReunion>();

            clsConexion.abrirConexion();

            // el lectorProductos consigue todo el contenido dentro de la tabla Producto
            SqlDataReader lectorJovenes = comando.ExecuteReader();
            //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
            while (lectorJovenes.Read())
            {
                clsReunion objOrientador = new clsReunion();
                // cada indice significa el lugar dentro de la tabla Producto
                // Es importante conocer la estructura de la tabla, sino genera error

                //
                bool fecha = false;
                objOrientador.Id= lectorJovenes.GetInt32(0);
                objOrientador.Tema= lectorJovenes.GetString(1);
                if (listaOrientador.Count == 0)
                {
                    listaOrientador.Add(objOrientador);
                }
                else
                {
                    for (int i = 0; i < listaOrientador.Count; i++)
                    {
                        
                            if (listaOrientador[i].Tema == objOrientador.Tema)
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
            lectorJovenes.Close();
            clsConexion.cerrarConexion();
            return listaOrientador;
        }
        public bool borrarRepresentanteAsistencia(int IDJOVEN, string FECHAASISTENCIA)
        {
            bool respuesta = false;

            try
            {


                //DELETE FROM Productos WHERE CodigoProductos = 7;

                string sql = "DELETE FROM ASISTENCIA WHERE ASISTENCIA.IDREPRESENTANTE=" + IDJOVEN + "AND (ASISTENCIA.FECHAASISTENCIA='" + FECHAASISTENCIA + "')";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);
                clsConexion.abrirConexion();
                comando.ExecuteNonQuery();
                clsConexion.cerrarConexion();
                return respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;

                return respuesta;
            }

        }
        public List<clsAsistencia> consultaDatosAsistenciaReunionRepresentantes(int IDORIENTADOR, string fechaASISTENCIA)
        {
            string sql = "SELECT REUNIONES.ID_Reunion, REUNIONES.Tema_Reunion FROM REUNIONES INNER JOIN ORIENTADOR ON ORIENTADOR.IDORIENTADOR = REUNIONES.IDORIENTADOR WHERE (ORIENTADOR.IDORIENTADOR = " + IDORIENTADOR + ") AND (REUNIONES.Habilitado = 'ACTIVO') AND (REUNIONES.Fecha_Reunion = '" + fechaASISTENCIA + "')";
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsAsistencia> listaJovenes = new List<clsAsistencia>();

            clsConexion.abrirConexion();

            // el lectorProductos consigue todo el contenido dentro de la tabla Producto
            SqlDataReader lectorJovenes = comando.ExecuteReader();
            //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
            while (lectorJovenes.Read())
            {
                clsAsistencia objOrientador = new clsAsistencia();
                // cada indice significa el lugar dentro de la tabla Producto
                // Es importante conocer la estructura de la tabla, sino genera error

                //
                objOrientador.CodigoReunion = int.Parse(lectorJovenes.GetInt32(0).ToString());
                objOrientador.Tema = lectorJovenes.GetString(1);
                

                //objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetString(1));
                //objOrientador.Cedula = int.Parse(lectorJovenes.GetString(2));


                listaJovenes.Add(objOrientador);
            }
            clsConexion.cerrarConexion();
            return listaJovenes;
        }

        public bool consultaPorIdRepresentante(int id, int idReu)
        {
            MERSembrarDataContext bd = new MERSembrarDataContext();
            try
            {
                //var Rep = from r in bd.ASISTENCIA
                //          where r.IDREPRESENTANTE == id 
                //          && r.IDREUNION == idReu
                //           select new
                //           {
                //               ID= r.IDREPRESENTANTE
                //           };

                //if(Rep.ToList().Count==1)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                return true;
                
            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        public List<clsAsistencia> consultaDatosAsistenciaReunionDeshabilitarRepresentantes(int IDORIENTADOR, string fechaASISTENCIA)
        {
            string sql = "SELECT REUNIONES.ID_Reunion, REUNIONES.Tema_Reunion, REUNIONES.HABILITADO FROM REUNIONES INNER JOIN ORIENTADOR ON ORIENTADOR.IDORIENTADOR = REUNIONES.IDORIENTADOR WHERE (ORIENTADOR.IDORIENTADOR = " + IDORIENTADOR + ") AND (REUNIONES.Habilitado = 'ACTIVO') AND (REUNIONES.Fecha_Reunion = '" + fechaASISTENCIA + "')";
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsAsistencia> listaJovenes = new List<clsAsistencia>();

            clsConexion.abrirConexion();

            // el lectorProductos consigue todo el contenido dentro de la tabla Producto
            SqlDataReader lectorJovenes = comando.ExecuteReader();
            //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
            while (lectorJovenes.Read())
            {
                clsAsistencia objOrientador = new clsAsistencia();
                // cada indice significa el lugar dentro de la tabla Producto
                // Es importante conocer la estructura de la tabla, sino genera error

                //
                objOrientador.CodigoReunion = int.Parse(lectorJovenes.GetInt32(0).ToString());
                objOrientador.Tema = lectorJovenes.GetString(1);
                objOrientador.Habilitado = lectorJovenes.GetString(2);


                //objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetString(1));
                //objOrientador.Cedula = int.Parse(lectorJovenes.GetString(2));


                listaJovenes.Add(objOrientador);
            }
            clsConexion.cerrarConexion();
            return listaJovenes;
        }
        public bool DeshabilitarReunionAsistencia(int IDReunion, string FECHAASISTENCIA, string HABILITADO)
        {
            bool respuesta = false;

            try
            {


                //DELETE FROM Productos WHERE CodigoProductos = 7;

                string sql = "UPDATE REUNIONES SET REUNIONES.HABILITADO ='" + HABILITADO + "' WHERE REUNIONES.ID_REUNION=" + IDReunion + "AND (REUNIONES.FECHA_REUNION='" + FECHAASISTENCIA + "')";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);
                clsConexion.abrirConexion();
                comando.ExecuteNonQuery();
                clsConexion.cerrarConexion();
                return respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;

                return respuesta;
            }

        }
    }
}
