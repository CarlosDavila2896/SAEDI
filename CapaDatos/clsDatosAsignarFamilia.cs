using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaNegocio;
using System.Transactions;

namespace CapaDatos
{
    public class clsDatosAsignarFamilia
    {
        MERSembrarDataContext bd = new MERSembrarDataContext();
        public List<PERIODO_PERSONA_FAMILIA> ConsultaFamilias()
        {
            try
            {
                return bd.PERIODO_PERSONA_FAMILIA.Where(ppf => ppf.PERIODO.ESTADOPERIODO == true).ToList();
            }
            catch(Exception ex)
            {
                return new List<PERIODO_PERSONA_FAMILIA>(); 
            }
        }
        public List<clsasignarfamilia> ConsultaMiembrosFamilia(clsNFamilia familia)
        {
            try
            {
                List<clsasignarfamilia> listaMiembros = new List<clsasignarfamilia>();
                List<PERIODO_PERSONA_FAMILIA> bases = bd.PERIODO_PERSONA_FAMILIA.Where(pf => pf.IDFAMILIA == familia.IDFAMILIA && pf.PERIODO.ESTADOPERIODO == true && pf.PERIODO.IDTIPOPERIODO==2).ToList();
                foreach (PERIODO_PERSONA_FAMILIA ppf in bases)
                {
                    clsasignarfamilia miembro = new clsasignarfamilia();
                    miembro.CodigoFamilia = ppf.IDFAMILIA;
                    miembro.NombreFamilia = ppf.FAMILIA.NOMBREFAMILIA;
                    miembro.CodigoPersona = ppf.IDPERSONA;
                    miembro.PrimerNombre = bd.PERSONA.Where(pa => pa.IDPERSONA == ppf.IDPERSONA).First().PRIMERNOMBREPERSONA;
                    miembro.SegundoNombre = bd.PERSONA.Where(pa => pa.IDPERSONA == ppf.IDPERSONA).First().SEGUNDONOMBREPERSONA;
                    miembro.PrimerApellido = bd.PERSONA.Where(pa => pa.IDPERSONA == ppf.IDPERSONA).First().PRIMERAPELLIDOPERSONA;
                    miembro.SegundoApellido = bd.PERSONA.Where(pa => pa.IDPERSONA == ppf.IDPERSONA).First().SEGUNDOAPELLIDOPERSONA;
                    miembro.CodigoParentezco = ppf.PARENTEZCO.IDPARENTEZCO;
                    miembro.Parentesco = ppf.PARENTEZCO.NOMBREPARENTEZCO;
                    listaMiembros.Add(miembro);
                }
                return listaMiembros;
            }
            catch (Exception ex)
            {
                return new List<clsasignarfamilia>();
            }
        }

       public List<clsasignarfamilia> ListarPersonaSinFa()
        {
            //string sql = "select * from PERSONA p left join persona_familia pf on p.idpersona=pf.idpersona where pf.idpersona is null ";
            string sql = "select tbl.IDPERSONA,tbl.PRIMERNOMBREPERSONA, tbl.SEGUNDONOMBREPERSONA, tbl.PRIMERAPELLIDOPERSONA, tbl.SEGUNDOAPELLIDOPERSONA, p.NOMBREPARENTEZCO from (select p.IDPERSONA,p.PRIMERNOMBREPERSONA,p.SEGUNDONOMBREPERSONA,p.PRIMERAPELLIDOPERSONA,p.SEGUNDOAPELLIDOPERSONA, p.IDPARENTEZCO from PERSONA p left join persona_familia pf on p.idpersona=pf.idpersona where pf.idpersona is null) as tbl inner join PARENTEZCO p on tbl.IDPARENTEZCO=p.IDPARENTEZCO";
            SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

            List<clsasignarfamilia> listaPersona = new List<clsasignarfamilia>();
            clsConexion.abrirConexion();
            SqlDataReader lectorPersona = comando.ExecuteReader();

            while (lectorPersona.Read())
            {
                

                clsasignarfamilia objetoPersona = new clsasignarfamilia();
                objetoPersona.Persona = lectorPersona.GetInt32(0);
                objetoPersona.PrimerNombre = lectorPersona.GetString(1);
                objetoPersona.SegundoNombre = lectorPersona.GetString(2);
                objetoPersona.PrimerApellido = lectorPersona.GetString(3);
                objetoPersona.SegundoApellido = lectorPersona.GetString(4);
                objetoPersona.Parentesco = lectorPersona.GetString(5);
                listaPersona.Add(objetoPersona);
               
            }
            clsConexion.cerrarConexion();

            return listaPersona;

        }

        




