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
    public partial class frmCerrarPeriodo : System.Web.UI.Page
    {
        clsDPeriodo objDPeriodo = new clsDPeriodo();
        clsNPeriodo objPeriodo = new clsNPeriodo();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(ddlPeriodo.SelectedValue.ToString(), out id);
            objPeriodo.IDPeriodo = id;
            if (objDPeriodo.cerrarPeriodo(objPeriodo))
            {
                Response.Write(@"<script>alert('RESULTADO CIERRE PERIODO: CORRECTO');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
            }
            else
            {
                Response.Write("<script>window.alert('Error en el proceso');</script>");
            }
        }

        protected void chbHoy_CheckedChanged(object sender, EventArgs e)
        { 
        }
    }
}