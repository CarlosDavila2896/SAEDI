using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Sembrar.Tecnico
{
    public partial class frmReporteAsistenciaAnualReuniones : System.Web.UI.Page
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
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaAnualReuniones.rpt"));
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@Anio", DropDownList1.SelectedValue);
            crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
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
        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaAnualReuniones.rpt"));
            //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@Anio", DropDownList1.SelectedValue);
            crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
            crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ReporteAsistenciaAnualReuniones" + DropDownList1.SelectedValue);
            crystalrpt.Refresh();
            //CrystalReportViewer1.ReportSource = crystalrpt;
            //CrystalReportViewer1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaAnualReuniones.rpt"));
            //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@Anio", DropDownList1.SelectedValue);
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
            crystalrpt.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "ReporteAsistenciaAnualReuniones" + DropDownList1.SelectedValue);

            crystalrpt.Export();
        }
    }
}