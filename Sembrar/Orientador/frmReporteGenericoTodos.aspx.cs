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
namespace Sembrar.Orientador
{
    public partial class frmReporteGenericoTodos : System.Web.UI.Page
    {
        clsDProceso objProceso = new clsDProceso();
        clsDatosPersona objPersona = new clsDatosPersona();
        protected void Page_Load(object sender, EventArgs e)
        {
            int idOrientador = (int)Session["id"];
            if (!Page.IsPostBack)
            {
                System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
                CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
                CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
                usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
                Session["id"] = usuario.IDOrientador1;

                try
                {
                    DropDownList1.DataSource = objProceso.D_consultarProcesoPorOrientador(idOrientador);
                    DropDownList1.DataTextField = "Nombre";
                    DropDownList1.DataValueField = "IdProceso";
                    DropDownList1.DataBind();
                    DropDownList2.DataSource = objPersona.D_consultarPersonaPorProcesoYOrientador(int.Parse(DropDownList1.SelectedValue), idOrientador);
                    DropDownList2.DataTextField = "Nombre";
                    DropDownList2.DataValueField = "IdPersona";
                    DropDownList2.DataBind();
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
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteGenerico.rpt"));
                //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
                crystalrpt.SetParameterValue("@IdPersona", DropDownList2.SelectedValue);
                crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ReporteCuestionario");
                crystalrpt.Refresh();
            }
            catch { }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idOrientador = (int)Session["id"];
                DropDownList2.DataSource = objPersona.D_consultarPersonaPorProcesoYOrientador(int.Parse(DropDownList1.SelectedValue), idOrientador);
                DropDownList2.DataTextField = "Nombre";
                DropDownList2.DataValueField = "IdPersona";
                DropDownList2.DataBind();
            }
            catch{ }
        }

        protected void btnBuscar0_Click1(object sender, EventArgs e)
        {
            try
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteGenerico.rpt"));
                //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
                crystalrpt.SetParameterValue("@IdPersona", DropDownList2.SelectedValue);
                ExportOptions exportOption;
                DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
                exportOption = crystalrpt.ExportOptions;
                {
                    exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                    exportOption.ExportFormatType = ExportFormatType.Excel;
                    exportOption.ExportDestinationOptions = diskFileDestinationOptions;
                    exportOption.ExportFormatOptions = new ExcelFormatOptions();
                }
                crystalrpt.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "ReporteCuestionario" + DropDownList2.SelectedItem.Text);

                crystalrpt.Export();
            }
            catch { }
        }
    
    }
}