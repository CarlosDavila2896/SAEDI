using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using CapaNegocio;
using CapaDatos;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
namespace Sembrar.Coordinador
{
    public partial class frmReporteAsistenciaAnualReunion : System.Web.UI.Page
    {
        clsDProceso objProceso = new clsDProceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProceso();

                for (int i = 2016; i <= int.Parse(DateTime.Now.ToString("yyyy")); i++)
                {
                    ListItem li = new ListItem();
                    li.Text = i.ToString() + " / " + (i + 1).ToString();
                    li.Value = i.ToString();
                    DropDownList1.Items.Add(li);
                }
            }
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/ReporteAsistenciaAnualReuniones.rpt"));
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@Anio", DropDownList1.SelectedValue);
            crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/ReporteAsistenciaAnualReuniones.rpt"));
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@Anio", DropDownList1.SelectedValue);
            crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }
        private void cargarProceso()
        {
            ddlProceso.DataSource = objProceso.D_consultarProceso();
            ddlProceso.DataValueField = "IdProceso";
            ddlProceso.DataTextField = "Nombre";
            ddlProceso.DataBind();
        }
        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/ReporteAsistenciaAnualReuniones.rpt"));
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@Anio", DropDownList1.SelectedValue);
            crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }
    }
}