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
    public partial class Ingresar_Joven : System.Web.UI.Page
    {
        clsPersona objPersona = new clsPersona();
        clsMenorEdad objMenorEdad = new clsMenorEdad();
        clsDatosJoven objDatosJoven = new clsDatosJoven();
        clsDOrientador objOrientador = new clsDOrientador();
        clsDAlimentacion2 objAlimentacion2 = new clsDAlimentacion2();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDDLs();
                
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            DateTime nacimiento = DateTime.Parse(txtFechaNacimiento.Text);
            if (revSAD.IsValid && rfvPrimerNombre.IsValid && rfvPrimerApellido.IsValid && rfvLugarNacimiento.IsValid && revTelefono.IsValid)
            {
                if (validaciones(nacimiento))
                {
                    cargarPersona(nacimiento);
                    cargarMenorEdad();

                    if (objDatosJoven.ingresaJoven(objPersona, objMenorEdad))
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
                    Response.Write("<script>window.alert('El joven debe tener al menos 12 años y tener menos de 18 años, por favor, comprobar');</script>");
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
            int.TryParse(txtAlimentacion.Text, out alimento);
            //objMenorEdad.IdOrientador = int.Parse(ddlOrientador.SelectedValue.ToString());
            objMenorEdad.Sad = txtSAD.Text;
            objMenorEdad.AnioIngreso = int.Parse(txtAnioIngreso.Text);
            objMenorEdad.Discapacidad = txtDiscapacidad.Text;
            objMenorEdad.Vacunas = chbVacunas.Checked;
            objMenorEdad.Alimentacion = alimento;
            objMenorEdad.NombreEncargado = 0;
            objMenorEdad.Sacramento = txtSacramento.Text;
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
            objPersona.ViveFamilia = chbViveFamilia.Checked;
            objPersona.Observacion = txtObservacion.Text;
            objPersona.Ingreso = DateTime.Now;
            objPersona.Cabeza = chbCabezaFamilia.Checked;
            objPersona.Telefono = txtTelefono.Text;
            objPersona.Numeros = cargarNumeros();
        }

        private void cargarDDLs()
        {
            ddlAlimentacion2.DataSource = objAlimentacion2.D_consultarOcupacion();
            ddlAlimentacion2.DataTextField = "NOMBRE";
            ddlAlimentacion2.DataValueField = "IDALIMENTACION2";
            ddlAlimentacion2.DataBind();

        }
        

        private bool validaciones(DateTime nacimiento)
        {
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

            if (edad < 18 && edad >= 12 && nacimiento < DateTime.Today && int.Parse(txtAnioIngreso.Text) >= nacimiento.Year)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void txtSAD_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ctvFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime nacimiento;
            DateTime maxDate = DateTime.Now;

            args.IsValid = (DateTime.TryParse(args.Value, out nacimiento) && nacimiento <= maxDate);
        }

        
        protected List<string> cargarNumeros()
        {
            List<string> numeros = new List<string>();

            if (txtTelefono.Text.Trim() != "")
            {
                numeros.Add(txtTelefono.Text);
            }
            if (txtTelefono0.Text.Trim() != "")
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