using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Orientador
{
    public partial class Actualizar_Niño : System.Web.UI.Page
    {
        clsPersona objPersona = new clsPersona();
        clsNinio objNinio = new clsNinio();
        clsMenorEdad objMenor = new clsMenorEdad();
        clsDatosPersona objDatosPersona = new clsDatosPersona();
        clsDatosNinio objDatosNinio = new clsDatosNinio();
        clsDOrientador objOrientador = new clsDOrientador();
        clsDAlimentacion2 objAlimentacion2 = new clsDAlimentacion2();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;

            if (!IsPostBack)
            {
                
                cargarDDLs();
                if (Request.QueryString["id"] != null)
                {
                    int idindividuo = int.Parse(Request.QueryString["id"]);
                    ddlIndividuo.SelectedValue = idindividuo.ToString();
                    PresentarDatos();
                }

            }
            if (Request.QueryString["id"] == null)
                {
                bloquearCampos();
                }
        }

        protected void bloquearCampos()
        {
            txtSAD.Enabled = false;
            txtAnioIngreso.Enabled = false;
            //ddlOrientador.Enabled = false;
            ddlAlimentacion2.Enabled = false;
            txtPrimerNombre.Enabled = false;
            txtSegundoNombre.Enabled = false;
            txtPrimerApellido.Enabled = false;
            txtSegundoApellido.Enabled = false;
            ddlGenero.Enabled = false;
            txtFechaNacimiento.Enabled = false;
            txtCedula.Enabled = false;
            txtLugarNacimiento.Enabled = false;
            txtTelefono.Enabled = false;
            txtTelefono0.Enabled = false;
            txtTelefono1.Enabled = false;
            chbTrabaja.Enabled = false;
            txtTiempoTrabajo.Enabled = false;
            chbVacunas.Enabled = false;
            txtAlimentacion.Enabled = false;
            txtSacramento.Enabled = false;
            txtObservacion.Enabled = false;
            btnModificar.Enabled = false;
        }

        protected void desbloquearCampos()
        {
            txtSAD.Enabled = true;
            txtAnioIngreso.Enabled = true;
            //ddlOrientador.Enabled = true;
            ddlAlimentacion2.Enabled = true;
            txtPrimerNombre.Enabled = true;
            txtSegundoNombre.Enabled = true;
            txtPrimerApellido.Enabled = true;
            txtSegundoApellido.Enabled = true;
            ddlGenero.Enabled = true;
            txtFechaNacimiento.Enabled = true;
            txtCedula.Enabled = true;
            txtLugarNacimiento.Enabled = true;
            txtTelefono.Enabled = true;
            txtTelefono0.Enabled = true;
            txtTelefono1.Enabled = true;
            chbTrabaja.Enabled = true;
            txtTiempoTrabajo.Enabled = true;
            chbVacunas.Enabled = true;
            txtAlimentacion.Enabled = true;
            txtSacramento.Enabled = true;
            txtObservacion.Enabled = true;
            btnModificar.Enabled = true;
        }

       

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            PresentarDatos();
        }

        private void PresentarDatos()
        {
            objDatosNinio.buscarNinio(int.Parse(ddlIndividuo.SelectedValue.ToString()), objPersona, objMenor, objNinio);

            ddlAlimentacion2.SelectedValue = objPersona.IdAlimentacion.ToString();
            txtPrimerNombre.Text = objPersona.PrimerNombre;
            txtSegundoNombre.Text = objPersona.SegundoNombre;
            txtPrimerApellido.Text = objPersona.PrimerApellido;
            txtSegundoApellido.Text = objPersona.SegundoApellido;
            ddlGenero.SelectedValue = objPersona.Genero.ToString();
            txtFechaNacimiento.Text = objPersona.Nacimiento.ToString("yyyy-MM-dd");
            txtCedula.Text = objPersona.Cedula;
            txtLugarNacimiento.Text = objPersona.LugarNacimiento;

            try
            {
                txtTelefono.Text = objPersona.Numeros[0];
                txtTelefono0.Text = objPersona.Numeros[1];
                txtTelefono1.Text = objPersona.Numeros[2];
            }
            catch
            {

            }
            txtObservacion.Text = objPersona.Observacion;

            //ddlOrientador.SelectedValue = objMenor.IdOrientador.ToString();
            txtSAD.Text = objMenor.Sad;
            txtAnioIngreso.Text = objMenor.AnioIngreso.ToString();
            txtDiscapacidad.Text = objMenor.Discapacidad;
            chbVacunas.Checked = objMenor.Vacunas;
            txtAlimentacion.Text = objMenor.Alimentacion.ToString();
            txtSacramento.Text = objMenor.Sacramento;

            chbTrabaja.Checked = objNinio.Trabajo;
            txtTiempoTrabajo.Text = objNinio.Tiempo.ToString();
            ddlIndividuo.Enabled = false;

            rfvPrimerNombre.Enabled = true;
            rfvPrimerApellido.Enabled = true;
            RequiredFieldValidator45.Enabled = true;

            rfvLugarNacimiento.Enabled = true;
            revTelefono.Enabled = true;
            RfAÑOIN.Enabled = true;
            ctvFecha.Enabled = true;
            desbloquearCampos();
        }

        protected void ctvFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime nacimiento;
            DateTime maxDate = DateTime.Now;

            args.IsValid = (DateTime.TryParse(args.Value, out nacimiento) && nacimiento <= maxDate);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime nacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                cargarPersona(nacimiento);
                cargarNinio();
                cargarMenorEdad();
                if (validaciones (nacimiento))
                {
                    if (objDatosNinio.actualizarNinio(int.Parse(ddlIndividuo.SelectedValue.ToString()), objPersona, objNinio, objMenor))
                    {

                        Response.Write(@"
     <script>
        alert('Modificacion Correcta .');
        setTimeout(function(){            
            window.location = '" + Request.RawUrl + @"';
        }, 10);
    </script>
");



                    }
                    else
                    {
                        Response.Write("<script>window.alert('Resultado Edición: INCORRECTO');</script>");

                    }
                }
                else
                {
                    Response.Write("<script>window.alert('El niño debe ser menor de 12 años, por favor, comprobar');</script>");
                }
                
            }
            catch
            {
                Response.Write("<script>window.alert('Resultado Edición: INCORRECTO, Revisar los datos editados');</script>");
            }
            bloquearCampos();

        }
        
        private void cargarMenorEdad()
        {
            //objMenor.IdOrientador = int.Parse(ddlOrientador.SelectedValue.ToString());
            objMenor.Sad = txtSAD.Text;
            objMenor.AnioIngreso = int.Parse(txtAnioIngreso.Text);
            objMenor.Discapacidad = txtDiscapacidad.Text;
            objMenor.Vacunas = chbVacunas.Checked;
            objMenor.Alimentacion = int.Parse(txtAlimentacion.Text);
            objMenor.NombreEncargado = 0;
            objMenor.Sacramento = txtSacramento.Text;
        }

        private void cargarNinio()
        {
            objNinio.Trabajo = chbTrabaja.Checked;
            objNinio.Tiempo = int.Parse(txtTiempoTrabajo.Text);

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
            objPersona.Numeros = cargarNumeros();
            objPersona.Cedula = txtCedula.Text;
            objPersona.LugarNacimiento = txtLugarNacimiento.Text;
            objPersona.ViveFamilia = true;
            objPersona.Observacion = txtObservacion.Text;
            objPersona.Ingreso = DateTime.Now;
            objPersona.Cabeza = false;
        }

        private void cargarDDLs()
        {

            ddlAlimentacion2.DataSource = objAlimentacion2.D_consultarOcupacion();
            ddlAlimentacion2.DataTextField = "NOMBRE";
            ddlAlimentacion2.DataValueField = "IDALIMENTACION2";
            ddlAlimentacion2.DataBind();

            ddlIndividuo.DataSource = objDatosNinio.consultarNinios();
            ddlIndividuo.DataTextField = "NOMBRECOMPLETO";
            ddlIndividuo.DataValueField = "IDPERSONA";
            ddlIndividuo.DataBind();
        }

        private bool validaciones(DateTime nacimiento)
        {
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

            if (edad < 12 && edad >= 0 && nacimiento < DateTime.Today && int.Parse(txtAnioIngreso.Text) >= nacimiento.Year)
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