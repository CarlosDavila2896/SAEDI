using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar.Orientador
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.Web.Security.MembershipUser logUser = System.Web.Security.Membership.GetUser(User.Identity.Name);
                CapaNegocio.clsOrientador usuario = new CapaNegocio.clsOrientador();
                CapaDatos.clsDOrientador objDatosPerfil = new CapaDatos.clsDOrientador();
                usuario = objDatosPerfil.D_consultarOrientador(logUser.UserName.ToString());
                Session["id"] = usuario.IDOrientador1;
                lblMiPerfil.Text = "Hola " + usuario.NombreOrientador;
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}