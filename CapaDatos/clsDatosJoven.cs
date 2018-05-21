using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using CapaNegocio;
namespace CapaDatos
{
    public class clsDatosJoven
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();
        static clsJoven transformarJoven(JOVEN newJoven)
        {
            clsJoven joven = new clsJoven();
            joven.Cedula = newJoven.IDJOVEN;
            joven.IdMenor = newJoven.IDMENOREDAD;
            joven.IdPersona = newJoven.IDPERSONA;
            return joven;
        }

        static clsMenorEdad transformarMenor(MENOREDAD newMenor)
        {
            clsMenorEdad menor = new clsMenorEdad();
            menor.Alimentacion = newMenor.ALIMENTACIONMENOREDAD;
            menor.AnioIngreso = newMenor.ANIOINGRESOMENOREDAD;
            menor.Discapacidad = newMenor.DISCAPACIDADESMENOREDAD;
            menor.IdMenorEdad = newMenor.IDMENOREDAD;
            menor.IdPersona = newMenor.IDPERSONA;
            menor.NombreEncargado = newMenor.NOMBREENCARGADOMENOREDAD;
            menor.Peso = double.Parse(newMenor.PESOMENOREDAD.ToString());
            menor.Sacramento = newMenor.SACRAMENTOMENOREDAD;
            menor.Sad = newMenor.CODIGOSADMENOREDAD;
            menor.Talla = double.Parse(newMenor.TALLAMENOREDAD.ToString());
            menor.Vacunas = newMenor.VACUNASMENOREDAD;
            menor.IdRepresentante = int.Parse(newMenor.IDREPRESENTANTE.ToString());
            return menor;
        }

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
        public bool ingresaJoven(CapaNegocio.clsPersona objPersona, CapaNegocio.clsMenorEdad objMenorEdad)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    PERSONA persona = new PERSONA();
                    MENOREDAD menor = new MENOREDAD();
                    JOVEN joven = new JOVEN();
                    
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
                    foreach (string numero in objPersona.Numeros)
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
                    joven.IDJOVEN = objPersona.Cedula;
                    joven.IDPERSONA = idPersona;
                    joven.IDMENOREDAD = idMenor;
                    bd.JOVEN.InsertOnSubmit(joven);
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

        public object consultarJovenes()
        {
            var lista = from j in bd.JOVEN
                        select new
                        {
                            NOMBRECOMPLETO = j.MENOREDAD.PERSONA.PRIMERNOMBREPERSONA + " " + j.MENOREDAD.PERSONA.SEGUNDONOMBREPERSONA + " " + j.MENOREDAD.PERSONA.PRIMERAPELLIDOPERSONA + " " + j.MENOREDAD.PERSONA.SEGUNDOAPELLIDOPERSONA,
                            IDPERSONA = j.MENOREDAD.PERSONA.IDPERSONA
                        };
            return lista.ToList().OrderBy(a=>a.NOMBRECOMPLETO).ToList();
        }


        public object buscarJoven()
        {
            try
            {
                var buscar = from persona in bd.PERSONA
                             join joven in bd.JOVEN on persona.IDPERSONA equals joven.IDPERSONA
                             select new { nombre = persona.PRIMERNOMBREPERSONA + " " + persona.SEGUNDONOMBREPERSONA + " " + persona.PRIMERAPELLIDOPERSONA + " " + persona.SEGUNDOAPELLIDOPERSONA, id = persona.IDPERSONA };
                return buscar;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void buscarJoven(int codigo, clsPersona objPersona, clsMenorEdad objMenor)
        {
            try
            {
                var buscar = from persona in bd.PERSONA
                             join menor in bd.MENOREDAD on persona.IDPERSONA equals menor.IDPERSONA
                             where persona.IDPERSONA == codigo
                             select new { persona, menor };
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
            }
            catch (Exception ex)
            {

            }
        }


        public object consultaMenorEdad(int idOrientador)
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {

                var pr = from p in db.MENOREDAD
                         where p.IDREPRESENTANTE == idOrientador
                         select new
                         {
                             ID = p.IDMENOREDAD,
                             Nombre = p.PERSONA.PRIMERNOMBREPERSONA
                         };
                return pr.ToList();
            }
        }



        public bool actualizarJoven(int codigo, clsPersona objPersona, clsMenorEdad objMenorEdad)
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
                    
                    bd.SubmitChanges();

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

                    



                    persona.VIVECONFAMILIAPERSONA = objPersona.ViveFamilia;
                    persona.OBSERVACIONPERSONA = objPersona.Observacion;
                    persona.FECHAINGRESOPROGRAMA = objPersona.Ingreso;
                    persona.CABEZAFAMILIA = objPersona.Cabeza;

                    MENOREDAD menor = bd.MENOREDAD.Single(u => u.IDPERSONA == codigo);
                    //menor.IDORIENTADOR = objMenorEdad.IdOrientador;
                    menor.CODIGOSADMENOREDAD = objMenorEdad.Sad;
                    menor.ANIOINGRESOMENOREDAD = objMenorEdad.AnioIngreso;
                    menor.DISCAPACIDADESMENOREDAD = objMenorEdad.Discapacidad;
                    menor.VACUNASMENOREDAD = objMenorEdad.Vacunas;
                    menor.ALIMENTACIONMENOREDAD = objMenorEdad.Alimentacion;
                    menor.NOMBREENCARGADOMENOREDAD = objMenorEdad.NombreEncargado;
                    menor.SACRAMENTOMENOREDAD = objMenorEdad.Sacramento;

                    JOVEN joven = bd.JOVEN.Single(u => u.IDPERSONA == codigo);
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