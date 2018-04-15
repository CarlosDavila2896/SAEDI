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
            e.Row.Cells[1].Visible = false;
        }

        protected void gvMatriculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            objDMatriculas.eliminarMatricula(Convert.ToInt32(gvMatriculas.DataKeys[gvMatriculas.SelectedRow.RowIndex].Value));
            DataBind();
        }
    }
}