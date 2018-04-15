using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar.Digitador
{
    public partial class frmCambioPass : System.Web.UI.Page
    {

        clsUsuario objDUsuario = new clsUsuario();
        clsNUsuario objNUsurio = new clsNUsuario();
        public int cont;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarUsuario();
                cont = 0;
            }
            else
            {
            }
        }

        protected void cargarUsuario()
        {

            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            objNUsurio = objDUsuario.obtenerDatosUsuarioCompleto(logUser.UserName.ToString());
            txtPass.Text = objNUsurio.pass;
            txtId.Text = objNUsurio.idUser.ToString();
        }
        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            objNUsurio.idUser = int.Parse(txtId.Text);
            if (txtPass.Text.CompareTo(txtPassA.Text) == 0)
            {
                    objNUsurio.pass = txtPassNueva.Text;
                    if (objDUsuario.actualizarPass(objNUsurio))
                    {
                        resultado = 1;
                    }
                    else
                    {
                        cont = cont + 1;
                        Response.Write("<script>window.alert('Resultado Actualización: INCORRECTO');</script>");
                    }
                
            }
            else

                        if (cont > 2)
            {
                Response.Write("<script>window.alert('Ha superado el límite de intentos');</script>");
               

            }
            else
            {
                cont=cont+1;
                Response.Write("<script>window.alert('Vuelva Intentarlo');</script>");

            }

            cargarUsuario();
            if (resultado == 1)
            {
                string u = "Resultado Actualización: CORRECTO";
                FormsAuthentication.SignOut();
                Roles.DeleteCookie();
                Session.Clear();
                //Sesion
                Session.Add("us", u); //Nombre de variable de sesion y se asigna una variable
                Response.Redirect("~/Administrador/Inicio.aspx");
            }
            if (cont == 3)
                Response.Redirect("~/Administrador/Inicio.aspx");

        }
    }
}