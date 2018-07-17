using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar.Administrador
{
    public partial class frmManejoUsuarios : System.Web.UI.Page
    {
        clsNUsuario objNUsuario = new clsNUsuario();
        clsUsuario objDUsuario = new clsUsuario();
        clsNMembership objeNMembership = new clsNMembership();
        clsOrientador objNOrientador = new clsOrientador();
        clsDOrientador objDOrientador = new clsDOrientador();

        protected void deshabilitarU()
        {
            txtNombreUsuario.Enabled = false;
            txtApellidoUsuario.Enabled = false;
            ddlGeneroUsuario.Enabled = false;
            ddlEstado.Enabled = false;
        }
        protected void habilitarU()
        {
            txtNombreUsuario.Enabled = true;
            txtApellidoUsuario.Enabled = true;
            ddlGeneroUsuario.Enabled = true;
            ddlEstado.Enabled = true;

        }
        protected void deshabilitarM()
        {
            txtUserName.Enabled = false;
            txtEmail.Enabled = false;
        }
        protected void habilitarM()
        {
            txtUserName.Enabled = false;
            txtEmail.Enabled = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            deshabilitarM();
            deshabilitarU();
            btnActualizarUsuario.Enabled = false;
            if (!IsPostBack)
            {
                lstUsuario.Enabled = false;
                lstUsuario.Visible = false;
            }
        }

        protected void ddlTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                deshabilitarM();
                deshabilitarU();
                btnActualizarUsuario.Enabled = false;
                lstUsuario.Items.Clear();
                var usuario = objDUsuario.consultaOrientador();
                lstUsuario.Enabled = true;

                if (int.Parse(ddlTipoUsuario.SelectedValue) == 0)
                {
                    lstUsuario.Items.Clear();
                    lstUsuario.Items.Insert(0, "<No Hay Usuarios>");
                    btnActualizarUsuario.Enabled = false;
                    lstUsuario.Enabled = false;
                    deshabilitarM();
                    deshabilitarU();
                }


                if (int.Parse(ddlTipoUsuario.SelectedValue) == 1)
                {
                    usuario = objDUsuario.consultaUsuario("Administrador");
                    lstUsuario.Enabled = true;
                }

                else if (int.Parse(ddlTipoUsuario.SelectedValue) == 2)
                {
                    usuario = objDUsuario.consultaUsuario("Tecnico");
                    lstUsuario.Enabled = true;
                }

                else if (int.Parse(ddlTipoUsuario.SelectedValue) == 3)
                {
                    usuario = objDUsuario.consultaUsuario("Coordinador");
                    lstUsuario.Enabled = true;
                }
                else if (int.Parse(ddlTipoUsuario.SelectedValue) == 4)
                {
                    usuario = objDUsuario.consultaUsuario("Digitador");
                    lstUsuario.Enabled = true;
                }

                lstUsuario.DataSource = usuario;
                lstUsuario.DataTextField = "nombre";
                lstUsuario.DataValueField = "id";
                lstUsuario.DataBind();
                lstUsuario.Visible = true;


                cargarUsuario();
                cargarMemberhsip();
                habilitarM();
                habilitarU();
                btnActualizarUsuario.Enabled = true;
            }
            catch (Exception ex)
            {
                lstUsuario.Items.Clear();
                lstUsuario.Items.Insert(0, "<No Hay Usuarios>");
                btnActualizarUsuario.Enabled = false;
                lstUsuario.Enabled = false;
                deshabilitarM();
                deshabilitarU();
            }

        }

        protected void cargarUsuario()
        {
            try
            {
                if (int.Parse(ddlTipoUsuario.SelectedValue) < 5 && int.Parse(ddlTipoUsuario.SelectedValue) > 0)
                {
                    objNUsuario = objDUsuario.obtenerDatosUsuarioID(int.Parse(lstUsuario.SelectedValue.ToString()));
                    txtNombreUsuario.Text = objNUsuario.nombre;
                    txtApellidoUsuario.Text = objNUsuario.appellido;
                    txtIdUsuario.Text = objNUsuario.idUser.ToString();
                    if (objNUsuario.genero == "M")
                        ddlGeneroUsuario.SelectedValue = "2";
                    else if (objNUsuario.genero == "F")
                        ddlGeneroUsuario.SelectedValue = "1";
                    else
                        ddlGeneroUsuario.SelectedValue = "0";
                    ddlEstado.SelectedValue = objNUsuario.estado.ToString();
                }
                if (int.Parse(ddlTipoUsuario.SelectedValue) == 5)
                {
                    objNOrientador = objDOrientador.D_consultarOrientadores(int.Parse(lstUsuario.SelectedValue.ToString()));
                    txtNombreUsuario.Text = objNOrientador.NombreOrientador;
                    txtApellidoUsuario.Text = objNOrientador.apellidoOrientador;
                    txtIdUsuario.Text = objNOrientador.IDOrientador1.ToString();
                    if (objNOrientador.generoOrientador == "M")
                        ddlGeneroUsuario.SelectedValue = "2";
                    else if (objNOrientador.generoOrientador == "F")
                        ddlGeneroUsuario.SelectedValue = "1";
                    else
                        ddlGeneroUsuario.SelectedValue = "0";
                    ddlEstado.SelectedValue = objNOrientador.estadoOrientador.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void cargarMemberhsip()
        {
            if (int.Parse(ddlTipoUsuario.SelectedValue) < 5 && int.Parse(ddlTipoUsuario.SelectedValue) > 0)
            {
                int id;
                int.TryParse(lstUsuario.SelectedValue.ToString(), out id);
                objeNMembership = objDUsuario.cargarUsuarioMembership(id);
                txtEmail.Text = objeNMembership.email;
                txtUserName.Text = objeNMembership.username;
            }
            if (int.Parse(ddlTipoUsuario.SelectedValue) == 5)
            {
                int id;
                int.TryParse(lstUsuario.SelectedValue.ToString(), out id);
                objeNMembership = objDOrientador.cargarOrientadorMembership(id);
                txtUserName.Text = objeNMembership.username;
                txtEmail.Text = objeNMembership.email;
            }

        }

        protected void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            if (ddlGeneroUsuario.SelectedValue == "0")
            {
                Response.Write("<script>window.alert('Resultado Actualización: INCORRECTO');</script>");
            }
            else if (int.Parse(ddlTipoUsuario.SelectedValue) < 5 && int.Parse(ddlTipoUsuario.SelectedValue) > 0)
            {
                clsNMembership userM = new clsNMembership();
                userM.email = txtEmail.Text;
                userM.lowEmail = txtEmail.Text.ToLower();
                userM.username = txtUserName.Text;
                userM.lowUsername = txtUserName.Text.ToLower();
                userM.id = int.Parse(txtIdUsuario.Text);
                clsNUsuario usuario = new clsNUsuario();
                usuario.idUser = int.Parse(txtIdUsuario.Text);
                usuario.nombre = txtNombreUsuario.Text;
                usuario.appellido = txtApellidoUsuario.Text;
                if (ddlGeneroUsuario.SelectedValue == "1")
                    usuario.genero = "F";
                if (ddlGeneroUsuario.SelectedValue == "2")
                    usuario.genero = "M";
                usuario.estado = bool.Parse(ddlEstado.SelectedValue);

                if (objDUsuario.D_actualizarUsuario(usuario, userM))
                {
                    Response.Write("<script>window.alert('Resultado Actualización: CORRECTO');</script>");
                    cargarUsuario();
                    cargarMemberhsip();
                }
                else
                {
                    Response.Write("<script>window.alert('Resultado Actualización: INCORRECTO, Vuelva a intentarlo');</script>");
                }
            }
            else if (int.Parse(ddlTipoUsuario.SelectedValue) == 5)
            {
                clsNMembership userMe = new clsNMembership();
                userMe.email = txtEmail.Text;
                userMe.lowEmail = txtEmail.Text.ToLower();
                userMe.username = txtUserName.Text;
                userMe.lowUsername = txtUserName.Text.ToLower();
                userMe.id = int.Parse(txtIdUsuario.Text);

                clsOrientador usuario = new clsOrientador();
                usuario.IDOrientador1 = int.Parse(txtIdUsuario.Text);
                usuario.NombreOrientador = txtNombreUsuario.Text;
                usuario.apellidoOrientador = txtApellidoUsuario.Text;
                if (ddlGeneroUsuario.SelectedValue == "1")
                    usuario.generoOrientador = "F";
                if (ddlGeneroUsuario.SelectedValue == "2")
                    usuario.generoOrientador = "M";
                usuario.estadoOrientador = bool.Parse(ddlEstado.SelectedValue);

                if (objDOrientador.D_actualizarUsuario(usuario, userMe))
                {
                    Response.Write("<script>window.alert('Resultado Actualización: CORRECTO');</script>");
                    cargarUsuario();
                    cargarMemberhsip();
                }

                else
                {
                    Response.Write("<script>window.alert('Resultado Actualización: INCORRECTO, Vuelva a intentarlo');</script>");
                }
            }
            else
            {
                cargarUsuario();
                cargarMemberhsip();
            }
        }
        private void limpiar()
        {
            txtIdUsuario.Text = "";
            txtNombreUsuario.Text = "";
            txtApellidoUsuario.Text = "";
            ddlGeneroUsuario.SelectedValue = "0";
            ddlEstado.SelectedValue = "true";
            txtUserName.Text = "";
            txtEmail.Text = "";
            lstUsuario.Items.Clear();
            lstUsuario.Enabled = false;
        }

        protected void lstUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarUsuario();
            cargarMemberhsip();
            habilitarM();
            habilitarU();
            btnActualizarUsuario.Enabled = true;
        }
    }
}