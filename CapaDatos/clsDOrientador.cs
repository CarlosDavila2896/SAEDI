using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class clsDOrientador
    {
        public object D_consultarOrientadores()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.ORIENTADOR.ToList();
            }
        }

        public object D_consultarRepresentantesporOrientador(int id)
        {/*
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var Rep = from r in db.REUNIONES
                              join m in db.MATRICULA on r.IDPERIODOPROGRAMA equals m.IDPERIODOPROGRAMA
                              where r.IDORIENTADOR == id
                              select new
                              {
                                  id = m.REPRESENTANTE.IDREPRESENTANTE,
                                  nombre = m.REPRESENTANTE.PERSONA.PRIMERNOMBREPERSONA + " " + m.REPRESENTANTE.PERSONA.PRIMERAPELLIDOPERSONA,
                              };
                    return Rep.Distinct().ToList();
                }

            }
            catch
            {
                return new List<FAMILIA>();
            }*/
            return new object();
            
        }
        

        public bool ingresarOrientador(clsOrientador orientador, string username)
        {
            try
            {
                clsConexion.abrirConexion();

                string cadena = " DECLARE @aspUserId uniqueidentifier " +
                                 "SET @aspUserId = (SELECT UserId FROM aspnet_Users WHERE UserName = '"+username+"')" +
                                 "INSERT INTO ORIENTADOR(USERIDASP, NOMBREORIENTADOR,APELLIDOORIENTADOR,GENEROORIENTADOR,ESTADOORIENTADOR)" +
                                 "VALUES(@aspUserId, '"+orientador.NombreOrientador+ "','" + orientador.apellidoOrientador + "','" + orientador.generoOrientador + "','"+orientador.estadoOrientador+"')";

                SqlCommand comando = new SqlCommand(cadena, clsConexion.Conexion);
                comando.ExecuteNonQuery();                      // Ejecutamos el comando
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
        public clsNMembership cargarOrientadorMembership(int id)
        {
            try
            {

                clsConexion clsConexion = new clsConexion();

                string sql = "SELECT * FROM ORIENTADOR,aspnet_Membership, aspnet_Users WHERE ORIENTADOR.USERIDASP = aspnet_Membership.UserId " +
                    "AND ORIENTADOR.USERIDASP = aspnet_Users.UserId AND ORIENTADOR.IDORIENTADOR = " + id;
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                clsConexion.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                CapaNegocio.clsNMembership usuario = new CapaNegocio.clsNMembership();

                while (lector.Read())
                {
                    usuario.id = lector.GetInt32(0);
                    usuario.email = lector.GetString(12);
                    usuario.pass = lector.GetString(8);
                    usuario.username = lector.GetString(29);
                }

                clsConexion.cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }

        public object D_consultarOrientadoresPorProcesoyLinea(int idProceso, int idLinea)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var procesos = from or in db.ORIENTADOR
                               join r in db.ORIENTADORACARGODEPROCESOENPERIODO on or.IDORIENTADOR equals r.IDORIENTADOR
                               where r.IDPROCESO == idProceso && r.IDLINEADEACCION == idLinea
                               select new
                               {
                                   IDORIENTADOR = or.IDORIENTADOR,
                                   NOMBREORIENTADOR = or.NOMBREORIENTADOR +" "+ or.APELLIDOORIENTADOR
                               };


                return procesos.Distinct().ToList().OrderBy(a => a.NOMBREORIENTADOR).ToList();
            }
        }

        public object D_consultarOrientadoresNombresCompletos()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var procesos = from or in db.ORIENTADOR
                               select new
                               {
                                   IDORIENTADOR = or.IDORIENTADOR,
                                   NOMBREORIENTADOR = or.NOMBREORIENTADOR + " " + or.APELLIDOORIENTADOR
                               };


                return procesos.Distinct().ToList().OrderBy(a => a.NOMBREORIENTADOR).ToList();
            }
        }

        public clsOrientador D_consultarOrientadores(int id)
        {
            try
            {
                clsConexion clsConexion = new clsConexion();

                string sql = "SELECT * FROM ORIENTADOR,aspnet_Users WHERE ORIENTADOR.USERIDASP = aspnet_Users.UserId AND ORIENTADOR.IDORIENTADOR =" + id;
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                clsConexion.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                clsOrientador usuario = new clsOrientador();

                while (lector.Read())
                {
                    usuario.IDOrientador1 = lector.GetInt32(0);
                    usuario.NombreOrientador = lector.GetString(2);
                    usuario.estadoOrientador = lector.GetBoolean(5);
                    try
                    {
                        usuario.apellidoOrientador = lector.GetString(3);
                        usuario.generoOrientador = lector.GetString(4);
                    }
                    catch (Exception ex)
                    {
                        usuario.apellidoOrientador = "";
                        usuario.generoOrientador = "";
                    }
                }

                clsConexion.cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public clsOrientador D_consultarOrientador(string username)
        {
            try
            {
                clsConexion clsConexion = new clsConexion();

                string sql = "SELECT * FROM ORIENTADOR,aspnet_Users,aspnet_Membership WHERE ORIENTADOR.USERIDASP = aspnet_Users.UserId " +
                    "AND aspnet_Membership.UserId = aspnet_Users.UserId  AND aspnet_Users.UserName ='" + username + "'";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                clsConexion.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                clsOrientador usuario = new clsOrientador();

                while (lector.Read())
                {
                    usuario.IDOrientador1 = lector.GetInt32(0);
                    usuario.NombreOrientador = lector.GetString(2);
                    usuario.estadoOrientador = lector.GetBoolean(5);
                    try
                    {
                        usuario.apellidoOrientador = lector.GetString(3);
                        usuario.generoOrientador = lector.GetString(4);
                    }
                    catch (Exception ex)
                    {
                        usuario.apellidoOrientador = "";
                        usuario.generoOrientador = "";
                    }
                }

                clsConexion.cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool D_actualizarUsuario(clsOrientador usuario, clsNMembership userM)
        {
            try
            {
                clsConexion.abrirConexion();
                string sql = "EXECUTE ActualizaOrientadorMembership " + usuario.IDOrientador1 + ",'" + usuario.NombreOrientador + "', '" + usuario.apellidoOrientador + "'," +
                            "'" + usuario.generoOrientador + "', '" + usuario.estadoOrientador + "', '" + userM.username + "', '" + userM.lowUsername + "', '" + userM.email + "','" + userM.lowEmail + "';";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);
                comando.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {
                clsConexion.cerrarConexion();
            }
        }

        public clsOrientador obtenerDatosOrientadorCompleto(string logUser)
        {
            try
            {
                clsConexion clsConexion = new clsConexion(); 

                string sql = "SELECT * FROM ORIENTADOR,aspnet_Users,aspnet_Membership WHERE ORIENTADOR.USERIDASP = aspnet_Users.UserId " +
                    "AND aspnet_Membership.UserId = aspnet_Users.UserId  AND aspnet_Users.UserName ='" + logUser + "'";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                clsConexion.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                clsOrientador usuario = new clsOrientador();

                while (lector.Read())
                {
                    usuario.IDOrientador1 = lector.GetInt32(0);
                    usuario.NombreOrientador = lector.GetString(2);
                    usuario.estadoOrientador = lector.GetBoolean(5);
                    usuario.pass = lector.GetString(15);
                    try
                    {
                        usuario.apellidoOrientador = lector.GetString(3);
                        usuario.generoOrientador = lector.GetString(4);
                    }
                    catch (Exception ex)
                    {
                        usuario.apellidoOrientador = "";
                        usuario.generoOrientador = "";
                    }
                }

                clsConexion.cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool actualizarPass(clsOrientador usuario)
        {
            try
            {
                clsConexion.abrirConexion();
                string sql = "EXECUTE ActualizarPassOrientador " + usuario.IDOrientador1 + ",'" + usuario.pass + "';";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);
                comando.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {
                clsConexion.cerrarConexion();
            }

        }
        public object D_consultarOrientadoresPorProceso(int idProceso)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var procesos = from or in db.ORIENTADOR
                               join r in db.ORIENTADORACARGODEPROCESOENPERIODO on or.IDORIENTADOR equals r.IDORIENTADOR
                               where r.IDPROCESO == idProceso 
                               select new
                               {
                                   IDORIENTADOR = or.IDORIENTADOR,
                                   NOMBREORIENTADOR = or.NOMBREORIENTADOR
                               };


                return procesos.Distinct().ToList();
            }
        }
        public object D_consultarOrientadores2()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var procesos = from or in db.ORIENTADOR
                               select new
                               {
                                   IDORIENTADOR = or.IDORIENTADOR,
                                   NOMBREORIENTADOR = or.NOMBREORIENTADOR + ' ' + or.APELLIDOORIENTADOR
                               };


                return procesos.Distinct().ToList();
            }
        }
    }
}
