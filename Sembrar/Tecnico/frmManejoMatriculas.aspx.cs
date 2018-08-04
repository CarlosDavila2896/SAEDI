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
    public partial class frmManejoMatriculas : System.Web.UI.Page
    {
        clsNMatricula nuevaMatricula = new clsNMatricula();
        clsDMatriculas objDMatriculas = new clsDMatriculas();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnIngresar);
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            nuevaMatricula.IDLINEADEACCION = int.Parse(ddlLineaAccion.SelectedValue);
            nuevaMatricula.IDPROCESO = int.Parse(ddlProceso.SelectedValue);
            nuevaMatricula.IDORIENTADOR = int.Parse(ddlOrientador.SelectedValue);
            nuevaMatricula.IDPERIODO = int.Parse(ddlPeriodo.SelectedValue);
            nuevaMatricula.IDPERSONA = int.Parse(lstIndividuos.SelectedValue);
            if (!objDMatriculas.ingresarMatricula(nuevaMatricula))
            {
                Response.Write(@"<script>window.alert('La persona ya se encuentra matriculada en ese proceso en este periodo.');</script>");
            }
        }

        protected void ddlLineaAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlOrientador_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvMatriculas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[1].Visible = false;
            }
            catch
            {

            }
        }

        protected void gvMatriculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            objDMatriculas.eliminarMatricula(Convert.ToInt32(gvMatriculas.DataKeys[gvMatriculas.SelectedRow.RowIndex].Value));
        }
    }
}