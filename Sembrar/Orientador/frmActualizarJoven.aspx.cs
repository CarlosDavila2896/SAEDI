using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;

namespace Sembrar.Orientador
{
    public partial class Actualizar_Joven : System.Web.UI.Page
    {
        clsDatosJoven objDatosJoven = new clsDatosJoven();
        clsPersona objPersona = new clsPersona();
        clsMenorEdad objMenor = new clsMenorEdad();
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
        private void bloquearCampos()
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
            txtObservacion.Enabled = false;
            btnModificar.Enabled = false;
        }
        private void desbloquearCampos()
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
            txtObservacion.Enabled = true;
            btnModificar.Enabled = true;
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            PresentarDatos();
        }

        private void PresentarDatos()
        {
            objDatosJoven.buscarJoven(int.Parse(ddlIndividuo.SelectedValue.ToString()), objPersona, objMenor);


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

            ddlIndividuo.Enabled = false;

            rfvPrimerNombre.Enabled = true;
            rfvPrimerApellido.Enabled = true;
            RequiredFieldValidator45.Enabled = true;

            rfvLugarNacimiento.Enabled = true;
            revTelefono.Enabled = true;
            RfAÑOIN.Enabled = true;
            desbloquearCampos();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime nacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                cargarPersona(nacimiento);
                cargarMenorEdad();

                if (validaciones(nacimiento))
                {
                    if (objDatosJoven.actualizarJoven(int.Parse(ddlIndividuo.SelectedValue.ToString()), objPersona, objMenor))
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
                    Response.Write("<script>window.alert('Hay un error en la fecha de nacimiento, por favor, comprobar');</script>");
                }

                
            }
            catch
            {
                Response.Write("<script>window.alert('Resultado Edición: INCORRECTO, Revisar los datos editados');</script>");
            }

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
            objPersona.Numeros = cargarNumeros();
            objPersona.LugarNacimiento = txtLugarNacimiento.Text;
            objPersona.Telefono = txtTelefono.Text;
            objPersona.Observacion = txtObservacion.Text;
            objPersona.Ingreso = DateTime.Now;
        }
        private void cargarMenorEdad()
        {
            //objMenor.IdOrientador = int.Parse(ddlOrientador.SelectedValue.ToString());
            objMenor.Sad = txtSAD.Text;
            objMenor.AnioIngreso = int.Parse(txtAnioIngreso.Text);
            objMenor.NombreEncargado = 0;
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

            ddlIndividuo.DataSource = objDatosJoven.consultarJovenes();
            ddlIndividuo.DataTextField = "NOMBRECOMPLETO";
            ddlIndividuo.DataValueField = "IDPERSONA";
            ddlIndividuo.DataBind();
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

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {/*
            if (txtCedula.Text != "")
            {
                verificarCedula();
            }
            */
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