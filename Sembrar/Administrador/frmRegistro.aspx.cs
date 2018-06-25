using CapaDatos;
using CapaNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar.Administrador
{
    public partial class frmRegistro : System.Web.UI.Page
    {
        clsOrientador objNOrientrador = new clsOrientador();
        clsDOrientador objetoDOrientrador = new clsDOrientador();
        clsUsuario objDUsuario = new clsUsuario();
        clsNUsuario objNUsuario = new clsNUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ocultar();
                limpiar();
            }
            lblRol.Visible = true;
            ddlROL.Visible = true;
        }

        private void limpiar()
        {
            txtUserApellido.Text = "";
            txtUserNombre.Text = "";
            ddlGeneroUsuario.SelectedIndex = 0;
            //ddlROL.SelectedIndex = 0;
            CreateUserWizard.UserName = "";
            CreateUserWizard.Email = "";
            CreateUserWizard.Question = "";
            CreateUserWizard.Answer = "";


        }

        private void Ocultar()
        {
            txtUserM.Visible = false;
            txtUserApellido.Visible = false;
            txtUserNombre.Visible = false;
            ddlGeneroUsuario.Visible = false;
            ddlROL.Visible = false;
            lblApellido.Visible = false;
            lblGenero.Visible = false;
            lblNombre.Visible = false;
            lblRol.Visible = false;
        }

        protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
        {
            try
            {
                txtUserM.Text = CreateUserWizard.UserName;
                if (ddlROL.SelectedValue == "orientador")
                {
                    Ocultar();
                    objNOrientrador.NombreOrientador = txtUserNombre.Text;
                    objNOrientrador.apellidoOrientador = txtUserApellido.Text;
                    if (ddlGeneroUsuario.SelectedValue == "1")
                        objNOrientrador.generoOrientador = "F";
                    else if (ddlGeneroUsuario.SelectedValue == "2")
                        objNOrientrador.generoOrientador = "M";
                    objNOrientrador.estadoOrientador = true;
                    if (objetoDOrientrador.ingresarOrientador(objNOrientrador, txtUserM.Text))
                    {
                        System.Web.Security.Roles.AddUserToRole(CreateUserWizard.UserName, ddlROL.SelectedValue);
                        System.Web.Security.MembershipUser MU = System.Web.Security.Membership.GetUser(CreateUserWizard.UserName);
                        MU.IsApproved = true;
                        System.Web.Security.Membership.UpdateUser(MU);
                        Response.Write("<script>window.alert('Usuario registrado con exito');</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('No se registro el usuario, vuelva a intentarlo');</script>");
                        //System.Web.Security.Membership.DeleteUser(CreateUserWizard.UserName);
                    }

                }
                else if (ddlROL.SelectedValue == "administrador" || ddlROL.SelectedValue == "tecnico" || ddlROL.SelectedValue == "coordinador" || ddlROL.SelectedValue == "digitador")
                {
                    Ocultar();
                    objNUsuario.nombre = txtUserNombre.Text;
                    objNUsuario.appellido = txtUserApellido.Text;
                    if (ddlGeneroUsuario.SelectedValue == "1")
                        objNUsuario.genero = "F";
                    else if (ddlGeneroUsuario.SelectedValue == "2")
                        objNUsuario.genero = "M";
                    objNUsuario.estado = true;
                    if (objDUsuario.ingresarUsuario(objNUsuario, txtUserM.Text))
                    {
                        System.Web.Security.Roles.AddUserToRole(CreateUserWizard.UserName, ddlROL.SelectedValue);
                        System.Web.Security.MembershipUser MU = System.Web.Security.Membership.GetUser(CreateUserWizard.UserName);
                        MU.IsApproved = true;
                        System.Web.Security.Membership.UpdateUser(MU);
                        Response.Write("<script>window.alert('Usuario registrado con exito');</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('No se registro el usuario, vuelva a intentarlo');</script>");
                        //System.Web.Security.Membership.DeleteUser(CreateUserWizard.UserName);
                    }
                    limpiar();
                }
                else
                {
                    Response.Write("<script>window.alert('ROL INCORRECTO');</script>");
                    limpiar();
                }
            }
            catch (Exception)
            {
                Response.Write("<script>window.alert('Resultado Ingreso: INCORRECTO');</script>");
                /* metodo para eliminar el usuario*/
                //System.Web.Security.Membership.DeleteUser(CreateUserWizard.UserName);
            }

        }


        protected void ddlROL_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateUserWizard.Visible = true;
            mostrar();
        }

        protected void mostrar()
        {
            txtUserApellido.Visible = true;
            txtUserNombre.Visible = true;
            ddlGeneroUsuario.Visible = true;
            lblApellido.Visible = true;
            lblGenero.Visible = true;
            lblNombre.Visible = true;
            lblRol.Visible = true;
        }

        protected void CreateUserWizard_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            if (txtUserApellido.Text == "" || txtUserNombre.Text == "" || ddlROL.SelectedIndex == 0
                 || CreateUserWizard.UserName == "" || CreateUserWizard.Email == "" || CreateUserWizard.Password == "")
                Response.Write("<script>window.alert('Campos Incompletos');</script>");
        }

        protected void CreateUserWizard_CreateUserError(object sender, CreateUserErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                Response.Write("<script>window.alert('Campos Incompletos');</script>");
            }
        }
    }
}