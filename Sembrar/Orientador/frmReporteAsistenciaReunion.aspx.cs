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

namespace Sembrar.Orientador
{
    public partial class frmReporteAsistenciaReunion : System.Web.UI.Page
    {
        clsDatosReunion objReunion = new clsDatosReunion();
        protected void Page_Load(object sender, EventArgs e)
        {

            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;

            int idOrientador = (int)Session["id"];
            if (!Page.IsPostBack)
            {
                try
                {
                    cargarFecha();
                    cargarTema(DateTime.Parse(ddlFecha.Text));
                }
                catch { }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idOrientador = (int)Session["id"];
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/ReporteAsistenciaReunion.rpt"));
                crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdReunion", ddlTema.SelectedValue);
                crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ReporteAsistenciaReunion" + ddlTema.SelectedItem.Text);
                crystalrpt.Refresh();
            }
            catch { }
            
        }

        protected void ddlFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idOrientador = (int)Session["id"];
            cargarTema(DateTime.Parse(ddlFecha.Text));
        }
        private void cargarFecha()
        {
            int idOrientador = (int)Session["id"];
            ddlFecha.DataSource = objReunion.consultaReunionesFechasPorOrientador(idOrientador);
            ddlFecha.DataTextField = "FECHA";
            ddlFecha.DataBind();
        }
        private void cargarTema(DateTime fecha)
        {
            int idOrientador = (int)Session["id"];
            ddlTema.DataSource = objReunion.consultaReunionesPorFechaYOrientador(fecha, idOrientador);
            ddlTema.DataValueField = "IDREUNION";
            ddlTema.DataTextField = "TEMAREUNION";
            ddlTema.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int idOrientador = (int)Session["id"];
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/ReporteAsistenciaReunion.rpt"));
                crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdReunion", ddlTema.SelectedValue);
                ExportOptions exportOption;
                DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
                exportOption = crystalrpt.ExportOptions;
                {
                    exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                    exportOption.ExportFormatType = ExportFormatType.Excel;
                    exportOption.ExportDestinationOptions = diskFileDestinationOptions;
                    exportOption.ExportFormatOptions = new ExcelFormatOptions();
                }
                crystalrpt.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "ReporteAsistenciaReunion" + ddlTema.SelectedItem.Text);

                crystalrpt.Export();
            }
            catch { }
            
        }
    }
}