using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Sembrar.Administrador
{
    public partial class EliminarParentesco : System.Web.UI.Page
    {
        clsDatosParentesco objDatosParentesco = new clsDatosParentesco();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(ddlParentesco.SelectedItem.Value);

                if (objDatosParentesco.eliminarParentesco(id))
                {
                    string script = "alert(\"Objetivo Eliminado con éxito!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                    ddlParentesco.DataBind();
                }
                else
                {
                    string script = "alert(\"Porfavor verifica, algo ha salido mal!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                }
            }
            catch (Exception)
            {
                string script = "alert(\"Porfavor verifica, algo ha salido mal!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}