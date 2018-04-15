using System;
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
    public partial class Reporte2 : System.Web.UI.Page
    {
        string path = "";
        clsDatosNinio objNinio = new clsDatosNinio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    DropDownList1.DataSource = objNinio.consultarNinio2();
                    DropDownList1.DataTextField = "Nombre";
                    DropDownList1.DataValueField = "IdPersona";
                    DropDownList1.DataBind();
                }
                catch
                {

                }
            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                path = Server.MapPath("");
                crystalrpt.Load(path + "\\CrystalReport1.rpt");
                //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdPersona", DropDownList1.SelectedValue);
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            ReportDocument crystalrpt = new ReportDocument();
            path = Server.MapPath("");
            crystalrpt.Load(path + "\\CrystalReport1.rpt");
            //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@IdPersona",DropDownList1.SelectedValue);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }
    }
}