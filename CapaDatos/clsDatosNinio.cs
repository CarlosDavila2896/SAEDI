using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
namespace CapaDatos
{
    public class clsDatosNinio
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();


        public bool ingresaNinio(clsPersona objPersona, clsNinio objNinio, clsMenorEdad objMenorEdad)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    PERSONA persona = new PERSONA();
                    MENOREDAD menor = new MENOREDAD();
                    NINIO ninio = new NINIO();
                    
                    //datos individuo

                    persona.IDALIMENTACION2 = objPersona.IdAlimentacion;
                    persona.PRIMERNOMBREPERSONA = objPersona.PrimerNombre;
                    persona.SEGUNDONOMBREPERSONA = objPersona.SegundoNombre;
                    persona.PRIMERAPELLIDOPERSONA = objPersona.PrimerApellido;
                    persona.SEGUNDOAPELLIDOPERSONA = objPersona.SegundoApellido;
                    persona.GENEROPERSONA = objPersona.Genero;
                    persona.FECHANACIMIENTOPERSONA = objPersona.Nacimiento;
                    persona.CEDULAPERSONA = objPersona.Cedula;
                    persona.LUGARNACIMIENTOPERSONA = objPersona.LugarNacimiento;
                    persona.VIVECONFAMILIAPERSONA = objPersona.ViveFamilia;
                    persona.OBSERVACIONPERSONA = objPersona.Observacion;
                    persona.FECHAINGRESOPROGRAMA = objPersona.Ingreso;
                    persona.CABEZAFAMILIA = objPersona.Cabeza;
                    bd.PERSONA.InsertOnSubmit(persona);
                    bd.SubmitChanges();
                    int idPersona = persona.IDPERSONA;

                    //Numeros de telefono
                    foreach(string numero in objPersona.Numeros)
                    {
                        TELEFONOPERSONA telefonos = new TELEFONOPERSONA();
                        telefonos.IDPERSONA = idPersona;
                        telefonos.TELEFONOPERSONA1 = numero;
                        bd.TELEFONOPERSONA.InsertOnSubmit(telefonos);
                        bd.SubmitChanges();

                    }

                    


                    //datos menor
                    menor.IDPERSONA = idPersona;
                    //menor.IDORIENTADOR = objMenorEdad.IdOrientador;
                    menor.CODIGOSADMENOREDAD = objMenorEdad.Sad;
                    menor.ANIOINGRESOMENOREDAD = objMenorEdad.AnioIngreso;
                    menor.DISCAPACIDADESMENOREDAD = objMenorEdad.Discapacidad;
                    menor.VACUNASMENOREDAD = objMenorEdad.Vacunas;
                    menor.ALIMENTACIONMENOREDAD = objMenorEdad.Alimentacion;
                    menor.NOMBREENCARGADOMENOREDAD = objMenorEdad.NombreEncargado;
                    menor.SACRAMENTOMENOREDAD = objMenorEdad.Sacramento;
                    bd.MENOREDAD.InsertOnSubmit(menor);
                    bd.SubmitChanges();
                    int idMenor = menor.IDMENOREDAD;
                    //datos ninio
                    ninio.IDPERSONA = idPersona;
                    ninio.IDMENOREDAD = idMenor;
                    ninio.TRABAJONINIO = objNinio.Trabajo;
                    ninio.TIEMPOTRABAJONINIO = objNinio.Tiempo;
                    bd.NINIO.InsertOnSubmit(ninio);
                    //insertar en base
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

        public object consultarNinios()
        {
            var lista = from n in bd.NINIO
                        select new
                        {
                            NOMBRECOMPLETO = n.MENOREDAD.PERSONA.PRIMERNOMBREPERSONA + " " + n.MENOREDAD.PERSONA.SEGUNDONOMBREPERSONA + " " + n.MENOREDAD.PERSONA.PRIMERAPELLIDOPERSONA + " " + n.MENOREDAD.PERSONA.SEGUNDOAPELLIDOPERSONA,
                            IDPERSONA = n.MENOREDAD.PERSONA.IDPERSONA
                        };
            return lista.ToList().OrderBy(a => a.NOMBRECOMPLETO).ToList();
        }

