using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CrystalDecisions.CrystalReports.Engine;

namespace Sembrar.Administrador
{
    public partial class Reporte3 : System.Web.UI.Page
    {
        string path = "";
        clsDOrientador objOrientador = new clsDOrientador();
        clsDatosAsistencia objAsistencia = new clsDatosAsistencia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.DataSource = objOrientador.D_consultarOrientadores();
                DropDownList1.DataTextField = "NOMBREORIENTADOR";
                DropDownList1.DataValueField = "IDORIENTADOR";
                DropDownList1.DataBind();
                ddlFecha.Enabled = false;

            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                path = Server.MapPath("");
                crystalrpt.Load(path + "\\ReporteAsistencia.rpt");
                crystalrpt.SetParameterValue("@IdOrientador", DropDownList1.SelectedValue);
                crystalrpt.SetParameterValue("@Fecha", ddlFecha.Text);
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportDocument crystalrpt = new ReportDocument();
            
            path = Server.MapPath("");
            crystalrpt.Load(path + "\\ReporteAsistencia.rpt");
            crystalrpt.SetParameterValue("@IdOrientador", DropDownList1.SelectedValue);
            crystalrpt.SetParameterValue("@Fecha", ddlFecha.Text);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlFecha.Enabled = true;
            ddlFecha.DataSource = objAsistencia.D_consultarAsistenciaPorOrientador(int.Parse(DropDownList1.SelectedValue.ToString()));
            ddlFecha.DataTextField = "cadena";
            ddlFecha.DataValueField = "cadena";
            ddlFecha.DataBind();
            ReportDocument crystalrpt = new ReportDocument();
            path = Server.MapPath("");
            crystalrpt.Load(path + "\\ReporteAsistencia.rpt");
            crystalrpt.SetParameterValue("@IdOrientador", DropDownList1.SelectedValue);
            crystalrpt.SetParameterValue("@Fecha", ddlFecha.Text);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }
    }
}