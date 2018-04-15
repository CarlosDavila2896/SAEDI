using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDatosReunion
    {
        SqlConnection conexion = new SqlConnection();

        string motrarError;
        public string MotrarError
        {
            get { return motrarError; }
            set { motrarError = value; }
        }

        private bool ConectarServer()
        {
            bool respuesta = false;
            string cadenaConexion = @"Data Source=.;Initial Catalog=Sembrar;Integrated Security=True";
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                respuesta = true;

            }
            catch (Exception ex)
            {
                respuesta = false;
                MotrarError = "No se ha podido conectar con el servidor. Mensaje de la exepción: " + ex.Message.ToString();
            }
            return respuesta;
        }

        public object consultaReuniones()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    //var reu = from r in db.REUNIONES
                    //          select new
                    //          {
                    //              ORIENTADOR = r.ORIENTADOR.NOMBREORIENTADOR,
                    //              TEMA_REUNION = r.Tema_Reunion,
                    //              PROGRAMA = r.PERIODO_PROGRAMA.PROGRAMA.NOMBREPROGRAMA + " - " + r.PERIODO_PROGRAMA.PERIODO.NOMBREPERIODO,
                    //              FECHA = r.Fecha_Reunion,
                    //              HORA = r.Hora,
                    //              DESCRIPCION = r.Descripcion_Reunion,
                    //              ESTADO = r.Habilitado
                    //          };
                    //return reu.ToList();
                    return new object();
                }
                catch (Exception ex)
                {
                    //return new List<REUNIONES>();
                    return new object();
                }
            }
        }

        public bool ingresaDatosReunion(int idLinea, int idOrientador, int idProceso, int idPeriodo, int idTipoAsistentes, string tema, DateTime fecha, TimeSpan hora, string obs)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    REUNION reunion = new REUNION();
                    reunion.IDLINEADEACCION = idLinea;
                    reunion.IDORIENTADOR = idOrientador;
                    reunion.IDPROCESO = idProceso;
                    reunion.IDPERIODO = idPeriodo;
                    reunion.IDTIPOASISTENTES = idTipoAsistentes;
                    reunion.TEMAREUNION = tema;
                    reunion.FECHAREUNION = fecha;
                    reunion.HORAREUNION = hora;
                    reunion.OBSERVACIONREUNION = obs;
                    reunion.ESTADOREUNION = true;
                    db.REUNION.InsertOnSubmit(reunion);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public object consultaReunionesPorFechaYOrientador(DateTime fecha, int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.REUNION
                              where r.FECHAREUNION == fecha && r.ESTADOREUNION == false
                              && r.IDORIENTADOR == idOrientador
                              select new
                              {

                                  TEMAREUNION = r.TEMAREUNION,
                                  IDREUNION = r.IDREUNION

                              };
                    return reu.ToList();

                }
                catch (Exception)
                {
                    return new List<REUNION>();
                }
            }
        }
        public object consultaReunionesFechasPorOrientador(int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.REUNION
                              where r.ESTADOREUNION == false
                              && r.IDORIENTADOR == idOrientador
                              select new
                              {
                                  FECHA = r.FECHAREUNION.ToShortDateString(),
                              };
                    return reu.Distinct().ToList();

                }
                catch
                {
                    return new List<REUNION>();
                }

            }
        }

        public object consultaReunionesActualizar()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.REUNION
                              where r.ESTADOREUNION == true
                              select new
                              {
                                  TEMA = r.TEMAREUNION + " -- " + r.FECHAREUNION,
                                  ID = r.IDREUNION,

                                  hora = r.HORAREUNION
                              };
                    return reu.Distinct().ToList().OrderBy(a => a.TEMA).ToList();

                }
                catch
                {
                    return new List<REUNION>();
                }
            }
        }

        public object consultaReunionesActualizarOrientador(int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.REUNION
                              where r.ESTADOREUNION == true && r.IDORIENTADOR==idOrientador
                              select new
                              {
                                  TEMA = r.TEMAREUNION + " -- " + r.FECHAREUNION,
                                  ID = r.IDREUNION,
                                  hora = r.HORAREUNION
                              };
                    return reu.Distinct().ToList().OrderBy(a => a.TEMA).ToList();

                }
                catch
                {
                    return new List<REUNION>();
                }
            }
        }

        public bool actualizarReunion(int id, string tema, DateTime fecha, TimeSpan hora)
        {
            using (MERSembrarDataContext bd = new MERSembrarDataContext())
            {
                try
                {
                    REUNION reu = bd.REUNION.First(r => r.IDREUNION == id);
                    reu.FECHAREUNION = fecha;
                    reu.HORAREUNION = hora;
                    reu.TEMAREUNION = tema;
                    bd.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;

                }
            }

        }


        public string cargarHora(int id)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var reu = (from r in db.REUNION

                         where r.IDREUNION == id
                         select new
                         {
                             HORA = r.HORAREUNION

                         }).FirstOrDefault().HORA;
                return reu.ToString() ;
            }
        }

        public string cargarTema(int id)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var reu = (from r in db.REUNION

                           where r.IDREUNION == id
                           select new
                           {
                               TEMA = r.TEMAREUNION

                           }).FirstOrDefault().TEMA;
                return reu.ToString();
            }
        }

        public DateTime cargarFecha(int id)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var reu = (from r in db.REUNION

                           where r.IDREUNION == id
                           select new
                           {
                               FECHA = r.FECHAREUNION

                           }).FirstOrDefault().FECHA;
                return reu;
            }
        }


        public object consultaReunionesHoras(string fecha)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.REUNION

                              where r.FECHAREUNION == DateTime.Parse(fecha) && r.ESTADOREUNION == true
                              select new
                              {
                                  TEMAREUNION = r.TEMAREUNION,
                                  IDREUNION = r.IDREUNION

                              };
                    return reu.ToList().OrderBy(a => a.TEMAREUNION).ToList();

                }
                catch (Exception)
                {
                    return new List<REUNION>();
                }
            }
        }

        public object consultaReunionesHorasOrientdor(string fecha, int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.REUNION

                              where r.FECHAREUNION == DateTime.Parse(fecha) && r.ESTADOREUNION == true && r.IDORIENTADOR == idOrientador
                              select new
                              {
                                  TEMAREUNION = r.TEMAREUNION,
                                  IDREUNION = r.IDREUNION

                              };
                    return reu.ToList().OrderBy(a => a.TEMAREUNION).ToList();

                }
                catch (Exception)
                {
                    return new List<REUNION>();
                }
            }
        }

        public object consultaReunionesFechas()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.REUNION
                              where r.ESTADOREUNION == false
                              select new
                              {
                                  FECHA = r.FECHAREUNION.ToShortDateString(),
                              };
                    return reu.Distinct().ToList();

                }
                catch
                {
                    return new List<REUNION>();
                }

            }
        }
        public object consultaReunionesHoras2(int id, DateTime fecha)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                //try
                //{
                //    var reu = from r in db.REUNIONES
                //              where r.IDORIENTADOR == id && r.Fecha_Reunion == fecha && r.Habilitado== "REALIZADA"
                //              select new
                //              {

                //                  HORA = r.Hora,

                //              };
                //    return reu.ToList();

                //}
                //catch (Exception)
                //{
                //    return new List<REUNIONES>();
                //}
                return new object();
            }
        }
        public bool Modificar(string tabla, string campos, string condicion)
        {
            bool respuesta = false;

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "UPDATE " + tabla + " SET " + campos + " WHERE " + condicion + ";";
                if (ConectarServer())
                {
                    if (comando.ExecuteNonQuery() == 1)
                        respuesta = true;
                    else
                        respuesta = false;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                MotrarError = "Mensaje de la excepción: " + ex.Message.ToString();
            }
            finally
            {
                conexion.Close();
            }

            return respuesta;
        }

        public object consultaReunionesPorFecha(DateTime fecha)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.REUNION
                              where r.FECHAREUNION == fecha && r.ESTADOREUNION == false 
                              select new
                              {

                                  TEMAREUNION = r.TEMAREUNION,
                                  IDREUNION = r.IDREUNION

                              };
                    return reu.ToList().OrderBy(a => a.TEMAREUNION).ToList();

                }
                catch (Exception)
                {
                    return new List<REUNION>();
                }
            }
        }

        public object consultaReunionesPorFechayOrientador(DateTime fecha, int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                try
                {
                    var reu = from r in db.REUNION
                              where r.FECHAREUNION == fecha && r.ESTADOREUNION == false && r.IDORIENTADOR==idOrientador
                              select new
                              {

                                  TEMAREUNION = r.TEMAREUNION,
                                  IDREUNION = r.IDREUNION
                              };
                    return reu.ToList().OrderBy(a => a.TEMAREUNION).ToList();

                }
                catch (Exception)
                {
                    return new List<REUNION>();
                }
            }
        }
        public bool Eliminar(string tabla, string condicion)
        {
            bool respuesta = false;

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM " + tabla + " WHERE " + condicion + ";";
                if (ConectarServer())
                {
                    if (comando.ExecuteNonQuery() == 1)
                        respuesta = true;
                    else
                        respuesta = false;
                }
                else
                {
                    respuesta = false;
                }
                return respuesta;

            }
            catch (Exception ex)
            {
                respuesta = false;
                MotrarError = "Mensaje de la excepción: " + ex.Message.ToString();
                return respuesta;
            }
            finally
            {
                conexion.Close();
            }


        }

        public bool D_modificaEstadoReunion(int id)
        {
            using (MERSembrarDataContext bd = new MERSembrarDataContext())
            {
                try
                {
                    REUNION reu = bd.REUNION.First(r => r.IDREUNION == id);
                    reu.ESTADOREUNION = false;
                    bd.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;

                }
            }
        }

        public object consultaDatosReuniones(int idLinea, int idProceso, int idOrientador, int idPeriodo)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var reu = from r in db.REUNION
                              where r.IDLINEADEACCION == idLinea && r.IDPROCESO == idProceso && r.IDORIENTADOR == idOrientador && r.IDPERIODO == idPeriodo
                              select new
                              {
                                  TEMA = r.TEMAREUNION,
                                  FECHA = r.FECHAREUNION.ToShortDateString(),
                                  HORA = string.Format("{0:D2}:{1:D2}", r.HORAREUNION.Hours, r.HORAREUNION.Minutes),
                                  ASISTENTES = r.TIPOASISTENTES.NOMBRETIPOASISTENTES,
                                  OBSERVACION = r.OBSERVACIONREUNION
                              };
                    return reu.ToList();
                }
            }
            catch
            {
                return new object();
            }
        }


        public DataSet MostrarRegistrosEditar(string tabla, string condicion)
        {
            DataSet respuesta = new DataSet();
            try
            {
                string instruccionSQL = "SELECT * FROM " + tabla + " WHERE " + condicion + ";";
                SqlDataAdapter adaptador = new SqlDataAdapter(instruccionSQL, conexion);
                if (ConectarServer())
                {
                    adaptador.Fill(respuesta, tabla);
                }
            }
            catch (Exception ex)
            {
                MotrarError = "Mensaje de la exepción: " + ex.Message.ToString();
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }

        public bool actualizaDatosReunion(CapaNegocio.clsReunion index)
        {
            try
            {
                clsConexion.abrirConexion();
                string sql = "update REUNIONES set IDORIENTADOR='" + index.Idorientador + "',Fecha_Reunion='" + index.Fecha + "',Hora='" + index.Hora + "', Descripcion_Reunion='" + index.Descripcion + "'     where Tema_Reunion=" + index.Tema;

                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);
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


    }

}
