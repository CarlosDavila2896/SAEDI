using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CrystalDecisions.Shared;

namespace Sembrar.Orientador
{
    public partial class frmReporteAsistenciaAnualReunion : System.Web.UI.Page
    {
        clsDProceso objProceso = new clsDProceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;

            int idOrientador = (int)Session["id"];
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
            
        }
        private void cargarProceso()
        {
            int idOrientador = (int)Session["id"];
            ddlProceso.DataSource = objProceso.D_consultarProcesoPorOrientador(idOrientador);
            ddlProceso.DataValueField = "IdProceso";
            ddlProceso.DataTextField = "Nombre";
            ddlProceso.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idOrientador = (int)Session["id"];
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/ReporteAsistenciaAnualReunionesOrientador.rpt"));
                crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdOrientador", idOrientador);
                crystalrpt.SetParameterValue("@Anio", DropDownList1.SelectedValue);
                crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
                crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ReporteAsistenciaAnualReuniones" + DropDownList1.SelectedValue);
                crystalrpt.Refresh();
            }
            catch { }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int idOrientador = (int)Session["id"];
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/ReporteAsistenciaAnualReunionesOrientador.rpt"));
                crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdOrientador", idOrientador);
                crystalrpt.SetParameterValue("@Anio", DropDownList1.SelectedValue);
                crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
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
            catch { }

            
        }
    }
}