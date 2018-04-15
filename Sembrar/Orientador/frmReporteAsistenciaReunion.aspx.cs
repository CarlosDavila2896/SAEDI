using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;
using CrystalDecisions.CrystalReports.Engine;
namespace Sembrar.Orientador
{
    public partial class frmReporteAsistenciaReunion : System.Web.UI.Page
    {
        clsDatosReunion objReunion = new clsDatosReunion();
        protected void Page_Load(object sender, EventArgs e)
        {

            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;

            int idOrientador = (int)Session["id"];
            if (!Page.IsPostBack)
            {

                

                try
                {
                    cargarFecha();
                    cargarTema(DateTime.Parse(ddlFecha.Text));
                }
                catch { }
            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaReunion.rpt"));
                //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdReunion", ddlTema.SelectedValue);
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int idOrientador = (int)Session["id"];
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaReunion.rpt"));
            //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@IdReunion", ddlTema.SelectedValue);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }

        protected void ddlFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idOrientador = (int)Session["id"];
            cargarTema(DateTime.Parse(ddlFecha.Text));
        }
        private void cargarFecha()
        {
            int idOrientador = (int)Session["id"];
            ddlFecha.DataSource = objReunion.consultaReunionesFechasPorOrientador(idOrientador);
            ddlFecha.DataTextField = "FECHA";
            ddlFecha.DataBind();
        }
        private void cargarTema(DateTime fecha)
        {
            int idOrientador = (int)Session["id"];
            ddlTema.DataSource = objReunion.consultaReunionesPorFechaYOrientador(fecha, idOrientador);
            ddlTema.DataValueField = "IDREUNION";
            ddlTema.DataTextField = "TEMAREUNION";
            ddlTema.DataBind();
        }
    }
}