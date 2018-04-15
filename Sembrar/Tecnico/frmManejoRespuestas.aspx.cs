using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Tecnico
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
    }
}