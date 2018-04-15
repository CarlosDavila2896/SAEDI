using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Sembrar.Administrador
{
    public partial class ActualizarReunion : System.Web.UI.Page
    {
       
        clsDatosReunion objReunion = new clsDatosReunion();
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
                cargarReunion();
                cargarFecha();
            }
        }

        private void cargarReunion() {
            try
            {
                ddlReunion.DataSource = objReunion.consultaReunionesActualizar();
                ddlReunion.DataValueField = "ID";
                ddlReunion.DataTextField = "TEMA";
                ddlReunion.DataBind();
            }
            catch
            {

            }
            
           
        }

        private void cargarFecha() {
            try
            {
                txtHora.Text = objReunion.cargarHora(int.Parse(ddlReunion.SelectedValue.ToString()));
                txtFecha.Text = objReunion.cargarFecha(int.Parse(ddlReunion.SelectedValue.ToString())).ToString("yyyy-MM-dd");
                txtTema.Text = objReunion.cargarTema(int.Parse(ddlReunion.SelectedValue.ToString()));
            }
            catch
            {

            }
        }

        protected void ddlReunion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtHora.Text = objReunion.cargarHora(int.Parse(ddlReunion.SelectedValue.ToString()));
                txtFecha.Text = objReunion.cargarFecha(int.Parse(ddlReunion.SelectedValue.ToString())).ToString("yyyy-MM-dd");
                txtTema.Text = objReunion.cargarTema(int.Parse(ddlReunion.SelectedValue.ToString()));
                cargarFecha();
            }
            catch
            {

            }
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if ((DateTime.Parse(txtFecha.Text).AddDays(1)) >= DateTime.Now)
            {
                try
                {
                    bool resultado = objReunion.actualizarReunion(int.Parse(ddlReunion.SelectedValue), txtTema.Text, DateTime.Parse(txtFecha.Text), TimeSpan.Parse(txtHora.Text));

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
            else
            {
                Response.Write("<script>window.alert('La fecha de la reunion no puede ser anterior a la fecha actual');</script>");
            }
            
         
            
        }
         
    }
}