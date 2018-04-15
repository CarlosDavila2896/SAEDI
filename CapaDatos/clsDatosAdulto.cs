using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaNegocio;
using System.Transactions;

namespace CapaDatos
{
    public class clsDatosAdulto
    {
        
        MERSembrarDataContext bd = new MERSembrarDataContext();
        public bool ingresaAdulto(clsPersona objPersona, clsAdulto objAdulto)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    PERSONA p = new PERSONA();
                    
            
                    p.IDALIMENTACION2 = objPersona.IdAlimentacion;
                    p.PRIMERNOMBREPERSONA = objPersona.PrimerNombre;
                    p.SEGUNDONOMBREPERSONA = objPersona.SegundoNombre;
                    p.PRIMERAPELLIDOPERSONA = objPersona.PrimerApellido;
                    p.SEGUNDOAPELLIDOPERSONA = objPersona.SegundoApellido;
                    p.GENEROPERSONA = objPersona.Genero;
                    p.FECHANACIMIENTOPERSONA = objPersona.Nacimiento;
                    p.CEDULAPERSONA = objPersona.Cedula;
                    p.LUGARNACIMIENTOPERSONA = objPersona.LugarNacimiento;
                    p.VIVECONFAMILIAPERSONA = objPersona.ViveFamilia;
                    p.OBSERVACIONPERSONA = objPersona.Observacion;
                    p.FECHAINGRESOPROGRAMA = objPersona.Ingreso;
                    p.CABEZAFAMILIA = objPersona.Cabeza;
                    bd.PERSONA.InsertOnSubmit(p);
                    bd.SubmitChanges();

                    int idPersona = p.IDPERSONA;

                    //Numeros de telefono
                    foreach (string numero in objPersona.Numeros)
                    {
                        TELEFONOPERSONA telefonos = new TELEFONOPERSONA();
                        telefonos.IDPERSONA = idPersona;
                        telefonos.TELEFONOPERSONA1 = numero;
                        bd.TELEFONOPERSONA.InsertOnSubmit(telefonos);
                        bd.SubmitChanges();
                    }

                    

                    ADULTO a = new ADULTO();

                    a.IDPERSONA = p.IDPERSONA;
                    a.ESTUDIAADULTO = objAdulto.EstudiaAdulto;
                    a.DONDEESTUDIAADULTO = objAdulto.DondeEstudiaAdulto;
                    a.NIVELEDUCACIONADULTO = objAdulto.NivelEducacion;
                    bd.ADULTO.InsertOnSubmit(a);
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

        public bool actualizaAdulto(int codigo, clsPersona objPersona, clsAdulto objAdulto)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    TELEFONOPERSONA telefonos = new TELEFONOPERSONA();
                    PERSONA p = bd.PERSONA.Single(u => u.IDPERSONA == codigo);
                    p.IDALIMENTACION2 = objPersona.IdAlimentacion;
                    p.PRIMERNOMBREPERSONA = objPersona.PrimerNombre;
                    p.SEGUNDONOMBREPERSONA = objPersona.SegundoNombre;
                    p.PRIMERAPELLIDOPERSONA = objPersona.PrimerApellido;
                    p.SEGUNDOAPELLIDOPERSONA = objPersona.SegundoApellido;
                    p.GENEROPERSONA = objPersona.Genero;
                    p.FECHANACIMIENTOPERSONA = objPersona.Nacimiento;
                    p.CEDULAPERSONA = objPersona.Cedula;
                    p.LUGARNACIMIENTOPERSONA = objPersona.LugarNacimiento;
                    p.VIVECONFAMILIAPERSONA = objPersona.ViveFamilia;
                    p.OBSERVACIONPERSONA = objPersona.Observacion;
                    p.FECHAINGRESOPROGRAMA = objPersona.Ingreso;
                    p.CABEZAFAMILIA = objPersona.Cabeza;

                    //Numeros de telefono
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

                    

