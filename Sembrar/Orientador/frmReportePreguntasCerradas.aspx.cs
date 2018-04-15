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
namespace Sembrar.Orientador
{
    public partial class frmReportePreguntasCerradas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;

            int idOrientador = (int)Session["id"];
            clsDProceso objProceso = new clsDProceso();

            if (!Page.IsPostBack)
            {
                

                try
                {
                    DropDownList1.DataSource = objProceso.D_consultarProcesoPorOrientador(idOrientador);
                    DropDownList1.DataTextField = "Nombre";
                    DropDownList1.DataValueField = "IdProceso";
                    DropDownList1.DataBind();
                }
                catch
                {

                }
            }
            else
            {
                ReportDocument crystalrpt = new ReportDocument();
                crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportePreguntasCerradasOrientador.rpt"));
                crystalrpt.Refresh();
                crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
                crystalrpt.SetParameterValue("@IdOrientador", idOrientador);
                //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
                CrystalReportViewer1.ReportSource = crystalrpt;
                CrystalReportViewer1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int idOrientador = (int)Session["id"];
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(Server.MapPath(@"~/Reportes/ReportePreguntasCerradasOrientador.rpt"));
            crystalrpt.Refresh();
            crystalrpt.SetParameterValue("@IdProceso", DropDownList1.SelectedValue);
            crystalrpt.SetParameterValue("@IdOrientador", idOrientador);
            //crystalrpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            CrystalReportViewer1.ReportSource = crystalrpt;
            CrystalReportViewer1.DataBind();
        }
    }
}