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
    public partial class frmManejoLineasAccion : System.Web.UI.Page
    {
        clsNLineaAccion nuevaLineaAccion = new clsNLineaAccion();
        clsDLineaAccion objDLineaAccion = new clsDLineaAccion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtNombreLineaAccion.Text.Trim().Length != 0)
            {
                nuevaLineaAccion.NOMBRELINEAACCION = txtNombreLineaAccion.Text;
                nuevaLineaAccion.IDTIPOPERSONA = int.Parse(ddlTipoPersona.SelectedValue);
                nuevaLineaAccion.DESCRIPCIONLINEAACCION = txtDescripcion.Text;

                if (objDLineaAccion.D_ingresarLineadeAccion(nuevaLineaAccion))
                {
                    Response.Write(@"<script>alert('Se ha ingresado correctamente la línea de acción');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Algo ha sido mal! Por favor, verifica la información ingresada');</script>");
                }
            }
            else
            {
                MsgBox("Ingrese un nombre para la linea de acción", this.Page, this);
            }
        }


        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}