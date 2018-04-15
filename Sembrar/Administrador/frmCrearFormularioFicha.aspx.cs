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
    public partial class frmCreacionFormularioFicha : System.Web.UI.Page
    {
        //Inicializacion de objetos
        clsNCuestionario nuevoCuestionario = new clsNCuestionario();
        clsDCuestionario objDCuestionario = new clsDCuestionario();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            leerVariables();           
            objDCuestionario.D_ingresarCuestionario(nuevoCuestionario);            
            gvCuestionario.DataBind();
        }

        

        //Cambio de Proceso
        protected void lstProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {            
            gvCuestionario.DataBind();
        }

        //Cambio de Objetivo
        protected void lstObjetivos_SelectedIndexChanged(object sender, EventArgs e)
        {            
            gvCuestionario.DataBind();
        }
        
        //Cambio de Indicador
        protected void lstIndicadores_SelectedIndexChanged(object sender, EventArgs e)
        {            
            gvCuestionario.DataBind();
        }

        //Cambio de pregunta
        protected void lstPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
                   
        }

        //Leer variables
        private void leerVariables()
        {
            if (lstProcesos.SelectedIndex >= 0)
            {
                nuevoCuestionario.IDPROCESO = int.Parse(lstProcesos.SelectedValue);
            }
            if (lstObjetivos.SelectedIndex >= 0)
            {
                nuevoCuestionario.IDOBJETIVO = int.Parse(lstObjetivos.SelectedValue);
            }
            if (lstIndicadores.SelectedIndex >= 0)
            {
                nuevoCuestionario.IDINDICADOR = int.Parse(lstIndicadores.SelectedValue);
            }
            if (lstPreguntas.SelectedIndex >= 0)
            {
                nuevoCuestionario.IDPREGUNTA = int.Parse(lstPreguntas.SelectedValue);
            }
            
            nuevoCuestionario.OBSERVACIONCUESTIONARIO = txtObservacion.Text;
            nuevoCuestionario.ESTADOCUESTIONARIO = true;
        }

        
    }
}