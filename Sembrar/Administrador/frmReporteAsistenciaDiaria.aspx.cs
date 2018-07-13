using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CrystalDecisions.Shared;

namespace Sembrar.Administrador
{
    public partial class frmReporte6 : System.Web.UI.Page
    {
        clsDProceso objProceso = new clsDProceso();
        clsDOrientador objOrientador = new clsDOrientador();
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
                    ddlAnio.Items.Add(li);
                }
                try
                {
                    ddlOrientador.DataSource = objOrientador.D_consultarOrientadores2();
                    ddlOrientador.DataTextField = "NOMBREORIENTADOR";
                    ddlOrientador.DataValueField = "IDORIENTADOR";
                    ddlOrientador.DataBind();
                }
                catch
                {

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
            try
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaDiaria.rpt"));
                //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@Orientador", ddlOrientador.SelectedValue);
                crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
                crystalrpt.SetParameterValue("@Mes", ddlMes.SelectedValue);
                crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);

                crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ReporteAsistenciaDiaria" + ddlMes.SelectedItem.Text);
                crystalrpt.Refresh();
            }
            catch { }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReporteAsistenciaDiaria.rpt"));
                //crystalrpt.SetDatabaseLogon("adminSAEDI", "SAEDI.2018*");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@Orientador", ddlOrientador.SelectedValue);
                crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
                crystalrpt.SetParameterValue("@Mes", ddlMes.SelectedValue);
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

                crystalrpt.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "ReporteAsistenciaDiaria" + ddlMes.SelectedItem.Text);
                crystalrpt.Export();
            }
            catch { }
        }
    }
}