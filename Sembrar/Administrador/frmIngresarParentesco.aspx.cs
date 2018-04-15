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
    public partial class IngresarParentesco : System.Web.UI.Page
    {
        clsParentesco objParentesco = new clsParentesco();
        clsDatosParentesco objDatosParentesco = new clsDatosParentesco();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            objParentesco.NombreParentesco = txtParentesco.Text;

            try
            {

                if (txtParentesco.Text.Trim().Length>0 && objDatosParentesco.ingresarParentesco(objParentesco))
                {
                    Response.Write(@"
     <script>
        alert('Ingreso  Correcto .');
        setTimeout(function(){            
            window.location = '" + Request.RawUrl + @"';
        }, 10);
    </script>
");
                    
                    txtParentesco.Text = "";
                }
                else
                {
                    string script = "alert(\"Porfavor verifica los datos ingresados, algo ha salido mal!\");";
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