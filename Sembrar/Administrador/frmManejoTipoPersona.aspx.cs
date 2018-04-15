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
    public partial class frmManejoTipoPersona : System.Web.UI.Page
    {
        clsNTipoPersona nuevoTipoPersona = new clsNTipoPersona();
        clsDTipoPersona objDTipoPersona = new clsDTipoPersona();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreTipoPersona.Text.Trim().Length != 0)
                {
                    nuevoTipoPersona.NOMBRETIPOPERSONA = txtNombreTipoPersona.Text;
                    if (txtEdadMinima.Text.Trim().Length != 0) { nuevoTipoPersona.EDADMINIMA = int.Parse(txtEdadMinima.Text); }
                    if (txtEdadMaxima.Text.Trim().Length != 0) { nuevoTipoPersona.EDADMAXIMA = int.Parse(txtEdadMaxima.Text); }


                    if (objDTipoPersona.D_ingresarTipoPersona(nuevoTipoPersona))
                    {
                        Response.Write(@"<script>alert('Se ha ingresado correctamente el tipo de persona');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('Algo ha sido mal! Por favor, verifica la información ingresada');</script>");
                    }
                }
                else
                {
                    MsgBox("Ingrese un nombre al tipo de persona", this.Page, this);
                }
            }
            catch
            {
                MsgBox("Compruebe los datos ingresados", this.Page, this);
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