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
    public partial class frmManejoPreguntas : System.Web.UI.Page
    {
        clsNPregunta nuevaPregunta = new clsNPregunta();
        clsDPregunta objDPregunta = new clsDPregunta();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtNombrePregunta.Text.Trim().Length != 0)
            {
                nuevaPregunta.NOMBREPREGUNTA = txtNombrePregunta.Text;
                nuevaPregunta.IDTIPOPREGUNTA = int.Parse(ddlTipoPregunta.SelectedValue);
                nuevaPregunta.ESTADOPREGUNTA = true;

                if (objDPregunta.D_ingresarPregunta(nuevaPregunta))
                {
                    Response.Write(@"<script>alert('Se ha ingresado correctamente la pregunta');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Algo ha sido mal! Por favor, verifica la información ingresada');</script>");
                }
            }
            else
            {
                MsgBox("Ingrese un nombre para la pregunta", this.Page, this);
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