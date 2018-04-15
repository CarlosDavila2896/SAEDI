using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Tecnico
{
    public partial class frmManejoProcesos : System.Web.UI.Page
    {
        clsDProceso objDProceso = new clsDProceso();
        clsNProceso nuevoProceso = new clsNProceso();
        clsNRelacionPR_LA_ORI nuevaRelacion = new clsNRelacionPR_LA_ORI();
        clsDRelacionPR_LA_ORI objDRelacion = new clsDRelacionPR_LA_ORI();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        //Leer variables
        private void leerVariables()
        {
            if (lstLineasAccion.SelectedIndex >= 0)
            {
                nuevaRelacion.IDLINEADEACCION = int.Parse(lstLineasAccion.SelectedValue);
            }
            if (lstProcesos.SelectedIndex >= 0)
            {
                nuevaRelacion.IDPROCESO = int.Parse(lstProcesos.SelectedValue);
            }
            if (lstOrientador.SelectedIndex >= 0)
            {
                nuevaRelacion.IDORIENTADOR = int.Parse(lstOrientador.SelectedValue);
            }
            if (lstPeriodo.SelectedIndex >= 0)
            {
                nuevaRelacion.IDPERIODO = int.Parse(lstPeriodo.SelectedValue);
            }
        }


        protected void lstOrientador_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvRelaciones.DataBind();
        }

        protected void lstProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvRelaciones.DataBind();
        }

        protected void lstLineasAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvRelaciones.DataBind();
        }
    }
}