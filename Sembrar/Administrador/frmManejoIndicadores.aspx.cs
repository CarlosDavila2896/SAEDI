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
    public partial class frmManejoIndicadores : System.Web.UI.Page
    {
        clsNIndicador nuevoIndicador = new clsNIndicador();
        clsDIndicador objDIndicador = new clsDIndicador();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            if (txtNombreIndicador.Text.Trim().Length != 0)
            {
                nuevoIndicador.NOMBREINDICADOR = txtNombreIndicador.Text;
                nuevoIndicador.ESTADOINDICADOR = true;

                if (objDIndicador.D_ingresarIndicador(nuevoIndicador))
                {
                    Response.Write(@"<script>alert('Se ha ingresado correctamente el indicador');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Algo ha sido mal! Por favor, verifica la información ingresada');</script>");
                }
            }
            else
            {
                MsgBox("Ingrese un nombre para el indicador", this.Page, this);
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