using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmReporteAsistenciaPorPersona : System.Web.UI.Page
    {
        clsDProceso objProceso = new clsDProceso();
        clsDatosAsistencia objAsistencia = new clsDatosAsistencia();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;

            int idOrientador = (int)Session["id"];
            try
            {
                if (!IsPostBack)
                {
                    

                    cargarProceso();
                    for (int i = 2016; i <= int.Parse(DateTime.Now.ToString("yyyy")); i++)
                    {
                        ListItem li = new ListItem();
                        li.Text = i.ToString();
                        li.Value = i.ToString();
                        ddlAnio.Items.Add(li);
                    }
                    cargarPersonas();
                }
                else
                {

                    ReportDocument crystalrpt = new ReportDocument();
                    crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaReunionPorPersonaOrientador.rpt"));
                    crystalrpt.Refresh();
                    crystalrpt.SetParameterValue("@Persona", ddlPersona.SelectedValue);
                    crystalrpt.SetParameterValue("@IdOrientador", idOrientador);
                    crystalrpt.SetParameterValue("@Mes", ddlMes.SelectedValue);
                    crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
                    crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
                    //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                    CrystalReportViewer1.ReportSource = crystalrpt;
                    CrystalReportViewer1.DataBind();
                }
            }
            catch { }
        }
        public void cargarPersonas()
        {
            int idOrientador = (int)Session["id"];
            ddlPersona.DataSource = objAsistencia.D_consultarPersonasPorOrientador(idOrientador, int.Parse(ddlTipo.SelectedValue));
            ddlPersona.DataTextField = "Nombre";
            ddlPersona.DataValueField = "IdPersona";
            ddlPersona.DataBind();
        }
        private void cargarProceso()
        {
            int idOrientador = (int)Session["id"];
            ddlProceso.DataSource = objProceso.D_consultarProcesoPorOrientador(idOrientador);
            ddlProceso.DataValueField = "IdProceso";
            ddlProceso.DataTextField = "Nombre";
            ddlProceso.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int idOrientador = (int)Session["id"];
            try
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaReunionPorPersonaOrientador.rpt"));
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@Persona", ddlPersona.SelectedValue);
                crystalrpt.SetParameterValue("@IdOrientador", idOrientador);
                crystalrpt.SetParameterValue("@Mes", ddlMes.SelectedValue);
                crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
                crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
                //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
            catch { }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargarPersonas();
            }
            catch {

            }
        }
    }
}