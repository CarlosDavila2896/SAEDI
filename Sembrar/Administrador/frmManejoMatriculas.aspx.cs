using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Administrador
{
    public partial class frmManejoMatriculas : System.Web.UI.Page
    {
        clsNMatricula nuevaMatricula = new clsNMatricula();
        clsDMatriculas objDMatriculas = new clsDMatriculas();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            nuevaMatricula.IDLINEADEACCION = int.Parse(ddlLineaAccion.SelectedValue);
            nuevaMatricula.IDPROCESO = int.Parse(ddlProceso.SelectedValue);
            nuevaMatricula.IDORIENTADOR = int.Parse(ddlOrientador.SelectedValue);
            nuevaMatricula.IDPERIODO = int.Parse(ddlPeriodo.SelectedValue);
            nuevaMatricula.IDPERSONA = int.Parse(lstIndividuos.SelectedValue);
            objDMatriculas.ingresarMatricula(nuevaMatricula);
            gvMatriculas.DataBind();
        }

        protected void ddlLineaAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMatriculas.DataBind();
        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMatriculas.DataBind();
        }

        protected void ddlOrientador_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMatriculas.DataBind();
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMatriculas.DataBind();
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
            gvMatriculas.DataBind();
        }
    }
}