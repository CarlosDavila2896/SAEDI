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
    public partial class frmManejoProcesos : System.Web.UI.Page
    {
        clsDProceso objDProceso = new clsDProceso();
        clsNProceso nuevoProceso = new clsNProceso();
        clsNRelacionPR_LA_ORI nuevaRelacion = new clsNRelacionPR_LA_ORI();
        clsDRelacionPR_LA_ORI objDRelacion = new clsDRelacionPR_LA_ORI();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtNombreProceso.Text.Trim().Length != 0)
            {
                nuevoProceso.NOMBREPROCESO = txtNombreProceso.Text;
                nuevoProceso.ESTADO = true;

                if (objDProceso.D_ingresarProceso(nuevoProceso))
                {
                    Response.Write(@"<script>alert('Se ha ingresado correctamente el proceso');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Algo ha sido mal! Por favor, verifica la información ingresada');</script>");
                }
            }
            else
            {
                MsgBox("Ingrese un nombre para el proceso", this.Page, this);
            }
            
        }

        protected void btnIngresarRelacion_Click(object sender, EventArgs e)
        {
            leerVariables();

            objDRelacion.D_ingresarRelacionLA_PR_OR_PER(nuevaRelacion);

            gvRelaciones.DataBind();
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

            nuevaRelacion.OBSERVACIONRELACION = txtObservacion.Text;
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

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}