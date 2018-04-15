using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar.Orientador
{
    public partial class frmMiPerfil : System.Web.UI.Page
    {
        clsOrientador LogUsuario = new clsOrientador();
        clsDOrientador objDUsuario = new clsDOrientador();
        clsNMembership objeNMembership = new clsNMembership();
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
            CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
            usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
            Session["id"] = usuario.IDOrientador1;

            if (!IsPostBack)
            {
                

                Cargar();
                cargarMemberhsip();
            }

        }

        protected void cargarMemberhsip()
        {
            objeNMembership = objDUsuario.cargarOrientadorMembership(int.Parse(txtIdUsuario.Text));
            txtEmail.Text = objeNMembership.email;
            txtUserName.Text = objeNMembership.username;

        }

        private void Cargar()
        {
            System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
            LogUsuario = objDUsuario.obtenerDatosOrientadorCompleto(logUser.UserName.ToString());
            txtNombreUsuario.Text = LogUsuario.NombreOrientador;
            txtApellidoUsuario.Text = LogUsuario.apellidoOrientador;
            txtIdUsuario.Text = LogUsuario.IDOrientador1.ToString();
            if (LogUsuario.generoOrientador == "M")
                ddlGeneroUsuario.SelectedValue = "2";
            else if (LogUsuario.generoOrientador == "F")
                ddlGeneroUsuario.SelectedValue = "1";
            else
                ddlGeneroUsuario.SelectedValue = "0";
        }


        protected void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            if (ddlGeneroUsuario.SelectedValue == "0")
            {
                Response.Write("<script>window.alert('Resultado Actualización: INCORRECTO');</script>");
            }
            else
            {
                clsOrientador usuario = new clsOrientador();
                usuario.IDOrientador1 = int.Parse(txtIdUsuario.Text);
                usuario.NombreOrientador = txtNombreUsuario.Text;
                usuario.apellidoOrientador = txtApellidoUsuario.Text;
                if (ddlGeneroUsuario.SelectedValue == "1")
                    usuario.generoOrientador = "F";
                if (ddlGeneroUsuario.SelectedValue == "2")
                    usuario.generoOrientador = "M";

                clsNMembership userM = new clsNMembership();
                userM.email = txtEmail.Text;
                userM.lowEmail = txtEmail.Text.ToLower();
                userM.username = txtUserName.Text;
                userM.lowUsername = txtUserName.Text.ToLower();
                userM.id = int.Parse(txtIdUsuario.Text);
                if (objDUsuario.D_actualizarUsuario(usuario, userM))
                {
                    Response.Write("<script>window.alert('Resultado Actualización: CORRECTO');</script>");

                }
                else
                {
                    Response.Write("<script>window.alert('Resultado Actualización: INCORRECTO, Vuelva a intentarlo');</script>");
                    Cargar();
                    cargarMemberhsip();
                }

            }
        }

    }
}

    