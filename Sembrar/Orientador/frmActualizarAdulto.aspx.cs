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
    public partial class Actualizar_Adulto : System.Web.UI.Page
    {
        clsPersona objPersona = new clsPersona();
        clsAdulto objAdulto = new clsAdulto();
        clsDatosAdulto objDatosAdulto = new clsDatosAdulto();
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
            ddlNivel.Enabled = false;
            txtDondeEstudia.Enabled = false;
            txtObservacion.Enabled = false;
            btnIngresar.Enabled = false;
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            PresentarDatos();

        }

        private void PresentarDatos()
        {
            try
            {
                objDatosAdulto.buscarAdulto(int.Parse(ddlIndividuo.SelectedValue.ToString()), objPersona, objAdulto);


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
                ddlNivel.SelectedIndex = ddlNivel.Items.IndexOf(ddlNivel.Items.FindByText(objAdulto.NivelEducacion));

                txtObservacion.Text = objPersona.Observacion;
                
                txtDondeEstudia.Text = objAdulto.DondeEstudiaAdulto;


                ddlIndividuo.Enabled = false;
                rfvPrimerNombre.Enabled = true;
                rfvPrimerApellido.Enabled = true;
                RequiredFieldValidator45.Enabled = true;

                rfvLugarNacimiento.Enabled = true;
                revTelefono.Enabled = true;
                desbloquearCampos();
            }
            catch
            {
                Response.Write("<script>window.alert('No se ha seleccionado ningún adulto, vuelva a intentarlo');</script>");
            }
        }

        private void desbloquearCampos()
        {
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
            ddlNivel.Enabled = true;
            txtDondeEstudia.Enabled = true;
            txtObservacion.Enabled = true;
            btnIngresar.Enabled = true;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime nacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                cargarPersona(nacimiento);
                cargarAdulto();

                if (validaciones(nacimiento))
                {
                    if (objDatosAdulto.actualizaAdulto(int.Parse(ddlIndividuo.SelectedValue.ToString()), objPersona, objAdulto))
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
                    Response.Write("<script>window.alert('El adulto debe tener al menos 18 años, por favor, comprobar');</script>");
                }

                

            }
            catch
            {
                Response.Write("<script>window.alert('Resultado Edición: INCORRECTO, Revisar los datos editados');</script>");
            }

            bloquearCampos();
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
        private void cargarAdulto()
        {
            objAdulto.DondeEstudiaAdulto = txtDondeEstudia.Text;
            objAdulto.NivelEducacion = ddlNivel.SelectedItem.ToString();
        }

        protected void ddlIndividuo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarDDLs()
        {
            ddlAlimentacion2.DataSource = objAlimentacion2.D_consultarOcupacion();
            ddlAlimentacion2.DataTextField = "NOMBRE";
            ddlAlimentacion2.DataValueField = "IDALIMENTACION2";
            ddlAlimentacion2.DataBind();

            ddlIndividuo.DataSource = objDatosAdulto.consultarAdultos();
            ddlIndividuo.DataTextField = "NOMBRECOMPLETO";
            ddlIndividuo.DataValueField = "IDPERSONA";
            ddlIndividuo.DataBind();
            
        }

        private bool validaciones(DateTime nacimiento)
        {
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

            if (edad >= 18 && nacimiento < DateTime.Today)
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