        public bool ingresaPersonaFamilia(List<clsasignarfamilia> lista,clsRepresentante repre)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    REPRESENTANTE r = new REPRESENTANTE();
                    r.IDPERSONA = repre.IDPERSONA;
                    bd.REPRESENTANTE.InsertOnSubmit(r);
                    bd.SubmitChanges();

                    PERIODO actualFamilia = new PERIODO();
                    actualFamilia.FECHAINICIOPERIODO = DateTime.Now;
                    actualFamilia.IDTIPOPERIODO = 2;
                    actualFamilia.NOMBREPERIODO = "NOMBRE";
                    bd.PERIODO.InsertOnSubmit(actualFamilia);
                    bd.SubmitChanges();

                    PERSONA_FAMILIA pf = new PERSONA_FAMILIA();
                    pf.IDFAMILIA = lista.First().CodigoFamilia;
                    PERIODO_PERSONA_FAMILIA ppf = new PERIODO_PERSONA_FAMILIA();
                    ppf.IDFAMILIA = lista.First().CodigoFamilia;
                    ppf.IDPERIODO = actualFamilia.IDPERIODO;
                    foreach (clsasignarfamilia relacion in lista)
                    {

                        pf.IDPERSONA = relacion.CodigoPersona;
                        bd.PERSONA_FAMILIA.InsertOnSubmit(pf);
                        bd.SubmitChanges();

                        ppf.IDPERSONA = relacion.CodigoPersona;

                        if (ppf.IDPERSONA == repre.IDPERSONA)
                        {
                            ppf.REPRESENTANTE = true;
                        }
                        else {
                            ppf.REPRESENTANTE = false;
                        }
                        bd.PERIODO_PERSONA_FAMILIA.InsertOnSubmit(ppf);
                        bd.SubmitChanges();
                    }
                    trans.Complete();
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

        public clsasignarfamilia ConsultaFamilias(clsasignarfamilia nuevaRelacion)
        {
            try
            {
                clsasignarfamilia retorno = new clsasignarfamilia();
                PERSONA per= bd.PERSONA.Where(p => p.IDPERSONA == nuevaRelacion.CodigoPersona).First();
                retorno.CodigoPersona = nuevaRelacion.CodigoPersona;
                retorno.PrimerNombre = per.PRIMERNOMBREPERSONA;
                retorno.SegundoNombre = per.SEGUNDONOMBREPERSONA;
                retorno.PrimerApellido = per.PRIMERAPELLIDOPERSONA;
                retorno.SegundoApellido = per.SEGUNDOAPELLIDOPERSONA;
                retorno.CodigoFamilia = nuevaRelacion.CodigoFamilia;
                FAMILIA fam = bd.FAMILIA.Where(f => f.IDFAMILIA == nuevaRelacion.CodigoFamilia).First();
                retorno.NombreFamilia = fam.NOMBREFAMILIA; ;
                retorno.CodigoParentezco = nuevaRelacion.CodigoParentezco;
                PARENTEZCO par = bd.PARENTEZCO.Where(pa => pa.IDPARENTEZCO == nuevaRelacion.CodigoParentezco).First();
                retorno.Parentesco = par.NOMBREPARENTEZCO;
                return retorno;

            }
            catch (Exception ex)
            {
                return new clsasignarfamilia();
            }
        }

