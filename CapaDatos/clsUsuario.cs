using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class clsUsuario
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();

        private static Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!/*-+?&%$#";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public clsNUsuario buscarEstadoUsuario(string logUser)
        {
            try
            {
                clsConexion clsConexion = new clsConexion();

                string sql = "SELECT EstadoUsuario FROM USUARIO,aspnet_Users WHERE Usuario.UserIdAsp = aspnet_Users.UserId AND aspnet_Users.UserName ='" + logUser + "'";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                clsConexion.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                CapaNegocio.clsNUsuario usuario = new CapaNegocio.clsNUsuario();

                while (lector.Read())
                {
                    usuario.estado = lector.GetBoolean(0);
                }

                clsConexion.cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string buscarUsuario(string logUser)
        {
            try
            {
                var usuario = from user in bd.Usuario
                              from aspUser in bd.aspnet_Users
                              where user.UserIdAsp == aspUser.UserId &&
                              aspUser.UserName == logUser
                              select user.NombreUsuario;
                return usuario.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool actualizarPass(clsNUsuario usuario)
        {
            try
            {
                clsConexion.abrirConexion();
                string sql = "EXECUTE ActualizarPass " + usuario.idUser + ",'" + usuario.pass + "';";
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

        public clsNUsuario obtenerDatosUsuario(string logUser)
        {
            try
            {
                clsConexion clsConexion = new clsConexion();

                string sql = "SELECT * FROM USUARIO,aspnet_Users WHERE Usuario.UserIdAsp = aspnet_Users.UserId AND aspnet_Users.UserName ='" + logUser + "'";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                clsConexion.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                CapaNegocio.clsNUsuario usuario = new CapaNegocio.clsNUsuario();

                while (lector.Read())
                {
                    usuario.idUser = lector.GetInt32(0);
                    usuario.nombre = lector.GetString(2);
                    usuario.estado = lector.GetBoolean(5);
                }

                clsConexion.cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public object consultaUsuario(string rol)
        {
            try
            {
                var usuario = from u in bd.Usuario
                              from aspur in bd.aspnet_UsersInRoles
                              from aspr in bd.aspnet_Roles
                              where u.UserIdAsp == aspur.UserId &&
                              aspur.RoleId == aspr.RoleId &&
                              aspr.RoleName == rol
                              select new
                              {
                                  nombre = "("+aspur.aspnet_Users.UserName+")" + u.NombreUsuario + " " + u.ApellidoUsuario ,
                                  id = u.IdUsuario
                              };
                return usuario.ToList().OrderBy(a => a.nombre).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }


        public clsNUsuario obtenerDatosUsuarioCompleto(string logUser)
        {
            try
            {
                clsConexion clsConexion = new clsConexion();

                string sql = "SELECT * FROM USUARIO,aspnet_Users,aspnet_Membership WHERE Usuario.UserIdAsp = aspnet_Users.UserId "+
                    "AND aspnet_Membership.UserId = aspnet_Users.UserId  AND aspnet_Users.UserName ='" + logUser + "'";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                clsConexion.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                CapaNegocio.clsNUsuario usuario = new CapaNegocio.clsNUsuario();

                while (lector.Read())
                {
                    usuario.idUser = lector.GetInt32(0);
                    usuario.nombre = lector.GetString(2);
                    usuario.pass = lector.GetString(15);
                    usuario.estado = lector.GetBoolean(5);
                    try
                    {
                        usuario.appellido = lector.GetString(3);
                        usuario.genero = lector.GetString(4);
                    }
                    catch (Exception ex)
                    {
                        usuario.appellido = "";
                        usuario.genero = "";
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

        public clsNUsuario obtenerDatosUsuarioID(int id)
        {
            try
            {
                clsConexion clsConexion = new clsConexion();

                string sql = "SELECT * FROM USUARIO,aspnet_Users WHERE Usuario.UserIdAsp = aspnet_Users.UserId AND Usuario.IdUsuario =" + id ;
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                clsConexion.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                CapaNegocio.clsNUsuario usuario = new CapaNegocio.clsNUsuario();

                while (lector.Read())
                {
                    usuario.idUser = lector.GetInt32(0);
                    usuario.nombre = lector.GetString(2);
                    usuario.estado = lector.GetBoolean(5);
                    try
                    {
                        usuario.appellido = lector.GetString(3);
                        usuario.genero = lector.GetString(4);
                    }
                    catch (Exception ex)
                    {
                        usuario.appellido = "";
                        usuario.genero = "";
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

        public bool D_actualizarUsuario(clsNUsuario usuario, clsNMembership userM)
        {
            try
            {
                clsConexion.abrirConexion();
                string sql = "EXECUTE ActualizarUsuarioMembership "+usuario.idUser +",'"+usuario.nombre+"', '"+usuario.appellido+"',"+
                            "'"+usuario.genero+"', '" + usuario.estado + "', '" + userM.username+"', '"+userM.lowUsername+"', '"+userM.email+"','"+userM.lowEmail+"';";
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
        public bool D_actualizarUsuario(clsNUsuario usuario)
        {
            try
            {
                clsConexion.abrirConexion();
                string sql = "EXECUTE ActualizarUsuario " + usuario.idUser + ",'" + usuario.nombre + "', '" + usuario.appellido + "'," +
                            "'" + usuario.genero + "';";
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

        public clsNMembership cargarUsuarioMembership(int id)
        {
            try
            {

                clsConexion clsConexion = new clsConexion();

                string sql = "SELECT * FROM USUARIO,aspnet_Membership, aspnet_Users WHERE Usuario.UserIdAsp = aspnet_Membership.UserId " +
                    "AND Usuario.UserIdAsp = aspnet_Users.UserId AND Usuario.IdUsuario = " + id;
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

        public bool ingresarUsuario(clsNUsuario usuario, string username)
        {
            try
            {
                clsConexion.abrirConexion();

                string cadena = "DECLARE @aspUserId uniqueidentifier " +
                                 "SET @aspUserId = (SELECT UserId FROM aspnet_Users WHERE UserName = '" + username + "')" +
                                 "INSERT INTO Usuario(UserIdAsp, NombreUsuario, ApellidoUsuario, GeneroUsuario, EstadoUsuario)" +
                                 "VALUES(@aspUserId, '" + usuario.nombre+ "','" + usuario.appellido + "','" + usuario.genero + "','" + usuario.estado + "')";

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
        public object consultaUsuarios()
        {
            var user = from usuario in bd.Usuario
                           select usuario;
            return user;
        }      

        public object consultaOrientador()
        {

            var Orientador = from or in bd.ORIENTADOR
                             select new
                             {
                                 nombre ="("+or.aspnet_Users.UserName+")"+or.NOMBREORIENTADOR + " "+ or.APELLIDOORIENTADOR,
                                 id = or.IDORIENTADOR
                             };
            return Orientador;
        }        
    }
}
