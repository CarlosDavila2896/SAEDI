using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Administrador
{
    public partial class ActualizarParentesco : System.Web.UI.Page
    {
        clsParentesco objParentesco = new clsParentesco();
        clsDatosParentesco objDatosParentesco = new clsDatosParentesco();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlParentesco_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNombreParentesco.Enabled = true;
            btnActualizar.Enabled = true;

            try
            {
                objParentesco = objDatosParentesco.obtenerParentesco(Convert.ToInt32(ddlParentesco.SelectedValue.ToString()));
                txtNombreParentesco.Text = objParentesco.NombreParentesco;
            }
            catch (Exception)
            {
                string script = "alert(\"Error al cargar los datos!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            objParentesco.Codigo = int.Parse(ddlParentesco.SelectedValue.ToString());
            objParentesco.NombreParentesco = txtNombreParentesco.Text;

            try
            {
                if (objDatosParentesco.actualizarParentesco(objParentesco))
                {
                    string script = "alert(\"Objetivo Editado!\");";
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
            finally
            {
                txtNombreParentesco.Text = "";
            }
        }
    }
}