using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos
{
    public class clsDParentezco
    {

        static clsParentesco transformar(PARENTEZCO newParentesco)
        {
            clsParentesco parentesco = new clsParentesco();
            parentesco.Codigo = newParentesco.IDPARENTEZCO;
            parentesco.NombreParentesco = newParentesco.NOMBREPARENTEZCO;
            return parentesco;
        }

        MERSembrarDataContext bd = new MERSembrarDataContext();
        public List<PARENTEZCO> consultarParentezcos()
        {
            try
            {
                return bd.PARENTEZCO.ToList().OrderBy(a => a.NOMBREPARENTEZCO).ToList();

            }
            catch (Exception ex)
            {
                return new List<PARENTEZCO>();
            }
        }
    }
}
