using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace Sembrar.Digitador
{
    public partial class CrearFamilia : System.Web.UI.Page
    {
   
        clsDatosAsignarFamilia DatoObjFamilia = new clsDatosAsignarFamilia();
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            clsNFamilia familia = new clsNFamilia();
            familia.NOMBREFAMILIA = txtNombre.Text;
            familia.OBSERVACIONFAMILIA = "";
            familia.DIRECCIONFAMILIA = txtDireccion.Text;
            familia.MIEMBROSFAMILIA = 0;
            if (DatoObjFamilia.ingresaFamilia(familia)){
                Response.Write(@"
     <script>
        alert('! La Familia Se ha Ingresado  Correctamente!');
        setTimeout(function(){            
            window.location = '" + Request.RawUrl + @"';
        }, 10);
    </script>
");
            }
            else
            {
                MsgBox("Hubo un error, no se completo el ingreso de la familia!", this.Page, this);
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}