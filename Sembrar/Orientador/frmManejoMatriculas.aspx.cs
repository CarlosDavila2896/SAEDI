using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Orientador
{
    public partial class frmManejoMatriculas : System.Web.UI.Page
    {
        clsNMatricula nuevaMatricula = new clsNMatricula();
        clsDMatriculas objDMatriculas = new clsDMatriculas();
        protected void Page_Load(object sender, EventArgs e)
        {

            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            nuevaMatricula.IDLINEADEACCION = int.Parse(ddlLineaAccion.SelectedValue);
            nuevaMatricula.IDPROCESO = int.Parse(ddlProceso.SelectedValue);
            nuevaMatricula.IDORIENTADOR = (int)Session["id"];
            nuevaMatricula.IDPERIODO = int.Parse(ddlPeriodo.SelectedValue);
            nuevaMatricula.IDPERSONA = int.Parse(lstIndividuos.SelectedValue);
            if (!objDMatriculas.ingresarMatricula(nuevaMatricula))
            {
                Response.Write("<script>window.alert('El menor de edad ya se encuentra matriculado en ese proceso en este periodo.');</script>");
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
            e.Row.Cells[1].Visible = false;
        }

        protected void gvMatriculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            objDMatriculas.eliminarMatricula(Convert.ToInt32(gvMatriculas.DataKeys[gvMatriculas.SelectedRow.RowIndex].Value));
        }
    }
}