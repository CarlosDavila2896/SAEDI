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
    
    public partial class frmManejoRespuestas : System.Web.UI.Page
    {
        clsNPosibleRespuesta nuevaRespuesta = new clsNPosibleRespuesta();
        clsDPosibleRespuesta objDPosibleRespuesta = new clsDPosibleRespuesta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarListaRespuestas();
            }
                
        }


        //Boton ingreso de respuesta
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtNombreRespuesta.Text.Trim().Length != 0)
            {
                nuevaRespuesta.TEXTOPOSIBLERESPUESTA = txtNombreRespuesta.Text;
                if (txtPuntaje.Text == "")
                {

                }
                else
                {
                    nuevaRespuesta.PUNTAJEPOSIBLERESPUESTA = int.Parse(txtPuntaje.Text);
                }

                nuevaRespuesta.ESTADOPOSIBLERESPUESTA = true;

                if (objDPosibleRespuesta.D_ingresarPosibleRespuesta(nuevaRespuesta))
                {
                    Response.Write(@"<script>alert('Se ha ingresado correctamente la respuesta');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Algo ha sido mal! Por favor, verifica la información ingresada');</script>");
                }
            }
            else
            {
                MsgBox("Ingrese un texto para la respuesta", this.Page, this);
            }


            
        }

        //Presentar los datos del gridview de relaciones
        private void cargarGVRelacionPR()
        {
            try
            {
                int idPregunta = int.Parse(lstPreguntas.SelectedValue);

                if (idPregunta > 0)
                {
                    gvRelacionPR.DataSource = objDPosibleRespuesta.D_consultaPreguntasconPosiblesRespuestasConPuntaje(idPregunta);
                    gvRelacionPR.DataBind();
                    
                }
                
            }
            catch
            {

            }
            
        }

        //Eliminar relacion pregunta con respuesta
        protected void gvRelacionPR_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPregunta = int.Parse(gvRelacionPR.SelectedRow.Cells[1].Text);
            int idRespuesta = int.Parse(gvRelacionPR.SelectedRow.Cells[2].Text);

            objDPosibleRespuesta.D_eliminarRelacionPreguntaRespuesta(idPregunta, idRespuesta);

            cargarGVRelacionPR();
        }

        //Ingresar nueva relacion pregunta respuesta
        protected void btnIngresarRelacion_Click(object sender, EventArgs e)
        {
            try
            {
                int idPregunta = int.Parse(lstPreguntas.SelectedValue);
                int idRespuesta = int.Parse(lstPosibleRespuesta.SelectedValue);

                objDPosibleRespuesta.D_ingresarRelacionPreguntaRespuesta(idPregunta, idRespuesta);

                cargarGVRelacionPR();

            }
            catch
            {
                Response.Write(@"<script>alert('Algo ha sido mal! Por favor, verifica la información ingresada');</script>");
            }
            
        }

        //Postback asincronico
        protected void lstPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGVRelacionPR();
            
        }

        //Ocultar ids del data gridview
        protected void gvRelacionPR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
        }

        private void cargarListaRespuestas()
        {
            lstPosibleRespuesta.DataSource = objDPosibleRespuesta.D_consultarPosiblesRespuestasActivasPuntaje1Linea();
            lstPosibleRespuesta.DataTextField = "TEXTOPOSIBLERESPUESTAPUNTAJE";
            lstPosibleRespuesta.DataValueField = "IDPOSIBLERESPUESTA";
            lstPosibleRespuesta.DataBind();
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