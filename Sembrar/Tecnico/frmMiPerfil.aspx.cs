using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar.Tecnico
{
    public partial class frmMiPerfil : System.Web.UI.Page
    {
            clsNUsuario LogUsuario = new clsNUsuario();
            clsUsuario objDUsuario = new clsUsuario();
            clsNMembership objeNMembership = new clsNMembership();
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    Cargar();
                    cargarMemberhsip();
                }

            }

            protected void cargarMemberhsip()
            {
                objeNMembership = objDUsuario.cargarUsuarioMembership(int.Parse(txtIdUsuario.Text));
                txtEmail.Text = objeNMembership.email;
                txtUserName.Text = objeNMembership.username;

            }

            private void Cargar()
            {
                System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
                LogUsuario = objDUsuario.obtenerDatosUsuarioCompleto(logUser.UserName.ToString());
                txtNombreUsuario.Text = LogUsuario.nombre;
                txtApellidoUsuario.Text = LogUsuario.appellido;
                txtIdUsuario.Text = LogUsuario.idUser.ToString();
                if (LogUsuario.genero == "M")
                    ddlGeneroUsuario.SelectedValue = "2";
                else if (LogUsuario.genero == "F")
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
                    clsNUsuario usuario = new clsNUsuario();
                    usuario.idUser = int.Parse(txtIdUsuario.Text);
                    usuario.nombre = txtNombreUsuario.Text;
                    usuario.appellido = txtApellidoUsuario.Text;
                    if (ddlGeneroUsuario.SelectedValue == "1")
                        usuario.genero = "F";
                    if (ddlGeneroUsuario.SelectedValue == "2")
                        usuario.genero = "M";

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

    