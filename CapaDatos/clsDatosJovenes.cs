using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class clsDatosJovenes
    {
        public List<clsJoven> consultaDatosJovenes(int IDORIENTADOR)
        {
            try
            {
                string sql = "SELECT JOVEN.IDJOVEN, JOVEN.PRIMERNOMBREPERSONA + ' ' + JOVEN.PRIMERAPELLIDOPERSONA AS Expr1,JOVEN.CEDULAPERSONA  FROM JOVEN INNER JOIN ORIENTADOR ON JOVEN.IDORIENTADOR = ORIENTADOR.IDORIENTADOR WHERE (ORIENTADOR.IDORIENTADOR = " + IDORIENTADOR + ")";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                List<clsJoven> listaJovenes = new List<clsJoven>();

                clsConexion.abrirConexion();

                // el lectorProductos consigue todo el contenido dentro de la tabla Producto
                SqlDataReader lectorJovenes = comando.ExecuteReader();
                //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
                while (lectorJovenes.Read())
                {
                    clsJoven objOrientador = new clsJoven();
                    // cada indice significa el lugar dentro de la tabla Producto
                    // Es importante conocer la estructura de la tabla, sino genera error

                    //
                    objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetInt32(0).ToString());
                    objOrientador.NombreApellido = lectorJovenes.GetString(1);

                    //objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetString(1));
                    objOrientador.Cedula = int.Parse(lectorJovenes.GetString(2));


                    listaJovenes.Add(objOrientador);
                }
                clsConexion.cerrarConexion();
                return listaJovenes;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<clsJoven> consultaDatosRepresentantes(int IDORIENTADOR)
        {
            try
            {
                string sql = "SELECT REPRESENTANTE.IDREPRESENTANTE, PERSONA.PRIMERNOMBREPERSONA + ' ' + PERSONA.PRIMERAPELLIDOPERSONA AS Expr1,PERSONA.CEDULAPERSONA  FROM REPRESENTANTE INNER JOIN ORIENTADOR ON REPRESENTANTE.IDORIENTADOR = ORIENTADOR.IDORIENTADOR INNER JOIN PERSONA ON REPRESENTANTE.IDREPRESENTANTE = PERSONA.IDREPRESENTANTE WHERE (ORIENTADOR.IDORIENTADOR = " + IDORIENTADOR + ")";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                List<clsJoven> listaJovenes = new List<clsJoven>();

                clsConexion.abrirConexion();

                // el lectorProductos consigue todo el contenido dentro de la tabla Producto
                SqlDataReader lectorJovenes = comando.ExecuteReader();
                //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
                while (lectorJovenes.Read())
                {
                    clsJoven objOrientador = new clsJoven();
                    // cada indice significa el lugar dentro de la tabla Producto
                    // Es importante conocer la estructura de la tabla, sino genera error

                    //
                    objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetInt32(0).ToString());
                    objOrientador.NombreApellido = lectorJovenes.GetString(1);

                    //objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetString(1));
                    objOrientador.Cedula = int.Parse(lectorJovenes.GetString(2));


                    listaJovenes.Add(objOrientador);
                }
                clsConexion.cerrarConexion();
                return listaJovenes;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<clsJoven> consultaDatosAsistenciaRepresentantes(int IDORIENTADOR, string fechaASISTENCIA)
        {
            try
            {
                string sql = "SELECT REPRESENTANTE.IDREPRESENTANTE, PERSONA.PRIMERNOMBREPERSONA + ' ' + PERSONA.PRIMERAPELLIDOPERSONA AS Expr1,PERSONA.CEDULAPERSONA  FROM REPRESENTANTE INNER JOIN ORIENTADOR ON REPRESENTANTE.IDORIENTADOR = ORIENTADOR.IDORIENTADOR INNER JOIN PERSONA ON REPRESENTANTE.IDREPRESENTANTE = PERSONA.IDREPRESENTANTE INNER JOIN ASISTENCIA ON ASISTENCIA.IDREPRESENTANTE =REPRESENTANTE.IDREPRESENTANTE WHERE (ORIENTADOR.IDORIENTADOR =" + IDORIENTADOR + ")AND (ASISTENCIA.FECHAASISTENCIA = '" + fechaASISTENCIA + "')";
                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                List<clsJoven> listaJovenes = new List<clsJoven>();

                clsConexion.abrirConexion();

                // el lectorProductos consigue todo el contenido dentro de la tabla Producto
                SqlDataReader lectorJovenes = comando.ExecuteReader();
                //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
                while (lectorJovenes.Read())
                {
                    clsJoven objOrientador = new clsJoven();
                    // cada indice significa el lugar dentro de la tabla Producto
                    // Es importante conocer la estructura de la tabla, sino genera error

                    //
                    objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetInt32(0).ToString());
                    objOrientador.NombreApellido = lectorJovenes.GetString(1);

                    //objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetString(1));
                    objOrientador.Cedula = int.Parse(lectorJovenes.GetString(2));


                    listaJovenes.Add(objOrientador);
                }
                clsConexion.cerrarConexion();
                return listaJovenes;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<clsJoven> consultaDatosAsistenciaRepresentantesReunion(int IDORIENTADOR, int IDREUNION)
        {
            try
            {

                string sql = "SELECT REPRESENTANTE.IDREPRESENTANTE, PERSONA.PRIMERNOMBREPERSONA + ' ' + PERSONA.PRIMERAPELLIDOPERSONA AS Expr1, PERSONA.CEDULAPERSONA, REUNIONES.IDINDICADOR FROM REPRESENTANTE INNER JOIN ORIENTADOR ON REPRESENTANTE.IDORIENTADOR = ORIENTADOR.IDORIENTADOR INNER JOIN PERSONA ON REPRESENTANTE.IDREPRESENTANTE = PERSONA.IDREPRESENTANTE INNER JOIN ASISTENCIA ON ASISTENCIA.IDREPRESENTANTE = REPRESENTANTE.IDREPRESENTANTE INNER JOIN REUNIONES ON REUNIONES.ID_Reunion = ASISTENCIA.IDREUNION WHERE (ORIENTADOR.IDORIENTADOR = " + IDORIENTADOR + ") AND (ASISTENCIA.IDREUNION = " + IDREUNION + ")";

                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                List<clsJoven> listaJovenes = new List<clsJoven>();

                clsConexion.abrirConexion();

                // el lectorProductos consigue todo el contenido dentro de la tabla Producto
                SqlDataReader lectorJovenes = comando.ExecuteReader();
                //ciclo para guardar todos los datos de lectorProductos a la lista en forma de objeto
                while (lectorJovenes.Read())
                {
                    clsJoven objOrientador = new clsJoven();
                    // cada indice significa el lugar dentro de la tabla Producto
                    // Es importante conocer la estructura de la tabla, sino genera error

                    //
                    objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetInt32(0).ToString());
                    objOrientador.NombreApellido = lectorJovenes.GetString(1);

                    //objOrientador.CodigoJoven = int.Parse(lectorJovenes.GetString(1));
                    objOrientador.Cedula = int.Parse(lectorJovenes.GetString(2));
                    objOrientador.CodigoIndicador = lectorJovenes.GetInt32(3);

                    listaJovenes.Add(objOrientador);
                }
                clsConexion.cerrarConexion();
                return listaJovenes;
            } catch (Exception)
            {
                return null;
            }
        }
    }
}
