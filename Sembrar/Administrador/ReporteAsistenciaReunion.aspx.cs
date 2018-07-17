using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;
using CrystalDecisions.CrystalReports.Engine;
namespace Sembrar.Administrador
{
    public partial class ReporteAsistenciaReunion1 : System.Web.UI.Page
    {
        clsDatosReunion objReunion = new clsDatosReunion();
        string path = "";
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
            else {
                ReportDocument crystalrpt = new ReportDocument();
                path = Server.MapPath("");
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/ReporteAsistenciaReunion.rpt"));
                //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                crystalrpt.Refresh();
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
        }

        private void cargarFecha()
        {
            ddlFecha.DataSource = objReunion.consultaReunionesFechas();
            ddlFecha.DataTextField = "FECHA";
            ddlFecha.DataBind();
        }
        private void cargarTema(DateTime fecha)
        {
            ddlTema.DataSource = objReunion.consultaReunionesPorFecha(fecha);
            ddlTema.DataValueField = "IDREUNION";
            ddlTema.DataTextField = "TEMAREUNION";
            ddlTema.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportDocument crystalrpt = new ReportDocument();
            path = Server.MapPath("");
            crystalrpt.Load(path + "\\ReporteAsistenciaReunion.rpt");
            //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@IdReunion", ddlTema.SelectedValue);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }

        protected void ddlFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTema(DateTime.Parse(ddlFecha.Text));
        }

        protected void ddlOrientador2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}