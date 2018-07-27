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
namespace Sembrar.Tecnico
{
    public partial class frmReporteAsistenciaPorPersona : System.Web.UI.Page
    {
        clsDProceso objProceso = new clsDProceso();
        clsDatosAsistencia objAsistencia = new clsDatosAsistencia();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cargarProceso();
                cargarPersonas();
                if (!IsPostBack)
                {
                    for (int i = 2016; i <= int.Parse(DateTime.Now.ToString("yyyy")); i++)
                    {
                        ListItem li = new ListItem();
                        li.Text = i.ToString();
                        li.Value = i.ToString();
                        ddlAnio.Items.Add(li);
                    }
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
                    //CrystalReportViewer1.ReportSource = crystalrpt;
                    //CrystalReportViewer1.DataBind();
                }
            }
            catch { }
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cargarProceso()
        {
            ddlProceso.DataSource = objProceso.D_consultarProceso();
            ddlProceso.DataValueField = "IdProceso";
            ddlProceso.DataTextField = "Nombre";
            ddlProceso.DataBind();
        }
        public void cargarPersonas() {
            ddlPersona.DataSource = objAsistencia.D_consultarPersonas();
            ddlPersona.DataTextField = "Nombre";
            ddlPersona.DataValueField = "IdPersona";
            ddlPersona.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaReunionPorPersona.rpt"));
                //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@Persona", ddlPersona.SelectedValue);
                crystalrpt.SetParameterValue("@Mes", ddlMes.SelectedValue);
                crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
                crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
                crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ReporteAsistencia" + ddlPersona.SelectedItem.Text);
                crystalrpt.Refresh();
                //CrystalReportViewer1.ReportSource = crystalrpt;
                //CrystalReportViewer1.DataBind();
            } catch { }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaReunionPorPersona.rpt"));
            //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@Persona", ddlPersona.SelectedValue);
            crystalrpt.SetParameterValue("@Mes", ddlMes.SelectedValue);
            crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
            crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
            //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ReporteAsistenciaDiaria"+ ddlMes.SelectedItem.Text);

            //CrystalReportViewer1.ReportSource = crystalrpt;
            //CrystalReportViewer1.DataBind();
            ExportOptions exportOption;
            DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
            exportOption = crystalrpt.ExportOptions;
            {
                exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                exportOption.ExportFormatType = ExportFormatType.Excel;
                exportOption.ExportDestinationOptions = diskFileDestinationOptions;
                exportOption.ExportFormatOptions = new ExcelFormatOptions();
            }
            crystalrpt.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "ReporteAsistencia"+ ddlPersona.SelectedItem.Text);

            crystalrpt.Export();
        }
    }
}