        public List<NINIO> consultarNinio() {
            try
            {
                return bd.NINIO.ToList();
            }
            catch(Exception ex)
            {
                return new List<NINIO>();
            }
        }

        public object consultarNinio2()
        {
            try
            {
                return (from persona in bd.PERSONA
                        join menor in bd.MENOREDAD on persona.IDPERSONA equals menor.IDPERSONA
                        join ninio in bd.NINIO on persona.IDPERSONA equals ninio.IDPERSONA
                        select new
                        {
                            PrimerNombre = ninio.MENOREDAD.PERSONA.PRIMERNOMBREPERSONA + " " + ninio.MENOREDAD.PERSONA.SEGUNDONOMBREPERSONA + " " + ninio.MENOREDAD.PERSONA.PRIMERAPELLIDOPERSONA + " " + ninio.MENOREDAD.PERSONA.SEGUNDOAPELLIDOPERSONA,
                            IdNinio = ninio.IDMENOREDAD,
                            IdPersona = ninio.IDPERSONA
                        }).ToList();
            }
            catch (Exception ex)
            {
                return new object();
            }
        }

        public void buscarNinio(int codigo, clsPersona objPersona, clsMenorEdad objMenor, clsNinio objNinio)
        {
            try
            {
                var buscar = from persona in bd.PERSONA
                             join menor in bd.MENOREDAD on persona.IDPERSONA equals menor.IDPERSONA
                             join ninio in bd.NINIO on persona.IDPERSONA equals ninio.IDPERSONA
                             where persona.IDPERSONA == codigo
                             select new { persona, menor, ninio };
                var p = buscar.First();
                objPersona.Codigo = Convert.ToInt32(p.persona.IDPERSONA);
                objPersona.IdAlimentacion = Convert.ToInt32(p.persona.IDALIMENTACION2);
                objPersona.PrimerNombre = p.persona.PRIMERNOMBREPERSONA;
                objPersona.SegundoNombre = p.persona.SEGUNDONOMBREPERSONA;
                objPersona.PrimerApellido = p.persona.PRIMERAPELLIDOPERSONA;
                objPersona.SegundoApellido = p.persona.SEGUNDOAPELLIDOPERSONA;
                objPersona.Genero = p.persona.GENEROPERSONA;
                objPersona.Nacimiento = Convert.ToDateTime(p.persona.FECHANACIMIENTOPERSONA);
                objPersona.Cedula = p.persona.CEDULAPERSONA;

                var numTelefonos = (from telefonos in bd.TELEFONOPERSONA
                                   where telefonos.IDPERSONA == codigo
                                   select new { numero = telefonos.TELEFONOPERSONA1 }).Select(x => x.numero).ToList();

                objPersona.Numeros = numTelefonos;

                objPersona.LugarNacimiento = p.persona.LUGARNACIMIENTOPERSONA;
                objPersona.ViveFamilia = p.persona.VIVECONFAMILIAPERSONA;
                objPersona.Observacion = p.persona.OBSERVACIONPERSONA;
                objPersona.Ingreso = Convert.ToDateTime(p.persona.FECHAINGRESOPROGRAMA);
                objPersona.Cabeza = Convert.ToBoolean(p.persona.CABEZAFAMILIA);

                objMenor.IdPersona = Convert.ToInt32(p.menor.IDPERSONA);
                objMenor.IdMenorEdad = Convert.ToInt32(p.menor.IDMENOREDAD);
                //objMenor.IdOrientador = Convert.ToInt32(p.menor.IDORIENTADOR);
                objMenor.Sad = p.menor.CODIGOSADMENOREDAD;
                objMenor.AnioIngreso = Convert.ToInt32(p.menor.ANIOINGRESOMENOREDAD);
                objMenor.Discapacidad = p.menor.DISCAPACIDADESMENOREDAD;
                objMenor.Vacunas = Convert.ToBoolean(p.menor.VACUNASMENOREDAD);
                objMenor.Alimentacion = Convert.ToInt32(p.menor.ALIMENTACIONMENOREDAD);
                objMenor.NombreEncargado = Convert.ToInt32(p.menor.NOMBREENCARGADOMENOREDAD);
                objMenor.Sacramento = p.menor.SACRAMENTOMENOREDAD;

                objNinio.IdPersona = Convert.ToInt32(p.ninio.IDPERSONA);
                objNinio.IdMenorEdad = Convert.ToInt32(p.ninio.IDMENOREDAD);
                objNinio.IdNinio = Convert.ToInt32(p.ninio.IDNINIO);
                objNinio.Trabajo = Convert.ToBoolean(p.ninio.TRABAJONINIO);
                objNinio.Tiempo = Convert.ToInt32(p.ninio.TIEMPOTRABAJONINIO);
            }
            catch (Exception ex)
            {

            }
        }

