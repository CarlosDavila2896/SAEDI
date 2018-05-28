using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDTipoPersona
    {
        static clsNTipoPersona transformar(TIPOPERSONA newPersona)
        {
            clsNTipoPersona persona = new clsNTipoPersona();
            persona.EDADMAXIMA = int.Parse(newPersona.EDADMAXIMA.ToString());
            persona.EDADMINIMA = int.Parse(newPersona.EDADMINIMA.ToString());
            persona.IDTIPOPERSONA = newPersona.IDTIPOPERSONA;
            persona.NOMBRETIPOPERSONA = newPersona.NOMBRETIPOPERSONA;
        }
        //Metodo de creacion de nuevo tipo persona
        public bool D_ingresarTipoPersona(clsNTipoPersona nuevoTipoPersona)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    TIPOPERSONA tipopersona = new TIPOPERSONA();
                    tipopersona.NOMBRETIPOPERSONA = nuevoTipoPersona.NOMBRETIPOPERSONA;                    
                    tipopersona.EDADMINIMA = nuevoTipoPersona.EDADMINIMA;
                    if (nuevoTipoPersona.EDADMAXIMA == 0) { tipopersona.EDADMAXIMA = null; } else { tipopersona.EDADMAXIMA = nuevoTipoPersona.EDADMAXIMA; } 
                    db.TIPOPERSONA.InsertOnSubmit(tipopersona);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de consulta de tipos de personas
        public List<TIPOPERSONA> D_consultarTipoPersona()
        {
            using (MERSembrarDataContext db = new MERSembrarDataContext())
            {
                return db.TIPOPERSONA.ToList();
            }
        }

        //Metodo de eliminacion de tipos de personas
        public bool D_eliminarTiposPersonas(TIPOPERSONA eliminarTipoPersona)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    TIPOPERSONA tipopersona = (from tp in db.TIPOPERSONA where tp.IDTIPOPERSONA == eliminarTipoPersona.IDTIPOPERSONA select tp).First();
                    db.TIPOPERSONA.DeleteOnSubmit(tipopersona);
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Metodo de edicion de tipos de personas
        public bool D_editarTipoPersona(TIPOPERSONA editarTipoPersona)
        {
            try
            {
                using (MERSembrarDataContext db = new MERSembrarDataContext())
                {
                    TIPOPERSONA tipopersona = db.TIPOPERSONA.Single(u => u.IDTIPOPERSONA == editarTipoPersona.IDTIPOPERSONA);
                    tipopersona.NOMBRETIPOPERSONA = editarTipoPersona.NOMBRETIPOPERSONA;
                    tipopersona.EDADMINIMA = editarTipoPersona.EDADMINIMA;
                    tipopersona.EDADMAXIMA = editarTipoPersona.EDADMAXIMA;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
