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
    public partial class IngresarNiño : System.Web.UI.Page
    {
        clsPersona objPersona = new clsPersona();
        clsDatosPersona objDatosPersona = new clsDatosPersona();
        clsNinio objNinio = new clsNinio();
        clsDatosNinio objDatosNinio = new clsDatosNinio();
        clsMenorEdad objMenorEdad = new clsMenorEdad();
        clsDOrientador objOrientador = new clsDOrientador();
        clsDAlimentacion2 objAlimentacion2 = new clsDAlimentacion2();
        int bandera;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (chbTrabaja.Checked == true)
            {
                txtTiempoTrabajo.Visible = true;
                RegularExpressionValidator12.Visible = true;
                lblTrabaja.Visible = true;
            }
            else
            {
                txtTiempoTrabajo.Visible = false;
                RegularExpressionValidator12.Visible = false;
                lblTrabaja.Visible = false;
            }

            if (bandera == 1)
            {
                txtTelefono0.Visible = true;
            }
            else if (bandera == 2)
            {
                txtTelefono1.Visible = true;
            }

            if (!IsPostBack)
            {
                cargarDDLs();
                bandera = 0;
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            DateTime nacimiento = DateTime.Parse(txtFechaNacimiento.Text);
            if (revSAD.IsValid && rfvPrimerNombre.IsValid && rfvPrimerApellido.IsValid && rfvLugarNacimiento.IsValid && ctvFecha.IsValid && revTelefono.IsValid)
            {

                cargarPersona(nacimiento);
                cargarNinio();
                cargarMenorEdad();

                if (validaciones(nacimiento))
                {
                    if (objDatosNinio.ingresaNinio(objPersona, objNinio, objMenorEdad))
                    {
                        Response.Write(@"
     <script>
        alert('Ingreso  Correcto .');
        setTimeout(function(){            
            window.location = '" + Request.RawUrl + @"';
        }, 10);
    </script>
");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('Resultado Ingreso: INCORRECTO');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('El niño debe ser menor de 12 años, por favor, comprobar');</script>");
                }
                
            }
            else
            {
                Response.Write("<script>window.alert('Algun dato es erroneo, por favor, comprobar');</script>");
            }

        }
        

        private void cargarMenorEdad()
        {
            int alimento;
            //objMenorEdad.IdOrientador = int.Parse(ddlOrientador.SelectedValue.ToString());
            objMenorEdad.Sad = txtSAD.Text;
            objMenorEdad.AnioIngreso = int.Parse(txtAnioIngreso.Text);
            objMenorEdad.Discapacidad = txtDiscapacidad.Text;
            objMenorEdad.Vacunas = chbVacunas.Checked;
            int.TryParse(txtAlimentacion.Text, out alimento);
            objMenorEdad.Alimentacion = alimento;
            objMenorEdad.NombreEncargado = 0;
            objMenorEdad.Sacramento = txtSacramento.Text;
            
        }
        private void cargarNinio()
        {
            objNinio.Trabajo = chbTrabaja.Checked;
            int tiempo;
            int.TryParse(txtTiempoTrabajo.Text, out tiempo);
            objNinio.Tiempo = tiempo;

        }

        private void cargarPersona(DateTime nacimiento)
        {
            objPersona.IdAlimentacion = int.Parse(ddlAlimentacion2.SelectedValue.ToString());
            objPersona.PrimerNombre = txtPrimerNombre.Text;
            objPersona.SegundoNombre = txtSegundoNombre.Text;
            objPersona.PrimerApellido = txtPrimerApellido.Text;
            objPersona.SegundoApellido = txtSegundoApellido.Text;
            objPersona.Genero = bool.Parse(ddlGenero.SelectedValue.ToString());
            objPersona.Nacimiento = nacimiento;
            objPersona.Cedula = txtCedula.Text;
            objPersona.LugarNacimiento = txtLugarNacimiento.Text;
            objPersona.ViveFamilia = true;
            objPersona.Observacion = txtObservacion.Text;
            objPersona.Ingreso = DateTime.Now;
            objPersona.Cabeza = false;
            objPersona.Numeros = cargarNumeros();
            
        }

        protected void ctvFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime nacimiento;
            DateTime maxDate = DateTime.Now;

            args.IsValid = (DateTime.TryParse(args.Value, out nacimiento) && nacimiento <= maxDate);
        }

        private void cargarDDLs()
        {
            ddlAlimentacion2.DataSource = objAlimentacion2.D_consultarOcupacion();
            ddlAlimentacion2.DataTextField = "NOMBRE";
            ddlAlimentacion2.DataValueField = "IDALIMENTACION2";
            ddlAlimentacion2.DataBind();

        }

        protected void chbTrabaja_CheckedChanged(object sender, EventArgs e)
        {
        }
        
        private bool validaciones(DateTime nacimiento)
        {
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

            if (edad<12 && edad>=0 && nacimiento<DateTime.Today && int.Parse(txtAnioIngreso.Text)>=nacimiento.Year)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


                
        protected List<string> cargarNumeros()
        {
            List<string> numeros = new List<string>();

            if (txtTelefono.Text.Trim() != "")
            {
                numeros.Add(txtTelefono.Text);
            }
            if (txtTelefono0.Text.Trim()!="")
            {
                numeros.Add(txtTelefono0.Text);                
            }
            if (txtTelefono1.Text.Trim() != "")
            {
                numeros.Add(txtTelefono1.Text);
            }
            return numeros;

        }
        
    }
    
}