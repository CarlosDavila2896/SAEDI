using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CapaNegocio;
using System.Data.SqlClient;
using System.Data;
using CapaDatos.DataSetPersonasTableAdapters;
using System.Transactions;

namespace CapaDatos
{
    public class clsDatosPersona
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();
        static clsPersona transformarPersona(PERSONA newPersona)
        {
            clsPersona persona = new clsPersona();
            persona.Codigo = newPersona.IDPERSONA;
            persona.IdAlimentacion = int.Parse(newPersona.IDALIMENTACION2.ToString());
            persona.PrimerNombre = newPersona.PRIMERNOMBREPERSONA;
            persona.SegundoNombre = newPersona.SEGUNDONOMBREPERSONA;
            persona.PrimerApellido = newPersona.PRIMERAPELLIDOPERSONA;
            persona.SegundoApellido = newPersona.SEGUNDOAPELLIDOPERSONA;
            persona.Genero = newPersona.GENEROPERSONA;
            persona.Nacimiento = DateTime.Parse(newPersona.FECHANACIMIENTOPERSONA.ToString());
            persona.Cedula = newPersona.CEDULAPERSONA;
            persona.LugarNacimiento = newPersona.LUGARNACIMIENTOPERSONA;
            persona.ViveFamilia = newPersona.VIVECONFAMILIAPERSONA;
            persona.Observacion = newPersona.OBSERVACIONPERSONA;
            persona.Ingreso = DateTime.Parse(newPersona.FECHAINGRESOPROGRAMA.ToString());
            persona.Cabeza = bool.Parse(newPersona.CABEZAFAMILIA.ToString());
            return persona;
        }
        private string cadena2;

        private static PERSONATableAdapter  adaptador = new PERSONATableAdapter();
        public static object buscarPersona(int codigo)
        {
            return adaptador.BuscarPersona(codigo);

        }

        public clsDatosPersona()
        {

            cadena2 = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;


        }

        public List<clsPersona> listarIndicador()
        {
            SqlConnection conexion = new SqlConnection(cadena2);
            SqlCommand comando = new SqlCommand("select * from TIPOPERSONA", conexion);

            List<clsPersona> lista = new List<clsPersona>();

            conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                clsPersona  persona = new clsPersona();

                persona.Codigo = lector.GetInt32(0);
               // persona.NombreTipoPersona = lector.GetString(1);
              

               lista.Add(persona);


            }

            conexion.Close();

