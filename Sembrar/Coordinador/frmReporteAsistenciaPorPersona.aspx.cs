using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
namespace Sembrar.Coordinador
{
    public partial class frmReporteAsistenciaPorPersona : System.Web.UI.Page
    {
        clsDProceso objProceso = new clsDProceso();
        clsDatosAsistencia objAsistencia = new clsDatosAsistencia();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaReunionPorPersona.rpt"));
                    crystalrpt.Refresh();
                    crystalrpt.SetParameterValue("@Persona", ddlPersona.SelectedValue);
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
            ddlPersona.DataSource = objAsistencia.D_consultarPersonas();
            ddlPersona.DataTextField = "Nombre";
            ddlPersona.DataValueField = "IdPersona";
            ddlPersona.DataBind();
        }
        private void cargarProceso()
        {
            ddlProceso.DataSource = objProceso.D_consultarProceso();
            ddlProceso.DataValueField = "IdProceso";
            ddlProceso.DataTextField = "Nombre";
            ddlProceso.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaReunionPorPersona.rpt"));
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@Persona", ddlPersona.SelectedValue);
                crystalrpt.SetParameterValue("@Mes", ddlMes.SelectedValue);
                crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
                crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
            catch { }
        }
    }
}