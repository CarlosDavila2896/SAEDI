using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Sembrar.Coordinador
{
    public partial class Ver_Induviduo : System.Web.UI.Page
    {
        clsDatosPersona objDPersona = new clsDatosPersona();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int bandera = 1;
                lblCantidad.Text = objDPersona.consultarInfoIndividuosCantidad().ToString();
                Session["bandera"] = bandera;
                pnlCodigos.Visible = false;
                bool buscar = false;
                Session["buscar"] = buscar;

            }
            try
            {
                gvIndividuos.DataBind();
            }
            catch
            {

            }
        }

        protected void gvIndividuos_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            try
            {
                
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[8].Visible = false;
                var cellToMove = e.Row.Cells[2];
                e.Row.Cells.RemoveAt(2);
                e.Row.Cells.AddAt(8, cellToMove);

                bool buscar = bool.Parse(Session["buscar"].ToString());
                
                if (!buscar)
                {
                    e.Row.Cells[1].Visible = false;
                }

            }
            catch
            {

            }           
        }

        protected void gvIndividuos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPersona = Convert.ToInt32(((Label)gvIndividuos.Rows[gvIndividuos.SelectedRow.RowIndex].FindControl("lblID")).Text);
            int tipoPersona = objDPersona.consultaTipoPersona(idPersona);

            switch (tipoPersona)
            {
                case 0:
                    MsgBox("Algo ha salido mal!",this.Page, this);
                    break;

                case 1:
                    Response.Redirect("frmActualizarNinio.aspx?id=" + idPersona);
                    break;

                case 2:
                    Response.Redirect("frmActualizarJoven.aspx?id=" + idPersona);
                    break;

                case 3:
                    Response.Redirect("frmActualizarAdulto.aspx?id=" + idPersona);
                    break;

                default:
                    MsgBox("Algo ha salido mal!", this.Page, this);
                    break;
            }
        }

        protected void lbtTodos_Click(object sender, EventArgs e)
        {
            bool buscar = false;
            Session["buscar"] = buscar;
            odsIndividuos.SelectParameters.Clear();
            pnlCodigos.Visible = false;
            int bandera = 1;            
            odsIndividuos.SelectMethod = "ConsultarInfoIndividuos";
            lblCantidad.Text = objDPersona.consultarInfoIndividuosCantidad().ToString();
            gvIndividuos.AllowPaging = true;
            gvIndividuos.DataBind();
            gvIndividuos.DataKeyNames[0] = "ID";
            Session["bandera"] = bandera;
        }
        
        protected void lbtAdultos_Click(object sender, EventArgs e)
        {
            bool buscar = false;
            Session["buscar"] = buscar;
            odsIndividuos.SelectParameters.Clear();
            pnlCodigos.Visible = false;
            int bandera = 2;
            odsIndividuos.SelectMethod = "consultarInfoIndividuosAdultos";
            lblCantidad.Text = objDPersona.consultarInfoIndividuosAdultosCantidad().ToString();
            gvIndividuos.AllowPaging = true;            
            gvIndividuos.DataBind();
            Session["bandera"] = bandera;
        }

        protected void lbtJovenes_Click(object sender, EventArgs e)
        {

            bool buscar = false;
            Session["buscar"] = buscar;
            odsIndividuos.SelectParameters.Clear();
            pnlCodigos.Visible = true;
            int bandera = 3;
            odsIndividuos.SelectMethod = "consultarInfoIndividuosJovenes";
            lblCantidad.Text = objDPersona.consultarInfoIndividuosAdultosCantidad().ToString();
            gvIndividuos.AllowPaging = true;            
            gvIndividuos.DataBind();
            Session["bandera"] = bandera;
        }

        protected void lbtNinios_Click(object sender, EventArgs e)
        {

            bool buscar = false;
            Session["buscar"] = buscar;
            odsIndividuos.SelectParameters.Clear();
            pnlCodigos.Visible = true;
            int bandera = 4;
            odsIndividuos.SelectMethod = "consultarInfoIndividuosNinios";
            lblCantidad.Text = objDPersona.consultarInfoIndividuosNiniosCantidad().ToString();
            gvIndividuos.AllowPaging = true;
            gvIndividuos.DataBind();
            Session["bandera"] = bandera;
        }

        protected void lbtPRO_Click(object sender, EventArgs e)
        {

            bool buscar = false;
            Session["buscar"] = buscar;
            int bandera = int.Parse(Session["bandera"].ToString());

            if (bandera == 3)
            {
                odsIndividuos.SelectParameters.Clear();
                odsIndividuos.SelectMethod = "consultarInfoIndividuosJovenesCodigo";
                odsIndividuos.SelectParameters.Add("Codigo", "PRO");
                lblCantidad.Text = objDPersona.consultarInfoIndividuosJovenesCantidadCodigo("PRO").ToString();
                gvIndividuos.AllowPaging = true;
                gvIndividuos.DataBind();
            }  
            if(bandera == 4)
            {
                odsIndividuos.SelectParameters.Clear();
                odsIndividuos.SelectMethod = "consultarInfoIndividuosNiniosCodigo";
                odsIndividuos.SelectParameters.Add("Codigo", "PRO");
                lblCantidad.Text = objDPersona.consultarInfoIndividuosNiniosCantidadCodigo("PRO").ToString();
                gvIndividuos.AllowPaging = true;
                gvIndividuos.DataBind();
            }      
            
        }

        protected void lbtQUI_Click(object sender, EventArgs e)
        {

            bool buscar = false;
            Session["buscar"] = buscar;
            int bandera = int.Parse(Session["bandera"].ToString());

            if (bandera == 3)
            {
                odsIndividuos.SelectParameters.Clear();
                odsIndividuos.SelectMethod = "consultarInfoIndividuosJovenesCodigo";
                odsIndividuos.SelectParameters.Add("Codigo", "QUI");
                lblCantidad.Text = objDPersona.consultarInfoIndividuosJovenesCantidadCodigo("QUI").ToString();
                gvIndividuos.AllowPaging = true;
                gvIndividuos.DataBind();
            }
            if (bandera == 4)
            {
                odsIndividuos.SelectParameters.Clear();
                odsIndividuos.SelectMethod = "consultarInfoIndividuosNiniosCodigo";
                odsIndividuos.SelectParameters.Add("Codigo", "QUI");
                lblCantidad.Text = objDPersona.consultarInfoIndividuosNiniosCantidadCodigo("QUI").ToString();
                gvIndividuos.AllowPaging = true;
                gvIndividuos.DataBind();
            }
        }

        protected void lbtOYE_Click(object sender, EventArgs e)
        {
            bool buscar = false;
            Session["buscar"] = buscar;

            int bandera = int.Parse(Session["bandera"].ToString());

            if (bandera == 3)
            {
                odsIndividuos.SelectParameters.Clear();
                odsIndividuos.SelectMethod = "consultarInfoIndividuosJovenesCodigo";
                odsIndividuos.SelectParameters.Add("Codigo", "OYE");
                lblCantidad.Text = objDPersona.consultarInfoIndividuosJovenesCantidadCodigo("OYE").ToString();
                gvIndividuos.AllowPaging = true;
                gvIndividuos.DataBind();
            }
            if (bandera == 4)
            {
                odsIndividuos.SelectParameters.Clear();
                odsIndividuos.SelectMethod = "consultarInfoIndividuosNiniosCodigo";
                odsIndividuos.SelectParameters.Add("Codigo", "OYE");
                lblCantidad.Text = objDPersona.consultarInfoIndividuosNiniosCantidadCodigo("OYE").ToString();
                gvIndividuos.AllowPaging = true;
                gvIndividuos.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int bandera = int.Parse(Session["bandera"].ToString());

            bool buscar =false;
            Session["buscar"] = buscar;

            switch (bandera)
            {
                case 1:
                    odsIndividuos.SelectParameters.Clear();
                    odsIndividuos.SelectMethod = "consultarInfoIndividuosFiltro";
                    odsIndividuos.SelectParameters.Add("texto", txtNombre.Text.Trim());
                    lblCantidad.Text = objDPersona.consultarInfoIndividuosCantidadFiltro(txtNombre.Text.Trim()).ToString();
                    gvIndividuos.AllowPaging = false;
                    gvIndividuos.DataBind();
                    break;

                case 2:
                    odsIndividuos.SelectParameters.Clear();
                    odsIndividuos.SelectMethod = "consultarInfoIndividuosAdultosFiltro";
                    odsIndividuos.SelectParameters.Add("texto", txtNombre.Text.Trim());
                    lblCantidad.Text = objDPersona.consultarInfoIndividuosCantidadAdultosFiltro(txtNombre.Text.Trim()).ToString();
                    gvIndividuos.AllowPaging = false;
                    gvIndividuos.DataBind();
                    break;

                case 3:
                    odsIndividuos.SelectParameters.Clear();
                    odsIndividuos.SelectMethod = "consultarInfoIndividuosJovenesFiltro";
                    odsIndividuos.SelectParameters.Add("texto", txtNombre.Text.Trim());
                    lblCantidad.Text = objDPersona.consultarInfoIndividuosJovenesCantidadFiltro(txtNombre.Text.Trim()).ToString();
                    gvIndividuos.AllowPaging = false;
                    gvIndividuos.DataBind();
                    break;

                case 4:
                    odsIndividuos.SelectParameters.Clear();
                    odsIndividuos.SelectMethod = "consultarInfoIndividuosNiniosFiltro";
                    odsIndividuos.SelectParameters.Add("texto", txtNombre.Text.Trim());
                    lblCantidad.Text = objDPersona.consultarInfoIndividuosNiniosCantidadFiltro(txtNombre.Text.Trim()).ToString();
                    gvIndividuos.AllowPaging = false;
                    gvIndividuos.DataBind();
                    break;

                default:
                    odsIndividuos.SelectParameters.Clear();
                    odsIndividuos.SelectMethod = "consultarInfoIndividuosFiltro";
                    odsIndividuos.SelectParameters.Add("texto", txtNombre.Text.Trim());
                    lblCantidad.Text = objDPersona.consultarInfoIndividuosCantidadFiltro(txtNombre.Text.Trim()).ToString();
                    gvIndividuos.AllowPaging = false;
                    gvIndividuos.DataBind();
                    break;
            }
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }


        


    }
}