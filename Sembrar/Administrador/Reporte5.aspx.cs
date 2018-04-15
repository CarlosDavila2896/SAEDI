using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;

namespace Sembrar.Administrador
{
    public partial class Reporte5 : System.Web.UI.Page
    {
        string path = "";

        clsDatosNinio objNinio = new clsDatosNinio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                {
                    DropDownList1.DataSource = objNinio.consultarNinio2();
                    DropDownList1.DataTextField = "Nombre";
                    DropDownList1.DataValueField = "IdPersona";
                    DropDownList1.DataBind();
                }
                
                {

                }
            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                path = Server.MapPath("");
                
                crystalrpt.Load(path + "\\CrystalReport2.rpt");
                //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdPersona", DropDownList1.SelectedValue);
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            path = Server.MapPath("");
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(path + "\\CrystalReport2.rpt");

            //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@IdPersona", DropDownList1.SelectedValue);
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }
    }
}