        public bool ingresarMiembrosFamilia(List<clsasignarfamilia> nuevaLista, clsRepresentante objRepresentante)
        {
            nuevaLista = nuevaLista.Distinct().ToList();
            try
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    bool existe = bd.REPRESENTANTE.Any(r => r.IDPERSONA == objRepresentante.IDPERSONA);
                    if (!existe)
                    {
                        REPRESENTANTE nuevoRep = new REPRESENTANTE();
                        nuevoRep.IDPERSONA = objRepresentante.IDPERSONA;
                        bd.REPRESENTANTE.InsertOnSubmit(nuevoRep);
                        bd.SubmitChanges();
                    }
                    PERIODO nuevoPeriodo = new PERIODO();
                    nuevoPeriodo.ESTADOPERIODO = true;
                    nuevoPeriodo.IDTIPOPERIODO = 2;
                    nuevoPeriodo.FECHAINICIOPERIODO = DateTime.Now;
                    nuevoPeriodo.NOMBREPERIODO = nuevaLista.Select(n=>n.NombreFamilia).First().ToUpper() + " - " + nuevoPeriodo.FECHAINICIOPERIODO.ToString().ToUpper();
                    bd.PERIODO.InsertOnSubmit(nuevoPeriodo);
                    bd.SubmitChanges();

                    foreach (clsasignarfamilia relacion in nuevaLista)
                    {
                        PERSONA_FAMILIA nuevaPF = new PERSONA_FAMILIA();
                        nuevaPF.IDFAMILIA = relacion.CodigoFamilia;
                        nuevaPF.IDPERSONA = relacion.CodigoPersona;
                        PERIODO_PERSONA_FAMILIA nuevaPPF = new PERIODO_PERSONA_FAMILIA();
                        nuevaPPF.IDPERSONA = relacion.CodigoPersona;
                        nuevaPPF.IDFAMILIA = relacion.CodigoFamilia;
                        nuevaPPF.IDPARENTEZCO = relacion.CodigoParentezco;
                        nuevaPPF.IDPERIODO = nuevoPeriodo.IDPERIODO;
                        nuevaPPF.IDREPRESENTANTE = objRepresentante.IDPERSONA;
                        if (relacion.CodigoPersona == objRepresentante.IDPERSONA)
                        {
                            nuevaPPF.REPRESENTANTE = true;
                        }
                        else {
                            nuevaPPF.REPRESENTANTE = false;
                        } 
                        if(!bd.PERSONA_FAMILIA.Any(p => p.IDFAMILIA == nuevaPF.IDFAMILIA && p.IDPERSONA == nuevaPF.IDPERSONA))
                        {
                            bd.PERSONA_FAMILIA.InsertOnSubmit(nuevaPF);
                            bd.PERIODO_PERSONA_FAMILIA.InsertOnSubmit(nuevaPPF);
                        }
                        
                        

                        bool esMenor = bd.MENOREDAD.Any(men => men.IDPERSONA == relacion.CodigoPersona);
                        if (esMenor)
                        {
                            MENOREDAD menor = bd.MENOREDAD.Where(men => men.IDPERSONA == relacion.CodigoPersona).First();
                            menor.IDREPRESENTANTE = bd.REPRESENTANTE.Where(rep => rep.IDPERSONA == objRepresentante.IDPERSONA).First().IDREPRESENTANTE;
                        }
                    }
                    bd.SubmitChanges();
                    trans.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modificarMiembrosFamilia(List<clsasignarfamilia> nuevaLista, clsRepresentante objRepresentante)
        {
            nuevaLista = nuevaLista.Distinct().ToList();
            try
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    bool existe = bd.REPRESENTANTE.Any(r => r.IDPERSONA == objRepresentante.IDPERSONA);
                    if (!existe)
                    {
                        REPRESENTANTE nuevoRep = new REPRESENTANTE();
                        nuevoRep.IDPERSONA = objRepresentante.IDPERSONA;
                        bd.REPRESENTANTE.InsertOnSubmit(nuevoRep);
                        bd.SubmitChanges();
                    }
                    PERIODO anterior = bd.PERIODO_PERSONA_FAMILIA.Where(ppf => ppf.IDFAMILIA == nuevaLista.First().CodigoFamilia && ppf.PERIODO.ESTADOPERIODO==true && ppf.PERIODO.IDTIPOPERIODO==2).Select(ppf => ppf.PERIODO).First();
                    anterior.FECHAFINPERIODO = DateTime.Now;
                    anterior.ESTADOPERIODO = false;
                    bd.SubmitChanges();

                    PERIODO nuevoPeriodo = new PERIODO();
                    nuevoPeriodo.ESTADOPERIODO = true;
                    nuevoPeriodo.IDTIPOPERIODO = 2;
                    nuevoPeriodo.FECHAINICIOPERIODO = DateTime.Now;
                    nuevoPeriodo.NOMBREPERIODO = nuevaLista.Select(n => n.NombreFamilia).First().ToUpper()+" - " +nuevoPeriodo.FECHAINICIOPERIODO.ToString().ToUpper();
                    bd.PERIODO.InsertOnSubmit(nuevoPeriodo);
                    bd.SubmitChanges();

                    foreach (clsasignarfamilia relacion in nuevaLista)
                    {
                        
                        if(!bd.PERSONA_FAMILIA.Any(pf => pf.IDPERSONA == relacion.CodigoPersona && pf.IDFAMILIA == relacion.CodigoFamilia))
                        {
                            PERSONA_FAMILIA nuevaPF = new PERSONA_FAMILIA();
                            nuevaPF.IDFAMILIA = relacion.CodigoFamilia;
                            nuevaPF.IDPERSONA = relacion.CodigoPersona;
                            bd.PERSONA_FAMILIA.InsertOnSubmit(nuevaPF);
                        }

                        PERIODO_PERSONA_FAMILIA nuevaPPF = new PERIODO_PERSONA_FAMILIA();
                        nuevaPPF.IDPERSONA = relacion.CodigoPersona;
                        nuevaPPF.IDFAMILIA = relacion.CodigoFamilia;
                        nuevaPPF.IDPARENTEZCO = relacion.CodigoParentezco;
                        nuevaPPF.IDPERIODO = nuevoPeriodo.IDPERIODO;
                        if (relacion.CodigoPersona == objRepresentante.IDPERSONA)
                        {
                            nuevaPPF.REPRESENTANTE = true;
                        }
                        else
                        {
                            nuevaPPF.REPRESENTANTE = false;
                        }
                        if (!bd.PERIODO_PERSONA_FAMILIA.Any(p => p.IDFAMILIA == nuevaPPF.IDFAMILIA && p.IDPERSONA == nuevaPPF.IDPERSONA && p.IDPERIODO == nuevaPPF.IDPERIODO))
                        {
                            bd.PERIODO_PERSONA_FAMILIA.InsertOnSubmit(nuevaPPF);
                        }
                        

                        bool esMenor = bd.MENOREDAD.Any(men => men.IDPERSONA == relacion.CodigoPersona);
                        if (esMenor)
                        {
                            MENOREDAD menor = bd.MENOREDAD.Where(men => men.IDPERSONA == relacion.CodigoPersona).First();
                            menor.IDREPRESENTANTE = bd.REPRESENTANTE.Where(rep=> rep.IDPERSONA == objRepresentante.IDPERSONA).First().IDREPRESENTANTE;
                        }
                    }
                    bd.SubmitChanges();
                    trans.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ingresaDatosPersonaFamilia(int CodigoFamilia, string PrimerNombre, string SegundoNombre, string PrimerApellido, string SegundoApellido)
        {
            try
            {
                clsConexion.abrirConexion();

                string sql = "Insert into persona_familia values(@codigofamilia,select idpersona from PERSONA where PRIMERNOMBREPERSONA=@primernombre AND SEGUNDONOMBREPERSONA=@segundonombre AND PRIMERAPELLIDOPERSONA=@primerapellido AND SEGUNDOAPELLIDOPERSONA=@segundoapellido)";

                SqlCommand comando = new SqlCommand(sql, clsConexion.conexion);

                comando.Parameters.Add("@codigofamilia", SqlDbType.Int, 4, "IDFAMILIA").Value = CodigoFamilia;
                comando.Parameters.Add("@primernombre", SqlDbType.VarChar, 50, "PRIMERNOMBREPERSONA").Value = PrimerNombre;
                comando.Parameters.Add("@segundonombre", SqlDbType.VarChar, 50, "SEGUNDONOMBREPERSONA").Value = SegundoNombre;
                comando.Parameters.Add("@primerapellido", SqlDbType.VarChar, 50, "PRIMERAPELLIDOPERSONA").Value = PrimerApellido;
                comando.Parameters.Add("@primerapellido", SqlDbType.VarChar, 50, "SEGUNNDOAPELLIDOPERSONA").Value = SegundoApellido;
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



        public bool ingresaFamilia(clsNFamilia familia)
        {

            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    FAMILIA f = new FAMILIA();
                    f.NOMBREFAMILIA = familia.NOMBREFAMILIA;
                    f.OBSERVACIONFAMILIA = familia.OBSERVACIONFAMILIA;
                    f.DIRECCIONFAMILIA = familia.DIRECCIONFAMILIA;
                    f.ANIOINGRESOFAMILIA = DateTime.Now;
                    f.MIEMBROSFAMILIA = familia.MIEMBROSFAMILIA;
                    bd.FAMILIA.InsertOnSubmit(f);
                    bd.SubmitChanges();
                    trans.Complete();
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
}