                    ADULTO a = bd.ADULTO.Single(ad => ad.IDPERSONA == codigo);
                    a.ESTUDIAADULTO = objAdulto.EstudiaAdulto;
                    a.DONDEESTUDIAADULTO = objAdulto.DondeEstudiaAdulto;
                    a.NIVELEDUCACIONADULTO = objAdulto.NivelEducacion;
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
        public object buscarAdulto()
        {
            try
            {
                var buscar = from persona in bd.PERSONA
                             join adulto in bd.ADULTO on persona.IDPERSONA equals adulto.IDPERSONA
                             select new { nombre = persona.PRIMERNOMBREPERSONA + " " + persona.SEGUNDONOMBREPERSONA + " " + persona.PRIMERAPELLIDOPERSONA + " " + persona.SEGUNDOAPELLIDOPERSONA, id = persona.IDPERSONA };
                return buscar;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void buscarAdulto(int codigo, clsPersona objPersona, clsAdulto objAdulto)
        {
            try
            {
                var buscar = from persona in bd.PERSONA
                             join adulto in bd.ADULTO on persona.IDPERSONA equals adulto.IDPERSONA
                             where persona.IDPERSONA == codigo
                             select new { persona, adulto };
                var p = buscar.First();
                objPersona.Codigo = Convert.ToInt32(p.persona.IDPERSONA);
                objPersona.IdAlimentacion = Convert.ToInt32(p.persona.IDALIMENTACION2);
                objPersona.PrimerNombre = p.persona.PRIMERNOMBREPERSONA;
                objPersona.SegundoNombre = p.persona.SEGUNDONOMBREPERSONA;
                objPersona.PrimerApellido = p.persona.PRIMERAPELLIDOPERSONA;
                objPersona.SegundoApellido = p.persona.SEGUNDOAPELLIDOPERSONA;
                objPersona.Genero = p.persona.GENEROPERSONA;
                objPersona.Nacimiento = Convert.ToDateTime(p.persona.FECHANACIMIENTOPERSONA);

                var numTelefonos = (from telefonos in bd.TELEFONOPERSONA
                                    where telefonos.IDPERSONA == codigo
                                    select new { numero = telefonos.TELEFONOPERSONA1 }).Select(x => x.numero).ToList();

                objPersona.Numeros = numTelefonos;

                objPersona.Cedula = p.persona.CEDULAPERSONA;
                objPersona.LugarNacimiento = p.persona.LUGARNACIMIENTOPERSONA;
                
                objPersona.ViveFamilia = p.persona.VIVECONFAMILIAPERSONA;
                objPersona.Observacion = p.persona.OBSERVACIONPERSONA;
                objPersona.Ingreso = Convert.ToDateTime(p.persona.FECHAINGRESOPROGRAMA);
                objPersona.Cabeza = Convert.ToBoolean(p.persona.CABEZAFAMILIA);

                objAdulto.EstudiaAdulto = Convert.ToBoolean(p.adulto.ESTUDIAADULTO);
                objAdulto.DondeEstudiaAdulto = p.adulto.DONDEESTUDIAADULTO;
                objAdulto.NivelEducacion = p.adulto.NIVELEDUCACIONADULTO;
            }
            catch (Exception ex)
            {

            }
        }

        public object consultarAdultos()
        {
            var lista = from a in bd.ADULTO
                        select new
                        {
                            NOMBRECOMPLETO = a.PERSONA.PRIMERNOMBREPERSONA + " " + a.PERSONA.SEGUNDONOMBREPERSONA + " " + a.PERSONA.PRIMERAPELLIDOPERSONA + " " + a.PERSONA.SEGUNDOAPELLIDOPERSONA,
                            IDPERSONA = a.PERSONA.IDPERSONA
                        };
            return lista.ToList().OrderBy(a => a.NOMBRECOMPLETO).ToList();
        }
    }
}
