using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar.Administrador
{
    public partial class frmManejoPass : System.Web.UI.Page
    {
        clsNUsuario objNUsuario = new clsNUsuario();
        clsUsuario objDUsuario = new clsUsuario();
        clsNMembership objeNMembership = new clsNMembership();
        clsOrientador objNOrientador = new clsOrientador();
        clsDOrientador objDOrientador = new clsDOrientador();
        protected void Page_Load(object sender, EventArgs e)
        {
            panelNuevaPass.Visible = false;
        }

        protected void ddlTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                btnGenerarContraseña.Enabled = true;
                ddlUsuario.Enabled = true;
                ddlUsuario.Items.Clear();

                var usuario = objDUsuario.consultaOrientador();
                ddlUsuario.Enabled = true;

                if (int.Parse(ddlTipoUsuario.SelectedValue) == 1)
                {
                    usuario = objDUsuario.consultaUsuario("Administrador");
                }

                else if (int.Parse(ddlTipoUsuario.SelectedValue) == 2)
                {
                    usuario = objDUsuario.consultaUsuario("Tecnico");
                }

                else if (int.Parse(ddlTipoUsuario.SelectedValue) == 3)
                {
                    usuario = objDUsuario.consultaUsuario("Coordinador");
                }
                else if (int.Parse(ddlTipoUsuario.SelectedValue) == 4)
                {
                    usuario = objDUsuario.consultaUsuario("Digitador");
                }
                else if (int.Parse(ddlTipoUsuario.SelectedValue) == 0)
                {
                    ddlUsuario.Items.Clear();
                    ddlUsuario.Items.Insert(0, "<No Hay Usuarios>");
                    btnGenerarContraseña.Enabled = false;
                    ddlUsuario.Enabled = false;
                }
                else
                {
                    usuario = objDUsuario.consultaOrientador();
                }
                ddlUsuario.DataSource = usuario;
                ddlUsuario.DataTextField = "nombre";
                ddlUsuario.DataValueField = "id";
                ddlUsuario.DataBind();
                ddlUsuario.Visible = true;

            }
            catch (Exception ex)
            {
                ddlUsuario.Items.Insert(0, "<No Hay Usuarios>");
                btnGenerarContraseña.Enabled = false;
            }

        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnGenerarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
                objNUsuario = objDUsuario.obtenerDatosUsuarioCompleto(logUser.UserName.ToString());
                int idUserLog = objNUsuario.idUser;
                string nPass = objDUsuario.RandomString(12);
                if (int.Parse(ddlTipoUsuario.SelectedValue) == 3)
                {
                    nPass = objDUsuario.RandomString(12);
                    txtContrasenia.Text = nPass;
                    objNOrientador.IDOrientador1 = int.Parse(ddlUsuario.SelectedValue);
                    objNOrientador.pass = nPass;
                    if (objDOrientador.actualizarPass(objNOrientador))
                    {
                        Response.Write("<script>window.alert('Resultado Actualización: CORRECTO');</script>");
                        bloquear();
                    }
                }
                else
                {
                    if (idUserLog != int.Parse(ddlUsuario.SelectedValue))
                    {
                        nPass = objDUsuario.RandomString(12);
                        objNUsuario.idUser = int.Parse(ddlUsuario.SelectedValue);
                        objNUsuario.pass = nPass;
                        txtContrasenia.Text = nPass;
                        if (objDUsuario.actualizarPass(objNUsuario))
                        {
                            Response.Write("<script>window.alert('Resultado Actualización: CORRECTO');</script>");
                            bloquear();
                        }
                    }

                    else
                    {
                        Response.Write("<script>window.alert('Si desea cambiar su contraseña debe ir a MiPerfil');</script>");
                    }
                }
            }

            catch (Exception)
            {
                Response.Write("<script>window.alert('Resultado Actualización: INCORRECTO');</script>");

            }
        }
        protected void bloquear()
        {
            ddlTipoUsuario.Enabled = false;
            ddlUsuario.Enabled = false;
            btnGenerarContraseña.Enabled = false;
            panelNuevaPass.Visible = true;

        }

        protected void desbloquear()
        {
            panelNuevaPass.Visible = false;
            ddlTipoUsuario.Enabled = true;
            ddlUsuario.Enabled = true;
            btnGenerarContraseña.Enabled = true;

        }

        protected void btnOtroUsuario_Click(object sender, EventArgs e)
        {
            desbloquear();
            txtContrasenia.Text = "";
        }
    }
}