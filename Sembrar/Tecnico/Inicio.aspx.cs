using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar.Tecnico
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
                CapaNegocio.clsNUsuario usuario = new CapaNegocio.clsNUsuario();
                CapaDatos.clsUsuario objDatosPerfil = new CapaDatos.clsUsuario();
                usuario = objDatosPerfil.obtenerDatosUsuario(logUser.UserName.ToString());
                lblMiPerfil.Text = "Hola " + usuario.nombre;
            }
            catch (Exception ex)
            {

            }

        }
    }
}