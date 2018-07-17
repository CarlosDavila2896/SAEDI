using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Sembrar.Coordinador
{
    public partial class Reporte7 : System.Web.UI.Page
    {
        clsDProceso objProceso = new clsDProceso();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                cargarProceso();
                try
                {
                 for (int i = 2016; i <= int.Parse(DateTime.Now.ToString("yyyy")); i++)
                {
                    ListItem li = new ListItem();
                    li.Text = i.ToString();
                    li.Value = i.ToString();
                    ddlAnio.Items.Add(li);
                }   
                }
                catch
                {

                }
            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/AsistenciaMensual.rpt"));
                //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
                crystalrpt.SetParameterValue("@Mes", DropDownList2.SelectedValue);
                crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
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
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportesServidor/AsistenciaMensual.rpt"));
            //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@Anio", ddlAnio.SelectedValue);
            crystalrpt.SetParameterValue("@Mes", DropDownList2.SelectedValue);
            crystalrpt.SetParameterValue("@IdProceso", ddlProceso.SelectedValue);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }
    }
}