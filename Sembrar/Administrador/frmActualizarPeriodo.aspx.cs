using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Sembrar.Administrador
{
    public partial class frmActualizarPeriodo : System.Web.UI.Page
    {
        int count = 0;
        clsDPeriodo objPeriodo = new clsDPeriodo();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch
            {

            }
            if (!IsPostBack)
            {
                cargarPeriodo();
                cargarFecha();
            }
        }
        private void cargarPeriodo()
        {
            try
            {
                ddlPeriodo.DataSource = objPeriodo.consultaPeriodosActualizar();
                ddlPeriodo.DataValueField = "ID";
                ddlPeriodo.DataTextField = "NOMBRE";
                ddlPeriodo.DataBind();
            }
            catch
            {

            }
        }
        private void cargarFecha()
        {
            try
            {
                txtNombre.Text = objPeriodo.cargarNombre(int.Parse(ddlPeriodo.SelectedValue.ToString()));
                txtFechaInicio.Text = objPeriodo.cargarFechaInicio(int.Parse(ddlPeriodo.SelectedValue.ToString())).ToString("yyyy-MM-dd");
                
                if (!objPeriodo.cargarFechaFin(int.Parse(ddlPeriodo.SelectedValue.ToString())).ToString("yyyy-MM-dd").Equals("1/1/0001"))
                {
                    txtFechaFin.Text = objPeriodo.cargarFechaFin(int.Parse(ddlPeriodo.SelectedValue.ToString())).ToString("yyyy-MM-dd");
                }
                else
                {
                    txtFechaFin.Text = String.Empty;
                }
            }
            catch
            {
                
            }
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargarFecha();
            }
            catch
            {

            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                bool resultado = objPeriodo.actualizarPeriodo(int.Parse(ddlPeriodo.SelectedValue), txtNombre.Text, DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFin.Text));

                if (resultado)
                {
                    string script = "alert(\"Datos actualizados con éxito!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                }
                else
                {
                    string script = "alert(\"Porfavor verifica, algo ha salido mal!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
            }
            catch (Exception)
            {
                string script = "alert(\"Porfavor verifica, algo ha salido mal!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}