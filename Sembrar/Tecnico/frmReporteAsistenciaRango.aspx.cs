using CapaDatos;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar.Tecnico
{
    public partial class Reporte8 : System.Web.UI.Page
    {
        clsDProceso objProceso = new clsDProceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                cargarProceso();
                for (int i = 2016; i <= int.Parse(DateTime.Now.ToString("yyyy")); i++)
                {
                    ListItem li = new ListItem();
                    li.Text = i.ToString();
                    li.Value = i.ToString();
                    ddlAnio1.Items.Add(li);
                    ddlAnio2.Items.Add(li);
                }
            }
            else
            {
                if ((int.Parse(ddlAnio1.SelectedValue) > int.Parse(ddlAnio2.SelectedValue)) || ((int.Parse(ddlAnio1.SelectedValue) == int.Parse(ddlAnio2.SelectedValue)) && int.Parse(ddlMes1.SelectedValue) > int.Parse(ddlMes2.SelectedValue)))
                {

                }
                else
                {
                    ReportDocument crystalrpt = new ReportDocument();
                    crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/AsistenciaRango.rpt"));
                    crystalrpt.Refresh();
                    crystalrpt.SetParameterValue("@Anio", ddlAnio1.SelectedValue);
                    crystalrpt.SetParameterValue("@Mes", ddlMes1.SelectedValue);
                    crystalrpt.SetParameterValue("@Anio2", ddlAnio2.SelectedValue);
                    crystalrpt.SetParameterValue("@Mes2", ddlMes2.SelectedValue);
                    crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
                    //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                    //CrystalReportViewer1.ReportSource = crystalrpt;
                    //CrystalReportViewer1.DataBind();
                }      
            }
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
            if ((int.Parse(ddlAnio1.SelectedValue) > int.Parse(ddlAnio2.SelectedValue)) || ((int.Parse(ddlAnio1.SelectedValue) == int.Parse(ddlAnio2.SelectedValue)) && int.Parse(ddlMes1.SelectedValue) > int.Parse(ddlMes2.SelectedValue)))
            {
                Response.Write(@"<script>alert('RANGO INCORRECTO');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/AsistenciaRango.rpt"));
                crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@Anio", ddlAnio1.SelectedValue);
                crystalrpt.SetParameterValue("@Mes", ddlMes1.SelectedValue);
                crystalrpt.SetParameterValue("@Anio2", ddlAnio2.SelectedValue);
                crystalrpt.SetParameterValue("@Mes2", ddlMes2.SelectedValue);
                crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
                //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "AsistenciaRango");
                crystalrpt.Refresh();
                //CrystalReportViewer1.ReportSource = crystalrpt;
                //CrystalReportViewer1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if ((int.Parse(ddlAnio1.SelectedValue) > int.Parse(ddlAnio2.SelectedValue)) || ((int.Parse(ddlAnio1.SelectedValue) == int.Parse(ddlAnio2.SelectedValue)) && int.Parse(ddlMes1.SelectedValue) > int.Parse(ddlMes2.SelectedValue)))
            {
                Response.Write(@"<script>alert('RANGO INCORRECTO');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/AsistenciaRango.rpt"));
                crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@Anio", ddlAnio1.SelectedValue);
                crystalrpt.SetParameterValue("@Mes", ddlMes1.SelectedValue);
                crystalrpt.SetParameterValue("@Anio2", ddlAnio2.SelectedValue);
                crystalrpt.SetParameterValue("@Mes2", ddlMes2.SelectedValue);
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
                crystalrpt.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "AsistenciaRango");

                crystalrpt.Export();
            }
        }
    }
}