using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.Web.Services;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
namespace Sembrar.Administrador
{
    public partial class Reporte9 : System.Web.UI.Page
    {
        string path = "";
        clsDOrientador objOrientador = new clsDOrientador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlOrientador.DataSource = objOrientador.D_consultarOrientadores();
                ddlOrientador.DataTextField = "NOMBREORIENTADOR";
                ddlOrientador.DataValueField = "IDORIENTADOR";
                ddlOrientador.DataBind();
                ddlRepresentante.DataSource = objOrientador.D_consultarRepresentantesporOrientador(int.Parse(ddlOrientador.SelectedValue));
                ddlRepresentante.DataTextField = "nombre";
                ddlRepresentante.DataValueField = "id";
                ddlRepresentante.DataBind();
            }
            else
            {
                if ((int.Parse(ddlAnio.SelectedValue) > int.Parse(ddlAnio2.SelectedValue)) || ((int.Parse(ddlAnio.SelectedValue) == int.Parse(ddlAnio2.SelectedValue)) && int.Parse(ddlMes.SelectedValue) > int.Parse(ddlMes2.SelectedValue)))
                {
                }
                else
                {
                    ReportDocument crystalrpt = new ReportDocument();
                    path = Server.MapPath("");
                    crystalrpt.Load(path + "\\AsistenciaRepresentanteRango.rpt");
                    //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                    crystalrpt.Refresh();
                    crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
                    crystalrpt.SetParameterValue("@Mes", ddlMes.SelectedValue);
                    crystalrpt.SetParameterValue("@Anio2", ddlAnio2.SelectedValue);
                    crystalrpt.SetParameterValue("@Mes2", ddlMes2.SelectedValue);
                    crystalrpt.SetParameterValue("@idRepresentante", ddlRepresentante.SelectedValue);
                    CrystalReportViewer1.ReportSource = crystalrpt;
                    CrystalReportViewer1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((int.Parse(ddlAnio.SelectedValue) > int.Parse(ddlAnio2.SelectedValue)) || ((int.Parse(ddlAnio.SelectedValue) == int.Parse(ddlAnio2.SelectedValue)) && int.Parse(ddlMes.SelectedValue) > int.Parse(ddlMes2.SelectedValue)))
            {
                Response.Write(@"<script>alert('RANGO INCORRECTO');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                path = Server.MapPath("");
                crystalrpt.Load(path + "\\AsistenciaRepresentanteRango.rpt");
                //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
                crystalrpt.SetParameterValue("@Mes", ddlMes.SelectedValue);
                crystalrpt.SetParameterValue("@Anio2", ddlAnio2.SelectedValue);
                crystalrpt.SetParameterValue("@Mes2", ddlMes2.SelectedValue);
                crystalrpt.SetParameterValue("@idRepresentante", ddlRepresentante.SelectedValue);
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
        }

        protected void ddlOrientador_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlRepresentante.DataSource = objOrientador.D_consultarRepresentantesporOrientador(int.Parse(ddlOrientador.SelectedValue));
            ddlRepresentante.DataTextField = "nombre";
            ddlRepresentante.DataValueField = "id";
            ddlRepresentante.DataBind();
        }
    }
}