using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Digitador
{
    public partial class frmVerCuestionario : System.Web.UI.Page
    {
        clsDCuestionario objDcuestionario = new clsDCuestionario();
        clsNSolucionCuestionario nuevasolucion = new clsNSolucionCuestionario();
        clsDSolucionCuestionario objDSolucionCuestionario = new clsDSolucionCuestionario();
        List<clsNSolucionCuestionario> respuestas = new List<clsNSolucionCuestionario>();
        int idProceso, idObjetivo, idIndicador, idPeriodo, idPersona;
        DateTime fechaSolucion;
        Table Cuestionario;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                generarCuestionario();
            }
        }


        private void generarCuestionario()
        {

            //pnlCuestionario.Controls.Clear();

            //Elentos cuestionario
            Table tablaCuestionario = new Table();
            TableRow filatabla;
            TableCell celdatabla;
            Label lblRespuesta;

            //Atributos cuestionario
            tablaCuestionario.Width = Unit.Percentage(100);
            tablaCuestionario.ID = "tblCuestionario";

            List<CapaDatos.OBJETIVO> consultaObjetivos = objDcuestionario.D_consultaObjectivosCuestionarioAResolver(int.Parse(ddlProceso.SelectedValue));

            int cont = 1;

            foreach (CapaDatos.OBJETIVO obj in consultaObjetivos)
            {

                //Cabecera
                filatabla = new TableRow();
                celdatabla = new TableCell();
                celdatabla.Width = Unit.Percentage(100);
                if (obj.NOMBREOBJETIVO != "No Aplica" && obj.NOMBREOBJETIVO != "No aplica" && obj.NOMBREOBJETIVO != "NO APLICA")
                {
                    celdatabla.Text = obj.NOMBREOBJETIVO;
                }
                else
                {
                    celdatabla.Text = "\n";
                    celdatabla.Height = 25;
                }
                celdatabla.HorizontalAlign = HorizontalAlign.Center;
                celdatabla.ID = "idObjetivo" + obj.IDOBJETIVO + "-" + cont;
                celdatabla.ClientIDMode = ClientIDMode.Static;
                filatabla.Cells.Add(celdatabla);
                tablaCuestionario.Rows.Add(filatabla);

                List<CapaDatos.INDICADOR> consultaIndicadores = objDcuestionario.D_consultaIndicadoresCuestionarioAResolver(int.Parse(ddlProceso.SelectedValue), obj.IDOBJETIVO);

                foreach (CapaDatos.INDICADOR ind in consultaIndicadores)
                {
                    //Cabecera
                    filatabla = new TableRow();
                    celdatabla = new TableCell();
                    celdatabla.Width = Unit.Percentage(100);
                    if (ind.NOMBREINDICADOR != "No Aplica" && ind.NOMBREINDICADOR != "No aplica" && ind.NOMBREINDICADOR != "NO APLICA")
                    {
                        celdatabla.Text = ind.NOMBREINDICADOR;
                    }
                    else
                    {
                        celdatabla.Text = "\n";
                        celdatabla.Height = 25;
                    }
                    celdatabla.HorizontalAlign = HorizontalAlign.Center;
                    celdatabla.ID = "idIndicador" + ind.IDINDICADOR + "-" + cont;
                    celdatabla.ClientIDMode = ClientIDMode.Static;
                    filatabla.Cells.Add(celdatabla);
                    tablaCuestionario.Rows.Add(filatabla);

                    List<CapaDatos.PREGUNTA> consultaPreguntas = objDcuestionario.D_consultaPreguntasCuestionarioAResolver(int.Parse(ddlProceso.SelectedValue), obj.IDOBJETIVO, ind.IDINDICADOR);

                    foreach (CapaDatos.PREGUNTA pre in consultaPreguntas)
                    {
                        //Nombre pregunta
                        filatabla = new TableRow();
                        celdatabla = new TableCell();
                        celdatabla.Width = Unit.Percentage(100);
                        celdatabla.Text = pre.NOMBREPREGUNTA;
                        celdatabla.ID = "id" + pre.IDPREGUNTA.ToString() + "-" + cont;
                        celdatabla.ClientIDMode = ClientIDMode.Static;
                        celdatabla.HorizontalAlign = HorizontalAlign.Left;
                        filatabla.Cells.Add(celdatabla);
                        tablaCuestionario.Rows.Add(filatabla);

                        //Controles respuesta
                        celdatabla = new TableCell();
                        filatabla = new TableRow();
                        celdatabla.Width = Unit.Percentage(100);


                        //Pregunta cerrada
                        if (pre.IDTIPOPREGUNTA == 1)
                        {
                            List<CapaDatos.POSIBLERESPUESTA> consultaRespuestas = objDcuestionario.D_consultaRespuestasCuestionarioAResolver(pre.IDPREGUNTA);

                            //Lista de radio buttons
                            lblRespuesta = new Label();
                            lblRespuesta.ID = "rblPregunta" + pre.IDPREGUNTA + "-" + cont;
                            celdatabla.Controls.Add(lblRespuesta);

                        }
                        //Preguta Abierta
                        else if (pre.IDTIPOPREGUNTA == 2)
                        {
                            lblRespuesta = new Label();
                            lblRespuesta.ID = "txtPregunta" + pre.IDPREGUNTA + "-" + cont;
                            celdatabla.Controls.Add(lblRespuesta);
                            celdatabla.HorizontalAlign = HorizontalAlign.Left;
                        }
                        filatabla.Cells.Add(celdatabla);
                        tablaCuestionario.Rows.Add(filatabla);
                        cont++;
                    }

                }

            }
            tablaCuestionario.ClientIDMode = ClientIDMode.Static;
            pnlCuestionario.Controls.Clear();
            this.pnlCuestionario.Controls.Add(tablaCuestionario);
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLineaAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlOrientador_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            cargarRespuestas();
        }

        private void cargarRespuestas()
        {
            try
            {
                idProceso = int.Parse(ddlProceso.SelectedValue);
                idPeriodo = int.Parse(ddlPeriodo.SelectedValue);
                if (lstIndividuos.SelectedIndex < 0)
                {
                    Response.Write("<script>window.alert('Seleccione una persona');</script>");
                    return;
                }
                idPersona = int.Parse(lstIndividuos.SelectedValue);


                respuestas = objDSolucionCuestionario.D_obtenerlistaRespuestas(idPersona, idProceso, idPeriodo);

                Session["respuestas"] = respuestas;

                if (respuestas.Count == 0)
                {
                    Response.Write("<script>window.alert('No se ha encontrado un conjunto de respuestas para esta persona en dicho periodo para dicho proceso.');</script>");
                    return;
                }

                Cuestionario = (Table)pnlCuestionario.Controls[0];

                foreach (TableRow filaTabla in Cuestionario.Rows)
                {
                    foreach (TableCell celdaTabla in filaTabla.Cells)
                    {
                        if (celdaTabla.ID != null && celdaTabla.ID.StartsWith("idObjetivo"))
                        {
                            string id = celdaTabla.ID.Remove(0, 10);
                            idObjetivo = int.Parse(id.Substring(0, id.LastIndexOf("-")));
                        }
                        else if (celdaTabla.ID != null && celdaTabla.ID.StartsWith("idIndicador"))
                        {
                            string id = celdaTabla.ID.Remove(0, 11);
                            idIndicador = int.Parse(id.Substring(0, id.LastIndexOf("-")));
                        }
                        else
                        {
                            foreach (Control controlTabla in celdaTabla.Controls)
                            {
                                if (controlTabla is Label && controlTabla.ID.StartsWith("txtPregunta"))
                                {
                                    Label tempLabel = (Label)controlTabla;
                                    string id = tempLabel.ID.Remove(0, 11);
                                    int idPregunta = int.Parse(id.Substring(0, id.LastIndexOf("-")));
                                    try
                                    {
                                        tempLabel.Text = respuestas.Where(r => r.IDOBJETIVO == idObjetivo && r.IDINDICADOR == idIndicador && r.IDPREGUNTA == idPregunta).First().TEXTOSOLUCIONCUESTIONARIO;
                                    }
                                    catch
                                    {
                                        tempLabel.Text = "";
                                    }

                                }
                                else if (controlTabla is Label && controlTabla.ID.StartsWith("rblPregunta"))
                                {
                                    Label tempLabel = (Label)controlTabla;
                                    string id = tempLabel.ID.Remove(0, 11);
                                    int idPregunta = int.Parse(id.Substring(0, id.LastIndexOf("-")));
                                    tempLabel.Text = respuestas.Where(r => r.IDOBJETIVO == idObjetivo && r.IDINDICADOR == idIndicador && r.IDPREGUNTA == idPregunta).First().TEXTOSOLUCIONCUESTIONARIO;
                                }
                            }
                        }

                    }

                }
            }
            catch
            {
                Response.Write("<script>window.alert('Compruebe la información ingresada');</script>");
            }
        }

    }
    



}
