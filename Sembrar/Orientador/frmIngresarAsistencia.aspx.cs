using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Orientador
{
    public partial class CrearAsistencia : System.Web.UI.Page
    {
        clsDatosPersona objPersona = new clsDatosPersona();
        clsDatosReunion objReunion = new clsDatosReunion();
        clsAsistencia objAsistencia = new clsAsistencia();
        clsDOrientador objDOrientador = new clsDOrientador();
        clsDatosJovenes objDatosJoven = new clsDatosJovenes();
        clsDatosAsistencia objDatosAsistencia = new clsDatosAsistencia();
        List<clsAsistencia> listaReunion = new List<clsAsistencia>();
        List<clsJoven> listaJoven = new List<clsJoven>();
        clsDFamilia objFamilia = new clsDFamilia();
        List<clsReunion> listaFechas = new List<clsReunion>();
        protected void Page_Load(object sender, EventArgs e)
        {

            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;

            lblFecha.Text = DateTime.Now.ToString("yyyy/MM/dd");
            if (!Page.IsPostBack)
            {
                

                cargarReuniones();

            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow gvr in grvJovenes.Rows)
            {
                DropDownList ddlAsisencia = (DropDownList)(gvr.FindControl("ddlAsistencia"));
                if (objReunion.D_modificaEstadoReunion(int.Parse(ddlReunion.SelectedValue)) && objDatosAsistencia.IngresoDatosAsistencia(int.Parse(ddlReunion.SelectedValue), int.Parse(ddlAsisencia.SelectedValue),int.Parse(gvr.Cells[4].Text)))
                {
                    string script = "alert(\"Datos ingresados con éxito!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else
                {
                    string script = "alert(\"Datos ingresados sin éxito!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                }

            }
            ddlReunion.Items.Clear();
            cargarReuniones();           
            grvJovenes.DataSource = null;
            grvJovenes.DataBind();
        }

        protected void ddlOrientador_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSourceOrientador_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        private void cargarReuniones()
        {
            int idOrientador = (int)Session["id"];
            ddlReunion.DataSource = objReunion.consultaReunionesHorasOrientdor(lblFecha.Text, idOrientador);
            ddlReunion.DataValueField = "IDREUNION";
            ddlReunion.DataTextField = "TEMAREUNION";
            ddlReunion.DataBind();
        }

        protected void ddlFecha8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                grvJovenes.DataSource = objFamilia.consultaPersonasAsistentes(int.Parse(ddlReunion.SelectedValue.ToString()));
                grvJovenes.DataBind();
            }
            catch
            {

            }
        }

    }
}