        public bool actualizarNinio(int codigo, clsPersona objPersona, clsNinio objNinio, clsMenorEdad objMenorEdad)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    PERSONA persona = bd.PERSONA.Single(u => u.IDPERSONA == codigo);
                    persona.IDALIMENTACION2 = objPersona.IdAlimentacion;
                    persona.PRIMERNOMBREPERSONA = objPersona.PrimerNombre;
                    persona.SEGUNDONOMBREPERSONA = objPersona.SegundoNombre;
                    persona.PRIMERAPELLIDOPERSONA = objPersona.PrimerApellido;
                    persona.SEGUNDOAPELLIDOPERSONA = objPersona.SegundoApellido;
                    persona.GENEROPERSONA = objPersona.Genero;
                    persona.FECHANACIMIENTOPERSONA = objPersona.Nacimiento;
                    persona.CEDULAPERSONA = objPersona.Cedula;
                    persona.LUGARNACIMIENTOPERSONA = objPersona.LugarNacimiento;
                    persona.VIVECONFAMILIAPERSONA = objPersona.ViveFamilia;
                    persona.OBSERVACIONPERSONA = objPersona.Observacion;
                    persona.FECHAINGRESOPROGRAMA = objPersona.Ingreso;
                    persona.CABEZAFAMILIA = objPersona.Cabeza;

                    //Numeros Telefono
                    var telfAntiguos = from tlfs in bd.TELEFONOPERSONA
                                       where tlfs.IDPERSONA == codigo
                                       select tlfs;
                    foreach (var tlf in telfAntiguos)
                    {
                        bd.TELEFONOPERSONA.DeleteOnSubmit(tlf);
                        bd.SubmitChanges();
                    }

                    
                    
                    foreach (string numero in objPersona.Numeros)
                    {
                        TELEFONOPERSONA telefonosNuevos = new TELEFONOPERSONA();
                        telefonosNuevos.IDPERSONA = codigo;
                        telefonosNuevos.TELEFONOPERSONA1 = numero;
                        bd.TELEFONOPERSONA.InsertOnSubmit(telefonosNuevos);
                        bd.SubmitChanges();
                    }

                    


                    MENOREDAD menor = bd.MENOREDAD.Single(u => u.IDPERSONA == codigo);
                   // menor.IDORIENTADOR = objMenorEdad.IdOrientador;
                    menor.CODIGOSADMENOREDAD = objMenorEdad.Sad;
                    menor.ANIOINGRESOMENOREDAD = objMenorEdad.AnioIngreso;
                    menor.DISCAPACIDADESMENOREDAD = objMenorEdad.Discapacidad;
                    menor.VACUNASMENOREDAD = objMenorEdad.Vacunas;
                    menor.ALIMENTACIONMENOREDAD = objMenorEdad.Alimentacion;
                    menor.NOMBREENCARGADOMENOREDAD = objMenorEdad.NombreEncargado;
                    menor.SACRAMENTOMENOREDAD = objMenorEdad.Sacramento;

                    NINIO ninio = bd.NINIO.Single(u => u.IDPERSONA == codigo);
                    ninio.TRABAJONINIO = objNinio.Trabajo;
                    ninio.TIEMPOTRABAJONINIO = objNinio.Tiempo;

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
    }
}