            return lista;

        }

        public object D_consultarPersonaPorProcesoYOrientador(int idProceso, int idOrientador)
        {
            try
            {
                using (MERSembrarDataContext bd = new MERSembrarDataContext())
                {
                    return (from solucion in bd.SOLUCIONCUESTIONARIO
                            join persona in bd.PERSONA on solucion.IDPERSONA equals persona.IDPERSONA
                            join matricula in bd.MATRICULA on solucion.IDPROCESO equals matricula.IDPROCESO
                            where solucion.IDPROCESO == idProceso && matricula.IDPERIODO == solucion.IDPERIODO
                            && matricula.IDORIENTADOR == idOrientador
                            select new
                            {
                                Nombre = persona.PRIMERNOMBREPERSONA + ' ' +persona.SEGUNDONOMBREPERSONA + ' ' + persona.PRIMERAPELLIDOPERSONA + ' ' + persona.SEGUNDOAPELLIDOPERSONA,
                                IdPersona = persona.IDPERSONA
                            }).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                return new object();
            }
        }

        public object D_consultarPersonaPorProceso()
        {
            try
            {
                using (MERSembrarDataContext bd = new MERSembrarDataContext())
                {
                    return (from solucion in bd.SOLUCIONCUESTIONARIO
                            join persona in bd.PERSONA on solucion.IDPERSONA equals persona.IDPERSONA
                            select new
                            {
                                Nombre = persona.PRIMERNOMBREPERSONA + ' ' + persona.SEGUNDONOMBREPERSONA + ' ' + persona.PRIMERAPELLIDOPERSONA + ' ' + persona.SEGUNDOAPELLIDOPERSONA,
                                IdPersona = persona.IDPERSONA
                            }).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                return new object();
            }
        }

        //Info personas sin filtrar
        public object consultarInfoIndividuos()
        {
            //try
            //{
                var individuos = from p in bd.PERSONA
                                 select new
                                 {
                                     ID=p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString()

                                 };


                return individuos.ToList();
            //}
            //catch (Exception ex)
            //{
            //    return new List<PERSONA>();
            //}
        }

        //Consultar cantidad de todos los individuos
        public int consultarInfoIndividuosCantidad()
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    return db.PERSONA.Count();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Info personas filtro
        public object consultarInfoIndividuosFiltro(string texto)
        {
            try
            {
                var individuos = from p in bd.PERSONA
                                 select new
                                 {
                                     ID = p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString()

                                 };


                return individuos.ToList().Where(n => n.NOMBRES.ToUpper().Contains(texto.ToUpper()));
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consultar cantidad de todos los individuos
        public int consultarInfoIndividuosCantidadFiltro(string texto)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var individuos = (from p in bd.PERSONA
                                      select new
                                      {
                                          NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                      });
                    return individuos.ToList().Where(n => n.NOMBRES.ToUpper().Contains(texto.ToUpper())).ToList().Count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //Info solo de adultos
        public object consultarInfoIndividuosAdultos()
        {
            try
            {
                var individuos = from p in bd.PERSONA
                                 join a in bd.ADULTO on p.IDPERSONA equals a.IDPERSONA
                                 select new
                                 {
                                     ID = p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString()

                                 };


                return individuos.ToList();
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consultar cantidad de todos los adultos
        public int consultarInfoIndividuosAdultosCantidad()
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var individuos = (from p in bd.PERSONA
                                     join a in bd.ADULTO on p.IDPERSONA equals a.IDPERSONA
                                     select p);
                    return individuos.ToList().Count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Info personas filtro
        public object consultarInfoIndividuosAdultosFiltro(string texto)
        {
            try
            {
                var individuos = from p in bd.PERSONA
                                 join a in bd.ADULTO on p.IDPERSONA equals a.IDPERSONA
                                 select new
                                 {
                                     ID = p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString()

                                 };


                return individuos.ToList().Where(n => n.NOMBRES.ToUpper().Contains(texto.ToUpper()));
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consultar cantidad de todos los individuos
        public int consultarInfoIndividuosCantidadAdultosFiltro(string texto)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var individuos = (from p in bd.PERSONA
                                      join a in bd.ADULTO on p.IDPERSONA equals a.IDPERSONA
                                      select new
                                      {
                                          NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                      });
                    return individuos.ToList().Where(n => n.NOMBRES.ToUpper().Contains(texto.ToUpper())).ToList().Count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Info solo de jovenes
        public object consultarInfoIndividuosJovenes()
        {
            try
            {
                var individuos = from p in bd.PERSONA
                                 join j in bd.JOVEN on p.IDPERSONA equals j.IDPERSONA
                                 join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                 select new
                                 {
                                     ID = p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString(),
                                     CODIGOSAD = m.CODIGOSADMENOREDAD

                                 };


                return individuos.ToList();
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consultar cantidad de todos los jovenes
        public int consultarInfoIndividuosJovenesCantidad()
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var individuos = (from p in bd.PERSONA
                                      join j in bd.JOVEN on p.IDPERSONA equals j.IDPERSONA
                                      select p);
                    return individuos.ToList().Count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Info solo de jovenes
        public object consultarInfoIndividuosJovenesCodigo(string Codigo)
        {
            try
            {
                var individuos = from p in bd.PERSONA
                                 join j in bd.JOVEN on p.IDPERSONA equals j.IDPERSONA
                                 join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                 where m.CODIGOSADMENOREDAD.Contains(Codigo)
                                 select new
                                 {
                                     ID = p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString(),
                                     CODIGOSAD = m.CODIGOSADMENOREDAD

                                 };


                return individuos.ToList();
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consultar cantidad de todos los jovenes
        public int consultarInfoIndividuosJovenesCantidadCodigo(string Codigo)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var individuos = (from p in bd.PERSONA
                                      join j in bd.JOVEN on p.IDPERSONA equals j.IDPERSONA
                                      join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                      where m.CODIGOSADMENOREDAD.Contains(Codigo)
                                      select p);
                    return individuos.ToList().Count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Info solo de ninios
        public object consultarInfoIndividuosNinios()
        {
            try
            {
                var individuos = from p in bd.PERSONA
                                 join n in bd.NINIO on p.IDPERSONA equals n.IDPERSONA
                                 join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                 select new
                                 {
                                     ID = p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString(),
                                     CODIGOSAD = m.CODIGOSADMENOREDAD

                                 };


                return individuos.ToList();
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consultar cantidad de todos los ninios
        public int consultarInfoIndividuosNiniosCantidad()
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var individuos = (from p in bd.PERSONA
                                      join n in bd.NINIO on p.IDPERSONA equals n.IDPERSONA
                                      select p);
                    return individuos.ToList().Count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Info solo de menores por codigo
        public object consultarInfoIndividuosNiniosCodigo(string Codigo)
        {
            try
            {
                var individuos = from p in bd.PERSONA
                                 join n in bd.NINIO on p.IDPERSONA equals n.IDPERSONA
                                 join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                 where m.CODIGOSADMENOREDAD.Contains(Codigo)
                                 select new
                                 {
                                     ID = p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString(),
                                     CODIGOSAD = m.CODIGOSADMENOREDAD

                                 };


                return individuos.ToList();
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consultar cantidad de todos los ninios
        public int consultarInfoIndividuosNiniosCantidadCodigo(string Codigo)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var individuos = (from p in bd.PERSONA
                                      join n in bd.NINIO on p.IDPERSONA equals n.IDPERSONA
                                      join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                      where m.CODIGOSADMENOREDAD.Contains(Codigo)
                                      select p);
                    return individuos.ToList().Count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Info solo de menores por codigo
        public object consultarInfoIndividuosNiniosFiltro(string texto)
        {
            try
            {
                var individuos = from p in bd.PERSONA
                                 join n in bd.NINIO on p.IDPERSONA equals n.IDPERSONA
                                 join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                 where m.CODIGOSADMENOREDAD.Contains(texto) || p.PRIMERNOMBREPERSONA.ToUpper().Contains(texto.ToUpper()) || p.SEGUNDONOMBREPERSONA.ToUpper().Contains(texto.ToUpper()) || p.PRIMERAPELLIDOPERSONA.ToUpper().Contains(texto.ToUpper()) || p.SEGUNDOAPELLIDOPERSONA.ToUpper().Contains(texto.ToUpper())
                                 select new
                                 {
                                     ID = p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString(),
                                     CODIGOSAD = m.CODIGOSADMENOREDAD

                                 };


                return individuos.ToList();
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consultar cantidad de todos los ninios
        public int consultarInfoIndividuosNiniosCantidadFiltro(string texto)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var individuos = (from p in bd.PERSONA
                                      join n in bd.NINIO on p.IDPERSONA equals n.IDPERSONA
                                      join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                      where m.CODIGOSADMENOREDAD.Contains(texto) || p.PRIMERNOMBREPERSONA.ToUpper().Contains(texto.ToUpper()) || p.SEGUNDONOMBREPERSONA.ToUpper().Contains(texto.ToUpper()) || p.PRIMERAPELLIDOPERSONA.ToUpper().Contains(texto.ToUpper()) || p.SEGUNDOAPELLIDOPERSONA.ToUpper().Contains(texto.ToUpper())
                                      select new
                                      {
                                          NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                      });
                    return individuos.ToList().Count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //Info solo de menores por codigo
        public object consultarInfoIndividuosJovenesFiltro(string texto)
        {
            try
            {
                var individuos = from p in bd.PERSONA
                                 join j in bd.JOVEN on p.IDPERSONA equals j.IDPERSONA
                                 join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                 where m.CODIGOSADMENOREDAD.Contains(texto) || p.PRIMERNOMBREPERSONA.ToUpper().Contains(texto.ToUpper()) || p.SEGUNDONOMBREPERSONA.ToUpper().Contains(texto.ToUpper()) || p.PRIMERAPELLIDOPERSONA.ToUpper().Contains(texto.ToUpper()) || p.SEGUNDOAPELLIDOPERSONA.ToUpper().Contains(texto.ToUpper())
                                 select new
                                 {
                                     ID = p.IDPERSONA,
                                     NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     CEDULA = p.CEDULAPERSONA,
                                     FECHANACIMIENTO = (Convert.ToDateTime(p.FECHANACIMIENTOPERSONA)).ToShortDateString(),
                                     LUGARNACIMIENTO = p.LUGARNACIMIENTOPERSONA,
                                     GENERO = p.GENEROPERSONA,
                                     FECHAINGRESO = (Convert.ToDateTime(p.FECHAINGRESOPROGRAMA)).ToShortDateString(),
                                     CODIGOSAD = m.CODIGOSADMENOREDAD

                                 };


                return individuos.ToList();
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consultar cantidad de todos los ninios
        public int consultarInfoIndividuosJovenesCantidadFiltro(string texto)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    var individuos = (from p in bd.PERSONA
                                      join j in bd.JOVEN on p.IDPERSONA equals j.IDPERSONA
                                      join m in bd.MENOREDAD on p.IDPERSONA equals m.IDPERSONA
                                      where m.CODIGOSADMENOREDAD.Contains(texto) || p.PRIMERNOMBREPERSONA.ToUpper().Contains(texto.ToUpper()) || p.SEGUNDONOMBREPERSONA.ToUpper().Contains(texto.ToUpper()) || p.PRIMERAPELLIDOPERSONA.ToUpper().Contains(texto.ToUpper()) || p.SEGUNDOAPELLIDOPERSONA.ToUpper().Contains(texto.ToUpper())
                                      select new
                                      {
                                          NOMBRES = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                      });
                    return individuos.ToList().Count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //Consultar tipo persona
        public int consultaTipoPersona(int idPersona)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                int contador = (from p in bd.PERSONA
                                  join n in bd.NINIO on p.IDPERSONA equals n.IDPERSONA
                                  where p.IDPERSONA == idPersona
                                  select p).Count();
                if (contador == 1)
                {
                    return 1;
                }
                contador = (from p in bd.PERSONA
                            join j in bd.JOVEN on p.IDPERSONA equals j.IDPERSONA
                            where p.IDPERSONA == idPersona
                            select p).Count();
                if (contador == 1)
                {
                    return 2;
                }

                contador = (from p in bd.PERSONA
                            join a in bd.ADULTO on p.IDPERSONA equals a.IDPERSONA
                            where p.IDPERSONA == idPersona
                            select p).Count();
                if (contador == 1)
                {
                    return 3;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool eliminaPersona(clsPersona objPersona)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    JOVEN joven = (from j in bd.JOVEN where j.IDPERSONA == objPersona.Codigo select j).First();
                    NINIO ninio = (from n in bd.NINIO where n.IDPERSONA == objPersona.Codigo select n).First();
                    ADULTO adulto = (from a in bd.ADULTO where a.IDPERSONA == objPersona.Codigo select a).First();
                    MENOREDAD menor = (from m in bd.MENOREDAD where m.IDPERSONA == objPersona.Codigo select m).First();
                    PERSONA persona = (from p in bd.PERSONA where p.IDPERSONA == objPersona.Codigo select p).First();
                    bd.ADULTO.DeleteOnSubmit(adulto);
                    bd.SubmitChanges();

                    bd.NINIO.DeleteOnSubmit(ninio);
                    bd.SubmitChanges();

                    bd.JOVEN.DeleteOnSubmit(joven);
                    bd.SubmitChanges();

                    bd.MENOREDAD.DeleteOnSubmit(menor);
                    bd.SubmitChanges();

                    bd.PERSONA.DeleteOnSubmit(persona);
                    bd.SubmitChanges();



                    trans.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;

                }
            }
        }




        public List<PERSONA> consultarIndividuos(List<clsasignarfamilia> lista)
        {
            try
            {
                List<PERSONA> retorno = new List<PERSONA>();
                PERSONA buscada;
                foreach (clsasignarfamilia per in lista)
                {
                    buscada = new PERSONA();
                    buscada = bd.PERSONA.Where(p => p.IDPERSONA == per.CodigoPersona).First();
                    retorno.Add(buscada);
                }
                return retorno;
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        public List<PERSONA> consultarIndividuosSinFamilia()
        {
            try
            {
                return bd.PERSONA.Where(p => !bd.PERSONA_FAMILIA.Any(p2 => p2.IDPERSONA == p.IDPERSONA)).ToList();
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        public List<PERSONA> consultarIndividuosValidos(clsNPeriodoPrograma objPP)
        {
            //try
            //{
            //    PERIODO_PROGRAMA PP = bd.PERIODO_PROGRAMA.Where(pp2 => pp2.IDPERIODOPROGRAMA == objPP.IDPERIODOPROGRAMA).First();
            //    return bd.PERSONA.Where(p => bd.PERSONA_FAMILIA.Any(p2 => p2.IDPERSONA == p.IDPERSONA)).ToList();
            //}
            //catch (Exception ex)
            //{
            //    return new List<PERSONA>();
            //}
            return new List<PERSONA>();
        }


        public bool eliminaJoven(clsPersona objPersona)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    JOVEN joven = (from j in bd.JOVEN where j.IDPERSONA == objPersona.Codigo select j).First();
                    MENOREDAD menor = (from m in bd.MENOREDAD where m.IDPERSONA == objPersona.Codigo select m).First();
                    PERSONA persona = (from p in bd.PERSONA where p.IDPERSONA == objPersona.Codigo select p).First();

                    bd.JOVEN.DeleteOnSubmit(joven);
                    bd.SubmitChanges();

                    bd.MENOREDAD.DeleteOnSubmit(menor);
                    bd.SubmitChanges();

                    bd.PERSONA.DeleteOnSubmit(persona);
                    bd.SubmitChanges();



                    trans.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;

                }
            }
        }
        public bool eliminaAdulto(clsPersona objPersona)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    ADULTO adulto = (from a in bd.ADULTO where a.IDPERSONA == objPersona.Codigo select a).First();
                    PERSONA persona = (from p in bd.PERSONA where p.IDPERSONA == objPersona.Codigo select p).First();

                    bd.ADULTO.DeleteOnSubmit(adulto);
                    bd.SubmitChanges();

                    bd.PERSONA.DeleteOnSubmit(persona);
                    bd.SubmitChanges();



                    trans.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;

                }
            }
        }

        public bool eliminaNinio(clsPersona objPersona)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    NINIO ninio = (from n in bd.NINIO where n.IDPERSONA == objPersona.Codigo select n).First();
                    MENOREDAD menor = (from m in bd.MENOREDAD where m.IDPERSONA == objPersona.Codigo select m).First();
                    PERSONA persona = (from p in bd.PERSONA where p.IDPERSONA == objPersona.Codigo select p).First();

                    bd.NINIO.DeleteOnSubmit(ninio);
                    bd.SubmitChanges();

                    bd.MENOREDAD.DeleteOnSubmit(menor);
                    bd.SubmitChanges();

                    bd.PERSONA.DeleteOnSubmit(persona);
                    bd.SubmitChanges();



                    trans.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;

                }
            }
        }

        public List<PERSONA> consultarIndividuos()
        {
            try
            {
                return bd.PERSONA.ToList();
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        //Consulta individuos segun linea de accion
        public object D_consultaIndividuosPorLineaDeAccion(int idLineaAccion)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                //Anio maximo representa en anio mas antiguo en el que el individuo pudo haber nacido
                int anioMin, anioMax;

                try
                {
                    var edadMinimaVar = (from la in db.LINEADEACCION where la.IDLINEADEACCION == idLineaAccion select la.TIPOPERSONA).First().EDADMINIMA.Value;
                    anioMax = DateTime.Now.Year - int.Parse(edadMinimaVar.ToString());
                    
                }
                catch
                {
                    anioMax = 3000;
                }

                try
                {
                    var edadMaximaVar = (from la in db.LINEADEACCION where la.IDLINEADEACCION == idLineaAccion select la.TIPOPERSONA).First().EDADMAXIMA.Value;
                    anioMin = DateTime.Now.Year - int.Parse(edadMaximaVar.ToString());
                }
                catch
                {
                    anioMin = 0;
                }
                

                var individuos = from p in bd.PERSONA
                                 where p.FECHANACIMIENTOPERSONA.Value.Year <= anioMax && p.FECHANACIMIENTOPERSONA.Value.Year >= anioMin
                                 select new
                                 {
                                     IDPERSONA = p.IDPERSONA,
                                     NOMBRE = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA,
                                     
                                 };


                return individuos.ToList();



            }
        }
        
        public object D_consultaIndividuosPorLineaDeAccionOrientador(int idLineaAccion,int idOrientador, int idProceso, int idPeriodo)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                //Anio maximo representa en anio mas antiguo en el que el individuo pudo haber nacido
                int anioMin, anioMax;

                try
                {
                    var edadMinimaVar = (from la in db.LINEADEACCION where la.IDLINEADEACCION == idLineaAccion select la.TIPOPERSONA).First().EDADMINIMA.Value;
                    anioMax = DateTime.Now.Year - int.Parse(edadMinimaVar.ToString());

                }
                catch
                {
                    anioMax = 3000;
                }

                try
                {
                    var edadMaximaVar = (from la in db.LINEADEACCION where la.IDLINEADEACCION == idLineaAccion select la.TIPOPERSONA).First().EDADMAXIMA.Value;
                    anioMin = DateTime.Now.Year - int.Parse(edadMaximaVar.ToString());
                }
                catch
                {
                    anioMin = 0;
                }

                var individuos = from p in bd.PERSONASORIENTADOR
                                 where p.FECHANACIMIENTOPERSONA.Value.Year <= anioMax && p.FECHANACIMIENTOPERSONA.Value.Year >= anioMin && p.IDORIENTADOR == idOrientador && p.IDLINEAACCION == idLineaAccion && p.IDPERIODO == idPeriodo && p.IDPROCESO == idProceso
                                 select p;
                return individuos.ToList();


            }
        }

        public object D_consultaIndividuosPorLineaDeAccionOrientador()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                var individuos = from p in bd.PERSONA
                                 select new
                                 {
                                     IDPERSONA = p.IDPERSONA,
                                     NOMBRE = p.PRIMERNOMBREPERSONA + " " + p.SEGUNDONOMBREPERSONA + " " + p.PRIMERAPELLIDOPERSONA + " " + p.SEGUNDOAPELLIDOPERSONA
                                 };


                return individuos.ToList().OrderBy(i=>i.NOMBRE);

            }
        }

    }
}