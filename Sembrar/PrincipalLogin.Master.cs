using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace Sembrar
{
    public partial class PrincipalLogin : System.Web.UI.MasterPage
    {
        CapaNegocio.clsNUsuario usuario = new CapaNegocio.clsNUsuario();
        CapaDatos.clsUsuario objDatosPerfil = new CapaDatos.clsUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            if (System.Web.Security.Roles.IsUserInRole(Login1.UserName, "Administrador"))
            {
                usuario = objDatosPerfil.obtenerDatosUsuario(Login1.UserName.ToString());
                if (!usuario.estado)
                    notificarUsuario();
                Response.Redirect("~/Administrador/Inicio.aspx");
            }
            if (System.Web.Security.Roles.IsUserInRole(Login1.UserName, "Tecnico"))
            {
                usuario = objDatosPerfil.obtenerDatosUsuario(Login1.UserName.ToString());
                if (!usuario.estado)
                    notificarUsuario();
                Response.Redirect("Tecnico/Inicio.aspx");
            }
            if (System.Web.Security.Roles.IsUserInRole(Login1.UserName, "Orientador"))
            {
                CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
                CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
                usuario = objDatosPerfil.D_consultarOrientador(Login1.UserName.ToString());
                if (!usuario.estadoOrientador)
                    notificarUsuario();
                Response.Redirect("Orientador/Inicio.aspx");
            }

            if (System.Web.Security.Roles.IsUserInRole(Login1.UserName, "Coordinador"))
            {
                usuario = objDatosPerfil.obtenerDatosUsuario(Login1.UserName.ToString());
                if (!usuario.estado)
                    notificarUsuario();
                Response.Redirect("Coordinador/Inicio.aspx");
            }

            if (System.Web.Security.Roles.IsUserInRole(Login1.UserName, "Digitador"))
            {
                usuario = objDatosPerfil.obtenerDatosUsuario(Login1.UserName.ToString());
                if (!usuario.estado)
                    notificarUsuario();
                Response.Redirect("Digitador/Inicio.aspx");
            }
        }

        protected void notificarUsuario()
        {
            string u = "El usuario está bloqueado, comuníquese con el administrador";
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Clear();
            //Sesion
            Session.Add("us", u); //Nombre de variable de sesion y se asigna una variable
            Response.Redirect("~/Administrador/Inicio.aspx");
        }
    }
}