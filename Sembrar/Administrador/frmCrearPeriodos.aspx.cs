using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace Sembrar.Administrador
{
    public partial class Crear_Periodos : System.Web.UI.Page
    {

        clsNPeriodo objPeriodo = new clsNPeriodo();
        clsDPeriodo objDPeriodo = new clsDPeriodo();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtNombrePeriodo.Text.Trim().Length !=0)
            {
                objPeriodo.NOMBREPERIODO = txtNombrePeriodo.Text;
                objPeriodo.IDTIPOPERIODO = 1;
                if (chbFinPeriodo.Checked)
                {
                    DateTime fin, inicio;
                    if(DateTime.TryParse(txtFechaInicio.Text, out inicio))
                    {
                        DateTime.TryParse(txtFechaFin.Text, out fin);
                        objPeriodo.FECHAFINPERIODO = fin;
                        objPeriodo.FECHAINICIOPERIODO = inicio;
                        if ((inicio <= DateTime.Now && fin > DateTime.Now) || inicio >DateTime.Now )
                        {
                            objPeriodo.ACTIVO = true;
                        }
                        else
                        {
                            objPeriodo.ACTIVO = false;
                        }
                        if (objDPeriodo.ingresarPeriodoConFechas(objPeriodo))
                        {
                            Response.Write(@"<script>alert('RESULTADO INGRESO PERIODO: CORRECTO');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                        }
                        else
                        {
                            MsgBox("! Error en el ingreso del periodo!", this.Page, this);
                        }
                    }
                    else
                    {
                        MsgBox("Ingrese una fecha de inicio válida", this.Page, this);
                    }

                    
                }
                else
                {
                    if (objDPeriodo.ingresarPeriodo(objPeriodo))
                    {
                        Response.Write(@"<script>alert('RESULTADO INGRESO PERIODO: CORRECTO');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                    }
                    else
                    {
                        MsgBox("! Error en el ingreso del periodo!", this.Page, this);
                    }
                }
            }
            else
            {
                MsgBox("Por favor, ingrese un nombre de periodo", this.Page, this);
            }

            gvPeriodo.DataBind();
        }

        protected void chbFinPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            pnlLimites.Enabled = chbFinPeriodo.Checked;
            pnlLimites.Visible= chbFinPeriodo.Checked;
            gvPeriodo.DataBind();
        }

        protected void txtFechaFin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gvPeriodo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[4].Visible = false;
                var cellToMove = e.Row.Cells[0];
                e.Row.Cells.RemoveAt(0);
                e.Row.Cells.AddAt(4, cellToMove);
                var cellToEdit = e.Row.Cells[2];
                if(cellToEdit.Text == "01/01/0001")
                {
                    cellToEdit.Text = "";
                }
                cellToEdit = e.Row.Cells[1];
                if (cellToEdit.Text == "01/01/0001")
                {
                    cellToEdit.Text = "";
                }
            }
            catch
            {

            }
        }

        private void editarGV()
        {

        }
    }
}