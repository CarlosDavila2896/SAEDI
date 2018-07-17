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
            CreateUserWizard1.UserName = "";
            CreateUserWizard1.Email= "";
            CreateUserWizard1.Question = "";
            CreateUserWizard1.Answer = "";


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
            lblTitulo.Visible = false;
        }
        
        

        protected void ddlROL_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            lblTitulo.Visible = true;
            CreateUserWizard1.Visible = true;
        }

        protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        {
           if(txtUserApellido.Text == "" || txtUserNombre.Text == "" || ddlROL.SelectedIndex == 0
                || CreateUserWizard1.UserName == "" || CreateUserWizard1.Email == "" || CreateUserWizard1.Password==""
                || CreateUserWizard1.Question =="" | CreateUserWizard1.Answer == "")
            {
                Response.Write("<script>window.alert('Campos Incompletos');</script>");
            }
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            try
            {
                txtUserM.Text = CreateUserWizard1.UserName;
                if (ddlROL.SelectedValue == "orientador")
                {
                    Ocultar();
                    objNOrientrador.NombreOrientador = txtUserNombre.Text;
                    objNOrientrador.apellidoOrientador = txtUserApellido.Text;
                    if (ddlGeneroUsuario.SelectedValue == "1")
                        objNOrientrador.generoOrientador = "F";
                    if (ddlGeneroUsuario.SelectedValue == "2")
                        objNOrientrador.generoOrientador = "M";
                    objNOrientrador.estadoOrientador = true;
                    if (objetoDOrientrador.ingresarOrientador(objNOrientrador, txtUserM.Text))
                    {
                        System.Web.Security.Roles.AddUserToRole(CreateUserWizard1.UserName, ddlROL.SelectedValue);
                        Response.Write("<script>window.alert('Resultado Ingreso: CORRECTO');</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('Resultado Ingreso: INCORRECTO');</script>");
                        System.Web.Security.Membership.DeleteUser(CreateUserWizard1.UserName);
                    }
                    limpiar();

                }
                if (ddlROL.SelectedValue == "administrador" || ddlROL.SelectedValue == "tecnico" || ddlROL.SelectedValue == "coordinador" || ddlROL.SelectedValue == "digitador")
                {
                    Ocultar();
                    objNUsuario.nombre = txtUserNombre.Text;
                    objNUsuario.appellido = txtUserApellido.Text;
                    if (ddlGeneroUsuario.SelectedValue == "1")
                        objNUsuario.genero = "F";
                    if (ddlGeneroUsuario.SelectedValue == "2")
                        objNUsuario.genero = "M";
                    objNUsuario.estado = true;
                    if (objDUsuario.ingresarUsuario(objNUsuario, txtUserM.Text))
                    {
                        System.Web.Security.Roles.AddUserToRole(CreateUserWizard1.UserName, ddlROL.SelectedValue);
                        Response.Write("<script>window.alert('Resultado Ingreso: CORRECTO');</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('Resultado Ingreso: INCORRECTO');</script>");
                        System.Web.Security.Membership.DeleteUser(CreateUserWizard1.UserName);
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
                System.Web.Security.Membership.DeleteUser(CreateUserWizard1.UserName);
            }

        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}