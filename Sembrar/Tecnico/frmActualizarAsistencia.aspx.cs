using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;


namespace Sembrar.Tecnico
{
    public partial class ActualizarAsistencia : System.Web.UI.Page
    {
        clsDatosJovenes objJovenes = new clsDatosJovenes();
        clsDatosReunion objReunion = new clsDatosReunion();
        List<clsJoven> listaJovenes = new List<clsJoven>();
        clsAsistencia objAsistencia = new clsAsistencia();
        clsDFamilia objFamilia = new clsDFamilia();
        clsDOrientador objDOrientador = new clsDOrientador();
        clsDatosJovenes objDatosJoven = new clsDatosJovenes();
        clsDatosAsistencia objDatosAsistencia = new clsDatosAsistencia();
        private ArrayList asisCreada = new ArrayList();  // guardo los jovenes que vienen de la base de datos
        private ArrayList asisActuali = new ArrayList();  // guardo los jovenes que se van a guardar en la BD
        private List<clsAsistencia> listaFechas = new List<clsAsistencia>();
        List<clsAsistencia> listaReunion = new List<clsAsistencia>();
        List<clsJoven> listaJoven = new List<clsJoven>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    cargarFecha();
                    cargarTema(DateTime.Parse(ddlFecha.Text));
                }
                catch { }
            }

        }


        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow gvr in grvAsistencia2.Rows)
            {
                DropDownList ddlAsisencia = (DropDownList)(gvr.FindControl("ddlAsistencia"));

                if (objDatosAsistencia.ActualizarDatosAsistencia(int.Parse(ddlTema.SelectedValue), int.Parse(gvr.Cells[4].Text), int.Parse(ddlAsisencia.SelectedValue)))
                {
                    string script = "alert(\"Datos actualizados con éxito!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                }
                else
                {
                    string script = "alert(\"Datos actualizados sin éxito!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                }


            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "DoPostBack", "__doPostBack(sender, e)", true);
            cargarFecha();
            cargarTema(DateTime.Parse(ddlFecha.Text));
            grvAsistencia2.DataSource = null;
            grvAsistencia2.DataBind();
        }

        protected void ddlOrientador2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargarTema(DateTime.Parse(ddlFecha.Text));
            }
            catch
            {

            }
        }
        private void cargarTema(DateTime fecha)
        {
            ddlTema.DataSource = objReunion.consultaReunionesPorFecha(fecha);
            ddlTema.DataValueField = "IDREUNION";
            ddlTema.DataTextField = "TEMAREUNION";
            ddlTema.DataBind();
        }

        protected void ObjectDataSourceFecha_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }
        private void cargarGridView() {
            try
            {
                grvAsistencia2.DataSource = objDatosAsistencia.consultaAsistentes(int.Parse(ddlTema.SelectedValue.ToString()));
                grvAsistencia2.DataBind();
                foreach (GridViewRow gvr in grvAsistencia2.Rows)
                {
                    DropDownList ddlAsisencia = (DropDownList)(gvr.FindControl("ddlAsistencia"));
                    ddlAsisencia.SelectedIndex = ddlAsisencia.Items.IndexOf(ddlAsisencia.Items.FindByText(objDatosAsistencia.consultaAsistencia(int.Parse(gvr.Cells[4].Text), int.Parse(ddlTema.SelectedValue))));
                }
            }
            catch { }
        }
        private void cargarFecha()
        {
            ddlFecha.DataSource = objReunion.consultaReunionesFechas();
            ddlFecha.DataTextField = "FECHA";
            ddlFecha.DataBind();
        }
        protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cargarGridView();
        }
    
    }
}