using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;

using CapaDatos;
using CapaNegocio;
namespace Sembrar.Coordinador
{
    public partial class ReporteGenericoTodos1 : System.Web.UI.Page
    {
        string path = "";
        clsDProceso objProceso = new clsDProceso();
        clsDatosPersona objPersona = new clsDatosPersona();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    DropDownList1.DataSource = objProceso.D_consultarProceso();
                    DropDownList1.DataTextField = "Nombre";
                    DropDownList1.DataValueField = "IdProceso";
                    DropDownList1.DataBind();
                    DropDownList2.DataSource = objPersona.D_consultarPersonaPorProceso();
                    DropDownList2.DataTextField = "Nombre";
                    DropDownList2.DataValueField = "IdPersona";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Add(new ListItem("Todos", "-1"));

                }
                catch
                {

                }
            }
            else
            {
                if (int.Parse(DropDownList2.SelectedValue) != -1)
                {
                    ReportDocument crystalrpt = new ReportDocument();
                    path = Server.MapPath("");
                    crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteGenerico.rpt"));
                    crystalrpt.Refresh();
                    crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
                    crystalrpt.SetParameterValue("@IdPersona", DropDownList2.SelectedValue);
                    CrystalReportViewer1.ReportSource = crystalrpt;
                    CrystalReportViewer1.DataBind();
                }
                else
                {
                    ReportDocument crystalrpt = new ReportDocument();
                    path = Server.MapPath("");
                    crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteGenericoTodos.rpt"));
                    crystalrpt.Refresh();
                    crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
                    CrystalReportViewer1.ReportSource = crystalrpt;
                    CrystalReportViewer1.DataBind();

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(DropDownList2.SelectedValue) != -1)
            {
                ReportDocument crystalrpt = new ReportDocument();
                path = Server.MapPath("");
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteGenerico.rpt"));
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
                crystalrpt.SetParameterValue("@IdPersona", DropDownList2.SelectedValue);
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                path = Server.MapPath("");
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteGenericoTodos.rpt"));
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.DataSource = objPersona.D_consultarPersonaPorProceso();
            DropDownList2.DataTextField = "Nombre";
            DropDownList2.DataValueField = "IdPersona";
            DropDownList2.DataBind();
            DropDownList2.Items.Add(new ListItem("Todos", "-1"));
        }
    }
}