﻿using System;
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
namespace Sembrar.Administrador
{
    public partial class ReportePreguntasCerradas1 : System.Web.UI.Page
    {
        string path = "";
        clsDProceso objProceso = new clsDProceso();
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
                }
                catch
                {

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument crystalrpt = new ReportDocument();
                path = Server.MapPath("");
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportePreguntasCerradas.rpt"));
                //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
                crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ReportePreguntasCerradas");
                crystalrpt.Refresh();
                //CrystalReportViewer1.ReportSource = crystalrpt;
                //CrystalReportViewer1.DataBind();
            }
            catch { }
           
        }

        protected void btnBuscar0_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument crystalrpt = new ReportDocument();
                path = Server.MapPath("");
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportePreguntasCerradas.rpt"));
                //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
                ExportOptions exportOption;
                DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
                exportOption = crystalrpt.ExportOptions;
                {
                    exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                    exportOption.ExportFormatType = ExportFormatType.Excel;
                    exportOption.ExportDestinationOptions = diskFileDestinationOptions;
                    exportOption.ExportFormatOptions = new ExcelFormatOptions();
                }
                crystalrpt.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "ReportePreguntasCerradas");

                crystalrpt.Export();
            }
            catch
            {

            }
            
        }
    }
}