using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using System.Transactions;

namespace Sembrar.Tecnico
{
    public partial class frmModificarCuestionario : System.Web.UI.Page
    {
        clsDCuestionario objDcuestionario = new clsDCuestionario();
        List<clsNSolucionCuestionario> listaRespuestasAGuardar;
        List<clsNSolucionCuestionario> listaRespuestasAModificar;
        clsDSolucionCuestionario objDSolucionCuestionario = new clsDSolucionCuestionario();
        List<clsNSolucionCuestionario> respuestas = new List<clsNSolucionCuestionario>();
        int idProceso, idObjetivo, idIndicador, idPeriodo, idPersona;
        DateTime fechaSolucion;
        Table Cuestionario;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["cargarCuestionario"] = false;
                System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
                CapaNegocio.clsNUsuario usuario = new CapaNegocio.clsNUsuario();
                CapaDatos.clsUsuario objDatosPerfil = new CapaDatos.clsUsuario();
                usuario = objDatosPerfil.obtenerDatosUsuario(logUser.UserName.ToString());
                ViewState["usuarioModifica"] = usuario.idUser;

            }
            if ((bool)ViewState["cargarCuestionario"])
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
            TextBox textboxRespuesta;
            RadioButtonList listaRespuestas;
            CheckBoxList listaRespuestasMultiples;

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
                            listaRespuestas = new RadioButtonList();
                            listaRespuestas.ID = "rblPregunta" + pre.IDPREGUNTA + "-" + cont;
                            listaRespuestas.ClientIDMode = ClientIDMode.Static;
                            listaRespuestas.RepeatDirection = RepeatDirection.Horizontal;
                            listaRespuestas.CellSpacing = 10;
                            foreach (CapaDatos.POSIBLERESPUESTA resp in consultaRespuestas)
                            {
                                listaRespuestas.Items.Add(new ListItem(resp.TEXTOPOSIBLERESPUESTA, resp.IDPOSIBLERESPUESTA.ToString()));
                            }
                            celdatabla.Controls.Add(listaRespuestas);

                        }
                        //Preguta Abierta
                        else if (pre.IDTIPOPREGUNTA == 2)
                        {
                            textboxRespuesta = new TextBox();
                            textboxRespuesta.ID = "txtPregunta" + pre.IDPREGUNTA + "-" + cont;
                            textboxRespuesta.ClientIDMode = ClientIDMode.Static;
                            celdatabla.Controls.Add(textboxRespuesta);
                            celdatabla.HorizontalAlign = HorizontalAlign.Left;
                        }
                        //Preguta Abierta Extendida
                        else if (pre.IDTIPOPREGUNTA == 3)
                        {
                            textboxRespuesta = new TextBox();
                            textboxRespuesta.ID = "txtPregunta" + pre.IDPREGUNTA + "-" + cont;
                            textboxRespuesta.ClientIDMode = ClientIDMode.Static;
                            textboxRespuesta.TextMode = TextBoxMode.MultiLine;
                            celdatabla.Controls.Add(textboxRespuesta);
                            celdatabla.HorizontalAlign = HorizontalAlign.Left;
                        }
                        //Pregunta respuesta multiple
                        else if (pre.IDTIPOPREGUNTA == 4)
                        {
                            List<CapaDatos.POSIBLERESPUESTA> consultaRespuestas = objDcuestionario.D_consultaRespuestasCuestionarioAResolver(pre.IDPREGUNTA);

                            //Lista de radio buttons
                            listaRespuestasMultiples = new CheckBoxList();
                            listaRespuestasMultiples.ID = "chkPregunta" + pre.IDPREGUNTA + "-" + cont;
                            listaRespuestasMultiples.ClientIDMode = ClientIDMode.Static;
                            listaRespuestasMultiples.RepeatDirection = RepeatDirection.Horizontal;
                            listaRespuestasMultiples.CellSpacing = 10;
                            foreach (CapaDatos.POSIBLERESPUESTA resp in consultaRespuestas)
                            {
                                listaRespuestasMultiples.Items.Add(new ListItem(resp.TEXTOPOSIBLERESPUESTA, resp.IDPOSIBLERESPUESTA.ToString()));
                            }
                            celdatabla.Controls.Add(listaRespuestasMultiples);
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

        private void solucionar2()
        {
            listaRespuestasAGuardar = new List<clsNSolucionCuestionario>();
            listaRespuestasAModificar = new List<clsNSolucionCuestionario>();
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(999)))
            {

                Cuestionario = (Table)pnlCuestionario.Controls[0];

                respuestas = (List<clsNSolucionCuestionario>)Session["respuestas"];

                if (!objDSolucionCuestionario.D_eliminarRespuestaMultiplesCuestionario(respuestas))
                {
                    Response.Write("<script>window.alert('Ha ocurrido un error al eliminar las respuestas anteriores');</script>");
                    return;
                }

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
                                if (controlTabla is TextBox && controlTabla.ID.StartsWith("txtPregunta"))
                                {
                                    TextBox tempTextBox = (TextBox)controlTabla;
                                    string id = tempTextBox.ID.Remove(0, 11);
                                    int idPregunta = int.Parse(id.Substring(0, id.LastIndexOf("-")));
                                    clsNSolucionCuestionario tempSolucion = respuestas.Where(s => s.IDOBJETIVO == idObjetivo && s.IDINDICADOR == idIndicador && s.IDPREGUNTA == idPregunta).First();
                                    tempSolucion.TEXTOSOLUCIONCUESTIONARIO = tempTextBox.Text;
                                    modificarSolucion(tempSolucion);
                                }
                                else if (controlTabla is RadioButtonList && controlTabla.ID.StartsWith("rblPregunta"))
                                {
                                    RadioButtonList tempRadioButtonList = (RadioButtonList)controlTabla;
                                    string id = tempRadioButtonList.ID.Remove(0, 11);
                                    int idPregunta = int.Parse(id.Substring(0, id.LastIndexOf("-")));
                                    clsNSolucionCuestionario tempSolucion = respuestas.Where(s => s.IDOBJETIVO == idObjetivo && s.IDINDICADOR == idIndicador && s.IDPREGUNTA == idPregunta).First();
                                    tempSolucion.TEXTOSOLUCIONCUESTIONARIO = tempRadioButtonList.Items.FindByValue(tempRadioButtonList.SelectedValue).Text;
                                    modificarSolucion(tempSolucion);
                                }
                                else if (controlTabla is CheckBoxList && controlTabla.ID.StartsWith("chkPregunta"))
                                {
                                    CheckBoxList tempCheckBoxList = (CheckBoxList)controlTabla;
                                    string id = tempCheckBoxList.ID.Remove(0, 11);
                                    foreach (ListItem opcion in tempCheckBoxList.Items)
                                    {
                                        if (opcion.Selected)
                                        {
                                            guardarSolucion(int.Parse(id.Substring(0, id.LastIndexOf("-"))), opcion.Text);
                                        }
                                    }
                                }
                            }
                        }

                    }

                }
                objDSolucionCuestionario.D_guardarRespuestaCuestionario(listaRespuestasAGuardar);
                objDSolucionCuestionario.D_modificarRespuestaCuestionario(listaRespuestasAModificar);
                trans.Complete();
            }

        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstIndividuos.DataBind();
        }

        protected void ddlLineaAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstIndividuos.DataBind();
        }

        protected void ddlOrientador_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            generarCuestionario();
            cargarRespuestas();
            ViewState["cargarCuestionario"] = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                respuestas = (List<clsNSolucionCuestionario>)Session["respuestas"];

                if (objDSolucionCuestionario.D_eliminarRespuestaCuestionario(respuestas))
                {
                    Response.Write(@" <script>alert('Ficha eliminada correctamente');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Ha ocurrido un error al eliminar las respuestas');</script>");
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Ha ocurrido un error al eliminar las respuestas');</script>");
            }

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
                                if (controlTabla is TextBox && controlTabla.ID.StartsWith("txtPregunta"))
                                {
                                    TextBox tempTextBox = (TextBox)controlTabla;
                                    string id = tempTextBox.ID.Remove(0, 11);
                                    int idPregunta = int.Parse(id.Substring(0, id.LastIndexOf("-")));
                                    tempTextBox.Text = respuestas.Where(r => r.IDOBJETIVO == idObjetivo && r.IDINDICADOR == idIndicador && r.IDPREGUNTA == idPregunta).First().TEXTOSOLUCIONCUESTIONARIO;
                                }
                                else if (controlTabla is RadioButtonList && controlTabla.ID.StartsWith("rblPregunta"))
                                {
                                    RadioButtonList tempRadioButtonList = (RadioButtonList)controlTabla;
                                    string id = tempRadioButtonList.ID.Remove(0, 11);
                                    int idPregunta = int.Parse(id.Substring(0, id.LastIndexOf("-")));
                                    tempRadioButtonList.Items.FindByText(respuestas.Where(r => r.IDOBJETIVO == idObjetivo && r.IDINDICADOR == idIndicador && r.IDPREGUNTA == idPregunta).First().TEXTOSOLUCIONCUESTIONARIO).Selected = true;
                                }
                                else if (controlTabla is CheckBoxList && controlTabla.ID.StartsWith("chkPregunta"))
                                {
                                    CheckBoxList tempCheckBoxList = (CheckBoxList)controlTabla;
                                    string id = tempCheckBoxList.ID.Remove(0, 11);
                                    int idPregunta = int.Parse(id.Substring(0, id.LastIndexOf("-")));
                                    foreach(clsNSolucionCuestionario t in respuestas.Where(r => r.IDOBJETIVO == idObjetivo && r.IDINDICADOR == idIndicador && r.IDPREGUNTA == idPregunta))
                                    {
                                        tempCheckBoxList.Items.FindByText(t.TEXTOSOLUCIONCUESTIONARIO).Selected = true;
                                    }
                                    
                                }
                            }
                        }

                    }

                }
                clsUsuario consultaUsuario = new clsUsuario();

                //Ultima modificacion
                if (respuestas.First().FECHASOLUCIONCUESTIONARIO != null)
                {                    
                    clsNUsuario usuarioIngresa = consultaUsuario.obtenerDatosUsuarioID(respuestas.First().USUARIOINGRESA);

                    
                    lblModificacion.Text = "Fecha de ingreso de este cuestionario: " + respuestas.First().FECHASOLUCIONCUESTIONARIO.Date + " realizada por el usuario " + usuarioIngresa.nombre + " " + usuarioIngresa.appellido;
                    lblModificacion.Visible = true;
                }
                if(respuestas.First().FECHAMODIFICACIONCUESTIONARIO != null)
                {
                    clsNUsuario usuarioModifica = consultaUsuario.obtenerDatosUsuarioID(respuestas.First().USUARIOMODIFICA);

                    lblModificacion.Text += "\n Última moficación de este cuestionario: " + respuestas.First().FECHAMODIFICACIONCUESTIONARIO.Date + " realizada por el usuario " + usuarioModifica.nombre + " " + usuarioModifica.appellido;
                }


                btnIngresar.Visible = true;
                btnEliminar.Visible = true;
            }
            catch
            {
                Response.Write("<script>window.alert('Compruebe la información ingresada');</script>");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
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

                if (validarRadioButtons())
                {
                    solucionar2();
                    Response.Write(@" <script>alert('Se han modificado exitosamente las respuestas');setTimeout(function(){window.location = '" + Request.RawUrl + @"';}, 10);</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Responda todas las preguntas cerradas para guardar la solucion del cuestionario');</script>");
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Ha ocurrido un error al guardar las respuestas');</script>");
            }
        }

        private void modificarSolucion(clsNSolucionCuestionario modificacion)
        {
            clsNSolucionCuestionario nuevasolucion = new clsNSolucionCuestionario();
            nuevasolucion = modificacion;
            nuevasolucion.FECHAMODIFICACIONCUESTIONARIO = DateTime.Now;
            nuevasolucion.USUARIOMODIFICA = (int)ViewState["usuarioModifica"];
            listaRespuestasAModificar.Add(nuevasolucion);
        }
        private void guardarSolucion(int idPregunta, string respuesta)
        {
            clsNSolucionCuestionario nuevasolucion = new clsNSolucionCuestionario();
            nuevasolucion.IDPROCESO = idProceso;
            nuevasolucion.IDOBJETIVO = idObjetivo;
            nuevasolucion.IDINDICADOR = idIndicador;
            nuevasolucion.IDPREGUNTA = idPregunta;
            nuevasolucion.IDPERSONA = idPersona;
            nuevasolucion.IDPERIODO = idPeriodo;
            nuevasolucion.FECHASOLUCIONCUESTIONARIO = respuestas.Select(s=>s.FECHASOLUCIONCUESTIONARIO).ToList().First();
            nuevasolucion.USUARIOINGRESA = respuestas.Select(s => s.USUARIOINGRESA).ToList().First();
            nuevasolucion.FECHAMODIFICACIONCUESTIONARIO = DateTime.Now;
            nuevasolucion.USUARIOMODIFICA = (int)ViewState["usuarioModifica"];
            nuevasolucion.TEXTOSOLUCIONCUESTIONARIO = respuesta;
            listaRespuestasAGuardar.Add(nuevasolucion);            
        }

        private bool validarRadioButtons()
        {
            Cuestionario = (Table)pnlCuestionario.Controls[0];

            foreach (TableRow filaTabla in Cuestionario.Rows)
            {
                foreach (TableCell celdaTabla in filaTabla.Cells)
                {
                    foreach (Control controlTabla in celdaTabla.Controls)
                    {
                        if (controlTabla is RadioButtonList && controlTabla.ID.StartsWith("rblPregunta"))
                        {
                            RadioButtonList tempRadioButtonList = (RadioButtonList)controlTabla;

                            if (tempRadioButtonList.SelectedIndex < 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

    }


}
