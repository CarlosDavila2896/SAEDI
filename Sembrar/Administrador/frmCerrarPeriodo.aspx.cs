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
            if (IsPostBack)
            {
                cargarDatos();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(ddlPeriodo.SelectedValue.ToString(), out id);
            if (id != 0)
            {
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
            else
            {
                Response.Write("<script>window.alert('Seleccione un proceso');</script>");
            }
        }

        protected void chbHoy_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            int id;
            int.TryParse(ddlPeriodo.SelectedValue.ToString(), out id);
            if (id!=0)
            {
                lblNombre.Text = objDPeriodo.cargarNombre(id);
                lblFechaInicio.Text = objDPeriodo.cargarFechaInicio(id).ToShortDateString();
                DateTime sinFecha = new DateTime();
                DateTime fecha = objDPeriodo.cargarFechaFin(id);
                if (sinFecha == fecha)
                    lblFechaFin.Text = "--";
                else
                    lblFechaFin.Text = fecha.ToShortDateString(); 
            }
        }
    }
}