using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace CapaDatos
{
    public class clsDatosProcesoNiño
    {
        clsProcesoNiño objProceso = new clsProcesoNiño();
        static clsProcesoNiño transformarprocesoNinio(PROCESO newProceso)
        {
            clsProcesoNiño proceso = new clsProcesoNiño();
            proceso.IDProceso1 = newProceso.IDPROCESO;
            proceso.NombreProceso = newProceso.NOMBREPROCESO;
            proceso.Estado = newProceso.ESTADOPROCESO;
            return proceso;
        }
        int resul;
            public bool AgregarProceso(CapaNegocio.clsProcesoNiño objetoProcesoNiño, CapaNegocio.clsOrientador objetoOrientador)
        {
            try
            {
                string sql = "insert into PROCESO values(@codDuplicado,@codOrientador,@nombreProceso,@estado)";

                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);
                comando.Parameters.Add("@codDuplicado", SqlDbType.Int).Value = objetoProcesoNiño.IdProcesoDuplicado;
                comando.Parameters.Add("@codOrientador", SqlDbType.Int).Value = objetoOrientador.IDOrientador1;
                comando.Parameters.Add("@nombreProceso", SqlDbType.VarChar).Value = objetoProcesoNiño.NombreProceso;
                comando.Parameters.Add("@estado", SqlDbType.Int).Value = objetoProcesoNiño.Estado;
                clsConexion.conexion.Open();

                int resultado = comando.ExecuteNonQuery();
               
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            finally { clsConexion.conexion.Close(); };
        }



        

        private string cadena2;
        public List<clsProcesoNiño> consultaDatosProceso(int IDPROCESO)
        {
            string sql = "SELECT PROCESO.IDPROCESO, PROCESO.NOMBREPROCESO  FROM PROCESO where Estado = "+1;
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsProcesoNiño> listaProceso = new List<clsProcesoNiño>();

            clsConexion.abrirConexion();


            SqlDataReader lectorJovenes = comando.ExecuteReader();

            while (lectorJovenes.Read())
            {
                clsProcesoNiño objProceso = new clsProcesoNiño();

                bool Proceso = false;

                objProceso.IDProceso1= lectorJovenes.GetInt32(0);
                objProceso.NombreProceso = lectorJovenes.GetString(1);
                if (listaProceso.Count == 0)
                {
                    listaProceso.Add(objProceso);
                }
                else
                {
                    for (int i = 0; i < listaProceso.Count; i++)
                    {
                        if (listaProceso[i].NombreProceso== objProceso.NombreProceso)
                        {
                            Proceso = true;

                        }

                    }
                    if (Proceso == false) // condicion para evitarrepetir las fechas dentro del DDL
                    {
                        listaProceso.Add(objProceso);
                    }
                }


            }
            clsConexion.cerrarConexion();
            lectorJovenes.Close();
            return listaProceso;
        }

        public string consultaNombre(int IdProceso)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                string p = (from r in db.PROCESO
                                where r.IDPROCESO == IdProceso
                                select r.NOMBREPROCESO).First().ToString();
                return p;
            }
        }
        public string consultaIdOrientador(int IdProceso)
        {
            //using (MERSembrarDataContext db = new MERSembrarDataContext())
            //{
            //    string p = (from r in db.PROCESO
            //                where r.IDPROCESO == IdProceso
            //                select r.IDORIENTADOR).First().ToString();
            //    return p;
            //}
            return "";
        }

        public int consultaDatosProceso2(string NOMBREPROCESO, int IDORIENTADOR)
        {
            string sql = "SELECT PROCESO.IDPROCESO  FROM PROCESO where Estado = " + 1+"AND NOMBREPROCESO='"+NOMBREPROCESO+"'AND IDORIENTADOR="+IDORIENTADOR;
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsProcesoNiño> listaProceso = new List<clsProcesoNiño>();

            clsConexion.abrirConexion();


            SqlDataReader lectorJovenes = comando.ExecuteReader();

            while (lectorJovenes.Read())
            {
                clsProcesoNiño objProceso = new clsProcesoNiño();

                bool Proceso = false;

                resul = objProceso.IDProceso1 = lectorJovenes.GetInt32(0);
                //objProceso.NombreProceso = lectorJovenes.GetString(1);
                


            }
            clsConexion.cerrarConexion();
            lectorJovenes.Close();
            return resul;
        }
        public object consultaDatosProcesoReunion(int IDPROCESO)
        {
            try
            {
                if ((IDPROCESO == 32))
                {
                    string sql = "SELECT PROCESO.IDPROCESO, PROCESO.NOMBREPROCESO  FROM PROCESO where Estado = " + 1+" AND IDPROCESO ="+ IDPROCESO;

                    SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                    //List<clsProcesoNiño> listaProceso = new List<clsProcesoNiño>();

                    clsConexion.abrirConexion();


                    SqlDataReader lectorJovenes = comando.ExecuteReader();
                    clsProcesoNiño objProceso = new clsProcesoNiño();

                    bool Proceso = false;
                    if (lectorJovenes.Read())
                    {
                        objProceso.IDProceso1 = lectorJovenes.GetInt32(0);
                        objProceso.NombreProceso = lectorJovenes.GetString(1);
                    }

                    clsConexion.cerrarConexion();
                    return objProceso;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        
        }

        public clsDatosProcesoNiño()
        {

            cadena2 = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;


        }

            public List<clsProcesoNiño> listarPregunta()
            {
                SqlConnection conexion = new SqlConnection(cadena2);
                SqlCommand comando = new SqlCommand("select * from PREGUNTA", conexion);

                List<clsProcesoNiño> lista = new List<clsProcesoNiño>();

                conexion.Open();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    clsProcesoNiño proceso = new clsProcesoNiño();

                    proceso.IDProceso1 = lector.GetInt32(0);
                    proceso.IDOrientador1 = lector.GetInt32(1);
                    proceso.NombreProceso= lector.GetString(2);
                    proceso.Estado = lector.GetInt32(3);


                    lista.Add(proceso);


                }

                conexion.Close();

                return lista;

            }




public void ActualizarProceso2(int IDPROCESO)
{
    try
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=Sembrar2;Integrated Security=True");
        SqlCommand comando = new SqlCommand("update PROCESO set IDPROCESODUPLICADO ='" + IDPROCESO + "' where IDPROCESO = " + IDPROCESO + " ", conexion);
        conexion.Open();
        comando.ExecuteNonQuery();
    }
    catch (Exception ex)
    { throw ex; }
  
}     
public void ActualizarProceso(int p1,int p2, string p3)
{

    SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=Sembrar2;Integrated Security=True");
    SqlCommand comando = new SqlCommand("update PROCESO set IDORIENTADOR='" + p2 + "', NOMBREPROCESO='" + p3 + "' where IDPROCESO = " + p1 + " ", conexion);
    conexion.Open();
    comando.ExecuteNonQuery();
 	
}


public void EliminaProceso(int p1, int p2, string p3, int p4)
{
    SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=Sembrar2;Integrated Security=True");
    SqlCommand comando = new SqlCommand("update PROCESO set IDORIENTADOR='" + p2 + "', NOMBREPROCESO='" + p3 + "',ESTADO='" + p4 + "' where IDPROCESO = " + p1 + " ", conexion);
    conexion.Open();
    comando.ExecuteNonQuery();
}

public void agregarRelacionProcesoObjetivos(List<int> lista)
{
    SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=Sembrar2;Integrated Security=True");
    foreach (int item in lista)
    {
        try
        {
            SqlCommand comando = new SqlCommand("insert into PROCESO_OBJETIVO values ((select top 1 IDPROCESO from PROCESO ORDER BY IDPROCESO desc), " + item + ", 1)", conexion);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        catch (Exception ex)
        { throw ex; }
    }

}
    }
}
